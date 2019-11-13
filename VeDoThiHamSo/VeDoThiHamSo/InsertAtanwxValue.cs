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
    public partial class InsertAtanwxValue : Form
    {
        public InsertAtanwxValue()
        {
            InitializeComponent();
        }
        private void InsertAtanwxValue_Load(object sender, EventArgs e)
        {
            txtA.Focus();
            txtA.Text = "0";
            txtW.Text = "0";
            txtA.Select();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1.a = Convert.ToDouble(this.txtA.Text);
            Form1.b = Convert.ToDouble(this.txtW.Text);
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

        private void txtW_Leave(object sender, EventArgs e)
        {
            if (!Form1.IsNumber(txtW.Text))
            {
                MessageBox.Show("Giá trị A không đúng! Hãy nhập lại!");
                txtW.Focus();
                txtW.SelectAll();
            }
        }
    }
}
