using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        SolidBrush brsh;
        bool Mouseclicked = false;
        Point prev;
        Point cur;
        Bitmap bmp;
        Graphics gb;
        enum Shape { LINE, PEN, Rect, Ell, Zaliv }
        Shape shape = new Shape();
        Queue<Point> queue = new Queue<Point>();
        Color orgncolor;
        Color Curcolor;
        bool DrawWithZalivka;
        public Form1()
        {
            InitializeComponent();
            Draw();
            pen = new Pen(Color.Black);
            brsh = new SolidBrush(Color.White);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            shape = Shape.PEN;
            gb = Graphics.FromImage(bmp);
            Curcolor = Color.White;
        }

        private void Draw() {
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // e.Graphics.DrawLine(pen,prev.X,prev.Y,cur.X,cur.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (shape == Shape.Zaliv)
            {
                orgncolor = bmp.GetPixel(e.X,e.Y);
                queue.Enqueue(e.Location);
                while (queue.Count != 0)
                {
                    Point cur = queue.Dequeue();
                    Step(new Point(cur.X, cur.Y + 1));
                    Step(new Point(cur.X, cur.Y - 1));
                    Step(new Point(cur.X+1, cur.Y));
                    Step(new Point(cur.X-1, cur.Y));
                }
                pictureBox1.Refresh();

            }
            prev = e.Location;
            Mouseclicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (shape == Shape.LINE)
            {
                cur = e.Location;
                Mouseclicked = false;
                gb.DrawLine(pen, prev, cur);
                pictureBox1.Image = bmp;
            }
            if (shape == Shape.PEN)
            {
                cur = e.Location;
                Mouseclicked = false;
            }

            if (shape == Shape.Rect) {
                if (cur.X > prev.X && cur.Y > prev.Y)

                    Mouseclicked = false;

                if(DrawWithZalivka==false)
                gb.DrawRectangle(pen, prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);
                        else
                    gb.FillRectangle(brsh, prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);

                if (cur.X < prev.X && cur.Y < prev.Y)
                {

                    Mouseclicked = false;
                    if (DrawWithZalivka == false)
                        gb.DrawRectangle(pen, e.X, e.Y, prev.X - e.X, prev.Y - e.Y);

                    else
                        gb.FillRectangle(brsh, e.X, e.Y, prev.X - e.X, prev.Y - e.Y);

                    pictureBox1.Image = bmp;

                }

                if (cur.X < prev.X && cur.Y > prev.Y)
                {
                    Mouseclicked = false;
                    if (DrawWithZalivka == false)
                        gb.DrawRectangle(pen, e.X, prev.Y, prev.X - e.X, e.Y - prev.Y);

                    else
                        gb.FillRectangle(brsh, e.X, prev.Y, prev.X - e.X, e.Y - prev.Y);

                    pictureBox1.Image = bmp;

                }

                if (cur.X > prev.X && cur.Y < prev.Y)
                {
                    Mouseclicked = false;
                    if (DrawWithZalivka == false)
                        gb.DrawRectangle(pen, prev.X, e.Y, e.X - prev.X, prev.Y - e.Y);

                    else
                        gb.FillRectangle(brsh, prev.X, e.Y, e.X - prev.X, prev.Y - e.Y);

                    pictureBox1.Image = bmp;

                }
                //pictureBox1.Image = bmp;

            }
            if (shape == Shape.Ell)
            {
                Mouseclicked = false;
                if(DrawWithZalivka==false)
                    gb.DrawEllipse(pen, prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);
                else
                    gb.FillEllipse(brsh, prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);

                pictureBox1.Image = bmp;
            }
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (shape == Shape.LINE) {
                if (Mouseclicked)
                {
                    cur.X = e.X;
                    cur.Y = e.Y;
                    Refresh();
                    g.DrawLine(pen, prev, e.Location);
                }
            }
            if (shape == Shape.PEN)
            {
                if (Mouseclicked)
                {

                    gb.DrawLine(pen, prev.X, prev.Y, e.X, e.Y);
                    prev = e.Location;
                    pictureBox1.Image = bmp;

                }
            }
            if (shape == Shape.Rect) {
                if (Mouseclicked) {
                    // Refresh();
                    cur = e.Location;

                    if (cur.X > prev.X && cur.Y > prev.Y)
                    {
                        Refresh();
                        g.DrawRectangle(pen, prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);
                    }
                    if (cur.X < prev.X && cur.Y < prev.Y)
                    {
                        Refresh();
                        g.DrawRectangle(pen, e.X, e.Y, prev.X - e.X, prev.Y - e.Y);

                    }
                    if (cur.X < prev.X && cur.Y > prev.Y) {
                        Refresh();
                        g.DrawRectangle(pen, e.X, prev.Y, prev.X - e.X, e.Y - prev.Y);
                    }
                    if (cur.X > prev.X && cur.Y < prev.Y)
                    {
                        Refresh();
                        g.DrawRectangle(pen, prev.X, e.Y, e.X - prev.X, prev.Y - e.Y);
                    }
                }
            }
            if (shape == Shape.Ell)
            {
                if (Mouseclicked == true)
                {
                    cur = e.Location;
                    if (cur.X > prev.X && cur.Y > prev.Y)
                    {
                        Refresh();
                        g.DrawEllipse(pen, prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);
                    }
                    if (cur.X < prev.X && cur.Y < prev.Y)
                    {
                        Refresh();
                        g.DrawEllipse(pen, e.X, e.Y, prev.X - e.X, prev.Y - e.Y);

                    }
                    if (cur.X < prev.X && cur.Y > prev.Y)
                    {
                        Refresh();
                        g.DrawEllipse(pen, e.X, prev.Y, prev.X - e.X, e.Y - prev.Y);
                    }
                    if (cur.X > prev.X && cur.Y < prev.Y)
                    {
                        Refresh();
                        g.DrawEllipse(pen, prev.X, e.Y, e.X - prev.X, prev.Y - e.Y);
                    }
                }
            }

            
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            Curcolor = button3.BackColor;
            pen = new Pen(button3.BackColor);
            brsh.Color = button3.BackColor;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Curcolor = button1.BackColor;
            brsh.Color = button1.BackColor;
            pen = new Pen(button1.BackColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Curcolor = button2.BackColor;
            brsh.Color = button2.BackColor;
            pen = new Pen(button2.BackColor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Curcolor = button4.BackColor;
            brsh.Color = button4.BackColor;
            pen = new Pen(button4.BackColor);
        }

        private void Karandash_Click(object sender, EventArgs e)
        {
            shape = Shape.PEN;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            shape = Shape.LINE;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            shape = Shape.Rect;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("pow");
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            shape = Shape.Ell;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("pow");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            shape = Shape.Zaliv;
            DrawWithZalivka = false;
        }


        public void Step(Point p) {
            if (p.X >= bmp.Width)
                return;
            if (p.X <= 0)
                return;
            if (p.Y >= bmp.Height)
                return;
            if (p.Y <= 0)
                return;

            if (bmp.GetPixel(p.X,p.Y) != orgncolor)
           return;
                    bmp.SetPixel(p.X, p.Y, Curcolor);
            queue.Enqueue(p);
        }

        private void AllColors_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog2.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                Curcolor = colorDialog2.Color;
                pen.Color = colorDialog2.Color;
                brsh.Color = colorDialog2.Color; 
            }
        }

        private void AllColors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DrawWithZalivka = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DrawWithZalivka = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gb.Clear(Color.White);
            pictureBox1.Refresh();
        }
    }
}
