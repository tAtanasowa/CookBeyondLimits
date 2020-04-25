namespace CookBeyondLimits.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using CookBeyondLimits.Data.Models;
    using CookBeyondLimits.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RecipeInCategoryViewModel> Recipes { get; set; }
    }
}
