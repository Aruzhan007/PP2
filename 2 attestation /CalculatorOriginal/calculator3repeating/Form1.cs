using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator3repeating
{
    public partial class Form1 : Form
    {
        double firstnum, secondnum,n=0;
        bool repeat, plus, minus, mult, div;

        private void toDef() {
            plus = false;
            minus = false;
            mult = false;
            div = false;
            repeat = false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += button0.Text;
        }
        
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            return;

            toDef();
            plus = true;
            firstnum = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            toDef();
            minus = true;
            firstnum = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            toDef();
            mult = true;
            firstnum = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            toDef();
            div = true;
            firstnum = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = (firstnum * (double.Parse(textBox1.Text) / 100)).ToString();
            }
            else {
                textBox1.Text=Convert.ToString(firstnum * (firstnum / 100));
            }
        }


        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double m = Double.Parse(textBox1.Text) * Double.Parse(textBox1.Text);
                textBox1.Text = Convert.ToString(m);
            }
            else
                textBox1.Text = "";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double d = Math.Sqrt(Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(d);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = Convert.ToString(double.Parse(textBox1.Text) * (-1));
        }

        private void buttonMemorySave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                n = double.Parse(textBox1.Text);
                textBox1.Text = "";
            }

        }

        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(n);
        }

        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            n = 0;
        }

        private void buttonM_Minus_Click(object sender, EventArgs e)
        {
            double q = Double.Parse(textBox1.Text);
            n -= q;
            textBox1.Text = "";
        }

        private void buttonM_Plus_Click(object sender, EventArgs e)
        {
            double q = Double.Parse(textBox1.Text);
            n += q;
            textBox1.Text = "";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            firstnum = 0;
            secondnum = 0;
            textBox1.Text = "";
            n = 0;
        }

        private void buttonEqualbuttonEqual_Click(object sender, EventArgs e)
        {
            double num=0;

            if(repeat==false)
            secondnum = double.Parse(textBox1.Text);

            if (plus) {
                num = firstnum + secondnum;
                textBox1.Text = Convert.ToString(num);
            }
            if (minus)
            {
                num=firstnum - secondnum;
                textBox1.Text = Convert.ToString(num);
            }
            if (mult)
            {
                num=firstnum * secondnum;
                textBox1.Text = Convert.ToString(num);
            }
            if (div)
            {
               num= firstnum / secondnum;
                textBox1.Text = Convert.ToString(num);
            }
            firstnum = num;
            repeat = true;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
