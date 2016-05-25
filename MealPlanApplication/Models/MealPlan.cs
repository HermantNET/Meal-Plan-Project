using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanApplication.Models
{
    public class MealPlan
    {
        public int MealPlanID { get; set; }

        public List<Food> Foods { get; set; }

        public double TotalCalories { get; set; }

        public double Carbohydrates { get { return macroRatio[0]; } set { macroRatio[0] = value; } }
        public double Proteins { get { return macroRatio[1]; } set { macroRatio[1] = value; } }
        public double Fats { get { return macroRatio[2]; } set { macroRatio[2] = value; } }
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

        private string myMealPlan;
        public string MyMealPlan
        {
            get { return myMealPlan; }
            set { if (Foods != null) {
                    double[] total = new double[2];
                    //var Breakfast = (Foods.Select(foo =>)).ToList();

                    ratioCheck();
                    for(int i = 0;i < 3; i++)
                    {
                        total[i] = TotalCalories / macroRatio[i];
                    }

                    //for (int i = 0; i < 3; i++)
                    //{
                    //    total[i]
                    //}
                }
            }
        }       
    }
}
