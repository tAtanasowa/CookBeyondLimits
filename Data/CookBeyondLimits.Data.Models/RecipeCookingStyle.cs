namespace CookBeyondLimits.Data.Models
{
    public class RecipeCookingStyle
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int CookingStyleId { get; set; }

        public virtual CookingStyle CookingStyle { get; set; }
    }
}
