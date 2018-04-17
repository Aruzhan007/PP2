using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RealSteroid
{
    class Ellipse
    {
        int x;
        int y;
        int[] loc = new int[2];
        int[] rad = new int[2];

        public Ellipse(int x,int y)
        {
            this.x = x;
            this.y = y;
            loc[0] = x;
            loc[1] = y;
            rad[0] = 30;
            rad[1] = 30;
        }
        public void Edraw(Graphics g, Brush br)
        {
            g.FillEllipse(br, loc[0],loc[1], rad[0],rad[1]);
        }
    }
}
