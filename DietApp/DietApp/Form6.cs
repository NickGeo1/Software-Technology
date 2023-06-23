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
using System.Configuration;

namespace DietApp
{
    public partial class Form6 : Form
    {
        bool flag = true;
        private static string connstr;
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Diet.active_user.searchPatient(label3, label5, label4, panel1, maskedTextBox1.Text);
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
