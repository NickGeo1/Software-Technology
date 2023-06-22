using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class Users
    {
        public string id { get; }
        public string role { get; }
        public string first_name { get; }
        public string last_name { get; }

        public Users(string id, string role, string first_name, string last_name)
        {
            this.id = id;
            this.role = role;
            this.first_name = first_name;
            this.last_name = last_name;

        }

    }
}
