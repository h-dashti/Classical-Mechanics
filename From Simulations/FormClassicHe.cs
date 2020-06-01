using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormClassicHe : Form
    {
        //--------------- Variables
        private double xPrior1, vxPrior1, xNext1, vxNext1, tPrior, tNext,
            yPrior1, vyPrior1, yNext1, vyNext1,
            xPrior2, vxPrior2, xNext2, vxNext2,
            yPrior2, vyPrior2, yNext2, vyNext2;

        private ClassicHe classicHe;
        //private ArrayList X, V, ElapsedTime;

        private Size margin = new Size(55, 35);
        private int n;

        private double dt;
        double scaleAnimate = 30;

        private PlotClass plotClass;
        //-------------------------- End Variables
        //

        public FormClassicHe()
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
            pictureBoxCurve.Size = new Size(650, vertical);
            pictureBoxAnimate.Size = new Size(400, vertical);
            pictureBoxAnimate.Location = new Point(pictureBoxCurve.Location.X + pictureBoxCurve.Width + 1,
                pictureBoxCurve.Location.Y);
            //labelResult.Location = new Point(pictureBoxAnimate.Location.X + pictureBoxAnimate.Width + 2,
              //  pictureBoxCurve.Location.Y);
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
            textBoxy1.Text = "0";
            textBoxvx1.Text = "0";
            textBoxvy1.Text = "0.95";

            textBoxx2.Text = "-1";
            textBoxy2.Text = "0";
            textBoxvx2.Text = "0";
            textBoxvy2.Text = "-1";

            textBoxc.Text = "1";

            timer1.Interval = 1;
            dt = 5E-5;
            n = 4500;

            ResetData();
        
        }// End Initialize1

        private void ResetData()
        {
            //X = new ArrayList();
            //V = new ArrayList();
            //ElapsedTime = new ArrayList();

            classicHe = new ClassicHe();
            classicHe.c = double.Parse(textBoxc.Text);

            xPrior1 = double.Parse(textBoxx1.Text);
            yPrior1 = double.Parse(textBoxy1.Text);
            vxPrior1 = double.Parse(textBoxvx1.Text);
            vyPrior1 = double.Parse(textBoxvy1.Text);

            xPrior2 = double.Parse(textBoxx2.Text);
            yPrior2 = double.Parse(textBoxy2.Text);
            vxPrior2 = double.Parse(textBoxvx2.Text);
            vyPrior2 = double.Parse(textBoxvy2.Text);

            tPrior = 0.0;

            xNext1 = xPrior1;
            yNext1 = yPrior1;
            vxNext1 = vxPrior1;
            vyNext1 = vyPrior1;

            xNext2 = xPrior2;
            yNext2 = yPrior2;
            vxNext2 = vxPrior2;
            vyNext2 = vyPrior2;

            tNext = tPrior;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
               pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, xNext1, vxNext1, yNext1, vyNext1,
                xNext2, vxNext2, yNext2, vyNext2, tNext),
                ValueString(comboBoxY.Text, xNext1, vxNext1, yNext1, vyNext1,
                xNext2, vxNext2, yNext2, vyNext2, tNext));

            pictureBoxCurve.Invalidate();
           
        }// End ResetData

        private double ValueString(string st, double x1, double vx1, double y1, double vy1,
           double x2, double vx2, double y2, double vy2, double t)
        {
            switch (st)
            {
                //case "r1":
                //    return doubleSpring2D.L1(x1, y1);
                //case "theta1":
                //    return doubleSpring2D.AngleD1(x1, y1);
                case "x1":
                    return x1;
                case "vx1":
                    return vx1;
                case "y1":
                    return y1;
                case "vy1":
                    return vy1;

                //case "r2":
                //    return doubleSpring2D.L2(x1, y1, x2, y2);
                //case "theta2":
                //    return doubleSpring2D.AngleD2(x1, y1, x2, y2);

                case "x2":
                    return x2;
                case "vx2":
                    return vx2;
                case "y2":
                    return y2;
                case "vy2":
                    return vy2;

                //case "Kinetic Energy1":
                //    return doubleSpring2D.KineticEnergy1(vx1, vy1);

                //case "Kinetic Energy2":
                //    return doubleSpring2D.KineticEnergy2(vx2, vy2);

                //case "Kinetic Energy":
                //    return doubleSpring2D.KineticEnergy(vx1, vy1, vx2, vy2);

                //case "Potential Energy":
                //    return doubleSpring2D.PotentialEnergy(x1, y1, x2, y2);

                //case "Mechanic Energy":
                //    return doubleSpring2D.MechanicEnergy(x1, y1, x2, y2, vx1, vy1, vx2, vy2);

                case "ax1":
                    return classicHe.Fx1(x1, y1, x2, y2);
                case "ay1":
                    return classicHe.Fy1(x1, y1, x2, y2);

                case "ax2":
                    return classicHe.Fx2(x1, y1, x2, y2);
                case "ay2":
                    return classicHe.Fy2(x1, y1, x2, y2);

                //case "RadialDot1":
                //    return doubleSpring2D.RadialDot1(x1, y1, vx1, vx2);
                //case "AngularDot1":
                //    return doubleSpring2D.AngularDot1(x1, y1, vx1, vx2);

                //case "RadialDot2":
                //    return doubleSpring2D.RadialDot2(x1, y1, vx1, vx2, x2, y2, vx2, vy2);
                //case "AngularDot2":
                //    return doubleSpring2D.AngularDot2(x1, y1, vx1, vx2, x2, y2, vx2, vy2);

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
                classicHe.NextVar1(dt,
                    xPrior1, vxPrior1, out xNext1, out vxNext1,
                    yPrior1, vyPrior1, out yNext1, out vyNext1,
                    xPrior2, vxPrior2, out xNext2, out vxNext2,
                    yPrior2, vyPrior2, out yNext2, out vyNext2);

                if (i < n)
                {
                    xPrior1 = xNext1;
                    yPrior1 = yNext1;
                    vxPrior1 = vxNext1;
                    vyPrior1 = vyNext1;

                    xPrior2 = xNext2;
                    yPrior2 = yNext2;
                    vxPrior2 = vxNext2;
                    vyPrior2 = vyNext2;
                }
            }
            tNext = n * dt + tPrior;

            plotClass.AddNewPoint(
                 ValueString(comboBoxX.Text, xNext1, vxNext1, yNext1, vyNext1,
                 xNext2, vxNext2, yNext2, vyNext2, tNext),
                 ValueString(comboBoxY.Text, xNext1, vxNext1, yNext1, vyNext1,
                 xNext2, vxNext2, yNext2, vyNext2, tNext));

            pictureBoxCurve.Invalidate();

            xPrior1 = xNext1;
            yPrior1 = yNext1;
            vxPrior1 = vxNext1;
            vyPrior1 = vyNext1;

            xPrior2 = xNext2;
            yPrior2 = yNext2;
            vxPrior2 = vxNext2;
            vyPrior2 = vyNext2;

            tPrior = tNext;

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
            xPrior1 = xNext1;
            yPrior1 = yNext1;
            vxPrior1 = vxNext1;
            vyPrior1 = vyNext1;

            xPrior2 = xNext2;
            yPrior2 = yNext2;
            vxPrior2 = vxNext2;
            vyPrior2 = vyNext2;

            tPrior = tNext;
            plotClass.AddNewPoint(
                            ValueString(comboBoxX.Text, xNext1, vxNext1, yNext1, vyNext1,
                            xNext2, vxNext2, yNext2, vyNext2, tNext),
                            ValueString(comboBoxY.Text, xNext1, vxNext1, yNext1, vyNext1,
                            xNext2, vxNext2, yNext2, vyNext2, tNext));

            pictureBoxCurve.Invalidate();

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
            Graphics g = e.Graphics;

            g.ScaleTransform(1, -1);
            g.TranslateTransform(pictureBoxAnimate.Width / 2, -pictureBoxAnimate.Height / 2);

            g.DrawRectangle(new Pen(Color.Black), 0, 0, 1, 1);

            int r = 1;

            Rectangle rect1 = new Rectangle((int)(scaleAnimate * xPrior1) - r, (int)(scaleAnimate * yPrior1) - r, 2 * r, 2 * r);
            Rectangle rect2 = new Rectangle((int)(scaleAnimate * xPrior2) - r, (int)(scaleAnimate * yPrior2) - r, 2 * r, 2 * r);

            g.FillRectangle(new SolidBrush(Color.DarkBlue), rect1);
            g.FillRectangle(new SolidBrush(Color.DarkRed), rect2);


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

        private void FormClassicHe_FormClosing(object sender, FormClosingEventArgs e)
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






    }// -------- End FormClassicHe



    //*********************************************
    //**********************************************
    public class ClassicHe
    {
        //------------- Vaiables
        public double c;
        //
        public ClassicHe()
        {
            c = 1.0;
        }
        public ClassicHe(double c)
        {
            this.c = c;
        }


        public double Fx1(double x1Data, double y1Data, double x2Data, double y2Data)
        {
            double r1 = Math.Sqrt(x1Data * x1Data + y1Data * y1Data);
            double dx = x1Data - x2Data;
            double dy = y1Data - y2Data;
            double r12 = Math.Sqrt(dx * dx + dy * dy);
            return (-2 * x1Data / (r1 * r1 * r1) + dx / (r12 * r12 * r12)) * c;
        }
        public double Fy1(double x1Data, double y1Data, double x2Data, double y2Data)
        {
            double r1 = Math.Sqrt(x1Data * x1Data + y1Data * y1Data);
            double dx = x1Data - x2Data;
            double dy = y1Data - y2Data;
            double r12 = Math.Sqrt(dx * dx + dy * dy);
            return (-2 * y1Data / (r1 * r1 * r1) + dy / (r12 * r12 * r12)) * c;
        }

        public double Fx2(double x1Data, double y1Data, double x2Data, double y2Data)
        {
            double r2 = Math.Sqrt(x2Data * x2Data + y2Data * y2Data);
            double dx = x2Data - x1Data;
            double dy = y2Data - y1Data;
            double r12 = Math.Sqrt(dx * dx + dy * dy);
            return (-2 * x2Data / (r2 * r2 * r2) + dx / (r12 * r12 * r12)) * c;
        }

        public double Fy2(double x1Data, double y1Data, double x2Data, double y2Data)
        {
            double r2 = Math.Sqrt(x2Data * x2Data + y2Data * y2Data);
            double dx = x2Data - x1Data;
            double dy = y2Data - y1Data;
            double r12 = Math.Sqrt(dx * dx + dy * dy);
            return (-2 * y2Data / (r2 * r2 * r2) + dy / (r12 * r12 * r12)) * c;
        }


        

        public void NextVar1(double dt,
            double xPrior1, double vxPrior1, out double xNext1, out double vxNext1,
            double yPrior1, double vyPrior1, out double yNext1, out double vyNext1,
            double xPrior2, double vxPrior2, out double xNext2, out double vxNext2,  
            double yPrior2, double vyPrior2, out double yNext2, out double vyNext2)
        {
             double
                 Ax1, Bx1, Cx1, Dx1, Avx1, Bvx1, Cvx1, Dvx1,
                 Ay1, By1, Cy1, Dy1, Avy1, Bvy1, Cvy1, Dvy1,
                 Ax2, Bx2, Cx2, Dx2, Avx2, Bvx2, Cvx2, Dvx2,
                 Ay2, By2, Cy2, Dy2, Avy2, Bvy2, Cvy2, Dvy2; // Runge Kutta method 




             Ax1 = vxPrior1 * dt;
             Avx1 = Fx1(xPrior1, yPrior1, xPrior2, yPrior2) * dt;
             Ay1 = vyPrior1 * dt;
             Avy1 = Fy1(xPrior1, yPrior1, xPrior2, yPrior2) * dt;

             Ax2 = vxPrior2 * dt;
             Avx2 = Fx2(xPrior1, yPrior1, xPrior2, yPrior2) * dt;
             Ay2 = vyPrior2 * dt;
             Avy2 = Fy2(xPrior1, yPrior1, xPrior2, yPrior2) * dt;




             Bx1 = (vxPrior1 + Avx1 / 2) * dt;
             Bvx1 = Fx1(xPrior1 + Ax1 / 2, yPrior1 + Ay1 / 2, xPrior2 + Ax2 / 2, yPrior2 + Ay2 / 2) * dt;
             By1 = (vyPrior1 + Avy1 / 2) * dt;
             Bvy1 = Fy1(xPrior1 + Ax1 / 2, yPrior1 + Ay1 / 2, xPrior2 + Ax2 / 2, yPrior2 + Ay2 / 2) * dt;

             Bx2 = (vxPrior2 + Avx2 / 2) * dt;
             Bvx2 = Fx2(xPrior1 + Ax1 / 2, yPrior1 + Ay1 / 2, xPrior2 + Ax2 / 2, yPrior2 + Ay2 / 2) * dt;
             By2 = (vyPrior2 + Avy2 / 2) * dt;
             Bvy2 = Fy2(xPrior1 + Ax1 / 2, yPrior1 + Ay1 / 2, xPrior2 + Ax2 / 2, yPrior2 + Ay2 / 2) * dt;



             Cx1 = (vxPrior1 + Bvx1 / 2) * dt;
             Cvx1 = Fx1(xPrior1 + Bx1 / 2, yPrior1 + By1 / 2, xPrior2 + Bx2 / 2, yPrior2 + By2 / 2) * dt;
             Cy1 = (vyPrior1 + Bvy1 / 2) * dt;
             Cvy1 = Fy1(xPrior1 + Bx1 / 2, yPrior1 + By1 / 2, xPrior2 + Bx2 / 2, yPrior2 + By2 / 2) * dt;

             Cx2 = (vxPrior2 + Bvx2 / 2) * dt;
             Cvx2 = Fx2(xPrior1 + Bx1 / 2, yPrior1 + By1 / 2, xPrior2 + Bx2 / 2, yPrior2 + By2 / 2) * dt;
             Cy2 = (vyPrior2 + Bvy2 / 2) * dt;
             Cvy2 = Fy2(xPrior1 + Bx1 / 2, yPrior1 + By1 / 2, xPrior2 + Bx2 / 2, yPrior2 + By2 / 2) * dt;




             Dx1 = (vxPrior1 + Cvx1) * dt;
             Dvx1 = Fx1(xPrior1 + Cx1, yPrior1 + Cy1, xPrior2 + Cx2, yPrior2 + Cy2) * dt;
             Dy1 = (vyPrior1 + Cvy1) * dt;
             Dvy1 = Fy1(xPrior1 + Cx1, yPrior1 + Cy1, xPrior2 + Cx2, yPrior2 + Cy2) * dt;

             Dx2 = (vxPrior2 + Cvx2) * dt;
             Dvx2 = Fx2(xPrior1 + Cx1, yPrior1 + Cy1, xPrior2 + Cx2, yPrior2 + Cy2) * dt;
             Dy2 = (vyPrior2 + Cvy2) * dt;
             Dvy2 = Fy2(xPrior1 + Cx1, yPrior1 + Cy1, xPrior2 + Cx2, yPrior2 + Cy2) * dt;




             xNext1 = xPrior1 + (Ax1 + 2 * Bx1 + 2 * Cx1 + Dx1) / 6;
             yNext1 = yPrior1 + (Ay1 + 2 * By1 + 2 * Cy1 + Dy1) / 6;
             vxNext1 = vxPrior1 + (Avx1 + 2 * Bvx1 + 2 * Cvx1 + Dvx1) / 6;
             vyNext1 = vyPrior1 + (Avy1 + 2 * Bvy1 + 2 * Cvy1 + Dvy1) / 6;

             xNext2 = xPrior2 + (Ax2 + 2 * Bx2 + 2 * Cx2 + Dx2) / 6;
             yNext2 = yPrior2 + (Ay2 + 2 * By2 + 2 * Cy2 + Dy2) / 6;
             vxNext2 = vxPrior2 + (Avx2 + 2 * Bvx2 + 2 * Cvx2 + Dvx2) / 6;
             vyNext2 = vyPrior2 + (Avy2 + 2 * Bvy2 + 2 * Cvy2 + Dvy2) / 6;

         }


         #region Old Methods

         //public void NextVar2(double dt,
        //double x1Prior, double vx1Prior, out double x1Next, out double vx1Next,
        //double y1Prior, double vy1Prior, out double y1Next, out double vy1Next,
        //double x2Prior, double vx2Prior, out double x2Next, out double vx2Next,
        //double y2Prior, double vy2Prior, out double y2Next, out double vy2Next)
        //{
        //    double k1x1, k2x1, k3x1, k4x1,
        //        k1x2, k2x2, k3x2, k4x2, k1vx2, k2vx2, k3vx2, k4vx2,
        //        k1vx1, k2vx1, k3vx1, k4vx1, k1y1, k2y1, k3y1, k4y1,
        //        k1y2, k2y2, k3y2, k4y2, k1vy2, k2vy2, k3vy2, k4vy2,
        //        k1vy1, k2vy1, k3vy1, k4vy1;



        //    k1vx1 = Ax1(x1Prior, y1Prior, x2Prior, y2Prior) * dt;
        //    k1x1 = vx1Prior * dt;
        //    k1vy1 = Ay1(x1Prior, y1Prior, x2Prior, y2Prior) * dt;
        //    k1y1 = vy1Prior * dt;
        //    k1vx2 = Ax2(x1Prior, y1Prior, x2Prior, y2Prior) * dt;
        //    k1x2 = vx2Prior * dt;
        //    k1vy2 = Ay2(x1Prior, y1Prior, x2Prior, y2Prior) * dt;
        //    k1y2 = vy2Prior * dt;

        //    k2vx1 = Ax1(x1Prior + k1x1 / 2.0, y1Prior + k1y1 / 2.0, x2Prior + k1x2 / 2.0, y2Prior + k1y2 / 2.0) * dt;
        //    k2x1 = (vx1Prior + k1vx1 / 2.0) * dt;
        //    k2vy1 = Ay1(x1Prior + k1x1 / 2.0, y1Prior + k1y1 / 2.0, x2Prior + k1x2 / 2.0, y2Prior + k1y2 / 2.0) * dt;
        //    k2y1 = (vy1Prior + k1vy1 / 2.0) * dt;
        //    k2vx2 = Ax2(x1Prior + k1x1 / 2.0, y1Prior + k1y1 / 2.0, x2Prior + k1x2 / 2.0, y2Prior + k1y2 / 2.0) * dt;
        //    k2x2 = (vx2Prior + k1vx2 / 2.0) * dt;
        //    k2vy2 = Ay2(x1Prior + k1x1 / 2.0, y1Prior + k1y1 / 2.0, x2Prior + k1x2 / 2.0, y2Prior + k1y2 / 2.0) * dt;
        //    k2y2 = (vy2Prior + k1vy2 / 2.0) * dt;

        //    k3vx1 = Ax1(x1Prior + k2x1 / 2.0, y1Prior + k2y1 / 2.0, x2Prior + k2x2 / 2.0, y2Prior + k2y2 / 2.0) * dt;
        //    k3x1 = (vx1Prior + k2vx1 / 2.0) * dt;
        //    k3vy1 = Ay1(x1Prior + k2x1 / 2.0, y1Prior + k2y1 / 2.0, x2Prior + k2x2 / 2.0, y2Prior + k2y2 / 2.0) * dt; ;
        //    k3y1 = (vy1Prior + k2vy1 / 2.0) * dt;
        //    k3vx2 = Ax2(x1Prior + k2x1 / 2.0, y1Prior + k2y1 / 2.0, x2Prior + k2x2 / 2.0, y2Prior + k2y2 / 2.0) * dt;
        //    k3x2 = (vx2Prior + k2vx2 / 2.0) * dt;
        //    k3vy2 = Ay2(x1Prior + k2x1 / 2.0, y1Prior + k2y1 / 2.0, x2Prior + k2x2 / 2.0, y2Prior + k2y2 / 2.0) * dt;
        //    k3y2 = (vy2Prior + k2vy2 / 2.0) * dt;

        //    k4vx1 = Ax1(x1Prior + k3x1, y1Prior + k3y1, x2Prior + k3x2, y2Prior + k3y2) * dt;
        //    k4x1 = (vx1Prior + k3vx1) * dt;
        //    k4vy1 = Ay1(x1Prior + k3x1, y1Prior + k3y1, x2Prior + k3x2, y2Prior + k3y2) * dt;
        //    k4y1 = (vy1Prior + k3vy1) * dt;
        //    k4vx2 = Ax2(x1Prior + k3x1, y1Prior + k3y1, x2Prior + k3x2, y2Prior + k3y2) * dt;
        //    k4x2 = (vx2Prior + k3vx2) * dt;
        //    k4vy2 = Ay2(x1Prior + k3x1, y1Prior + k3y1, x2Prior + k3x2, y2Prior + k3y2) * dt;
        //    k4y2 = (vy2Prior + k3vy2) * dt;

        //    x1Next = x1Prior + (k1x1 + k2x1 * 2.0 + k3x1 * 2.0 + k4x1) / 6.0;
        //    y1Next = y1Prior + (k1y1 + k2y1 * 2.0 + k3y1 * 2.0 + k4y1) / 6.0;
        //    x2Next = x2Prior + (k1x2 + k2x2 * 2.0 + k3x2 * 2.0 + k4x2) / 6.0;
        //    y2Next = y2Prior + (k1y2 + k2y2 * 2.0 + k3y2 * 2.0 + k4y2) / 6.0;

        //    vx1Next = vx1Prior + (k1vx1 + k2vx1 * 2.0 + k3vx1 * 2.0 + k4vx1) / 6.0;
        //    vy1Next = vy1Prior + (k1vy1 + k2vy1 * 2.0 + k3vy1 * 2.0 + k4vy1) / 6.0;
        //    vx2Next = vx2Prior + (k1vx2 + k2vx2 * 2.0 + k3vx2 * 2.0 + k4vx2) / 6.0;
        //    vy2Next = vy2Prior + (k1vy2 + k2vy2 * 2.0 + k3vy2 * 2.0 + k4vy2) / 6.0;
        //}

         //double Ax1(double x1Data, double y1Data, double x2Data, double y2Data)
         //{
         //    double r1 = Math.Sqrt(x1Data * x1Data + y1Data * y1Data);
         //    double dx = x1Data - x2Data;
         //    double dy = y1Data - y2Data;
         //    double r12 = Math.Sqrt(dx * dx + dy * dy);
         //    return (-2 * x1Data / (r1 * r1 * r1) + dx / (r12 * r12 * r12)) * c;
         //}
         //double Ay1(double x1Data, double y1Data, double x2Data, double y2Data)
         //{
         //    double r1 = Math.Sqrt(x1Data * x1Data + y1Data * y1Data);
         //    double dx = x1Data - x2Data;
         //    double dy = y1Data - y2Data;
         //    double r12 = Math.Sqrt(dx * dx + dy * dy);
         //    return (-2 * y1Data / (r1 * r1 * r1) + dy / (r12 * r12 * r12)) * c;
         //}

         //double Ax2(double x1Data, double y1Data, double x2Data, double y2Data)
         //{
         //    double r2 = Math.Sqrt(x2Data * x2Data + y2Data * y2Data);
         //    double dx = x2Data - x1Data;
         //    double dy = y2Data - y1Data;
         //    double r12 = Math.Sqrt(dx * dx + dy * dy);
         //    return (-2 * x2Data / (r2 * r2 * r2) + dx / (r12 * r12 * r12)) * c;
         //}

         //double Ay2(double x1Data, double y1Data, double x2Data, double y2Data)
         //{
         //    double r2 = Math.Sqrt(x2Data * x2Data + y2Data * y2Data);
         //    double dx = x2Data - x1Data;
         //    double dy = y2Data - y1Data;
         //    double r12 = Math.Sqrt(dx * dx + dy * dy);
         //    return (-2 * y2Data / (r2 * r2 * r2) + dy / (r12 * r12 * r12)) * c;
         //}

        #endregion
        
    }// --- ClassicHe



   
}