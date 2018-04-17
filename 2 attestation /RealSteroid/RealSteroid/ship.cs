using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RealSteroid
{
    class ship
    {
        int x;
        int y;
        Point[] sh = new Point[8];

        public ship(int x,int y)
        {
            this.x = x;
            this.y = y;
            sh[0].X = x;
            sh[0].Y = y;
            sh[1].X = x+14;
            sh[1].Y = y+14;
            sh[2].X = x+14;
            sh[2].Y = y+28;
            sh[3].X = x;
            sh[3].Y = y+42;
            sh[4].X = x-14;
            sh[4].Y = y+42;
            sh[5].X = x-28;
            sh[5].Y = y+28;
            sh[6].X = x - 28;
            sh[6].Y = y + 14;
            sh[7].X = x - 14;
            sh[7].Y = y;
        }
        public void ShDraw(Graphics g, Brush br)
        {
            g.FillPolygon(br,sh);
        }
    }
}
