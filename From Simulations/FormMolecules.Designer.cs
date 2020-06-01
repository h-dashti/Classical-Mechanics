namespace MechanicalSimulations
{
    partial class FormMolecules
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
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.buttonMoreDetail = new System.Windows.Forms.Button();
            this.checkBoxConnectDots = new System.Windows.Forms.CheckBox();
            this.buttonRedrawPoints = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.buttonResetData = new System.Windows.Forms.Button();
            this.pictureBoxCurve = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnimate = new System.Windows.Forms.PictureBox();
            this.panelMolecule = new System.Windows.Forms.Panel();
            this.buttonNewMolecules = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxg = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxInsideBox = new System.Windows.Forms.CheckBox();
            this.groupBoxAxes = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.buttonTakeCurvePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).BeginInit();
            this.groupBoxAxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.BackColor = System.Drawing.SystemColors.Control;
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(352, 556);
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
            this.labelY.Location = new System.Drawing.Point(124, 46);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(36, 13);
            this.labelY.TabIndex = 274;
            this.labelY.Text = "labelY";
            // 
            // buttonMoreDetail
            // 
            this.buttonMoreDetail.Location = new System.Drawing.Point(118, 576);
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
            this.checkBoxConnectDots.Location = new System.Drawing.Point(265, 20);
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
            this.buttonRedrawPoints.Location = new System.Drawing.Point(510, 16);
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
            this.buttonStop.Location = new System.Drawing.Point(510, 577);
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
            this.buttonPlay.Location = new System.Drawing.Point(412, 577);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(85, 21);
            this.buttonPlay.TabIndex = 248;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearGraph.Location = new System.Drawing.Point(412, 16);
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
            this.buttonResetData.Location = new System.Drawing.Point(118, 16);
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
            this.pictureBoxCurve.Location = new System.Drawing.Point(118, 43);
            this.pictureBoxCurve.Name = "pictureBoxCurve";
            this.pictureBoxCurve.Size = new System.Drawing.Size(487, 528);
            this.pictureBoxCurve.TabIndex = 258;
            this.pictureBoxCurve.TabStop = false;
            this.pictureBoxCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCurve_Paint);
            // 
            // pictureBoxAnimate
            // 
            this.pictureBoxAnimate.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxAnimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAnimate.Location = new System.Drawing.Point(606, 43);
            this.pictureBoxAnimate.Name = "pictureBoxAnimate";
            this.pictureBoxAnimate.Size = new System.Drawing.Size(468, 528);
            this.pictureBoxAnimate.TabIndex = 257;
            this.pictureBoxAnimate.TabStop = false;
            this.pictureBoxAnimate.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAnimate_Paint);
            // 
            // panelMolecule
            // 
            this.panelMolecule.AutoScroll = true;
            this.panelMolecule.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panelMolecule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMolecule.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMolecule.Location = new System.Drawing.Point(7, 45);
            this.panelMolecule.Name = "panelMolecule";
            this.panelMolecule.Size = new System.Drawing.Size(108, 398);
            this.panelMolecule.TabIndex = 276;
            // 
            // buttonNewMolecules
            // 
            this.buttonNewMolecules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewMolecules.Location = new System.Drawing.Point(7, 16);
            this.buttonNewMolecules.Name = "buttonNewMolecules";
            this.buttonNewMolecules.Size = new System.Drawing.Size(100, 21);
            this.buttonNewMolecules.TabIndex = 277;
            this.buttonNewMolecules.Text = "New Molecules";
            this.buttonNewMolecules.UseVisualStyleBackColor = true;
            this.buttonNewMolecules.Click += new System.EventHandler(this.buttonNewMolecules_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 12);
            this.label1.TabIndex = 278;
            this.label1.Text = "g";
            // 
            // textBoxg
            // 
            this.textBoxg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxg.Location = new System.Drawing.Point(49, 449);
            this.textBoxg.Name = "textBoxg";
            this.textBoxg.Size = new System.Drawing.Size(41, 18);
            this.textBoxg.TabIndex = 279;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(1080, 46);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(142, 525);
            this.richTextBox1.TabIndex = 280;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // checkBoxInsideBox
            // 
            this.checkBoxInsideBox.AutoSize = true;
            this.checkBoxInsideBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxInsideBox.Location = new System.Drawing.Point(999, 20);
            this.checkBoxInsideBox.Name = "checkBoxInsideBox";
            this.checkBoxInsideBox.Size = new System.Drawing.Size(75, 17);
            this.checkBoxInsideBox.TabIndex = 281;
            this.checkBoxInsideBox.Text = "Inside Box";
            this.checkBoxInsideBox.UseVisualStyleBackColor = true;
            this.checkBoxInsideBox.CheckedChanged += new System.EventHandler(this.checkBoxInsideBox_CheckedChanged);
            // 
            // groupBoxAxes
            // 
            this.groupBoxAxes.Controls.Add(this.label12);
            this.groupBoxAxes.Controls.Add(this.label13);
            this.groupBoxAxes.Controls.Add(this.comboBoxX);
            this.groupBoxAxes.Controls.Add(this.comboBoxY);
            this.groupBoxAxes.Location = new System.Drawing.Point(7, 491);
            this.groupBoxAxes.Name = "groupBoxAxes";
            this.groupBoxAxes.Size = new System.Drawing.Size(108, 107);
            this.groupBoxAxes.TabIndex = 282;
            this.groupBoxAxes.TabStop = false;
            this.groupBoxAxes.Text = "Axes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(42, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 277;
            this.label12.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 276;
            this.label13.Text = " Y";
            // 
            // comboBoxX
            // 
            this.comboBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Location = new System.Drawing.Point(4, 77);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(100, 20);
            this.comboBoxX.TabIndex = 275;
            this.comboBoxX.Text = "vx1";
            this.comboBoxX.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // comboBoxY
            // 
            this.comboBoxY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Location = new System.Drawing.Point(4, 33);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(100, 20);
            this.comboBoxY.TabIndex = 274;
            this.comboBoxY.Text = "vy1";
            this.comboBoxY.TextChanged += new System.EventHandler(this.comboBoxY_TextChanged);
            // 
            // buttonTakeCurvePic
            // 
            this.buttonTakeCurvePic.Location = new System.Drawing.Point(221, 575);
            this.buttonTakeCurvePic.Name = "buttonTakeCurvePic";
            this.buttonTakeCurvePic.Size = new System.Drawing.Size(119, 23);
            this.buttonTakeCurvePic.TabIndex = 283;
            this.buttonTakeCurvePic.Text = "Take picture of curve";
            this.buttonTakeCurvePic.UseVisualStyleBackColor = true;
            this.buttonTakeCurvePic.Click += new System.EventHandler(this.buttonTakeCurvePic_Click);
            // 
            // FormMolecules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1028, 610);
            this.Controls.Add(this.buttonTakeCurvePic);
            this.Controls.Add(this.groupBoxAxes);
            this.Controls.Add(this.checkBoxInsideBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBoxg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNewMolecules);
            this.Controls.Add(this.panelMolecule);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.buttonMoreDetail);
            this.Controls.Add(this.checkBoxConnectDots);
            this.Controls.Add(this.buttonRedrawPoints);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonResetData);
            this.Controls.Add(this.pictureBoxCurve);
            this.Controls.Add(this.pictureBoxAnimate);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "FormMolecules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Molecules";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMolecules_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnimate)).EndInit();
            this.groupBoxAxes.ResumeLayout(false);
            this.groupBoxAxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Button buttonMoreDetail;
        private System.Windows.Forms.CheckBox checkBoxConnectDots;
        private System.Windows.Forms.Button buttonRedrawPoints;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonClearGraph;
        private System.Windows.Forms.Button buttonResetData;
        private System.Windows.Forms.PictureBox pictureBoxCurve;
        private System.Windows.Forms.PictureBox pictureBoxAnimate;
        private System.Windows.Forms.Panel panelMolecule;
        private System.Windows.Forms.Button buttonNewMolecules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxg;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxInsideBox;
        private System.Windows.Forms.GroupBox groupBoxAxes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button buttonTakeCurvePic;
    }
}