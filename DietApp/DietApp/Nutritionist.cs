using System;
using System.Collections.Generic;
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

        public void createNewplan(DietRequirements plan, BMI bmi)
        {
            //program data
            DatabaseManager.updateData("insert into program(patient_id,type_of_diet," +
            "meals," +
            "reason_to_diet,desired_weight,weeks_of_dieting," +
            "hours_of_sleep,hours_of_excersise) " +
            "values('" + plan.patient_id + "','" + plan.type_of_diet +
            "','" + plan.meal_string +
            "','" + plan.reason_to_diet + "','" + plan.desired_weight + "','" + plan.weeks_of_dieting +
            "','" + plan.hours_of_sleep + "','" + plan.hours_of_excersise + "')");

            //bmi data
            DatabaseManager.updateData("insert into bmi(patient_id, bmi_of_patient, age, weight, height) values " +
                "('" + bmi.patient_id + "','" + bmi.compute_BMI() + "','" + bmi.age + "','" + bmi.weight.ToString().Replace(",",".") + "','" + bmi.height + "')");

            //special needs data
            DatabaseManager.updateData("insert into special_needs values('" + plan.patient_id + "','" + plan.special_needs_string + "')");

            //excluding data
            DatabaseManager.updateData("insert into excluding values('" + plan.patient_id + "','" + plan.exclude_string + "')");

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
                double kg_to_gain = program.desired_weight+bmi.weight;
                double weight_per_day = kg_to_gain / days;
                cal_intake += (weight_per_day * 3500 / 0.5);
            }
            //2 search database table (food) for appropriate foods
            string diet_type = program.type_of_diet;
            var meals = program.meal_string;
            //3 create 7 DailyProgram Objects from the foods
            //4 store the 7 DailyProgram Objects in a weekly_diet List and store it to patient object: patient.weekly_diet = weekly_diet
            //5 store the appropriate foods in database table (eating)

        }
    }
}
