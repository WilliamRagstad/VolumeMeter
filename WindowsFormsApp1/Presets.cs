using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nevron.Nov.Graphics;

namespace WindowsFormsApp1
{
    public class PresetClass
    {
        public List<Preset> Presets = new List<Preset>();

        public PresetClass()
        {
            Presets.Add(
                new Preset
                {
                    ID = Guid.NewGuid(),
                    Name = "Default",
                    isUsermade = false,
                    Color_bar = new Pen(Color.Green),
                    FlipBars = false,
                    Bar_length_scale = 0f,
                    ChromaKey = Color.AliceBlue,
                    ControlColor = Color.AliceBlue,
                    Color_background = new SolidBrush(Color.Fuchsia),
                    Bar_drop_size = 0
                }
            );
            Presets.Add(
                new Preset
                {
                    ID = Guid.NewGuid(),
                    Name = "Vertical Orange",
                    Color_bar = new Pen(Color.Coral),
                    Color_background = new SolidBrush(SystemColors.ControlDarkDark),
                    VerticalBars = true,
                    isUsermade = false
                }
            );
            Presets.Add(
                new Preset
                {
                    ID = Guid.NewGuid(),
                    Name = "Retro Slopes",
                    Color_bar = new Pen(Color.Aqua),
                    FlipBars = true,
                    Bar_length_scale = 2.3f,
                    ChromaKey = Color.AliceBlue,
                    ControlColor = Color.AliceBlue,
                    Color_background = new SolidBrush(Color.Fuchsia),
                    Bar_drop_size = 0,
                    isUsermade = false
                }
            );
            Presets.Add(
                new Preset
                {
                    ID = Guid.NewGuid(),
                    Name = "Ghost Bars",
                    Color_bar = new Pen(Color.GhostWhite),
                    Bar_length_scale = -0.5f,
                    Color_background = new SolidBrush(Color.GhostWhite),
                    Bar_drop_size = 83,
                    isUsermade = false
                }
            );
        }

        public Preset Get(string presetName)
        {
            // Find preset
            Preset match = null;
            foreach (var preset in Presets)
            {
                if (preset.ToStr().Trim() == presetName.Trim())
                {
                    match = preset;
                }
            }

            return match;
        }

        public Preset GetByName(string presetName)
        {
            // Find preset
            Preset match = null;
            foreach (var preset in Presets)
            {
                if (preset.ToStr().Split('|')[0].Trim() == presetName.Trim())
                {
                    match = preset;
                }
            }

            return match;
        }

        public bool PresetIsNull(Preset p)
        {
            return p == null || p.ID == Guid.Empty;
        }
    }

    public class Preset
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool isUsermade { get; set; }
        
        public Color ControlColor { get; set; } = Form1.ControlColor;
        public Color ChromaKey { get; set; } = Form1.ChromaKey;
        public SolidBrush Color_background { get; set; } = Form1.Color_background;
        public Pen Color_bar { get; set; } = Form1.Color_bar;
        public Pen Color_bar_drop { get; set; } = Form1.Color_bar_drop;
        public float Bar_drop_size { get; set; } = Form1.Bar_drop_size;
        public bool Animate { get; set; } = Form1.Animate;
        public bool Exaggerate { get; set; } = Form1.Exaggerate;
        public string OnTop { get; set; } = Form1.OnTop;
        public bool HideMenu { get; set; } = Form1.HideMenu;
        public float Bar_length_scale { get; set; } = Form1.Bar_length_scale;
        public bool VerticalBars { get; set; } = Form1.VerticalBars;
        public bool FlipBars { get; set; } = Form1.FlipBars;
        
        public int TopOffset { get; set; }
        public int LeftOffset { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        public string ToStr()
        {
            return Name + "                                                                                                  | " + ID;
        }

        public string ToSaveableString()
        {
            if (isUsermade)
            {
                StringBuilder sb = new StringBuilder();
            
                sb.AppendLine($"##{Name}##");
                sb.AppendLine($"ControlColor = {ControlColor.R}, {ControlColor.G}, {ControlColor.B}");
                sb.AppendLine($"ChromaKey = {ChromaKey.R}, {ChromaKey.G}, {ChromaKey.B}");
                sb.AppendLine($"Color_background = {Color_background.Color.A}, {Color_background.Color.R}, {Color_background.Color.G}, {Color_background.Color.B}");
                sb.AppendLine($"Color_bar = {Color_bar.Color.A}, {Color_bar.Color.R}, {Color_bar.Color.G}, {Color_bar.Color.B}");
                sb.AppendLine($"Color_bar_drop = {Color_bar_drop.Color.A}, {Color_bar_drop.Color.R}, {Color_bar_drop.Color.G}, {Color_bar_drop.Color.B}");
                sb.AppendLine($"Bar_drop_size = {Bar_drop_size}");
                sb.AppendLine($"Animate = {Animate}");
                sb.AppendLine($"Exaggerate = {Exaggerate}");
                sb.AppendLine($"OnTop = {OnTop}");
                sb.AppendLine($"HideMenu = {HideMenu}");
                sb.AppendLine($"Bar_length_scale = {Bar_length_scale}");
                sb.AppendLine($"VerticalBars = {VerticalBars}");
                sb.AppendLine($"FlipBars = {FlipBars}");
                sb.AppendLine($"TopOffset = {TopOffset}");
                sb.AppendLine($"LeftOffset = {LeftOffset}");
                sb.AppendLine($"WindowWidth = {WindowWidth}");
                sb.AppendLine($"WindowHeight = {WindowHeight}");
                sb.AppendLine("");

                return sb.ToString();
            }

            return String.Empty;
        }
    }

    public partial class Form1 : Form
    {
        public PresetClass Pr = new PresetClass();

        public void NewPreset(string name)
        {
            Pr.Presets.Add(
                new Preset
                {
                    ID = Guid.NewGuid(),
                    Name = name,
                    isUsermade = true,
                    Color_bar = Color_bar,
                    Bar_length_scale = Bar_length_scale,
                    Color_background = Color_background,
                    Bar_drop_size = Bar_drop_size,
                    Animate = Animate,
                    ChromaKey = ChromaKey,
                    Color_bar_drop = Color_bar_drop,
                    ControlColor = BackColor,
                    HideMenu = HideMenu,
                    Exaggerate = Exaggerate,
                    FlipBars = FlipBars,
                    VerticalBars = VerticalBars,
                    TopOffset = (int)numericUpDown1.Value,
                    LeftOffset = (int)numericUpDown2.Value,
                    WindowHeight = (int)numericUpDown3.Value,
                    WindowWidth = (int)numericUpDown4.Value
                }
            );

            LoadAllPresets();

            File.Delete(UserPresets);
            foreach (var preset in Pr.Presets)
            {
                if (preset.isUsermade)
                {
                    // Print to file
                    File.AppendAllText(UserPresets, preset.ToSaveableString());
                }
            }
        }

        public void LoadAllPresets()
        {

            presetBox.Items.Clear();
            foreach (var preset in Pr.Presets)
            {
                presetBox.Items.Add(preset.ToStr());
            }
        }

        public void LoadAllUserPresets()
        {
            if (File.Exists(UserPresets))
            {
                string[] content = File.ReadAllLines(UserPresets);

                Preset currentPreset = new Preset();

                foreach (string rline in content)
                {
                    string line = rline;
                    if (line.StartsWith("##") && line.EndsWith("##"))
                    {
                        // Add the old one and start a new
                        if (currentPreset.ID != Guid.Empty)
                        {
                            Pr.Presets.Add(currentPreset);
                            currentPreset = new Preset();
                        }
                        
                        currentPreset.ID = Guid.NewGuid();
                        currentPreset.isUsermade = true;
                        currentPreset.Name = line.Replace("#", "");
                    }
                    else
                    {
                        line = line.Replace(" ", "");
                    }
                    
                    if (line.StartsWith("ControlColor="))
                    {
                        currentPreset.ControlColor = ParseColor(line.Replace("ControlColor=", ""));
                    }
                    else if (line.StartsWith("ChromaKey="))
                    {
                        currentPreset.ChromaKey = ParseColor(line.Replace("ChromaKey=", ""));
                    }
                    else if (line.StartsWith("Color_background="))
                    {
                        currentPreset.Color_background.Color = ParseColor(line.Replace("Color_background=", ""));
                    }
                    else if (line.StartsWith("Color_bar="))
                    {
                        currentPreset.Color_bar.Color = ParseColor(line.Replace("Color_bar=", ""));
                    }
                    else if (line.StartsWith("Color_bar_drop="))
                    {
                        currentPreset.Color_bar_drop.Color = ParseColor(line.Replace("Color_bar_drop=", ""));
                    }
                    else if (line.StartsWith("Bar_drop_size="))
                    {
                        currentPreset.Bar_drop_size = float.Parse(line.Replace("Bar_drop_size=", ""));
                    }
                    else if (line.StartsWith("Animate="))
                    {
                        currentPreset.Animate = bool.Parse(line.Replace("Animate=", ""));
                    }
                    else if (line.StartsWith("Exaggerate="))
                    {
                        currentPreset.Exaggerate = bool.Parse(line.Replace("Exaggerate=", ""));
                    }
                    else if (line.StartsWith("OnTop="))
                    {
                        currentPreset.OnTop = line.Replace("OnTop=", "");
                    }
                    else if (line.StartsWith("HideMenu="))
                    {
                        currentPreset.HideMenu = bool.Parse(line.Replace("HideMenu=", ""));
                    }
                    else if (line.StartsWith("Bar_length_scale="))
                    {
                        currentPreset.Bar_length_scale = float.Parse(line.Replace("Bar_length_scale=", ""));
                    }
                    else if (line.StartsWith("VerticalBars="))
                    {
                        currentPreset.VerticalBars = bool.Parse(line.Replace("VerticalBars=", ""));
                    }
                    else if (line.StartsWith("FlipBars="))
                    {
                        currentPreset.FlipBars = bool.Parse(line.Replace("FlipBars=", ""));
                    }
                    else if (line.StartsWith("TopOffset="))
                    {
                        currentPreset.TopOffset = int.Parse(line.Replace("TopOffset=", ""));
                    }
                    else if (line.StartsWith("LeftOffset="))
                    {
                        currentPreset.LeftOffset = int.Parse(line.Replace("LeftOffset=", ""));
                    }
                    else if (line.StartsWith("WindowWidth="))
                    {
                        currentPreset.WindowWidth = int.Parse(line.Replace("WindowWidth=", ""));
                    }
                    else if (line.StartsWith("WindowHeight="))
                    {
                        currentPreset.WindowHeight = int.Parse(line.Replace("WindowHeight=", ""));
                    }
                }
                if (currentPreset.ID != Guid.Empty)
                {
                    Pr.Presets.Add(currentPreset);
                }
            }
        }

        public Color ParseColor(string col)
        {
            if (col.Contains(','))
            {
                string[] cols = col.Split(',');
                if (cols.Length == 3)
                {
                    // ControlColor=255, 0, 6
                    return Color.FromArgb(Convert.ToInt32(col.Split(',')[0]), Convert.ToInt32(col.Split(',')[1]), Convert.ToInt32(col.Split(',')[2]));
                }
                else if (cols.Length == 4)
                {
                    // ControlColor=50, 255, 0, 6
                    return Color.FromArgb(Convert.ToInt32(col.Split(',')[0]), Convert.ToInt32(col.Split(',')[1]), Convert.ToInt32(col.Split(',')[2]), Convert.ToInt32(col.Split(',')[3]));
                }
            }

            try
            {
                // ControlColor=Red
                return Color.FromName(col);
            }
            catch (Exception)
            {
                return Color.Empty;
            }
        }

        public bool LoadPreset(string presetString)
        {
            try
            {
                // Find preset
                Preset match = Pr.Get(presetString);

                // Load preset
                {
                    //ControlColor = match.ControlColor;
                    BackColor = match.ControlColor;
                    ChromaKey = match.ChromaKey;
                    Color_background = match.Color_background;
                    Color_bar = match.Color_bar;
                    Color_bar_drop = match.Color_bar_drop;
                    Color_background = match.Color_background;
                    Color_bar = match.Color_bar;
                    Color_bar_drop = match.Color_bar_drop;
                    Bar_drop_size = match.Bar_drop_size;
                    Bar_length_scale = match.Bar_length_scale;
                    VerticalBars = match.VerticalBars;
                    FlipBars = match.FlipBars;
                    Animate = match.Animate;
                    Exaggerate = match.Exaggerate;
                    OnTop = match.OnTop;
                    HideMenu = match.HideMenu;
                    Top = match.TopOffset;
                    Left = match.LeftOffset;
                    if (match.WindowWidth > 0) Width = match.WindowWidth;
                    if (match.WindowHeight > 0) Height = match.WindowHeight;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateControls()
        {
            frequencyVisualizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nColorBoxControl1.Widget.SelectedColor = new NColor(Color_bar.Color.R, Color_bar.Color.G, Color_bar.Color.B);
            nColorBoxControl2.Widget.SelectedColor = new NColor(Color_background.Color.R, Color_background.Color.G, Color_background.Color.B);
            nColorBoxControl3.Widget.SelectedColor = new NColor(ControlColor.R, ControlColor.G, ControlColor.B);
            nColorBoxControl4.Widget.SelectedColor = new NColor(ChromaKey.R, ChromaKey.G, ChromaKey.B, ChromaKey.A);
            frequencyVisualizer.BackColor = Color_background.Color;
            trackBar2.Value = (int)Bar_drop_size;
            trackBar1.Value = (int) Bar_length_scale * 100;
            TransparencyKey = ChromaKey;
            switch (OnTop)
            {
                case "Normal": comboBox1.SelectedIndex = 0; break;
                case "Top": comboBox1.SelectedIndex = 1; break;
                case "Behind": comboBox1.SelectedIndex = 2; break;
            }

            checkBox1.Checked = Animate;
            checkBox2.Checked = Exaggerate;
            checkBox4.Checked = HideMenu;
            checkBox5.Checked = VerticalBars;
            checkBox6.Checked = FlipBars;
        }
    }
}
