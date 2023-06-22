using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class Nutritionist: Users
    {

        public Nutritionist(string id, string first_name, string last_name) : base(id, first_name, last_name)
        {

        }

        public void registerNewpatient(Patient patient)
        {
            DatabaseManager.updateData("insert into users(id, role) values('" + patient.id + "','patient')");

            DatabaseManager.updateData("insert into patient (id , First_name,Last_name,ssn,postal_code,birthday,nutritionist_id,telephone) values" +
            "('" + patient.id + "','" + patient.first_name + "','" + patient.last_name + "','" + patient.ssn + "','" + patient.postal_code +
            "','" + patient.birthday + "','" + Diet.active_user.id + "','" + patient.telephone + "')");
        }

        //Not functional yet
        public void registerNewnutritionist()
        {

        }

        public void createNewplan(DietProgram plan, BMI bmi)
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
                "('" + bmi.patient_id + "','" + bmi.compute_BMI() + "','" + bmi.age + "','" + bmi.weight + "','" + bmi.height + "')");

            //special needs data
            DatabaseManager.updateData("insert into special_needs values('" + plan.patient_id + "','" + plan.special_needs_string + "')");

            //excluding data
            DatabaseManager.updateData("insert into excluding values('" + plan.patient_id + "','" + plan.exclude_string + "')");

        }

        public void searchPatient()
        {

        }

        //Not functional yet
        public void createWeeklydiet(DietProgram program)
        {

        }
    }
}
