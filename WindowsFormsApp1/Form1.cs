using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public bool listen = true;
        public Thread LTS;
        public SolidBrush Color_background = new System.Drawing.SolidBrush(Color.GhostWhite);
        public Pen Color_bar = new System.Drawing.Pen(Color.FromArgb(80, 240, 123));
        public Pen Color_bar_drop = new System.Drawing.Pen(Color.FromArgb(0, 160, 103));
        public float Bar_drop_size = 10;
        public float Bar_length_inc = 1f;
        public float Bar_length_scale = 0f;
        public float Time_Tickrate = 1 / 10f;

        public float time;
        public bool Animate = false;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = 0;

            LTS = new Thread(ListenToSterio);
            LTS.Start();
        }

        private void ListenToSterio()
        {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            while (true)
            {
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

        private Bitmap CreateBars(float master, float left, float right)
        {
            Bitmap img = new Bitmap(frequencyVisualizer.Width, frequencyVisualizer.Height);
            Graphics mockup = Graphics.FromImage(img);

            //   |####################|
            //   |#######             |
            //   |############________|

            mockup.FillRectangle(Color_background, 0, 0, img.Width, img.Height);   // Background

            // Fill a bar for master
            for (int i = 0; i < img.Height/3; i++)
            {
                float length = img.Width * master + i * Bar_length_inc;
                if (i < img.Height / 3 - Bar_drop_size)
                {
                    mockup.DrawLine(Color_bar, 0, i, length, i);
                }
                else
                {
                    mockup.DrawLine(Color_bar_drop, 0, i, length, i);
                }
            }

            // Fill a bar for left speaker
            for (int j = img.Height/3; j < img.Height/3 * 2; j++)
            {
                float length = img.Width * left + j * Bar_length_inc;
                if (j < img.Height / 3 * 2 - Bar_drop_size)
                {
                    mockup.DrawLine(Color_bar, 0, j, length, j);
                }
                else
                {
                    mockup.DrawLine(Color_bar_drop, 0, j, length, j);
                }
            }

            // Fill a bar for right speaker
            for (int k = img.Height/3 * 2; k < img.Height/3 * 3; k++)
            {
                float length = img.Width * right + k * Bar_length_inc;
                if (k < img.Height / 3 * 3 - Bar_drop_size)
                {
                    mockup.DrawLine(Color_bar, 0, k, length, k);
                }
                else
                {
                    mockup.DrawLine(Color_bar_drop, 0, k, length, k);
                }
            }

            return img;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bar_length_scale = (float)trackBar1.Value / 100;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Animate = checkBox1.Checked;
        }
    }
}
