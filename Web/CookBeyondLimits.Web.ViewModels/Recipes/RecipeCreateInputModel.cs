namespace CookBeyondLimits.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Common;

    using Microsoft.AspNetCore.Http;

    public class RecipeCreateInputModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.RecipeTitleMaxLength, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage, MinimumLength = AttributesConstraints.RecipeTitleMinLength)]
        public string Title { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        public string Photo { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.CategoryNameMaxLength, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage, MinimumLength = AttributesConstraints.CategoryNameMinLength)]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.RecipeDescriptionMaxLength, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage, MinimumLength = AttributesConstraints.RecipeDescriptionMinLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //[MaxLength(1000)]
        //public string Notes { get; set; }

        //public Difficulty Difficulty { get; set; }

        //public int Serving { get; set; }

        //public int PreparationTimeInMinutes { get; set; }

        //public int CookingTimeInMinutes { get; set; }

        //public int CategoryId { get; set; }

        //public virtual Category Category { get; set; }

        //public int? CuisineId { get; set; }

        //public virtual Cuisine Cuisine { get; set; }

        //public int? NutritionalFactId { get; set; }

        //public virtual NutritionalFact NutritionalFact { get; set; }

        //[Required]
        //public string UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public virtual ICollection<RecipeAllergen> Allergens { get; set; }

        //public virtual ICollection<Step> Steps { get; set; }

        //public virtual ICollection<RecipeTag> Tags { get; set; }

        //public virtual ICollection<RecipeCookingStyle> CookingStyles { get; set; }

        //public virtual ICollection<RecipeHealthAndDiet> HealthAndDiets { get; set; }

        //public virtual ICollection<UserFavoriteRecipe> FavoredBy { get; set; }

        //public virtual ICollection<TestedRecipe> CookedBy { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }
    }
}
