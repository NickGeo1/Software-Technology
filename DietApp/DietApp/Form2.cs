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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Close();
                Form4 form4 = new Form4();
                form4.Show();
            }
            else if (radioButton2.Checked)
            {

            }
            else if(radioButton3.Checked)
            {   
                this.Close();
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {

            }
        }
    }
}
