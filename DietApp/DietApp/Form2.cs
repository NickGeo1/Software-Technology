using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class Form2 : Form
    {
        bool flag = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                flag= false;
                this.Close();
                Form4 form4 = new Form4();
                form4.Show();
            }
            else if (radioButton2.Checked)
            {
                flag= false;
                this.Close();
                Form5 form5 = new Form5(null);
                form5.Show();
            }
            else if(radioButton3.Checked)
            {   
                flag= false;
                this.Close();
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                flag = false;
                this.Close();
                Form6 form6 = new Form6();
                form6.Show();
            
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag==true)
            {
                Application.Exit();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
