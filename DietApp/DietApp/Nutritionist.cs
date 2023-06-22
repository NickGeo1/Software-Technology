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
    }
}
