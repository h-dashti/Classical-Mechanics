namespace MechanicalSimulations
{
    partial class Form2DSingleSpring
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
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxm = new System.Windows.Forms.TextBox();
            this.textBoxk = new System.Windows.Forms.TextBox();
            this.textBoxvy = new System.Windows.Forms.TextBox();
            this.textBoxvx = new System.Windows.Forms.TextBox();
            this.textBoxy = new System.Windows.Forms.TextBox();
            this.textBoxx = new System.Windows.Forms.TextBox();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.checkBoxAnimate = new System.Windows.Forms.CheckBox();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.textBoxb = new System.Windows.Forms.TextBox();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(114, 462);
            this.buttonMoreDetail.Name = "buttonMoreDetail";
            this.buttonMoreDetail.Size = new System.Drawing.Size(85, 23);
            this.buttonMoreDetail.TabIndex = 133;
            this.buttonMoreDetail.Text = "More Detail";
            this.buttonMoreDetail.UseVisualStyleBackColor = true;
            this.buttonMoreDetail.Click += new System.EventHandler(this.buttonMoreDetail_Click);
            // 
            // checkBoxConnectDots
            // 
            this.checkBoxConnectDots.AutoSize = true;
            this.checkBoxConnectDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConnectDots.Location = new System.Drawing.Point(274, 24);
            this.checkBoxConnectDots.Name = "checkBoxConnectDots";
            this.checkBoxConnectDots.Size = new System.Drawing.Size(91, 17);
            this.checkBoxConnectDots.TabIndex = 132;
            this.checkBoxConnectDots.Text = "Connect Dots";
            this.checkBoxConnectDots.UseVisualStyleBackColor = true;
            this.checkBoxConnectDots.CheckedChanged += new System.EventHandler(this.checkBoxConnectDots_CheckedChanged);
            // 
            // buttonRedrawPoints
            // 
            this.buttonRedrawPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedrawPoints.Location = new System.Drawing.Point(506, 21);
            this.buttonRedrawPoints.Name = "buttonRedrawPoints";
            this.buttonRedrawPoints.Size = new System.Drawing.Size(85, 21);
            this.buttonRedrawPoints.TabIndex = 131;
            this.buttonRedrawPoints.Text = "Redraw Points";
            this.buttonRedrawPoints.UseVisualStyleBackColor = true;
            this.buttonRedrawPoints.Click += new System.EventHandler(this.buttonRedrawPoints_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(506, 464);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 21);
            this.buttonStop.TabIndex = 130;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(408, 464);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 129;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // textBoxm
            // 
            this.textBoxm.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm.Location = new System.Drawing.Point(34, 167);
            this.textBoxm.Name = "textBoxm";
            this.textBoxm.Size = new System.Drawing.Size(65, 18);
            this.textBoxm.TabIndex = 126;
            // 
            // textBoxk
            // 
            this.textBoxk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxk.Location = new System.Drawing.Point(34, 145);
            this.textBoxk.Name = "textBoxk";
            this.textBoxk.Size = new System.Drawing.Size(65, 18);
            this.textBoxk.TabIndex = 125;
            // 
            // textBoxvy
            // 
            this.textBoxvy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxvy.Location = new System.Drawing.Point(34, 118);
            this.textBoxvy.Name = "textBoxvy";
            this.textBoxvy.Size = new System.Drawing.Size(65, 18);
            this.textBoxvy.TabIndex = 124;
            // 
            // textBoxvx
            // 
            this.textBoxvx.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxvx.Location = new System.Drawing.Point(34, 94);
            this.textBoxvx.Name = "textBoxvx";
            this.textBoxvx.Size = new System.Drawing.Size(65, 18);
            this.textBoxvx.TabIndex = 123;
            // 
            // textBoxy
            // 
            this.textBoxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxy.Location = new System.Drawing.Point(34, 70);
            this.textBoxy.Name = "textBoxy";
            this.textBoxy.Size = new System.Drawing.Size(65, 18);
            this.textBoxy.TabIndex = 122;
            // 
            // textBoxx
            // 
            this.textBoxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxx.Location = new System.Drawing.Point(34, 46);
            this.textBoxx.Name = "textBoxx";
            this.textBoxx.Size = new System.Drawing.Size(65, 18);
            this.textBoxx.TabIndex = 121;
            // 
            // comboBoxX
            // 
            this.comboBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "r",
            "theta",
            "x",
            "vx",
            "y",
            "vy",
            "ax",
            "ay",
            "RadialDot",
            "AngularDot",
            "Kinetic Energy",
            "Potential Energy",
            "Mechanic Energy",
            "t",
            "",
            "--"});
            this.comboBoxX.Location = new System.Drawing.Point(8, 383);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 21);
            this.comboBoxX.TabIndex = 128;
            this.comboBoxX.Text = "x";
            this.comboBoxX.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "r",
            "theta",
            "x",
            "vx",
            "y",
            "vy",
            "ax",
            "ay",
            "RadialDot",
            "AngularDot",
            "Kinetic Energy",
            "Potential Energy",
            "Mechanic Energy",
            "t",
            "",
            "--"});
            this.comboBoxY.Location = new System.Drawing.Point(8, 325);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 21);
            this.comboBoxY.TabIndex = 127;
            this.comboBoxY.Text = "y";
            this.comboBoxY.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // checkBoxAnimate
            // 
            this.checkBoxAnimate.AutoSize = true;
            this.checkBoxAnimate.Checked = true;
            this.checkBoxAnimate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAnimate.Location = new System.Drawing.Point(719, 24);
            this.checkBoxAnimate.Name = "checkBoxAnimate";
            this.checkBoxAnimate.Size = new System.Drawing.Size(94, 17);
            this.checkBoxAnimate.TabIndex = 120;
            this.checkBoxAnimate.Text = "Show Animate";
            this.checkBoxAnimate.UseVisualStyleBackColor = true;
            this.checkBoxAnimate.CheckedChanged += new System.EventHandler(this.checkBoxAnimate_CheckedChanged);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(408, 21);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(85, 21);
            this.buttonClearGraph.TabIndex = 119;
            this.buttonClearGraph.Text = "Clear Graph";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // buttonResetData
            // 
            this.buttonResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetData.Location = new System.Drawing.Point(114, 21);
            this.buttonResetData.Name = "buttonResetData";
            this.buttonResetData.Size = new System.Drawing.Size(85, 21);
            this.buttonResetData.TabIndex = 118;
            this.buttonResetData.Text = "Reset Data";
            this.buttonResetData.UseVisualStyleBackColor = true;
            this.buttonResetData.Click += new System.EventHandler(this.buttonResetData_Click);
            // 
            // pictureBoxCurve
            // 
            this.pictureBoxCurve.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCurve.Location = new System.Drawing.Point(114, 48);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(485, 405);
            this.pictureBoxCurve.TabIndex = 117;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(597, 48);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(254, 405);
            this.pictureBoxAnimate.TabIndex = 116;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // textBoxb
            // 
            this.textBoxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb.Location = new System.Drawing.Point(34, 191);
            this.textBoxb.Name = "textBoxb";
            this.textBoxb.Size = new System.Drawing.Size(65, 18);
            this.textBoxb.TabIndex = 134;
            // 
            // textBoxR
            // 
            this.textBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR.Location = new System.Drawing.Point(34, 215);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(65, 18);
            this.textBoxR.TabIndex = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 12);
            this.label1.TabIndex = 136;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 12);
            this.label2.TabIndex = 137;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 12);
            this.label3.TabIndex = 138;
            this.label3.Text = "vx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 12);
            this.label4.TabIndex = 139;
            this.label4.Text = "vy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 12);
            this.label5.TabIndex = 140;
            this.label5.Text = "k";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 141;
            this.label6.Text = "m";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 12);
            this.label7.TabIndex = 142;
            this.label7.Text = "b";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 12);
            this.label8.TabIndex = 143;
            this.label8.Text = "R";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 12);
            this.label9.TabIndex = 144;
            this.label9.Text = "g";
            // 
            // textBoxg
            // 
            this.textBoxg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxg.Location = new System.Drawing.Point(34, 239);
            this.textBoxg.Name = "textBoxg";
            this.textBoxg.Size = new System.Drawing.Size(65, 18);
            this.textBoxg.TabIndex = 145;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 367);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 147;
            this.label12.Text = "Axes x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(31, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 146;
            this.label13.Text = "Axes y";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.SystemColors.Control;
            this.labelY.ForeColor = System.Drawing.Color.Blue;
            this.labelY.Location = new System.Drawing.Point(120, 51);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 148;
            this.labelY.Text = "labelY";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(364, 433);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 149;
            this.labelX.Text = "labelX";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 150;
            this.label10.Text = "Initial Values :";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(857, 48);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(51, 12);
            this.labelResult.TabIndex = 234;
            this.labelResult.Text = "labelResult";
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(219, 462);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 235;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // Form2DSingleSpring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(920, 497);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxg);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.textBoxb);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.buttonRedrawPoints);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.textBoxm);
            this.Controls.Add(this.textBoxk);
            this.Controls.Add(this.textBoxvy);
            this.Controls.Add(this.textBoxvx);
            this.Controls.Add(this.textBoxy);
            this.Controls.Add(this.textBoxx);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.checkBoxAnimate);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonResetData);
            this.Controls.Add(this.pictureBoxCurve);
            this.Controls.Add(this.pictureBoxAnimate);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "Form2DSingleSpring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "2D Single Spring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2DSingleSpring_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TextBox textBoxm;
        private System.Windows.Forms.TextBox textBoxk;
        private System.Windows.Forms.TextBox textBoxvy;
        private System.Windows.Forms.TextBox textBoxvx;
        private System.Windows.Forms.TextBox textBoxy;
        private System.Windows.Forms.TextBox textBoxx;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.CheckBox checkBoxAnimate;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.TextBox textBoxb;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}