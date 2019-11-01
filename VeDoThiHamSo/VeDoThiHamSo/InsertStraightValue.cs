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
    public partial class InsertStraightValue : Form
    {
        public InsertStraightValue()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1.X1 = this.txtX1.Text;
            Form1.Y1 = this.txtY1.Text;
            Form1.X2 = this.txtX2.Text;
            Form1.Y2 = this.txtY2.Text;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtX1_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtX1.Text))
            {
                MessageBox.Show("Giá trị X1 không đúng! Hãy nhập lại!");
                txtX1.Focus();
                txtX1.SelectAll();
            }
        }

        private void txtY1_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtY1.Text))
            {
                MessageBox.Show("Giá trị Y1 không đúng! Hãy nhập lại!");
                txtY1.Focus();
                txtY1.SelectAll();
            }
        }

        private void txtX2_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtX2.Text))
            {
                MessageBox.Show("Giá trị X2 không đúng! Hãy nhập lại!");
                txtX2.Focus();
                txtX2.SelectAll();
            }
        }

        private void txtY2_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtY2.Text))
            {
                MessageBox.Show("Giá trị Y2 không đúng! Hãy nhập lại!");
                txtY2.Focus();
                txtY2.SelectAll();
            }
        }
    }
}
