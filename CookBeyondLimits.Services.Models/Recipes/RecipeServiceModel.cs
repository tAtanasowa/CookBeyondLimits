namespace CookBeyondLimits.Services.Models.Recipes
{
    using CookBeyondLimits.Data.Models;
    using CookBeyondLimits.Services.Mapping;
    using System;
    using System.Collections.Generic;

    public class RecipeServiceModel : IMapTo<Recipe>, IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Serving { get; set; }

        public int PreparationTimeInMinutes { get; set; }

        public int CookingTimeInMinutes { get; set; }

        public int CategoryId { get; set; }

        public CategoryServiceModel Category { get; set; }

        public int? CuisineId { get; set; }

        public virtual Cuisine Cuisine { get; set; }

        public int? IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public int? NutritionalFactId { get; set; }

        public virtual NutritionalFact NutritionalFact { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<RecipeAllergenServiceModel> Allergens { get; set; }

        public ICollection<Step> Steps { get; set; }

        public ICollection<RecipeTag> Tags { get; set; }

        public ICollection<RecipeCookingStyleServiceModel> CookingStyles { get; set; }

        public ICollection<RecipeHealthAndDietServiceModel> HealthAndDiets { get; set; }

        public ICollection<UserFavoriteRecipeServiceModel> FavoredBy { get; set; }

        public ICollection<TestedRecipeServiceModel> CookedBy { get; set; }

        public ICollection<ReviewServiceModel> Reviews { get; set; }
    }
}
