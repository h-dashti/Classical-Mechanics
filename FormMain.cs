using System;
using System.Windows.Forms;


namespace MechanicalSimulations
{
    public partial class FormMain : Form
    {
        const string nameFile_BilliradGameDLL = "BilliradGame.dll";
        const string nameFile_RopeSimDLL = "RopeSimulation__GlUMethod.dll";
        public FormMain()
        {
            InitializeComponent();
            //Vector2D[] v = new Vector2D[4] { 
            //    new Vector2D(-50, 0), new Vector2D(50, 50), new Vector2D(100, 0), new Vector2D(50, -50) };
            //WallPolygonal wall = new WallPolygonal(v);
            ////int c = wall.IsContain(new Vector2D(100, 100));
            //this.Text = wall.orient.ToString();
            //Vector2D a = wall.Normal(0);
            //this.Text = a.ToString();

        }

        private void ToolStripMenuItemSingleSp_Click(object sender, EventArgs e)
        {
            FormSingleSpring formSingleSp = new FormSingleSpring();
            //formSingleSp.Location = new System.Drawing.Point(10, 10);
            formSingleSp.Show();
            
        }

        private void doubleSpringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoubleSprings formDoubleSp = new FormDoubleSprings();
            //formDoubleSp.Location = new System.Drawing.Point(10, 10);
            formDoubleSp.Show();
            
        }

        private void singleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2DSingleSpring form2dsingleSpring = new Form2DSingleSpring();
            form2dsingleSpring.Show();
//            form2dsingleSpring.Location = new System.Drawing.Point(10, 10);
            
        }

        private void doubleSprings2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoubleSpring2D formDoubleSpring2D = new FormDoubleSpring2D();
            //formDoubleSpring2D.Location = new System.Drawing.Point(10, 10);
            formDoubleSpring2D.Show();
            
        }

        private void classicHeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClassicHe formClassicHe = new FormClassicHe();
            //formClassicHe.Location = new System.Drawing.Point(10, 10);
            formClassicHe.Show();
            
        }

        private void chaoticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChaoticPendelum formchaoticPendelum = new FormChaoticPendelum();
            //formchaoticPendelum.Location = new System.Drawing.Point(10, 10);
            formchaoticPendelum.Show();
            

        }

       

        private void doublePendelumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoublePendelum formdoublePendelum = new FormDoublePendelum();
            //formdoublePendelum.Location = new System.Drawing.Point(10, 10);
            formdoublePendelum.Show();
            
          

        }

        private void pendelumAndCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPendelumAndCart formPendelumCart = new FormPendelumAndCart();
            formPendelumCart.Show();
        }

        private void danglingStickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanglingStick formDanglingStick = new FormDanglingStick();
            formDanglingStick.Show();
        }

        private void simpleCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSimpleCollision formSimpleCollision = new FormSimpleCollision();
            formSimpleCollision.Show();
        }

        private void overHeadSpringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTwoSpringsOverHead formTwoSpringsOverHead = new FormTwoSpringsOverHead();
            formTwoSpringsOverHead.Show();
        }

        private void rollerCoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRollerCoaster formRoallerCoaster = new FormRollerCoaster();
            formRoallerCoaster.Show();
        }

        private void roolerSpringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRollerAndSpring formRollerSpring = new FormRollerAndSpring();
            formRollerSpring.Show();
        }

        private void twoRollersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTwoRollers formTwoRollers = new FormTwoRollers();
            formTwoRollers.Show();
        }

        private void MoleculeSpringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMolecules formMolecules = new FormMolecules();
            formMolecules.Show();
        }

       

        private void rectanglesCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrientedRectangles formOrientedRectangles = new FormOrientedRectangles();
            formOrientedRectangles.Show();
        }

        private void meToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void biliardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                BilliradGame.BilliardForm billiardForm = new BilliradGame.BilliardForm();
                billiardForm.Show();
            }
            catch
            {
                MessageBox.Show("There is not file : " + nameFile_BilliradGameDLL, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void ropeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RopeSimulation__GlUMethod.FormRopeSimulation formRopeSimulation =
                   new RopeSimulation__GlUMethod.FormRopeSimulation();
                formRopeSimulation.Show();
            }
            catch
            {
                MessageBox.Show("There is not file : " + nameFile_RopeSimDLL, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutMe formAboutMe = new FormAboutMe();
            formAboutMe.Show();
        }
    }
}