using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeDoThiHamSo
{
    public partial class Form1 : Form
    {
        CoordinateAxis ca = new CoordinateAxis();
        Funtions F = new Funtions();
        double a, b, c, d;
        double x;
        Color curColor;
        int curPenSize;
        int iFlag;

        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(picMain.Width, picMain.Height);
            ca.g = picMain.CreateGraphics();
            ca.g = Graphics.FromImage(bmp);
            curColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region on/off controler
        private void onA()
        {
            lbA.Enabled = true;
            lbA.Visible = true;
            txtA.Enabled = true;
            txtA.Visible = true;
        }
        private void offA()
        {
            lbA.Enabled = false;
            lbA.Visible = false;
            txtA.Enabled = false;
            txtA.Visible = false;
        }
        private void onB()
        {
            lbB.Enabled = true;
            lbB.Visible = true;
            txtB.Enabled = true;
            txtB.Visible = true;
        }
        private void offB()
        {
            lbB.Enabled = false;
            lbB.Visible = false;
            txtB.Enabled = false;
            txtB.Visible = false;
        }

        private void onC()
        {
            lbC.Enabled = true;
            lbC.Visible = true;
            txtC.Enabled = true;
            txtC.Visible = true;
        }
        private void offC()
        {
            lbC.Enabled = false;
            lbC.Visible = false;
            txtC.Enabled = false;
            txtC.Visible = false;
        }
        private void onD()
        {
            lbD.Enabled = true;
            lbD.Visible = true;
            txtD.Enabled = true;
            txtD.Visible = true;
        }
        private void offD()
        {
            lbD.Enabled = false;
            lbD.Visible = false;
            txtD.Enabled = false;
            txtD.Visible = false;
        }
        private void onAll()
        {
            onA(); onB(); onC(); onD();
        }
        private void offAll()
        {
            offA(); offB(); offC(); offD();
        }
        private void onGBFuntions()
        {
            onAll();
            gbFuntions.Enabled = true;
            gbFuntions.Visible = true;
        }
        private void offGBFuntions()
        {
            offAll();
            gbFuntions.Enabled = false;
            gbFuntions.Visible = false;
        }
        private void onGBStraight()
        {
            gbStraight.Enabled = true;
            gbStraight.Visible = true;
        }
        private void offGBStraight()
        {
            gbStraight.Enabled = false;
            gbStraight.Visible = false;
        }

        private void onGbCircle()
        {
            gbCircle.Enabled = true;
            gbCircle.Visible = true;
        }
        private void offGbCircle()
        {
            gbCircle.Enabled = false;
            gbCircle.Visible = false;
        }
        #endregion


        private void StraightParagraphMTS_Click(object sender, EventArgs e)
        {

        }

        private void QuadraticFunctionMTS_Click(object sender, EventArgs e)
        {

        }

        private void CubicFunctionMTS_Click(object sender, EventArgs e)
        {

        }

        private void YaxbcxdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CircleMTS_Click(object sender, EventArgs e)
        {

        }

        private void ElipMTS_Click(object sender, EventArgs e)
        {

        }

        private void HyperbolMTS_Click(object sender, EventArgs e)
        {

        }

        private void AsinwxMTS_Click(object sender, EventArgs e)
        {

        }

        private void AtanwxMTS_Click(object sender, EventArgs e)
        {

        }

        private void LogaxMTS_Click(object sender, EventArgs e)
        {

        }

        private void ExponentialFunctionMTS_Click(object sender, EventArgs e)
        {

        }
    }
}
