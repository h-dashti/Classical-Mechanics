using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalSimulations
{
    public class OvalPath
    {
        private static double a = 0.5;
        private static double b = 1;
        private static double t1 = Math.PI;
        private static double t2 = t1 + b;
        private static double t3 = t2 + Math.PI;
        private static double t4 = t3 + b;
        public static double te = t4;

        public static double FindX_Oval(double t)
        {
            if (t <= t1)
                return a * Math.Cos(t);
            else if (t <= t2)
                return -a;
            else if (t <= t3)
                return a * Math.Cos(Math.PI + t - t2);
            else if (t <= t4)
                return a;
            else
                return 0;
        }
        public static double FindY_Oval(double t)
        {
            if (t <= t1)
                return b / 2 + a * Math.Sin(t);
            else if (t <= t2)
                return b / 2 - (t - t1);
            else if (t <= t3)
                return -b / 2 + a * Math.Sin(Math.PI + t - t2);
            else if (t <= t4)
                return (t - t3) - b / 2;
            else
                return 0;
        }// FindY_Oval
        public static double FindS_Oval(double t)
        {
            if (t <= t1)
                return a * t;
            else if (t <= t2)
                return a * t1 + (t - t1);
            else if (t <= t3)
                return a * t1 + (t2 - t1) + a * (t - t2);
            else if (t <= t4)
                return a * t1 + (t2 - t1) + a * (t3 - t2) + (t - t3);
            else
                return 0;

        }// FindS_Oval
    }// end Class OvalPath

    public class SpiralPath
    {


        private static double arc1x = -2.50287; // center of upper arc
        private static double arc1y = 5.67378;
        private static double rad = 1; // radius of the arcs
        private static double slo = 4.91318; // t value at inside of spiral
        private static double slox = 0.122489;  // inside point of spiral
        private static double sloy = -0.601809;
        private static double shi = 25.9566; // t value at outside of spiral
        private static double shix = 2.20424;  // outside point of spiral
        private static double shiy = 2.38089;
        private static double arc2y = sloy + rad; // center of lower arc
        private static double arc1rx = arc1x + Math.Cos(Math.PI / 4); // right point of upper arc
        private static double t1 = Math.PI / 2;  // end of upper arc
        private static double t2 = t1 + arc1y - arc2y; // end of left vertical line
        private static double t3 = t2 + Math.PI / 2;  // end of lower arc
        private static double t4 = t3 + slox - arc1x;  // end of horiz line, start of spiral
        private static double t5 = t4 + shi - slo;  // end of spiral
        private static double t6 = t5 + Math.Sqrt(2) * (shix - arc1rx); // end of diagonal line
        private static double t7 = t6 + Math.PI / 4;  // top of upper arc
        public static double te = t7;

        public static double FindX_Spiral(double t)
        {
            if (t < t1)  // upper arc
                return Math.Cos(t + Math.PI / 2) + arc1x;
            else if (t <= t2)  // left vertical line
                return arc1x - rad;
            else if (t <= t3)  // lower arc
                return Math.Cos(t - t2 + Math.PI) + arc1x;
            else if (t <= t4)  // end of horiz line
                return arc1x + (t - t3);
            else if (t <= t5)  // end of spiral
                return ((t - t4 + slo) / 8) * Math.Cos(t - t4 + slo);
            else if (t <= t6)  // end of diagonal line
                return shix - (t - t5) / Math.Sqrt(2);
            else if (t <= t7)
                return arc1x + Math.Cos(Math.PI / 4 + t - t6);
            else
                return 0;

        }
        public static double FindY_Spiral(double t)
        {
            if (t <= t1)  // upper arc
                return Math.Sin(t + Math.PI / 2) + arc1y;
            else if (t <= t2)  // left vertical line
                return arc1y - (t - t1);
            else if (t <= t3)  // lower arc
                return Math.Sin(t - t2 + Math.PI) + arc2y;
            else if (t <= t4)  // end of horiz line
                return sloy;
            else if (t <= t5)  // end of spiral
                return ((t - t4 + slo) / 8) * Math.Sin(t - t4 + slo);
            else if (t <= t6)  // end of diagonal line
                return shiy + (t - t5) / Math.Sqrt(2);
            else if (t <= t7)
                return arc1y + Math.Sin(Math.PI / 4 + t - t6);
            else
                return 0;
        }

        public static double FindS_Spiral(double t, double sPrior, double tPrior, double dt)
        {
            if (t <= t1)  // upper arc
                return sPrior + (t - tPrior);
            else if (t <= t2)  // left vertical line
                return sPrior + (t - tPrior);
            else if (t <= t3)  // lower arc
                return sPrior + (t - tPrior);
            else if (t <= t4)  // end of horiz line
                return sPrior + (t - tPrior);
            else if (t <= t5)  // end of spiral
            {
                int n = (int)Math.Round((t - tPrior) / dt);
                for (int i = 1; i <= n; i++)
                {
                    double tNew = tPrior + i * dt;
                    sPrior += Math.Sqrt(1 + (tNew - t4 + slo) * (tNew - t4 + slo)) / 8 * dt;
                }
                return sPrior;
            }
            else if (t <= t6)  // end of diagonal line
            {

                return sPrior + (t - tPrior);
            }
            else if (t <= t7)
                return sPrior + (t - tPrior);
            else
                return 0;
        }
    }// End Class SpiralPath

}
