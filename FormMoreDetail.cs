using System;
using System.Drawing;
using System.Windows.Forms;


namespace MechanicalSimulations
{
    public partial class FormMoreDetail : Form
    {
        private PlotClass plotClass;
        private int numLineX, numLineY;

        public double scaleAnimate;
        public double h, timerInterval;
        public int n;

        private int digitX, digitY;
        private Size margin;
        private bool autoscaleX, autoscaleY;
        private double manual_xmin, manual_xmax, manual_ymin, manual_ymax;

        /*int numlinex, int numliney, string digitLableX, string digitLableY, Size margin,
            bool autoscaleX, bool autoscaleY
         */


        public FormMoreDetail(PlotClass plotClass, double scaleAnimate, double deltat, double timerinteval, int num)
        {
            InitializeComponent();
            //this.numLineX = plotClass.numlinex;
            //this.numLineY = plotClass.numliney;
            //this.digitLableX = plotClass.digitLableX;
            //this.digitLableY = plotClass.digitLableY;
            //this.margin = plotClass.sizeMarginLeft;
            //this.autoscaleX = autoscaleX;
            //this.autoscaleY = autoscaleY;
       
            //this.scaleAnimate = scaleAnimate;
            //this.h = deltat;
            //this.timerInterval = timerinteval;
            //this.n = num;
            this.plotClass = plotClass;

            textBoxnumLinex.Text = plotClass.numlinex.ToString();
            textBoxnumLineY.Text = plotClass.numliney.ToString();
            textBoxdigitAxisX.Text = plotClass.digitLableX.ToString();
            textBoxdigitAxisY.Text = plotClass.digitLableY.ToString();
            textBoxSizeMarginX.Text = plotClass.sizeMarginLeft.Width.ToString();
            textBoxSizeMarginY.Text = plotClass.sizeMarginLeft.Height.ToString();

            checkBoxAutoScaleX.Checked = plotClass.autoScalex;
            checkBoxAutoScaleY.Checked = plotClass.autoScaley;

            textBoxMaxX.Text = plotClass.manual_maxx.ToString();
            textBoxMinX.Text = plotClass.manual_minx.ToString();
            textBoxMaxY.Text = plotClass.manual_maxy.ToString();
            textBoxMinY.Text = plotClass.manual_miny.ToString();

            textBoxscaleAnimate.Text = scaleAnimate.ToString("f1");

            textBoxDeltat.Text = deltat.ToString();
            textBoxTimer.Text = timerinteval.ToString("f3");
            textBoxNum.Text = num.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.errorProviderData.Clear();
            bool allCorrect = true;

            try
            {
                this.numLineX = int.Parse(textBoxnumLinex.Text);
                if (this.numLineX < 0) throw new Exception();
               
            }
            catch
            {
                allCorrect = false;
                errorProviderData.SetError(textBoxnumLinex, "must be positive Integer");
            }

            //--------------
            try
            {
                this.numLineY = int.Parse(textBoxnumLineY.Text);
                if (this.numLineY < 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxnumLineY, "must be positive Integer");
                allCorrect = false;
            }

            //--------------
            try
            {
                this.digitX = int.Parse(textBoxdigitAxisX.Text);
                if (this.digitX < 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxdigitAxisX, "must be positive Integer");
                allCorrect = false;
            }

            //--------------
            try
            {
                this.digitY = int.Parse(textBoxdigitAxisY.Text);
                if (this.digitY < 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxdigitAxisY, "must be positive Integer");
                allCorrect = false;
            }

            //--------------
            try
            {
                this.margin.Width = int.Parse(textBoxSizeMarginX.Text);
                if (this.margin.Width < 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxSizeMarginX, "must be positive Integer");
                allCorrect = false;
            }


            //--------------
            try
            {
                this.margin.Height = int.Parse(textBoxSizeMarginY.Text);
                if (this.margin.Height < 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxSizeMarginY, "must be positive Integer");
                allCorrect = false;
            }


            //------------------
            try { this.autoscaleX = checkBoxAutoScaleX.Checked; }
            catch { allCorrect = false; }
            try { this.autoscaleY = checkBoxAutoScaleY.Checked; }
            catch { allCorrect = false; }

            //---------
            try { this.manual_xmax = double.Parse(textBoxMaxX.Text); }
            catch
            {
                errorProviderData.SetError(textBoxMaxX, "must be value");
                allCorrect = false;
            }
            try 
            { 
                this.manual_xmin = double.Parse(textBoxMinX.Text);
                if (manual_xmax <= manual_xmin) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxMinX, "must be value");
                allCorrect = false;
            }

            try 
            { 
                this.manual_ymax = double.Parse(textBoxMaxY.Text); 

            }
            catch
            {
                errorProviderData.SetError(textBoxMaxY, "must be value");
                allCorrect = false;
            }
            try 
            { 
                this.manual_ymin = double.Parse(textBoxMinY.Text);
                if (manual_ymax <= manual_ymin) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxMinY, "must be value");
                allCorrect = false;
            }

            //---------------------------------
            try
            {
                this.scaleAnimate = double.Parse(textBoxscaleAnimate.Text);
                if (scaleAnimate <= 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxscaleAnimate, "must be positive value");
                allCorrect = false;
            }


            //----------
            try
            {
                this.h = double.Parse(textBoxDeltat.Text);
                if (h <= 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxDeltat, "must be positive value");
                allCorrect = false;
            }

            //-------------------
            try
            {
                this.timerInterval = double.Parse(textBoxTimer.Text);
                if (this.timerInterval < 0.001) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxTimer, "must be value GT than 0.001");
                allCorrect = false;
            }

            //------------
            try
            {
                this.n = int.Parse(textBoxNum.Text);
                if (this.n <= 0) throw new Exception();
            }
            catch
            {
                errorProviderData.SetError(textBoxNum, "must be positive Integer");
                allCorrect = false;
            }


            if (!allCorrect) return;

            this.DialogResult = DialogResult.OK;
            plotClass.numlinex = numLineX;
            plotClass.numliney = numLineY;
            plotClass.digitLableX = digitX;
            plotClass.digitLableY = digitY;
            plotClass.sizeMarginLeft = margin;
            plotClass.autoScalex = autoscaleX;
            plotClass.autoScaley = autoscaleY;
            plotClass.manual_maxx = manual_xmax;
            plotClass.manual_minx = manual_xmin;
            plotClass.manual_maxy = manual_ymax;
            plotClass.manual_miny = manual_ymin;

            plotClass.ResetRectPlotArea();
            plotClass.ChangeAutoScaling(autoscaleX, autoscaleY, true);

            this.Close();

        }

        private void checkBoxAutoScaleX_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoScaleX.Checked)
                groupBoxRangeX.Enabled = false;
            else
                groupBoxRangeX.Enabled = true;
        }

        private void checkBoxAutoScaleY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoScaleY.Checked)
                groupBoxRangeY.Enabled = false;
            else
                groupBoxRangeY.Enabled = true;
        }

      
           

        
    }
}