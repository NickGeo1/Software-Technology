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
        bool flag = true;

        private BMI patient_bmi;
        private Patient patient;

        public Form5(Patient patient)
        {
            InitializeComponent();
            if (patient == null)
                maskedTextBox2.Text = "000000";
            else
                maskedTextBox2.Text = patient.id;

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
                patient_bmi = new BMI(maskedTextBox2.Text, int.Parse(maskedTextBox1.Text), weight, height);
                textBox6.Text = patient_bmi.compute_BMI().ToString();
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox3.MaskFull && maskedTextBox4.MaskFull)
            {
                weight = Double.Parse(maskedTextBox3.Text);
                height = Int32.Parse(maskedTextBox4.Text);
                patient_bmi = new BMI(maskedTextBox2.Text, int.Parse(maskedTextBox1.Text), weight, height);
                textBox6.Text = patient_bmi.compute_BMI().ToString();
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
            patient = Diet.active_user.registeredPatients.Find(p => p.id.Equals(maskedTextBox2.Text));

            if (patient == null)
            {
                MessageBox.Show("There is not any registered patient with this id yet");
                return;
            }

            try
            {
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

                DietRequirements plan = new DietRequirements(maskedTextBox2.Text, diet.Text, meals_string, reason.Text, double.Parse(maskedTextBox5.Text.Replace(",", ".")),
                    int.Parse(maskedTextBox6.Text), int.Parse(maskedTextBox7.Text), int.Parse(maskedTextBox8.Text), exclude_string, special_needs_string);

                Diet.active_user.createNewplan(plan, patient_bmi);

                //Not functional yet
                Diet.active_user.createWeeklydiet(plan, patient_bmi, patient);

                MessageBox.Show("Successfuly created patient program!");

                flag = false;
                this.Close();
                new Form2().Show(); //go back to main menu
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong during plan making, please check your data and try again\n" + ex.Message);
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
