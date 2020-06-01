namespace MechanicalSimulations
{
    partial class FormDoubleSprings
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
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.textBoxR1 = new System.Windows.Forms.TextBox();
            this.textBoxm1 = new System.Windows.Forms.TextBox();
            this.textBoxk1 = new System.Windows.Forms.TextBox();
            this.textBoxv1 = new System.Windows.Forms.TextBox();
            this.textBoxx1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxR2 = new System.Windows.Forms.TextBox();
            this.textBoxm2 = new System.Windows.Forms.TextBox();
            this.textBoxk2 = new System.Windows.Forms.TextBox();
            this.textBoxv2 = new System.Windows.Forms.TextBox();
            this.textBoxx2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxb1 = new System.Windows.Forms.TextBox();
            this.textBoxb2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRedrawPoints
            // 
            this.buttonRedrawPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedrawPoints.Location = new System.Drawing.Point(637, 26);
            this.buttonRedrawPoints.Name = "buttonRedrawPoints";
            this.buttonRedrawPoints.Size = new System.Drawing.Size(85, 21);
            this.buttonRedrawPoints.TabIndex = 87;
            this.buttonRedrawPoints.Text = "Redraw Points";
            this.buttonRedrawPoints.UseVisualStyleBackColor = true;
            this.buttonRedrawPoints.Click += new System.EventHandler(this.buttonRedrawPoints_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(640, 483);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 21);
            this.buttonStop.TabIndex = 86;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(532, 483);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 85;
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
            "Distance1",
            "Speed1",
            "Acceleration1",
            "Distance2",
            "Speed2",
            "Acceleration2",
            "Total Kinetic Energy",
            "Total Potential Energy",
            "Total Mechanic Energy",
            "Elapsed Time",
            "",
            "--"});
            this.comboBoxX.Location = new System.Drawing.Point(3, 421);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 20);
            this.comboBoxX.TabIndex = 84;
            this.comboBoxX.Text = "Distance1";
            this.comboBoxX.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "Distance1",
            "Speed1",
            "Acceleration1",
            "Distance2",
            "Speed2",
            "Acceleration2",
            "Total Kinetic Energy",
            "Total Potential Energy",
            "Total Mechanic Energy",
            "Elapsed Time",
            "",
            "--"});
            this.comboBoxY.Location = new System.Drawing.Point(3, 379);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 20);
            this.comboBoxY.TabIndex = 83;
            this.comboBoxY.Text = "Distance2";
            this.comboBoxY.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(532, 26);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(85, 21);
            this.buttonClearGraph.TabIndex = 81;
            this.buttonClearGraph.Text = "Clear Graph";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // buttonResetData
            // 
            this.buttonResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetData.Location = new System.Drawing.Point(107, 26);
            this.buttonResetData.Name = "buttonResetData";
            this.buttonResetData.Size = new System.Drawing.Size(85, 21);
            this.buttonResetData.TabIndex = 80;
            this.buttonResetData.Text = "Reset Data";
            this.buttonResetData.UseVisualStyleBackColor = true;
            this.buttonResetData.Click += new System.EventHandler(this.buttonResetData_Click);
            // 
            // pictureBoxCurve
            // 
            this.pictureBoxCurve.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCurve.Location = new System.Drawing.Point(107, 107);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(615, 370);
            this.pictureBoxCurve.TabIndex = 79;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(107, 54);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(615, 55);
            this.pictureBoxAnimate.TabIndex = 78;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // textBoxR1
            // 
            this.textBoxR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR1.Location = new System.Drawing.Point(52, 146);
            this.textBoxR1.Name = "textBoxR1";
            this.textBoxR1.Size = new System.Drawing.Size(43, 18);
            this.textBoxR1.TabIndex = 99;
            // 
            // textBoxm1
            // 
            this.textBoxm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm1.Location = new System.Drawing.Point(52, 122);
            this.textBoxm1.Name = "textBoxm1";
            this.textBoxm1.Size = new System.Drawing.Size(43, 18);
            this.textBoxm1.TabIndex = 97;
            // 
            // textBoxk1
            // 
            this.textBoxk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxk1.Location = new System.Drawing.Point(52, 98);
            this.textBoxk1.Name = "textBoxk1";
            this.textBoxk1.Size = new System.Drawing.Size(43, 18);
            this.textBoxk1.TabIndex = 96;
            // 
            // textBoxv1
            // 
            this.textBoxv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxv1.Location = new System.Drawing.Point(52, 74);
            this.textBoxv1.Name = "textBoxv1";
            this.textBoxv1.Size = new System.Drawing.Size(43, 18);
            this.textBoxv1.TabIndex = 95;
            // 
            // textBoxx1
            // 
            this.textBoxx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxx1.Location = new System.Drawing.Point(52, 54);
            this.textBoxx1.Name = "textBoxx1";
            this.textBoxx1.Size = new System.Drawing.Size(43, 18);
            this.textBoxx1.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 93;
            this.label4.Text = "R circle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 92;
            this.label6.Text = "m circle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 91;
            this.label3.Text = "k circle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 90;
            this.label2.Text = "v circle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 89;
            this.label1.Text = "x circle";
            // 
            // textBoxR2
            // 
            this.textBoxR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR2.Location = new System.Drawing.Point(51, 303);
            this.textBoxR2.Name = "textBoxR2";
            this.textBoxR2.Size = new System.Drawing.Size(43, 18);
            this.textBoxR2.TabIndex = 110;
            // 
            // textBoxm2
            // 
            this.textBoxm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm2.Location = new System.Drawing.Point(51, 279);
            this.textBoxm2.Name = "textBoxm2";
            this.textBoxm2.Size = new System.Drawing.Size(43, 18);
            this.textBoxm2.TabIndex = 108;
            // 
            // textBoxk2
            // 
            this.textBoxk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxk2.Location = new System.Drawing.Point(51, 255);
            this.textBoxk2.Name = "textBoxk2";
            this.textBoxk2.Size = new System.Drawing.Size(43, 18);
            this.textBoxk2.TabIndex = 107;
            // 
            // textBoxv2
            // 
            this.textBoxv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxv2.Location = new System.Drawing.Point(51, 231);
            this.textBoxv2.Name = "textBoxv2";
            this.textBoxv2.Size = new System.Drawing.Size(43, 18);
            this.textBoxv2.TabIndex = 106;
            // 
            // textBoxx2
            // 
            this.textBoxx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxx2.Location = new System.Drawing.Point(51, 210);
            this.textBoxx2.Name = "textBoxx2";
            this.textBoxx2.Size = new System.Drawing.Size(43, 18);
            this.textBoxx2.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 104;
            this.label5.Text = "R square";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 12);
            this.label8.TabIndex = 103;
            this.label8.Text = "m square";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 102;
            this.label9.Text = "k square";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 101;
            this.label10.Text = "v square";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 12);
            this.label11.TabIndex = 100;
            this.label11.Text = "x square";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 407);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Axes x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 363);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 112;
            this.label13.Text = "Axes y";
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(107, 482);
            this.buttonMoreDetail.Name = "buttonMoreDetail";
            this.buttonMoreDetail.Size = new System.Drawing.Size(85, 23);
            this.buttonMoreDetail.TabIndex = 114;
            this.buttonMoreDetail.Text = "More Detail";
            this.buttonMoreDetail.UseVisualStyleBackColor = true;
            this.buttonMoreDetail.Click += new System.EventHandler(this.buttonMoreDetail_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 12);
            this.label7.TabIndex = 115;
            this.label7.Text = "b circle";
            // 
            // textBoxb1
            // 
            this.textBoxb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb1.Location = new System.Drawing.Point(52, 170);
            this.textBoxb1.Name = "textBoxb1";
            this.textBoxb1.Size = new System.Drawing.Size(43, 18);
            this.textBoxb1.TabIndex = 116;
            // 
            // textBoxb2
            // 
            this.textBoxb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb2.Location = new System.Drawing.Point(52, 327);
            this.textBoxb2.Name = "textBoxb2";
            this.textBoxb2.Size = new System.Drawing.Size(43, 18);
            this.textBoxb2.TabIndex = 118;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 12);
            this.label14.TabIndex = 117;
            this.label14.Text = "b square";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(453, 459);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 151;
            this.labelX.Text = "labelX";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.BackColor = System.Drawing.SystemColors.Control;
            this.labelY.ForeColor = System.Drawing.Color.Blue;
            this.labelY.Location = new System.Drawing.Point(113, 111);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 150;
            this.labelY.Text = "labelY";
            // 
            // checkBoxConnectDots
            // 
            this.checkBoxConnectDots.AutoSize = true;
            this.checkBoxConnectDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConnectDots.Location = new System.Drawing.Point(389, 486);
            this.checkBoxConnectDots.Name = "checkBoxConnectDots";
            this.checkBoxConnectDots.Size = new System.Drawing.Size(91, 17);
            this.checkBoxConnectDots.TabIndex = 152;
            this.checkBoxConnectDots.Text = "Connect Dots";
            this.checkBoxConnectDots.UseVisualStyleBackColor = true;
            this.checkBoxConnectDots.CheckedChanged += new System.EventHandler(this.checkBoxConnectDots_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 189;
            this.label15.Text = "Initial Values :";
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(207, 482);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 236;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // FormDoubleSprings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(733, 531);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.textBoxb2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxb1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxR2);
            this.Controls.Add(this.textBoxm2);
            this.Controls.Add(this.textBoxk2);
            this.Controls.Add(this.textBoxv2);
            this.Controls.Add(this.textBoxx2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxR1);
            this.Controls.Add(this.textBoxm1);
            this.Controls.Add(this.textBoxk1);
            this.Controls.Add(this.textBoxv1);
            this.Controls.Add(this.textBoxx1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Name = "FormDoubleSprings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Double Springs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDoubleSprings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.TextBox textBoxR1;
        private System.Windows.Forms.TextBox textBoxm1;
        private System.Windows.Forms.TextBox textBoxk1;
        private System.Windows.Forms.TextBox textBoxv1;
        private System.Windows.Forms.TextBox textBoxx1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxR2;
        private System.Windows.Forms.TextBox textBoxm2;
        private System.Windows.Forms.TextBox textBoxk2;
        private System.Windows.Forms.TextBox textBoxv2;
        private System.Windows.Forms.TextBox textBoxx2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxb1;
        private System.Windows.Forms.TextBox textBoxb2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}