using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace MealPlanApplication.Models
{
    [Authorize]
    public class MealPlan
    {
        [ScaffoldColumn(false)]
        public int MealPlanID { get; set; }

        public int UserID { get; set; }

        public int FoodsID { get; set; }

        public List<Food> Foods { get; set; }

        private double totalCalories = 0;
        public object TotalCalories { get { return totalCalories; } set { double.TryParse(value.ToString(), out totalCalories); } }

        public double Carbohydrates { get { return macroRatio[0]; } set {  double.TryParse(value.ToString(), out macroRatio[0]); } }
        public double Proteins { get { return macroRatio[1]; } set { double.TryParse(value.ToString(), out macroRatio[1]); } }
        public double Fats { get { return macroRatio[2]; } set { double.TryParse(value.ToString(), out macroRatio[2]); } }
        private double[] macroRatio = { 40, 30, 30 };
        public string MacroRatio
        {
            get
            {
                string Macros = macroRatio[0] + ", " + macroRatio[1] + ", " + macroRatio[2];
                return Macros;
            }
        }
        //check to make sure macros add up to at most 100
        public void ratioCheck()
        {
            double total = 0;
            foreach (double m in macroRatio) { total += m; }
            while (total > 100)
            {
                for (var i = 0; i < 3; i++)
                {
                    macroRatio[i] -= 1;
                    total--;
                    if (total <= 100) { break; }
                }
            }
        }

        private List<string>[] myPlan { get; set; }
        public List<string>[] MyPlan { get { return myPlan; } }
        
        public void CreateMealPlan()
        {
            List<string>[] ThePlan = new List<string>[3];

            if (Foods != null) {
                //Macros
                double[] total = new double[3];
                var foods = (Foods.Select(foo => foo)).ToList();
                //seperating foods by time of day
                var breakfast = foods.Select(foo => foo.Breakfast = true).ToList();
                var lunch = foods.Select(foo => foo.Lunch = true).ToList();
                var dinner = foods.Select(foo => foo.Dinner = true).ToList();
                var snack = foods.Select(foo => foo.Snack = true).ToList();

                //number of items in each list
                int[] max = { breakfast.Count(), lunch.Count(), dinner.Count(), snack.Count() };

                //randomizer
                Random rand = new Random();


                /*************End of Variables*************/

                ratioCheck();
                for (int i = 0; i < 3; i++)
                {
                    total[i] = (((double)TotalCalories / (macroRatio[i] / 100)) / 4) - 100;
                }

                total[3] = (double)TotalCalories - total[0] + total[1] + total[2];
                
                //Generate Breakfast portion of plan
                for (int macros = 0; macros < 3; macros++)
                for (int i = 0; i < total[macros];) {
                        Food random = new Food();
                        random = (Food)breakfast.ElementAt(rand.Next(max[0]));
                        i += random.Calories;
                        ThePlan[0].Add(random.Name);
                }

                //Generate Lunch portion of plan
                for (int macros = 0; macros < 3; macros++)
                    for (int i = 0; i < total[macros];)
                    {
                        Food random = new Food();
                        random = (Food)lunch.ElementAt(rand.Next(max[1]));
                        i += random.Calories;
                        ThePlan[1].Add(random.Name);
                    }

                //Generate dinner portion of plan
                for (int macros = 0; macros < 3; macros++)
                    for (int i = 0; i < total[macros];)
                    {
                        Food random = new Food();
                        random = (Food)dinner.ElementAt(rand.Next(max[2]));
                        i += random.Calories;
                        ThePlan[2].Add(random.Name);
                    }

                //Generate snack portion of plan
                for (int macros = 0; macros < 3; macros++)
                    for (int i = 0; i < total[macros];)
                    {
                        Food random = new Food();
                        random = (Food)snack.ElementAt(rand.Next(max[3]));
                        i += random.Calories;
                        ThePlan[3].Add(random.Name);
                    }
            }

            myPlan = ThePlan;
        }
    }
}
