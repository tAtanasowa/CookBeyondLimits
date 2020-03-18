namespace CookBeyondLimits.Data.Models
{
    public class RecipeHealthAndDiet
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int HealthAndDietId { get; set; }

        public virtual HealthAndDiet HealthAndDiet { get; set; }
    }
}
