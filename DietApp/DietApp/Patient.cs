using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.weekly_diet = getWeeklyProgram(id);
        }

        private static List<DailyProgram> getWeeklyProgram(string id)
        {
            List<DailyProgram> weekly_program = null;
            try
            {
                //1 find the 7 daily set of foods from eating table in database, using patient_id (in case patient doesnt have plan yet, they wont exist)
                List<List<string>> result_table = DatabaseManager.returnData("select * from eating where patient_id=id");
                if (!(result_table.Count > 0))
                {
                    MessageBox.Show("This patient either doesn't exist or have a plan registered");
                }
                else
                {
                    List<Food> temp = new List<Food>();
                    Food food = null;
                    //2 create all 7 DailyProgram objects, each object contains 4 Food objects (create them as well)
                    for (int i = 0; i <= 6; i++)
                    {

                        for (int j = 1; j <= 4; j++)
                        {
                            List<List<string>> food_table = DatabaseManager.returnData("select * from food where foodname='" + result_table[0][j] + "'");
                            if (food_table != null)
                            {
                                food = new Food(food_table[0][0], double.Parse(food_table[0][1]), double.Parse(food_table[0][2]), double.Parse(food_table[0][3]), double.Parse(food_table[0][4]), int.Parse(food_table[0][5]), food_table[0][6], food_table[0][7].Split(',').ToList());
                            }
                            temp[j - 1] = food;
                        }
                        //3 store the DailyProgram objects in weekly_diet list
                        weekly_program[i] = new DailyProgram(result_table[0][0], temp[0], temp[1], temp[2], temp[3], result_table[5][0]);
                    }
                }
            }
            catch (Exception exc) 
            {
            
            }
            return weekly_program;
        
        }

    }
}
