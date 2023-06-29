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

        //Not functional yet
        public void registerNewnutritionist()
        {

        }

        public void createNewplan(DietRequirements plan, BMI bmi, string boolean_special_needs, string boolean_exclude)
        {
            List<List<string>> list = DatabaseManager.returnData("select patient_id from program where patient_id='" + plan.patient_id + "'");
            if (list == null)
            {
                //program data
                DatabaseManager.updateData("insert into program(patient_id,type_of_diet,meals,reason_to_diet,desired_weight,weeks_of_dieting,hours_of_sleep,hours_of_excersise,sex) " +
                "values('" + plan.patient_id + "','" + plan.type_of_diet +"','" + plan.meal_string +"','" + plan.reason_to_diet + "','" + plan.desired_weight + "','" + plan.weeks_of_dieting +"','" + plan.hours_of_sleep + "','" + plan.hours_of_excersise + "','" + bmi.patient_sex + "')");

                //bmi data
                DatabaseManager.updateData("insert into bmi(patient_id, bmi_of_patient, age, weight, height) values " +
                "('" + bmi.patient_id + "','" + bmi.compute_BMI() + "','" + bmi.age + "','" + bmi.weight.ToString().Replace(",", ".") + "','" + bmi.height + "')");

                //special needs data
                DatabaseManager.updateData("insert into special_needs values('" + plan.patient_id + "','" + boolean_special_needs + "')");

                //excluding data
                DatabaseManager.updateData("insert into excluding values('" + plan.patient_id + "','" + boolean_exclude + "')");
            }
            else
            {
                // program data update
                DatabaseManager.updateData("UPDATE program SET type_of_diet = '" + plan.type_of_diet + "', meals = '" + plan.meal_string + "', reason_to_diet = '" + plan.reason_to_diet + "', desired_weight = '" + plan.desired_weight + "', weeks_of_dieting = '" + plan.weeks_of_dieting + "', hours_of_sleep = '" + plan.hours_of_sleep + "', hours_of_excersise = '" + plan.hours_of_excersise + "', sex = '" + bmi.patient_sex + "' WHERE patient_id = '" + plan.patient_id + "'");

                // bmi data update
                DatabaseManager.updateData("UPDATE bmi SET bmi_of_patient = '" + bmi.compute_BMI() + "', age = '" + bmi.age + "', weight = '" + bmi.weight.ToString().Replace(",", ".") + "', height = '" + bmi.height + "' WHERE patient_id = '" + bmi.patient_id + "'");

                // special needs data update
                List<string> string_list= boolean_special_needs.Split(',').ToList();
                DatabaseManager.updateData("UPDATE special_needs SET cancer = '" + int.Parse(string_list[0]) + "', diabetes = '" + int.Parse(string_list[1]) + "', hyperthyroidism = '" + int.Parse(string_list[2]) + "', hypothyroidism = '" + int.Parse(string_list[3]) + "', high_blood_cholesterol = '" + int.Parse(string_list[4]) + "', high_blood_sugar = '" + int.Parse(string_list[5]) + "', pregnancy = '" + int.Parse(string_list[6]) + "', breastfeeding = '" + int.Parse(string_list[7]) + "', cardiovascular_diseases = '" + int.Parse(string_list[8]) + "', osteoporosis = '" + int.Parse(string_list[9]) + "' WHERE patient_id = '" + plan.patient_id + "'");

                // excluding data update
                string_list = boolean_exclude.Split(',').ToList();
                DatabaseManager.updateData("UPDATE excluding SET fish = '" + int.Parse(string_list[0]) + "', diary = '" + int.Parse(string_list[1]) + "', wheat = '" + int.Parse(string_list[2]) + "', egg = '" + int.Parse(string_list[3]) + "', tree_nuts = '" + int.Parse(string_list[4]) + "', peanuts = '" + int.Parse(string_list[5]) + "', crustacean_shellfish = '" + int.Parse(string_list[6]) + "', soybeans = '" + int.Parse(string_list[7]) + "', sesame = '" + int.Parse(string_list[8]) + "', mushrooms = '" + int.Parse(string_list[9]) + "' WHERE patient_id = '" + plan.patient_id + "'");

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
                cal_intake = 1.2 * bmr;
            }
            else if(program.hours_of_excersise < 10)
            {
                cal_intake = 1.375 * bmr;
            }
            else if(program.hours_of_excersise<15)
            {
                cal_intake= 1.55*bmr;
            }
            else if (program.hours_of_excersise<20)
            {
                cal_intake= 1.725*bmr;
            }
            else 
            {
                cal_intake=1.9*bmr;
            }
            int days = program.weeks_of_dieting * 7;
            if (program.reason_to_diet == "Weight Loss")
            {
                double kg_to_lose = bmi.weight - program.desired_weight;
                double weight_per_day = kg_to_lose / days;
                cal_intake -= (weight_per_day * 3500 / 0.5);
            }
            else if (program.reason_to_diet == "Weight Gain") 
            {
                double kg_to_gain = program.desired_weight - bmi.weight;
                double weight_per_day = kg_to_gain / days;
                cal_intake += (weight_per_day * 3500 / 0.5);
            }

            //2 search database table (food) for appropriate food
            string[] exclude = program.exclude_string.Split(',');
            string[] meals=program.meal_string.Split(',');
            List<string> exclude_list = exclude.ToList();

            List<string> meals_fromDB = new List<string> ();
            List<List<string>> result_table=DatabaseManager.returnData("select foodname,includes from food where is_snack='0'and diet='" + program.type_of_diet+"'");
            for(int i = 0; i < result_table.Count; i++)
            {
                bool flag = false;
                int j = 0;
                while (!flag || j < exclude_list.Count-1)
                {
                    flag = result_table[i][1].Contains(exclude_list[j]);
                    j++;
                }
                if (!flag)
                {
                    meals_fromDB.Add(result_table[i][0]);
                }
            }
            
            //and appropriate snacks
            List<string> snack_fromDB = new List<string>();
            result_table = DatabaseManager.returnData("select foodname,includes from food where is_snack='1'and diet='" + program.type_of_diet + "'");
            for (int i = 0; i < result_table.Count; i++)
            {
                bool flag = false;
                int j = 0;
                while (!flag || j < exclude_list.Count-1)
                {
                    flag = result_table[i][1].Contains(exclude_list[j]);
                    j++;
                }
                if (!flag)
                {
                    snack_fromDB.Add(result_table[i][0]);
                }
            }

            //3 create 7 DailyProgram Objects from the foods
            List<string> week_days= new List<string>() {"Monday", "Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };
            string breakfast_name="";
            string lunch_name = "";
            string snack_name = "";
            string dinner_name = "";
            double estimated_intake = 0;
            int rnd;
            if (!program.meal_string.Contains("Breakfast")) { breakfast_name = "-"; }
            if (!program.meal_string.Contains("Lunch")) { lunch_name = "-"; }
            if (!program.meal_string.Contains("Snack")) { snack_name = "-"; }
            if (!program.meal_string.Contains("Dinner")) { dinner_name = "-"; }

            List<List<string>> breakfast_table= new List<List<string>>();
            List<List<string>> lunch_table= new List<List<string>>();
            List<List<string>> dinner_table= new List<List<string>>();
            List < List<string>> snack_table= new List<List<string>>();

            List<DailyProgram> weekly_diet = new List<DailyProgram>();

            for (int i = 0; i <= 6; i++)
            {
                bool flag = false;
                while (!flag)
                {
                    if (!(breakfast_name.Equals("-")))
                    {
                        rnd = random.Next(0, meals_fromDB.Count);
                        breakfast_table = DatabaseManager.returnData("select foodname,kcal,fats,protein,carbs,includes from food where foodname='" + meals_fromDB[rnd] + "'");
                        estimated_intake += int.Parse(breakfast_table[0][1]);
                        breakfast_name = breakfast_table[0][0];
                    }
                    if (!(lunch_name.Equals("-"))) {
                        rnd = random.Next(0, meals_fromDB.Count);
                        lunch_table = DatabaseManager.returnData("select foodname,kcal,fats,protein,carbs,includes from food where foodname='" + meals_fromDB[rnd] + "'");
                        estimated_intake += int.Parse(lunch_table[0][1]);
                        lunch_name = lunch_table[0][0];
                    }
                    if (!(dinner_name.Equals("-"))) {
                        rnd = random.Next(0, meals_fromDB.Count);
                        dinner_table = DatabaseManager.returnData("select foodname,kcal,fats,protein,carbs,includes from food where foodname='" + meals_fromDB[rnd] + "'"); 
                        estimated_intake += int.Parse(dinner_table[0][1]);
                        dinner_name = dinner_table[0][0];
                    }   
                    if (!(snack_name.Equals("-"))) {
                        rnd = random.Next(0, snack_fromDB.Count);
                        snack_table = DatabaseManager.returnData("select foodname,kcal,fats,protein,carbs,includes from food where foodname='" + snack_fromDB[rnd] + "'");
                        estimated_intake += int.Parse(snack_table[0][1]);
                        lunch_name = lunch_table[0][0];
                    }
                    if (Math.Abs(estimated_intake - cal_intake) <= 100)
                    {
                        flag = true;  
                    }
                }
                Food breakfast= null;
                Food lunch = null;
                Food dinner = null;
                Food snack = null;

                if (!(breakfast_name.Equals("-"))) { 
                    breakfast = new Food(breakfast_name, double.Parse(breakfast_table[0][1]), double.Parse(breakfast_table[0][2]), double.Parse(breakfast_table[0][3]), double.Parse(breakfast_table[0][4]), 0, program.type_of_diet,breakfast_table[0][5].Split(',').ToList());
                }
                if (!(lunch_name.Equals("-")))
                {
                    lunch = new Food(lunch_name, double.Parse(lunch_table[0][1]), double.Parse(lunch_table[0][2]), double.Parse(lunch_table[0][3]), double.Parse(lunch_table[0][4]), 0, program.type_of_diet, lunch_table[0][5].Split(',').ToList());
                }
                if (!(dinner_name.Equals("-")))
                {
                    dinner = new Food(dinner_name, double.Parse(dinner_table[0][1]), double.Parse(dinner_table[0][2]), double.Parse(dinner_table[0][3]), double.Parse(dinner_table[0][4]), 0, program.type_of_diet, dinner_table[0][5].Split(',').ToList());
                }
                if (!(snack_name.Equals("-")))
                {
                    snack = new Food(snack_name, double.Parse(snack_table[0][1]), double.Parse(snack_table[0][2]), double.Parse(snack_table[0][3]), double.Parse(snack_table[0][4]), 0, program.type_of_diet, snack_table[0][5].Split(',').ToList());
                }
                //4 store the 7 DailyProgram Objects in a weekly_diet List and store it to patient object: patient.weekly_diet = weekly_diet
                DailyProgram new_program = new DailyProgram(week_days[i], breakfast, lunch, snack, dinner, program.patient_id);
                weekly_diet.Add(new_program);
                string ConcatenatedString = string.Join(",", new_program.patient_id.ToString(),new_program.day);
                //5 store the appropriate foods in database table (eating)
                List<List<string>> list = DatabaseManager.returnData("select id_and_day from eating where patient_id='" + new_program.patient_id + "'");
                if (list == null)
                {
                    DatabaseManager.updateData("insert into eating(day, breakfast, lunch, snack, dinner, patient_id, id_and_day) values('" + new_program.day + "','" + new_program.breakfast + "','" + new_program.lunch + "','" + new_program.snack + "','" + new_program.dinner + "','" + new_program.patient_id + "','" + ConcatenatedString + "')");
                }
                else
                {
                    DatabaseManager.updateData("UPDATE eating SET breakfast = '" + new_program.breakfast + "', lunch = '" + new_program.lunch + "', snack = '" + new_program.snack + "', dinner = '" + new_program.dinner + "'WHERE day = '" + new_program.day + "' AND patient_id = '" + new_program.patient_id + "'");
                }
            }

            patient.weekly_diet = weekly_diet;
        }
    }
}
