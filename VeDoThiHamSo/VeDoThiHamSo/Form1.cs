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
        private Color currDrawColor;
        private int currPenSize;

        CoordinateAxis ca = new CoordinateAxis();
        double a, b, c, d, e;
        double x;
        Bitmap bmp;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
