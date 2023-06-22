using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class DietProgram
    {
        public string patient_id { get; }
        public string type_of_diet { get; }
        public string meal_string { get; }
        public string reason_to_diet { get; }
        public double desired_weight { get; }
        public int weeks_of_dieting { get; }
        public int hours_of_sleep { get; }
        public int hours_of_excersise { get; }
        public string exclude_string { get;  }
        public string special_needs_string { get; }

        public DietProgram(string patient_id, string type_of_diet, string meal_string ,string reason_to_diet, double desired_weight, 
            int weeks_of_dieting, int hours_of_sleep, int hours_of_excersise, string exclude_string, string special_needs_string)
        {
            this.patient_id = patient_id;
            this.type_of_diet = type_of_diet;
            this.meal_string = meal_string;
            this.reason_to_diet = reason_to_diet;
            this.desired_weight = desired_weight;
            this.weeks_of_dieting = weeks_of_dieting;
            this.hours_of_sleep = hours_of_sleep;
            this.hours_of_excersise = hours_of_excersise;
            this.exclude_string = exclude_string;
            this.special_needs_string = special_needs_string;
        }

    }
}
