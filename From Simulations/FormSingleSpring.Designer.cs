namespace MechanicalSimulations
{
    partial class FormSingleSpring
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
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.textBoxb = new System.Windows.Forms.TextBox();
            this.textBoxm = new System.Windows.Forms.TextBox();
            this.textBoxk = new System.Windows.Forms.TextBox();
            this.textBoxv0 = new System.Windows.Forms.TextBox();
            this.textBoxx0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(105, 45);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(615, 57);
            this.pictureBoxAnimate.TabIndex = 0;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // pictureBoxCurve
            // 
            this.pictureBoxCurve.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCurve.Location = new System.Drawing.Point(105, 101);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(615, 368);
            this.pictureBoxCurve.TabIndex = 1;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(530, 18);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(85, 21);
            this.buttonClearGraph.TabIndex = 56;
            this.buttonClearGraph.Text = "Clear Graph";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // buttonResetData
            // 
            this.buttonResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetData.Location = new System.Drawing.Point(105, 18);
            this.buttonResetData.Name = "buttonResetData";
            this.buttonResetData.Size = new System.Drawing.Size(85, 21);
            this.buttonResetData.TabIndex = 55;
            this.buttonResetData.Text = "Reset Data";
            this.buttonResetData.UseVisualStyleBackColor = true;
            this.buttonResetData.Click += new System.EventHandler(this.buttonResetData_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Axes x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Axes y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 12);
            this.label7.TabIndex = 69;
            this.label7.Text = "b";
            // 
            // textBoxR
            // 
            this.textBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxR.Location = new System.Drawing.Point(21, 171);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(65, 18);
            this.textBoxR.TabIndex = 68;
            // 
            // textBoxb
            // 
            this.textBoxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb.Location = new System.Drawing.Point(21, 149);
            this.textBoxb.Name = "textBoxb";
            this.textBoxb.Size = new System.Drawing.Size(65, 18);
            this.textBoxb.TabIndex = 67;
            // 
            // textBoxm
            // 
            this.textBoxm.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxm.Location = new System.Drawing.Point(21, 127);
            this.textBoxm.Name = "textBoxm";
            this.textBoxm.Size = new System.Drawing.Size(65, 18);
            this.textBoxm.TabIndex = 66;
            // 
            // textBoxk
            // 
            this.textBoxk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxk.Location = new System.Drawing.Point(21, 103);
            this.textBoxk.Name = "textBoxk";
            this.textBoxk.Size = new System.Drawing.Size(65, 18);
            this.textBoxk.TabIndex = 65;
            // 
            // textBoxv0
            // 
            this.textBoxv0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxv0.Location = new System.Drawing.Point(21, 74);
            this.textBoxv0.Name = "textBoxv0";
            this.textBoxv0.Size = new System.Drawing.Size(65, 18);
            this.textBoxv0.TabIndex = 64;
            // 
            // textBoxx0
            // 
            this.textBoxx0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxx0.Location = new System.Drawing.Point(21, 50);
            this.textBoxx0.Name = "textBoxx0";
            this.textBoxx0.Size = new System.Drawing.Size(65, 18);
            this.textBoxx0.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 61;
            this.label6.Text = "m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 12);
            this.label3.TabIndex = 60;
            this.label3.Text = "k";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "v0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 12);
            this.label1.TabIndex = 58;
            this.label1.Text = "x0";
            // 
            // comboBoxX
            // 
            this.comboBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "Distance",
            "Speed",
            "Acceleration",
            "Kinetic Energy",
            "Potential Energy",
            "Mechanic Energy",
            "Elapsed Time",
            "",
            "None"});
            this.comboBoxX.Location = new System.Drawing.Point(4, 386);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 21);
            this.comboBoxX.TabIndex = 71;
            this.comboBoxX.Text = "Distance";
            this.comboBoxX.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "Distance",
            "Speed",
            "Acceleration",
            "Kinetic Energy",
            "Potential Energy",
            "Mechanic Energy",
            "Elapsed Time",
            "",
            "None"});
            this.comboBoxY.Location = new System.Drawing.Point(4, 328);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 21);
            this.comboBoxY.TabIndex = 70;
            this.comboBoxY.Text = "Speed";
            this.comboBoxY.TextChanged += new System.EventHandler(this.ComboBox_TextChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(638, 475);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(85, 21);
            this.buttonStop.TabIndex = 75;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(530, 475);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 74;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(105, 474);
            this.buttonMoreDetail.Name = "buttonMoreDetail";
            this.buttonMoreDetail.Size = new System.Drawing.Size(85, 23);
            this.buttonMoreDetail.TabIndex = 115;
            this.buttonMoreDetail.Text = "More Detail";
            this.buttonMoreDetail.UseVisualStyleBackColor = true;
            this.buttonMoreDetail.Click += new System.EventHandler(this.buttonMoreDetail_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(418, 450);
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
            this.labelY.Location = new System.Drawing.Point(111, 105);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 150;
            this.labelY.Text = "labelY";
            // 
            // checkBoxConnectDots
            // 
            this.checkBoxConnectDots.AutoSize = true;
            this.checkBoxConnectDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxConnectDots.Location = new System.Drawing.Point(253, 21);
            this.checkBoxConnectDots.Name = "checkBoxConnectDots";
            this.checkBoxConnectDots.Size = new System.Drawing.Size(91, 17);
            this.checkBoxConnectDots.TabIndex = 152;
            this.checkBoxConnectDots.Text = "Connect Dots";
            this.checkBoxConnectDots.UseVisualStyleBackColor = true;
            this.checkBoxConnectDots.CheckedChanged += new System.EventHandler(this.checkBoxConnectDots_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 189;
            this.label10.Text = "Initial Values :";
            // 
            // buttonRedrawPoints
            // 
            this.buttonRedrawPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedrawPoints.Location = new System.Drawing.Point(635, 18);
            this.buttonRedrawPoints.Name = "buttonRedrawPoints";
            this.buttonRedrawPoints.Size = new System.Drawing.Size(85, 21);
            this.buttonRedrawPoints.TabIndex = 266;
            this.buttonRedrawPoints.Text = "Redraw Points";
            this.buttonRedrawPoints.UseVisualStyleBackColor = true;
            this.buttonRedrawPoints.Click += new System.EventHandler(this.buttonRedrawPoints_Click);
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(205, 474);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 299;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // FormSingleSpring
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(735, 533);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.buttonRedrawPoints);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.textBoxb);
            this.Controls.Add(this.textBoxm);
            this.Controls.Add(this.textBoxk);
            this.Controls.Add(this.textBoxv0);
            this.Controls.Add(this.textBoxx0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonResetData);
            this.Controls.Add(this.pictureBoxCurve);
            this.Controls.Add(this.pictureBoxAnimate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "FormSingleSpring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Single Spring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSingleSpring_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.TextBox textBoxb;
        private System.Windows.Forms.TextBox textBoxm;
        private System.Windows.Forms.TextBox textBoxk;
        private System.Windows.Forms.TextBox textBoxv0;
        private System.Windows.Forms.TextBox textBoxx0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}