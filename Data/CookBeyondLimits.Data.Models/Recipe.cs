namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;
    using CookBeyondLimits.Data.Models.Enums;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Allergens = new HashSet<RecipeAllergen>();
            this.Steps = new HashSet<Step>();
            this.Tags = new HashSet<RecipeTag>();
            this.CookingStyles = new HashSet<RecipeCookingStyle>();
            this.HealthAndDiets = new HashSet<RecipeHealthAndDiet>();
            this.FavoredBy = new HashSet<UserFavoriteRecipe>();
            this.CookedBy = new HashSet<TestedRecipe>();
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Serving { get; set; }

        public int PreparationTimeInMinutes { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? CuisineId { get; set; }

        public virtual Cuisine Cuisine { get; set; }

        public int? NutritionalFactId { get; set; }

        public virtual NutritionalFact NutritionalFact { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public virtual ICollection<RecipeAllergen> Allergens { get; set; }

        public virtual ICollection<Step> Steps { get; set; }

        public virtual ICollection<RecipeTag> Tags { get; set; }

        public virtual ICollection<RecipeCookingStyle> CookingStyles { get; set; }

        public virtual ICollection<RecipeHealthAndDiet> HealthAndDiets { get; set; }

        public virtual ICollection<UserFavoriteRecipe> FavoredBy { get; set; }

        public virtual ICollection<TestedRecipe> CookedBy { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
