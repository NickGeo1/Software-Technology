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

        public Form5(string patient_id)
        {
            InitializeComponent();
            connstr = GetConnectionString();
            maskedTextBox2.Text = patient_id;

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

        //Takes a list of checkboxes and returns which are checked and which not
        private List<int> returnChecked(List<CheckBox> all)
        {
            List<int> are_checked = new List<int>(); //bool list to specify which checkboxes are checked
            all.ForEach(cb =>
            {
                if (cb.Checked)
                    are_checked.Add(1);
                else
                    are_checked.Add(0);
            });

            return are_checked;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            string connection_string = connstr;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;
            con.Open();
            var diet = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var reason = panel3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            //lists of all panel checkboxes. Each list is sorted by the checkbox tag
            var exclude_all = panel2.Controls.OfType<CheckBox>().OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();
            var meals_all = panel4.Controls.OfType<CheckBox>().OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();
            var special_needs_all = panel5.Controls.OfType<CheckBox>().OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();

            //binary values seperated with "','" for seperate insertion or "," for mass insertion
            string exclude_string = String.Join("','", returnChecked(exclude_all));
            string meals_string = String.Join(",", returnChecked(meals_all));
            string special_needs_string = String.Join("','", returnChecked(special_needs_all));

            //program data
            MySqlCommand cmd = new MySqlCommand("insert into program" +
            "(patient_id,type_of_diet," +
            "meals," +
            "reason_to_diet,desired_weight,weeks_of_dieting," +
            "hours_of_sleep,hours_of_excersise) " +
            "values('" + maskedTextBox2.Text + "','" + diet.Text.ToString() +
            "','" + meals_string +
            "','" + reason.Text.ToString() + "','" + maskedTextBox5.Text.Replace(",", ".") + "','" + maskedTextBox6.Text +
            "','" + maskedTextBox7.Text + "','" + maskedTextBox8.Text + "')", con);

            //bmi data
            MySqlCommand cmd2 = new MySqlCommand("insert into bmi(patient_id, bmi_of_patient, age, weight, height) values " +
                "('" + maskedTextBox2.Text + "','" + textBox6.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox3.Text.Replace(",",".") + "','" + maskedTextBox4.Text + "')",con);

            //special needs data
            string query = "insert into special_needs values('"+ maskedTextBox2.Text + "','" + special_needs_string + "')";
            MySqlCommand cmd3 = new MySqlCommand(query,con);

            //excluding data
            string query2 = "insert into excluding values('" + maskedTextBox2.Text + "','" + exclude_string + "')";
            MySqlCommand cmd4 = new MySqlCommand(query2, con);

            cmd.ExecuteReader();
            con.Close();

            con.Open();
            cmd2.ExecuteReader();
            con.Close();

            con.Open();
            cmd3.ExecuteReader();
            con.Close();

            con.Open();
            cmd4.ExecuteReader();
            con.Close();

            MessageBox.Show("Successfuly created patient program!");

            flag = false;
            this.Close();
            new Form2().Show(); //go back to main menu

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
