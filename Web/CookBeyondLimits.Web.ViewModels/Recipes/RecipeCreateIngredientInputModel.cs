namespace CookBeyondLimits.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Common;
    using CookBeyondLimits.Services.Mapping;

    public class RecipeCreateIngredientInputModel/* : IMapTo<IngredientServiceModel>*/
    {
        [Display(Name = "Ingredients")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.IngredientDescriptionMaxLength, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage, MinimumLength = AttributesConstraints.IngredientDescriptionMinLength)]
        public string Description { get; set; }
    }
}
