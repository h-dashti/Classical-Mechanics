using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormOrientedRectangles : Form
    {
        //------------------------------------ variables
        private double scaleAnimate = 20;
        //private Bitmap[] bitMaps;
        private OrientedRects myBodies;
        private int numBody;
        private int numSteps;
        private double dt;
        
        //-------------------------------------
        public FormOrientedRectangles()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
            Initialize();
            pictureBoxAnimate.Paint += new PaintEventHandler(pictureBoxAnimate_Paint);
        }

        

        private void Initialize()
        {
            timer1.Interval = 10;
            dt = 0.0005;
            numSteps = 100;


            Color color = Color.Blue;
            Vector2D v = new Vector2D(1, 2);
            Vector2D r = new Vector2D(20, 10);
            double theta = 0;
            double omega = 1;
            double g = 0;
            numBody = 1;
            OrientedRect body1 = new OrientedRect(color, v, r, omega, theta, 1, 0, 1);
            RectangleD rectBox = new RectangleD(0, 0, pictureBoxAnimate.Width / scaleAnimate, pictureBoxAnimate.Height / scaleAnimate);
            myBodies = new OrientedRects(1, g, rectBox, new OrientedRect[1] { body1 });

        }
        //private void InitializeBitMaps()
        //{
        //    bitMaps = new Bitmap[1];

        //    int width = (int)(myBodies.bodies[0].width * scaleAnimate);
        //    int height = (int)(myBodies.bodies[0].height * scaleAnimate);
        //    bitMaps[0] = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bitMaps[0]);
        //    g.Clear(myBodies.bodies[0].color);
        //}


        void pictureBoxAnimate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxAnimate.Height);
            g.ScaleTransform(1, -1);
            System.Drawing.Drawing2D.GraphicsState gState = g.Save();


            Point[] ptsBody = new Point[4];
            for (int j = 0; j < 4; j++)
            {
                ptsBody[j] = new Point();
                ptsBody[j].X = (int)(myBodies.bodies[0].vertexes[j].X * scaleAnimate);
                ptsBody[j].Y = (int)(myBodies.bodies[0].vertexes[j].Y * scaleAnimate);
            }

            g.FillPolygon(new SolidBrush(myBodies.bodies[0].color), ptsBody);
            Point ptA = new Point();
            ptA.X = (int)(myBodies.bodies[0].rA.X * scaleAnimate);
            ptA.Y = (int)(myBodies.bodies[0].rA.Y * scaleAnimate);
            g.FillRectangle(new SolidBrush(myBodies.bodies[0].colorA), ptA.X - 1.5F, ptA.Y - 1.5F, 3, 3); 



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
            for (int i = 0; i < numSteps; i++)
                myBodies.Update(dt);

            pictureBoxAnimate.Invalidate();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = true;
            buttonStop.Enabled = false;

            timer1.Stop();
            timer1.Tick -= new EventHandler(timer1_Tick);


        }

        private void FormOrientedRectangles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
            }
        }
    }// End FormOrientedRectangles
}