using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class BMI
    {
        public string patient_id { get; }
        public int age { get; }
        public double weight { get; }
        public double height { get; }

        public BMI(string patient_id, int age, double weight, double height)
        {
            this.patient_id = patient_id;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        public double compute_BMI()
        {
            double bmi = weight / Math.Pow(height / 100, 2);
            bmi = Math.Ceiling(bmi);

            return bmi;
        }
    }
}
