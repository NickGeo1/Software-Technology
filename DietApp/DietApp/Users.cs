using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                List<List<string>> result_table = DatabaseManagement.returnData("select First_name,Last_name from nutritionist where id='" + id + "' and password='" + password + "'");

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

    }
}
