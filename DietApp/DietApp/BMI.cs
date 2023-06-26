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
        public string patient_sex { get; }

        public int age { get; }
        public double weight { get; }
        public double height { get; }

        public BMI(string patient_id,string sex, int age, double weight, double height)
        {
            this.patient_id = patient_id;
            this.patient_sex = sex;
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
        public double compute_BMR() 
        {
            double bmr;
            if(patient_sex=="Male")
            {
                bmr = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else 
            {
                bmr = 10 * weight + 6.25 * height - 5 * age - 161;
            }
            return bmr;
        }
    }
}
