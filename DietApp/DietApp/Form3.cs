using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class Form3 : Form
    {   
        bool flag = true;
        private static string connstr;

        public Form3()
        {
            InitializeComponent();

            if (Form1.user_type.Equals("Patient"))
            {
                button1.Visible= false;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag==true)
            {
                Application.Exit();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Form1.user_type.Equals("Nutritionist"))
            {
                flag= false;
                this.Close();
                Form2 form2 = new Form2(); 
                form2.Show();
            }
            else
            {
                flag = false;
                this.Close();
                Form1 form1= new Form1();
                form1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string connection_string = connstr;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from patient where id='" + maskedTextBox1.Text + "'", con);
            MySqlDataReader myreader;
            myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                string fullname = myreader["First_name"].ToString() + " " + myreader["Last_name"].ToString();
                MessageBox.Show(fullname);
            }
            else
            {
                MessageBox.Show("Patient id Not found");
            }

            con.Close();
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
