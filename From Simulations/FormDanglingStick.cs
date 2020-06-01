using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormDanglingStick : Form
    {
        //--------------- Variables
        private double r, vr, theta, vtheta, phi, vphi, t;

        private DanglingStick danglingStick;

        private Size margin = new Size(55, 35);
        private int n;

        private double dt;
        double scaleAnimate = 30;

        private PlotClass plotClass;
  
        //-------------------------- End Variables


       

        private void PrintResults()
        {
            string data = 
            "r   = " + r.ToString() + "\r\n" +
            "vr  = " + vr.ToString() + "\r\n" +
            "ar  = " + danglingStick.Fr(r, theta, vtheta, phi, vphi).ToString() + "\r\n" +
            "theta = " + theta.ToString() + "\r\n" +
            "vtheta = " + vtheta.ToString() + "\r\n" +
            "atehta  = " + danglingStick.ThetaDotDot(r, vr, theta, vtheta, phi, vphi).ToString() + "\r\n" +
            "t     = " + t.ToString() + "\r\n" + "\r\n" +

            "vx1   = " + danglingStick.VX1(r, vr, theta, vtheta).ToString() + "\r\n" +
            "vy1   = " + danglingStick.VY1(r, vr, theta, vtheta).ToString() + "\r\n" +
            "vx2   = " + danglingStick.VX2(r, vr, theta, vtheta, phi, vphi).ToString() + "\r\n" +
            "vy2   = " + danglingStick.VY2(r, vr, theta, vtheta, phi, vphi).ToString() + "\r\n"  + "\r\n" +


            "Kinetic energy   = " + "\r\n" +
            danglingStick.KineticEnergy(r, vr, theta, vtheta, phi, vphi).ToString() + "\r\n" +
            "Potential energy = " + "\r\n" +
            danglingStick.PotentialEnergy(r, theta, phi).ToString() + "\r\n" +
            "Mechanic energy  = " + "\r\n" +
            danglingStick.MechanicEnergy(r, vr, theta, vtheta, phi, vphi).ToString() + "\r\n";



            labelResult.Text = data;

        }
        public FormDanglingStick()
        {
            InitializeComponent();
            InitControlsLocation();
            Initialize1();
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
            textBoxr.Text = "3";
            textBoxvr.Text = "0";
            textBoxtheta.Text = "45";
            textBoxvtheta.Text = "0";
            textBoxm1.Text = "0.5";
            textBoxR1.Text = "2";
            textBoxk.Text = "20";

            textBoxphi.Text = "0";
            textBoxvphi.Text = "0";
            textBoxm2.Text = "0.5";
            textBoxl2.Text = "2";
            
            textBoxg.Text = "9.8";

            timer1.Interval = 10;
            dt = 0.005;
            n = 3;

            ResetData();
            PrintResults();
        }// End Initialize1

        private void ResetData()
        {
            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;

            r = double.Parse(textBoxr.Text);
            vr = double.Parse(textBoxvr.Text);
            theta = double.Parse(textBoxtheta.Text) * Math.PI / 180;
            vtheta = double.Parse(textBoxvtheta.Text);

            phi = double.Parse(textBoxphi.Text) * Math.PI / 180;
            vphi = double.Parse(textBoxvphi.Text);

            t = 0.0;

            danglingStick = new DanglingStick();
            danglingStick.m1 = double.Parse(textBoxm1.Text);
            danglingStick.R = double.Parse(textBoxR1.Text);
            danglingStick.k = double.Parse(textBoxk.Text);
            danglingStick.m2 = double.Parse(textBoxm2.Text);
            danglingStick.l = double.Parse(textBoxl2.Text);
            danglingStick.g = double.Parse(textBoxg.Text);


            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
               pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, r, vr, theta, vtheta, phi, vphi, t),
                ValueString(comboBoxY.Text, r, vr, theta, vtheta, phi, vphi, t));
            pictureBoxCurve.Invalidate();
           

        }// End ResetData
        private double ValueString(string st, double r, double vr, double theta, double vtheta,
            double phi, double vphi, double t)
        {

            switch (st)
            {
                case "r":
                    return r;
                case "vr":
                    return vr;
                case "vrDot":
                    return danglingStick.Fr(r, theta, vtheta, phi, vphi);
                case "theta":
                    return theta * 180 / Math.PI;
                case "vtheta":
                    return vtheta;
                case "vthetaDot":
                    return danglingStick.ThetaDotDot(r, vr, theta, vtheta, phi, vphi);

                case "phi":
                    return phi * 180 / Math.PI;
                case "vphi":
                    return vphi;
                case "vphiDot":
                    return danglingStick.PhiDotDot(r, theta, phi);

                case "v1x" :
                    return danglingStick.VX1(r, vr, theta, vtheta);
                case "v1y" :
                    return danglingStick.VY1(r, vr, theta, vtheta);
                case "v2x":
                    return danglingStick.VX2(r, vr, theta, vtheta, phi, vphi);
                case "v2y":
                    return danglingStick.VY2(r, vr, theta, vtheta, phi, vphi);
                case "v1_2" :
                    return danglingStick.V1_2(r, vr, theta, vtheta);
                case "v2_2" :
                    return danglingStick.V2_2(r, vr, theta, vtheta, phi, vphi);

                case "Potential Energy":
                    return danglingStick.PotentialEnergy(r, theta, phi);
                case "Kinetic Energy":
                    return danglingStick.KineticEnergy(r, vr, theta, vtheta, phi, vphi);
                case "Mechanic Energy":
                    return danglingStick.MechanicEnergy(r, vr, theta, vtheta, phi, vphi);
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
                danglingStick.NextVar(dt, ref r, ref vr, ref theta, ref vtheta, ref phi, ref vphi);
            }
            t = t + n * dt;

            plotClass.AddNewPoint(
               ValueString(comboBoxX.Text, r, vr, theta, vtheta, phi, vphi, t),
               ValueString(comboBoxY.Text, r, vr, theta, vtheta, phi, vphi, t));
            pictureBoxCurve.Invalidate();

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
                ValueString(comboBoxX.Text, r, vr, theta, vtheta, phi, vphi, t),
                ValueString(comboBoxY.Text, r, vr, theta, vtheta, phi, vphi, t));

            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            plotClass.RepeatDrawingPointsMap();
            pictureBoxCurve.Invalidate();
            pictureBoxAnimate.Invalidate();
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
        }

       

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            int lMases = 10;
            // Draw spring
            int peak = 13;
            int l1 = (int)(scaleAnimate * r) - lMases;
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

            Rectangle rect1 = new Rectangle(l1, -lMases, 2*lMases, 2*lMases);
            // end Definition spring

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 2, pictureBoxAnimate.Height / 2);
            g.FillRectangle(new SolidBrush(Color.Black), -2, -2, 4, 4); // plot the point center

            // Draw x y
            g.DrawLine(new Pen(Color.Blue), 0, 0, 20, 0);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("x", font, new SolidBrush(Color.Blue), 20, -7);
            g.DrawLine(new Pen(Color.Blue), 0, 0, 0, 20);
            g.DrawString("y", font, new SolidBrush(Color.Blue), -4, 18);
            //-----


            Color color = Color.Green;
            if (r < danglingStick.R)
                color = Color.Red;

            GraphicsState gs = g.Save();

            g.RotateTransform(90 - (float)(theta * 180 / Math.PI));

            g.DrawLines(new Pen(color), pts);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rect1);
            g.Restore(gs);
            //
            // End plot spring



            // Plot pendelum
            int l2 = (int)(scaleAnimate * danglingStick.l) - lMases;
            Rectangle rectPendelum = new Rectangle(l2, -lMases, 2*lMases, 2*lMases);

            int transaltex = (int)((scaleAnimate * r ) * Math.Sin(theta));
            int transaltey = (int)((scaleAnimate * r ) * Math.Cos(theta));
            g.TranslateTransform(transaltex, transaltey);

            g.RotateTransform((float)(90 - phi * 180 / Math.PI));
            g.DrawLine(new Pen(Color.DarkGreen,3), 0, 0, l2, 0);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectPendelum);

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

        private void FormDanglingStick_FormClosing(object sender, FormClosingEventArgs e)
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
    //*********************************************************
    //*********************************************************

    public class DanglingStick
    {
        public double m1, k, R, m2, l, g;
        public DanglingStick()
        {
        }
        public DanglingStick(double m1, double k, double R, double m2, double l, double g)
        {
            this.m1 = m1;
            this.k = k;
            this.R = R;
            this.m2 = m2;
            this.l = l;
            this.g = g;
        }
        public double Fr(double r, double theta, double vtheta, double phi, double vphi)
        {
            return (m1 * m1*(r * vtheta * vtheta + g * Math.Cos(theta)) +
                m2 * k*(R - r) * Math.Sin(theta - phi) * Math.Sin(theta - phi) +
                m1 * (k * (R - r) + m2 * (r * vtheta * vtheta + g * Math.Cos(theta) + l * vphi * vphi * Math.Cos(theta - phi)))) /
                (m1 * (m1 + m2));
                /*(k * (2 * m1 + m2) * (R - r) + 2 * m1 * (m1 + m2) * r * vtheta * vtheta +
                2 * g * m1 * (m1 + m2) * Math.Cos(theta) +
                2 * l * m1 * m2 * vphi * vphi * Math.Cos(theta - phi)
                - k * m2 * (R - r) * Math.Cos(2 * theta - 2 * phi)) /
                (2 * m1 * (m1 + m2)); */
        }

        public double ThetaDotDot(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            return (k * m2 * (R - r) * Math.Sin(2 * theta - 2 * phi)
                - 2 * g * m1 * (m1 + m2) * Math.Sin(theta) - 4 * m1 * (m1 + m2) * vr * vtheta 
                - 2 * l * m1 * m2 * vphi * vphi * Math.Sin(theta - phi)) /
                (2 * m1 * (m1 + m2) * r);

                /*(k * m2 * (R - r) * Math.Sin(2 * theta - 2 * phi) 
                - 2 * g * m1 * (m1 + m2) * Math.Sin(theta) - 4 * m1 * (m1 + m2) * vr * vtheta +
                2 * l * m1 * m2 * vphi * vphi * Math.Sin(theta - phi)) /
                (2 * m1 * (m1 + m2) * r); */
        }
        public double PhiDotDot(double r, double theta, double phi)
        {
            return k * (r - R) * Math.Sin(theta - phi) / (l * m1);
        }

        public void NextVar(double dt, ref double r, ref double vr, ref double theta, ref double vtheta,
             ref double phi, ref double vphi)
        {
            double Ar, Br, Cr, Dr, Avr, Bvr, Cvr, Dvr,
            Atheta, Btheta, Ctheta, Dtheta, Avtheta, Bvtheta, Cvtheta, Dvtheta,
            Aphi, Bphi, Cphi, Dphi, Avphi, Bvphi, Cvphi, Dvphi;



            Ar = vr * dt;
            Avr = Fr(r, theta, vtheta, phi, vphi) * dt;
            Atheta = vtheta * dt;
            Avtheta = ThetaDotDot(r, vr, theta, vtheta, phi, vphi) * dt;
            Aphi = vphi * dt;
            Avphi = PhiDotDot(r, theta, phi) * dt;



            Br = (vr + Avr / 2) * dt;
            Bvr = Fr(r + Ar / 2, theta + Atheta / 2, vtheta + Avtheta / 2, phi + Aphi / 2, vphi + Avphi / 2) * dt;

            Btheta = (vtheta + Avtheta / 2) * dt;
            Bvtheta = ThetaDotDot(r + Ar / 2, vr + Avr / 2, theta + Atheta / 2, vtheta + Avtheta / 2,
                phi + Aphi / 2, vphi + Avphi / 2) * dt;

            Bphi = (vphi + Avphi / 2) * dt;
            Bvphi = PhiDotDot(r + Ar / 2, theta + Atheta / 2, phi + Aphi / 2) * dt;




            Cr = (vr + Bvr / 2) * dt;
            Cvr = Fr(r + Br / 2, theta + Btheta / 2, vtheta + Bvtheta / 2, phi + Bphi / 2, vphi + Bvphi / 2) * dt;

            Ctheta = (vtheta + Bvtheta / 2) * dt;
            Cvtheta = ThetaDotDot(r + Br / 2, vr + Bvr / 2, theta + Btheta / 2, vtheta + Bvtheta / 2,
                phi + Bphi / 2, vphi + Bvphi / 2) * dt;

            Cphi = (vphi + Bvphi / 2) * dt;
            Cvphi = PhiDotDot(r + Br / 2, theta + Btheta / 2, phi + Bphi / 2) * dt;




            Dr = (vr + Cvr) * dt;
            Dvr = Fr(r + Cr, theta + Ctheta, vtheta + Cvtheta, phi + Cphi, vphi + Cvphi) * dt;

            Dtheta = (vtheta + Cvtheta) * dt;
            Dvtheta = ThetaDotDot(r + Cr, vr + Cvr, theta + Ctheta, vtheta + Cvtheta, phi + Cphi, vphi + Cvphi) * dt;

            Dphi = (vphi + Cvphi) * dt;
            Dvphi = PhiDotDot(r + Cr, theta + Ctheta, phi + Cphi) * dt;




            r +=  (Ar + 2 * Br + 2 * Cr +  Dr) / 6;
            theta += (Atheta + 2 * Btheta + 2 * Ctheta + Dtheta) / 6;
            phi +=  (Aphi + 2 * Bphi + 2 * Cphi + Dphi) / 6;

            vr +=  (Avr + 2 * Bvr + 2 * Cvr +  Dvr) / 6;
            vtheta +=  (Avtheta + 2 * Bvtheta + 2 * Cvtheta + Dvtheta) / 6;
            vphi +=  (Avphi + 2 * Bvphi + 2 * Cvphi + Dvphi) / 6;


        }

        public double VX1(double r, double vr, double theta, double vtheta)
        {
            return r * vtheta * Math.Cos(theta) + vr * Math.Sin(theta);
        }
        public double VY1(double r, double vr, double theta, double vtheta)
        {
            return -vr * Math.Cos(theta) + r * vtheta * Math.Sin(theta);
        }

        public double VX2(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            return r * vtheta * Math.Cos(theta) + vr * Math.Sin(theta) + l * vphi * Math.Cos(phi);
        }
        public double VY2(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            return -vr * Math.Cos(theta) + r * vtheta * Math.Sin(theta) + l * vphi * Math.Sin(phi);
        }

        public double V1_2(double r, double vr, double theta, double vtheta)
        {
            double vx = VX1(r, vr, theta, vtheta);
            double vy = VY1(r, vr, theta, vtheta);

            return vx * vx + vy * vy;
        }

        public double V2_2(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            double vx = VX2(r, vr, theta, vtheta, phi, vphi);
            double vy = VY2(r, vr, theta, vtheta, phi, vphi);

            return vx * vx + vy * vy;
        }

        public double KineticEnergy(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            return m1 / 2 * V1_2(r, vr, theta, vtheta) + m2 / 2 * V2_2(r, vr, theta, vtheta, phi, vphi);
        }
        public double PotentialEnergy(double r, double theta, double phi)
        {
            return k / 2 * (r - R) * (r - R)
                - m1 * g * r * Math.Cos(theta) - m2 * g * (r * Math.Cos(theta) + l * Math.Cos(phi));
        }

        public double MechanicEnergy(double r, double vr, double theta, double vtheta, double phi, double vphi)
        {
            return KineticEnergy(r, vr, theta, vtheta, phi, vphi) + PotentialEnergy(r, theta, phi);
        }
    }
}