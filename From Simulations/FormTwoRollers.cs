using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormTwoRollers : Form
    {
        //---------------------------- Variables
        private double x1, y1, s1, v1, x2, y2, s2, v2, t, dt = 0.005;
        private int currenti1,currenti2;

        private Size margin = new Size(55, 35);
        private int n = 5;
        private TwoRollers twoRollers;
        private double scaleAnimate = 50;
       
        private PlotClass plotClass;
        private int transX, transY;
        private bool isCatchBall1, isCatchBall2;
        //Point ptBehind_sp;
        int widthBall = 20;
        Bitmap bitNow;
     
        //------------------------------------------

        public FormTwoRollers()
        {
            InitializeComponent();
            InitializeFirst();
        }
        private void PrintResults()
        {
            string data =
            "x1   = " + x1.ToString() + "\r\n" +
            "y1  = " + y1.ToString() + "\r\n" +
            "v1  = " + v1.ToString() + "\r\n" +
            "s1  = " + s1.ToString() + "\r\n" +
            "Transverse Acc1 =" + "\r\n" +
            twoRollers.F1_By_Currenti1(s1, v1, currenti1, s2, currenti2).ToString() + "\r\n" + "\r\n" +
            "x2   = " + x2.ToString() + "\r\n" +
            "y2  = " + y2.ToString() + "\r\n" +
            "v2  = " + v2.ToString() + "\r\n" +
            "s2  = " + s2.ToString() + "\r\n" +
            "Transverse Acc2 =" + "\r\n" +
            twoRollers.F2_By_Currenti2(s2, v2, currenti2, s1, currenti1).ToString() + "\r\n" + "\r\n" +

            "t     = " + t.ToString() + "\r\n" + "\r\n" +

            "Mechanical Energy  = " + "\r\n" +
            twoRollers.MechanicalEnergy(x1, y1, v1, x2, y2, v2) + "\r\n" + "\r\n"  +
            "F Spring1 =" + "\r\n" +
            twoRollers.F_Spring1(currenti1, currenti2).ToString() + "\r\n";
            labelResult.Text = data;

        }

        private void InitializeFirst()
        {
            
            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;
            
            textBoxv1.Text = "0";
            textBoxm1.Text = "0.5";
            textBoxb1.Text = "0";
            textBoxv2.Text = "0";
            textBoxm2.Text = "0.5";
            textBoxb2.Text = "0";
            textBoxg.Text = "9.8";
            textBoxk.Text = "2";
            textBoxR0.Text = "1";

            timer1.Interval = 10;

            InitializeHump();
            

            ResetData();
           
        }// End Initialize1

        private void InitializeHump()
        {
            scaleAnimate = 60;
            widthBall = 20;
            transY = pictureBoxAnimate.Height;
            transX = pictureBoxAnimate.Width / 2;
            labelShape.Text = "Hump";
            s1 = 30;
            s2 = 36;
           
        }
        private void InitializeInfinity()
        {
            scaleAnimate = 150;
            widthBall = 20;
            transY = pictureBoxAnimate.Height / 2;
            transX = pictureBoxAnimate.Width / 2;
            labelShape.Text = "Infinity";
            s1 = 1;
            s2 = 3;
           
        }
        private void InitializeCardiod()
        {
            scaleAnimate = 100;
            widthBall = 20;
            transY = pictureBoxAnimate.Height / 2 ;
            transX = pictureBoxAnimate.Width / 8;
            labelShape.Text = "Cardiod";
            s1 = 1;
            s2 = 3;
        }

        private void InitializeButterfly()
        {
            widthBall = 14;
            scaleAnimate = 55;
            transY = pictureBoxAnimate.Height / 2;
            transX = pictureBoxAnimate.Width / 2 - 40;
            labelShape.Text = "Butterfly";
            s1 = 2;
            s2 = 4.5;


        }

        private void InitializeOval()
        {
            scaleAnimate = 150;
            widthBall = 20;
            transY =  pictureBoxAnimate.Height / 2 + 10;
            transX = pictureBoxAnimate.Width / 2;
            labelShape.Text = "Oval";
            s1 = 1;
            s2 = 4;

        }
        private void InitializeSpiral()
        {
            scaleAnimate = 30;
            widthBall = 20;
            transY = pictureBoxAnimate.Height / 2 + 60;
            transX = pictureBoxAnimate.Width / 2;
            labelShape.Text = "Spiral";
            s1 = 2.5;
            s2 = 6;

        }

        private void InitializeCircle()
        {
            scaleAnimate = 150;
            widthBall = 20;
            transY = pictureBoxAnimate.Height / 2 + 10;
            transX = pictureBoxAnimate.Width / 2;
            labelShape.Text = "Circle";
            s1 = 1.5;
            s2 = 3;
        }

        // End Initialize Shapes

        private void ResetData()
        {
            if (buttonPlay.Enabled)
                numericUpDownPath.Enabled = true;
            isCatchBall1 = isCatchBall2 = false;
            v1 = double.Parse(textBoxv1.Text);
            v2 = double.Parse(textBoxv2.Text);
                 
            t = 0.0;
            twoRollers = new TwoRollers();
            twoRollers.m1 = double.Parse(textBoxm1.Text);
            twoRollers.b1 = double.Parse(textBoxb1.Text);
            twoRollers.m2 = double.Parse(textBoxm2.Text);
            twoRollers.b2 = double.Parse(textBoxb2.Text);
            twoRollers.g = double.Parse(textBoxg.Text);
            twoRollers.R0 = double.Parse(textBoxR0.Text);
            twoRollers.k = double.Parse(textBoxk.Text);
            switch (labelShape.Text)
            {
                case "Hump" :
                    
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateHumpArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = false;
                    break;
                case "Infinity":
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateInfinteArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    break ;
                case "Cardiod" :
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateCardiodArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    break;
                case "Butterfly" :
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateButterflyArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    break;
                case "Oval":
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateOvalArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;

                case "Spiral":
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateSpiralArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                case "Circle":
                    numericUpDownPath.Value = 0.0001M;
                    twoRollers.CreateCircleArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                default  :
                    break;

            }
            twoRollers.Findxyi(s1, out x1, out y1, out currenti1);
            twoRollers.Findxyi(s2, out x2, out y2, out currenti2);

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);

            plotClass.AddFirstPoint(
                ValueString(comboBoxX.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t),
                ValueString(comboBoxY.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t));
            pictureBoxCurve.Invalidate();

            PrintResults();
            if(buttonPlay.Enabled)
                TurnOnMouseHandles();
            SetBitMaps(pictureBoxAnimate.Width, pictureBoxAnimate.Height, transX, transY, pictureBoxAnimate.BackColor);
            pictureBoxAnimate.Invalidate();

        }// End ResetData
        private double ValueString(string st,
            double s1, double v1, double x1, double y1, int currenti1,
            double s2, double v2, double x2, double y2, int currenti2, double t)
        {
            switch (st)
            {
                case "s1":
                    return s1;
                case "v1":
                    return v1;
                case "x1" :
                    return x1;
                case "y1" :
                    return y1;

                case "At1":
                    return twoRollers.F1_By_Currenti1(s1, v1, currenti1, s2, currenti2);

                case "s2":
                    return s2;
                case "v2":
                    return v2;
                case "x2":
                    return x2;
                case "y2":
                    return y2;

                case "At2":
                    return twoRollers.F2_By_Currenti2(s2, v2, currenti2, s1, currenti1);

                case "F_spring1" :
                    return twoRollers.F_Spring1(currenti1, currenti2);
                
                case "Mechanical E":
                    return twoRollers.MechanicalEnergy(x1, y1, v1, x2, y2, v2);

                case "t":
                    return t;
                default:
                    return 0;

            }// End ValueString
        }


        private void ChangeMainShapes(object sender, EventArgs e)
        {
            if (sender == toolStripButtonInfinity)
            {
                labelShape.Text = "Infinity";
                InitializeInfinity();
            }
            else if (sender == toolStripButtonHump)
            {
                labelShape.Text = "Hump";
                InitializeHump();
            }
            else if (sender == toolStripButtonCardiod)
            {
                labelShape.Text = "Cardiod";
                InitializeCardiod();
            }
            else if (sender == toolStripButtonButterfly)
            {
                labelShape.Text = "Butterfly";
                InitializeButterfly();
            }
            else if (sender == toolStripButtonOval)
            {
                labelShape.Text = "Oval";
                InitializeOval();
            }

            else if (sender == toolStripButtonSpiral)
            {
                labelShape.Text = "Spiral";
                InitializeSpiral();
            }
            else if (sender == toolStripButtonCircle)
            {
                labelShape.Text = "Circle";
                InitializeCircle();
            }



            TurnOffMouseHandles();
            ResetData();
            pictureBoxAnimate.Invalidate();
        }
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
            isCatchBall1 = isCatchBall2 = false;
            pictureBoxAnimate.Invalidate();

        } //pictureBoxAnimate_MouseUp


        private void FindNearest_I_toMouse(Point pt, double s, double ds , ref int currenti)
        {
            int indexUp = twoRollers.GetIndexWithPereviousI(s + ds, currenti);
            int indexDo = twoRollers.GetIndexWithPereviousI(s - ds, currenti);

            double dUp =
                (twoRollers.X[indexUp] * scaleAnimate - pt.X) * (twoRollers.X[indexUp] * scaleAnimate - pt.X) +
                (twoRollers.Y[indexUp] * scaleAnimate - pt.Y) * (twoRollers.Y[indexUp] * scaleAnimate - pt.Y);

            double dDo =
                (twoRollers.X[indexDo] * scaleAnimate - pt.X) * (twoRollers.X[indexDo] * scaleAnimate - pt.X) +
                (twoRollers.Y[indexDo] * scaleAnimate - pt.Y) * (twoRollers.Y[indexDo] * scaleAnimate - pt.Y);

            if (dUp <= dDo)
                currenti = indexUp;
            else
                currenti = indexDo;


        }// End FindNearestItoMouse

        void pictureBoxAnimate_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X - transX, -(e.Y - transY));
            if (isCatchBall1)
            {
                FindNearest_I_toMouse(pt, s1, 0.01, ref currenti1);
                x1 = twoRollers.X[currenti1];
                y1 = twoRollers.Y[currenti1];
                s1 = twoRollers.S[currenti1];

                plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t),
                ValueString(comboBoxY.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
            
            }
            else if (isCatchBall2)
            {
                FindNearest_I_toMouse(pt, s2, 0.01, ref currenti2);
                x2 = twoRollers.X[currenti2];
                y2 = twoRollers.Y[currenti2];
                s2 = twoRollers.S[currenti2];

                plotClass.AddNewPoint(
                ValueString(comboBoxX.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t),
                ValueString(comboBoxY.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
                
            }
            
            
            pictureBoxAnimate.Invalidate();

        } // pictureBoxAnimate_MouseMove

        void pictureBoxAnimate_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X - transX, -(e.Y - transY));
            int x1_cm = (int)(x1 * scaleAnimate);
            int y1_cm = (int)(y1 * scaleAnimate);
            int x2_cm = (int)(x2 * scaleAnimate);
            int y2_cm = (int)(y2 * scaleAnimate);


            if ((x1_cm - pt.X) * (x1_cm - pt.X) +  (y1_cm - pt.Y) * (y1_cm - pt.Y) <= widthBall / 2 * widthBall / 2)  // catchin ball1
            {
                isCatchBall1 = true;
            }
            else if ((x2_cm - pt.X) * (x2_cm - pt.X) +  (y2_cm - pt.Y) * (y2_cm - pt.Y) <= widthBall / 2 * widthBall / 2) // catch ball2
            {
                isCatchBall2 = true;
            }
            pictureBoxAnimate.Invalidate();


        }// pictureBoxAnimate_MouseDown


        private void buttonPlay_Click(object sender, EventArgs e)
        {
            numericUpDownPath.Enabled = false;
            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
            buttonStop.Focus();
            TurnOffMouseHandles();

            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }
        void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= n; i++)
            {
                twoRollers.UpDate(dt,
                    ref s1, ref v1, ref x1, ref y1, ref currenti1, 
                    ref s2, ref v2, ref x2, ref y2, ref currenti2);
            }
            t += n * dt;

            plotClass.AddNewPoint(
                 ValueString(comboBoxX.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t),
                 ValueString(comboBoxY.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t));
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
                 ValueString(comboBoxX.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t),
                 ValueString(comboBoxY.Text, s1, v1, x1, y1, currenti1, s2, v2, x2, y2, currenti2, t));
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
            System.Drawing.Drawing2D.GraphicsState gs = g.Save();
            g.TranslateTransform(0, pictureBoxAnimate.Height);
            g.ScaleTransform(1, -1);
            g.DrawImage(bitNow, 0, 0);

            g.Restore(gs);
            
            //----------------------


            // Drawin mass1
            g.TranslateTransform(transX, transY);
            g.ScaleTransform(1, -1);
            Rectangle rectMass1 = new Rectangle(
                (int)Math.Round(x1 * scaleAnimate) - widthBall/2,
                (int)Math.Round(y1 * scaleAnimate) - widthBall/2, widthBall, widthBall);
            g.FillEllipse(new SolidBrush(Color.DarkBlue), rectMass1);

            // Drawin mass2
            Rectangle rectMass2 = new Rectangle(
                (int)Math.Round(x2 * scaleAnimate) - widthBall / 2,
                (int)Math.Round(y2 * scaleAnimate) - widthBall / 2, widthBall, widthBall);
            g.FillEllipse(new SolidBrush(Color.DarkRed), rectMass2);



            // Drawing Spring
            g.TranslateTransform((int)Math.Round(x2 * scaleAnimate), (int)Math.Round(y2 * scaleAnimate));
            
            double alfa = Math.Atan2(y1 - y2, x1 - x2);
            g.RotateTransform((float)(alfa * 180 / Math.PI));
            Color colorSpring = Color.Green;
            double r = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (r < twoRollers.R0)
                colorSpring = Color.Red;

            int lspring = (int)Math.Round(r * scaleAnimate);
            int peaks = 13;
            int temp = -8;
            Point[] pts = new Point[peaks + 4];
            for (int i = 2; i < pts.Length - 2; i++)
            {
                pts[i] = new Point(5 + (2 * i - 3) * (lspring - 10) / (2 * peaks), temp);
                temp = -temp;
            }
            pts[0] = new Point(0, 0);
            pts[1] = new Point(5, 0);
            pts[pts.Length - 2] = new Point(lspring - 5, 0);
            pts[pts.Length - 1] = new Point(lspring, 0);

            g.DrawLines(new Pen(colorSpring), pts);



        }// End PainAnimate

        private void SetBitMaps(int width, int height, int transx, int transy, Color backColor)
        {
            bitNow = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitNow);
            g.Clear(backColor);

            // Drawing path Curve
            System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();

            int lenghtArr = twoRollers.X.Length;
            int nums = lenghtArr / 1000;
            for (int i = 0; i < twoRollers.S.Length; i++)
            {
                if (i % nums == 0 || nums == 0)
                    gPath.AddLine(
                        (int)Math.Round(scaleAnimate * twoRollers.X[i]) + transx,
                        (int)Math.Round(scaleAnimate * twoRollers.Y[i]) - transy + height,
                        (int)Math.Round(scaleAnimate * twoRollers.X[i]) + transx,
                        (int)Math.Round(scaleAnimate * twoRollers.Y[i]) - transy + height);

            }

            g.DrawPath(new Pen(Color.Black), gPath);
            g.DrawRectangle(new Pen(Color.White, 2),
                (int)Math.Round(scaleAnimate * twoRollers.X[0]) - 1 + transx,
                (int)Math.Round(scaleAnimate * twoRollers.Y[0]) - 1 - transy + height, 2, 2);  // Draw point s=0
            // Draw Arrow

            int locate0 = lenghtArr / 5;
            int locate = locate0;
            for (int i = 1; i <= 4; i++)
            {
                System.Drawing.Drawing2D.GraphicsState gState = g.Save();

                if (locate >= lenghtArr - 2)
                    break;
                int xArrow = (int)Math.Round(scaleAnimate * twoRollers.X[locate]) + transx;
                int yArrow = (int)Math.Round(scaleAnimate * twoRollers.Y[locate]) - transy + height;
                Point[] ptsArrow = new Point[3]{
                new Point(- 8, +4), new Point(0, 0), new Point(-8, -4)};

                float angle = (float)(Math.Atan2(twoRollers.Y[locate + 1] - twoRollers.Y[locate],
                    twoRollers.X[locate + 1] - twoRollers.X[locate]));

                g.TranslateTransform(xArrow, yArrow);
                g.RotateTransform((float)(angle * 180 / Math.PI));
                g.DrawLines(new Pen(Color.Blue, 2), ptsArrow);
                g.Restore(gState);
                locate += locate0;
            }

            //----------------------


        }// End SetBitmap
        //----------------------------------------------------

        private void numericUpDownPath_ValueChanged(object sender, EventArgs e)
        {
            switch (labelShape.Text)
            {
                case "Hump":

                    twoRollers.CreateHumpArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = false;
                    
                    break;
                case "Infinity":

                    twoRollers.CreateInfinteArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                case "Cardiod":

                    twoRollers.CreateCardiodArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                case "Butterfly":

                    twoRollers.CreateButterflyArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                case "Oval":

                    twoRollers.CreateOvalArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;

                case "Spiral":

                    twoRollers.CreateSpiralArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                case "Circle":

                    twoRollers.CreateCircleArrays((double)numericUpDownPath.Value);
                    twoRollers.curveisClosed = true;
                    
                    break;
                default:
                    break;

            }

            twoRollers.Findxyi(s1, out x1, out y1, out currenti1);
            twoRollers.Findxyi(s2, out x2, out y2, out currenti2);
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

        private void FormTwoRollers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
            }
        }

        private void buttonTakeCurvePic_Click(object sender, EventArgs e)
        {
            string dir = this.Text + "(" + labelShape.Text + ")" + " Images";
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
    //****************************************************
    //****************************************************
    public class TwoRollers
    {
        public double[] X, Y, S;
        public double g, b1, m1, b2, m2;
        public double k, R0; // spring parameters
        public bool curveisClosed;

        public TwoRollers()
        {
        }
        public TwoRollers(double m1, double b1, double m2, double b2, double g, bool curveisClosed, double k, double R0)
        {
            this.m1 = m1;
            this.b1 = b1;
            this.m2 = m2;
            this.b2 = b2;
            this.g = g;
            this.curveisClosed = curveisClosed;
            this.k = k;
            this.R0 = R0;
        }



        public  double Finds(double x, double y)
        {
            double dmin;
            int index = 0;
            dmin = (x - X[0]) * (x - X[0]) + (y - Y[0]) * (y - Y[0]);
            for (int i = 1; i < S.Length; i++)
            {
                double d = (x - X[i]) * (x - X[i]) + (y - Y[i]) * (y - Y[i]);
                if(d < dmin)
                {
                    dmin = d;
                    index = i;
                }     
            }
            return S[index];
            
        }// End Finds

        public void Findxyi(double s, out double x, out double y, out int currenti)
        {
            int index = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (s == S[i])
                {
                    index = i;
                    break;
                }
                else if (s > S[i] && s < S[i + 1])
                {
                    if (s - S[i] <= S[i + 1] - s)
                        index = i;
                    else
                        index = i + 1;

                    break;
                }
            }// end for

            x = X[index];
            y = Y[index];
            currenti = index;

        }
        private void Findxy_this(double s, ref double x, ref double y, ref int currenti)
        {
            int index = 0;

            if (s >= S[currenti])
            {
                for (int i = currenti; i < S.Length; i++)
                {
                    if (s == S[i])
                    {
                        index = i;
                        break;
                    }
                    else if (s > S[i] && s < S[i + 1])
                    {
                        if (s - S[i] <= S[i + 1] - s)
                            index = i;
                        else
                            index = i + 1;
                        break;

                    }

                }// end for
            }// End if exist in up

            else
            {
                for (int i = currenti; i >= 0; i--)
                {
                    if (s == S[i])
                    {
                        index = i;
                        break;
                    }
                    else if (s < S[i] && s > S[i -1])
                    {
                        if (s - S[i - 1] <= S[i] - s)
                            index = i - 1;
                        else
                            index = i;

                        break;
                    }

                }// end for
            }//  End if exist in down

            x = X[index];
            y = Y[index];
            currenti = index;
        }
        public int GetIndex(double s)
        {
            if (s >= S[S.Length - 1])
                s -= S[S.Length - 1];  
            else if (s < 0)
                s += S[S.Length - 1];
          


            for (int i = 0; i < S.Length - 1; i++)
            {
                if (s == S[i])
                    return i;
                else if (s > S[i] && s < S[i + 1])
                    return i;
            }
            return S.Length - 2;
        }// End GetIndex
        public int GetIndexWithPereviousI(double s, int beforei)
        {
            if (s >= S[S.Length - 1])
            {
                s -= S[S.Length - 1];
                for (int i = 0; i < S.Length - 1; i++)
                {
                    if (s == S[i])
                        return i;
                    else if (s > S[i] && s < S[i + 1])
                        return i;
                }
            }
            else if (s < 0)
            {
                s += S[S.Length - 1];
                for (int i = S.Length - 1; i >= 0; i--)
                {
                    if (s == S[i])
                        return i;
                    else if (s > S[i - 1] && s < S[i])
                        return i - 1;
                }
            }
           

            if (s >= S[beforei])  // target is up
            {
                for (int i = beforei; i < S.Length - 1; i++)
                {
                    if (s == S[i])
                        return i;
                    else if (s > S[i] && s < S[i + 1])
                        return i;
                }
            } 
            else  // target is down
            {
                for (int i = beforei; i >= 0; i--)
                {
                    if (s == S[i])
                        return i;
                    else if (s > S[i - 1] && s < S[i])
                        return i - 1;
                }
            }

            return S.Length - 2;

        }// End GetIndexWithBeforI

        private double F1(double s1, double v1, int beforei1, double s2, int beforei2)
        {
            int i1 = GetIndexWithPereviousI(s1, beforei1);
            int i2 = GetIndexWithPereviousI(s2, beforei2);
            double dx1 = X[i1 + 1] - X[i1];
            double dy1 = Y[i1 + 1] - Y[i1];
            double dr1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);

            double r12 = Math.Sqrt((X[i1] - X[i2]) * (X[i1] - X[i2]) + (Y[i1] - Y[i2]) * (Y[i1] - Y[i2]));
            double f_Sp;
            if (r12 == 0)
                f_Sp = 0;
            else  // k is constant of Spring
                f_Sp = -k * (r12 - R0) / r12 * ((X[i1] - X[i2]) * dx1 + (Y[i1] - Y[i2]) * dy1) / dr1;

            return -g * dy1 / dr1 - b1 * v1 / m1 + f_Sp / m1;


        }// End F1

        private double F2(double s2, double v2, int beforei2, double s1, int beforei1)
        {
            int i1 = GetIndexWithPereviousI(s1, beforei1);
            int i2 = GetIndexWithPereviousI(s2, beforei2);
            double dx2 = X[i2 + 1] - X[i2];
            double dy2 = Y[i2 + 1] - Y[i2];
            double dr2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            double r21 = Math.Sqrt((X[i2] - X[i1]) * (X[i2] - X[i1]) + (Y[i2] - Y[i1]) * (Y[i2] - Y[i1]));
            double f_Sp;
            if (r21 == 0)
                f_Sp = 0;
            else  // k is constant of Spring
                f_Sp = -k * (r21 - R0) / r21 * ((X[i2] - X[i1]) * dx2 + (Y[i2] - Y[i1]) * dy2) / dr2;

            return -g * dy2 / dr2 - b2 * v2 / m2 + f_Sp / m2;


        }// End F2

        public double F1_By_Currenti1(double s1, double v1, int currenti1, double s2, int currenti2)
        {
            int i1 = currenti1;
            int i2 = currenti2;
            int iup1 = i1 + 1;
            if (iup1 == X.Length )
                iup1 = 1;
            double dx1 = X[iup1] - X[i1];
            double dy1 = Y[iup1] - Y[i1];
            double dr1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);

            double r12 = Math.Sqrt((X[i1] - X[i2]) * (X[i1] - X[i2]) + (Y[i1] - Y[i2]) * (Y[i1] - Y[i2]));
            double f_Sp;
            if (r12 == 0)
                f_Sp = 0;
            else  // k is constant of Spring
                f_Sp = -k * (r12 - R0) / r12 * ((X[i1] - X[i2]) * dx1 + (Y[i1] - Y[i2]) * dy1) / dr1;

            return -g * dy1 / dr1 - b1 * v1 / m1 + f_Sp / m1;

            
        }// End F1_By_Curreni1

        public double F2_By_Currenti2(double s2, double v2, int currenti2, double s1, int currenti1)
        {
            int i1 = currenti1;
            int i2 = currenti2;
            int iup2 = i2 + 1;
            if (iup2 == X.Length)
                iup2 = 1;
            double dx2 = X[iup2] - X[i2];
            double dy2 = Y[iup2] - Y[i2];
            double dr2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            double r21 = Math.Sqrt((X[i2] - X[i1]) * (X[i2] - X[i1]) + (Y[i2] - Y[i1]) * (Y[i2] - Y[i1]));
            double f_Sp;
            if (r21 == 0)
                f_Sp = 0;
            else  // k is constant of Spring
                f_Sp = -k * (r21 - R0) / r21 * ((X[i2] - X[i1]) * dx2 + (Y[i2] - Y[i1]) * dy2) / dr2;

            return -g * dy2 / dr2 - b2 * v2 / m2 + f_Sp / m2;


        }// End F2_By_Curreni2

        public double F_Spring1(int currenti1, int currenti2)
        {
            int i1 = currenti1;
            int i2 = currenti2;
            int iup1 = i1 + 1;
            if (iup1 == X.Length)
                iup1 = 1;
            double dx1 = X[iup1] - X[i1];
            double dy1 = Y[iup1] - Y[i1];
            double dr1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);

            double r12 = Math.Sqrt((X[i1] - X[i2]) * (X[i1] - X[i2]) + (Y[i1] - Y[i2]) * (Y[i1] - Y[i2]));
            double f_Sp;
            if (r12 == 0)
                f_Sp = 0;
            else  // k is constant of Spring
                f_Sp = -k * (r12 - R0) / r12 * ((X[i1] - X[i2]) * dx1 + (Y[i1] - Y[i2]) * dy1) / dr1;

            return f_Sp;
        }


        public void UpDate(double dt, ref double s1, ref double v1, ref double x1, ref double y1, ref int currenti1,
            ref double s2, ref double v2, ref double x2, ref double y2, ref int currenti2)
        {
            double
                As1, Bs1, Cs1, Ds1, Av1, Bv1, Cv1, Dv1,
                As2, Bs2, Cs2, Ds2, Av2, Bv2, Cv2, Dv2;


            As1 = v1 * dt;
            Av1 = F1(s1, v1, currenti1, s2, currenti2) * dt;
            As2 = v2 * dt;
            Av2 = F2(s2, v2, currenti2, s1, currenti1) * dt;

            Bs1 = (v1 + Av1 / 2) * dt;
            Bv1 = F1(s1 + As1 / 2, v1 + Av1 / 2, currenti1, s2 + As2 / 2, currenti2) * dt;
            Bs2 = (v2 + Av2 / 2) * dt;
            Bv2 = F2(s2 + As2 / 2, v2 + Av2 / 2, currenti2, s1 + As1 / 2, currenti1) * dt;

            Cs1 = (v1 + Bv1 / 2) * dt;
            Cv1 = F1(s1 + Bs1 / 2, v1 + Bv1 / 2, currenti1, s2 + Bs2 / 2, currenti2) * dt;
            Cs2 = (v2 + Bv2 / 2) * dt;
            Cv2 = F2(s2 + Bs2 / 2, v2 + Bv2 / 2, currenti2, s1 + Bs1 / 2, currenti1) * dt;

            Ds1 = (v1 + Cv1) * dt;
            Dv1 = F1(s1 + Cs1, v1 + Cv1, currenti1, s2 + Cs2, currenti2) * dt;
            Ds2 = (v2 + Cv2) * dt;
            Dv2 = F2(s2 + Cs2, v2 + Cv2, currenti2, s1 + Cs1, currenti1) * dt;


            s1 += (As1 + 2 * Bs1 + 2 * Cs1 + Ds1) / 6;
            v1 += (Av1 + 2 * Bv1 + 2 * Cv1 + Dv1) / 6;
            s2 += (As2 + 2 * Bs2 + 2 * Cs2 + Ds2) / 6;
            v2 += (Av2 + 2 * Bv2 + 2 * Cv2 + Dv2) / 6;

            if (s1 >= S[S.Length - 1])
                s1 -= S[S.Length - 1];
            else if (s1 < 0)
                s1 += S[S.Length - 1];

            if (s2 >= S[S.Length - 1])
                s2 -= S[S.Length - 1];
            else if (s2 < 0)
                s2 += S[S.Length - 1];

            Findxy_this(s1, ref x1, ref y1, ref currenti1 );
            Findxy_this(s2, ref x2, ref y2, ref currenti2);

        }// End UpDate

        public double MechanicalEnergy(double x1, double y1, double v1, double x2, double y2, double v2)
        {
            double r = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (r == 0)
                return m1 / 2 * v1 * v1 + m1 * g * y1 + m2 / 2 * v2 * v2 + m2 * g * y2;
            else
                return m1 / 2 * v1 * v1 + m1 * g * y1 + m2 / 2 * v2 * v2 + m2 * g * y2 +
                +k / 2 * (r - R0) * (r - R0);
        }


       /* public void CreateHumpArrays(double y, double v, double dt)
        {
            curveisClosed = false;
            double t0 = -2.1;
            double te = 2.1;
            double hmax = (v * v / 2 + g * y) / g;
            while (true)
            {
                double ymax = 3 - 7 * te * te / 6 + Math.Pow(te, 4) / 6;
                if (ymax <= hmax)
                {
                    t0 -= 1;
                    te += 1;
                }
                else
                    break;
            }

            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = t;
                Y[i] = 3 - 7 * t * t / 6 + Math.Pow(t, 4) / 6;

                if (i == 0)
                    S[i] = 0;
                else
                    S[i] = S[i - 1] + Math.Sqrt(9 + 49 * t * t - 28 * Math.Pow(t, 4) + 4 * Math.Pow(t, 6)) * dt / 3; ;
            }

        } // CreateHumpArrays 
        */

        public void CreateHumpArrays(double dt)
        {
            curveisClosed = false;
            double t0 = -4.1;
            double te = 4.1;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = t;
                Y[i] = 3 - 7 * t * t / 6 + Math.Pow(t, 4) / 6;

                if (i == 0)
                    S[i] = 0;
                else
                    S[i] = S[i - 1] + Math.Sqrt(9 + 49 * t * t - 28 * Math.Pow(t, 4) + 4 * Math.Pow(t, 6)) * dt / 3; ;
            }
        } // end CreateHumpArrays


        public void CreateCircleArrays(double dt)
        {
            curveisClosed = true;

            double t0 = 0;
            double te = 2 * Math.PI;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = 1 * Math.Cos(t);
                Y[i] = 1 * Math.Sin(t);

                S[i] = 1 * t;
            }
        } // end CreateCircleArrays


        public void CreateInfinteArrays(double dt)
        {
            curveisClosed = true;

            double t0 = -3;
            double te = 3;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = 1 * Math.Sin(t * Math.PI / 3);
                Y[i] = 1 * Math.Sin(2 * t * Math.PI / 3);

                if (i == 0)
                    S[i] = 0;
                else
                {
                    double u1 = Math.PI / 3 * Math.Cos(t * Math.PI / 3);
                    double u2 = 2 * Math.PI / 3 * Math.Cos(2 * t * Math.PI / 3);
                    S[i] = S[i - 1] + Math.Sqrt(u1 * u1 + u2 * u2) * dt;
                }
            }
        }// End CreateInfiniteArrays

        public void CreateCardiodArrays(double dt)
        {
            curveisClosed = true;

            double t0 = 0;
            double te = 2;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = 1 * Math.Cos(t * Math.PI) * (1 + 2 * Math.Cos(t * Math.PI));
                Y[i] = 0.8 * Math.Sin(t * Math.PI) * (1 + 2 * Math.Cos(t * Math.PI));

                if (i == 0)
                    S[i] = 0;
                else
                {
                    double u1 = -2 * Math.PI * Math.Cos(Math.PI * t) * Math.Sin(Math.PI * t) -
                         1 * Math.PI * (1 + 2 * Math.Cos(Math.PI * t)) * Math.Sin(Math.PI * t);

                    double u2 = -1.6 * Math.PI * Math.Sin(Math.PI * t) * Math.Sin(Math.PI * t) +
                          0.8 * Math.PI * (1 + 2 * Math.Cos(Math.PI * t)) * Math.Cos(Math.PI * t);

                    S[i] = S[i - 1] + Math.Sqrt(u1 * u1 + u2 * u2) * dt;
                }
            }
        }// End CreateCardiod

        public void CreateButterflyArrays(double dt)
        {
            curveisClosed = true;
            double t0 = 0;
            double te = 2 * Math.PI;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = Math.Cos(t) *
                    (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 2), 5));

                Y[i] = Math.Sin(t) *
                    (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 2), 5));
                if (i == 0)
                    S[i] = 0;
                else
                {
                    double u1 =
                        -Math.Sin(t) * (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 2), 5)) +
                        Math.Cos(t) * (-Math.Sin(t) * Math.Exp(Math.Cos(t)) +
                        8 * Math.Sin(4 * t) - 5 * Math.Cos(t / 2) / 2 * Math.Pow(Math.Sin(t / 2), 4));


                    double u2 = Math.Cos(t) * (Math.Exp(Math.Cos(t)) - 2 * Math.Cos(4 * t) - Math.Pow(Math.Sin(t / 2), 5)) +
                        Math.Sin(t) * (-Math.Sin(t) * Math.Exp(Math.Cos(t)) +
                        8 * Math.Sin(4 * t) - 5 * Math.Cos(t / 2) / 2 * Math.Pow(Math.Sin(t / 2), 4));



                    S[i] = S[i - 1] + Math.Sqrt(u1 * u1 + u2 * u2) * dt;
                }
            }
        }// End ButterflyCraetion

        public void CreateOvalArrays(double dt)
        {
            curveisClosed = true;
            double t0 = 0;
            double te = OvalPath.te;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = OvalPath.FindX_Oval(t);
                Y[i] = OvalPath.FindY_Oval(t);
                S[i] = OvalPath.FindS_Oval(t);
            }
        }// End Creation Oval

        public void CreateSpiralArrays(double dt)
        {
            curveisClosed = true;
            double t0 = 0;
            double te = SpiralPath.te;
            int n = (int)((te - t0) / dt);
            X = new double[n];
            Y = new double[n];
            S = new double[n];

            for (int i = 0; i < n; i++)
            {
                double t = i * dt + t0;
                X[i] = SpiralPath.FindX_Spiral(t);
                Y[i] = SpiralPath.FindY_Spiral(t);
                if (i == 0)
                    S[i] = 0;
                else
                {
                    S[i] = SpiralPath.FindS_Spiral(t, S[i - 1], t - dt, dt);
                }
            }
        }// End Creation Spiral
    }//
    //**********************************************
    //********************************************
    

}