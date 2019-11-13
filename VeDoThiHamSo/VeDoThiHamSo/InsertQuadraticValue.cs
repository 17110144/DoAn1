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
    public partial class InsertQuadraticValue : Form
    {
        public InsertQuadraticValue()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1.a = Convert.ToDouble(this.txtA.Text);
            Form1.b = Convert.ToDouble(this.txtB.Text);
            Form1.c = Convert.ToDouble(this.txtC.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtA_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtA.Text))
            {
                MessageBox.Show("Giá trị A không đúng! Hãy nhập lại!");
                txtA.Focus();
                txtA.SelectAll();
            }
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtB.Text))
            {
                MessageBox.Show("Giá trị B không đúng! Hãy nhập lại!");
                txtB.Focus();
                txtB.SelectAll();
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtC.Text))
            {
                MessageBox.Show("Giá trị C không đúng! Hãy nhập lại!");
                txtC.Focus();
                txtC.SelectAll();
            }
        }

        private void InsertQuadraticValue_Load(object sender, EventArgs e)
        {
            txtA.Focus();
            txtA.Text = "0";
            txtB.Text = "0";
            txtC.Text = "0";
            txtA.Select();
        }
    }
}
