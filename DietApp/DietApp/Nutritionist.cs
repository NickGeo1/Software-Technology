using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class Nutritionist: Users
    {
        public string password { get; }

        public Nutritionist(string id, string role, string first_name, string last_name, string password) : base(id, role, first_name, last_name)
        {
            this.password = password;
        }
    }
}
