using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;


namespace MechanicalSimulations
{

    public partial class Form2DSingleSpring : Form
    {
        //--------------- Variables
        private double xPrior, vxPrior, xNext, vxNext, tPrior, tNext,
            yPrior, vyPrior, yNext, vyNext;
        private SingleSpring2D singleSpring2D;

        private Size margin = new Size(55, 35);
        private int n = 5;

        private double h = 0.005;
        private double scaleAnimate = 30;

        private PlotClass plotClass;

     //   private FormResults formResult;
        //_________________________________________________

        //private void InitializeFormResult()
        //{
        //    formResult = new FormResults(new Point(250, this.Size.Height));
            
        //    PrintResults();
        //    formResult.Show();
        //    formResult.Location = new Point(this.Location.X + this.Width, this.Location.Y);
           
        //}
       
        private void PrintResults()
        {
            string data =
                "x  = " + xNext.ToString() + "\r\n" +
                "y  = " + yNext.ToString() + "\r\n" +
                "vx = " + vxNext.ToString() + "\r\n" +
                "vy = " + vyNext.ToString() + "\r\n" +
                "ax = " + singleSpring2D.AccelerationX(xNext, yNext, vxNext).ToString() + "\r\n" +
                "ay = " + singleSpring2D.AccelerationY(xNext, yNext, vxNext).ToString() + "\r\n" +
                "t  = " + tNext.ToString() + "\r\n" + "\r\n" +
                "Kinetic energy   = " + "\r\n" +
                singleSpring2D.KineticEnergy(vxNext, vyNext).ToString() + "\r\n" +
                "Potential energy = " + "\r\n" +
                singleSpring2D.PotentialEnergy(xNext, yNext).ToString() + "\r\n" +
                "Mechanic energy  = " + "\r\n" +
                singleSpring2D.MechanicEnergy(xNext, vxNext, yNext, vyNext).ToString() + "\r\n";


            labelResult.Text = data;
     
        }

        //
        //
        public Form2DSingleSpring()
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
            pictureBoxAnimate.Location = new Point( pictureBoxCurve.Location.X + pictureBoxCurve.Width+1,
                pictureBoxCurve.Location.Y);
            labelResult.Location = new Point(pictureBoxAnimate.Location.X + pictureBoxAnimate.Width + 2,
                pictureBoxCurve.Location.Y);
            labelX.Location = new Point(labelX.Location.X,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Size.Height - 20);

            buttonStop.Location = new Point(pictureBoxAnimate.Location.X - buttonStop.Width,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Size.Height + 10);
            buttonPlay.Location = new Point( buttonStop.Location.X-5- buttonPlay.Width,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Height + 10);
            

            buttonMoreDetail.Location = new Point(pictureBoxCurve.Location.X,
                pictureBoxCurve.Location.Y + pictureBoxCurve.Height + 10);
            buttonTakeCurvePic.Location = new Point(buttonMoreDetail.Right+20, buttonMoreDetail.Location.Y);
        }

        private void Initialize1()
        {
            textBoxx.Text = "2";
            textBoxy.Text = "3";
            textBoxvx.Text = "4";
            textBoxvy.Text = "-3";
            textBoxk.Text = "7";
            textBoxm.Text = "1";
            textBoxR.Text = "2.5";
            textBoxb.Text = "0";
            textBoxg.Text = "9.8";

            timer1.Interval = 10;
            h = 0.005;
            n = 5;

            ResetData();
            PrintResults();

        }// End Initialize1

        private void ResetData()
        {
            singleSpring2D = new SingleSpring2D();
            singleSpring2D.k = double.Parse(textBoxk.Text);
            singleSpring2D.m = double.Parse(textBoxm.Text);
            singleSpring2D.R = double.Parse(textBoxR.Text);
            singleSpring2D.b = double.Parse(textBoxb.Text);
            singleSpring2D.g = double.Parse(textBoxg.Text);

            xPrior = double.Parse(textBoxx.Text);
            yPrior = double.Parse(textBoxy.Text);
            vxPrior = double.Parse(textBoxvx.Text); 
            vyPrior = double.Parse(textBoxvy.Text);
            tPrior = 0.0;

            xNext = xPrior;
            yNext = yPrior;
            vxNext = vxPrior;
            vyNext = vyPrior;
            tNext = tPrior;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);
            plotClass.AddFirstPoint(ValueString(comboBoxX.Text, xNext, vxNext, yNext, vyNext, tNext),
                                    ValueString(comboBoxY.Text, xNext, vxNext, yNext, vyNext, tNext));

            pictureBoxCurve.Invalidate();
            PrintResults();

        }// End ResetData

        private double ValueString(string st, double x, double vx, double y, double vy, double t)
        {
            switch (st)
            {
                case "r" :
                    return singleSpring2D.L(x, y);
                case "theta" :
                    return singleSpring2D.AngleD(x, y);
                case "x":
                    return x;
                case "vx":
                    return vx;
                case "y":
                    return y;
                case "vy":
                    return vy;
                case "Kinetic Energy":
                    return singleSpring2D.KineticEnergy(vx, vy);
                case "Potential Energy":
                    return singleSpring2D.PotentialEnergy(x, y);
                case "Mechanic Energy":
                    return singleSpring2D.MechanicEnergy(x, vx, y, vy);
                case "ax":
                    return singleSpring2D.AccelerationX(x, y, vx);
                case "ay":
                    return singleSpring2D.AccelerationY(x, y, vy);
                case "RadialDot" :
                    return singleSpring2D.RadialDot(x, y, vx, vy);
                case "AngularDot" :
                    return singleSpring2D.AngularDot(x, y, vx, vy);
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
                singleSpring2D.NextVar(h,   xPrior, vxPrior, out xNext, out vxNext,
                                            yPrior, vyPrior, out yNext, out vyNext);

                if (i < n)
                {
                    xPrior = xNext;
                    yPrior = yNext;
                    vxPrior = vxNext;
                    vyPrior = vyNext;
                }
            }
            tNext = n * h + tPrior;

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, xNext, vxNext, yNext, vyNext, tNext),
                                  ValueString(comboBoxY.Text, xNext, vxNext, yNext, vyNext, tNext));
            pictureBoxCurve.Invalidate();

            xPrior = xNext;
            yPrior = yNext;
            vxPrior = vxNext;           
            vyPrior = vyNext;
            tPrior = tNext;

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
        }

        private void buttonResetData_Click(object sender, EventArgs e)
        {
            ResetData();
            pictureBoxAnimate.Invalidate();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();

            xPrior = xNext;
            yPrior = yNext;
            vxPrior = vxNext;
            vyPrior = vyNext;
            tPrior = tNext;

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, xNext, vxNext, yNext, vyNext, tNext),
                                  ValueString(comboBoxY.Text, xNext, vxNext, yNext, vyNext, tNext));

            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
        }

        private void comboBoxY_TextChanged(object sender, EventArgs e)
        {
            ResetData();
           
            pictureBoxAnimate.Invalidate();

            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;
        }

        private void checkBoxAnimate_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
            pictureBoxCurve.Invalidate();
        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            plotClass.RepeatDrawingPointsMap();
            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
        }

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
        }

        private void buttonMoreDetail_Click(object sender, EventArgs e)
        {
            FormMoreDetail formMoreDetail = new FormMoreDetail(plotClass, scaleAnimate, h, timer1.Interval / 1000.0, n);

            DialogResult dialog = formMoreDetail.ShowDialog();

            if (dialog == DialogResult.OK)
            {

                scaleAnimate = formMoreDetail.scaleAnimate;
                this.n = formMoreDetail.n;
                this.h = formMoreDetail.h;
                timer1.Interval = (int)(formMoreDetail.timerInterval * 1000);
            }
            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            if (!checkBoxAnimate.Checked)
                return;

            int lMases = 15;
            double L = singleSpring2D.L(xPrior, yPrior);
            Color color = Color.Green;
            if (L < singleSpring2D.R)
                color = Color.Red;

            // Draw spring
            int peak = 11;
            int l = (int)(scaleAnimate * L) - lMases;
            Point[] pts = new Point[peak + 4];

            int temp = -8;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (l - 10) / (2 * peak), 0 + temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(l - 5, 0);
            pts[pts.Length - 1] = new Point(l, 0);
            // end define spring

            Rectangle rectOfMass = new Rectangle(l, 0 - lMases, 2*lMases, 2*lMases);

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 2, 100);
            g.FillRectangle(new SolidBrush(Color.Black), -2, -4, 4, 4);

            // Draw x y
            g.DrawLine(new Pen(Color.Blue), 0, 0, 40, 0);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("x", font, new SolidBrush(Color.Blue), 40, -7);
            g.DrawLine(new Pen(Color.Blue), 0, 0, 0, 40);
            g.DrawString("y", font, new SolidBrush(Color.Blue), -4, 38);
            //-----


            g.RotateTransform(90 - (float)singleSpring2D.AngleD(xPrior, yPrior));

            g.DrawLines(new Pen(color), pts);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectOfMass);
            
            // End painanimate
        }

        private void pictureBoxCurve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxCurve.Height);
            g.ScaleTransform(1, -1);

            g.DrawImage(plotClass.map, 0, 0);
            Rectangle rectPtHead = new Rectangle(plotClass.ptHead - new Size(3, 3), new Size(6, 6));
            g.DrawRectangle(new Pen(Color.Black), rectPtHead);

        }// End paint Curve

        private void Form2DSingleSpring_FormClosing(object sender, FormClosingEventArgs e)
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

    // *************************************************
    // *************************************************
    public class SingleSpring2D
    {
        // k = spring constant, b = damping constant, R = rest lenght of spring, m = mass of Block
        public double k, R, m, b, g;
        public SingleSpring2D()
        {
        }
        public SingleSpring2D(double k, double R, double m, double b, double g)
        {
            this.k = k;            
            this.R = R;
            this.m = m;
            this.b = b;
            this.g = g;
        }
        private double Fx(double x, double y, double vx)
        {
            double S = L(x, y) - R;
            double sinTeta = x / L(x, y);

            return -S * sinTeta * k / m - vx * b / m;
        }
        private double Fy(double x, double y, double vy)
        {
            double S = L(x, y) - R;
            double cosTeta = y / L(x, y);

            return g - S * cosTeta * k / m - vy * b / m;
            
        }
        public void NextVar(double h, double xPrior, double vxPrior, out double xNext, out double vxNext,
            double yPrior, double vyPrior, out double yNext, out double vyNext)
        {
            // h = deltat
            double Ax, Bx, Cx, Dx, Avx, Bvx, Cvx, Dvx; // Runge Kutta method 
            double Ay, By, Cy, Dy, Avy, Bvy, Cvy, Dvy; // Runge Kutta method
            Ax = vxPrior;
            Avx = Fx(xPrior, yPrior, vxPrior);
            Ay = vyPrior;
            Avy = Fy(xPrior, yPrior, vyPrior);

            Bx = vxPrior + Avx * h / 2;
            Bvx = Fx(xPrior + Ax * h / 2, yPrior + Ay * h / 2, vxPrior + Avx * h / 2);
            By = vyPrior + Avy * h / 2;
            Bvy = Fy(xPrior + Ax * h / 2, yPrior + Ay * h / 2, vyPrior + Avy * h / 2);

            Cx = vxPrior + Bvx * h / 2;
            Cvx = Fx(xPrior + Bx * h / 2, yPrior + By * h / 2, vxPrior + Bvx * h / 2);
            Cy = vyPrior + Bvy * h / 2;
            Cvy = Fy(xPrior + Bx * h / 2, yPrior + By * h / 2, vyPrior + Bvy * h / 2);

            Dx = vxPrior + Cvx * h;
            Dvx = Fx(xPrior + Cx * h, yPrior + Cy * h, vxPrior + Cvx * h);
            Dy = vyPrior + Cvy * h;
            Dvy = Fy(xPrior + Cx * h, yPrior + Cy * h, vyPrior + Cvy * h);

            xNext = xPrior + (Ax + 2 * Bx + 2 * Cx + Dx) * h / 6;
            yNext = yPrior + (Ay + 2 * By + 2 * Cy + Dy) * h / 6;
            vxNext = vxPrior + (Avx + 2 * Bvx + 2 * Cvx + Dvx) * h / 6;
            vyNext = vyPrior + (Avy + 2 * Bvy + 2 * Cvy + Dvy) * h / 6;

        }
        public double KineticEnergy(double vx, double vy)
        {
            return (vx * vx + vy * vy) * m / 2;
        }
        public double KineticEnergyX(double vx)
        {
            return vx * vx * m / 2;

        }
        public double KineticEnergyY(double vy)
        {
            return vy * vy * m / 2;

        }

        public double PotentialEnergy(double x, double y)
        {
            double S = L(x, y) - R;
            return S * S * k / 2 - y * m * g;
        }

        public double MechanicEnergy(double x, double vx, double y, double vy)
        {
            return PotentialEnergy(x, y) + KineticEnergy(vx, vy);
        }
        
        public double AccelerationX(double x, double y, double vx)
        {
            return Fx(x, y, vx);
        }

        public double AccelerationY(double x, double y, double vy)
        {
            return Fy(x, y, vy);
        }

        public double L(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        public double L2(double x, double y)
        {
            return (x * x + y * y);
        }

        public double AngleD(double x, double y)
        {
            return Math.Atan2(x , y) * 180/Math.PI;
        }
        public double RadialDot(double x, double y, double vx, double vy)
        {
            return (x * vx + y * vy) / L(x, y);
        }
        public double AngularDot(double x, double y, double vx, double vy)
        {
            return (vx * y - vy * x) / L2(x, y);

        }
        //public double ThetaDotDot(double x, double y, double vx, double vy)
        //{
        //    return -g * x / L2(x, y);
        //}
        
    }// Class SingleSpring2D

}