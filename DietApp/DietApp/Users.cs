using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DietApp.Properties;
namespace DietApp
{
    public class Users
    {
        public string id { get; }
        public string first_name { get; }
        public string last_name { get; }

        public Users(string id, string first_name, string last_name)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;

        }

        public static Users Login(Form1 form1, string role, string id = "", string password = "")
        {
            if (role.Equals("Nutritionist"))
            {
                //returns a single row with 2 columns or nothing
                List<List<string>> result_table = DatabaseManager.returnData("select First_name,Last_name from nutritionist where id='" + id + "' and password='" + password + "'");

                if (result_table.Count != 0)
                {
                    form1.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();

                    return new Nutritionist(id, result_table[0][0], result_table[0][1]);
                }
                else
                {
                    MessageBox.Show("Sorry wrong id or password. Please type your correct id and password");
                    return null;
                }

            }
            else //else role = Patient
            {
                form1.Hide();
                Form3 form3 = new Form3();
                form3.Show();

                return null;
            }
        }

        public static void viewPlan(string patient_id)
        {
            Patient patient = null;

            if (Diet.active_user == null) //patient is viewing plan
            {
                List<List<string>> result_table = DatabaseManager.returnData("select * from patient where id='" + patient_id + "'");

                if (result_table.Count == 0)
                {
                    MessageBox.Show("Patient with id " + patient_id + " not found");
                    return;
                }

                patient = new Patient(result_table[0][0], result_table[0][1], result_table[0][2], result_table[0][3], int.Parse(result_table[0][4]), DateTime.Parse(result_table[0][5]), result_table[0][6], result_table[0][7]);
            }
            else //Nutritionist is viewing plan
            {
                patient = Diet.active_user.registeredPatients.Find(p => p.id.Equals(patient_id));

                if (patient == null)
                {
                    MessageBox.Show("Patient with id " + patient_id + " not found");
                    return;
                }

            }

            if (patient.weekly_diet.Count == 0)
            {
                MessageBox.Show("Patient with id " + patient_id + " does not have weekly diet yet");
                return;
            }
            else
            {
                //2 Iterate weekly_diet list and use all the 7 DailyProgram objects to print the plan
                Form3.Monday = patient.weekly_diet[0];
                Form3.Tuesday = patient.weekly_diet[1];
                Form3.Wednesday = patient.weekly_diet[2];
                Form3.Thursday = patient.weekly_diet[3];
                Form3.Friday = patient.weekly_diet[4];
                Form3.Saturday = patient.weekly_diet[5];
                Form3.Sunday = patient.weekly_diet[6];
                

            }
        }
    }
}
