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

        public void createNewplan()
        {

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
