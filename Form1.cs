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

        int[] a = new int[4];
        int[] b = new int[10];
        int right = 3, plc, lb;

        Random plcs = new Random();
        Random label = new Random();

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

            for(int i = 0; i < 3; i++)
            {
                listBox1.Items.Add(a[i]);
            }
            
            listBox1.Items.Add("-------------------------------------------------------------------------");
            
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

        public void labels()
        {
            label7.Text = "Number is correct and placed well";
            label11.Text = "Nothing is right";
            label15.Text = "One number is correct but wrongly placed";
            label19.Text = "Two number are correct but wrongly placed";
        }

        public void hints()
        {
            Random rnd = new Random();
            
        hintsNumGen:
            for(int i = 0;i < 9; i++)
            {
                b[i] = rnd.Next(1,10);
            }

            if (a[0] != b[0] || a[1] != b[1] || a[2] != b[2])
            {
                goto hintsNumGen;
            }

            // Hints

            places();

            int l1, l2, l3;

            //label 7

            if(plc == 1)
            {
                label8.Text = Convert.ToString(a[0]);
                l3 = int.Parse(label8.Text);
                lbl();
                label9.Text = Convert.ToString(b[lb]);
                l1 = int.Parse(label9.Text);
                
            lbl:
                lbl();
                if(lb == l1)
                {
                    goto lbl;
                }
                else
                {
                    l2 = b[lb];
                    label10.Text = Convert.ToString(b[lb]);
                }                
            }
            else if(plc == 2)
            {
                label9.Text = Convert.ToString(a[1]);
                l3 = int.Parse(label9.Text);
                lbl();
                label8.Text = Convert.ToString(b[lb]);
                l1 = int.Parse(label8.Text);
                
            lbl:
                lbl();
                if (lb == l1)
                {
                    goto lbl;
                }
                else
                {
                    l2 = b[lb];
                    label10.Text = Convert.ToString(b[lb]);
                }
            }
            else
            {
                label10.Text = Convert.ToString(a[2]);
                l3 = int.Parse(label10.Text);
                lbl();
                label8.Text = Convert.ToString(b[lb]);
                l1 = int.Parse(label8.Text);
                
            lbl:
                lbl();
                if (lb == l1)
                {
                    goto lbl;
                }
                else
                {
                    l2 = b[lb];
                    label9.Text = Convert.ToString(b[lb]);
                }
            }

            //label 11

            
            label12.Text = Convert.ToString(l1);
            label13.Text = Convert.ToString(l2);
            
        plc:
            places();
            if (lb == l1 || lb == l2)
            {
                goto plc;    
            }
            else
            {
                label14.Text = Convert.ToString(b[lb]);
            }

            for (int i = 0; i < b.Length - 1; i++)
            {
                listBox1.Items.Add(b[i]);
            }
        }

        public void places()
        { 
            plc = plcs.Next(1,4);
        }

        public void lbl()
        {
            lb = label.Next(4, 7);
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
            Form1_Load(null, null);
        }
    }
}
