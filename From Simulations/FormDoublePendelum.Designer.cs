namespace MechanicalSimulations
{
    partial class FormDoublePendelum
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxl1 = new System.Windows.Forms.TextBox();
            this.textBoxm1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxomega1 = new System.Windows.Forms.TextBox();
            this.textBoxtheta1 = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxl2 = new System.Windows.Forms.TextBox();
            this.textBoxm2 = new System.Windows.Forms.TextBox();
            this.textBoxomega2 = new System.Windows.Forms.TextBox();
            this.textBoxtheta2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 170;
            this.label1.Text = "theta1";
            // 
            // textBoxl1
            // 
            this.textBoxl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxl1.Location = new System.Drawing.Point(40, 80);
            this.textBoxl1.Name = "textBoxl1";
            this.textBoxl1.Size = new System.Drawing.Size(65, 18);
            this.textBoxl1.TabIndex = 169;
            // 
            // textBoxm1
            // 
            this.textBoxm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm1.Location = new System.Drawing.Point(40, 61);
            this.textBoxm1.Name = "textBoxm1";
            this.textBoxm1.Size = new System.Drawing.Size(65, 18);
            this.textBoxm1.TabIndex = 160;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxl1);
            this.groupBox2.Controls.Add(this.textBoxm1);
            this.groupBox2.Controls.Add(this.textBoxomega1);
            this.groupBox2.Controls.Add(this.textBoxtheta1);
            this.groupBox2.Location = new System.Drawing.Point(4, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 106);
            this.groupBox2.TabIndex = 205;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mass 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 177;
            this.label8.Text = "lenght1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 12);
            this.label6.TabIndex = 175;
            this.label6.Text = "m1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 171;
            this.label2.Text = "omega1";
            // 
            // textBoxomega1
            // 
            this.textBoxomega1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxomega1.Location = new System.Drawing.Point(40, 37);
            this.textBoxomega1.Name = "textBoxomega1";
            this.textBoxomega1.Size = new System.Drawing.Size(65, 18);
            this.textBoxomega1.TabIndex = 156;
            // 
            // textBoxtheta1
            // 
            this.textBoxtheta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxtheta1.Location = new System.Drawing.Point(40, 18);
            this.textBoxtheta1.Name = "textBoxtheta1";
            this.textBoxtheta1.Size = new System.Drawing.Size(65, 18);
            this.textBoxtheta1.TabIndex = 155;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(369, 428);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 203;
            this.labelX.Text = "labelX";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.SystemColors.Control;
            this.labelY.ForeColor = System.Drawing.Color.Blue;
            this.labelY.Location = new System.Drawing.Point(125, 46);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 202;
            this.labelY.Text = "labelY";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 201;
            this.label12.Text = "Axes x";
            // 
            // comboBoxX
            // 
            this.comboBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "x1",
            "y1",
            "x2",
            "y2",
            "theta1",
            "omega1",
            "alfa1",
            "theta2",
            "omega2",
            "alfa2",
            "Kinetic E",
            "Potential E",
            "Mechanical E",
            "t",
            "",
            "--"});
            this.comboBoxX.Location = new System.Drawing.Point(13, 378);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 21);
            this.comboBoxX.TabIndex = 194;
            this.comboBoxX.Text = "theta1";
            this.comboBoxX.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "x1",
            "y1",
            "x2",
            "y2",
            "theta1",
            "omega1",
            "alfa1",
            "theta2",
            "omega2",
            "alfa2",
            "Kinetic E",
            "Potential E",
            "Mechanical E",
            "t",
            "",
            "--"});
            this.comboBoxY.Location = new System.Drawing.Point(13, 320);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 21);
            this.comboBoxY.TabIndex = 193;
            this.comboBoxY.Text = "theta2";
            this.comboBoxY.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(413, 16);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(85, 21);
            this.buttonClearGraph.TabIndex = 191;
            this.buttonClearGraph.Text = "Clear Graph";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // buttonResetData
            // 
            this.buttonResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetData.Location = new System.Drawing.Point(119, 16);
            this.buttonResetData.Name = "buttonResetData";
            this.buttonResetData.Size = new System.Drawing.Size(85, 21);
            this.buttonResetData.TabIndex = 190;
            this.buttonResetData.Text = "Reset Data";
            this.buttonResetData.UseVisualStyleBackColor = true;
            this.buttonResetData.Click += new System.EventHandler(this.buttonResetData_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 200;
            this.label13.Text = "Axes y";
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(602, 43);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(254, 405);
            this.pictureBoxAnimate.TabIndex = 188;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // pictureBoxCurve
            // 
            this.pictureBoxCurve.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCurve.Location = new System.Drawing.Point(119, 43);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(484, 405);
            this.pictureBoxCurve.TabIndex = 189;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(119, 457);
            this.buttonMoreDetail.Name = "buttonMoreDetail";
            this.buttonMoreDetail.Size = new System.Drawing.Size(85, 23);
            this.buttonMoreDetail.TabIndex = 199;
            this.buttonMoreDetail.Text = "More Detail";
            this.buttonMoreDetail.UseVisualStyleBackColor = true;
            this.buttonMoreDetail.Click += new System.EventHandler(this.buttonMoreDetail_Click);
            // 
            // checkBoxConnectDots
            // 
            this.checkBoxConnectDots.AutoSize = true;
            this.checkBoxConnectDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConnectDots.Location = new System.Drawing.Point(279, 19);
            this.checkBoxConnectDots.Name = "checkBoxConnectDots";
            this.checkBoxConnectDots.Size = new System.Drawing.Size(91, 17);
            this.checkBoxConnectDots.TabIndex = 198;
            this.checkBoxConnectDots.Text = "Connect Dots";
            this.checkBoxConnectDots.UseVisualStyleBackColor = true;
            this.checkBoxConnectDots.CheckedChanged += new System.EventHandler(this.checkBoxConnectDots_CheckedChanged);
            // 
            // buttonRedrawPoints
            // 
            this.buttonRedrawPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedrawPoints.Location = new System.Drawing.Point(511, 16);
            this.buttonRedrawPoints.Name = "buttonRedrawPoints";
            this.buttonRedrawPoints.Size = new System.Drawing.Size(85, 21);
            this.buttonRedrawPoints.TabIndex = 197;
            this.buttonRedrawPoints.Text = "Redraw Points";
            this.buttonRedrawPoints.UseVisualStyleBackColor = true;
            this.buttonRedrawPoints.Click += new System.EventHandler(this.buttonRedrawPoints_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(511, 459);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 21);
            this.buttonStop.TabIndex = 196;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(413, 459);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 195;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // textBoxg
            // 
            this.textBoxg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxg.Location = new System.Drawing.Point(43, 262);
            this.textBoxg.Name = "textBoxg";
            this.textBoxg.Size = new System.Drawing.Size(65, 18);
            this.textBoxg.TabIndex = 207;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 12);
            this.label9.TabIndex = 206;
            this.label9.Text = "g";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxl2);
            this.groupBox1.Controls.Add(this.textBoxm2);
            this.groupBox1.Controls.Add(this.textBoxomega2);
            this.groupBox1.Controls.Add(this.textBoxtheta2);
            this.groupBox1.Location = new System.Drawing.Point(4, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 105);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mass 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 177;
            this.label3.Text = "lenght2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 12);
            this.label4.TabIndex = 175;
            this.label4.Text = "m2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 171;
            this.label5.Text = "omega2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 12);
            this.label7.TabIndex = 170;
            this.label7.Text = "theta2";
            // 
            // textBoxl2
            // 
            this.textBoxl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxl2.Location = new System.Drawing.Point(40, 80);
            this.textBoxl2.Name = "textBoxl2";
            this.textBoxl2.Size = new System.Drawing.Size(65, 18);
            this.textBoxl2.TabIndex = 169;
            // 
            // textBoxm2
            // 
            this.textBoxm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm2.Location = new System.Drawing.Point(40, 61);
            this.textBoxm2.Name = "textBoxm2";
            this.textBoxm2.Size = new System.Drawing.Size(65, 18);
            this.textBoxm2.TabIndex = 160;
            // 
            // textBoxomega2
            // 
            this.textBoxomega2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxomega2.Location = new System.Drawing.Point(40, 37);
            this.textBoxomega2.Name = "textBoxomega2";
            this.textBoxomega2.Size = new System.Drawing.Size(65, 18);
            this.textBoxomega2.TabIndex = 156;
            // 
            // textBoxtheta2
            // 
            this.textBoxtheta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxtheta2.Location = new System.Drawing.Point(40, 18);
            this.textBoxtheta2.Name = "textBoxtheta2";
            this.textBoxtheta2.Size = new System.Drawing.Size(65, 18);
            this.textBoxtheta2.TabIndex = 155;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 209;
            this.label10.Text = "Initial Values :";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(862, 42);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(51, 12);
            this.labelResult.TabIndex = 234;
            this.labelResult.Text = "labelResult";
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(227, 457);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 236;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // FormDoublePendelum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(962, 497);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxg);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonResetData);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBoxAnimate);
            this.Controls.Add(this.pictureBoxCurve);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.buttonRedrawPoints);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "FormDoublePendelum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Double Pendelum";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDoublePendelum_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxl1;
        private System.Windows.Forms.TextBox textBoxm1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxomega1;
        private System.Windows.Forms.TextBox textBoxtheta1;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TextBox textBoxg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxl2;
        private System.Windows.Forms.TextBox textBoxm2;
        private System.Windows.Forms.TextBox textBoxomega2;
        private System.Windows.Forms.TextBox textBoxtheta2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}