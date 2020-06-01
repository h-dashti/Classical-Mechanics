using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormDoublePendelum : Form
    {
        //--------------- Variables
        private double 
            thetaPrior1, omegaPrior1, thetaNext1, omegaNext1,
            thetaPrior2, omegaPrior2, thetaNext2, omegaNext2, tPrior, tNext;

        private DoublePendelum doublePendelum;
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
                "theta1 = " + Convert.ToString( thetaNext1*180/Math.PI) + "\r\n" +
                "omega1 = " + omegaNext1.ToString() + "\r\n" +
                "alfa1  = " + doublePendelum.Alfa1(thetaNext1, omegaNext1, thetaNext2, omegaNext2).ToString() + "\r\n" +
                "theta2 = " + Convert.ToString(thetaNext2 * 180 / Math.PI) + "\r\n" +
                "omega2 = " + omegaNext2.ToString() + "\r\n" +
                "alfa2  = " + doublePendelum.Alfa2(thetaNext1, omegaNext1, thetaNext2, omegaNext2).ToString() + "\r\n\r\n" +

                "Kientic E = " + "\r\n" +
                doublePendelum.KineticE(thetaNext1, omegaNext1, thetaNext2, omegaNext2).ToString() + "\r\n" +
                "Potentia E =\r\n" + doublePendelum.PotentialE(thetaNext1, thetaNext2) + "\r\n" +
                "Mechanical E =" + "\r\n" +
                doublePendelum.MechanicalE(thetaNext1, omegaNext1, thetaNext2, omegaNext2).ToString() + "\r\n\r\n" +
                "t = " + tNext.ToString();
        }

        public FormDoublePendelum()
        {
            InitializeComponent();
            InitControlsLocation();
            Initialize1();

            
        }

        private void InitControlsLocation()
        {
            int vertical = 650 ;
            pictureBoxCurve.Size = new Size(DesktopBounds.Width - 300, vertical);
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
            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;

            textBoxtheta1.Text = "30";
            textBoxomega1.Text = "0";
            textBoxm1.Text = "1";
            textBoxl1.Text = "2.5";

            textBoxtheta2.Text = "-90";
            textBoxomega2.Text = "0";
            textBoxm2.Text = "1";
            textBoxl2.Text = "2.5";

            textBoxg.Text = "9.8";
            
            timer1.Interval = 10;
            dt = 0.005;
            n = 5;

            ResetData();
            PrintResult();
            
        }// End Initialize1

        private void ResetData()
        {
            thetaPrior1 = double.Parse(textBoxtheta1.Text) * Math.PI / 180;
            omegaPrior1 = double.Parse(textBoxomega1.Text);

            thetaPrior2 = double.Parse(textBoxtheta2.Text) * Math.PI / 180;
            omegaPrior2 = double.Parse(textBoxomega2.Text);

            doublePendelum = new DoublePendelum();

            doublePendelum.m1 = double.Parse(textBoxm1.Text);
            doublePendelum.l1 = double.Parse(textBoxl1.Text);

            doublePendelum.m2 = double.Parse(textBoxm2.Text);
            doublePendelum.l2 = double.Parse(textBoxl2.Text);

            doublePendelum.g = double.Parse(textBoxg.Text);
    
            tPrior = 0.0;

            thetaNext1 = thetaPrior1;
            omegaNext1 = omegaPrior1;
            thetaNext2 = thetaPrior2;
            omegaNext2 = omegaPrior2;
            tNext = tPrior;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
               pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext),
                ValueString(comboBoxY.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext));
            pictureBoxCurve.Invalidate();

            //PrintResult();

        }// End ResetData

        private double ValueString(string st, double theta1, double omega1, double theta2, double omega2, double t)
        {

            switch (st)
            {
                case "x1" :
                    return doublePendelum.X1(theta1);
                case "y1":
                    return doublePendelum.Y1(theta1);
                case "x2":
                    return doublePendelum.X2(theta1, theta2);
                case "y2":
                    return doublePendelum.Y2(theta1, theta2);

                case "theta1":
                    return theta1 * 180 / Math.PI;
                case "omega1":
                    return omega1;
                case "alfa1":
                    return doublePendelum.Alfa1(theta1, omega1, theta2, omega2);

                case "theta2":
                    return theta2 * 180 / Math.PI;
                case "omega2":
                    return omega2;
                case "alfa2":
                    return doublePendelum.Alfa2(theta1, omega1, theta2, omega2);
                   
                case "Potential E":
                    return doublePendelum.PotentialE(theta1, theta2);
                case "Kinetic E":
                    return doublePendelum.KineticE(theta1, omega1, theta2, omega2);
                case "Mechanical E":
                    return doublePendelum.MechanicalE(theta1, omega1, theta2, omega2);
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
                doublePendelum.NextVar(dt,
                    thetaPrior1, omegaPrior1, out thetaNext1, out omegaNext1,
                    thetaPrior2, omegaPrior2, out thetaNext2, out omegaNext2);
                if (i < n)
                {
                    thetaPrior1 = thetaNext1;
                    omegaPrior1 = omegaNext1;
                    thetaPrior2 = thetaNext2;
                    omegaPrior2 = omegaNext2;
                }
            }
            tNext = tPrior + n * dt;

            plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext),
                ValueString(comboBoxY.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext));
            pictureBoxCurve.Invalidate();

            PrintResult();

            thetaPrior1 = thetaNext1;
            omegaPrior1 = omegaNext1;
            thetaPrior2 = thetaNext2;
            omegaPrior2 = omegaNext2;
            tPrior = tNext;
            

            pictureBoxAnimate.Invalidate();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonPlay.Enabled = true;

            timer1.Tick -= new EventHandler(timer1_Tick);
            timer1.Stop();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();
            plotClass.AddNewPoint(
               ValueString(comboBoxX.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext),
               ValueString(comboBoxY.Text, thetaNext1, omegaNext1, thetaNext2, omegaNext2, tNext));
            pictureBoxCurve.Invalidate();

            thetaPrior1 = thetaNext1;
            omegaPrior1 = omegaNext1;
            thetaPrior2 = thetaNext2;
            omegaPrior2 = omegaNext2;
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
            PrintResult();
            pictureBoxAnimate.Invalidate();

            labelY.Text = comboBoxY.Text;
            labelX.Text = comboBoxX.Text;
        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            int lMases = 10;
            int l1 = (int)(scaleAnimate * doublePendelum.l1) - lMases;

            Rectangle rectMass1 = new Rectangle(l1, -lMases, 2*lMases, 2*lMases);

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBoxAnimate.Width / 2, pictureBoxAnimate.Height / 2);
            GraphicsState gState = g.Save();

            // Draw x y
            g.DrawLine(new Pen(Color.Blue), 0, 0, 20, 0);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            g.DrawString("x", font, new SolidBrush(Color.Blue), 20, -7);
            g.DrawLine(new Pen(Color.Blue), 0, 0, 0, -20);
            g.DrawString("y", font, new SolidBrush(Color.Blue), -4, -35);
            //-----


            // Drawing Rod And Mass1
            g.RotateTransform((float)(90 - thetaPrior1 * 180 / Math.PI));

            g.DrawLine(new Pen(Color.DarkGreen,3), 0, 0, l1, 0);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectMass1);
            g.Restore(gState);
            //



            // Drawing Rod And Mass2
            int l2 = (int)(scaleAnimate * doublePendelum.l2) - lMases;
            Rectangle rectMass2 = new Rectangle(l2, -lMases, 2*lMases, 2*lMases);

            g.TranslateTransform((float)((l1 + rectMass1.Width/2) * Math.Sin(thetaPrior1)),
                (float)((l1 + rectMass1.Height/2) * Math.Cos(thetaPrior1)));

            g.RotateTransform((float)(90 - thetaPrior2 * 180 / Math.PI));

            g.DrawLine(new Pen(Color.DarkGreen,3), 0, 0, l2, 0);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectMass2);
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

        private void FormDoublePendelum_FormClosing(object sender, FormClosingEventArgs e)
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

    }//  End Form



    //**************************************************************************
    //**************************************************************************

    public class DoublePendelum
    {
        // Variables
        public double l1, l2, m1, m2, g;
        //

        public DoublePendelum()
        {
        }
        public DoublePendelum(double l1, double l2, double m1, double m2, double g)
        {
            this.g = g;
            this.l1 = l1;
            this.l2 = l2;
            this.m1 = m1;
            this.m2 = m2;
        }
        public double Alfa1(double theta1, double omega1, double theta2, double omega2)
        {
            return (-g * (2 * m1 + m2) * Math.Sin(theta1) - m2 * g * Math.Sin(theta1 - 2 * theta2) -
                2 * Math.Sin(theta1 - theta2) * m2 * (omega2 * omega2 * l2 + omega1 * omega1 * l1 * Math.Cos(theta1 - theta2))) /
                (l1 * (2 * m1 + m2 - m2 * Math.Cos(2 * theta1 - 2 * theta2)));
        }

        public double Alfa2(double theta1, double omega1, double theta2, double omega2)
        {
            return 2 * Math.Sin(theta1 - theta2) *
                (omega1 * omega1 * l1 * (m1 + m2) + g * (m1 + m2) * Math.Cos(theta1) + omega2 * omega2 * l2 * m2 * Math.Cos(theta1 - theta2)) /
                (l2 * (2 * m1 + m2 - m2 * Math.Cos(2 * theta1 - 2 * theta2)));
        }

        public void NextVar(double dt,
            double thetaPrior1, double omegaPrior1, out double thetaNext1, out double omegaNext1,
            double thetaPrior2, double omegaPrior2, out double thetaNext2, out double omegaNext2)
        {

            double
                Atheta1, Btheta1, Ctheta1, Dtheta1,
                Aomega1, Bomega1, Comega1, Domega1,
                Atheta2, Btheta2, Ctheta2, Dtheta2,
                Aomega2, Bomega2, Comega2, Domega2;

            Atheta1 = omegaPrior1 * dt;
            Aomega1 = Alfa1(thetaPrior1, omegaPrior1, thetaPrior2, omegaPrior2) * dt;
            Atheta2 = omegaPrior2 * dt;
            Aomega2 = Alfa2(thetaPrior1, omegaPrior1, thetaPrior2, omegaPrior2) * dt;



            Btheta1 = (omegaPrior1 + Aomega1 / 2) * dt;
            Bomega1 = Alfa1(thetaPrior1 + Atheta1 / 2, omegaPrior1 + Aomega1 / 2,
                thetaPrior2 + Atheta2 / 2, omegaPrior2 + Aomega2 / 2) * dt;
            Btheta2 = (omegaPrior2 + Aomega2 / 2) * dt;
            Bomega2 = Alfa2(thetaPrior1 + Atheta1 / 2, omegaPrior1 + Aomega1 / 2,
                thetaPrior2 + Atheta2 / 2, omegaPrior2 + Aomega2 / 2) * dt;



            Ctheta1 = (omegaPrior1 + Bomega1 / 2) * dt;
            Comega1 = Alfa1(thetaPrior1 + Btheta1 / 2, omegaPrior1 + Bomega1 / 2,
                thetaPrior2 + Btheta2 / 2, omegaPrior2 + Bomega2 / 2) * dt;
            Ctheta2 = (omegaPrior2 + Bomega2 / 2) * dt;
            Comega2 = Alfa2(thetaPrior1 + Btheta1 / 2, omegaPrior1 + Bomega1 / 2,
                thetaPrior2 + Btheta2 / 2, omegaPrior2 + Bomega2 / 2) * dt;



            Dtheta1 = (omegaPrior1 + Comega1) * dt;
            Domega1 = Alfa1(thetaPrior1 + Ctheta1 , omegaPrior1 + Comega1 , 
                thetaPrior2 + Ctheta2, omegaPrior2 + Comega2) * dt;
            Dtheta2 = (omegaPrior2 + Comega2) * dt;
            Domega2 = Alfa2(thetaPrior1 + Ctheta1, omegaPrior1 + Comega1,
                thetaPrior2 + Ctheta2, omegaPrior2 + Comega2) * dt;



            thetaNext1 = thetaPrior1 + (Atheta1 + 2 * Btheta1 + 2 * Ctheta1 + Dtheta1) / 6;
            thetaNext2 = thetaPrior2 + (Atheta2 + 2 * Btheta2 + 2 * Ctheta2 + Dtheta2) / 6;

            omegaNext1 = omegaPrior1 + (Aomega1 + 2 * Bomega1 + 2 * Comega1 + Domega1) / 6;
            omegaNext2 = omegaPrior2 + (Aomega2 + 2 * Bomega2 + 2 * Comega2 + Domega2) / 6;

        }

        public double X1(double theta1)
        {
            return l1 * Math.Sin(theta1);
        }
        public double Y1(double theta1)
        {
            return -l1 * Math.Cos(theta1);
        }
        public double X2(double theta1, double theta2)
        {
            return X1(theta1) + l2 * Math.Sin(theta2);
        }
        public double Y2(double theta1, double theta2)
        {
            return Y1(theta1) - l2 * Math.Cos(theta2);
        }

        public double KineticE(double theta1, double omega1, double theta2, double omega2)
        {
            return m1 / 2 * l1 * l1 * omega1 * omega1 +
                m2 / 2 * (l1 * l1 * omega1 * omega1 + l2 * l2 * omega2 * omega2 +
                2 * l1 * l2 * omega1 * omega2 * Math.Cos(theta2 - theta1));
             
        }

        public double PotentialE(double theta1, double theta2)
        {
            return -m1 * g * l1 * Math.Cos(theta1) - m2 * g * (l1 * Math.Cos(theta1) + l2 * Math.Cos(theta2));
        }
        public double MechanicalE(double theta1, double omega1, double theta2, double omega2)
        {
            return KineticE(theta1, omega1, theta2, omega2) + PotentialE(theta1, theta2);
        }


    }
}