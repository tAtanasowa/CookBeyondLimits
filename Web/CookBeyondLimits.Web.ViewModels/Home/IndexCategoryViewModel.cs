namespace CookBeyondLimits.Web.ViewModels.Home
{
    using CookBeyondLimits.Data.Models;
    using CookBeyondLimits.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int RecipesCount { get; set; }

        public string Url => $"/{this.Name.Replace(' ', '-')}";
    }
}