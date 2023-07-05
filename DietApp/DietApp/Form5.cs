using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace DietApp
{
    public partial class Form5 : Form
    {
        List<string> PANEL2 = new List<string>() { };
        double weight = 0;
        double height = 0;
        bool flag = true;
        double bmr = 0;

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
            if (flag == true)
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
            if (!maskedTextBox3.Text.Equals("000.00") && !maskedTextBox4.Text.Equals("000"))
            {
                string weight_st=maskedTextBox3.Text;
                weight = Double.Parse(weight_st);
                height = Int32.Parse(maskedTextBox4.Text);
                var selected_but = panel6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                var sex = selected_but.Text;
                patient_bmi = new BMI(maskedTextBox2.Text, sex.ToString(), int.Parse(maskedTextBox1.Text), weight, height);
                textBox6.Text = patient_bmi.compute_BMI().ToString();
                bmr = patient_bmi.compute_BMR();
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBox3.Text.Equals("000.00") && !maskedTextBox4.Text.Equals("000"))
            {
                string weight_st = maskedTextBox3.Text;
                weight = Double.Parse(weight_st);
                height = Int32.Parse(maskedTextBox4.Text);
                var selected_but = panel6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                var sex = selected_but.Text;
                patient_bmi = new BMI(maskedTextBox2.Text, sex.ToString(), int.Parse(maskedTextBox1.Text), weight, height);
                textBox6.Text = patient_bmi.compute_BMI().ToString();
                bmr = patient_bmi.compute_BMR();
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


            // check num values
            double num = 0;

            try
            {
                foreach(MaskedTextBox mt in Controls.OfType<MaskedTextBox>())
                {
                    if (!mt.Name.Equals("maskedTextBox2"))
                    {
                        num = Double.Parse(mt.Text); //try casting to double
                    }

                    //set minimum values to weight and height to avoid searching for low calories

                    if (mt.Name.Equals("maskedTextBox3") && num < 20)
                    {
                        MessageBox.Show("Weight must be at least 20 kg");
                        return;
                    }

                    if (mt.Name.Equals("maskedTextBox4") && num < 100)
                    {
                        MessageBox.Show("Height must be at least 100 cm");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Please check the number inputs and try again");
                return;
            }

            //try
            {
                var diet = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
                var reason = panel3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

                //lists of panel checkboxes. Each list is sorted by the checkbox tag
                var exclude_all = panel2.Controls.OfType<CheckBox>().OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();
                var special_needs_all = panel5.Controls.OfType<CheckBox>().OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();

                //lists of only checked checkboxes
                var exclude = exclude_all.Where(chkbox => chkbox.Checked).ToList();
                var special_needs = special_needs_all.Where(chkbox => chkbox.Checked).ToList();
                var meals = panel4.Controls.OfType<CheckBox>().Where(chkbox => chkbox.Checked).OrderBy(chkbox => int.Parse(chkbox.Tag.ToString())).ToList();

                //binary values seperated with "','" for seperate column insertion 
                string binary_exclude = String.Join("','", returnChecked(exclude_all));
                string binary_special_needs = String.Join("','", returnChecked(special_needs_all));

                //lists of checked checkbox values as strings
                string exclude_string = String.Join(",", exclude.Select(chkbox => chkbox.Text));
                string meals_string = String.Join(",", meals.Select(chkbox => chkbox.Text));
                string special_needs_string = String.Join(",", special_needs.Select(chkbox => chkbox.Text));


                DietRequirements plan = new DietRequirements(maskedTextBox2.Text, diet, meals_string, reason, double.Parse(maskedTextBox5.Text.Replace(",", ".")),
                    int.Parse(maskedTextBox6.Text), int.Parse(maskedTextBox7.Text), int.Parse(maskedTextBox8.Text), exclude_string, special_needs_string, bmr);

                Diet.active_user.createNewplan(plan, patient_bmi, binary_exclude, binary_special_needs);

                //Not functional yet
                Diet.active_user.createWeeklydiet(plan, patient_bmi, patient);
                
                MessageBox.Show("Successfuly created patient program!");

                flag = false;
                this.Close();
                new Form2().Show(); //go back to main menu
            }
            // catch(Exception ex)
            {
                //  MessageBox.Show("Something went wrong during plan making, please check your data and try again\n" + ex.Message);
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
