using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormTwoSpringsOverHead : Form
    {
        // ---------------------------variables
        private double x1, vx1, x2, vx2, t, dt;
        private TwoSpringOverHead twoSpringOverHead;

        private Size margin = new Size(55, 35);
        private int n = 3;

        private double scaleAnimate = 30;
        private int width1 = 100, width2 = 100, widhtWall, h1 = 20, h2 = 20;
        private Rectangle rect1, rect2;

        private PlotClass plotClass;

        //
        private int transY1, transY2;
        private Point pt0;
        private bool isCatchRect1, isCatchRect2;
        
        
        //------------------------------------ End Variables

        public FormTwoSpringsOverHead()
        {
            InitializeComponent();
            Initialize1();
        }

        private void PrintResults()
        {
            string data =
            "x1   = " + x1.ToString() + "\r\n" +
            "v1  = " + vx1.ToString() + "\r\n" +
            "a1  = " + twoSpringOverHead.Fx1(x1, vx1, vx2).ToString() + "\r\n" + "\r\n" +
            "x2   = " + x2.ToString() + "\r\n" +
            "v2  = " + vx2.ToString() + "\r\n" +
            "a2  = " + twoSpringOverHead.Fx2(x2, vx2, vx1).ToString() + "\r\n" +
            "t     = " + t.ToString() + "\r\n" + "\r\n" +

            "Mechanic energy  = " + "\r\n" +
            twoSpringOverHead.MechanicEnergy(x1, x2, vx1, vx2).ToString() + "\r\n" +
            "\r\n" + "\r\n" + " Distance between two walls = "  + "\r\n"+
            Convert.ToString(widhtWall / scaleAnimate);

            labelResult.Text = data;

        }

        private void Initialize1()
        {
            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
            transY2 = pictureBoxAnimate.Height - h2 / 2 - 2;
            transY1 = pictureBoxAnimate.Height - h2 - h1 / 2 - 2; 

            textBoxv1.Text = "0";
            textBoxm1.Text = "0.5";
            textBoxk1.Text = "5";
            textBoxR1.Text = "3.5";

            textBoxb12.Text = "0.1";
            
            textBoxv2.Text = "0";
            textBoxm2.Text = "0.5";
            textBoxk2.Text = "7";
            textBoxR2.Text = "3.5";

            timer1.Interval = 10;
            dt = 0.005;

            widhtWall = 300;//(int)((3.5 + 3.5) * 2 * scaleAnimate);
            x1 = 4;
            x2 = 7;

            isCatchRect1 = isCatchRect2  = false;

            rect1 = new Rectangle((int)(x1 * scaleAnimate - width1 / 2), -h1 / 2, width1, h1);
            rect2 = new Rectangle((int)(x2 * scaleAnimate - width2 / 2), -h2 / 2, width2, h2);
            //rectWall = new Rectangle(300, -transY, 10, pictureBoxAnimate.Height);
            ResetData();
           
        }// End Initialize1

        private void ResetData()
        {
            twoSpringOverHead = new TwoSpringOverHead();
            twoSpringOverHead.k1 = double.Parse(textBoxk1.Text);
            twoSpringOverHead.m1 = double.Parse(textBoxm1.Text);
            twoSpringOverHead.b12 = double.Parse(textBoxb12.Text);
            twoSpringOverHead.R1 = double.Parse(textBoxR1.Text);
            twoSpringOverHead.m2 = double.Parse(textBoxm2.Text);
            twoSpringOverHead.k2 = double.Parse(textBoxk2.Text);
            twoSpringOverHead.R2 = double.Parse(textBoxR2.Text);
            twoSpringOverHead.width1 = width1 / scaleAnimate;
            twoSpringOverHead.width2 = width2 / scaleAnimate;
            
            vx1 = double.Parse(textBoxv1.Text);
            vx2 = double.Parse(textBoxv2.Text);
            t = 0.0;

            //widhtWall =  (int)((twoSpringOverHead.R1 + twoSpringOverHead.R2) * 2 * scaleAnimate);

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
            pictureBoxCurve.Invalidate();
           
            PrintResults();
            TurnOnMouseHandles();

        }// End ResetData
        private double ValueString(string st, double x1, double vx1, double x2, double vx2, double t)
        {
            switch (st)
            {
                case "x1":
                    return x1;
                case "v1":
                    return vx1;
                case "a1":
                    return twoSpringOverHead.Fx1(x1, vx1, vx2);
                case "x2":
                    return x2;
                case "v2":
                    return vx2;
                case "a2":
                    return twoSpringOverHead.Fx2(x2, vx2, vx1);
                case "Mechanic Energy":
                    return twoSpringOverHead.MechanicEnergy(x1, x2, vx1, vx2);

                case "Elapsed Time":
                    return t;
                default:
                    return 0;

            }
        }// End ValueString

        private void TurnOnMouseHandles()
        {
            pictureBoxAnimate.MouseDown += new MouseEventHandler(pictureBoxAnimate_MouseDown);
            pictureBoxAnimate.MouseMove += new MouseEventHandler(pictureBoxAnimate_MouseMove);
            pictureBoxAnimate.MouseUp += new MouseEventHandler(pictureBoxAnimate_MouseUp);
        }
        private void TurnOffMouseHandles()
        {
            pictureBoxAnimate.MouseDown -= new MouseEventHandler(pictureBoxAnimate_MouseDown);
            pictureBoxAnimate.MouseMove -= new MouseEventHandler(pictureBoxAnimate_MouseMove);
            pictureBoxAnimate.MouseUp -= new MouseEventHandler(pictureBoxAnimate_MouseUp);
        }
        void pictureBoxAnimate_MouseUp(object sender, MouseEventArgs e)
        {
            isCatchRect1 = isCatchRect2 = false;
            pictureBoxAnimate.Invalidate();

        } //pictureBoxAnimate_MouseUp

        void pictureBoxAnimate_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = new Point();
            if (isCatchRect1)
            {
                pt = new Point(e.X, e.Y - transY1);
                rect1.Offset(pt.X - pt0.X, 0);

                if (rect1.X < 0)
                    rect1.X = 0;
                else if (rect1.Right > widhtWall)
                    rect1.X = widhtWall - rect1.Width;
                

                x1 = (rect1.X + rect1.Width / 2) / scaleAnimate;
                plotClass.AddNewPoint(
                    ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
                

            }
            else if (isCatchRect2)
            {
                pt = new Point(-(e.X - widhtWall), e.Y - transY2);
                rect2.Offset(pt.X - pt0.X, 0);
                if (rect2.X < 0)
                    rect2.X = 0;
                else if (rect2.Right > widhtWall)
                    rect2.X = widhtWall - rect2.Width;
                

                x2 = (rect2.X + rect2.Width / 2) / scaleAnimate;

                plotClass.AddNewPoint(
                    ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
               

            }
            
            pt0 = pt;
            pictureBoxAnimate.Invalidate();

        } // pictureBoxAnimate_MouseMove

        void pictureBoxAnimate_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt1 = new Point(e.X, e.Y - transY1);
            Point pt2 = new Point(-(e.X - widhtWall), e.Y - transY2);

            if (rect1.Contains(pt1))
            {
                isCatchRect1 = true;
                pt0 = pt1;
            }
            else if (rect2.Contains(pt2))
            {
                isCatchRect2 = true;
                pt0 = pt2;
            }
           

            pictureBoxAnimate.Invalidate();
        }// pictureBoxAnimate_MouseDown

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
            TurnOffMouseHandles();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= n; i++)
            {
                twoSpringOverHead.UpDate(dt, ref x1, ref vx1, ref x2, ref vx2);
            }
            t += n * dt;
            plotClass.AddNewPoint(
                           ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
            pictureBoxCurve.Invalidate();
            PrintResults();
            pictureBoxAnimate.Invalidate();
        }// End Timer1_Tick

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonPlay.Enabled = true;

            timer1.Tick -= new EventHandler(timer1_Tick);
            timer1.Stop();
            //plotClass.RedrawPoints();
            pictureBoxAnimate.Invalidate();

        }

        private void buttonResetData_Click(object sender, EventArgs e)
        {
            TurnOffMouseHandles();
            ResetData();
            pictureBoxAnimate.Invalidate();
        }
        private void DoingClear()
        {
            plotClass.ClearData();
            plotClass.AddNewPoint(
               ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
            pictureBoxCurve.Invalidate();

            pictureBoxAnimate.Invalidate();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            DoingClear();
        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            plotClass.RepeatDrawingPointsMap();
            pictureBoxAnimate.Invalidate();
            pictureBoxCurve.Invalidate();

        }

        private void buttonMoreDetail_Click(object sender, EventArgs e)
        {
            FormMoreDetail formMoreDetail  = new FormMoreDetail(plotClass, scaleAnimate, dt, timer1.Interval / 1000.0, n);

            DialogResult dialog = formMoreDetail.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                scaleAnimate = formMoreDetail.scaleAnimate;
                this.n = formMoreDetail.n;
                this.dt = formMoreDetail.h;
                timer1.Interval = (int)(formMoreDetail.timerInterval * 1000);
            }
            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
        }

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
            pictureBoxAnimate.Invalidate();
        }

        private void comboBoxY_TextChanged(object sender, EventArgs e)
        {
            ResetData();
           
            pictureBoxAnimate.Invalidate();

            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;

        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.Black), widhtWall, 0, 10, pictureBoxAnimate.Height);  // draw wall

            Color colorSpring;
            int lspring, peaks;
            Point[] pts;
            int temp = -6;
            GraphicsState gState = g.Save();

            // Draw x1, x2
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            g.DrawLine(new Pen(Color.DarkBlue), 0, 5, 40, 5);
            Point[] ptArrow1 = new Point[3] { new Point(40 - 5, 5 - 3), new Point(40, 5), new Point(40 - 5, 5 + 3)};
            g.DrawLines(new Pen(Color.DarkBlue), ptArrow1);
            g.DrawString("x1", font, new SolidBrush(Color.DarkBlue), 40-3, 5);

            g.DrawLine(new Pen(Color.DarkRed), widhtWall, 5, widhtWall - 40, 5);
            Point[] ptArrow2 =
                new Point[3] { 
                new Point(widhtWall - 40 + 5, 5 - 3), new Point(widhtWall - 40, 5), new Point(widhtWall -40+ 5, 5 + 3)};
            g.DrawLines(new Pen(Color.DarkRed), ptArrow2);
            g.DrawString("x2", font, new SolidBrush(Color.DarkRed), widhtWall - 40 - 10, 5);

            //-------------------

            // Draw spring1
            g.TranslateTransform(0, transY1);
            colorSpring = Color.Green;
            if (x1 - twoSpringOverHead.width1 / 2 < twoSpringOverHead.R1)
                colorSpring = Color.Red;

            rect1.X = (int)(x1 * scaleAnimate) - rect1.Width / 2;

            peaks = 22;
            lspring = rect1.X;
            pts = new Point[peaks + 4];
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (lspring - 10) / (2 * peaks), temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(lspring - 5, 0);
            pts[pts.Length - 1] = new Point(lspring, 0);

            g.DrawLines(new Pen(colorSpring), pts);
            g.FillRectangle(new SolidBrush(Color.DarkBlue), rect1);  // draw mass1
            g.FillRectangle(new SolidBrush(Color.White), rect1.X + rect1.Width / 2 - 2,
                rect1.Y + rect1.Height / 2 - 2, 4, 4);  // draw center of mass1

            //-------------------------------------

            // Drawing spring 2
            g.Restore(gState);
            g.TranslateTransform(widhtWall, transY2);
            g.ScaleTransform(-1, 1);

            colorSpring = Color.Green;
            if (x2 - twoSpringOverHead.width2 / 2 < twoSpringOverHead.R2)
                colorSpring = Color.Red;

            rect2.X = (int)(x2 * scaleAnimate) - rect2.Width / 2;

            peaks = 22;
            lspring = rect2.X;
            pts = new Point[peaks + 4];
            temp = -6;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (lspring - 10) / (2 * peaks), temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(lspring - 5, 0);
            pts[pts.Length - 1] = new Point(lspring, 0);

            g.DrawLines(new Pen(colorSpring), pts);
            g.FillRectangle(new SolidBrush(Color.DarkRed), rect2);  // draw mass2
            g.FillRectangle(new SolidBrush(Color.White), rect2.X + rect2.Width / 2 - 2,
                rect2.Y + rect2.Height / 2 - 2, 4, 4);  // draw cenetr mass 2

            //---------------------------------------------

            GraphicsPath gp = new GraphicsPath();
           

        }

        private void pictureBoxCurve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxCurve.Height);
            g.ScaleTransform(1, -1);

            g.DrawImage(plotClass.map, 0, 0);
            Rectangle rectPtHead = new Rectangle(plotClass.ptHead - new Size(3, 3), new Size(6, 6));
            g.DrawRectangle(new Pen(Color.Black), rectPtHead);
        }

        private void FormTwoSpringsOverHead_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
            }
        }

        private void buttonTakeCurvePic_Click(object sender, EventArgs e)
        {
            string dir = this.Text + " Images";
            System.IO.Directory.CreateDirectory(dir);
            string st0 = dir + "\\" + labelY.Text + "(" + labelX.Text + ")";
            string file0 = st0 + ".jpg";
            string file = file0;
            if (System.IO.File.Exists(file))
            {
                int i = 1;
                do { file = st0 + "_" + i + ".jpg"; i++; }
                while (System.IO.File.Exists(file));
            }

            Bitmap curveBit = new Bitmap(pictureBoxCurve.Width, pictureBoxCurve.Height);
            pictureBoxCurve.DrawToBitmap(curveBit, new Rectangle(0, 0, pictureBoxCurve.Width, pictureBoxCurve.Height));
            curveBit.Save(file);
            curveBit.Dispose();
        }
    }

    //*******************************************************
    //*******************************************************
    public class TwoSpringOverHead
    {
        public double m1, b12, k1, R1, m2, k2, R2;
        public double width1, width2;
        public TwoSpringOverHead()
        {
        }
        public TwoSpringOverHead(double m1, double b12, double width1, double k1, double R1,
            double m2, double width2, double k2, double R2)
        {
            this.m1 = m1;
            this.b12 = b12;
            this.width1 = width1;
            this.k1 = k1;
            this.R1 = R1;
            this.m2 = m2;
            this.width2 = width2;
            this.k2 = k2;
            this.R2 = R2;
        }

        public double Fx1(double x1, double vx1,double vx2)
        {
            return -k1 * (x1 - R1 - width1 / 2) / m1 - b12 * (vx1 + vx2) / m1;
        }
        public double Fx2(double x2, double vx2, double vx1)
        {
            return -k2 * (x2 - R2 - width2 / 2) / m2 - b12 * (vx1 + vx2) / m2;
        }
        

        public void UpDate(double dt, ref double x1, ref double vx1, ref double x2, ref double vx2)
        {
            double Ax1, Bx1, Cx1, Dx1, Av1, Bv1, Cv1, Dv1; // Runge Kutta method 
            double Ax2, Bx2, Cx2, Dx2, Av2, Bv2, Cv2, Dv2; // Runge Kutta method

            Ax1 = vx1 * dt;
            Av1 = Fx1(x1, vx1, vx2) * dt;
            Ax2 = vx2 * dt;
            Av2 = Fx2(x2, vx2, vx1) * dt;

            Bx1 = (vx1 + Av1 / 2) * dt;
            Bv1 = Fx1(x1 + Ax1 / 2, vx1 + Av1 / 2, vx2 + Av2 / 2) * dt;
            Bx2 = (vx2 + Av2 / 2) * dt;
            Bv2 = Fx2(x2 + Ax2 / 2, vx2 + Av2 / 2, vx1 + Av1 / 2) * dt;

            Cx1 = (vx1 + Bv1 / 2) * dt;
            Cv1 = Fx1(x1 + Bx1 / 2, vx1 + Bv1 / 2, vx2 + Bv2 / 2) * dt;
            Cx2 = (vx2 + Bv2 / 2) * dt;
            Cv2 = Fx2(x2 + Bx2 / 2, vx2 + Bv2 / 2, vx1 + Bv1 / 2) * dt;

            Dx1 = (vx1 + Cv1) * dt;
            Dv1 = Fx1(x1 + Cx1, vx1 + Cv1, vx2 + Cv2) * dt;
            Dx2 = (vx2 + Cv2) * dt;
            Dv2 = Fx2(x2 + Cx2, vx2 + Cv2, vx1 + Cv1) * dt;

            x1 += (Ax1 + 2 * Bx1 + 2 * Cx1 + Dx1) / 6;
            x2 += (Ax2 + 2 * Bx2 + 2 * Cx2 + Dx2) / 6;
            vx1 += (Av1 + 2 * Bv1 + 2 * Cv1 + Dv1) / 6;
            vx2 += (Av2 + 2 * Bv2 + 2 * Cv2 + Dv2) / 6;

            
        }
        public double MechanicEnergy(double x1, double x2, double vx1, double vx2)
        {
            return k1 / 2 * (x1 - R1 - width1 / 2) * (x1 - R1 - width1 / 2) + m1 / 2 * vx1 * vx1 +
                k2 / 2 * (x2 - R2 - width2 / 2) * (x2 - R2 - width2 / 2) + m2 / 2 * vx2 * vx2;
        }
    }
}