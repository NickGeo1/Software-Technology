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
using MySql.Data.MySqlClient;

namespace DietApp
{
    public partial class Form3 : Form
    {
        // Assuming you have an instance of Form3 available or can create a new instance
        public static DailyProgram Monday = null;
        public static DailyProgram Tuesday = null;
        public static DailyProgram Wednesday = null;
        public static DailyProgram Thursday = null;
        public static DailyProgram Friday = null;
        public static DailyProgram Saturday = null;
        public static DailyProgram Sunday = null;
        bool flag = true;

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
            Users.viewPlan(maskedTextBox1.Text);
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
