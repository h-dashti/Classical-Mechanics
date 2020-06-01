using System;
using System.Drawing;

namespace MechanicalSimulations
{
    public class PlotClass
    {
        #region Variables
        public Size sizeMarginLeft = new Size(55, 35);
        public Size sizeMarginRigth = new Size(10, 10);
        private double scalex, scaley;

        private double real_minx, real_maxx, real_miny, real_maxy;

        public double manual_minx = -1, manual_maxx = 1, manual_miny = -1, manual_maxy = 1;
        private Size sizeChartArea;
        public Rectangle rectPlotArea;

        public Point ptHead;
        private Point ptTail;

        private static readonly Color colorBpt = Color.Red;
        private static readonly Pen penMajorAxes = new Pen(Color.Blue);
        private static readonly Pen penMajorLines = new Pen(Color.FromArgb(192, 192, 255));
        private static readonly Brush textBrush = new SolidBrush(Color.Black);
        private static readonly Font font = new System.Drawing.Font("Times New Roman", 7F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        //Microsoft Sans Serif         Times New Roman Courier New
        public bool autoScalex, autoScaley;
        
        private int maxLenArray; 
        private double[] arrx, arry;
        public int l_arr;
        public bool isConnectDots;
      
        public Bitmap map;
        public Color cBackGround;
        
        public int digitLableX = 2, digitLableY = 2;
        public int numlinex = 4, numliney = 4;
        private const int maxLenArray0 = 10000;


        private double x0, y0; //dumy var
        #endregion

        #region Constructors
        public PlotClass(Size sizeChartArea, bool isconnectdots, Color cBackGround,
            int digitLableX, int digitLableY, int numlinex, int numliney, Size sizeMarginLeft)
        {
            this.l_arr = 0;
            this.maxLenArray = maxLenArray0;
            this.arrx = new double[maxLenArray0];
            this.arry = new double[maxLenArray0];

            this.sizeChartArea = sizeChartArea;
            this.isConnectDots = isconnectdots;
            this.cBackGround = cBackGround;
            this.digitLableX = digitLableX;
            this.digitLableY = digitLableY;
            this.numlinex = numlinex;
            this.numliney = numliney;
            this.sizeMarginLeft = sizeMarginLeft;
            this.autoScalex = this.autoScaley = true;
            this.scalex = this.scaley = 1;
            ResetRectPlotArea();


            this.map = new Bitmap(sizeChartArea.Width, sizeChartArea.Height);
            Graphics g = Graphics.FromImage(map);
            g.Clear(cBackGround);
            g.Dispose();
        }
        #endregion

        #region Public Methods
        public void ResetRectPlotArea()
        {
            this.rectPlotArea = new Rectangle(sizeMarginLeft.Width, sizeMarginLeft.Height,
               sizeChartArea.Width - sizeMarginLeft.Width - sizeMarginRigth.Width,
               sizeChartArea.Height - sizeMarginLeft.Height - sizeMarginRigth.Height);
        }

        public void ClearData()
        {
            l_arr = 0;
            this.maxLenArray = maxLenArray0;
            this.arrx = new double[maxLenArray0];
            this.arry = new double[maxLenArray0];

            Graphics g = Graphics.FromImage(map);
            g.Clear(cBackGround);
            DrawStringAndAxes(g);
            g.Dispose();            
            GC.Collect();
        }

       
        public void AddFirstPoint(double x, double y)
        {
            l_arr = 0;
            arrx[0] = x;
            arry[0] = y;
            l_arr++;
            real_minx = real_maxx = x;
            real_miny = real_maxy = y;

            if (autoScalex) { x0 = real_minx; scalex = 0; }
            else { x0 = manual_minx; scalex = (rectPlotArea.Width-1) / (manual_maxx - manual_minx); }

            if (autoScaley) { y0 = real_miny; scaley = 0; }
            else { y0 = manual_miny; scaley = (rectPlotArea.Height-1) / (manual_maxy - manual_miny); }

            RepeatDrawingPointsMap();
        }
        


        public void AddNewPoint(double x, double y)
        {
            if (l_arr >= maxLenArray) IncreaseArrSize();
            arrx[l_arr] = x;
            arry[l_arr] = y;
            l_arr++;
            bool boundXchanged = false, boundYchanged = false;

            if (x > real_maxx)
            {
                real_maxx = x;
                boundXchanged = true;
            }
            else if (x < real_minx)
            {
                real_minx = x;
                boundXchanged = true;
            }

            if (y > real_maxy)
            {
                real_maxy = y;
                boundYchanged = true;
            }
            else if (y < real_miny)
            {
                real_miny = y;
                boundYchanged = true;
            }


            if (!autoScalex && !autoScaley)
            {
                int xInPic = (int)(scalex * (x - manual_minx) + rectPlotArea.X);
                int yInPic = (int)(scaley * (y - manual_miny) + rectPlotArea.Y);
                ptHead = new Point(xInPic, yInPic);
                if (xInPic >= rectPlotArea.X && xInPic <= rectPlotArea.Right &&
                   yInPic >= rectPlotArea.Y && yInPic <= rectPlotArea.Bottom)
                {
                    map.SetPixel(xInPic, yInPic, colorBpt);
                    if (isConnectDots) ConnectPoints(ptTail, ptHead);
                }
                ptTail = ptHead;
                return;
            }


            if (!autoScalex) boundXchanged = false;         //if scale is manual then scale dont change
            if (!autoScaley) boundYchanged = false;

            
            if (boundXchanged || boundYchanged)
            {
               
                if (autoScalex)
                {
                    scalex = (real_maxx == real_minx) ? 0 : (rectPlotArea.Width-1) / (real_maxx - real_minx);
                    x0 = real_minx;
                }
                else x0 = manual_minx;
                
                if (autoScaley)
                {
                    scaley = (real_maxy == real_miny) ? 0 : (rectPlotArea.Height-1) / (real_maxy - real_miny);
                    y0 = real_miny;
                }
                else y0 = manual_miny;
                RepeatDrawingPointsMap();
            }
            else
            {
                int xInPic = (int)(scalex * (x - x0) + rectPlotArea.X);
                int yInPic = (int)(scaley * (y - y0) + rectPlotArea.Y);
                ptHead = new Point(xInPic, yInPic);

                if (xInPic >= rectPlotArea.X && xInPic <= rectPlotArea.Right &&
                   yInPic >= rectPlotArea.Y && yInPic <= rectPlotArea.Bottom)
                {
                    map.SetPixel(xInPic, yInPic, colorBpt);
                    if (isConnectDots) ConnectPoints(ptTail, ptHead);
                }
                ptTail = ptHead;
            }
        }

        public void ChangeAutoScaling(bool autoScalex,  bool autoScaley, bool dowork )
        {
            this.autoScalex = autoScalex;
            this.autoScaley = autoScaley;

            if (!dowork) return;

            if (autoScalex)
            { 
                x0 = real_minx;
                if (real_minx == real_maxx)
                    scalex = 0;
                else
                    scalex = (rectPlotArea.Width-1) / (real_maxx - real_minx); ;
            }
            else { x0 = manual_minx; scalex = (rectPlotArea.Width-1) / (manual_maxx - manual_minx); }

            if (autoScaley)
            {
                y0 = real_miny;
                if (real_miny == real_maxy)
                    scaley = 0;
                else
                    scaley = (rectPlotArea.Height-1) / (real_maxy - real_miny);
            }
            else { y0 = manual_miny; scaley = (rectPlotArea.Height-1) / (manual_maxy - manual_miny); }

            RepeatDrawingPointsMap();

        }
        public void SetMinMaxX(double min, double max)
        {
            this.manual_minx = min;
            this.manual_maxx = max;
            this.autoScalex = false;
            this.scalex = (rectPlotArea.Width-1) / (max - min);
        }
        public void SetMinMaxY(double min, double max)
        {
            this.manual_miny = min;
            this.manual_maxy = max;
            this.autoScaley = false;
            this.scaley = (rectPlotArea.Height-1) / (max - min);
        }
        public void RepeatDrawingPointsMap()
        {
            Graphics g = Graphics.FromImage(map);
            g.Clear(cBackGround);
            DrawStringAndAxes(g);

            for (int i = 0; i < l_arr; i++)
            {
                double x = this.arrx[i];
                double y = this.arry[i];
                int xInPic = (int)(scalex * (x - x0) + rectPlotArea.X);
                int yInPic = (int)(scaley * (y - y0) + rectPlotArea.Y);
                ptHead = new Point(xInPic, yInPic);

                if (xInPic >= rectPlotArea.X && xInPic <= rectPlotArea.Right &&
                    yInPic >= rectPlotArea.Y && yInPic <= rectPlotArea.Bottom)
                {
                    map.SetPixel(xInPic, yInPic, colorBpt);
                    if (isConnectDots && i > 0) ConnectPoints(ptTail, ptHead);
                }
                ptTail = ptHead;
            }// for i

            g.Dispose();
        }
        #endregion

        #region Private Methods
        private void IncreaseArrSize()
        {
            double[] x = (double[])arrx.Clone();
            double[] y = (double[])arry.Clone();

            this.maxLenArray *= 2;
            this.arrx = new double[maxLenArray];
            this.arry = new double[maxLenArray];
            for (int i = 0; i < x.Length; i++)
            {
                arrx[i] = x[i];
                arry[i] = y[i];
            }
            x = null;
            y = null;
            GC.Collect();
        }
            


        private void DrawAxes(Graphics g)
        {
            g.DrawRectangle(penMajorAxes, rectPlotArea);

            int deltax = rectPlotArea.Width / (numlinex + 1);
            int deltay = rectPlotArea.Height / (numliney + 1);
            for (int i = 1; i <= numlinex; i++)
            {
                g.DrawLine(penMajorLines, rectPlotArea.X + deltax * i, rectPlotArea.Y,
                    rectPlotArea.X + deltax * i, rectPlotArea.Bottom);
            }

            // axes y
            for (int i = 1; i <= numliney; i++)
            {
                g.DrawLine(penMajorLines, rectPlotArea.X, rectPlotArea.Y + deltay * i,
                    rectPlotArea.Right, rectPlotArea.Y + deltay * i);
            }

        }// End DrawAxes
        //------------------------------------------
        private void DrawStringX(Graphics g)
        {
            System.Drawing.Drawing2D.GraphicsState gState = g.Save();
            g.ScaleTransform(1, -1);

            float delta = rectPlotArea.Width / (numlinex + 1F);
            for (int i = 0; i <= numlinex; i++)
            {
                if (i % 2 != 0) continue;
                double d = (scalex <= 0) ? real_minx : (delta * i) / scalex + x0;

                string st = d.ToString("f" + digitLableX);
                SizeF sizeFont = g.MeasureString(st, font);

                g.DrawString(st, font, textBrush,
                    rectPlotArea.X + delta * i - sizeFont.Width / 2, -rectPlotArea.Y + 4);
            }
            g.Restore(gState);

        }

        private void DrawStringY(Graphics g)
        {
            System.Drawing.Drawing2D.GraphicsState gState = g.Save();
            g.ScaleTransform(1, -1);

            float delta = rectPlotArea.Height / (numliney + 1F);
            for (int i = 0; i <= numliney; i++)
            {
                if (i % 2 != 0) continue;
                double d = (scaley <= 0) ? real_miny : delta * i / scaley + y0;

                string st = d.ToString("f" + digitLableY);
                SizeF sizeFont = g.MeasureString(st, font);

                //RectangleF rectst = new RectangleF(rectPlotArea.X - sizeMarginLeft.Width + 5, -rectPlotArea.Y - delta * i - font.Size,
                //    sizeMarginLeft.Width - 2, 2 * delta);
                //g.DrawString(st, font, textBrush, rectst);
                if (sizeFont.Width >= sizeMarginLeft.Width-1)
                {
                    st = d.ToString("e0");
                    sizeFont = g.MeasureString(st, font);
                }
                g.DrawString(st, font, textBrush, rectPlotArea.X - sizeFont.Width, -rectPlotArea.Y - delta * i - font.Size);

            }
            g.Restore(gState);
        }
        private void DrawStringAndAxes(Graphics g)
        {
            DrawAxes(g);
            DrawStringX(g);
            DrawStringY(g);            
        }


              
 
        private void ConnectPoints(Point pt1, Point pt2)
        {
            if (pt1 == pt2) return;

            int x = pt1.X;
            int y = pt1.Y;
            int xerr = 0, yerr = 0, incx, incy, distance;

            int dx = pt2.X - pt1.X;
            int dy = pt2.Y - pt1.Y;

            if (dx > 0) incx = 1;
            else if (dx < 0) incx = -1;
            else incx = 0;

            if (dy > 0) incy = 1;
            else if (dy < 0) incy = -1;
            else incy = 0;

            dx = dx > 0 ? dx : -dx;
            dy = dy > 0 ? dy : -dy;

            if (dx > dy) distance = dx;
            else distance = dy;
       
            for (int i = 0; i < distance +1; i++)
            {
                if (x >= rectPlotArea.X && x <= rectPlotArea.Right &&
                    y >= rectPlotArea.Y && y <= rectPlotArea.Bottom)
                    map.SetPixel(x, y, colorBpt);
                xerr += dx;
                yerr += dy;
                if (xerr > distance)
                {
                    xerr -= distance;
                    x += incx;
                }

                if (yerr > distance)
                {
                    yerr -= distance;
                    y += incy;
                }
            }// End for i
      
        }// End ConnectPoints
        #endregion
    }
}
