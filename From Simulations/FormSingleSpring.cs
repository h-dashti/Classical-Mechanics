using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormSingleSpring : Form
    {
        // static variables
        private double xPrior, vPrior, xNext, vNext, tPrior, tNext, h;
        private SingleSpring singleSp;

        private Size margin = new Size(55, 35);
        private int n = 5;

        double scaleAnimate = 40;

        private PlotClass plotClass;
        

        //--------------------------------
        //------------------------------------------
        public FormSingleSpring()
        {
            InitializeComponent();
            Initialize1();

            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
        }

        private void Initialize1()
        {
            textBoxx0.Text = "5";
            textBoxv0.Text = "0";
            textBoxk.Text = "5";
            textBoxm.Text = "0.5";
            textBoxb.Text = "0.1";
            textBoxR.Text = "2.5";

            timer1.Interval = 10;
            h = 0.005;

            ResetData();
            
        }// End Initialize1

        private void ResetData()
        {
            singleSp = new SingleSpring();
            singleSp.k = double.Parse(textBoxk.Text);
            singleSp.m = double.Parse(textBoxm.Text);
            singleSp.b = double.Parse(textBoxb.Text);
            singleSp.R = double.Parse(textBoxR.Text);
            xPrior = double.Parse(textBoxx0.Text);
            vPrior = double.Parse(textBoxv0.Text);
            tPrior = 0.0;

            xNext = xPrior;
            vNext = vPrior;
            tNext = tPrior;

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(ValueString(comboBoxX.Text, xNext, vNext, tNext),
                ValueString(comboBoxY.Text, xNext, vNext, tNext));
            pictureBoxCurve.Invalidate();
            

        }// End RseetData

        //---------------------------------------------------------------------
        //----------------------------------------------------

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
                singleSp.NextVar(h, xPrior, vPrior, out xNext, out vNext);
                if (i < n)
                {
                    xPrior = xNext;
                    vPrior = vNext;
                }
            }
            tNext = n * h + tPrior;

            //X.Add(xNext);
            //V.Add(vNext);
            //ElapsedTime.Add(tNext);

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, xNext, vNext, tNext),
                ValueString(comboBoxY.Text, xNext, vNext, tNext));

            pictureBoxCurve.Invalidate();

            xPrior = xNext;
            vPrior = vNext;
            tPrior = tNext;

            pictureBoxAnimate.Invalidate();
            
            
        }// End Timer1_Tick
        //----------------------------------
        //----------------------------------------------------------------

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
            ResetData();
            pictureBoxAnimate.Invalidate();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();
            xPrior = xNext;
            vPrior = vNext;
            tPrior = tNext;

            //X.Add(xNext);
            //V.Add(vNext);
            //ElapsedTime.Add(tNext);

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, xNext, vNext, tNext),
                 ValueString(comboBoxY.Text, xNext, vNext, tNext));
            pictureBoxCurve.Invalidate();

            pictureBoxAnimate.Invalidate();
        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Color color = Color.Green;
            if (xPrior < singleSp.R)
                color = Color.Red;

            // Draw spring
            int peak = 21;
            int l = (int)(scaleAnimate * xPrior);
            Point[] pts = new Point[peak + 4];

            int temp = -15;
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(15 + (2 * i - 3) * (l - 10) / (2 * peak), pictureBoxAnimate.Height / 2 + temp);
                temp = -temp;
            }
            pts[0] = new Point(10, pictureBoxAnimate.Height / 2);
            pts[1] = new Point(15, pictureBoxAnimate.Height / 2);
            pts[pts.Length - 2] = new Point(15 + (l - 10), pictureBoxAnimate.Height / 2);
            pts[pts.Length - 1] = new Point(15 + (l - 10) + 5, pictureBoxAnimate.Height / 2);

            g.DrawLines(new Pen(color), pts);

            g.FillRectangle(new SolidBrush(Color.DarkBlue), l + 10, pictureBoxAnimate.Height / 2 - 15, 30, 30);
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 10, pictureBoxAnimate.Height);

        }

        
        //

        private double ValueString(string st, double x, double v, double t)
        {
            switch (st)
            {
                case "Distance":
                    return x;
                case "Speed":
                    return v;
                case "Kinetic Energy":
                    return singleSp.KineticEnergy(v);
                case "Potential Energy":
                    return singleSp.PotentialEnergy(x);
                case "Mechanic Energy":
                    return singleSp.MechanicEnergy(x, v);
                case "Acceleration":
                    return singleSp.Acceleration(x, v);
                case "Elapsed Time":
                    return t;
                default:
                    return 0.0;

            }
        }// End ValueString

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            ResetData();
            pictureBoxAnimate.Invalidate();

            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
        }

        //----------------
        //-------------------------------

       

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
            pictureBoxAnimate.Invalidate();
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

        private void buttonRedrawPoints_Click(object sender, EventArgs e)
        {
            pictureBoxAnimate.Invalidate();
            plotClass.RepeatDrawingPointsMap();
            pictureBoxCurve.Invalidate();
        }

        private void FormSingleSpring_FormClosing(object sender, FormClosingEventArgs e)
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

      
//-------------------------------------------------



    }// End Class FormSingleSpring

    //*********************************************************
    public class SingleSpring
    {
        // k = spring constant, b = damping constant, R = rest lenght of spring, m = mass of Block
        public double k, b, R, m;
        public SingleSpring()
        {
        }
        public SingleSpring(double k, double b, double R, double m)
        {
            this.k = k;
            this.b = b;
            this.R = R;
            this.m = m;
        }
        private double F(double x, double v)
        {
            return -(x - R) * k / m - v * b / m;
        }
        public void NextVar(double h, double xPrior, double vPrior, out double xNext, out double vNext)
        {
            // h = deltat
            double Ax, Bx, Cx, Dx, Av, Bv, Cv, Dv; // Runge Kutta method
            Ax = vPrior;
            Av = F(xPrior, vPrior);

            Bx = vPrior + Av * h / 2;
            Bv = F(xPrior + Ax * h / 2, vPrior + Av * h / 2);

            Cx = vPrior + Bv * h / 2;
            Cv = F(xPrior + Bx * h / 2, vPrior + Bv * h / 2);

            Dx = vPrior + Cv * h;
            Dv = F(xPrior + Cx * h, vPrior + Cv * h);

            xNext = xPrior + (Ax + 2 * Bx + 2 * Cx + Dx) * h / 6;
            vNext = vPrior + (Av + 2 * Bv + 2 * Cv + Dv) * h / 6;

        }
        public double KineticEnergy(double v)
        {
            return v * v * m / 2.0;

        }

        public double PotentialEnergy(double x)
        {
            return (x-R) * (x-R) * k / 2.0;
        }
        public double MechanicEnergy(double x, double v)
        {
            return PotentialEnergy(x) + KineticEnergy(v);
        }
        public double Acceleration(double x, double v)
        {
            return F(x, v);
        }
    }// End Class SingleSpring


    
}// End NameSpace