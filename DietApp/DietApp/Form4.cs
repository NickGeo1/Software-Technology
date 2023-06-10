using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

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
            string connection_string = "server=127.0.0.1;uid=root;pwd=autamaresoun;database=diet_app";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into users(id, role) values('" + textBox4.Text + "','patient'", con);
            MySqlCommand cmd2 = new MySqlCommand("insert into patient (id , First_name,Last_name,ssn,postal_code,birthday,nutritionist_id,telephone) values('" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + Diet.diaitologos + "','" + maskedTextBox1.Text + "'", con);
            MySqlDataReader myreader;
            myreader = cmd.ExecuteReader();
            myreader = cmd2.ExecuteReader();
           
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
                maskedTextBox2.Visible= true;
                maskedTextBox3.Visible= true;
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
                maskedTextBox2.Visible = false;
                maskedTextBox3.Visible = false;
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

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[A-Za-z\s]+$"))
            {
                MessageBox.Show("Please enter letters only");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter letters only");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must contain at least one lowercase letter,one uppercase letter, one digit,one special character and must be at least 8 characters long");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must contain at least one lowercase letter,one uppercase letter, one digit,one special character and must be at least 8 characters long");
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if(textBox7.Text!=textBox3.Text)
            {
                MessageBox.Show("Passwords must be the same");
            }
        }
    }
}
