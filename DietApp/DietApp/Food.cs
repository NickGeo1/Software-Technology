using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public class Food
    {
        public string foodname      {get;}
        public double kcal          {get;}
        public double fats          {get;}
        public double protein       {get;}
        public double carbohydrates {get;}
        public bool is_snack        {get;}
        public string diet          {get;}
        public List<string> includes { get; } //Will contain some of the values of the "Excluding" checkboxes

        public Food(string foodname, double kcal, double fats, double protein, double carbs, int is_snack, string diet, List<string> includes)
        {
            this.foodname = foodname;
            this.kcal = kcal;
            this.fats = fats;
            this.protein = protein;
            carbohydrates = carbs;
            this.is_snack = is_snack == 0 ? false : true; //return is_snack as boolean
            this.diet = diet;
            this.includes = includes;
        }
    }
}
