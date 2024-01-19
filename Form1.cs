using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace keyLockGuessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            genNum();
            hints();
            labels();
            reStart();

            label6.Text = Convert.ToString(right);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b, c, d;

            b= int.Parse(textBox1.Text);
            c = int.Parse(textBox2.Text);
            d = int.Parse(textBox3.Text);

            if (a[0] != b || a[1] != c || a[2] != d)
            {
                right = right - 1;
                label6.Text = Convert.ToString(right);

                if(a[0] != b)
                {
                    textBox1.ForeColor = Color.Red;
                }
                if (a[1] != c)
                {
                    textBox2.ForeColor = Color.Red;
                }
                if (a[2] != d)
                {
                    textBox3.ForeColor = Color.Red;
                }
            }
            
            if (a[0] == b)
            {
                textBox1.ForeColor = Color.Green;
                textBox1.Enabled = false;
            }
            if (a[1] == c)
            {
                textBox2.ForeColor = Color.Green;
                textBox2.Enabled = false;
            }
            if (a[2] == d)
            {
                textBox3.ForeColor = Color.Green;
                textBox3.Enabled = false;
            }

            if (right == 0)
            {
                MessageBox.Show("You lose, try again");
                Form1_Load(null, null);
            }

            if(textBox1.Enabled == false && textBox2.Enabled == false && textBox3.Enabled == false)
            {
                if(right == 3)
                {
                    label4.Text = $"Your score 100";
                }
                else if(right == 2)
                {
                    label4.Text = $"Your score {100 / 2}";
                }
                else
                {
                    label4.Text = $"Your score {100 / 3}";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
