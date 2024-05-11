namespace ColorsContrastIGA
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
            this.generate = new System.Windows.Forms.Button();
            this.showCrossProb = new System.Windows.Forms.Label();
            this.showProb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.crossoverProb = new System.Windows.Forms.TrackBar();
            this.mutationProb = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.gen_random = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.GroupBox();
            this.buttTextCheck = new System.Windows.Forms.CheckBox();
            this.mainBackCheck = new System.Windows.Forms.CheckBox();
            this.buttBackCheck = new System.Windows.Forms.CheckBox();
            this.bannCheck = new System.Windows.Forms.CheckBox();
            this.normCheck = new System.Windows.Forms.CheckBox();
            this.boldCheck = new System.Windows.Forms.CheckBox();
            this.backCheck = new System.Windows.Forms.CheckBox();
            this.updateButt = new System.Windows.Forms.Button();
            this.BackBut = new System.Windows.Forms.Button();
            this.colorPick = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttForeButton = new System.Windows.Forms.Button();
            this.textBackButton = new System.Windows.Forms.Button();
            this.banBackButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.boldButton = new System.Windows.Forms.Button();
            this.buttBackButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autoAesthetic = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.applyButt = new System.Windows.Forms.Button();
            this.bannerText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.crossoverProb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProb)).BeginInit();
            this.Options.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(1112, 795);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(127, 57);
            this.generate.TabIndex = 0;
            this.generate.Text = "Generate New Mix";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // showCrossProb
            // 
            this.showCrossProb.AutoSize = true;
            this.showCrossProb.BackColor = System.Drawing.SystemColors.Control;
            this.showCrossProb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.showCrossProb.Location = new System.Drawing.Point(1212, 628);
            this.showCrossProb.Name = "showCrossProb";
            this.showCrossProb.Size = new System.Drawing.Size(27, 13);
            this.showCrossProb.TabIndex = 29;
            this.showCrossProb.Text = "80%";
            // 
            // showProb
            // 
            this.showProb.AutoSize = true;
            this.showProb.BackColor = System.Drawing.SystemColors.Control;
            this.showProb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.showProb.Location = new System.Drawing.Point(1206, 677);
            this.showProb.Name = "showProb";
            this.showProb.Size = new System.Drawing.Size(27, 13);
            this.showProb.TabIndex = 28;
            this.showProb.Text = "80%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(1101, 628);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Design Consistency";
            // 
            // crossoverProb
            // 
            this.crossoverProb.BackColor = System.Drawing.SystemColors.Control;
            this.crossoverProb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crossoverProb.Location = new System.Drawing.Point(1104, 644);
            this.crossoverProb.Maximum = 5;
            this.crossoverProb.Name = "crossoverProb";
            this.crossoverProb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.crossoverProb.Size = new System.Drawing.Size(144, 45);
            this.crossoverProb.TabIndex = 24;
            this.crossoverProb.Value = 4;
            this.crossoverProb.Scroll += new System.EventHandler(this.crossoverProb_Scroll_1);
            // 
            // mutationProb
            // 
            this.mutationProb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mutationProb.BackColor = System.Drawing.SystemColors.Control;
            this.mutationProb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mutationProb.Location = new System.Drawing.Point(1099, 693);
            this.mutationProb.Maximum = 8;
            this.mutationProb.Name = "mutationProb";
            this.mutationProb.Size = new System.Drawing.Size(148, 45);
            this.mutationProb.TabIndex = 26;
            this.mutationProb.Tag = "";
            this.mutationProb.Value = 7;
            this.mutationProb.Scroll += new System.EventHandler(this.mutationProb_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(1101, 677);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Design Variability";
            // 
            // gen_random
            // 
            this.gen_random.Location = new System.Drawing.Point(1112, 758);
            this.gen_random.Name = "gen_random";
            this.gen_random.Size = new System.Drawing.Size(127, 31);
            this.gen_random.TabIndex = 30;
            this.gen_random.Text = "Generate Random";
            this.gen_random.UseVisualStyleBackColor = true;
            this.gen_random.Click += new System.EventHandler(this.gen_random_Click);
            // 
            // Options
            // 
            this.Options.Controls.Add(this.buttTextCheck);
            this.Options.Controls.Add(this.mainBackCheck);
            this.Options.Controls.Add(this.buttBackCheck);
            this.Options.Controls.Add(this.bannCheck);
            this.Options.Controls.Add(this.normCheck);
            this.Options.Controls.Add(this.boldCheck);
            this.Options.Controls.Add(this.backCheck);
            this.Options.Location = new System.Drawing.Point(1104, 4);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(146, 179);
            this.Options.TabIndex = 31;
            this.Options.TabStop = false;
            this.Options.Text = "Color Lock";
            // 
            // buttTextCheck
            // 
            this.buttTextCheck.AutoSize = true;
            this.buttTextCheck.Location = new System.Drawing.Point(10, 155);
            this.buttTextCheck.Name = "buttTextCheck";
            this.buttTextCheck.Size = new System.Drawing.Size(104, 17);
            this.buttTextCheck.TabIndex = 44;
            this.buttTextCheck.Text = "Button Forecolor";
            this.buttTextCheck.UseVisualStyleBackColor = true;
            this.buttTextCheck.CheckedChanged += new System.EventHandler(this.buttTextCheck_CheckedChanged);
            // 
            // mainBackCheck
            // 
            this.mainBackCheck.AutoSize = true;
            this.mainBackCheck.Location = new System.Drawing.Point(10, 132);
            this.mainBackCheck.Name = "mainBackCheck";
            this.mainBackCheck.Size = new System.Drawing.Size(128, 17);
            this.mainBackCheck.TabIndex = 43;
            this.mainBackCheck.Text = "Text Main Back Color";
            this.mainBackCheck.UseVisualStyleBackColor = true;
            this.mainBackCheck.CheckedChanged += new System.EventHandler(this.mainBackCheck_CheckedChanged);
            // 
            // buttBackCheck
            // 
            this.buttBackCheck.AutoSize = true;
            this.buttBackCheck.Location = new System.Drawing.Point(10, 40);
            this.buttBackCheck.Name = "buttBackCheck";
            this.buttBackCheck.Size = new System.Drawing.Size(112, 17);
            this.buttBackCheck.TabIndex = 42;
            this.buttBackCheck.Text = "Button Back Color";
            this.buttBackCheck.UseVisualStyleBackColor = true;
            this.buttBackCheck.CheckedChanged += new System.EventHandler(this.buttBackCheck_CheckedChanged_1);
            // 
            // bannCheck
            // 
            this.bannCheck.AutoSize = true;
            this.bannCheck.Location = new System.Drawing.Point(10, 63);
            this.bannCheck.Name = "bannCheck";
            this.bannCheck.Size = new System.Drawing.Size(87, 17);
            this.bannCheck.TabIndex = 41;
            this.bannCheck.Text = "Banner Color";
            this.bannCheck.UseVisualStyleBackColor = true;
            this.bannCheck.CheckedChanged += new System.EventHandler(this.bannCheck_CheckedChanged_1);
            // 
            // normCheck
            // 
            this.normCheck.AutoSize = true;
            this.normCheck.Location = new System.Drawing.Point(10, 109);
            this.normCheck.Name = "normCheck";
            this.normCheck.Size = new System.Drawing.Size(94, 17);
            this.normCheck.TabIndex = 40;
            this.normCheck.Text = "Normal Letters";
            this.normCheck.UseVisualStyleBackColor = true;
            this.normCheck.CheckedChanged += new System.EventHandler(this.normCheck_CheckedChanged_1);
            // 
            // boldCheck
            // 
            this.boldCheck.AutoSize = true;
            this.boldCheck.Location = new System.Drawing.Point(10, 86);
            this.boldCheck.Name = "boldCheck";
            this.boldCheck.Size = new System.Drawing.Size(82, 17);
            this.boldCheck.TabIndex = 39;
            this.boldCheck.Text = "Bold Letters";
            this.boldCheck.UseVisualStyleBackColor = true;
            this.boldCheck.CheckedChanged += new System.EventHandler(this.boldCheck_CheckedChanged_1);
            // 
            // backCheck
            // 
            this.backCheck.AutoSize = true;
            this.backCheck.Location = new System.Drawing.Point(9, 19);
            this.backCheck.Name = "backCheck";
            this.backCheck.Size = new System.Drawing.Size(111, 17);
            this.backCheck.TabIndex = 38;
            this.backCheck.Text = "Background Color";
            this.backCheck.UseVisualStyleBackColor = true;
            this.backCheck.CheckedChanged += new System.EventHandler(this.backCheck_CheckedChanged_1);
            // 
            // updateButt
            // 
            this.updateButt.Location = new System.Drawing.Point(1112, 721);
            this.updateButt.Name = "updateButt";
            this.updateButt.Size = new System.Drawing.Size(127, 31);
            this.updateButt.TabIndex = 37;
            this.updateButt.Text = "Refresh";
            this.updateButt.UseVisualStyleBackColor = true;
            this.updateButt.Click += new System.EventHandler(this.updateButt_Click);
            // 
            // BackBut
            // 
            this.BackBut.Location = new System.Drawing.Point(10, 15);
            this.BackBut.Name = "BackBut";
            this.BackBut.Size = new System.Drawing.Size(127, 31);
            this.BackBut.TabIndex = 35;
            this.BackBut.Text = "Background";
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttForeButton);
            this.groupBox1.Controls.Add(this.textBackButton);
            this.groupBox1.Controls.Add(this.banBackButton);
            this.groupBox1.Controls.Add(this.normalButton);
            this.groupBox1.Controls.Add(this.boldButton);
            this.groupBox1.Controls.Add(this.BackBut);
            this.groupBox1.Controls.Add(this.buttBackButton);
            this.groupBox1.Location = new System.Drawing.Point(1104, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 262);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Background Color Input";
            // 
            // buttForeButton
            // 
            this.buttForeButton.Location = new System.Drawing.Point(9, 225);
            this.buttForeButton.Name = "buttForeButton";
            this.buttForeButton.Size = new System.Drawing.Size(127, 31);
            this.buttForeButton.TabIndex = 48;
            this.buttForeButton.Text = "Button Forecolor";
            this.buttForeButton.UseVisualStyleBackColor = true;
            this.buttForeButton.Click += new System.EventHandler(this.buttForeButton_Click);
            // 
            // textBackButton
            // 
            this.textBackButton.Location = new System.Drawing.Point(10, 190);
            this.textBackButton.Name = "textBackButton";
            this.textBackButton.Size = new System.Drawing.Size(127, 31);
            this.textBackButton.TabIndex = 47;
            this.textBackButton.Text = "Text Area Back Color";
            this.textBackButton.UseVisualStyleBackColor = true;
            this.textBackButton.Click += new System.EventHandler(this.textBackButton_Click);
            // 
            // banBackButton
            // 
            this.banBackButton.Location = new System.Drawing.Point(10, 85);
            this.banBackButton.Name = "banBackButton";
            this.banBackButton.Size = new System.Drawing.Size(127, 31);
            this.banBackButton.TabIndex = 44;
            this.banBackButton.Text = "Banner Color";
            this.banBackButton.UseVisualStyleBackColor = true;
            this.banBackButton.Click += new System.EventHandler(this.banBackButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.Location = new System.Drawing.Point(10, 155);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(127, 31);
            this.normalButton.TabIndex = 46;
            this.normalButton.Text = "Normal Text Color";
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // boldButton
            // 
            this.boldButton.Location = new System.Drawing.Point(10, 120);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(127, 31);
            this.boldButton.TabIndex = 45;
            this.boldButton.Text = "Bold Text Color";
            this.boldButton.UseVisualStyleBackColor = true;
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // buttBackButton
            // 
            this.buttBackButton.Location = new System.Drawing.Point(10, 50);
            this.buttBackButton.Name = "buttBackButton";
            this.buttBackButton.Size = new System.Drawing.Size(127, 31);
            this.buttBackButton.TabIndex = 43;
            this.buttBackButton.Text = "Button Background";
            this.buttBackButton.UseVisualStyleBackColor = true;
            this.buttBackButton.Click += new System.EventHandler(this.buttBackButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.autoAesthetic);
            this.groupBox2.Location = new System.Drawing.Point(1104, 566);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 59);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aesthetic Measure";
            // 
            // autoAesthetic
            // 
            this.autoAesthetic.Location = new System.Drawing.Point(10, 19);
            this.autoAesthetic.Name = "autoAesthetic";
            this.autoAesthetic.Size = new System.Drawing.Size(127, 31);
            this.autoAesthetic.TabIndex = 39;
            this.autoAesthetic.Text = "Auto Design";
            this.autoAesthetic.UseVisualStyleBackColor = true;
            this.autoAesthetic.Click += new System.EventHandler(this.autoAesthetic_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 860);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1266, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.applyButt);
            this.groupBox3.Controls.Add(this.bannerText);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(1104, 453);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(146, 107);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Banner Text";
            // 
            // applyButt
            // 
            this.applyButt.Location = new System.Drawing.Point(12, 74);
            this.applyButt.Name = "applyButt";
            this.applyButt.Size = new System.Drawing.Size(127, 31);
            this.applyButt.TabIndex = 2;
            this.applyButt.Text = "Apply";
            this.applyButt.UseVisualStyleBackColor = true;
            this.applyButt.Click += new System.EventHandler(this.applyButt_Click);
            // 
            // bannerText
            // 
            this.bannerText.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannerText.Location = new System.Drawing.Point(10, 37);
            this.bannerText.MaxLength = 8;
            this.bannerText.Name = "bannerText";
            this.bannerText.Size = new System.Drawing.Size(130, 30);
            this.bannerText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banner Text (Max 8 chars)";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(713, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(145, 23);
            this.btnBrowse.TabIndex = 43;
            this.btnBrowse.Text = "Add Banner Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(285, 20);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(422, 20);
            this.txtFileName.TabIndex = 44;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 882);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.updateButt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.gen_random);
            this.Controls.Add(this.showCrossProb);
            this.Controls.Add(this.showProb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.crossoverProb);
            this.Controls.Add(this.mutationProb);
            this.Controls.Add(this.generate);
            this.Name = "Form1";
            this.Text = "Colors IGA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crossoverProb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProb)).EndInit();
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label showCrossProb;
        private System.Windows.Forms.Label showProb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar crossoverProb;
        private System.Windows.Forms.TrackBar mutationProb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button gen_random;
        private System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.ColorDialog colorPick;
        private System.Windows.Forms.Button BackBut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox bannCheck;
        private System.Windows.Forms.CheckBox normCheck;
        private System.Windows.Forms.CheckBox boldCheck;
        private System.Windows.Forms.CheckBox backCheck;
        private System.Windows.Forms.Button updateButt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button autoAesthetic;
        private System.Windows.Forms.CheckBox buttBackCheck;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox mainBackCheck;
        private System.Windows.Forms.CheckBox buttTextCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox bannerText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButt;
        private System.Windows.Forms.Button buttForeButton;
        private System.Windows.Forms.Button textBackButton;
        private System.Windows.Forms.Button banBackButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button buttBackButton;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;

    }
}

