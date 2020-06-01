using System;

//  for collision
namespace MechanicalSimulations
{
    public class Polygon
    {
        //------------------------- Variables
        public Vector2D[] pArr;// the vertexes of wall
        public Oriention orient;
        
        //-----------------
        public Polygon()
        {
        }
        public Polygon(Vector2D[] pArr, Oriention orient)
        {
            this.pArr = (Vector2D[])pArr.Clone();
            this.orient = orient;            
        }
        public Polygon(Vector2D[] pArr)
        {
            this.pArr = (Vector2D[])pArr.Clone();
            this.orient = GetOriention(pArr);
            
        }

        public static Oriention GetOriention(Vector2D[] points)
        {
            if (points.Length < 3)
                return Oriention.None;

            int count = 0;
            for (int  i = 0; i < points.Length; i++)
            {
                int j = (i + 1) % points.Length;
                int k = (i + 2) % points.Length;
                double s = (points[j].X - points[i].X) * (points[k].Y - points[j].Y);
                s -= (points[j].Y - points[i].Y) * (points[k].X - points[j].X);
                if (s < 0)
                    count--;
                else if (s > 0)
                    count++;
            }

            if (count > 0)
                return Oriention.CounterClockWise;
            else if (count < 0)
                return Oriention.ClockWise;
            else
                return Oriention.None;

        }
        public static void FindMinMax(double[] array, out double min, out double max)
        {
            min = array[0];
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
                if (array[i] > max)
                    max = array[i];
            }
        }
        public Vector2D Normal(int iLine)
        {
            if (iLine > pArr.Length - 1 || iLine < 0)
                return new Vector2D(0, 0);

            int j = (iLine + 1) % pArr.Length;// j = i+1;
            double dx = pArr[j].X - pArr[iLine].X;
            double dy = pArr[j].Y - pArr[iLine].Y;
            double dr = Math.Sqrt(dx * dx + dy * dy);

            if (this.orient == Oriention.ClockWise)
                return (new Vector2D(-dy, dx)) / dr;
            else if (this.orient == Oriention.CounterClockWise)
                return (new Vector2D(dy, -dx)) / dr;
            else
                return new Vector2D(0, 0);
            

        }

        public int Contain(Vector2D p)
        {
            int  c = 0;  // c = 0 : not contain.  c = 1 : contain.   

            for (int i = 0, j = pArr.Length - 1; i < pArr.Length; j = i++)
            {
                // part finding if point is lying along a side
                if (p.Equal(pArr[i]) || p.Equal(pArr[j]))
                    return 1;
                if (pArr[i].Y == pArr[j].Y && pArr[j].Y == p.Y)
                    if (p.X >= Math.Min(pArr[i].X, pArr[j].X) && p.X <= Math.Max(pArr[i].X, pArr[j].X))
                        return 1;


                //-----------------
                if (((pArr[i].Y <= p.Y && p.Y < pArr[j].Y) || (pArr[j].Y <= p.Y && p.Y < pArr[i].Y)) &&
                    (p.X < (pArr[j].X - pArr[i].X) * (p.Y - pArr[i].Y) / (pArr[j].Y - pArr[i].Y) + pArr[i].X))
                    c = (c == 0) ? 1 : 0;
                
            }
            return c;

        }

        public static int Contain(Vector2D p, Vector2D[] pArr)
        {
            int c = 0;  // c = 0 : not contain.  c = 1 : contain.   

            for (int i = 0, j = pArr.Length - 1; i < pArr.Length; j = i++)
            {
                // part finding if point is lying along a side
                if (p.Equal(pArr[i]) || p.Equal(pArr[j]))
                    return 1;
                if (pArr[i].Y == pArr[j].Y && pArr[j].Y == p.Y)
                    if (p.X >= Math.Min(pArr[i].X, pArr[j].X) && p.X <= Math.Max(pArr[i].X, pArr[j].X))
                        return 1;


                //-----------------
                if (((pArr[i].Y <= p.Y && p.Y < pArr[j].Y) || (pArr[j].Y <= p.Y && p.Y < pArr[i].Y)) &&
                    (p.X < (pArr[j].X - pArr[i].X) * (p.Y - pArr[i].Y) / (pArr[j].Y - pArr[i].Y) + pArr[i].X))
                    c = (c == 0) ? 1 : 0;

            }
            return c;

        }


        public Vector2D CMass()
        {
            Vector2D temp = new Vector2D();
            double p = 0; // circuity
            int lenght = this.pArr.Length;
            for (int i = 0; i < lenght; i++)
            {
                int j = (i + 1) % lenght;
                Vector2D r_cm = (pArr[j] + pArr[i]) / 2;
                double l = Vector2D.Abs(pArr[j] - pArr[i]);
                temp = temp + r_cm * l;
                p += l;
            }
            return temp / p;

        }

    }// End Class Polygon

    //****************************************************************
    public enum Oriention { ClockWise = -1, None = 0, CounterClockWise = 1 }
}
