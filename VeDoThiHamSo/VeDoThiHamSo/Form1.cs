 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeDoThiHamSo
{
    public partial class Form1 : Form
    {
        CoordinateAxis ca = new CoordinateAxis();
        Functions F = new Functions();
        double a, b, c, d;
        double x;
        Color curColor;
        int curPenSize;
        string sFlag;

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
            offGBStraight();
            offGBFuntions();
            offGbCircle();
            ThemGiaTri();

            ca.min = -100;
            ca.max = 100;

            ca.max_x = picMain.Width;
            ca.max_y = picMain.Height;
            ca.x0 = (int)ca.max_x / 2;
            ca.y0 = (int)ca.max_y / 2;

            ca.DrawAxis();
            ca.DrawPoint();
            picMain.Image = bmp;
        }
        public void DrawFuntion()
        {
            int x1, y1, x2, y2;
            double dx, fx1, fx2;

            Pen pen = new Pen(curColor, curPenSize);
            x = ca.min;
            dx = 1.0f / ca.Scale;

            F.InPut(a, b, c, d);

            fx1 = F.f(x);
            x1 = ca.x0 + (int)(x * ca.Scale);
            y1 = ca.y0 - (int)(fx1 * ca.Scale);


            while (x < ca.max)
            {
                x += dx;
                fx2 = F.f(x);
                x2 = ca.x0 + (int)(x * ca.Scale);
                y2 = ca.y0 - (int)(fx2 * ca.Scale);

                try
                {
                    if (!(fx1 * fx2 < 0 && Math.Abs((int)(fx2 - fx1)) > ca.Scale / 2))
                    {
                        ca.g.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y2));
                    }
                }
                catch { }

                x1 = x2;
                y1 = y2;
                fx1 = fx2;
            }
        }
        public void Draw()
        {
            DrawFuntion();
            picMain.Image = bmp;
        }

        private void CreateNew()
        {
            bmp = new Bitmap(picMain.Width, picMain.Height);
            ca.g = picMain.CreateGraphics();
            ca.g = Graphics.FromImage(bmp);
            ca.x0 = (int)ca.max_x / 2;
            ca.y0 = (int)ca.max_y / 2;
            ca.DrawAxis();
            ca.DrawPoint();
            picMain.Image = bmp;
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

        private float findXt(double x)
        {
            float xt = float.Parse(Convert.ToString(ca.x0 + (x * ca.Scale)));
            return xt;

        }
        private float findYt(double y)
        {
            float yt = float.Parse(Convert.ToString(ca.y0 + (-y * ca.Scale)));
            return yt;
        }
        private void DrawStraight()
        {
            double x1 = Convert.ToDouble(txtX1.Text.ToString());
            double y1 = Convert.ToDouble(txtY1.Text.ToString());
            double x2 = Convert.ToDouble(txtX2.Text.ToString());
            double y2 = Convert.ToDouble(txtY2.Text.ToString());

            Pen pen = new Pen(curColor, curPenSize);
            ca.g.DrawLine(pen, findXt(x1), findYt(y1), findXt(x2), findYt(y2));
            picMain.Image = bmp;
        }
        private void DrawCircle()
        {
            Pen pen = new Pen(curColor, curPenSize);
            double x = Convert.ToDouble(txtX.Text.ToString());
            double y = Convert.ToDouble(txtY.Text.ToString());
            float r = float.Parse(txtR.Text.ToString()) * ca.Scale;
            float xt = findXt(x) - r;
            float yt = findYt(y) - r;
            ca.g.DrawEllipse(pen, xt, yt, 2 * r, 2 * r);
            picMain.Image = bmp;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            switch (sFlag)
            {
                case "Straight":
                    {
                        DrawStraight();
                    }
                    break;
                case "Quadratic":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        b = Convert.ToDouble(txtB.Text.ToString());
                        c = Convert.ToDouble(txtC.Text.ToString());
                        Draw();
                    }
                    break;
                case "Cubic":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        b = Convert.ToDouble(txtB.Text.ToString());
                        c = Convert.ToDouble(txtC.Text.ToString());
                        d = Convert.ToDouble(txtD.Text.ToString());
                        Draw();

                    }
                    break;
                case "axb/cxd":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        b = Convert.ToDouble(txtB.Text.ToString());
                        c = Convert.ToDouble(txtC.Text.ToString());
                        d = Convert.ToDouble(txtD.Text.ToString());
                        Draw();
                    }
                    break;
                case "Circle":
                    {
                        DrawCircle();
                    }
                    break;
                case "Elip":
                    {
                        
                    }
                    break;
                case "Hyperbol":
                    {

                    }
                    break;
                case "Asinwx":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        b = Convert.ToDouble(txtB.Text.ToString());
                        Draw();
                    }
                    break;
                case "Atanwx":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        b = Convert.ToDouble(txtB.Text.ToString());
                        Draw();
                    }
                    break;
                case "Logax":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        Draw();
                    }
                    break;
                case "a^x":
                    {
                        a = Convert.ToDouble(txtA.Text.ToString());
                        Draw();
                    }
                    break;

                default:
                    break;
            }
        }
        
        #region MTS_Click

        private void StraightParagraphMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Straight";
            onGBStraight();
            offGBFuntions();
            offGbCircle();
        }

        private void QuadraticFunctionMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Quadratic";
            offGBStraight();
            onGBFuntions();
            offD();
            offGbCircle();
            gbFuntions.Text = "f(x) = ax^2 + bx + c";
            F.Sender("Quadratic");
        }

        private void CubicFunctionMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Cubic";
            offGBStraight();
            onGBFuntions();
            onAll();
            offGbCircle();
            gbFuntions.Text = "f(x) = ax^3 + bx^2 + cx + d";
            F.Sender("Cubic");
        }

        private void YaxbcxdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sFlag = "axb/cxd";
            offGBStraight();
            onGBFuntions();
            onAll();
            offGbCircle();
            gbFuntions.Text = "f(x) = (ax + b) / (cx + d)";
            F.Sender("axb/cxd");
        }

        private void CircleMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Circle";
            offGBStraight();
            offGBFuntions();
            onGbCircle();
        }

        private void ElipMTS_Click(object sender, EventArgs e)
        {

        }

        private void HyperbolMTS_Click(object sender, EventArgs e)
        {

        }

        private void AsinwxMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Asinwx";
            offGBStraight();
            onGBFuntions();
            offAll();
            onA();
            onB();
            offGbCircle();
            gbFuntions.Text = "f(x) = Asin(bx)";
            F.Sender("Asinwx");
        }



        private void AtanwxMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Atanwx";
            offGBStraight();
            onGBFuntions();
            offAll();
            onA();
            onB();
            offGbCircle();
            gbFuntions.Text = "f(x) = Atan(bx)";
            F.Sender("Atanwx");
        }


        private void LogaxMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Logax";
            offGBStraight();
            onGBFuntions();
            offAll();
            onA();
            offGbCircle();
            gbFuntions.Text = "f(x) = Loga(x)";
            F.Sender("Logax");
        }

        private void ExponentialFunctionMTS_Click(object sender, EventArgs e)
        {
            sFlag = "a^x";
            offGBStraight();
            onGBFuntions();
            offAll();
            onA();
            offGbCircle();
            gbFuntions.Text = "f(x) = a^x";
            F.Sender("a^x");
        }
        #endregion

        private void BtnClear_Click(object sender, EventArgs e)
        {
            CreateNew();
        }
        private void btnCurColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdl = new ColorDialog();
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                curColor = cdl.Color;
                btnCurColor.BackColor = cdl.Color;
            }
        }

        private void ThemGiaTri()
        {
            for (int i = 1; i <= 5; i++)
            {
                cbbCurSize.Items.Add(i);
            }
            cbbCurSize.SelectedIndex = 0;

        }
        private void cbbCurSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPenSize = int.Parse(cbbCurSize.Text.ToString());
        }


        #region CheckValue
        public bool IsNumber(string pText)
        {
            Regex regex = null;
            regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void txtX1_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtX1.Text))
            {
                MessageBox.Show("Giá trị X1 không đúng! Hãy nhập lại!");
                txtX1.Focus();
                txtX1.SelectAll();
            }
        }

        private void txtY1_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtY1.Text))
            {
                MessageBox.Show("Giá trị Y1 không đúng! Hãy nhập lại!");
                txtY1.Focus();
                txtY1.SelectAll();
            }
        }

        private void txtX2_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtX2.Text))
            {
                MessageBox.Show("Giá trị X2 không đúng! Hãy nhập lại!");
                txtX2.Focus();
                txtX2.SelectAll();
            }
        }

        private void txtY2_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtY2.Text))
            {
                MessageBox.Show("Giá trị Y2 không đúng! Hãy nhập lại!");
                txtY2.Focus();
                txtY2.SelectAll();
            }
        }

        private void txtA_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtA.Text))
            {
                MessageBox.Show("Giá trị A không đúng! Hãy nhập lại!");
                txtA.Focus();
                txtA.SelectAll();
            }
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtB.Text))
            {
                MessageBox.Show("Giá trị B không đúng! Hãy nhập lại!");
                txtB.Focus();
                txtB.SelectAll();
            }
        }

        private void txtC_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtC.Text))
            {
                MessageBox.Show("Giá trị C không đúng! Hãy nhập lại!");
                txtC.Focus();
                txtC.SelectAll();
            }
        }

        private void txtD_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtD.Text))
            {
                MessageBox.Show("Giá trị D không đúng! Hãy nhập lại!");
                txtD.Focus();
                txtD.SelectAll();
            }
        }

        private void txtR_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtR.Text))
            {
                MessageBox.Show("Giá trị R không đúng! Hãy nhập lại!");
                txtR.Focus();
                txtR.SelectAll();
            }
        }

        private void txtX_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtX.Text))
            {
                MessageBox.Show("Giá trị X không đúng! Hãy nhập lại!");
                txtX.Focus();
                txtX.SelectAll();
            }
        }

        private void txtY_Leave(object sender, EventArgs e)
        {
            if (!IsNumber(txtY.Text))
            {
                MessageBox.Show("Giá trị Y không đúng! Hãy nhập lại!");
                txtY.Focus();
                txtY.SelectAll();
            }
        }
        #endregion

    }
}
