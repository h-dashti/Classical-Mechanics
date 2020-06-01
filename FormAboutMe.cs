using System;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalSimulations
{
    public partial class FormAboutMe : Form
    {
        //Bitmap icon =new Bitmap(10,10);
        Icon icon;
       

        public FormAboutMe()
        {
            InitializeComponent();

            try
            {
                //old  version
                //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                //System.IO.Stream stream =
                //   assembly.GetManifestResourceStream("MechanicalSimulations.Planet3D.ico");

                icon = MechanicalSimulations.Properties.Resources.SpringIcon;
            }
            catch
            {
            }
            this.Paint += new PaintEventHandler(FormAboutMe_Paint);
        }

        void FormAboutMe_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = 20; int y = labelAbout.Location.Y;
            if (icon != null)
                g.DrawIcon(icon,new Rectangle( x, y, 2 * icon.Width, 2 * icon.Height));
           /* Font font = new System.Drawing.Font("Edwardian Script ITC", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Point pt = new Point(22, 40);
            string st = "Designed by H.Dashti.";
            g.DrawString(st, font, Brushes.Blue, pt);

            SizeF size = g.MeasureString(st, font);
            pt = new Point(pt.X +50, pt.Y + (int)size.Height+8);
            font = new System.Drawing.Font("Times New Roman", icon.Height, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            st = "(Not yet Physicist)";
            g.DrawString(st , font, Brushes.DarkBlue, pt);
            if (icon != null)
            {
                size = g.MeasureString(st, font);
                g.DrawIcon(icon, pt.X + (int)size.Width - 4, pt.Y + icon.Height / 3);
                //g.DrawString(")", font, Brushes.DarkBlue, pt.X + size.Width + icon.Width-4, pt.Y);
            }*/

            //else
            //{
            //    g.DrawString(")", font, Brushes.DarkBlue, pt.X + size.Width, pt.Y);
            //}
            

        }


        const int dWidth = 25;
        const int dHeigth = 10;

        private void FormAboutMe_FormClosing(object sender, FormClosingEventArgs e)
        {
            int width = ClientSize.Width - dWidth;
            int heigth = ClientSize.Height - dHeigth;
            while (width > dWidth && heigth > dHeigth)
            {
                System.Threading.Thread.Sleep(10);
                ClientSize = new Size(width, heigth);
                width -= dWidth;
                heigth -= dHeigth;
            }
           
        }

    }
}