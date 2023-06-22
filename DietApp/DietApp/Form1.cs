using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DietApp
{

    public partial class Form1 : Form
    {
        List<string> btn1 = new List<string>() { "enter (1).png", "enter.png" };
        public static string user_type;

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false; 
            radioButton2.Checked= true;
            panel1.Visible= false;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked) //patient login
            {
                user_type = radioButton2.Text;
                Users.Login(this, radioButton2.Text);
            }
            else //nutritionist login
            {
                user_type = radioButton1.Text;
                //user is Nutritionist object if login is successful, else null
                Users nutritionist = Users.Login(this, radioButton1.Text, maskedTextBox1.Text, textBox2.Text);
                Diet.active_user = (Nutritionist)nutritionist;
            }

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/" + btn1[1]);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/" + btn1[0]);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Show();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();

            }
        }
    }

    public static class Diet
    {
        public static Nutritionist active_user;
    }
}
