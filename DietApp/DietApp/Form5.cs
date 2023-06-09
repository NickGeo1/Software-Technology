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
    public partial class Form5 : Form
    {
        double weight = 0;
        double height = 0;
        double bmi = 0;
        bool flag = true;
        public Form5()
        {

            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel5.BackColor= Color.FromArgb(150, 250, 235, 215);
            label15.BackColor = Color.FromArgb(150, 250, 235, 215);
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag==true)
            {
                Application.Exit();

            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void maskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox4.Text != null && maskedTextBox4.Text != "0")
            {
                weight = Int32.Parse(maskedTextBox3.Text);
                height = Int32.Parse(maskedTextBox4.Text);
                bmi = weight / Math.Pow(height / 100, 2);
                bmi = Math.Ceiling(bmi);
                textBox6.Text = bmi.ToString();
            }
        }

        private void maskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (maskedTextBox3.Text != null && maskedTextBox3.Text != "0")
            {
                weight = Int32.Parse(maskedTextBox3.Text);
                height = Int32.Parse(maskedTextBox4.Text);
                bmi = weight / Math.Pow(height / 100, 2);
                bmi = Math.Ceiling(bmi);
                textBox6.Text = bmi.ToString();
            }
        }
    }
}
