using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealSteroid
{
    public partial class Form1 : Form
    {
        public int i = 3;
        public int x = 100;
        public int y = 130;
        public int y1 = 50;
        public int x1 = 50;
        public int y2 = 150;
        public int x2 = 150;
        public int y3 = 250;
        public int x3 = 250;
        public int y4 = 250;
        public int x4 = 250;
        public int y5 = 300;
        public int x5 = 300;
        public int y6 = 20;
        public int x6 = 30;
        public Bitmap bmp;
        public Graphics g;
        public Pen pen;
        public SolidBrush brsh;
        public SolidBrush elbrsh;
        public char n;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                n = 'u';
            if (e.KeyCode == Keys.Down)
                n = 'd';
            if (e.KeyCode == Keys.Right)
                n = 'r';
            if (e.KeyCode == Keys.Left)
                n = 'l';
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black);
            brsh = new SolidBrush(Color.Red);
            elbrsh = new SolidBrush(Color.White);
            g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 400, 400);

            Ellipse el1 = new Ellipse(120, 100);
            el1.Edraw(g, elbrsh);

            Ellipse el2 = new Ellipse(200, 40);
            el2.Edraw(g, elbrsh);

            Ellipse el3 = new Ellipse(300, 230);
            el3.Edraw(g, elbrsh);

            Ellipse el4 = new Ellipse(20, 14);
            el4.Edraw(g, elbrsh);

            Ellipse el5 = new Ellipse(30, 170);
            el5.Edraw(g, elbrsh);

            Ellipse el6 = new Ellipse(70, 270);
            el6.Edraw(g, elbrsh);

            Ellipse el7 = new Ellipse(270, 100);
            el7.Edraw(g, elbrsh);

            //below I create a stars like a circle
            SolidBrush bromb = new SolidBrush(Color.Yellow);

            ship sh = new ship(x, y);
            sh.ShDraw(g, bromb);

            //below I create a ship

            if (n == 'u')
            {
                y -= 10;
            }
            if (n == 'd')
            {
                y += 10;
            }
            if (n == 'r')
            {
                x += 10;
            }
            if (n == 'l')
            {
                x -= 10;
            }

            //below I control my ship
            if (x > 380)
                x = -15;
            if (y > 350)
                y = -20;
            if (x < -16)
                x = 379;
            if (y < -21)
                y = 349;

            //because of the below my ship cannot go out of picturebox

            Asteroids as1 = new Asteroids(x1, y1);
            as1.AsDraw(g, brsh);
            x1 += 12;
            y1 += 5;

            Asteroids as2 = new Asteroids(x2, y2);
            as2.AsDraw(g, brsh);
            x2 -= 4;
            y2 -= 10;

            Asteroids as3 = new Asteroids(x3, y3);
            as3.AsDraw(g, brsh);
            x3 += 5;
            y3 -= 4;

            Asteroids as4 = new Asteroids(x4, y4);
            as4.AsDraw(g, brsh);
            x4 -= 15;
            y4 += 4;
            Asteroids as5 = new Asteroids(x5, y5);
            as5.AsDraw(g, brsh);
            x5 += 15;
            y5 += 6;
            Asteroids as6 = new Asteroids(x6, y6);
            as6.AsDraw(g, brsh);
            x6 -= 17;
            y6 += 7;

            //below I create a steroids

            if (x1 > 380)
                x1 = -15;
            if (y1 > 350)
                y1 = -20;
            if (x1 < -16)
                x1 = 379;
            if (y1 < -21)
                y1 = 349;

            if (x2 > 380)
                x2 = -15;
            if (y2 > 350)
                y2 = -20;
            if (x2 < -16)
                x2 = 379;
            if (y2 < -21)
                y2 = 349;

            if (x3 > 380)
                x3 = -15;
            if (y3 > 350)
                y3 = -20;
            if (x3 < -16)
                x3 = 379;
            if (y3 < -21)
                y3 = 349;

            if (x4 > 380)
                x4 = -15;
            if (y4 > 350)
                y4 = -20;
            if (x4 < -16)
                x4 = 379;
            if (y4 < -21)
                y4 = 349;

            if (x5 > 380)
                x5 = -15;
            if (y5 > 350)
                y5 = -20;
            if (x5 < -16)
                x5 = 379;
            if (y5 < -21)
                y5 = 349;

            if (x6 > 380)
                x6 = -15;
            if (y6 > 350)
                y6 = -20;
            if (x6 < -16)
                x6 = 379;
            if (y6 < -21)
                y6 = 349;

            //below I control Stars in order to don't let them escape picture box

            if (y < y1+7 && y+42 > y1+7 && x - 7 + 21 > x1-9 && x - 7 - 21 < x1 || y < y2 + 7 && y + 42 > y2 + 7 && x - 7 + 21 > x2 - 9 && x - 7 - 21 < x2 || y < y3 + 7 && y + 42 > y3 + 7 && x - 7 + 21 > x3 - 9 && x - 7 - 21 < x3 || y < y4 + 7 && y + 42 > y4 + 7 && x - 7 + 21 > x4 - 9 && x - 7 - 21 < x4)
            {
                timer1.Stop();
                g.DrawString("GameOver", Font, bromb, 149, 146);
            }//сверху слева
            if (y < y1 && y + 42 > y1 && x - 7 + 21 > x1 + 15 && x - 7 - 21 < x1+10 || y < y2 && y + 42 > y2 && x - 7 + 21 > x2 + 15 && x - 7 - 21 < x2 + 10 || y < y3 && y + 42 > y3 && x - 7 + 21 > x3 + 15 && x - 7 - 21 < x3 + 10 || y < y4 && y + 42 > y4 && x - 7 + 21 > x4 + 15 && x - 7 - 21 < x4 + 10 )
            {
                timer1.Stop();
                g.DrawString("GameOver", Font, bromb, 149, 146);
            }//сверху справа 

            if ( y+42 > y1+30 && y < y1+30 && x - 7 + 21 > x1+7 && x - 7 - 21 < x1+7 || y + 42 > y2 + 30 && y < y2 + 30 && x - 7 + 21 > x2 + 7 && x - 7 - 21 < x2 + 7 || y + 42 > y3 + 30 && y < y3 + 30 && x - 7 + 21 > x3 + 7 && x - 7 - 21 < x3 + 7 || y + 42 > y4 + 30 && y < y4 + 30 && x - 7 + 21 > x4 + 7 && x - 7 - 21 < x4 + 7)
            {
                timer1.Stop();
                g.DrawString("GameOver", Font, bromb, 149, 146);
            }//снизу справа
            if (y + 42 > y1 + 30 && y < y1 + 30 && x - 7 + 21 > x1 - 11 && x - 7 - 21 < x1 - 11 || y + 42 > y2 + 30 && y < y2 + 30 && x - 7 + 21 > x2 - 11 && x - 7 - 21 < x2 - 11 || y + 42 > y3 + 30 && y < y3 + 30 && x - 7 + 21 > x3 - 11 && x - 7 - 21 < x3 - 11 || y + 42 > y4 + 30 && y < y4 + 30 && x - 7 + 21 > x4 - 11 && x - 7 - 21 < x4 - 11)
            {
                timer1.Stop();
                g.DrawString("GameOver", Font, bromb, 149, 146);
            }//снизу слева

            pictureBox1.Image = bmp;
        }

        


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
