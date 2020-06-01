using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormSimpleCollision : Form
    {
        // ---------------------------variables
        private double x1, vx1, x2, vx2, t, dt;
        private SimpleCollision simpleCollision;

        private Size margin = new Size(55, 35);
        private int n = 3;

        private double scaleAnimate = 30;
        int widthBlocks = 30;
        private Rectangle rect1, rect2, rectWall;

        private PlotClass plotClass;

        //
        private int transY;
        private Point pt0;
        private bool isCatchRect1, isCatchRect2, isCathRectWall;
        //------------------------------------ End Variables


        public FormSimpleCollision()
        {
            InitializeComponent();
            Initialize1();
            
        }

        private void PrintResults()
        {
            string data =
            "x1   = " + x1.ToString() + "\r\n" +
            "v1  = " + vx1.ToString() + "\r\n" +
            "a1  = " + simpleCollision.Fx1(x1, vx1).ToString() + "\r\n" +
            "x2   = " + x2.ToString() + "\r\n" +
            "v2  = " + vx2.ToString() + "\r\n" +
            "a2  = " + simpleCollision.Fx2(x2, vx2).ToString() + "\r\n" +
            "t     = " + t.ToString() + "\r\n" + "\r\n" +

            "Mechanic energy  = " + "\r\n" +
            simpleCollision.MechanicEnergy(x1, vx1, vx2).ToString() + "\r\n";

            labelResult.Text = data;

        }

        private void Initialize1()
        {
            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
            transY = pictureBoxAnimate.Height - widthBlocks / 2;

            textBoxv1.Text = "0";
            textBoxm1.Text = "0.5";
            textBoxb1.Text = "0";
            textBoxk.Text = "5";
            textBoxR.Text = "2.5";

            textBoxv2.Text = "-4";
            textBoxm2.Text = "0.5";
            textBoxb2.Text = "0";

            textBoxeBlock.Text = "1";
            textBoxeWall.Text = "1";


            timer1.Interval = 10;
            dt = 0.005;

            x1 = 4;
            x2 = 8;

            isCatchRect1 = isCatchRect2 = isCathRectWall = false;

            rect1 = new Rectangle((int)(x1 * scaleAnimate - widthBlocks / 2), -widthBlocks / 2, widthBlocks, widthBlocks);
            rect2 = new Rectangle((int)(x2 * scaleAnimate - widthBlocks / 2), -widthBlocks / 2, widthBlocks, widthBlocks);
            rectWall = new Rectangle(300, -transY, 10, pictureBoxAnimate.Height);
            ResetData();
            
        }// End Initialize1

        private void ResetData()
        {
            simpleCollision = new SimpleCollision();
            simpleCollision.k = double.Parse(textBoxk.Text);
            simpleCollision.m1 = double.Parse(textBoxm1.Text);
            simpleCollision.b1 = double.Parse(textBoxb1.Text);
            simpleCollision.R = double.Parse(textBoxR.Text);
            simpleCollision.m2 = double.Parse(textBoxm2.Text);
            simpleCollision.b2 = double.Parse(textBoxb2.Text);
            simpleCollision.eBlocks = double.Parse(textBoxeBlock.Text);
            simpleCollision.eWall = double.Parse(textBoxeWall.Text);
            simpleCollision.l1 = widthBlocks / scaleAnimate;
            simpleCollision.l2 = widthBlocks / scaleAnimate;
            simpleCollision.lWall = rectWall.X / scaleAnimate;

            vx1 = double.Parse(textBoxv1.Text);
            vx2 = double.Parse(textBoxv2.Text);
            t = 0.0;

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
                    return simpleCollision.Fx1(x1, vx1);
                case "x2":
                    return x2;
                case "v2":
                    return vx2;
                case "a2":
                    return simpleCollision.Fx2(x2, vx2);
                case "Mechanic Energy":
                    return simpleCollision.MechanicEnergy(x1, vx1, vx2);
                
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
            isCatchRect1 = isCatchRect2 = isCathRectWall = false;
            pictureBoxAnimate.Invalidate();
            
        } //pictureBoxAnimate_MouseUp

        void pictureBoxAnimate_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y - transY);
            if (isCatchRect1)
            {
                rect1.Offset((pt.X - pt0.X), 0);

                if (rect1.X < 0)
                    rect1.X = 0;
                else if (rect1.Right > rectWall.X)
                    rect1.X = rectWall.X - rect1.Width;
                else if (rect1.IntersectsWith(rect2))
                    rect1.X = rect1.X > rect2.X ? rect2.Right : rect2.X - rect1.Width;

                x1 = (rect1.X + rect1.Width / 2) / scaleAnimate;

                plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
              
               
            }
            else if (isCatchRect2)
            {
                rect2.Offset((pt.X - pt0.X), 0);
                if (rect2.X < 0)
                    rect2.X = 0;
                else if (rect2.Right > rectWall.X)
                    rect2.X = rectWall.X - rect2.Width;
                else if (rect2.IntersectsWith(rect1))
                {
                    int dx = e.X - rect2.X;
                    rect2.X = rect2.X > rect1.X ? rect1.X - rect2.Width : rect1.Right;
                    Cursor.Position = pictureBoxAnimate.PointToScreen(new Point(rect2.X + dx, e.Y));
                    pt.X = rect2.X + dx;
                }

                x2 = (rect2.X + rect2.Width / 2) / scaleAnimate;

                plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, x1, vx1, x2, vx2, t), ValueString(comboBoxY.Text, x1, vx1, x2, vx2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
              
            }
            else if (isCathRectWall)
            {
                rectWall.Offset((pt.X - pt0.X), 0);

                if (rectWall.X < 0)
                    rectWall.X = 0;
                else if (rectWall.Right > pictureBoxAnimate.Width)
                    rectWall.X = pictureBoxAnimate.Width - rectWall.Width;
                else if (rectWall.IntersectsWith(rect1))
                    rectWall.X = rectWall.X > rect1.X ? rect1.Right : rect1.X - rectWall.Width;
                else if (rectWall.IntersectsWith(rect2))
                    rectWall.X = rectWall.X > rect2.X ? rect2.Right : rect2.X - rectWall.Width;

                simpleCollision.lWall = rectWall.X / scaleAnimate;
            }
            pt0 = pt;
            pictureBoxAnimate.Invalidate();

        } // pictureBoxAnimate_MouseMove

        void pictureBoxAnimate_MouseDown(object sender, MouseEventArgs e)
        {
            pt0 = new Point(e.X, e.Y - transY);

            if (rect1.Contains(pt0))
                isCatchRect1 = true;
            else if (rect2.Contains(pt0))
                isCatchRect2 = true;
            else if (rectWall.Contains(pt0))
                isCathRectWall = true;

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
                simpleCollision.UpDate(dt, ref x1, ref vx1, ref x2, ref vx2);
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
            g.TranslateTransform(0, transY);



            // Draw spring
            Color colorSpring = Color.Green;
            if (x1 - simpleCollision.l1 / 2 < simpleCollision.R)
                colorSpring = Color.Red;

            rect1.X = (int)(x1 * scaleAnimate) - rect1.Width / 2;

            int peak = 13;
            int lspring = rect1.X;
            Point[] pts = new Point[peak + 4];

            int temp = -10;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (lspring - 10) / (2 * peak), temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(lspring - 5, 0);
            pts[pts.Length - 1] = new Point(lspring, 0);

            g.DrawLines(new Pen(colorSpring), pts);
            //
            g.FillRectangle(new SolidBrush(Color.DarkBlue), rect1);  // draw mass1

            // Mass2
            rect2.X = (int)(x2 * scaleAnimate) - rect2.Width / 2;
            g.FillRectangle(new SolidBrush(Color.DarkRed), rect2);  // draw mass1


            g.FillRectangle(new SolidBrush(Color.Black), rectWall);  // draw wall right


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

        private void FormSimpleCollision_FormClosing(object sender, FormClosingEventArgs e)
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
    //******************************************************
    //******************************************************
    public class SimpleCollision
    {
        public double m1, b1, k, R, m2, b2, eBlocks, eWall;
        public double l1, l2, lWall;
        public SimpleCollision()
        {
        }
        public SimpleCollision(double m1, double b1, double l1, double k, double R, double m2, double b2,
             double l2, double eBlocks, double eWall, double lWall)
        {
            this.m1 = m1;
            this.b1 = b1;
            this.l1 = l1;
            this.k = k;
            this.R = R;
            this.m2 = m2;
            this.b2 = b2;
            this.l2 = l2;
            this.eBlocks = eBlocks;
            this.eWall = eWall;
            this.lWall = lWall;
        }

        public double Fx1(double x1, double vx1)
        {
            return -k * (x1 - R - l1 / 2) / m1 - b1 * vx1 / m1;
        }
        public double Fx2(double x2, double vx2)
        {
            return -b2 * vx2 / m2;
        }
        public bool IsContactedBlocks(double x1, double l1, double x2, double l2)
        {
            if (Math.Abs(x1 - x2) < l1 / 2 + l2 / 2)
                return true;
            else
                return false;
        }
        public bool IsContactBlockToWall(double x, double l)
        {
            if (x - l / 2 < 0 || x + l / 2 > lWall)
                return true;
            else
                return false;
        }

        public void AftherContactBlocks(ref double x1, double l1, double x2, double l2)
        {
            double dx = (l1 / 2 + l2 / 2) - Math.Abs(x1 - x2);
            x1 = x1 > x2 ? x1 + dx : x1 - dx;

        }
        public void AftherContactBlocks(ref double x1, ref double vx1, ref double x2, ref double vx2)
        {
            double vx1_f = ((m1 - eBlocks * m2) * vx1 + m2 * (1 + eBlocks) * vx2) / (m1 + m2);
            double vx2_f = (m1 * (1 + eBlocks) * vx1 + (m2 - eBlocks * m1) * vx2) / (m1 + m2);

            vx1 = vx1_f;
            vx2 = vx2_f;

            double dx = (l1 / 2 + l2 / 2) - Math.Abs(x1 - x2);


            //x1 = x1 > x2 ? x1 + dx / 2 : x1 - dx / 2;
            x2 = x2 > x1 ? x2 + dx : x2 - dx;

        }
        public void AftherContactWithWall(ref double x, double l)
        {
            if (x - l / 2 < 0)
                x = l / 2;
            else if (x + l / 2 > lWall)
                x = lWall - l / 2;
        }
        public void AftherContactWithWall(ref double x, ref double vx, double l)
        {
            vx = -eWall * vx;
            if (x - l / 2 < 0)
                x = l / 2;
            else if (x + l / 2 > lWall)
                x = lWall - l / 2;
        }
        

        public void UpDate(double dt, ref double x1, ref double vx1, ref double x2, ref double vx2)
        {
            double Ax1, Bx1, Cx1, Dx1, Av1, Bv1, Cv1, Dv1; // Runge Kutta method 
            double Ax2, Bx2, Cx2, Dx2, Av2, Bv2, Cv2, Dv2; // Runge Kutta method

            Ax1 = vx1 * dt;
            Av1 = Fx1(x1, vx1) * dt;
            Ax2 = vx2 * dt;
            Av2 = Fx2(x2, vx2) * dt;

            Bx1 = (vx1 + Av1 / 2) * dt;
            Bv1 = Fx1(x1 + Ax1 / 2, vx1 + Av1 / 2) * dt;
            Bx2 = (vx2 + Av2 / 2) * dt;
            Bv2 = Fx2(x2 + Ax2 / 2, vx2 + Av2 / 2) * dt;

            Cx1 = (vx1 + Bv1 / 2) * dt;
            Cv1 = Fx1(x1 + Bx1 / 2, vx1 + Bv1 / 2) * dt;
            Cx2 = (vx2 + Bv2 / 2) * dt;
            Cv2 = Fx2(x2 + Bx2 / 2, vx2 + Bv2 / 2) * dt;

            Dx1 = (vx1 + Cv1) * dt;
            Dv1 = Fx1(x1 + Cx1, vx1 + Cv1) * dt;
            Dx2 = (vx2 + Cv2) * dt;
            Dv2 = Fx2(x2 + Cx2, vx2 + Cv2) * dt;

            x1 += (Ax1 + 2 * Bx1 + 2 * Cx1 + Dx1) / 6;
            x2 += (Ax2 + 2 * Bx2 + 2 * Cx2 + Dx2) / 6;
            vx1 += (Av1 + 2 * Bv1 + 2 * Cv1 + Dv1) / 6;
            vx2 += (Av2 + 2 * Bv2 + 2 * Cv2 + Dv2) / 6;

            if (IsContactedBlocks(x1, l1, x2, l2))
                AftherContactBlocks(ref x1, ref vx1, ref x2, ref vx2);
            if (IsContactBlockToWall(x2, l2))
                AftherContactWithWall(ref x2, ref vx2, l2);
            if (IsContactBlockToWall(x1, l1))
                AftherContactWithWall(ref x1, ref vx1, l1);
            
        }
        public double MechanicEnergy(double x1, double vx1, double vx2)
        {
            return k / 2 * (x1 - R - l1/2) * (x1 - R - l1/2) + m1 / 2 * vx1 * vx1 + m2 / 2 * vx2 * vx2;
        }
    }

}