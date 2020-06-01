using System;
using System.Drawing;

namespace MechanicalSimulations
{
    public class OrientedRect
    {
       //----------------- Fields
        public Color color;
        public double m, I; // mass , I = moment inertia
        public double eWall; // elastistiy with walls
        public Vector2D rA; // the location of an arbitary point
        public double b;// constant of friction
        public Color colorA = Color.Yellow; // color of point A
        public double omega;
        public Vector2D vCM; // cm velocity of body
        public double width, height;
        
        private Vector2D rCM; // cm positon of block
        private double theta;
        public Vector2D[] vertexes;
        
       private double la; // distance between point a and CM
        
        
        
       //-------------------------

        public OrientedRect()
        {
        }

        public OrientedRect(Color color, Vector2D vCM, Vector2D rCM, double omega, double theta, double eWall, double b,
            double m)
        {
            //this.rectBox = rectBox;
            this.color = color;
            this.rCM = rCM;
            this.vCM = vCM;
            this.eWall = eWall;
            this.b = b;
            this.m = m;
            this.theta = theta;
            this.omega = omega;
           
            this.width = 5.5;
            this.height = 1;
            this.I = m * (width * width + height * height) / 12;
            this.la = width / 2 - 0.5;
            vertexes = new Vector2D[4];
            SetVertexes();
             
        }

        public Vector2D GetVertex(int i)
        {
            return vertexes[i];
        }
        public void SetVertexes()
        {
            this.rA = rCM + (new Vector2D(la, 0)).Rotate(this.theta);
            
            vertexes[0] = rCM + (new Vector2D(-width / 2, height / 2)).Rotate(this.theta);
            vertexes[1] = rCM + (new Vector2D(width / 2, height / 2)).Rotate(this.theta);
            vertexes[2] = rCM + (new Vector2D(width / 2, -height / 2)).Rotate(this.theta);
            vertexes[3] = rCM + (new Vector2D(-width / 2, -height / 2)).Rotate(this.theta);
        }

        public Vector2D RCM
        {
            get { return rCM; }
            set
            {
                rCM = value;
                SetVertexes();
            }
        }
  
        public double Theta
        {
            get { return theta; }
            set
            {
                theta = value;
                SetVertexes();
            }
        }

        public int VertexBounced(OrientedRect block)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Polygon.Contain(this.vertexes[i], block.vertexes) == 1)
                    return i;
            }
            return -1; // no bounced
                
        }

        public int VertexBounced(RectangleD rectBox)
        {
            double x0 = rectBox.X;
            double y0 = rectBox.Y;
            double x1 = x0 + rectBox.Width;
            double y1 = y0 + rectBox.Height;
            
            for (int i = 0; i < 4; i++)
            {
                if (this.vertexes[i].X <= Math.Min(x0, x1))
                    return i;
                if (this.vertexes[i].X >= Math.Max(x0, x1))
                    return i;
                if (this.vertexes[i].Y <= Math.Min(y0, y1))
                    return i;
                if (this.vertexes[i].Y >= Math.Max(y0, y1))
                    return i;
            }
            return -1;
        }


    }// End Class OrientedRect

    //********************************************************************
    //********************************************************************
    //********************************************************************
    public class OrientedRects
    {
        public double g, e; // e = elasiticty between bodies, b = friction cons
        public const double epsilon = 0.001;
        public OrientedRect[] bodies;
        public Polygon[] walls;
        public RectangleD rectBox; // the box that contained bodies
        //-------------------------------------------------------------------

        public OrientedRects()
        {
        }
        public OrientedRects(double e, double g, RectangleD rectBox, OrientedRect[] bodies)
        {
            this.e = e;
            this.g = g;
            this.bodies = (OrientedRect[])bodies.Clone();
            this.rectBox = rectBox;
        }

        public OrientedRect GetBody(int i)
        {
            return bodies[i];
        }
        public Polygon GetBlockPoly(int i)
        {
            return walls[i];
        }

        public void Update(double dt)
        {
            RungeKutta4(dt);
        }
        private void RungeKutta4(double dt)
        {
            Vector2D[] Ar, Br, Cr, Dr, Av, Bv, Cv, Dv;
            double[] Atheta, Btheta, Ctheta, Dtheta, Aomega, Bomega, Comega, Domega;
            int n = bodies.Length;
            Ar = new Vector2D[n];
            Br = new Vector2D[n];
            Cr = new Vector2D[n];
            Dr = new Vector2D[n];
            Av = new Vector2D[n];
            Bv = new Vector2D[n];
            Cv = new Vector2D[n];
            Dv = new Vector2D[n];
            Atheta = new double[n];
            Btheta = new double[n];
            Ctheta = new double[n];
            Dtheta = new double[n];
            Aomega = new double[n];
            Bomega = new double[n];
            Comega = new double[n];
            Domega = new double[n];


            for (int i = 0; i < n; i++)
            {
                Ar[i] = bodies[i].vCM * dt;
                Av[i] = Accr(bodies[i].vCM, bodies[i].m, bodies[i].b, g) * dt;
                Atheta[i] = bodies[i].omega * dt;
                Aomega[i] = Accth(bodies[i].omega, bodies[i].I, bodies[i].b) * dt;
            }

            for (int i = 0; i < n; i++)
            {
                Br[i] = (bodies[i].vCM + Av[i] / 2) * dt;
                Bv[i] = Accr(bodies[i].vCM + Av[i] / 2, bodies[i].m, bodies[i].b, g) * dt;
                Btheta[i] = (bodies[i].omega + Aomega[i] / 2) * dt;
                Bomega[i] = Accth(bodies[i].omega + Aomega[i] / 2, bodies[i].I, bodies[i].b) * dt;
            }

            for (int i = 0; i < n; i++)
            {
                Cr[i] = (bodies[i].vCM + Bv[i] / 2) * dt;
                Cv[i] = Accr(bodies[i].vCM + Bv[i] / 2, bodies[i].m, bodies[i].b, g) * dt;
                Ctheta[i] = (bodies[i].omega + Bomega[i] / 2) * dt;
                Comega[i] = Accth(bodies[i].omega + Bomega[i] / 2, bodies[i].I, bodies[i].b) * dt;
            }

            for (int i = 0; i < n; i++)
            {
                Dr[i] = (bodies[i].vCM + Cv[i]) * dt;
                Dv[i] = Accr(bodies[i].vCM + Cv[i], bodies[i].m, bodies[i].b, g) * dt;
                Dtheta[i] = (bodies[i].omega + Comega[i]) * dt;
                Domega[i] = Accth(bodies[i].omega + Comega[i], bodies[i].I, bodies[i].b) * dt;
            }


            for (int i = 0; i < n; i++)
            {
                bodies[i].RCM = bodies[i].RCM + (Ar[i] + 2 * Br[i] + 2 * Cr[i] + Dr[i]) / 6;
                bodies[i].vCM = bodies[i].vCM + (Av[i] + 2 * Bv[i] + 2 * Cv[i] + Dv[i]) / 6;
                bodies[i].Theta = bodies[i].Theta + (Atheta[i] + 2 * Btheta[i] + 2 * Ctheta[i] + Dtheta[i]) / 6;
                bodies[i].omega = bodies[i].omega + (Aomega[i] + 2 * Bomega[i] + 2 * Comega[i] + Domega[i]) / 6;

                CheckContactWall(i);
            }



        }


        private void CheckContactWall(int i)
        {
            double x0 = rectBox.X;
            double y0 = rectBox.Y;
            double x1 = x0 + rectBox.Width;
            double y1 = y0 + rectBox.Height;

            Vector2D normal = new Vector2D();
            bool isContacted = false;
            for (int j = 0; j < 4; j++)
            {
                if (bodies[i].vertexes[j].X <= x0)
                {
                    isContacted = true;
                    normal = new Vector2D(1, 0);

                }
                else if (bodies[i].vertexes[j].X >= x1)
                {
                    isContacted = true;
                    normal = new Vector2D(-1, 0);

                }
                else if (bodies[i].vertexes[j].Y <= y0)
                {
                    isContacted = true;
                    normal = new Vector2D(0, 1);

                }
                else if (bodies[i].vertexes[j].Y >= y1)
                {
                    isContacted = true;
                    normal = new Vector2D(0, -1);

                }

                if (isContacted)
                {
                    Vector2D rpCM = bodies[i].vertexes[j] - bodies[i].RCM; // the contact point relative cm
                    Vector2D vp = bodies[i].vCM + (new Vector2D(-rpCM.Y, rpCM.X)) * bodies[i].omega;
                    double d = rpCM ^ normal;

                    double J = -(1 + bodies[i].eWall) * (vp * normal) / (1 / bodies[i].m + d * d / bodies[i].I);

                    bodies[i].vCM = bodies[i].vCM + J * normal / bodies[i].m;
                    bodies[i].omega = bodies[i].omega + (rpCM ^ normal) * J / bodies[i].I;

                    break;
                }

            }// End for j
            
        }

        private void CheckContactOther(int i, int j)
        {
            int iEdge, iSide;
            bool isContacted = false;
            if(bodies[i].VertexBounced(bodies[j]) == 1)
            {
                iEdge = i;
                iSide = j;
                isContacted = true;
            }
            else if (bodies[j].VertexBounced(bodies[i]) == 1)
            {
                iEdge = j;
                iSide = i;
                isContacted = true;
            }
        }

        public static Vector2D Accr(Vector2D v, double m, double b, double g)
        {
            return -b * v / m + new Vector2D(0, -g);

        }
        public static double Accth(double omega, double I, double b)
        {
            return -b * omega / I;
        }


    }// End OrientedRectangles
    
}
