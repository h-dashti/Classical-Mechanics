using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormDoubleSprings : Form
    {
        //--------------- Variables
        private double xPrior1, vPrior1, xNext1, vNext1, tPrior, tNext,
            xPrior2, vPrior2, xNext2, vNext2;
        private DoubleSprings doubleSpring;
        //private ArrayList X, V, ElapsedTime;

        Size margin = new Size(55, 35);
        private int n = 6;
        private double h = 0.005;
        double scaleAnimate = 20;

        private PlotClass plotClass;

        //_________________________________________________

        public FormDoubleSprings()
        {
            InitializeComponent();
            Initialize1();

            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
        }

        private void Initialize1()
        {
            textBoxx1.Text = "5";
            textBoxv1.Text = "0";
            textBoxk1.Text = "5";
            textBoxm1.Text = "0.5";
            textBoxR1.Text = "2.5";
            textBoxb1.Text = "0";

            textBoxx2.Text = "7.5";
            textBoxv2.Text = "0";
            textBoxk2.Text = "5";
            textBoxm2.Text = "0.5";
            textBoxR2.Text = "2.5";
            textBoxb2.Text = "0";

            timer1.Interval = 10;
            h = 0.005;
            n = 5;

            ResetData();
         
        }// End Initialize1
        private void ResetData()
        {
            //X = new ArrayList();
            //V = new ArrayList();
            //ElapsedTime = new ArrayList();

            doubleSpring = new DoubleSprings();
            doubleSpring.k1 = double.Parse(textBoxk1.Text);
            doubleSpring.m1 = double.Parse(textBoxm1.Text);
            doubleSpring.R1 = double.Parse(textBoxR1.Text);
            doubleSpring.b1 = double.Parse(textBoxb1.Text);
            doubleSpring.k2 = double.Parse(textBoxk2.Text);
            doubleSpring.m2 = double.Parse(textBoxm2.Text);
            doubleSpring.R2 = double.Parse(textBoxR2.Text);
            doubleSpring.b2 = double.Parse(textBoxb2.Text);

            xPrior1 = double.Parse(textBoxx1.Text);
            vPrior1 = double.Parse(textBoxv1.Text);
            xPrior2 = double.Parse(textBoxx2.Text);
            vPrior2 = double.Parse(textBoxv2.Text);
            tPrior = 0.0;

            xNext1 = xPrior1;
            vNext1 = vPrior1;
            xNext2 = xPrior2;
            vNext2 = vPrior2;
            tNext = tPrior;

            //X.Add(xPrior);
            //V.Add(vPrior);
            //ElapsedTime.Add(tPrior);

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, xNext1, vNext1, xNext2, vNext2, tNext),
                ValueString(comboBoxY.Text, xNext1, vNext1, xNext2, vNext2, tNext));
            pictureBoxCurve.Invalidate();
        }// End ResetData

        private double ValueString(string st, double x1, double v1, double x2, double v2, double t)
        {
            switch (st)
            {
                case "Distance1":
                    return x1;
                case "Speed1":
                    return v1;
                case "Distance2":
                    return x2;
                case "Speed2":
                    return v2;
                case "Total Kinetic Energy":
                    return doubleSpring.TotalKineticEnergy(v1, v2);
                case "Total Potential Energy":
                    return doubleSpring.TotalPotentialEnergy(x1, x2);
                case "Total Mechanic Energy":
                    return doubleSpring.TotalMechanicEnergy(x1, v1, x2, v2);
                case "Acceleration1":
                    return doubleSpring.Acceleration1(x1, x2, v1);
                case "Acceleration2":
                    return doubleSpring.Acceleration2(x1, x2, v2);
                case "Elapsed Time":
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
                doubleSpring.NextVar(h, xPrior1, vPrior1, out xNext1, out vNext1,
                    xPrior2, vPrior2, out xNext2, out vNext2);
                
                if (i < n)
                {
                    xPrior1 = xNext1;
                    vPrior1 = vNext1;
                    xPrior2 = xNext2;
                    vPrior2 = vNext2;
                }
            }
            tNext = n * h + tPrior;

            //X.Add(xNext);
            //V.Add(vNext);
            //ElapsedTime.Add(tNext);

            plotClass.AddNewPoint(
                 ValueString(comboBoxX.Text, xNext1, vNext1, xNext2, vNext2, tNext),
                 ValueString(comboBoxY.Text, xNext1, vNext1, xNext2, vNext2, tNext));
            pictureBoxCurve.Invalidate();

            xPrior1 = xNext1;
            vPrior1 = vNext1;
            xPrior2 = xNext2;
            vPrior2 = vNext2;
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

        private void buttonResetData_Click(object sender, EventArgs e)
        {
            ResetData();
            pictureBoxAnimate.Invalidate();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();

            xPrior1 = xNext1;
            vPrior1 = vNext1;
            xPrior2 = xNext2;
            vPrior2 = vNext2;
            tPrior = tNext;

            plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, xNext1, vNext1, xNext2, vNext2, tNext),
                ValueString(comboBoxY.Text, xNext1, vNext1, xNext2, vNext2, tNext));
            pictureBoxCurve.Invalidate();

            pictureBoxAnimate.Invalidate();
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            ResetData();
            pictureBoxAnimate.Invalidate();
            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
        }

        private void checkBoxAnimate_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
        }

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            plotClass.RepeatDrawingPointsMap();
            pictureBoxAnimate.Invalidate();
            pictureBoxCurve.Invalidate();
        }

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
            pictureBoxAnimate.Invalidate();
        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int sizeSquare = 20;
            int lMases = 10; ;

            // Draw spring1
            Color color = Color.Green;
            if (xPrior1 < doubleSpring.R1)
                color = Color.Red;
            int peak1 = 11;
            
            int l1 = (int)(scaleAnimate * xPrior1) - lMases;
            Point[] pts = new Point[peak1 + 4];

            int temp = -8;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(15 + (2 * i - 3) * (l1 - 10) / (2 * peak1), pictureBoxAnimate.Height / 2 + temp);
                temp = -temp;
            }
            pts[0] = new Point(10, pictureBoxAnimate.Height / 2);
            pts[1] = new Point(15, pictureBoxAnimate.Height / 2);
            pts[pts.Length - 2] = new Point(15 + (l1 - 10), pictureBoxAnimate.Height / 2);
            pts[pts.Length - 1] = new Point(15 + (l1 - 10) + 5, pictureBoxAnimate.Height / 2);

            g.DrawLines(new Pen(color), pts);

            g.FillEllipse(new SolidBrush(Color.DarkBlue), pts[pts.Length-1].X, pictureBoxAnimate.Height / 2 - sizeSquare/2, 
                sizeSquare, sizeSquare);

            //Font font = new System.Drawing.Font("Microsoft Sans Serif", 2*sizeSquare/3, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            //g.DrawString("1", font, new SolidBrush(Color.Blue), pts[pts.Length - 1].X, pictureBoxAnimate.Height / 2 - sizeSquare / 2);


            //
            //  Draw Spring2
            color = Color.Green;
            if (xPrior2 - xPrior1 < doubleSpring.R2)
                color = Color.Red;
            int  peak2 = 11;
            int l2 = (int)(scaleAnimate * (xPrior2 - xPrior1)) - lMases ;
            pts = new Point[peak2 + 4];

            temp = -8;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(25 + l1 + lMases + (2 * i - 3) * (l2 - 20) / (2 * peak2),
                    pictureBoxAnimate.Height / 2 + temp);
                temp = -temp;
            }
            pts[0] = new Point(l1 + lMases + 10 , pictureBoxAnimate.Height / 2);
            pts[1] = new Point(pts[0].X + 15, pictureBoxAnimate.Height / 2);
            pts[pts.Length - 2] = new Point(10+  l1 + lMases  + (l2 - 5), pictureBoxAnimate.Height / 2);
            pts[pts.Length - 1] = new Point(pts[pts.Length - 2].X + 5, pictureBoxAnimate.Height / 2);

            g.DrawLines(new Pen(color), pts);

            g.FillRectangle(new SolidBrush(Color.DarkBlue), pts[pts.Length - 1].X, 
                pictureBoxAnimate.Height / 2 - sizeSquare/2 , sizeSquare, sizeSquare);
            //g.DrawString("2", font, new SolidBrush(Color.Blue), pts[pts.Length - 1].X, pictureBoxAnimate.Height / 2 - sizeSquare / 2);
            //
            //


            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 10, pictureBoxAnimate.Height);
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

        private void pictureBoxCurve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxCurve.Height);
            g.ScaleTransform(1, -1);

            g.DrawImage(plotClass.map, 0, 0);
            Rectangle rectPtHead = new Rectangle(plotClass.ptHead - new Size(3, 3), new Size(6, 6));
            g.DrawRectangle(new Pen(Color.Black), rectPtHead);
        }

        private void FormDoubleSprings_FormClosing(object sender, FormClosingEventArgs e)
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
      
        //----------------------------------
        //----------------------------------------------------------------
    }// End Class FormDoubleSprings

    //**************************************************
    public class DoubleSprings
    {
        // k = spring constant, b = damping constant, R = rest lenght of spring, m = mass of Block
        public double k1, R1, m1, b1, k2, R2, m2, b2;
        public DoubleSprings()
        {
        }
        public DoubleSprings(double k1, double R1, double m1, double b1, double k2, double R2, double m2, double b2)
        {
            this.k1 = k1;            
            this.R1 = R1;
            this.m1 = m1;
            this.b1 = b1;

            this.k2 = k2;
            this.R2 = R2;
            this.m2 = m2;
            this.b2 = b2;
        }
        private double F1(double x1, double x2, double v1)
        {
            return -(x1 - R1) * k1 / m1 + (x2 - x1 - R2) * k2 / m1 - v1 * b1 / m1;
        }
        private double F2(double x1, double x2, double v2)
        {
            return -(x2 - x1 - R2) * k2 / m2 - v2 * b2 / m2;
        }
        public void NextVar(double h, double xPrior1, double vPrior1, out double xNext1, out double vNext1,
            double xPrior2, double vPrior2, out double xNext2, out double vNext2)
        {
            // h = deltat
            double Ax1, Bx1, Cx1, Dx1, Av1, Bv1, Cv1, Dv1; // Runge Kutta method 
            double Ax2, Bx2, Cx2, Dx2, Av2, Bv2, Cv2, Dv2; // Runge Kutta method
            Ax1 = vPrior1;
            Av1 = F1(xPrior1, xPrior2, vPrior1);
            Ax2 = vPrior2;
            Av2 = F2(xPrior1, xPrior2, vPrior2);

            Bx1 = vPrior1 + Av1 * h / 2;
            Bv1 = F1(xPrior1 + Ax1 * h / 2, xPrior2 + Ax2 * h / 2, vPrior1 + Av1 * h / 2);
            Bx2 = vPrior2 + Av2 * h / 2;
            Bv2 = F2(xPrior1 + Ax1 * h / 2, xPrior2 + Ax2 * h / 2, vPrior2 + Av2 * h / 2);

            Cx1 = vPrior1 + Bv1 * h / 2;
            Cv1 = F1(xPrior1 + Bx1 * h / 2, xPrior2 + Bx2 * h / 2, vPrior1 + Bv1 * h / 2);
            Cx2 = vPrior2 + Bv2 * h / 2;
            Cv2 = F2(xPrior1 + Bx1 * h / 2, xPrior2 + Bx2 * h / 2, vPrior2 + Bv2 * h / 2);

            Dx1 = vPrior1 + Cv1 * h;
            Dv1 = F1(xPrior1 + Cx1 * h, xPrior2 + Cx2 * h, vPrior1 + Cv1 * h);
            Dx2 = vPrior2 + Cv2 * h;
            Dv2 = F2(xPrior1 + Cx1 * h, xPrior2 + Cx2 * h, vPrior2 + Cv2 * h);

            xNext1 = xPrior1 + (Ax1 + 2 * Bx1 + 2 * Cx1 + Dx1) * h / 6;
            vNext1 = vPrior1 + (Av1 + 2 * Bv1 + 2 * Cv1 + Dv1) * h / 6;
            xNext2 = xPrior2 + (Ax2 + 2 * Bx2 + 2 * Cx2 + Dx2) * h / 6;
            vNext2 = vPrior2 + (Av2 + 2 * Bv2 + 2 * Cv2 + Dv2) * h / 6;

        }
        public double KineticEnergy1(double v1)
        {
            return v1 * v1 * m1 / 2.0;
        }
        public double KineticEnergy2(double v2)
        {
            return v2 * v2 * m2 / 2.0;

        }


        public double PotentialEnergy1(double x1, double x2)
        {
            return (x1 - R1) * (x1 - R1) * k1 / 2.0  + (x2 - x1 - R2) * (x2 - x1 - R2) * k2 / 2.0;
        }
        public double PotentialEnergy2(double x1, double x2)
        {
            return (x2 - x1 - R2) * (x2 - x1 - R2) * k2 / 2.0;
        }


        public double MechanicEnergy1(double x1, double v1, double x2)
        {
            return PotentialEnergy1(x1, x2) + KineticEnergy1(v1);
        }
        public double MechanicEnergy2(double x1, double x2, double v2)
        {
            return PotentialEnergy2(x1, x2) + KineticEnergy2(v2);
        }


        public double Acceleration1(double x1, double x2, double v1)
        {
            return F1(x1, x2, v1);
        }

        public double Acceleration2(double x1, double x2, double v2)
        {
            return F2(x1, x2, v2);
        }


        public double TotalKineticEnergy(double v1, double v2)
        {
            return KineticEnergy1(v1) + KineticEnergy2(v2);
        }

        public double TotalPotentialEnergy(double x1, double x2)
        {
            return PotentialEnergy1(x1, x2);
        }

        public double TotalMechanicEnergy(double x1, double v1, double x2, double v2)
        {
            return TotalKineticEnergy(v1, v2) + TotalPotentialEnergy(x1, x2);
        }


    }// End Class DoubleSprings

}