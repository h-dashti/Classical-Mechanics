using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormChaoticPendelum : Form
    {
        //--------------- Variables
        private double thetaPrior, omegaPrior, thetaNext, omegaNext, tPrior, tNext;

        private ChaoticPendelum chaoticPendelum;
        //private ArrayList X, V, ElapsedTime;

        private Size margin = new Size(55, 35);
        private int n;

        private double dt;
        double scaleAnimate = 30;

        private PlotClass plotClass;
        //-------------------------- End Variables

        private void PrintResult()
        {
            labelResult.Text =
                "theta = " + Convert.ToString(thetaNext * 180 / Math.PI) + "\r\n" +
                "omega = " + thetaNext.ToString() + "\r\n" +
                "alfa = " + chaoticPendelum.OmegaDot(thetaNext, omegaNext, tNext).ToString() + "\r\n\r\n" +

                "Tension =\r\n" + chaoticPendelum.Tension(thetaNext, omegaNext).ToString() + "\r\n" +
                "Driving Force =\r\n" + chaoticPendelum.DrivingForce(tNext).ToString() + "\r\n\r\n" +

                "Kinetic E =\r\n" + chaoticPendelum.KineticEnergy(omegaNext).ToString() + "\r\n" +
                "Potential E =\r\n" + chaoticPendelum.PotentialEnergy(thetaNext).ToString() + "\r\n" +
                "Mechanical E =\r\n" + chaoticPendelum.MechanicEnergy(thetaNext, omegaNext).ToString() + "\r\n\r\n" +
                "t = " + tNext.ToString();
        }

        public FormChaoticPendelum()
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
            textBoxtheta.Text = "30";
            textBoxomega.Text = "0";
            textBoxm.Text = "1";
            textBoxl.Text = "2.5";
            textBoxg.Text = "9.8";
            textBoxb.Text = "0";

            textBoxk.Text = "2";
            textBoxA.Text = "10";
            textBoxPhase.Text = "180";

            timer1.Interval = 10;
            dt = 0.005;
            n = 5;

            ResetData();
            PrintResult();
            
        }// End Initialize1

        private void ResetData()
        {
            thetaPrior = double.Parse(textBoxtheta.Text) * Math.PI / 180;
            omegaPrior = double.Parse(textBoxomega.Text);
            
            chaoticPendelum = new ChaoticPendelum();
            chaoticPendelum.m = double.Parse(textBoxm.Text);
            chaoticPendelum.l = double.Parse(textBoxl.Text);
            chaoticPendelum.b = double.Parse(textBoxb.Text);
            chaoticPendelum.g = double.Parse(textBoxg.Text);

            chaoticPendelum.k = double.Parse(textBoxk.Text);
            chaoticPendelum.A = double.Parse(textBoxA.Text);
            chaoticPendelum.phase = double.Parse(textBoxPhase.Text) * Math.PI / 180;

            tPrior = 0.0;

            thetaNext = thetaPrior;
            omegaNext = omegaPrior;
            tNext = tPrior;

            //X.Add(xPrior);
            //V.Add(vPrior);
            //ElapsedTime.Add(tPrior);

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(ValueString(comboBoxX.Text, thetaNext, omegaNext, tNext),
                ValueString(comboBoxY.Text, thetaNext, omegaNext, tNext));

            pictureBoxCurve.Invalidate();
            PrintResult();

        }// End ResetData


        private double ValueString(string st, double theta, double omega, double t)
        {
           
            switch (st)
            {
                case "theta" :
                    return theta * 180/Math.PI;
                case "omega" :
                    return omega;
                case "Potential Energy" :
                    return chaoticPendelum.PotentialEnergy(theta);
                case "Kinetic Energy" :
                    return chaoticPendelum.KineticEnergy(omega);
                case "Mechanic Energy" :
                    return chaoticPendelum.MechanicEnergy(theta, omega);
                case "Tension" :
                    return chaoticPendelum.Tension(theta, omega);
                case "alfa" :
                    return chaoticPendelum.OmegaDot(theta, omega, t);
                case "Driving Force" :
                    return chaoticPendelum.DrivingForce(t);

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
                chaoticPendelum.NextVar(dt, thetaPrior, omegaPrior, out thetaNext, out omegaNext, tPrior);
                if (i < n)
                {
                    thetaPrior = thetaNext;
                    omegaPrior = omegaNext;
                    tPrior += dt;
                }
            }
            tNext = tPrior + dt;

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, thetaNext, omegaNext, tNext),
                                  ValueString(comboBoxY.Text, thetaNext, omegaNext, tNext));
            pictureBoxCurve.Invalidate();

            PrintResult();

            thetaPrior = thetaNext;
            omegaPrior = omegaNext;
            tPrior = tNext;

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

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, thetaNext, omegaNext, tNext),
                                  ValueString(comboBoxY.Text, thetaNext, omegaNext, tNext));
            pictureBoxCurve.Invalidate();


            thetaPrior = thetaNext;
            omegaPrior = omegaNext;
            tPrior = tNext;

            pictureBoxAnimate.Invalidate();
        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            plotClass.RepeatDrawingPointsMap();
            pictureBoxAnimate.Invalidate();
            pictureBoxCurve.Invalidate();

        }

        private void buttonResetData_Click(object sender, EventArgs e)
        {
            ResetData();
            //PrintResult();
           
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

            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;
        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            int lMases = 10;
            int l = (int)(scaleAnimate * chaoticPendelum.l) - lMases;

            //Rectangle rectRod = new Rectangle(0, -2, l, 4);
            Rectangle rectMass = new Rectangle(l, -lMases, 2*lMases, 2*lMases);

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 2, pictureBoxAnimate.Height / 2);
            GraphicsState gState = g.Save();

            // Draw x y
            g.DrawLine(new Pen(Color.Blue), 0, 0, 20, 0);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("x", font, new SolidBrush(Color.Blue), 20, -7);
            g.DrawLine(new Pen(Color.Blue), 0, 0, 0, 20);
            g.DrawString("y", font, new SolidBrush(Color.Blue), -4, 18);
            //-----

            // Drawing DrivingForce
            if (chaoticPendelum.A != 0)
            {
                int rDF = 60;
                float beta = (float)(chaoticPendelum.DrivingForce(tPrior) * 90 / chaoticPendelum.A);
                g.DrawArc(new Pen(Color.Black), -rDF, -rDF, 2 * rDF, 2 * rDF, 90, -beta);


                // Drawing Arrow
                Point[] ptsArrow = new Point[3] { new Point(-6, -4), new Point(0, 0), new Point(-6, 4) };
                int xArrow = (int)Math.Round(rDF * Math.Sin(beta * Math.PI / 180));
                int yArrow = (int)Math.Round((rDF * Math.Cos(beta * Math.PI / 180)));

                g.TranslateTransform(xArrow, yArrow);
                if (beta < 0)
                    g.RotateTransform(180 - beta);
                else
                    g.RotateTransform(- beta);
                g.DrawLines(new Pen(Color.Black), ptsArrow);
                g.Restore(gState);

                //
            }


            // Drawing Rod And Mass
            g.RotateTransform((float)(90  - thetaPrior * 180 / Math.PI));

            g.DrawLine(new Pen(Color.DarkGreen,3), 0, 0, l, 0);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectMass);
    
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

        private void FormChaoticPendelum_FormClosing(object sender, FormClosingEventArgs e)
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

    //*****************************************************
    //*****************************************************

    public class ChaoticPendelum
    {
        // Variables
        public double m, g, l, b, k, A, phase;
        // g= gravitation cons, l = lenght of pendelum, b = damping cons, k = frequance of Driving Force,
        // A= Ampilitude of Drinving Force
        //-----------

        public  ChaoticPendelum()
        {
        }

        public ChaoticPendelum(double m, double g, double l, double b, double k, double A, double phase)
        {
            this.m = m;
            this.g = g;
            this.l = l;
            this.b = b;
            this.k = k;
            this.A = A;
            this.phase = phase;

        }

        public double OmegaDot(double theta, double omega, double t)
        {
            return -g / l * Math.Sin(theta) + (-b * omega + DrivingForce(t) / (m * l * l));
        }

        public void NextVar(double dt, double thetaPrior, double omegaPrior, out double thetaNext, out double omegaNext,
            double tPrior)
        {
            double 
                Atheta, Btheta, Ctheta, Dtheta,
                Aomega, Bomega, Comega, Domega;


            Atheta = omegaPrior * dt;
            Aomega = OmegaDot(thetaPrior, omegaPrior, tPrior) * dt;

            Btheta = (omegaPrior + Aomega / 2) * dt;
            Bomega = OmegaDot(thetaPrior + Atheta / 2, omegaPrior + Aomega / 2, tPrior + dt/2) * dt;

            Ctheta = (omegaPrior + Bomega / 2) * dt;
            Comega = OmegaDot(thetaPrior + Btheta / 2, omegaPrior + Bomega / 2, tPrior + dt / 2) * dt;

            Dtheta = (omegaPrior + Comega) * dt;
            Domega = OmegaDot(thetaPrior + Ctheta, omegaPrior + Comega, tPrior + dt) * dt;


            thetaNext = thetaPrior + (Atheta + 2 * Btheta + 2 * Ctheta + Dtheta) / 6;
            omegaNext = omegaPrior + (Aomega + 2 * Bomega + 2 * Comega + Domega) / 6;
        }

        public double KineticEnergy(double omega)
        {
            return  m * l * l * omega * omega / 2;
        }
        public double PotentialEnergy(double theta)
        {
            return -m * g * l * Math.Cos(theta);
        }

        public double MechanicEnergy(double theta, double omega)
        {
            return KineticEnergy(omega) + PotentialEnergy(theta);
        }
        public double Tension(double theta, double omega)
        {
            return m * g * Math.Cos(theta) - m * l * omega * omega;
        }
        public double DrivingForce(double t)
        {
            return A * Math.Cos(k * t + phase);
        }
        
    }

        
}