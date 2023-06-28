using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class DailyProgram
    {
        public string day { get; }
        public Food breakfast { get; }
        public Food lunch { get; }
        public Food snack { get; }
        public Food dinner { get; }
        public string patient_id { get; }

        public DailyProgram(string day, Food breakfast, Food lunch, Food snack, Food dinner, string patient_id)
        {
            this.day = day;
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.snack = snack;
            this.dinner = dinner;
            this.patient_id = patient_id;
        }
    }
}
