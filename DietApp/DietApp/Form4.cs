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
    public partial class Form4 : Form
    {
        bool flag = true;
        public Form4()
        {
            InitializeComponent();
            Random rnd= new Random();
            string id = rnd.Next(999999).ToString().PadLeft(6, '0');
            textBox4.Text = id;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label8.Visible= false;
                label9.Visible= false;
                textBox3.Visible= false;
                textBox7.Visible= false;
                label3.Visible= true;
                label4.Visible= true;
                label6.Visible= true;
                textBox5.Visible= true;
                textBox6.Visible= true;
                dateTimePicker1.Visible= true;
                label11.Visible=true;
                maskedTextBox1.Visible= true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label8.Visible = true;
                label9.Visible = true;
                textBox3.Visible = true;
                textBox7.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                dateTimePicker1.Visible = false;
                label11.Visible = false;
                maskedTextBox1.Visible= false;
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag == true)
            {
                Application.Exit();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag= false;
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }


    }
}
