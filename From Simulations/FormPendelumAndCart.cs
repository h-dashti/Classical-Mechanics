using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormPendelumAndCart : Form
    {
        //--------------- Variables
        private double xPrior, vxPrior, xNext, vxNext,
            thetaPrior, omegaPrior, thetaNext, omegaNext, tPrior, tNext;

        private PendelumAndCart pendelumAndCart;

        private Size margin = new Size(55, 35);
        private int n;
        private double dt;
        double scaleAnimate = 30;

        private PlotClass plotClass;
        //private FormResults formResult;
        //-------------------------- End Variables
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
                "x   = " + xNext.ToString() + "\r\n" +
                "vx  = " + vxNext.ToString() + "\r\n" +
                "ax  = " + pendelumAndCart.Fx(xNext, vxNext, thetaNext, omegaNext).ToString() + "\r\n" +
                "theta = " + thetaNext.ToString() + "\r\n" +
                "omega = " + omegaNext.ToString() + "\r\n" +
                "alfa  = " + pendelumAndCart.Alfa(xNext, vxNext, thetaNext, omegaNext).ToString() + "\r\n" +
                "t     = " + tNext.ToString() + "\r\n" + "\r\n" +
                "Kinetic energy   = " + "\r\n" +
                pendelumAndCart.KineticEnergy(xNext, vxNext, thetaNext, omegaNext).ToString() + "\r\n" +
                "Potential energy = " + "\r\n" +
                pendelumAndCart.PotentialEnergy(xNext, thetaNext).ToString() + "\r\n" +
                "Mechanic energy  = " + "\r\n" +
                pendelumAndCart.MechanicEnergy(xNext, vxNext, thetaNext, omegaNext).ToString() + "\r\n";


            labelResult.Text = data;

        }
        public FormPendelumAndCart()
        {
            InitializeComponent();
            InitControlsLocation();
            Initialize1();
        }

        private void InitControlsLocation()
        {
            int horizon = 1000;
            pictureBoxCurve.Size = new Size(horizon, 450);
            pictureBoxAnimate.Size = new Size(horizon, 200);

            pictureBoxCurve.Location = new Point(pictureBoxCurve.Location.X,
                pictureBoxAnimate.Location.Y + pictureBoxAnimate.Height + 1);
           
            labelResult.Location = new Point(pictureBoxAnimate.Location.X + pictureBoxAnimate.Width + 2,
                pictureBoxAnimate.Location.Y);
            labelX.Location = new Point(labelX.Location.X,
                pictureBoxCurve.Location.Y + pictureBoxCurve.Size.Height - 20);
            labelY.Location = new Point(labelY.Location.X,
                pictureBoxCurve.Location.Y +5);

            buttonStop.Location = new Point(pictureBoxCurve.Location.X + pictureBoxCurve.Width - buttonStop.Width,
                pictureBoxCurve.Location.Y + pictureBoxCurve.Size.Height + 5);
            buttonPlay.Location = new Point(buttonStop.Location.X - 5 - buttonPlay.Width,
               buttonStop.Location.Y);

            buttonMoreDetail.Location = new Point(pictureBoxCurve.Location.X,
               buttonStop.Location.Y);
            buttonTakeCurvePic.Location = new Point(buttonMoreDetail.Right + 20, buttonMoreDetail.Location.Y);
        }

        private void Initialize1()
        {
            textBoxx.Text = "3";
            textBoxvx.Text = "0";
            textBoxm1.Text = "1";
            textBoxb1.Text = "0";
            textBoxR.Text = "2.5";
            textBoxk.Text = "6";

            textBoxtheta.Text = "30";
            textBoxomega.Text = "0";
            textBoxm2.Text = "1";
            textBoxl.Text = "1.5";
            textBoxb2.Text = "0";

            textBoxg.Text = "9.8";

            timer1.Interval = 10;
            dt = 0.005;
            n = 7;

            ResetData();
            PrintResults();
         
        }// End Initialize1

        private void ResetData()
        {
            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;

            xPrior = double.Parse(textBoxx.Text);
            vxPrior = double.Parse(textBoxvx.Text);

            thetaPrior = double.Parse(textBoxtheta.Text) * Math.PI / 180;
            omegaPrior = double.Parse(textBoxomega.Text);

            pendelumAndCart = new PendelumAndCart();
            pendelumAndCart.m1 = double.Parse(textBoxm1.Text);
            pendelumAndCart.b1 = double.Parse(textBoxb1.Text);
            pendelumAndCart.R = double.Parse(textBoxR.Text);
            pendelumAndCart.k = double.Parse(textBoxk.Text);
            pendelumAndCart.m2 = double.Parse(textBoxm2.Text);
            pendelumAndCart.b2 = double.Parse(textBoxb2.Text);
            pendelumAndCart.l = double.Parse(textBoxl.Text);
            pendelumAndCart.g = double.Parse(textBoxg.Text);

            tPrior = 0.0;
            xNext = xPrior;
            vxNext = vxPrior;
            thetaNext = thetaPrior;
            omegaNext = omegaPrior;
            tNext = tPrior;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, xNext, vxNext, thetaNext, omegaNext, tNext),
                ValueString(comboBoxY.Text, xNext, vxNext, thetaNext, omegaNext, tNext));
            pictureBoxCurve.Invalidate();

        }// End ResetData
        private double ValueString(string st, double x, double vx, double theta, double omega, double t)
        {

            switch (st)
            {
                case "x" :
                    return x;
                case "vx" :
                    return vx;
                case "ax" :
                    return pendelumAndCart.Fx(x, vx, theta, omega);
                case "theta":
                    return theta * 180 / Math.PI;
                case "omega":
                    return omega;
                case "alfa":
                    return pendelumAndCart.Alfa(x, vx, theta, omega);
                case "Potential Energy":
                    return pendelumAndCart.PotentialEnergy(x,theta);
                case "Kinetic Energy":
                    return pendelumAndCart.KineticEnergy(x, vx, theta, omega);
                case "Mechanic Energy":
                    return pendelumAndCart.MechanicEnergy(x, vx, theta, omega);
                //case "Tension":
                //    return chaoticPendelum.Tension(theta, omega);
                
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
                pendelumAndCart.NextVar(dt,
                    xPrior, vxPrior, out xNext, out vxNext,
                    thetaPrior, omegaPrior, out thetaNext, out omegaNext);
                if (i < n)
                {
                    xPrior = xNext;
                    vxPrior = vxNext;
                    thetaPrior = thetaNext;
                    omegaPrior = omegaNext;
                }
            }
            tNext = tPrior + n * dt;

            plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, xNext, vxNext, thetaNext, omegaNext, tNext),
                ValueString(comboBoxY.Text, xNext, vxNext, thetaNext, omegaNext, tNext));
            pictureBoxCurve.Invalidate();

            xPrior = xNext;
            vxPrior = vxNext;
            thetaPrior = thetaNext;
            omegaPrior = omegaNext;
            tPrior = tNext;

            PrintResults();
            pictureBoxAnimate.Invalidate();
        }

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
               ValueString(comboBoxX.Text, xNext, vxNext, thetaNext, omegaNext, tNext),
               ValueString(comboBoxY.Text, xNext, vxNext, thetaNext, omegaNext, tNext));
            pictureBoxCurve.Invalidate();

            xPrior = xNext;
            vxPrior = vxNext;
            thetaPrior = thetaNext;
            omegaPrior = omegaNext;
            tPrior = tNext;
            
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
           
            PrintResults();
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

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
            pictureBoxAnimate.Invalidate();
        }

        private void checkBoxAnimate_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
        }

        private void comboBoxY_TextChanged(object sender, EventArgs e)
        {
            ResetData();
            pictureBoxAnimate.Invalidate();

        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            int lMases = 10;
            // Draw spring
            int peak = 13;
            int l1 = (int)(scaleAnimate * xPrior) - lMases;
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
                
            Rectangle rectCart = new Rectangle(l1, -lMases, 2*lMases, 2*lMases);
            // end Definition spring

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 3, pictureBoxAnimate.Height / 2);
            g.FillRectangle(new SolidBrush(Color.Black),-5, -20, 5, 30); // plot the wall
            g.FillRectangle(new SolidBrush(Color.Black), -5, 10, 300, 2); // plot the wall


            Color color = Color.Green;
            if (xPrior < pendelumAndCart.R)
                color = Color.Red;

            g.DrawLines(new Pen(color), pts);
            g.FillRectangle(new SolidBrush(Color.DarkBlue), rectCart);
            //
            // end plot Cart



            // Plot pendelum
            int l2 = (int)(scaleAnimate * pendelumAndCart.l) - lMases;
            Rectangle rectPendelum = new Rectangle(l2, -lMases, 2*lMases, 2*lMases);
            g.TranslateTransform(l1 + rectCart.Width / 2, 0);

            g.RotateTransform((float)(90 - thetaPrior * 180 / Math.PI));
            g.DrawLine(new Pen(Color.DarkGreen,3), 0, 0, l2, 0);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectPendelum);
            // end Plot Pendelum

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

        private void FormPendelumAndCart_FormClosing(object sender, FormClosingEventArgs e)
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

    //*******************************************************************
    //*******************************************************************
    public class PendelumAndCart
    {
        public double b1, m1, k, R, b2, m2, l, g;
        public PendelumAndCart()
        {
        }
        public PendelumAndCart(double m1, double b1, double k , double R, double m2, double b2, double l, double g)
        {
            this.b1 = b1;
            this.m1 = m1;
            this.k = k;
            this.R = R;

            this.m2 = m2;
            this.b2 = b2;
            this.l = l;
            this.g = g;
        }
        public double Fx(double x, double vx, double theta, double omega)
        {
            return (m2 * l * omega * omega * Math.Sin(theta) +
                 m2 * g * Math.Sin(theta) * Math.Cos(theta) - k * (x-R) - b1 * vx + b2 / l * omega * Math.Cos(theta))
                / (m1 + m2 * Math.Sin(theta) * Math.Sin(theta));
        }

        public double Alfa(double x, double vx, double theta, double omega)
        {
            return (-m2 * l * omega * omega * Math.Sin(theta) * Math.Cos(theta)
                - (m2 + m1) * g * Math.Sin(theta) +
                k * (x-R) * Math.Cos(theta) + b1 * vx * Math.Cos(theta) - (1 + m1 / m2) * b2 / l*omega)
                / (l * (m1 + m2 * Math.Sin(theta) * Math.Sin(theta)));
        }
        public void NextVar(double dt, 
            double xPrior,double vxPrior, out double xNext, out double  vxNext,
            double thetaPrior, double omegaPrior, out double thetaNext, out double omegaNext)
        {
            double
                Ax, Bx, Cx, Dx, Avx, Bvx, Cvx, Dvx,
                Atheta, Btheta, Ctheta, Dtheta,Aomega, Bomega, Comega, Domega;

            Ax = vxPrior * dt;
            Avx = Fx(xPrior, vxPrior, thetaPrior, omegaPrior) * dt;
            Atheta = omegaPrior * dt;
            Aomega = Alfa(xPrior, vxPrior, thetaPrior, omegaPrior) * dt;

            Bx = (vxPrior + Avx / 2) * dt;
            Bvx = Fx(xPrior + Ax / 2, vxPrior + Avx / 2, thetaPrior + Atheta / 2, omegaPrior + Aomega / 2) * dt;
            Btheta = (omegaPrior + Aomega / 2) * dt;
            Bomega = Alfa(xPrior + Ax / 2, vxPrior + Avx / 2, thetaPrior + Atheta / 2, omegaPrior + Aomega / 2) * dt;

            Cx = (vxPrior + Bvx / 2) * dt;
            Cvx = Fx(xPrior + Bx / 2, vxPrior + Bvx / 2, thetaPrior + Btheta / 2, omegaPrior + Bomega / 2) * dt;
            Ctheta = (omegaPrior + Bomega / 2) * dt;
            Comega = Alfa(xPrior + Bx / 2, vxPrior + Bvx / 2, thetaPrior + Btheta / 2, omegaPrior + Bomega / 2) * dt;

            Dx = (vxPrior + Cvx) * dt;
            Dvx = Fx(xPrior + Cx, vxPrior + Cvx, thetaPrior + Ctheta, omegaPrior + Comega) * dt;
            Dtheta = (omegaPrior + Comega) * dt;
            Domega = Alfa(xPrior + Cx, vxPrior + Cvx, thetaPrior + Ctheta, omegaPrior + Comega) * dt;


            xNext = xPrior + (Ax + 2 * Bx + 2 * Cx + Dx) / 6;
            vxNext = vxPrior + (Avx + 2 * Bvx + 2 * Cvx + Dvx) / 6;

            thetaNext = thetaPrior + (Atheta + 2 * Btheta + 2 * Ctheta + Dtheta) / 6;
            omegaNext = omegaPrior + (Aomega + 2 * Bomega + 2 * Comega + Domega) / 6;

        }
        public double KineticEnergy(double x, double vx, double theta, double omega)
        {
            return m1 / 2 * vx * vx +
                m2 / 2 *( (vx + l * omega * Math.Cos(theta)) * (vx + l * omega * Math.Cos(theta)) +
                (l * omega * Math.Sin(theta)) * (l * omega * Math.Sin(theta)));
        }
        public double PotentialEnergy(double x, double theta)
        {
            return k / 2 * (x - R) * (x - R) - m2 * g * l * Math.Cos(theta);
        }
        public double MechanicEnergy(double x, double vx, double theta, double omega)
        {
            return KineticEnergy(x, vx, theta, omega) + PotentialEnergy(x, theta);
        }
    }
}