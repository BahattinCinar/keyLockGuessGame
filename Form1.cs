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

namespace keyLockGuessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] a = new int[4];
        int right = 3;

        public void genNum()
        {
            Random rnd = new Random();

            numGenerate:
            for (int i = 0; i < 3; i++)
            {
                a[i] = rnd.Next(1, 10);
            }

            if (a[0] == a[1] || a[1] == a[2] || a[0] == a[2])
            {
                goto numGenerate;
            }

            for(int i = 0; i<3;i++)
            {
                listBox1.Items.Add(a[i]);
            }
        }

        public void reStart()
        {
            right = 3;

            textBox1.Enabled = true;
            textBox1.Text = "";

            textBox2.Enabled = true;
            textBox2.Text = "";

            textBox3.Enabled = true;
            textBox3.Text = "";
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
                int mod = 3;

                mod = right % mod;

                if(mod == 0)
                {
                    mod += 1;
                }
                
                label4.Text = $"Your score = {100 / mod}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }
    }
}
