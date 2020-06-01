using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormMolecules : Form
    {
        //-----------------------------------variables
        private Vector2D[] r, v;
        private Mass[] masses;
        private Spring[,] springs;
        private double g;
        private int numMolecules = 4;
        TextBox textBoxNum;

        private double dt, t;
        private Molecules molecules;
        private Size margin = new Size(55, 35);
        private int n = 10;
        private double scaleAnimate = 30;
        private PlotClass plotClass;
        private int rBall = 10;

        private int n_catchedBall;
        private Rectangle rectWall;
        private Point ptBenid;

        private double vx = 0, vy = 0, k = 3, R0 = 3, b = 0, m = 0.5;
        //------------------------------ panelMolecule Variables
        Label[] labelsm, labelsvx, labelsvy, labelsb, labelsk, labelsR0;
        TextBox[] textBoxm, textBoxvx, textBoxvy, textBoxb, textBoxk, textBoxR0;
        
        //*************************************************
        

        private void buttonNewMolecules_Click(object sender, EventArgs e)
        {
            panelMolecule.Controls.Clear();

            Label labelNum = new Label();
            labelNum.Text = "Num of Molecules =";
            labelNum.Location = new Point(2, 2);
            labelNum.Size = new Size(panelMolecule.Width - 2, 20);
            labelNum.Parent = panelMolecule;

            textBoxNum = new TextBox();
            textBoxNum.Text = numMolecules.ToString();
            textBoxNum.Location = new Point(labelNum.Location.X, labelNum.Location.Y + labelNum.Height + 2);
            textBoxNum.Size = new Size(35, 20);
            textBoxNum.Parent = panelMolecule;


            Button buttonOk = new Button();
            buttonOk.Text = "Ok";
            buttonOk.Location = new Point(textBoxNum.Location.X + textBoxNum.Size.Width + 2, textBoxNum.Location.Y);
            buttonOk.Size = new Size(40, 20);
            buttonOk.Parent = panelMolecule;

            buttonOk.Click += new EventHandler(buttonOk_Click);

        }

        private void ResetNewMolecules()
        {
            masses = new Mass[numMolecules];
            springs = new Spring[numMolecules, numMolecules];
            v = new Vector2D[numMolecules];
            r = new Vector2D[numMolecules];
            //for (int i = 0; i < numMolecules; i++)
            //    r[i] = new Vector2D(4, i + 1);

            panelMolecule.Controls.Clear();


            labelsm = new Label[numMolecules];
            labelsvx = new Label[numMolecules];
            labelsvy = new Label[numMolecules];
            labelsb = new Label[numMolecules];
            textBoxm = new TextBox[numMolecules];
            textBoxvx = new TextBox[numMolecules];
            textBoxvy = new TextBox[numMolecules];
            textBoxb = new TextBox[numMolecules];

            

            int temp = 4;
            for (int i = 0; i < numMolecules; i++)
            {
                labelsm[i] = new Label();
                labelsm[i].Text = "m" + Convert.ToString(i + 1);
                labelsm[i].Location = new Point(10, temp + 4 * 20 * i);
                labelsm[i].Size = new Size(30, 10);
                labelsm[i].Parent = panelMolecule;

                textBoxm[i] = new TextBox();
                textBoxm[i].Location = new Point(labelsm[i].Location.X + labelsm[i].Size.Width + 2, labelsm[i].Location.Y);
                textBoxm[i].Size = new Size(40, 10);
                textBoxm[i].Parent = panelMolecule;

                labelsvx[i] = new Label();
                labelsvx[i].Text = "vx" + Convert.ToString(i + 1);
                labelsvx[i].Location = new Point(10, temp + 4 * 20 * i + 20);
                labelsvx[i].Size = new Size(30, 10);
                labelsvx[i].Parent = panelMolecule;

                textBoxvx[i] = new TextBox();
                textBoxvx[i].Location = new Point(labelsvx[i].Location.X + labelsvx[i].Size.Width + 2, labelsvx[i].Location.Y);
                textBoxvx[i].Size = new Size(40, 10);
                textBoxvx[i].Parent = panelMolecule;

                labelsvy[i] = new Label();
                labelsvy[i].Text = "vy" + Convert.ToString(i + 1);
                labelsvy[i].Location = new Point(10, temp + 4 * 20 * i + 40);
                labelsvy[i].Size = new Size(30, 13);
                labelsvy[i].Parent = panelMolecule;

                textBoxvy[i] = new TextBox();
                textBoxvy[i].Location = new Point(labelsvy[i].Location.X + labelsvy[i].Size.Width + 2, labelsvy[i].Location.Y);
                textBoxvy[i].Size = new Size(40, 10);
                textBoxvy[i].Parent = panelMolecule;

                labelsb[i] = new Label();
                labelsb[i].Text = "b" + Convert.ToString(i + 1);
                labelsb[i].Location = new Point(10, temp + 4 * 20 * i + 60);
                labelsb[i].Size = new Size(30, 10);
                labelsb[i].Parent = panelMolecule;

                textBoxb[i] = new TextBox();
                textBoxb[i].Location = new Point(labelsb[i].Location.X + labelsb[i].Size.Width + 2, labelsb[i].Location.Y);
                textBoxb[i].Size = new Size(40, 10);
                textBoxb[i].Parent = panelMolecule;


                textBoxvx[i].Text = vx.ToString();
                textBoxvy[i].Text = vy.ToString();
                textBoxb[i].Text = b.ToString();
                textBoxm[i].Text = m.ToString();    

                temp += 4;
            }

            temp = labelsb[labelsb.Length - 1].Location.Y + labelsb[labelsb.Length - 1].Size.Height + 20;
            int iAction = (int)(Fact(numMolecules) / Fact(numMolecules - 2) / 2);
            labelsk = new Label[iAction];
            labelsR0 = new Label[iAction];
            textBoxk = new TextBox[iAction];
            textBoxR0 = new TextBox[iAction];
            int k = 0;
            for (int i = 0; i < numMolecules - 1; i++)
                for (int j = i + 1; j < numMolecules; j++)
                {
                    labelsk[k] = new Label();
                    labelsk[k].Text = "k" + Convert.ToString(i + 1) + Convert.ToString(j + 1);
                    labelsk[k].Location = new Point(10, temp + 2 * 20 * k);
                    labelsk[k].Size = new Size(30, 10);
                    labelsk[k].Parent = panelMolecule;

                    textBoxk[k] = new TextBox();
                    textBoxk[k].Location = new Point(labelsk[k].Location.X + labelsk[k].Size.Width + 2, labelsk[k].Location.Y);
                    textBoxk[k].Size = new Size(40, 10);
                    textBoxk[k].Parent = panelMolecule;

                    labelsR0[k] = new Label();
                    labelsR0[k].Text = "R" + Convert.ToString(i + 1) + Convert.ToString(j + 1);
                    labelsR0[k].Location = new Point(10, temp + 2 * 20 * k + 20);
                    labelsR0[k].Size = new Size(30, 10);
                    labelsR0[k].Parent = panelMolecule;

                    textBoxR0[k] = new TextBox();
                    textBoxR0[k].Location = new Point(labelsR0[k].Location.X + labelsR0[k].Size.Width + 2, labelsR0[k].Location.Y);
                    textBoxR0[k].Size = new Size(40, 10);
                    textBoxR0[k].Parent = panelMolecule;



                    textBoxk[k].Text = this.k.ToString();
                    textBoxR0[k].Text = this.R0.ToString();

                    temp += 4;
                    k++;
                }   
        }
        void buttonOk_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Tick -= new EventHandler(timer1_Tick);
            buttonStop.Enabled = false;
            buttonPlay.Enabled = true;

            numMolecules = int.Parse(textBoxNum.Text);
            ResetNewMolecules();
            DistributeBalls(numMolecules ,r);
            InitilazeComboBoxes();
            ResetData();
            pictureBoxAnimate.Invalidate();       
        }// End ButtonOk_Click

        public static double Fact(int a)
        {
            double fact = 1;
            for (int i = 2; i <= a; i++)
                fact *= i;
            return fact;
        }
        //------------------------------------------------------

     
        public FormMolecules()
        {
            InitializeComponent();
            InitControlsLocation();
            Initialize1();
        }

        private void InitControlsLocation()
        {
            int vertical = DesktopBounds.Height - 50;
            pictureBoxCurve.Size = new Size((DesktopBounds.Width + 200)/2, vertical);
            pictureBoxAnimate.Size = new Size((DesktopBounds.Width - 250) / 2, vertical);
            pictureBoxAnimate.Location = new Point(pictureBoxCurve.Location.X + pictureBoxCurve.Width + 1,
                pictureBoxCurve.Location.Y);
            richTextBox1.Location = new Point(pictureBoxAnimate.Location.X + pictureBoxAnimate.Width + 2,
                pictureBoxCurve.Location.Y);
            richTextBox1.Size = new Size(richTextBox1.Width, pictureBoxAnimate.Height);
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

        private void InitilazeComboBoxes()
        {
            comboBoxX.Items.Clear();
            comboBoxY.Items.Clear();
            for (int i = 0; i < numMolecules; i++)
            {
                comboBoxX.Items.Add("x" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("y" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("vx" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("vy" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("v" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("ax" + Convert.ToString(i + 1));
                comboBoxX.Items.Add("ay" + Convert.ToString(i + 1));

                comboBoxY.Items.Add("x" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("y" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("vx" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("vy" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("v" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("ax" + Convert.ToString(i + 1));
                comboBoxY.Items.Add("ay" + Convert.ToString(i + 1));
            }

            comboBoxX.Items.Add("t");
            comboBoxX.Items.Add("KineticE");
            comboBoxX.Items.Add("PotentialE");
            comboBoxX.Items.Add("MechanicalE");
            comboBoxX.Items.Add("None");

            comboBoxY.Items.Add("t");
            comboBoxY.Items.Add("KineticE");
            comboBoxY.Items.Add("PotentialE");
            comboBoxY.Items.Add("MechanicalE");
            comboBoxY.Items.Add("None");

         // End Initilaize ComboBxes  
        }

        private void PrintResults()
        {
            string data =
                "ME = " + molecules.MechanicE(r, v) + "\r\n" +
                "KE = " + molecules.KienticE(v) + "\r\n" +
                "PE = " + molecules.PotentialE(r) + "\r\n" +
                "t = "  + t.ToString() + "\r\n\r\n";
            string st = "";
            for (int i = 0; i < numMolecules; i++)
            {
                st +=
                    "x" + Convert.ToString(i + 1) + " = " + r[i].X.ToString() + "\r\n" +
                    "y" + Convert.ToString(i + 1) + " = " + r[i].Y.ToString() + "\r\n" +
                    "vx" + Convert.ToString(i + 1) + " = " + v[i].X.ToString() + "\r\n" +
                    "vy" + Convert.ToString(i + 1) + " = " + v[i].Y.ToString() + "\r\n" +
                    "ax" + Convert.ToString(i + 1) + " = " + molecules.Acc(i, r, v).X.ToString() + "\r\n" +
                    "ay" + Convert.ToString(i + 1) + " = " + molecules.Acc(i, r, v).Y.ToString() + "\r\n\r\n";
            }


            data += st;
            richTextBox1.Text = data;
        }
        private void Initialize1()
        {
            
         
            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;

            rectWall = new Rectangle(0, 0, pictureBoxAnimate.Width, pictureBoxAnimate.Height);

            timer1.Interval = 10;
            dt = 0.001;
            n = 10;
            
            textBoxg.Text = "0";
            numMolecules = 5;
            ResetNewMolecules();
            InitilazeComboBoxes();

            DistributeBalls(numMolecules, r);
            //r[0] = new Vector2D(4, 5);
            //r[1] = new Vector2D(7, 5);
            //r[2] = new Vector2D(5.5, 7);
            //r[3] = new Vector2D(5.5, 4);

            
            ResetData();
            TurnOnMouseHandles();
       

        }// End Initilalize1

        private void DistributeBalls(int num, Vector2D[] r)
        {
            double centerx = pictureBoxAnimate.Width / scaleAnimate / 2.0;
            double centery = pictureBoxAnimate.Height / scaleAnimate / 2.0;
            double r_c = 3;

            r[0] = new Vector2D(centerx, centery - r_c);

            double delta = 2 * Math.PI / r.Length;
            for (int i = 1; i < r.Length; i++)
            {
                double alfa = i * delta;
                double x = r_c * Math.Sin(alfa); //r[0].X * Math.Cos(alfa) - r[0].Y * Math.Sin(alfa);
                double y = -r_c * Math.Cos(alfa); //r[0].X * Math.Sin(alfa) + r[0].Y * Math.Cos(alfa);
                r[i] = new Vector2D(x + centerx, y + centery);

            }

            // End DistributeBalls
        }

        private void ResetData()
        {
            n_catchedBall = -1;

            t = 0;
            for (int i = 0; i < numMolecules; i++)
            {
                v[i] = new Vector2D(double.Parse(textBoxvx[i].Text), double.Parse(textBoxvy[i].Text));
                masses[i]= new Mass(double.Parse(textBoxm[i].Text), double.Parse(textBoxb[i].Text));
                springs[i, i] = new Spring(0, 0);
            }
            int k=0;
            for(int i=0; i< numMolecules-1; i++)
                for (int j = i + 1; j < numMolecules; j++)
                {
                    springs[i, j] = new Spring(double.Parse(textBoxk[k].Text), double.Parse(textBoxR0[k].Text));
                    springs[j, i] = new Spring(double.Parse(textBoxk[k].Text), double.Parse(textBoxR0[k].Text));
                    k++;
                }
            g = double.Parse(textBoxg.Text);
            molecules = new Molecules(springs, masses, g, rectWall.Width / scaleAnimate, rectWall.Height / scaleAnimate,
                checkBoxInsideBox.Checked);

            plotClass = new PlotClass(pictureBoxCurve.Size, checkBoxConnectDots.Checked,
                pictureBoxCurve.BackColor, 1, 1, 4, 4, margin);
            plotClass.AddFirstPoint(ValueString(comboBoxX.Text, r, v, t), ValueString(comboBoxY.Text, r, v, t));
            pictureBoxCurve.Invalidate();
   
            PrintResults();
            //if (buttonPlay.Enabled)
             //TurnOnMouseHandles();
            pictureBoxAnimate.Invalidate();

            //PrintResults();


        }// End ResetData
        //------------------------------
        private double ValueString(string st, Vector2D[] r, Vector2D[] v, double t)
        {
            if (st == "t")
                return t;
            else if (st == "KienticE")
                return molecules.KienticE(v);
            else if (st == "PotentialE")
                return molecules.PotentialE(r);
            else if (st == "MechanicalE")
                return molecules.MechanicE(r, v);
            else if (st == "None" || st == "")
                return 0;
            else
            {

                for (int i = 0; i < r.Length; i++)
                    if (st == "x" + Convert.ToString(i + 1))
                        return r[i].X;
                    else if (st == "y" + Convert.ToString(i + 1))
                        return r[i].Y;
                    else if (st == "vx" + Convert.ToString(i + 1))
                        return v[i].X;
                    else if (st == "vy" + Convert.ToString(i + 1))
                        return v[i].Y;
                    else if (st == "v" + Convert.ToString(i + 1))
                        return Math.Sqrt(v[i].X * v[i].X + v[i].Y * v[i].Y);
                    else if (st == "ax" + Convert.ToString(i + 1))
                        return molecules.Acc(i, r, v).X;
                    else if (st == "ay" + Convert.ToString(i + 1))
                        return molecules.Acc(i, r, v).Y;
            }// end else

            return 0;
        }// End Value string

        //----------------------------------------------------------


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
            n_catchedBall = -1;
                      
        }

        private void AfthetContactWall(ref double x, ref double y )
        {
            if (x < 0)
                x = 0;
            else if (x > rectWall.Width / scaleAnimate)
                x = rectWall.Width / scaleAnimate;

            if (y < 0)
                y = 0;
            else if (y > rectWall.Height / scaleAnimate)
                y = rectWall.Height / scaleAnimate;
            
        }
        void pictureBoxAnimate_MouseMove(object sender, MouseEventArgs e)
        {
            if (n_catchedBall > -1)
            {
                int transy = pictureBoxAnimate.Height;
                Point pt = new Point(e.X, -(e.Y - transy));

                double dx = (pt.X - ptBenid.X) / (3.0 * scaleAnimate);
                double dy = (pt.Y - ptBenid.Y) / (3.0 * scaleAnimate);
                double x = r[n_catchedBall].X + dx;
                double y = r[n_catchedBall].Y + dy;
                AfthetContactWall(ref x, ref y);

                r[n_catchedBall] = new Vector2D(x, y);
                plotClass.AddNewPoint(ValueString(comboBoxX.Text, r, v, t), ValueString(comboBoxY.Text, r, v, t));
                pictureBoxCurve.Invalidate();
                PrintResults();
                pictureBoxAnimate.Invalidate();

                ptBenid = pt;
            }
          
        }

        void pictureBoxAnimate_MouseDown(object sender, MouseEventArgs e)
        {
            int transy = pictureBoxAnimate.Height;
             ptBenid = new Point(e.X, -(e.Y - transy));

            for (int i = 0; i < numMolecules; i++)
            {
                int x = (int)(r[i].X * scaleAnimate);
                int y = (int)(r[i].Y * scaleAnimate);
                if ((x - ptBenid.X) * (x - ptBenid.X) + (y - ptBenid.Y) * (y - ptBenid.Y) <= rBall * rBall)
                {
                    n_catchedBall = i;
                    return;
                }

            }
            n_catchedBall = -1;
        }


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
                molecules.UpDate(dt, r, v);
            }
            t += n * dt;

            plotClass.AddNewPoint(ValueString(comboBoxX.Text, r, v, t), ValueString(comboBoxY.Text, r, v, t));
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
            //TurnOffMouseHandles();
            ResetData();
        }

        private void buttonClearGraph_Click(object sender, EventArgs e)
        {
            plotClass.ClearData();
            plotClass.AddNewPoint(ValueString(comboBoxX.Text, r, v, t), ValueString(comboBoxY.Text, r, v, t));
            pictureBoxCurve.Invalidate();

            pictureBoxAnimate.Invalidate();
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
        }

        private void checkBoxConnectDots_CheckedChanged(object sender, EventArgs e)
        {
            plotClass.isConnectDots = checkBoxConnectDots.Checked;
            pictureBoxAnimate.Invalidate();
        }

        private void comboBoxY_TextChanged(object sender, EventArgs e)
        {
            ResetData();
         //PrintResults();

            pictureBoxAnimate.Invalidate();

            labelX.Text = comboBoxX.Text;
            labelY.Text = comboBoxY.Text;

        }

        private void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxAnimate.Height);
            g.ScaleTransform(1, -1);
            
            //
            // draw spring
            int k = 0;
            for(int i=0; i< numMolecules-1; i++)
                for (int j = i + 1; j < numMolecules; j++)
                {
                    System.Drawing.Drawing2D.GraphicsState gs = g.Save();

                    int peaks = 11;
                    int temp = -5;
                    Vector2D dr = r[i] - r[j];
                    int lspring = (int)(Vector2D.Abs(dr) * scaleAnimate);
                    Color colorSp = Color.Green;
                    if (lspring < springs[i, j].R0 * scaleAnimate)
                        colorSp = Color.Red;
                    
                    Point[] pts = new Point[peaks + 4];
                    for (int w = 2; w < pts.Length - 2; w++)
                    {
                        pts[w] = new Point(14 + (2 * w - 3) * (lspring - 2*14) / (2 * peaks), temp);
                        temp = -temp;
                    }
                    pts[0] = new Point(0, 0);
                    pts[1] = new Point(14, 0);
                    pts[pts.Length - 2] = new Point(lspring - 14, 0);
                    pts[pts.Length - 1] = new Point(lspring, 0);



                    double alfa = Math.Atan2(dr.Y, dr.X);
                    g.TranslateTransform((int)(r[j].X * scaleAnimate), (int)(r[j].Y * scaleAnimate));
                    g.RotateTransform((float)(alfa * 180 / Math.PI));
                    g.DrawLines(new Pen(colorSp), pts);

                    g.Restore(gs);
                    k++;
                    //
                }


            // draw masses
            for (int i = 0; i < numMolecules; i++)
            {
                System.Drawing.Drawing2D.GraphicsState gs = g.Save();

                int x = (int)(r[i].X * scaleAnimate);
                int y = (int)(r[i].Y * scaleAnimate);
                Rectangle rectMass = new Rectangle(x - rBall, y - rBall, 2 * rBall, 2 * rBall);
                g.FillEllipse(new SolidBrush(Color.DarkBlue), rectMass);



                // draw string
                g.TranslateTransform(x, y);
                g.ScaleTransform(1, -1);
                Font font = new System.Drawing.Font("Microsoft Sans Serif", 7);
                g.DrawString(Convert.ToString(i + 1), font, new SolidBrush(Color.White), -5, -5);
                g.Restore(gs);
            }


        }// End paint

        //----------------
        private void checkBoxInsideBox_CheckedChanged(object sender, EventArgs e)
        {
            molecules.isConstrained = checkBoxInsideBox.Checked;
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

        private void FormMolecules_FormClosing(object sender, FormClosingEventArgs e)
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
        //----------------------------------------------
    }// End FormMolecules
    //************************************************************************
    //************************************************************************
    public class Molecules
    {
        public Spring[,] springs;
        public Mass[] masses;
        public double g;
        public double wWall, hWall;
        public bool isConstrained;
        public Molecules()
        {
        }
        public Molecules(int numMass)
        {
            masses = new Mass[numMass];
            springs = new Spring[numMass, numMass];
        }
        public Molecules(Spring[,] springs, Mass[] masses, double g, double wWall, double hWall, bool isConstrained)
        {
            this.masses = (Mass[])masses.Clone();
            this.springs = (Spring[,])springs.Clone();
            this.g = g;
            this.hWall = hWall;
            this.wWall = wWall;
            this.isConstrained = isConstrained;
        }


        private void AfthetrBounceWall(ref Vector2D r, ref Vector2D v)
        {
            if (r.X < 0)
            {
                v.X = -v.X;
            }
            else if (r.X > wWall)
            {
                v.X = -v.X;
            }
            if (r.Y < 0)
            {
                v.Y = -v.Y;
            }
            else if (r.Y > hWall)
            {
                v.Y = -v.Y;
            }
        }

        public Vector2D Acc(int itarg, Vector2D[] r, Vector2D[] v)
        {
            Vector2D f_sp = new Vector2D();
            for(int i=0; i< r.Length; i++)
            {
                if (i == itarg)
                    continue;

                Vector2D dr = r[itarg] - r[i];
                double l = Vector2D.Abs(dr);
                f_sp = f_sp - springs[itarg, i].k * (l - springs[itarg, i].R0) * dr / l;

            }

            return (f_sp - masses[itarg].b * v[itarg]) / masses[itarg].m + new Vector2D(0, -g);

        }// End Acc

        public void UpDate(double dt, Vector2D[] r, Vector2D[] v)
        {
            Vector2D[] Ar, Br, Cr, Dr, Av, Bv, Cv, Dv;
            Ar = new Vector2D[r.Length];
            Br = new Vector2D[r.Length];
            Cr = new Vector2D[r.Length];
            Dr = new Vector2D[r.Length];
            Av = new Vector2D[r.Length];
            Bv = new Vector2D[r.Length];
            Cv = new Vector2D[r.Length];
            Dv = new Vector2D[r.Length];

            for (int i = 0; i < r.Length; i++)
            {
                Ar[i] = v[i] * dt;
                Av[i] = Acc(i, r, v) * dt;
            }
            for (int i = 0; i < r.Length; i++)
            {
                Br[i] = (v[i] + Av[i] / 2) * dt;
                Bv[i] = Acc(i, Vector2D.Add(r, Vector2D.Div(Ar, 2)), Vector2D.Add(v, Vector2D.Div(Av, 2))) * dt;
            }
            for (int i = 0; i < r.Length; i++)
            {
                Cr[i] = (v[i] + Bv[i] / 2) * dt;
                Cv[i] = Acc(i, Vector2D.Add(r, Vector2D.Div(Br, 2)), Vector2D.Add(v, Vector2D.Div(Bv, 2))) * dt;
            }

            for (int i = 0; i < r.Length; i++)
            {
                Dr[i] = (v[i] + Cv[i]) * dt;
                Dv[i] = Acc(i, Vector2D.Add(r, Cr), Vector2D.Add(v, Cv)) * dt;
            }


            for (int i = 0; i < r.Length; i++)
            {
                r[i] = r[i] + (Ar[i] + 2 * Br[i] + 2 * Cr[i] + Dr[i]) / 6;
                v[i] = v[i] + (Av[i] + 2 * Bv[i] + 2 * Cv[i] + Dv[i]) / 6;

                if(isConstrained)
                    AfthetrBounceWall(ref r[i], ref v[i]);
            }

        }// End Update

        public double KienticE(Vector2D[] v)
        {
            double kientic = 0;
            for (int i = 0; i < v.Length; i++)
                kientic += masses[i].m / 2 * Vector2D.Abs2(v[i]);
            return kientic;

        }

        public double PotentialE(Vector2D[] r)
        {
            double potential = 0;
            for (int i = 0; i < r.Length-1; i++)
                for (int j = i + 1; j < r.Length; j++)
                {
                    Vector2D dr = r[i] - r[j];
                    double l = Vector2D.Abs(dr);
                    potential += springs[i, j].k / 2 * (l - springs[i, j].R0) * (l - springs[i, j].R0);
                       
                }
            if (g != 0)
                for (int i = 0; i < r.Length; i++)
                    potential += masses[i].m * g * r[i].Y;

            return potential;
        }

        public double MechanicE(Vector2D[] r, Vector2D[] v)
        {
            return KienticE(v) + PotentialE(r);
        }

    }// End FourMolecules
    public class Spring
    {
        public double k, R0;
        public Spring(double k, double R0)
        {
            this.k = k;
            this.R0 = R0;
        }
        public Spring()
        {
        }
        
        
    }// End Springs
    public class Mass
    {
        public double m, b;
        public Mass(double m, double b)
        {
            this.m = m;
            this.b = b;
        }
        public Mass()
        {
        }
    }// End Class Mass

}