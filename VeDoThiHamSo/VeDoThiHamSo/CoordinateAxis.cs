using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VeDoThiHamSo
{
    class CoordinateAxis
    {
        public int max_x;
        public int max_y;
        public Graphics g;
        public int x0, y0, Scale = 50;
        public CoordinateAxis() { }

        public void DrawAxis()
        {
            Pen pen = new Pen(Color.BlueViolet, 2);
            g.DrawLine(pen, 1, y0, max_x, y0);
            g.DrawLine(pen, x0, 1, x0, max_y);

            Font f = new Font("Tahoma", 10);
            Brush br = new SolidBrush(Color.Red);
            /*---------------------------------------------------------*/
            int i;
            Pen pen2 = new Pen(Color.OldLace, 1);
            for (i = x0; i < max_x; i += Scale / 5)
            {
                g.DrawLine(pen2, i, y0 - max_x, i, y0 + max_x);
            }
            for (i = x0; i > 0; i -= Scale / 5)
            {
                g.DrawLine(pen2, i, y0 - max_x, i, y0 + max_x);
            }

            for (i = y0; i < max_y; i += Scale / 5)
            {
                g.DrawLine(pen2, x0 - max_y, i, x0 + max_y, i);
            }
            for (i = y0; i > 0; i -= Scale / 5)
            {
                g.DrawLine(pen2, x0 - max_y, i, x0 + max_y, i);
            }
            /*-------------------------------------------------*/
            Pen pen1 = new Pen(Color.BlueViolet, 1);
            for (i = x0 + Scale; i < max_x; i += Scale)
            {
                g.DrawLine(pen1, i, y0 - 3, i, y0 + 2);
            }
            for (i = x0 - Scale; i > 0; i -= Scale)
            {
                g.DrawLine(pen1, i, y0 - 3, i, y0 + 2);
            }

            for (i = y0 + Scale; i < max_y; i += Scale)
            {
                g.DrawLine(pen1, x0 - 3, i, x0 + 2, i);
            }

            for (i = y0 - Scale; i > 0; i -= Scale)
            {
                g.DrawLine(pen1, x0 - 3, i, x0 + 2, i);
            }

            g.DrawString("O", f, br, x0 - 20, y0);
            g.DrawString("X", f, br, max_x - 20, y0 + 2);
            g.DrawString("Y", f, br, x0 + 3, 1);
        }
        public void DrawPoint()
        {
            Font f = new Font("Microsoft Sans Serif", 7);
            int i;
            for (i = x0 + Scale; i < max_x; i += Scale)
            {
                g.DrawString(((i - x0 - Scale) / Scale + 1).ToString(), f, Brushes.BlueViolet, i - 10, y0 - 30);

            }
            for (i = x0 - Scale; i > 0; i -= Scale)
            {
                g.DrawString(((i - x0 + Scale) / Scale - 1).ToString(), f, Brushes.BlueViolet, i, y0 - 30);
            }

            for (i = y0 + Scale; i < max_y; i += Scale)
            {
                g.DrawString(((i - y0 - Scale) / (-Scale) - 1).ToString(), f, Brushes.BlueViolet, x0 + 10, i - 10);
            }

            for (i = y0 - Scale; i > 0; i -= Scale)
            {
                g.DrawString(((i - y0 + Scale) / (-Scale) + 1).ToString(), f, Brushes.BlueViolet, x0 + 10, i);
            }
        }
    }
}
