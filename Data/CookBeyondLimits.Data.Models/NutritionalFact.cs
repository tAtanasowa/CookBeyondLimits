namespace CookBeyondLimits.Data.Models
{
    using System;

    using CookBeyondLimits.Data.Common.Models;

    public class NutritionalFact : BaseDeletableModel<int>
    {
        public NutritionalFact()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        public double Calories { get; set; }

        public double TotalFat { get; set; }

        public double SaturatedFat { get; set; }

        public double Cholesterol { get; set; }

        public double Sodium { get; set; }

        public double Potassium { get; set; }

        public double TotalCarbohydrate { get; set; }

        public double DietaryFiber { get; set; }

        public double Sugars { get; set; }

        public double Protein { get; set; }

        public double Salt { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
