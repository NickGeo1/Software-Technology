using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class Patient : Users
    {
        public string ssn { get; }
        public int postal_code { get; }
        public string birthday { get; }
        public string nutritionist_id { get; }
        public string telephone { get; }
        public List<DailyProgram> weekly_diet = new List<DailyProgram>() { };

        public Patient(string id, string first_name, string last_name, string ssn, int postal_code, DateTime birthday, string nutritionist_id, string telephone) : base(id,first_name,last_name)
        {
            this.ssn = ssn;
            this.postal_code = postal_code;
            this.birthday = birthday.ToString("yyyy/MM/dd"); //return birthday as string in this format, in order to store it in database
            this.nutritionist_id = nutritionist_id;
            this.telephone = telephone;
            //this.weekly_diet = retreiveWeeklyProgram(id);
        }


        //To be implemented //2//
        //1 find the 7 daily set of foods from eating table in database, using patient_id (in case patient doesnt have plan yet, they wont exist)
        //2 create all 7 DailyProgram objects, each object contains 4 Food objects (create them as well)
        //3 store the DailyProgram objects in weekly_diet list

        /*private static List<DailyProgram> retreiveWeeklyProgram(string patient_id)
        {
            List<DailyProgram> weekly_program = new List<DailyProgram>();
            List<List<string>> result_table = DatabaseManager.returnData("select * from eating where patient_id=" + patient_id);

            foreach (List<string> patient_atrs in result_table) //iterate each row
            {
                weekly_program.Add();
            }
            
            return weekly_program;
        }*/

    }
}
