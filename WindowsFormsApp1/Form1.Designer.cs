namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.frequencyVisualizer = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nColorBoxControl1 = new Nevron.Nov.WinFormControls.NColorBoxControl();
            this.label9 = new System.Windows.Forms.Label();
            this.nColorBoxControl2 = new Nevron.Nov.WinFormControls.NColorBoxControl();
            this.nColorBoxControl3 = new Nevron.Nov.WinFormControls.NColorBoxControl();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuBox = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.nColorBoxControl4 = new Nevron.Nov.WinFormControls.NColorBoxControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.frequencyVisualizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // frequencyVisualizer
            // 
            this.frequencyVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frequencyVisualizer.Location = new System.Drawing.Point(12, 13);
            this.frequencyVisualizer.Name = "frequencyVisualizer";
            this.frequencyVisualizer.Size = new System.Drawing.Size(814, 186);
            this.frequencyVisualizer.TabIndex = 0;
            this.frequencyVisualizer.TabStop = false;
            this.toolTip1.SetToolTip(this.frequencyVisualizer, "Top: Master\r\nMiddle: Left Stereo\r\nBottom Right Stereo");
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(628, 20);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = -100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(90, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(602, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Slope";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(729, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Animate";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(780, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(465, 53);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(402, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Exaggerate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(15, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Placement";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(371, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Bars";
            // 
            // nColorBoxControl1
            // 
            this.nColorBoxControl1.AutoSize = false;
            this.nColorBoxControl1.DesignTimeState = resources.GetString("nColorBoxControl1.DesignTimeState");
            this.nColorBoxControl1.Location = new System.Drawing.Point(405, 22);
            this.nColorBoxControl1.Name = "nColorBoxControl1";
            this.nColorBoxControl1.Size = new System.Drawing.Size(57, 18);
            this.nColorBoxControl1.TabIndex = 15;
            this.nColorBoxControl1.SelectedColorChanged += new Nevron.Nov.Function<Nevron.Nov.Dom.NValueChangeEventArgs>(this.nColorBoxControl1_SelectedColorChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(468, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Background";
            // 
            // nColorBoxControl2
            // 
            this.nColorBoxControl2.AutoSize = false;
            this.nColorBoxControl2.DesignTimeState = resources.GetString("nColorBoxControl2.DesignTimeState");
            this.nColorBoxControl2.Location = new System.Drawing.Point(539, 22);
            this.nColorBoxControl2.Name = "nColorBoxControl2";
            this.nColorBoxControl2.Size = new System.Drawing.Size(57, 18);
            this.nColorBoxControl2.TabIndex = 17;
            this.nColorBoxControl2.SelectedColorChanged += new Nevron.Nov.Function<Nevron.Nov.Dom.NValueChangeEventArgs>(this.nColorBoxControl2_SelectedColorChanged);
            // 
            // nColorBoxControl3
            // 
            this.nColorBoxControl3.AutoSize = false;
            this.nColorBoxControl3.DesignTimeState = resources.GetString("nColorBoxControl3.DesignTimeState");
            this.nColorBoxControl3.Location = new System.Drawing.Point(308, 22);
            this.nColorBoxControl3.Name = "nColorBoxControl3";
            this.nColorBoxControl3.Size = new System.Drawing.Size(57, 18);
            this.nColorBoxControl3.TabIndex = 19;
            this.nColorBoxControl3.SelectedColorChanged += new Nevron.Nov.Function<Nevron.Nov.Dom.NValueChangeEventArgs>(this.nColorBoxControl3_SelectedColorChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(276, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "App";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(240, 23);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 21;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(181, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Hide Menu";
            // 
            // menuBox
            // 
            this.menuBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuBox.Controls.Add(this.comboBox1);
            this.menuBox.Controls.Add(this.label3);
            this.menuBox.Controls.Add(this.checkBox7);
            this.menuBox.Controls.Add(this.nColorBoxControl4);
            this.menuBox.Controls.Add(this.label2);
            this.menuBox.Controls.Add(this.label1);
            this.menuBox.Controls.Add(this.checkBox6);
            this.menuBox.Controls.Add(this.label12);
            this.menuBox.Controls.Add(this.checkBox5);
            this.menuBox.Controls.Add(this.label4);
            this.menuBox.Controls.Add(this.label7);
            this.menuBox.Controls.Add(this.checkBox4);
            this.menuBox.Controls.Add(this.trackBar1);
            this.menuBox.Controls.Add(this.label11);
            this.menuBox.Controls.Add(this.nColorBoxControl3);
            this.menuBox.Controls.Add(this.label5);
            this.menuBox.Controls.Add(this.label10);
            this.menuBox.Controls.Add(this.checkBox1);
            this.menuBox.Controls.Add(this.nColorBoxControl2);
            this.menuBox.Controls.Add(this.label6);
            this.menuBox.Controls.Add(this.label9);
            this.menuBox.Controls.Add(this.checkBox2);
            this.menuBox.Controls.Add(this.nColorBoxControl1);
            this.menuBox.Controls.Add(this.label8);
            this.menuBox.Location = new System.Drawing.Point(12, 205);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(814, 86);
            this.menuBox.TabIndex = 22;
            this.menuBox.TabStop = false;
            this.menuBox.Text = "Menu";
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.comboBox1.DisplayMember = "Normal";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal",
            "Top",
            "Behind"});
            this.comboBox1.Location = new System.Drawing.Point(72, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.ValueMember = "Normal";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(310, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Bar Shadow";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(381, 53);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 29;
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // nColorBoxControl4
            // 
            this.nColorBoxControl4.AutoSize = false;
            this.nColorBoxControl4.DesignTimeState = resources.GetString("nColorBoxControl4.DesignTimeState");
            this.nColorBoxControl4.Location = new System.Drawing.Point(247, 49);
            this.nColorBoxControl4.Name = "nColorBoxControl4";
            this.nColorBoxControl4.Size = new System.Drawing.Size(57, 18);
            this.nColorBoxControl4.TabIndex = 27;
            this.nColorBoxControl4.SelectedColorChanged += new Nevron.Nov.Function<Nevron.Nov.Dom.NValueChangeEventArgs>(this.nColorBoxControl4_SelectedColorChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(181, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Chroma Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(106, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Flip Bars";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(157, 52);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 25;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(15, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Vertical Bars";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(82, 52);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 303);
            this.Controls.Add(this.menuBox);
            this.Controls.Add(this.frequencyVisualizer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Volume Visualizer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frequencyVisualizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuBox.ResumeLayout(false);
            this.menuBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox frequencyVisualizer;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Nevron.Nov.WinFormControls.NColorBoxControl nColorBoxControl1;
        private System.Windows.Forms.Label label9;
        private Nevron.Nov.WinFormControls.NColorBoxControl nColorBoxControl2;
        private Nevron.Nov.WinFormControls.NColorBoxControl nColorBoxControl3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox menuBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox6;
        private Nevron.Nov.WinFormControls.NColorBoxControl nColorBoxControl4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

