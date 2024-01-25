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

        public void hints()
        {
           //1 den 10 a kadar 3 adet random sayı üret ürettiğin sayıları 1 ila 3 arasında sırala (sırayı diziye yaz) ipucu kısmında ne lazım ise göster
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
}

        private void button1_Click(object sender, EventArgs e)
        {
            answers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rightNums();
        }
    }
}
