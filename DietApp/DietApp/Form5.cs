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
        public Form5()
        {

            InitializeComponent();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text!=null && textBox3.Text!="0") {
                weight = Int32.Parse(textBox2.Text);
                height = Int32.Parse(textBox3.Text);
                bmi = weight / Math.Pow(height / 100, 2);
                bmi = Math.Ceiling(bmi);
                textBox6.Text= bmi.ToString();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text != "0")
            {
                weight = Int32.Parse(textBox2.Text);
                height = Int32.Parse(textBox3.Text);
                bmi = weight / Math.Pow(height / 100,2);
                bmi=Math.Ceiling(bmi);
                textBox6.Text = bmi.ToString();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel5.BackColor= Color.FromArgb(150, 250, 235, 215);
            label15.BackColor = Color.FromArgb(150, 250, 235, 215);
        }
    }
}
