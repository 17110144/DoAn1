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
    public partial class InsertCircleValue : Form
    {
        public InsertCircleValue()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1.X = this.txtX.Text;
            Form1.Y = this.txtY.Text;
            Form1.R = this.txtR.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtX_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtX.Text))
            {
                MessageBox.Show("Giá trị X không đúng! Hãy nhập lại!");
                txtX.Focus();
                txtX.SelectAll();
            }
        }

        private void txtY_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtY.Text))
            {
                MessageBox.Show("Giá trị Y không đúng! Hãy nhập lại!");
                txtY.Focus();
                txtY.SelectAll();
            }
        }
        private void txtR_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtR.Text))
            {
                MessageBox.Show("Giá trị R không đúng! Hãy nhập lại!");
                txtR.Focus();
                txtR.SelectAll();
            }
        }

        private void InsertCircleValue_Load(object sender, EventArgs e)
        {
            txtX.Focus();
            txtX.Text = "0";
            txtR.Text = "0";
            txtY.Text = "0";
            txtX.Select();
        }
    }
}
