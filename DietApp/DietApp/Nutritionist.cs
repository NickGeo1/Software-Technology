using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public class Nutritionist: Users
    {
        public List<Patient> registeredPatients { get; }

        public Nutritionist(string id, string first_name, string last_name) : base(id, first_name, last_name)
        {
            this.registeredPatients = returnPatients(id);
        }

        private static List<Patient> returnPatients(string nutritionist_id)
        {
            List<Patient> patients = new List<Patient>();
            List<List<string>> result_table = DatabaseManager.returnData("select * from patient where nutritionist_id=" + nutritionist_id);

            foreach (List<string> patient_atrs in result_table) //iterate each list of patient attributes
            {
                //Add patient object to the patients list
                patients.Add(new Patient(patient_atrs[0], patient_atrs[1], patient_atrs[2], patient_atrs[3], int.Parse(patient_atrs[4]), DateTime.Parse(patient_atrs[5]), patient_atrs[6], patient_atrs[7]));
            }

            return patients;
        } 

        public void registerNewpatient(Patient patient)
        {
            DatabaseManager.updateData("insert into users(id, role) values('" + patient.id + "','patient')");

            DatabaseManager.updateData("insert into patient (id , First_name,Last_name,ssn,postal_code,birthday,nutritionist_id,telephone) values" +
            "('" + patient.id + "','" + patient.first_name + "','" + patient.last_name + "','" + patient.ssn + "','" + patient.postal_code +
            "','" + patient.birthday + "','" + Diet.active_user.id + "','" + patient.telephone + "')");

            registeredPatients.Add(patient);
        }

        public void registerNewnutritionist(String id,String first_name, String last_name,String password)
        {
            DatabaseManager.updateData("insert into users(id, role) values('" + id + "','nutritionist')");

            DatabaseManager.updateData("insert into nutritionist (id, First_name, Last_name, password) values" +
            "('" + id + "','" + first_name + "','" + last_name + "','" + password + "')");

        
        }

        public void createNewplan(DietRequirements plan, BMI bmi, string boolean_special_needs, string boolean_exclude)
        {
            List<List<string>> list = DatabaseManager.returnData("select patient_id from program where patient_id='" + plan.patient_id + "'");
            if (list.Count == 0)
            {
                //program data
                DatabaseManager.updateData("insert into program(patient_id,type_of_diet,meals,reason_to_diet,desired_weight,weeks_of_dieting,hours_of_sleep,hours_of_excersise) " +
                "values('" + plan.patient_id + "','" + plan.type_of_diet +"','" + plan.meal_string +"','" + plan.reason_to_diet + "','" + plan.desired_weight + "','" + plan.weeks_of_dieting +"','" + plan.hours_of_sleep + "','" + plan.hours_of_excersise + "')");

                //bmi data
                DatabaseManager.updateData("insert into bmi(patient_id, bmi_of_patient, age, weight, height, sex) values " +
                "('" + bmi.patient_id + "','" + bmi.compute_BMI() + "','" + bmi.age + "','" + bmi.weight.ToString().Replace(",", ".") + "','" + bmi.height + "','" + bmi.patient_sex + "')");

                //special needs data
                DatabaseManager.updateData("insert into special_needs values('" + plan.patient_id + "','" + boolean_special_needs + "')");

                //excluding data
                DatabaseManager.updateData("insert into excluding values('" + plan.patient_id + "','" + boolean_exclude + "')");
            }
            else
            {
                // program data update
                DatabaseManager.updateData("UPDATE program SET type_of_diet = '" + plan.type_of_diet + "', meals = '" + plan.meal_string + "', reason_to_diet = '" + plan.reason_to_diet + "', desired_weight = '" + plan.desired_weight + "', weeks_of_dieting = '" + plan.weeks_of_dieting + "', hours_of_sleep = '" + plan.hours_of_sleep + "', hours_of_excersise = '" + plan.hours_of_excersise + "' WHERE patient_id = '" + plan.patient_id + "'");

                // bmi data update
                DatabaseManager.updateData("UPDATE bmi SET bmi_of_patient = '" + bmi.compute_BMI() + "', age = '" + bmi.age + "', weight = '" + bmi.weight.ToString().Replace(",", ".") + "', height = '" + bmi.height + "', sex = '" + bmi.patient_sex + "' WHERE patient_id = '" + bmi.patient_id + "'");

                // special needs data update
                string clean_input = boolean_special_needs.Replace("'", "");
                List<int> string_list = clean_input.Split(',').Select(element => int.Parse(element)).ToList();
                DatabaseManager.updateData("UPDATE special_needs SET cancer = '" + string_list[0] + "', diabetes = '" + string_list[1] + "', hyperthyroidism = '" + string_list[2] + "', hyporthiroidism = '" + string_list[3] + "', high_blood_choresterol = '" + string_list[4] + "', high_blood_sugar = '" + string_list[5] + "', pregnacy = '" + string_list[6] + "', breast_feeding = '" + string_list[7] + "', cardiovascular_diseases = '" + string_list[8] + "', osteoporosis = '" + string_list[9] + "' WHERE patient_id = '" + plan.patient_id + "'");

                // excluding data update
                clean_input = boolean_exclude.Replace("'", "");
                string_list = clean_input.Split(',').Select(element => int.Parse(element)).ToList();
                DatabaseManager.updateData("UPDATE excluding SET fish = '" + string_list[0] + "', diary = '" + string_list[1] + "', wheat = '" + string_list[2] + "', egg = '" + string_list[3] + "', tree_nuts = '" + string_list[4] + "', peanuts = '" + string_list[5] + "', crustacean_shellfish = '" + string_list[6] + "', soybeans = '" + string_list[7] + "', sesame = '" + string_list[8] + "', mushrooms = '" + string_list[9] + "' WHERE patient_id = '" + plan.patient_id + "'");

            }
        }

        public void searchPatient(Label full_name, Label ssn, Label id, Panel datapanel, string patient_ssn)
        {
            full_name.Text = "Full Name: ";
            ssn.Text = "SSN: ";
            id.Text = "ID: ";

            Patient patient = registeredPatients.Find(p => p.ssn.Equals(patient_ssn));

            if (patient != null)
            {
                string fullname = patient.first_name + " " + patient.last_name;
                full_name.Text += fullname;
                ssn.Text += patient.ssn;
                id.Text += patient.id;

                datapanel.Visible = true;
            }
            else
            {
                datapanel.Visible = false;
                MessageBox.Show("No patient found with this ssn");
            }
        }

        //Not functional yet //1//
        public void createWeeklydiet(DietRequirements program, BMI bmi, Patient patient)
        {
            Random random= new Random();
            //1 check program,bmi object details
            double bmr = program.bmr;
            double cal_intake;
            if (program.hours_of_excersise < 5)
            {
                cal_intake = 1.02 * bmr;
            }
            else if(program.hours_of_excersise < 10)
            {
                cal_intake = 1.0375 * bmr;
            }
            else if(program.hours_of_excersise<15)
            {
                cal_intake= 1.055*bmr;
            }
            else if (program.hours_of_excersise<20)
            {
                cal_intake= 1.0725*bmr;
            }
            else 
            {
                cal_intake=1.09*bmr;
            }
            //int days = program.weeks_of_dieting * 7;
            /*double kg_to_reach = Math.Abs(bmi.weight - program.desired_weight);
            double weight_per_day = kg_to_reach / days;
            cal_intake -= (weight_per_day * 3500 / 0.5);*/

            //2 search database table (food) for appropriate food
            string[] exclude = program.exclude_string.Split(',');


            string like_part = exclude.Contains("") ? "" : " and includes not like '%" + exclude[0] + "%'";

            for (int i = 1; i < exclude.Length; i++)
            {
                like_part += " and includes not like '%" + exclude[i] + "%'";
            }

            //Set of diet foods with excluding ingredients absent
            List<List<string>> result_main_dishes = DatabaseManager.returnData("select foodname,kcal from food where is_snack='0' and diet='" + program.type_of_diet + "'" + like_part);
            List<List<string>> result_table_snacks = DatabaseManager.returnData("select foodname,kcal from food where is_snack='1' and diet='" + program.type_of_diet + "'" + like_part);


            List<string> week_days = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            string breakfast_name = "-";
            string lunch_name = "-";
            string snack_name = "-";
            string dinner_name = "-";

            Food breakfast = null;
            Food lunch = null;
            Food dinner = null;
            Food snack = null;

            double estimated_intake = 0;
            int rnd = 0;

            bool first_program = DatabaseManager.returnData("select id_and_day from eating where patient_id='" + patient.id + "'").Count == 0;

            for (int i = 0; i <= 6; i++)
            {
                breakfast = null;
                lunch = null;
                dinner = null;
                snack = null;

                do
                {
                    breakfast_name = "-";
                    lunch_name = "-";
                    snack_name = "-";
                    dinner_name = "-";
                    estimated_intake = 0;

                    //get random snack
                    rnd = random.Next(0, result_table_snacks.Count);
                    snack_name = result_table_snacks[rnd][0];
                    estimated_intake += double.Parse(result_table_snacks[rnd][1]);

                    //get random main dishes

                    rnd = random.Next(0, result_main_dishes.Count);
                    breakfast_name = result_main_dishes[rnd][0];
                    estimated_intake += double.Parse(result_main_dishes[rnd][1]);

                    rnd = random.Next(0, result_main_dishes.Count);
                    lunch_name = result_main_dishes[rnd][0];
                    estimated_intake += double.Parse(result_main_dishes[rnd][1]);

                    rnd = random.Next(0, result_main_dishes.Count);
                    dinner_name = result_main_dishes[rnd][0];
                    estimated_intake += double.Parse(result_main_dishes[rnd][1]);

                } while (Math.Abs(estimated_intake - cal_intake) > 300);

                // data of daily foods
                List<List<string>> daily_main_dishes = DatabaseManager.returnData("select kcal,fats,protein,corbohydrates,includes from food where foodname='" + breakfast_name + "' or foodname='" + lunch_name + "' or foodname='" + dinner_name + "'");
                List<string> daily_snack = DatabaseManager.returnData("select kcal,fats,protein,corbohydrates,includes from food where foodname='" + snack_name + "'")[0];

                //daily food objects
                snack = new Food(snack_name, double.Parse(daily_snack[0]), double.Parse(daily_snack[1]), double.Parse(daily_snack[2]), double.Parse(daily_snack[3]), 1, program.type_of_diet, daily_snack[4].Split(',').ToList());

                breakfast = new Food(breakfast_name, double.Parse(daily_main_dishes[0][0]), double.Parse(daily_main_dishes[0][1]), double.Parse(daily_main_dishes[0][2]), double.Parse(daily_main_dishes[0][3]), 0, program.type_of_diet, daily_main_dishes[0][4].Split(',').ToList());
                
                lunch = new Food(lunch_name, double.Parse(daily_main_dishes[1 % daily_main_dishes.Count][0]), double.Parse(daily_main_dishes[1 % daily_main_dishes.Count][1]), double.Parse(daily_main_dishes[1 % daily_main_dishes.Count][2]), double.Parse(daily_main_dishes[1 % daily_main_dishes.Count][3]), 0, program.type_of_diet, daily_main_dishes[1 % daily_main_dishes.Count][4].Split(',').ToList());
                
                dinner = new Food(dinner_name, double.Parse(daily_main_dishes[2 % daily_main_dishes.Count][0]), double.Parse(daily_main_dishes[2 % daily_main_dishes.Count][1]), double.Parse(daily_main_dishes[2 % daily_main_dishes.Count][2]), double.Parse(daily_main_dishes[2 % daily_main_dishes.Count][3]), 0, program.type_of_diet, daily_main_dishes[2 % daily_main_dishes.Count][4].Split(',').ToList());

                //store the 7 DailyProgram Objects in a weekly_diet List and store it to patient object: patient.weekly_diet = weekly_diet
                DailyProgram new_program = new DailyProgram(week_days[i], breakfast, lunch, snack, dinner, program.patient_id);
                patient.weekly_diet.Add(new_program);
                string ConcatenatedString = string.Join(",", new_program.patient_id.ToString(), new_program.day);
                //store the appropriate foods in database table (eating)

                if (first_program)
                {
                    DatabaseManager.updateData("INSERT into eating(day, breakfast, lunch, snack, dinner, patient_id, id_and_day) values('" + new_program.day + "','" + breakfast_name + "','" + lunch_name + "','" + snack_name + "','" + dinner_name + "','" + new_program.patient_id + "','" + ConcatenatedString + "')");
                }
                else
                {
                    DatabaseManager.updateData("UPDATE eating SET breakfast = '" + breakfast_name + "', lunch = '" + lunch_name + "', snack = '" + snack_name + "', dinner = '" + dinner_name + "'WHERE day = '" + new_program.day + "' AND patient_id = '" + new_program.patient_id + "'");
                }

            }
        }
    }
}
