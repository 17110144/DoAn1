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

    }
}
