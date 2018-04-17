using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RealSteroid
{
    class Asteroids 
    {
        int x, y;
        Point[] tr1 = new Point[3];
        Point[] tr2 = new Point[3];

        public Asteroids(int x,int y)
        {
            this.x = x;
            this.y = y;

            tr1[0].X = x;
            tr1[0].Y = y;

            tr1[1].X = x - 15;
            tr1[1].Y = y + 20;

            tr1[2].X = x + 15;
            tr1[2].Y = y + 20;

            tr2[0].X = x;
            tr2[0].Y = y + 30;

            tr2[1].X = x - 15;
            tr2[1].Y = y + 10;

            tr2[2].X = x + 15;
            tr2[2].Y = y + 10;
        }
        public void AsDraw(Graphics g, Brush b)
        {
            g.FillPolygon(b, tr1);
            g.FillPolygon(b, tr2);
        }
    }
}
