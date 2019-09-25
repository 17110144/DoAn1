using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeDoThiHamSo
{
    abstract class cObject
    {
        public Color Color;
        public int iDoDay;

        public Pen pen;
        public DashStyle dashStyle;

        public Point p1;
        public Point p2;
        public abstract void Draw(Graphics g, Pen p);
    }
}
