using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormDoubleSpring2D : Form
    {
        //--------------- Variables
        private double x1, vx1, t, y1, vy1, x2, vx2, y2, vy2;

        private DoubleSpring2D doubleSpring2D;
        //private ArrayList X, V, Elapsehime;

        Size margin = new Size(55, 35);
        private int n = 5;

        private double  dt = 0.005;
        double scaleAnimate = 30;

        private PlotClass plotClass;

        //_________________________________________________

        private void PrintResult()
        {
            labelResult.Text =
                "x1 = " + x1.ToString() + "\r\n" +
                "y1 = " + y1.ToString() + "\r\n" +
                "vx1 = " + vx1.ToString() + "\r\n" +
                "vy1 = " + vy1.ToString() + "\r\n" +
                "ax1 = " + doubleSpring2D.AccelerationX1(x1, y1, vx1, x2, y2).ToString() + "\r\n" +
                "ay1 = " + doubleSpring2D.AccelerationY1(x1, y1, vy1, x2, y2).ToString() + "\r\n\r\n" +

                "x2 = " + x2.ToString() + "\r\n" +
                "y2 = " + y2.ToString() + "\r\n" +
                "vx2 = " + vx2.ToString() + "\r\n" +
                "vy2 = " + vy2.ToString() + "\r\n" +
                "ax2 = " + doubleSpring2D.AccelerationX2(x1, y1, x2, y2, vx2).ToString() + "\r\n" +
                "ay2 = " + doubleSpring2D.AccelerationY2(x1, y1, x2, y2, vy2).ToString() + "\r\n\r\n" +

                "Kinetic E =\r\n" + doubleSpring2D.KineticEnergy(vx1, vy1, vx2, vy2).ToString() + "\r\n" +
                "Potential E =\r\n" + doubleSpring2D.PotentialEnergy(x1, y1, x2, y2).ToString() + "\r\n" +
                "Mechanical E =\r\n" + doubleSpring2D.MechanicEnergy(x1, y1, x2, y2, vx1, vy1, vx2, vy2).ToString() +
                "\r\n\r\n" + "t = " + t.ToString();
        }
        public FormDoubleSpring2D()
        {
            InitializeComponent();
            InitControlsLocation();
            Initialize1();

            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;
          
        }

        private void InitControlsLocation()
        {
            int vertical = 650;
            pictureBoxCurve.Size = new Size(700, vertical);
            pictureBoxAnimate.Size = new Size(300, vertical);
            pictureBoxAnimate.Location = new Point(pictureBoxCurve.Location.X + pictureBoxCurve.Width + 1,
                pictureBoxCurve.Location.Y);
            labelResult.Location = new Point(pictureBoxAnimate.Location.X + pictureBoxAnimate.Width + 2,
                pictureBoxCurve.Location.Y);
            labelX.Location = new Point(labelX.Location.X,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Size.Height - 20);

            buttonStop.Location = new Point(pictureBoxAnimate.Location.X - buttonStop.Width,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Size.Height + 10);
            buttonPlay.Location = new Point(buttonStop.Location.X - 5 - buttonPlay.Width,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Height + 10);

            buttonMoreDetail.Location = new Point(pictureBoxCurve.Location.X,
                pictureBoxCurve.Location.Y + pictureBoxCurve.Height + 10);
            buttonTakeCurvePic.Location = new Point(buttonMoreDetail.Right + 20, buttonMoreDetail.Location.Y);
        }


        private void Initialize1()
        {
            textBoxx1.Text = "2";
            textBoxy1.Text = "3";
            textBoxvx1.Text = "0";
            textBoxvy1.Text = "0";
            textBoxk1.Text = "7";
            textBoxm1.Text = "0.5";
            textBoxR1.Text = "2";
            textBoxb1.Text = "0";

            textBoxx2.Text = "4";
            textBoxy2.Text = "4";
            textBoxvx2.Text = "0";
            textBoxvy2.Text = "1";
            textBoxk2.Text = "7";
            textBoxm2.Text = "0.5";
            textBoxR2.Text = "2";
            textBoxb2.Text = "0";

            textBoxg.Text = "9.8";

            timer1.Interval = 10;
            dt = 0.005;
            n = 4;

            ResetData();
            PrintResult();
       
        }// End Initialize1
        private void ResetData()
        {
            //X = new ArrayList();
            //V = new ArrayList();
            //Elapsehime = new ArrayList();

            doubleSpring2D = new DoubleSpring2D();
            doubleSpring2D.k1 = double.Parse(textBoxk1.Text);
            doubleSpring2D.m1 = double.Parse(textBoxm1.Text);
            doubleSpring2D.R1 = double.Parse(textBoxR1.Text);
            doubleSpring2D.b1 = double.Parse(textBoxb1.Text);
            
            doubleSpring2D.k2 = double.Parse(textBoxk2.Text);
            doubleSpring2D.m2 = double.Parse(textBoxm2.Text);
            doubleSpring2D.R2 = double.Parse(textBoxR2.Text);
            doubleSpring2D.b2 = double.Parse(textBoxb2.Text);

            doubleSpring2D.g = double.Parse(textBoxg.Text);

            

            x1 = double.Parse(textBoxx1.Text);
            y1 = double.Parse(textBoxy1.Text);
            vx1 = double.Parse(textBoxvx1.Text); 
            vy1 = double.Parse(textBoxvy1.Text);

            x2 = double.Parse(textBoxx2.Text);
            y2 = double.Parse(textBoxy2.Text);
            vx2 = double.Parse(textBoxvx2.Text);
            vy2 = double.Parse(textBoxvy2.Text);

            t = 0.0;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);          

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t),
                ValueString(comboBoxY.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t));
            
            pictureBoxCurve.Invalidate();
        }// End ResetData


        private double ValueString(string st, double x1, double vx1, double y1, double vy1,
            double x2, double vx2, double y2, double vy2,  double t)
        {
            switch (st)
            {
                case "r1":
                    return doubleSpring2D.L1(x1, y1);
                case "theta1":
                    return doubleSpring2D.AngleD1(x1, y1);
                case "x1":
                    return x1;
                case "vx1":
                    return vx1;
                case "y1":
                    return y1;
                case "vy1":
                    return vy1;

                case "r2":
                    return doubleSpring2D.L2(x1, y1, x2, y2);
                case "theta2":
                    return doubleSpring2D.AngleD2(x1, y1, x2, y2);

                case "x2":
                    return x2;
                case "vx2":
                    return vx2;
                case "y2":
                    return y2;
                case "vy2":
                    return vy2;

                case "Kinetic Energy1":
                    return doubleSpring2D.KineticEnergy1(vx1, vy1);

                case "Kinetic Energy2":
                    return doubleSpring2D.KineticEnergy2(vx2, vy2);

                case "Kinetic Energy":
                    return doubleSpring2D.KineticEnergy(vx1, vy1, vx2, vy2);

                case "Potential Energy":
                    return doubleSpring2D.PotentialEnergy(x1, y1, x2, y2);

                case "Mechanic Energy":
                    return doubleSpring2D.MechanicEnergy(x1, y1, x2, y2, vx1, vy1, vx2, vy2);

                case "ax1":
                    return doubleSpring2D.AccelerationX1(x1, y1, vx1, x2, y2);
                case "ay1":
                    return doubleSpring2D.AccelerationY1(x1, y1,vy1, x2, y2);

                case "ax2":
                    return doubleSpring2D.AccelerationX2(x1, y1, x2, y2, vx2);
                case "ay2":
                    return doubleSpring2D.AccelerationY2(x1, y1, x2, y2, vy2);

                case "RadialDot1":
                    return doubleSpring2D.RadialDot1(x1, y1, vx1, vx2);
                case "AngularDot1":
                    return doubleSpring2D.AngularDot1(x1, y1, vx1, vx2);

                case "RadialDot2":
                    return doubleSpring2D.RadialDot2(x1, y1, vx1, vx2, x2, y2, vx2, vy2);
                case "AngularDot2":
                    return doubleSpring2D.AngularDot2(x1, y1, vx1, vx2, x2, y2, vx2, vy2);

                case "t":
                    return t;
                default:
                    return 0.0;

            }
        }// End ValueString

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }
        void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= n; i++)
            {
                doubleSpring2D.NextVar(dt, ref x1, ref vx1, ref y1, ref vy1, ref x2, ref vx2, ref y2, ref vy2);
            }
            t += n * dt;

            plotClass.AddNewPoint(
                 ValueString(comboBoxX.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t),
                 ValueString(comboBoxY.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t));
            pictureBoxCurve.Invalidate();

            PrintResult();
            pictureBoxAnimate.Invalidate();

        }// End Timer1_Tick

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonPlay.Enabled = true;

            timer1.Tick -= new EventHandler(timer1_Tick);
            timer1.Stop();

            //plotClass.RedrawPoints();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();

            plotClass.AddNewPoint(
                 ValueString(comboBoxX.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t),
                 ValueString(comboBoxY.Text, x1, vx1, y1, vy1, x2, vx2, y2, vy2, t));
            pictureBoxCurve.Invalidate();

            pictureBoxAnimate.Invalidate();

        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
            plotClass.RepeatDrawingPointsMap();
            pictureBoxCurve.Invalidate();

        }

        private void buttonResetData_Click(object sender, EventArgs e)
        {
            ResetData();
            PrintResult();
            pictureBoxAnimate.Invalidate();

        }

        private void buttonMoreDetail_Click(object sender, EventArgs e)
        {
            FormMoreDetail formMoreDetail = new FormMoreDetail(plotClass, scaleAnimate, dt, timer1.Interval / 1000.0, n);

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

        private void checkBoxAnimate_CheckedChanged(object sender, EventArgs e)
        {
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
            PrintResult();
            pictureBoxAnimate.Invalidate();

            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;

        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            
            int lMases = 10;
            double L1 = doubleSpring2D.L1(x1, y1);
            Color color = Color.Green;
            if (L1 < doubleSpring2D.R1)
                color = Color.Red;
            else if (L1 == doubleSpring2D.R1)
                color = Color.White;

            // Draw spring
            int peak = 13;
            int l1 = (int)(scaleAnimate * L1) - lMases;
            Point[] pts = new Point[peak + 4];

            int temp = -8;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (l1 - 10) / (2 * peak), 0 + temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(l1 - 5, 0);
            pts[pts.Length - 1] = new Point(l1, 0);
            // end define spring1

            Rectangle rectOfMass = new Rectangle(l1, -lMases, 2*lMases, 2*lMases);

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 2, 100);
            g.FillRectangle(new SolidBrush(Color.Black), -2, -4, 4, 4);

            // Draw x y
            g.DrawLine(new Pen(Color.Blue), 0, 0, 40, 0);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));            
            g.DrawString("x", font, new SolidBrush(Color.Blue), 40,-7);
            g.DrawLine(new Pen(Color.Blue), 0, 0, 0, 40);
            g.DrawString("y", font, new SolidBrush(Color.Blue), -4, 38);
            //-----



            GraphicsState gs = g.Save();

            g.RotateTransform(90 - (float)doubleSpring2D.AngleD1(x1, y1));

            g.DrawLines(new Pen(color), pts);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectOfMass);
            g.Restore(gs);
            //End drqwing mass1



            // drawing spring 2
            double L2 = doubleSpring2D.L2(x1, y1, x2, y2);
            color = Color.Green;
            if (L2 < doubleSpring2D.R2)
                color = Color.Red;
            else if (L2 == doubleSpring2D.R2)
                color = Color.White;
            peak = 13;
            int l2 = (int)(scaleAnimate * L2) - lMases;
            pts = new Point[peak + 4];

            temp = -8;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(15 + (2 * i - 3) * (l2 - 20) / (2 * peak), 0 + temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(15, 0);
            pts[pts.Length - 2] = new Point(l2 - 5, 0);
            pts[pts.Length - 1] = new Point(l2, 0);
            // end define spring2

            int translatex = (int)(((l1+rectOfMass.Width/2) * Math.Sin(doubleSpring2D.AngleD1(x1, y1)*Math.PI/180)));
            int translatey = (int)(((l1+rectOfMass.Height/2) * Math.Cos(doubleSpring2D.AngleD1(x1, y1)*Math.PI/180)));
            g.TranslateTransform(translatex, translatey);

            g.RotateTransform(90 - (float) doubleSpring2D.AngleD2(x1, y1, x2, y2));

            rectOfMass = new Rectangle(l2, 0 - lMases, 2*lMases, 2*lMases);

            g.DrawLines(new Pen(color), pts);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectOfMass);



            

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

        private void FormDoubleSpring2D_FormClosing(object sender, FormClosingEventArgs e)
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
    //---- End Form
    //***********************************************************************
    //***********************************************************************
    public class DoubleSpring2D
    {
        // k = spring constant, b = damping constant, R = rest lenght of spring, m = mass of Block
        public double k1, R1, m1, b1, k2, R2, m2, b2, g;
        public DoubleSpring2D()
        {
        }
        public DoubleSpring2D(double k1, double R1, double m1, double b1, 
            double k2, double R2, double m2, double b2, double g)
        {
            this.k1 = k1;
            this.R1 = R1;
            this.m1 = m1;
            this.b1 = b1;

            this.k2 = k2;
            this.R2 = R2;
            this.m2 = m2;
            this.b2 = b2;
            this.g = g;
        }

        public double L1(double x1, double y1)
        {
            return Math.Sqrt(x1 * x1 + y1 * y1);
        }
        public double L1_2(double x1, double y1)
        {
            return (x1 * x1 + y1 * y1);
        }
        public double L2(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        public double L2_2(double x1, double y1, double x2, double y2)
        {
            return ((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }


        private double Fx1(double x1, double y1, double vx1, double x2, double y2)
        {
            double S1 = L1(x1, y1) - R1;
            double S2 = L2(x1, y1, x2, y2) - R2;
            double sinTeta1 = x1 / L1(x1, y1);
            double sinTeta2 = (x2 - x1) / L2(x1, y1, x2, y2);

            return -k1 / m1 * S1 * sinTeta1 - b1 / m1 * vx1 + k2 / m1 * S2 * sinTeta2;
        }
        private double Fy1(double x1, double y1, double vy1, double x2, double y2)
        {
            double S1 = L1(x1, y1) - R1;
            double S2 = L2(x1, y1, x2, y2) - R2;
            double cosTeta1 = y1 / L1(x1, y1);
            double cosTeta2 = (y2 - y1) / L2(x1, y1, x2, y2);

            return -k1 / m1 * S1 * cosTeta1 - b1 / m1 * vy1 + k2 / m1 * S2 * cosTeta2 + g;
        }

        private double Fx2(double x1, double y1, double x2, double y2, double vx2)
        {
            double S2 = L2(x1, y1, x2, y2) - R2;
            double sinTeta2 = (x2 - x1) / L2(x1, y1, x2, y2);

            return -k2 / m2 * S2 * sinTeta2 - b2 / m2 * vx2;
        }

        private double Fy2(double x1, double y1, double x2, double y2, double vy2)
        {
            double S2 = L2(x1, y1, x2, y2) - R2;
            double cosTeta2 = (y2 - y1) / L2(x1, y1, x2, y2);

            return -k2 / m2 * S2 * cosTeta2 - b2 / m2 * vy2 + g;
        }

        public void NextVar(double dt,
            ref double x1, ref double vx1, ref double y1, ref double vy1,
            ref double x2, ref double vx2, ref double y2, ref double vy2)
        {
            // dt = deltat
            double Ax1, Bx1, Cx1, Dx1, Avx1, Bvx1, Cvx1, Dvx1; // Runge Kutta method 
            double Ay1, By1, Cy1, Dy1, Avy1, Bvy1, Cvy1, Dvy1; // Runge Kutta method
            double Ax2, Bx2, Cx2, Dx2, Avx2, Bvx2, Cvx2, Dvx2; // Runge Kutta method 
            double Ay2, By2, Cy2, Dy2, Avy2, Bvy2, Cvy2, Dvy2; // Runge Kutta method

            Ax1 = vx1 * dt;
            Avx1 = Fx1(x1, y1, vx1, x2, y2) * dt;
            Ay1 = vy1 * dt;
            Avy1 = Fy1(x1, y1, vy1, x2, y2) * dt;

            Ax2 = vx2 * dt;
            Avx2 = Fx2(x1, y1, x2, y2, vx2) * dt;
            Ay2 = vy2 * dt;
            Avy2 = Fy2(x1, y1, x2, y2, vy2) * dt;



            Bx1 = (vx1 + Avx1 / 2) * dt;
            Bvx1 = Fx1(x1 + Ax1 / 2, y1 + Ay1 / 2, vx1 + Avx1 / 2, x2 + Ax2 / 2, y2 + Ay2 / 2) * dt;
            By1 = (vy1 + Avy1 / 2) * dt;
            Bvy1 = Fy1(x1 + Ax1 / 2, y1 + Ay1 / 2, vy1 + Avy1 / 2, x2 + Ax2 / 2, y2 + Ay2 / 2) * dt;

            Bx2 = (vx2 + Avx2 / 2) * dt;
            Bvx2 = Fx2(x1 + Ax1 / 2, y1 + Ay1 / 2, x2 + Ax2 / 2, y2 + Ay2 / 2, vx2 + Avx2 / 2) * dt;
            By2 = (vy2 + Avy2 / 2) * dt;
            Bvy2 = Fy2(x1 + Ax1 / 2, y1 + Ay1 / 2, x2 + Ax2 / 2, y2 + Ay2 / 2, vy2 + Avy2 / 2) * dt;



            Cx1 = (vx1 + Bvx1 / 2) * dt;
            Cvx1 = Fx1(x1 + Bx1 / 2, y1 + By1 / 2, vx1 + Bvx1 / 2, x2 + Bx2 / 2, y2 + By2 / 2) * dt;
            Cy1 = (vy1 + Bvy1 / 2) * dt;
            Cvy1 = Fy1(x1 + Bx1 / 2, y1 + By1 / 2, vy1 + Bvy1 / 2, x2 + Bx2 / 2, y2 + By2 / 2) * dt;

            Cx2 = (vx2 + Bvx2 / 2) * dt;
            Cvx2 = Fx2(x1 + Bx1 / 2, y1 + By1 / 2, x2 + Bx2 / 2, y2 + By2 / 2, vx2 + Bvx2 / 2) * dt;
            Cy2 = (vy2 + Bvy2 / 2) * dt;
            Cvy2 = Fy2(x1 + Bx1 / 2, y1 + By1 / 2, x2 + Bx2 / 2, y2 + By2 / 2, vy2 + Bvy2 / 2) * dt;




            Dx1 = (vx1 + Cvx1) * dt;
            Dvx1 = Fx1(x1 + Cx1, y1 + Cy1, vx1 + Cvx1, x2 + Cx2, y2 + Cy2) * dt;
            Dy1 = (vy1 + Cvy1) * dt;
            Dvy1 = Fy1(x1 + Cx1, y1 + Cy1, vy1 + Cvy1, x2 + Cx2, y2 + Cy2) * dt;


            Dx2 = (vx2 + Cvx2) * dt;
            Dvx2 = Fx2(x1 + Cx1, y1 + Cy1, x2 + Cx2, y2 + Cy2, vx2 + Cvx2) * dt;
            Dy2 = (vy2 + Cvy2) * dt;
            Dvy2 = Fy2(x1 + Cx1, y1 + Cy1, x2 + Cx2, y2 + Cy2, vy2 + Cvy2) * dt;




            x1 += (Ax1 + 2 * Bx1 + 2 * Cx1 + Dx1) / 6;
            y1 += (Ay1 + 2 * By1 + 2 * Cy1 + Dy1) / 6;
            vx1 += (Avx1 + 2 * Bvx1 + 2 * Cvx1 + Dvx1) / 6;
            vy1 += (Avy1 + 2 * Bvy1 + 2 * Cvy1 + Dvy1) / 6;

            x2 += (Ax2 + 2 * Bx2 + 2 * Cx2 + Dx2) / 6;
            y2 += (Ay2 + 2 * By2 + 2 * Cy2 + Dy2) / 6;
            vx2 += (Avx2 + 2 * Bvx2 + 2 * Cvx2 + Dvx2) / 6;
            vy2 += (Avy2 + 2 * Bvy2 + 2 * Cvy2 + Dvy2) / 6;

        }


        public double KineticEnergy1(double vx1, double vy1)
        {
            return (vx1 * vx1 + vy1 * vy1) * m1 / 2;
        }

        public double KineticEnergy2(double vx2, double vy2)
        {
            return (vx2 * vx2 + vy2 * vy2) * m2 / 2;

        }

        public double KineticEnergy(double vx1, double vy1, double vx2, double vy2)
        {
            return KineticEnergy1(vx1, vy1) + KineticEnergy2(vx2, vy2);
        }


        public double PotentialEnergy(double x1, double y1, double x2, double y2)
        {
            double S1 = L1(x1, y1) - R1;
            double S2 = L2(x1, y1, x2, y2) - R2;

            return (k1 * S1 * S1 / 2 - m1 * g * y1) + (k2 * S2 * S2 / 2 - m2 * g * y2);
        }

        public double MechanicEnergy(double x1, double y1, double x2, double y2,
            double vx1, double vy1, double vx2, double vy2)
        {
            return PotentialEnergy(x1, y1, x2, y2) + KineticEnergy(vx1, vy1, vx2, vy2);
        }



        public double AccelerationX1(double x1, double y1, double vx1, double x2, double y2)
        {
            return Fx1(x1, y1, vx1, x2, y2);
        }

        public double AccelerationY1(double x1, double y1, double vy1, double x2, double y2)
        {
            return Fy1(x1, y1, vy1, x2, y2);
        }

        public double AccelerationX2(double x1, double y1,  double x2, double y2, double vx2)
        {
            return Fx2(x1, y1, x2, y2, vx2);
        }

        public double AccelerationY2(double x1, double y1, double x2, double y2, double vy2)
        {
            return Fy2(x1, y1, x2, y2, vy2);
        }

        

        public double AngleD1(double x1, double y1)
        {
            return Math.Atan2(x1 , y1) * 180 / Math.PI;
        }

        public double AngleD2(double x1, double y1, double x2, double y2)
        {
            return Math.Atan2((x2 - x1) , (y2 - y1)) * 180 / Math.PI;
        }


        public double RadialDot1(double x1, double y1, double vx1, double vy1)
        {
            return (x1 * vx1 + y1 * vy1) / L1(x1, y1);
        }
        public double AngularDot1(double x1, double y1, double vx1, double vy1)
        {
            return (vx1 * y1 - vy1 * x1) / L1_2(x1, y1);

        }

        public double RadialDot2(double x1, double y1, double vx1, double vy1,
            double x2, double y2, double vx2, double vy2)
        {
            return ((x2 - x1) * (vx2 - vx1) + (y2 - y1) * (vy2 - vy1)) / L2(x1, y1, x2, y2);
        }
        public double AngularDot2(double x1, double y1, double vx1, double vy1,
            double x2, double y2, double vx2, double vy2)
        {
            return ((vx2 - vx1) * (y2 - y1) - (vy2 - vy1) * (x2 - x1)) / L2_2(x1, y1, x1, y2);

        }
        //public double ThetaDotDot(double x, double y, double vx, double vy)
        //{
        //    return -g * x / L2(x, y);
        //----

    }// Class doubleSpring2D

}