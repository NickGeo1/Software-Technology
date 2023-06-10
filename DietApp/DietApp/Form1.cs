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

namespace DietApp
{

    public partial class Form1 : Form
    {
        public static class Diet{
            public static string diaitologos;
        }
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
            string connection_string = "server=127.0.0.1;uid=root;pwd=autamaresoun;database=diet_app";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select id from nutritionist where id='" + maskedTextBox1.Text + "' and password='" + textBox2.Text + "'", con);
            MySqlDataReader myreader;
            myreader = cmd.ExecuteReader();
            user_type = radioButton1.Text;
            if (radioButton1.Checked)
            {
                if (myreader.Read())   
                {
                    Diet.diaitologos= myreader["id"].ToString();
                    MessageBox.Show(Diet.diaitologos.ToString());
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                    MessageBox.Show("Sorry wrong id or password. Please type your correct id and password");
            }
            else
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();
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
        public static string diaitologos;
    }
}
