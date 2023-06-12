using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
namespace DietApp
{
    public partial class Form6 : Form
    {
        bool flag = true;
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            string connection_string = "server=127.0.0.1;uid=root;pwd=autamaresoun;database=diet_app";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select id from patient where id='" + maskedTextBox1.Text + "'", con);
            MySqlDataReader myreader;
            myreader = cmd.ExecuteReader();
            string fullname = myreader["First_name"].ToString() + " " + myreader["Last_name"].ToString(); 
            string ssn = myreader["ssn"].ToString();
            string id = myreader["id"].ToString();
            label3.Text = myreader["First_name"].ToString() + " " + myreader["Last_name"].ToString();
            label5.Text = myreader["ssn"].ToString();
            label4.Text = myreader["id"].ToString();
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "Enter SSN")
            {
                maskedTextBox1.Text = "";
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                maskedTextBox1.Text = "Enter SSN";
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(maskedTextBox1.Text, @"^\d+$"))
            {
                MessageBox.Show("Please enter numbers only");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == true)
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
