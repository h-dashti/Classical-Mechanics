using System;

namespace MechanicalSimulations
{
    struct Vector3D
    {
        private double x, y, z;
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
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
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public static bool Equal(Vector3D v1, Vector3D v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
                return true;
            else
                return false;

        }
       
        //public static bool operator ==(Vector3D v1, Vector3D v2)
        //{
        //    return Vector3D.Equal(v1, v2);
        //}
        //public static bool operator !=(Vector3D v1, Vector3D v2)
        //{
        //    return !(Vector3D.Equal(v1, v2));
        //}

        public Vector3D Unit()
        {
            return this / Vector3D.Abs(this);
        }
        public static double Abs_2(Vector3D v)
        {
            return v.x * v.x + v.y * v.y + v.z * v.z;
        }
        public static double Abs(Vector3D v)
        {
            return Math.Sqrt(Abs_2(v));
        }
        public static Vector3D Add(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3D Subtract(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vector3D Multiply(Vector3D v, double d)
        {
            return new Vector3D(v.x * d, v.y * d, v.z * d);
        }
        public static Vector3D Multiply(double d, Vector3D v)
        {
            return new Vector3D(v.x * d, v.y * d, v.z * d);
        }
        public static Vector3D Divide(Vector3D v, double d)
        {
            return new Vector3D(v.x / d, v.y / d, v.z / d);
        }
       
        public static Vector3D CrossProduct(Vector3D v1, Vector3D v2)
        {
            double x = v1.y * v2.z - v1.z * v2.y;
            double y = v1.z * v2.x - v1.x * v2.z;
            double z = v1.x * v2.y - v1.y * v2.x;
            return new Vector3D(x, y, z);
        }
        public static double DotProduct(Vector3D v1, Vector3D v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
        public static Vector3D operator -(Vector3D v)
        {
            return new Vector3D(-v.x, -v.y, -v.z);
        }
        public static Vector3D operator +(Vector3D v)
        {
            return v;
        }
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return Vector3D.Add(v1, v2);
        }
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return Vector3D.Subtract(v1, v2);
        }
        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return Vector3D.DotProduct(v1, v2);
        }

        public static Vector3D operator *(Vector3D v, double d)
        {
            return Vector3D.Multiply(v, d);
        }
        public static Vector3D operator *(double d, Vector3D v)
        {
            return Vector3D.Multiply(d, v);
        }
        public static Vector3D operator /(Vector3D v, double d)
        {
            return Vector3D.Divide(v, d);
        }
        public static Vector3D operator ^(Vector3D v1, Vector3D v2)
        {
            return Vector3D.CrossProduct(v1, v2);
        }

        public static Vector3D[] Add(Vector3D[] arr1, Vector3D[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return null;

            Vector3D[] arr3 = new Vector3D[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                arr3[i] = arr1[i] + arr2[i];
            return arr3;
        }
        public static Vector3D[] Subtract(Vector3D[] arr1, Vector3D[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return null;

            Vector3D[] arr3 = new Vector3D[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                arr3[i] = arr1[i] - arr2[i];
            return arr3;
        }

        public static Vector3D[] Multiply(Vector3D[] arr1, double d)
        {
            Vector3D[] arr2 = new Vector3D[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                arr2[i] = arr1[i] * d;
            return arr2;
        }

        public static Vector3D[] Divide(Vector3D[] arr1, double d)
        {
            Vector3D[] arr2 = new Vector3D[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
                arr2[i] = arr1[i] / d;
            return arr2;
        }


    }// end Struct Vector3D
}
