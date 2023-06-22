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

        public Patient(string id, string first_name, string last_name, string ssn, int postal_code, DateTime birthday, string nutritionist_id, string telephone) : base(id,first_name,last_name)
        {
            this.ssn = ssn;
            this.postal_code = postal_code;
            this.birthday = birthday.ToString("yyyy/MM/dd"); //return birthday as string in this format, in order to store it in database
            this.nutritionist_id = nutritionist_id;
            this.telephone = telephone;
        }
    }
}
