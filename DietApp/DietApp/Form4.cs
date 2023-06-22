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
using System.Configuration;

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
            try
            {
                //patient register by nutritionist
                if (radioButton1.Checked)
                {
                    Patient patient = new Patient(textBox4.Text, textBox1.Text, textBox2.Text, maskedTextBox2.Text,
                        int.Parse(maskedTextBox3.Text), dateTimePicker1.Value, Diet.active_user.id, maskedTextBox1.Text);

                    Diet.active_user.registerNewpatient(patient);

                    MessageBox.Show("Patient " + textBox4.Text + " successfuly registered!");
                    MessageBox.Show("Lets create now his diet plan!");

                    flag = false;
                    new Form5(patient.id).Show(); //pass patient id on form5
                    this.Close();
                }
                else //nutritionist register by nutritionist (TODO)
                {

                }
            }
            catch
            {
                MessageBox.Show("Something went wrong during user registration. Please check the data and try again");
            }                   
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

        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
