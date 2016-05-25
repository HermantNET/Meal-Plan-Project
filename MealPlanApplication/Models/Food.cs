using System;
using System.ComponentModel.DataAnnotations;

namespace MealPlanApplication.Models
{
    public class Food
    {
        [ScaffoldColumn(false)]
        public int FoodID { get; set; }

        [Display(Name = "Meal Plan ID")]
        public int MealPlanID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int Calories { get; set; }


        public bool Carbohydrate { get; set; }

        public bool Protein { get; set; }

        public bool Fat { get; set; }


        public bool Breakfast { get; set; }

        public bool Lunch { get; set; }

        public bool Dinner { get; set; }

        public bool Snack { get; set; }

        public static explicit operator Food(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
