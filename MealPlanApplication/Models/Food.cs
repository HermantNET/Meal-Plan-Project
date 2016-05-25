using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanApplication.Models
{
    public class Food
    {
        public int FoodID { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }


        public bool Carbohydrate { get; set; }

        public bool Protein { get; set; }

        public bool Fat { get; set; }


        public bool Breakfast { get; set; }

        public bool Lunch { get; set; }

        public bool Dinner { get; set; }

        public bool Snack { get; set; }
    }
}
