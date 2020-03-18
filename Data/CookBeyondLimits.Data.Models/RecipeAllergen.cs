namespace CookBeyondLimits.Data.Models
{
    public class RecipeAllergen
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int AllergenId { get; set; }

        public virtual Allergen Allergen { get; set; }
    }
}
