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
    public partial class Form5 : Form
    {
        List<string> PANEL2 = new List<string>(){};
        double weight = 0;
        double height = 0;
        double bmi = 0;
        bool flag = true;
        private static string connstr;

        public Form5()
        {
            connstr = GetConnectionString();
            InitializeComponent();
            Console.WriteLine(maskedTextBox3.Text);
            Console.WriteLine(maskedTextBox4.Text);
        }

        private static string GetConnectionString()
        {
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            return settings[0].ConnectionString; //return App.config connection string

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

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox3.MaskFull && maskedTextBox4.MaskFull)
            {
                weight = Double.Parse(maskedTextBox3.Text);
                height = Int32.Parse(maskedTextBox4.Text);
                bmi = weight / Math.Pow(height / 100, 2);
                bmi = Math.Ceiling(bmi);
                textBox6.Text = bmi.ToString();
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox3.MaskFull && maskedTextBox4.MaskFull)
            {
                weight = Double.Parse(maskedTextBox3.Text);
                height = Int32.Parse(maskedTextBox4.Text);
                bmi = weight / Math.Pow(height / 100, 2);
                bmi = Math.Ceiling(bmi);
                textBox6.Text = bmi.ToString();
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            string connection_string = connstr;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            var diet = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var reason = panel3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var exclude = panel2.Controls.OfType<CheckBox>().Where(x => x.Checked).ToString().ToList();
            var exclude_string= String.Join(",", exclude);
            var meals = panel4.Controls.OfType<CheckBox>().Where(x => x.Checked).ToString().ToList();
            var meals_string = String.Join(",", meals);
            var special_neads = panel5.Controls.OfType<CheckBox>().Where(x => x.Checked).ToString().ToList();
            var special_needs_string = String.Join(",", special_neads);


            MySqlCommand cmd = new MySqlCommand("insert into program(patient_id ,bmi,type_of_diet," +
                "exlude,meals,special_needs," +
                "reasons_to_diet,desired_weight,weeks_of_dieting," +
                "hours_of_sleep,hours_of_excersise) " +
                "values('" + maskedTextBox2.Text + "','" + textBox6.Text + "','" + diet.Text.ToString() + 
                "','" + exclude_string + "','" + meals_string + "','" + special_needs_string + 
                "','" + reason.Text.ToString() + "','" + maskedTextBox5.Text + "','" + maskedTextBox6.Text + 
                "','" + maskedTextBox7.Text + "','" + maskedTextBox8.Text + "'", con);
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
