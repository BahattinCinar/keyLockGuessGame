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

        int[] a = new int[3];
        int[] b = new int[3];
        int point = 4;

        public void rightNums()
        {
            Random RightNums = new Random();

            int rndm;

            for (int i = 0; i < 3; i++)
            {
            rndm:
                rndm = RightNums.Next(1,10);

                int aof = Array.IndexOf(a, rndm);

                if (aof == -1)
                {
                    a[i] = rndm;
                }
                else
                {
                    goto rndm;
                }
            }
        }
        
        private void labels()
        {
            label1.Visible = false;

            label2.Text = "One number is correct and well placed";
            label6.Text = "Nothing is right";
            label10.Text = "One number is correct but wrongly placed";
            label14.Text = "Two number is correct but wrongly placed";

            label19.Text = Convert.ToString(point);
        }

        public void hints()
        {
            //fake num gen
            
            Random hints = new Random();

            int rndm;

            for(int i = 0; i < 3; i++)
            {
            rndm:
                rndm = hints.Next(1, 10);
                int aof = Array.IndexOf(a, rndm);
                int aif = Array.IndexOf(b, rndm);

                if(aif == -1 && aof == -1)
                {
                    b[i] = rndm;
                }
                else
                {
                    goto rndm;
                }
            }

            //hints locate

            //label2
            label3.Text = Convert.ToString(b[2]);
            label4.Text = Convert.ToString(a[1]);
            label5.Text = Convert.ToString(b[0]);

            //label6
            label7.Text = Convert.ToString(b[0]);
            label8.Text = Convert.ToString(b[1]);
            label9.Text = Convert.ToString(b[2]);

            //label10
            label11.Text = Convert.ToString(a[2]);
            label12.Text = Convert.ToString(b[2]);
            label13.Text = Convert.ToString(b[1]);

            //label14
            label15.Text = Convert.ToString(a[2]);
            label16.Text = Convert.ToString(b[1]);
            label17.Text = Convert.ToString(a[0]);

        }

        public void answers()
        {
            int text1,text2,text3;

            text1 = int.Parse(textBox1.Text);
            text2 = int.Parse(textBox2.Text);
            text3 = int.Parse(textBox3.Text);

            if (text1 == a[0])
            {
                textBox1.Enabled = false;
                textBox1.BackColor = Color.White;
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox1.ForeColor = Color.Black;
            }
            if (text2 == a[1])
            {
                textBox2.Enabled = false;
                textBox2.BackColor = Color.White;
            }
            else
            {
                textBox2.BackColor = Color.Red;
                textBox2.ForeColor = Color.Black;
            }
            if (text3 == a[2])
            {
                textBox3.Enabled = false;
                textBox3.BackColor = Color.White;
            }
            else
            {
                textBox3.BackColor = Color.Red;
                textBox3.ForeColor = Color.Black;
            }

            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            point--;

            answers();

            if (point == 0 && int.Parse(textBox1.Text) != a[0] && int.Parse(textBox2.Text) != a[1] && int.Parse(textBox3.Text) != a[2])
            {
                label1.Text = "You lose try again";
                label1.ForeColor = Color.Red;

                textBox1.Text = Convert.ToString(a[0]);
                textBox2.Text = Convert.ToString(a[1]);
                textBox3.Text = Convert.ToString(a[2]);
            }
            else if (int.Parse(textBox1.Text) == a[0] && int.Parse(textBox2.Text) == a[1] && int.Parse(textBox3.Text) == a[2] && point > 0)
            {
                
                label1.Text = $"You winn. Your score is = {25 * point}";
            }
            else if (point == 0 && int.Parse(textBox1.Text) == a[0] && int.Parse(textBox2.Text) == a[1] && int.Parse(textBox3.Text) == a[2])
            {
                label1.Text = $"You lucky man you win last right. Here is your score : 25";
            }
            else
            {
                label1.Text = $"Your score is = {25 * point}";
            }

            label19.Text = Convert.ToString(point);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rightNums();
            labels();
            hints();
            
        }
    }
}
