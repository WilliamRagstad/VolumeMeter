using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualBasic;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Nevron.Nov.Graphics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region ProgramFiles
        
        public static string AppData = $@"C:\Users\{Environment.UserName}\AppData\Local\";
        public static string VolumeMeter = AppData + @"VolumeMeter\";
        public static string UserPresets = VolumeMeter + @"presets.txt";



        public void SetupFileSystem()
        {
            if (!Directory.Exists(VolumeMeter))
            {
                Directory.CreateDirectory(VolumeMeter);
            }
        }

        #endregion

        #region Settings
        public bool listen = true;
        public Thread LTS;
        public static Color ControlColor = SystemColors.Control;
        public static Color ChromaKey = Color.DeepPink;
        public static SolidBrush Color_background = new System.Drawing.SolidBrush(Color.GhostWhite);
        public static Pen Color_bar = new System.Drawing.Pen(Color.FromArgb(80, 240, 123));
        public static Pen Color_bar_drop = new System.Drawing.Pen(Color.FromArgb(80, 0, 0, 60));
        public static Pen Color_bar_drop_custom = new System.Drawing.Pen(Color.Red);
        public static float Bar_drop_size = 10;
        public static float Bar_length_inc = 1f;
        public static float Bar_length_scale = 0f;
        public static float Time_Tickrate = 1 / 10f;
        public static Bitmap PrevFrame;
        public int DeactivatedLocationDiff_x = 8;
        public int DeactivatedLocationDiff_y = 31;
        public int HideMenuPadding = 5;

        public float time;
        public static bool Animate = false;
        public static bool Exaggerate = false;
        public static string OnTop = "Top";
        public static bool HideMenu = true;
        public static bool VerticalBars = false;
        public static bool FlipBars = false;

        public IntPtr hwndf;
        public IntPtr hwndParent;
        public IntPtr defaultParent;

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr FindWindow(
            [MarshalAs(UnmanagedType.LPTStr)] string lpClassName,
            [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(
            IntPtr hWndChild,      // handle to window
            IntPtr hWndNewParent   // new parent window
        );
        [DllImport("user32.dll")]
        public static extern IntPtr ShowWindow(
            IntPtr hWnd,      // handle to window
            uint nCmdShow
        );
        private const uint SW_RESTORE = 0x09;
        private const uint SW_SHOW = 0x05;

        #endregion

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = 0;

            LTS = new Thread(ListenToSterio);
            LTS.SetApartmentState(ApartmentState.STA);
            LTS.Start();
            
            hwndf = Handle;
            hwndParent = FindWindow("ProgMan", "Program Manager");

            SetupFileSystem();
            UpdateControls();
            LoadAllUserPresets();
            LoadAllPresets();
        }

        private void ListenToSterio()
        {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            while (true)
            {
                if (OnTop == "Normal")
                {
                    TopMost = false;
                }
                else if (OnTop == "Top" && Form.ActiveForm == null)
                {
                    TopMost = true;
                }
                else if (OnTop == "Behind")
                {
                    TopMost = false;

                    // "Behind"
                    SetParent(hwndf,hwndParent);
                    ShowWindow(hwndf, SW_RESTORE);

                    if ((Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) && Keyboard.IsKeyDown(Key.F12))
                    {
                        comboBox1.SelectedIndex = 0;
                        OnTop = "Normal";
                        SetParent(hwndf, new IntPtr(0));
                        Thread.Sleep(1000);
                        TopMost = true;
                        ShowWindow(Handle, SW_RESTORE);
                        Focus();
                    }
                }

                if (Animate)
                {
                    time += Time_Tickrate;
                    Bar_length_inc = (float) Math.Sin(time) * Bar_length_scale;
                }
                else
                {
                    Bar_length_inc = Bar_length_scale;
                }

                if (listen)
                {
                    var m = defaultDevice.AudioMeterInformation.MasterPeakValue;    // Master
                    var l = defaultDevice.AudioMeterInformation.PeakValues[0];      // left
                    var r = defaultDevice.AudioMeterInformation.PeakValues[1];      // right

                    if (!m.Equals(0))
                    {
                        // Send information to the form
                        frequencyVisualizer.Image = CreateBars(m, l, r);
                        Thread.Sleep(40);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LTS.Abort();
            listen = false;
        }

        private Bitmap img;
        private Graphics mockup;

        private Bitmap CreateBars(float master, float left, float right)
        {
            if (PrevFrame != null && (frequencyVisualizer.Width == 0 || frequencyVisualizer.Height == 0))
            {
                return PrevFrame;
            }

            if (Exaggerate)
            {
                master = master * master * master * 10;
                left = left * left * left * 10;
                right = right * right * right * 10;
            }


            img = new Bitmap(frequencyVisualizer.Width, frequencyVisualizer.Height);
            mockup = Graphics.FromImage(img);

            //   |####################|
            //   |#######             |
            //   |############________|

            mockup.FillRectangle(Color_background, 0, 0, img.Width, img.Height);   // Background

            // Set bar color
            Pen barDropColor = checkBox3.Checked ? Color_bar_drop_custom : Color_bar_drop;

            if (VerticalBars)
            {
                // Fill a bar for master
                for (int i = 0; i < img.Width/3; i++)
                {
                    float length = img.Height * master + i * Bar_length_inc;
                    if (i < img.Width / 3 - img.Width / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, i, 0, i, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, i, img.Height, i, img.Height-length);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, i, 0, i, length);
                            mockup.DrawLine(barDropColor, i, 0, i, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, i, img.Height, i, img.Height-length);
                            mockup.DrawLine(barDropColor, i, img.Height, i, img.Height-length);
                        }
                    }
                }

                // Fill a bar for left speaker
                for (int j = img.Width/3; j < img.Width/3 * 2; j++)
                {
                    float length = img.Height * left + j * Bar_length_inc;
                    if (j < img.Width / 3 * 2 - img.Width / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, j, 0, j, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, j, img.Height, j, img.Height-length);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, j, 0, j, length);
                            mockup.DrawLine(barDropColor, j, 0, j, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, j, img.Height, j, img.Height-length);
                            mockup.DrawLine(barDropColor, j, img.Height, j, img.Height-length);
                        }
                    }
                }

                // Fill a bar for right speaker
                for (int k = img.Width/3 * 2; k <= img.Width/3 * 3; k++)
                {
                    float length = img.Height * right + k * Bar_length_inc;
                    if (k <= img.Width / 3 * 3 - img.Width / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, k, 0, k, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, k, img.Height, k, img.Height-length);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, k, 0, k, length);
                            mockup.DrawLine(barDropColor, k, 0, k, length);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, k, img.Height, k, img.Height-length);
                            mockup.DrawLine(barDropColor, k, img.Height, k, img.Height-length);
                        }
                    }
                }
            }
            else
            {
                // Fill a bar for master
                for (int i = 0; i < img.Height/3; i++)
                {
                    float length = img.Width * master + i * Bar_length_inc;
                    if (i < img.Height / 3 - img.Height / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width,  i, img.Width-length, i);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, i, length, i);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width, i, img.Width-length, i);
                            mockup.DrawLine(barDropColor, img.Width, i, img.Width-length, i);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, i, length, i);
                            mockup.DrawLine(barDropColor, 0, i, length, i);
                        }
                    }
                }

                // Fill a bar for left speaker
                for (int j = img.Height/3; j < img.Height/3 * 2; j++)
                {
                    float length = img.Width * left + j * Bar_length_inc;
                    if (j < img.Height / 3 * 2 - img.Height / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width, j, img.Width-length, j);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, j, length, j);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width, j, img.Width-length, j);
                            mockup.DrawLine(barDropColor, img.Width, j, img.Width-length, j);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, j, length, j);
                            mockup.DrawLine(barDropColor, 0, j, length, j);
                        }
                    }
                }

                // Fill a bar for right speaker
                for (int k = img.Height/3 * 2; k <= img.Height/3 * 3; k++)
                {
                    float length = img.Width * right + k * Bar_length_inc;
                    if (k <= img.Height / 3 * 3 - img.Height / 3 * Bar_drop_size/100)
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width,  k, img.Width-length, k);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, k, length, k);
                        }
                    }
                    else
                    {
                        if (FlipBars)
                        {
                            mockup.DrawLine(Color_bar, img.Width, k, img.Width-length, k);
                            mockup.DrawLine(barDropColor, img.Width, k, img.Width-length, k);
                        }
                        else
                        {
                            mockup.DrawLine(Color_bar, 0, k, length, k);
                            mockup.DrawLine(barDropColor, 0, k, length, k);
                        }
                    }
                }
            }

            mockup.Dispose();
            PrevFrame = img;
            return img;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (Math.Abs(trackBar1.Value) < 10)
            {
                trackBar1.Value = 0;
            }

            Bar_length_scale = (float)trackBar1.Value / 100;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Animate = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Exaggerate = checkBox2.Checked;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                if (HideMenu)
                {
                    Size = new Size(Width, Height+menuBox.Height + HideMenuPadding);
                    frequencyVisualizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
                else
                {
                    Size = new Size(Width, Height);
                }
                FormBorderStyle = FormBorderStyle.Sizable;

                // Move window a bit
                Location = new Point(Location.X - DeactivatedLocationDiff_x, Location.Y - DeactivatedLocationDiff_y);

                menuBox.Show();
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                if (HideMenu)
                {
                    frequencyVisualizer.Anchor = AnchorStyles.Top;
                    menuBox.Hide();

                    Size = new Size(Width, Height-menuBox.Height-HideMenuPadding);
                }
                else
                {
                    Size = new Size(Width, Height);
                }
                FormBorderStyle = FormBorderStyle.None;

                // Move window a bit
                Location = new Point(Location.X + DeactivatedLocationDiff_x, Location.Y + DeactivatedLocationDiff_y);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            HideMenu = checkBox4.Checked;
        }

        private void nColorBoxControl1_SelectedColorChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            NColor c = (Nevron.Nov.Graphics.NColor) arg.NewValue;
            Color_bar.Color = Color.FromArgb(c.R, c.G, c.B);
        }

        private void nColorBoxControl2_SelectedColorChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            NColor c = (Nevron.Nov.Graphics.NColor) arg.NewValue;
            Color_background.Color = Color.FromArgb(c.R, c.G, c.B);
        }

        private void nColorBoxControl3_SelectedColorChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            NColor c = (Nevron.Nov.Graphics.NColor) arg.NewValue;
            BackColor = Color.FromArgb(c.R, c.G, c.B);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            VerticalBars = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            FlipBars = checkBox6.Checked;
        }

        private void nColorBoxControl4_SelectedColorChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            NColor c = (Nevron.Nov.Graphics.NColor) arg.NewValue;
            TransparencyKey = Color.FromArgb(c.R, c.G, c.B);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnTop = comboBox1.SelectedItem.ToString();
            if (OnTop == "Behind")
            {
                MessageBox.Show("OBS! Seems like you are trying to place the program below the desktop icons! Remember to use SHIFT + F12 to resume to normal mode!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Bar_drop_size = trackBar2.Value;
        }

        private void presetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            if (presetBox.SelectedItem != null)
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load preset
            if (!LoadPreset(presetBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Failed to load selected preset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string presetName = string.Empty;
            while (presetName.Replace("#","").Trim() == String.Empty)
            {
                presetName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Save current configuration as preset.\nPlease enter a name:", "New Preset", "New Preset");
            }

            NewPreset(presetName.Replace("#",""));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (presetBox.SelectedIndex >= 0)
            {
                string selectedPreset = presetBox.SelectedItem.ToString();
                string selectedPresetName = selectedPreset.Split('|')[0].Trim();

                PresetClass prclass = new PresetClass();
                Preset preset = prclass.GetByName(selectedPresetName);
                Preset p = Pr.GetByName(selectedPresetName);

                if (!Pr.PresetIsNull(p))
                {
                    // Remove the preset file in case it's an user preset!
                    if (Pr.PresetIsNull(preset))
                    {
                        // It only exists inside the Pr class, which means it's a user element
                        if (MessageBox.Show($"Are you sure you want to remove {selectedPresetName}?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            // Remove it from the list
                            presetBox.Items.RemoveAt(presetBox.SelectedIndex);
                            Pr.Presets.Remove(p);
                            
                            File.Delete(UserPresets);
                            foreach (var pre in Pr.Presets)
                            {
                                if (pre.isUsermade)
                                {
                                    // Print to file
                                    File.AppendAllText(UserPresets, pre.ToSaveableString());
                                }
                            }

                            // Remove from file

                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't remove this built in preset!", "Can't remove!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"An error occured when trying to remove a preset! Seems like the preset does not exist! ({selectedPresetName})!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nColorBoxControl5_SelectedColorChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            checkBox3.Checked = true;
            NColor c = (Nevron.Nov.Graphics.NColor) arg.NewValue;
            Color_bar_drop_custom.Color = Color.FromArgb(c.R, c.G, c.B);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = int.MinValue;
            numericUpDown2.Minimum = int.MinValue;

            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown2.Maximum = int.MaxValue;

            numericUpDown1.Value = Top;
            numericUpDown2.Value = Left;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown3.Minimum = int.MinValue;
            numericUpDown4.Minimum = int.MinValue;

            numericUpDown3.Maximum = int.MaxValue;
            numericUpDown4.Maximum = int.MaxValue;
            
            numericUpDown3.Value = Height;
            numericUpDown4.Value = Width;
        }
    }
}
