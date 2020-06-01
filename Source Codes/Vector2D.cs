using System;

namespace MechanicalSimulations
{
    public struct Vector2D
    {
        private double x,y;
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public bool Equal(Vector2D v)
        {
            if (this.x == v.x && this.y == v.y)
                return true;
            else
                return false;
        }

        public Vector2D Rotate(double theta)
        {
            double x = this.x * Math.Cos(theta) - this.y * Math.Sin(theta);
            double y = this.x * Math.Sin(theta) + this.y * Math.Cos(theta);
            return new Vector2D(x, y);

        }
        public Vector2D Uint()
        {
            return this / Vector2D.Abs(this);
        }
        public static double Abs2(Vector2D v)
        {
            return v.X * v.X + v.Y * v.Y;
        }
        public static double Abs(Vector2D v)
        {
            return Math.Sqrt(Abs2(v));
        }
        
        public static Vector2D operator -(Vector2D v1)
        {
            return new Vector2D(-v1.X, -v1.Y);
        }
        public static Vector2D operator +(Vector2D v1)
        {
            return new Vector2D(v1.X, v1.Y);
        }
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static double operator *(Vector2D v1, Vector2D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public static Vector2D operator *(Vector2D v, double d)
        {
            return new Vector2D(v.X * d, v.Y * d);
        }
        public static Vector2D operator *(double d, Vector2D v)
        {
            return new Vector2D(v.X * d, v.Y * d);
        }
        public static Vector2D operator /(Vector2D v, double d)
        {
            return new Vector2D(v.X / d, v.Y / d);
        }

        public static double operator ^(Vector2D v1, Vector2D v2)
        {
            return v1.x * v2.y - v1.y * v2.x;
        }
       
        public static Vector2D[] Add(Vector2D[] a, Vector2D[] b)
        {
            Vector2D[] c = new Vector2D[a.Length];
            for (int i = 0; i < a.Length; i++)
                c[i] = a[i] + b[i];

            return c;
        }

        public static Vector2D[] Sub(Vector2D[] a, Vector2D[] b)
        {
            Vector2D[] c = new Vector2D[a.Length];
            for (int i = 0; i < a.Length; i++)
                c[i] = a[i] - b[i];

            return c;
        }
        public static Vector2D[] Multi(Vector2D[] a, double d)
        {
            Vector2D[] c = new Vector2D[a.Length];
            for (int i = 0; i < a.Length; i++)
                c[i] = a[i] * d;

            return c;
        }

        public static Vector2D[] Div(Vector2D[] a, double d)
        {
            Vector2D[] c = new Vector2D[a.Length];
            for (int i = 0; i < a.Length; i++)
                c[i] = a[i] / d;

            return c;
        }

        public override string ToString()
        {
            return this.x.ToString() + "  " + this.y.ToString();
        }
        

    }
}
