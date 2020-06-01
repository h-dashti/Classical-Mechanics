namespace MechanicalSimulations
{
    partial class FormRollerAndSpring
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxg = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelShape = new System.Windows.Forms.Label();
            this.toolStripShapes = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHump = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInfinity = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCardiod = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonButterfly = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOval = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSpiral = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCircle = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxR0 = new System.Windows.Forms.TextBox();
            this.textBoxk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxb = new System.Windows.Forms.TextBox();
            this.textBoxv0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPath = new System.Windows.Forms.NumericUpDown();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            this.toolStripShapes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPath)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 281;
            this.label10.Text = "Initial Values :";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(351, 426);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 275;
            this.labelX.Text = "labelX";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.SystemColors.Control;
            this.labelY.ForeColor = System.Drawing.Color.Blue;
            this.labelY.Location = new System.Drawing.Point(124, 86);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 274;
            this.labelY.Text = "labelY";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 273;
            this.label12.Text = "Axes x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 272;
            this.label13.Text = "Axes y";
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(118, 446);
            this.buttonMoreDetail.Name = "buttonMoreDetail";
            this.buttonMoreDetail.Size = new System.Drawing.Size(85, 23);
            this.buttonMoreDetail.TabIndex = 267;
            this.buttonMoreDetail.Text = "More Detail";
            this.buttonMoreDetail.UseVisualStyleBackColor = true;
            this.buttonMoreDetail.Click += new System.EventHandler(this.buttonMoreDetail_Click);
            // 
            // checkBoxConnectDots
            // 
            this.checkBoxConnectDots.AutoSize = true;
            this.checkBoxConnectDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConnectDots.Location = new System.Drawing.Point(354, 451);
            this.checkBoxConnectDots.Name = "checkBoxConnectDots";
            this.checkBoxConnectDots.Size = new System.Drawing.Size(91, 17);
            this.checkBoxConnectDots.TabIndex = 266;
            this.checkBoxConnectDots.Text = "Connect Dots";
            this.checkBoxConnectDots.UseVisualStyleBackColor = true;
            this.checkBoxConnectDots.CheckedChanged += new System.EventHandler(this.checkBoxConnectDots_CheckedChanged);
            // 
            // buttonRedrawPoints
            // 
            this.buttonRedrawPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedrawPoints.Location = new System.Drawing.Point(520, 56);
            this.buttonRedrawPoints.Name = "buttonRedrawPoints";
            this.buttonRedrawPoints.Size = new System.Drawing.Size(85, 21);
            this.buttonRedrawPoints.TabIndex = 265;
            this.buttonRedrawPoints.Text = "Redraw Points";
            this.buttonRedrawPoints.UseVisualStyleBackColor = true;
            this.buttonRedrawPoints.Click += new System.EventHandler(this.buttonRedrawPoints_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(627, 448);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 21);
            this.buttonStop.TabIndex = 264;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(519, 448);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 248;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // comboBoxX
            // 
            this.comboBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "x",
            "y",
            "v",
            "s",
            "At",
            "F_spring",
            "Mechanical E",
            "t",
            "",
            "--"});
            this.comboBoxX.Location = new System.Drawing.Point(6, 418);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 20);
            this.comboBoxX.TabIndex = 263;
            this.comboBoxX.Text = "x";
            this.comboBoxX.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "x",
            "y",
            "v",
            "s",
            "At",
            "F_spring",
            "Mechanical E",
            "t",
            "",
            "--"});
            this.comboBoxY.Location = new System.Drawing.Point(6, 374);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 20);
            this.comboBoxY.TabIndex = 262;
            this.comboBoxY.Text = "y";
            this.comboBoxY.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(412, 56);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(85, 21);
            this.buttonClearGraph.TabIndex = 260;
            this.buttonClearGraph.Text = "Clear Graph";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // buttonResetData
            // 
            this.buttonResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetData.Location = new System.Drawing.Point(118, 56);
            this.buttonResetData.Name = "buttonResetData";
            this.buttonResetData.Size = new System.Drawing.Size(85, 21);
            this.buttonResetData.TabIndex = 259;
            this.buttonResetData.Text = "Reset Data";
            this.buttonResetData.UseVisualStyleBackColor = true;
            this.buttonResetData.Click += new System.EventHandler(this.buttonResetData_Click);
            // 
            // pictureBoxCurve
            // 
            this.pictureBoxCurve.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCurve.Location = new System.Drawing.Point(118, 83);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(487, 359);
            this.pictureBoxCurve.TabIndex = 258;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(601, 83);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(364, 359);
            this.pictureBoxAnimate.TabIndex = 257;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 12);
            this.label7.TabIndex = 288;
            this.label7.Text = "g";
            // 
            // textBoxg
            // 
            this.textBoxg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxg.Location = new System.Drawing.Point(56, 184);
            this.textBoxg.Name = "textBoxg";
            this.textBoxg.Size = new System.Drawing.Size(43, 18);
            this.textBoxg.TabIndex = 289;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(971, 83);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(51, 12);
            this.labelResult.TabIndex = 290;
            this.labelResult.Text = "labelResult";
            // 
            // labelShape
            // 
            this.labelShape.AutoSize = true;
            this.labelShape.BackColor = System.Drawing.SystemColors.Control;
            this.labelShape.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShape.ForeColor = System.Drawing.Color.Blue;
            this.labelShape.Location = new System.Drawing.Point(743, 84);
            this.labelShape.Name = "labelShape";
            this.labelShape.Size = new System.Drawing.Size(89, 22);
            this.labelShape.TabIndex = 292;
            this.labelShape.Text = "laelShape";
            // 
            // toolStripShapes
            // 
            this.toolStripShapes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHump,
            this.toolStripButtonInfinity,
            this.toolStripButtonCardiod,
            this.toolStripButtonButterfly,
            this.toolStripButtonOval,
            this.toolStripButtonSpiral,
            this.toolStripButtonCircle});
            this.toolStripShapes.Location = new System.Drawing.Point(0, 0);
            this.toolStripShapes.Name = "toolStripShapes";
            this.toolStripShapes.Size = new System.Drawing.Size(1048, 40);
            this.toolStripShapes.TabIndex = 293;
            this.toolStripShapes.Text = "toolStripShape";
            // 
            // toolStripButtonHump
            // 
            this.toolStripButtonHump.Image = global::MechanicalSimulations.Properties.Resources.BitmapHump;
            this.toolStripButtonHump.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHump.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonHump.Name = "toolStripButtonHump";
            this.toolStripButtonHump.Size = new System.Drawing.Size(79, 37);
            this.toolStripButtonHump.Text = "Hump";
            this.toolStripButtonHump.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonInfinity
            // 
            this.toolStripButtonInfinity.Image = global::MechanicalSimulations.Properties.Resources.BittmapInfinity;
            this.toolStripButtonInfinity.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonInfinity.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonInfinity.Name = "toolStripButtonInfinity";
            this.toolStripButtonInfinity.Size = new System.Drawing.Size(85, 37);
            this.toolStripButtonInfinity.Text = "Infinity";
            this.toolStripButtonInfinity.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonCardiod
            // 
            this.toolStripButtonCardiod.Image = global::MechanicalSimulations.Properties.Resources.BitmapCardiod;
            this.toolStripButtonCardiod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCardiod.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonCardiod.Name = "toolStripButtonCardiod";
            this.toolStripButtonCardiod.Size = new System.Drawing.Size(87, 37);
            this.toolStripButtonCardiod.Text = "Cardiod";
            this.toolStripButtonCardiod.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonButterfly
            // 
            this.toolStripButtonButterfly.Image = global::MechanicalSimulations.Properties.Resources.BitmapButterfly;
            this.toolStripButtonButterfly.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonButterfly.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonButterfly.Name = "toolStripButtonButterfly";
            this.toolStripButtonButterfly.Size = new System.Drawing.Size(96, 37);
            this.toolStripButtonButterfly.Text = "Butterfly";
            this.toolStripButtonButterfly.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonOval
            // 
            this.toolStripButtonOval.Image = global::MechanicalSimulations.Properties.Resources.BitmapOval;
            this.toolStripButtonOval.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOval.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonOval.Name = "toolStripButtonOval";
            this.toolStripButtonOval.Size = new System.Drawing.Size(59, 37);
            this.toolStripButtonOval.Text = "Oval";
            this.toolStripButtonOval.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonSpiral
            // 
            this.toolStripButtonSpiral.Image = global::MechanicalSimulations.Properties.Resources.BitmapSpiral;
            this.toolStripButtonSpiral.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSpiral.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonSpiral.Name = "toolStripButtonSpiral";
            this.toolStripButtonSpiral.Size = new System.Drawing.Size(78, 37);
            this.toolStripButtonSpiral.Text = "Spiral";
            this.toolStripButtonSpiral.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // toolStripButtonCircle
            // 
            this.toolStripButtonCircle.Image = global::MechanicalSimulations.Properties.Resources.BitmapCircle;
            this.toolStripButtonCircle.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonCircle.Name = "toolStripButtonCircle";
            this.toolStripButtonCircle.Size = new System.Drawing.Size(57, 37);
            this.toolStripButtonCircle.Text = "Circle";
            this.toolStripButtonCircle.Click += new System.EventHandler(this.ChangeMainShapes);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxR0);
            this.groupBox1.Controls.Add(this.textBoxk);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 69);
            this.groupBox1.TabIndex = 294;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "about Spring";
            // 
            // textBoxR0
            // 
            this.textBoxR0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR0.Location = new System.Drawing.Point(45, 39);
            this.textBoxR0.Name = "textBoxR0";
            this.textBoxR0.Size = new System.Drawing.Size(43, 18);
            this.textBoxR0.TabIndex = 298;
            // 
            // textBoxk
            // 
            this.textBoxk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxk.Location = new System.Drawing.Point(45, 19);
            this.textBoxk.Name = "textBoxk";
            this.textBoxk.Size = new System.Drawing.Size(43, 18);
            this.textBoxk.TabIndex = 297;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 12);
            this.label3.TabIndex = 295;
            this.label3.Text = "k";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 296;
            this.label4.Text = "R0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxb);
            this.groupBox2.Controls.Add(this.textBoxv0);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxm);
            this.groupBox2.Location = new System.Drawing.Point(6, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 82);
            this.groupBox2.TabIndex = 295;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "about Mass";
            // 
            // textBoxb
            // 
            this.textBoxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb.Location = new System.Drawing.Point(50, 61);
            this.textBoxb.Name = "textBoxb";
            this.textBoxb.Size = new System.Drawing.Size(43, 18);
            this.textBoxb.TabIndex = 293;
            // 
            // textBoxv0
            // 
            this.textBoxv0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxv0.Location = new System.Drawing.Point(50, 19);
            this.textBoxv0.Name = "textBoxv0";
            this.textBoxv0.Size = new System.Drawing.Size(43, 18);
            this.textBoxv0.TabIndex = 289;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 288;
            this.label1.Text = "v0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 290;
            this.label2.Text = "m";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 12);
            this.label6.TabIndex = 291;
            this.label6.Text = "b";
            // 
            // textBoxm
            // 
            this.textBoxm.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm.Location = new System.Drawing.Point(50, 41);
            this.textBoxm.Name = "textBoxm";
            this.textBoxm.Size = new System.Drawing.Size(43, 18);
            this.textBoxm.TabIndex = 292;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(971, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 297;
            this.label5.Text = "Path points\r\n interval";
            // 
            // numericUpDownPath
            // 
            this.numericUpDownPath.DecimalPlaces = 7;
            this.numericUpDownPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPath.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.numericUpDownPath.Location = new System.Drawing.Point(973, 386);
            this.numericUpDownPath.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownPath.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.numericUpDownPath.Name = "numericUpDownPath";
            this.numericUpDownPath.Size = new System.Drawing.Size(75, 18);
            this.numericUpDownPath.TabIndex = 296;
            this.numericUpDownPath.Tag = "";
            this.numericUpDownPath.Value = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownPath.ValueChanged += new System.EventHandler(this.numericUpDownPath_ValueChanged);
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(209, 446);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 298;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // FormRollerAndSpring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1028, 483);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripShapes);
            this.Controls.Add(this.labelShape);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.buttonRedrawPoints);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonResetData);
            this.Controls.Add(this.pictureBoxCurve);
            this.Controls.Add(this.pictureBoxAnimate);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "FormRollerAndSpring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Roller  Spring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRollerAndSpring_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            this.toolStripShapes.ResumeLayout(false);
            this.toolStripShapes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxg;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelShape;
        private System.Windows.Forms.ToolStrip toolStripShapes;
        private System.Windows.Forms.ToolStripButton toolStripButtonHump;
        private System.Windows.Forms.ToolStripButton toolStripButtonInfinity;
        private System.Windows.Forms.ToolStripButton toolStripButtonCardiod;
        private System.Windows.Forms.ToolStripButton toolStripButtonButterfly;
        private System.Windows.Forms.ToolStripButton toolStripButtonOval;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpiral;
        private System.Windows.Forms.ToolStripButton toolStripButtonCircle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxR0;
        private System.Windows.Forms.TextBox textBoxk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxb;
        private System.Windows.Forms.TextBox textBoxv0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownPath;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}