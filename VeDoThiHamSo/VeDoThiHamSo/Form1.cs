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
        public static string X1 = "0", X2 = "0", Y1 = "0", Y2 = "0";
        public static string X = "0", Y = "0", R = "0";
        public static double a, b, c, d;
        double x;
        Color curColor;
        int curPenSize;
        public static string sFlag;

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
            lbAv.Enabled = true;
            lbAv.Visible = true;
        }
        private void offA()
        {
            lbA.Enabled = false;
            lbA.Visible = false;
            lbAv.Enabled = false;
            lbAv.Visible = false;
        }
        private void onB()
        {
            lbB.Enabled = true;
            lbB.Visible = true;
            lbBv.Enabled = true;
            lbBv.Visible = true;
        }
        private void offB()
        {
            lbB.Enabled = false;
            lbB.Visible = false;
            lbBv.Enabled = false;
            lbBv.Visible = false;
        }

        private void onC()
        {
            lbC.Enabled = true;
            lbC.Visible = true;
            lbCv.Enabled = true;
            lbCv.Visible = true;
        }
        private void offC()
        {
            lbC.Enabled = false;
            lbC.Visible = false;
            lbCv.Enabled = false;
            lbCv.Visible = false;
        }
        private void onD()
        {
            lbD.Enabled = true;
            lbD.Visible = true;
            lbDv.Enabled = true;
            lbDv.Visible = true;
        }
        private void offD()
        {
            lbD.Enabled = false;
            lbD.Visible = false;
            lbDv.Enabled = false;
            lbDv.Visible = false;
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
            double x1 = Convert.ToDouble(lbX1v.Text.ToString());
            double y1 = Convert.ToDouble(lbY1v.Text.ToString());
            double x2 = Convert.ToDouble(lbX2v.Text.ToString());
            double y2 = Convert.ToDouble(lbY2v.Text.ToString());

            Pen pen = new Pen(curColor, curPenSize);
            ca.g.DrawLine(pen, findXt(x1), findYt(y1), findXt(x2), findYt(y2));
            picMain.Image = bmp;
        }
        private void DrawCircle()
        {
            Pen pen = new Pen(curColor, curPenSize);
            double x = Convert.ToDouble(lbXv.Text.ToString());
            double y = Convert.ToDouble(lbYv.Text.ToString());
            float r = float.Parse(lbRv.Text.ToString()) * ca.Scale;
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
                        Draw();
                    }
                    break;
                case "Cubic":
                    {
                        Draw();

                    }
                    break;
                case "axb/cxd":
                    {
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
                        Draw();
                    }
                    break;
                case "Atanwx":
                    {
                        Draw();
                    }
                    break;
                case "Logax":
                    {
                        Draw();
                    }
                    break;
                case "a^x":
                    {
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
            InsertStraightValue st = new InsertStraightValue();
            st.ShowDialog();
            this.lbX1v.Text = X1;
            this.lbY1v.Text = Y1;
            this.lbX2v.Text = X2;
            this.lbY2v.Text = Y2;
        }

        private void QuadraticFunctionMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Quadratic";
            offGBStraight();
            onGBFuntions();
            offD();
            offGbCircle();
            gbFuntions.Text = "f(x) = ax^2 + bx + c";
            InsertQuadraticValue q = new InsertQuadraticValue();
            q.ShowDialog();
            this.lbAv.Text = a.ToString();
            this.lbBv.Text = b.ToString();
            this.lbCv.Text = c.ToString();
        }

        private void CubicFunctionMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Cubic";
            offGBStraight();
            onGBFuntions();
            onAll();
            offGbCircle();
            gbFuntions.Text = "f(x) = ax^3 + bx^2 + cx + d";
            InsertCubicValue cb = new InsertCubicValue();
            cb.ShowDialog();
            this.lbAv.Text = a.ToString();
            this.lbBv.Text = b.ToString();
            this.lbCv.Text = c.ToString();
            this.lbDv.Text = d.ToString();

        }

        private void YaxbcxdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sFlag = "axb/cxd";
            offGBStraight();
            onGBFuntions();
            onAll();
            offGbCircle();
            gbFuntions.Text = "f(x) = (ax + b) / (cx + d)";
            InsertAxBCxDValue axbcxd = new InsertAxBCxDValue();
            axbcxd.ShowDialog();
            this.lbAv.Text = a.ToString();
            this.lbBv.Text = b.ToString();
            this.lbCv.Text = c.ToString();
            this.lbDv.Text = d.ToString();
        }

        private void CircleMTS_Click(object sender, EventArgs e)
        {
            sFlag = "Circle";
            offGBStraight();
            offGBFuntions();
            onGbCircle();
            InsertCircleValue c = new InsertCircleValue();
            c.ShowDialog();
            this.lbXv.Text = X;
            this.lbYv.Text = Y;
            this.lbRv.Text = R;
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
            InsertAsinbxValue asinx = new InsertAsinbxValue();
            asinx.ShowDialog();
            this.lbAv.Text = a.ToString();
            this.lbBv.Text = b.ToString();
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
            InsertAtanbxValue atanx = new InsertAtanbxValue();
            atanx.ShowDialog();
            this.lbAv.Text = a.ToString();
            this.lbBv.Text = b.ToString();
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
            InsertLogaxValue log = new InsertLogaxValue();
            log.ShowDialog();
            this.lbAv.Text = a.ToString();
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
            InsertAexpXValue aexpx = new InsertAexpXValue();
            aexpx.ShowDialog();
            this.lbAv.Text = a.ToString();
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


        static public bool IsNumber(string pText)
        {
            Regex regex = null;
            regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }    
       
    }
}
