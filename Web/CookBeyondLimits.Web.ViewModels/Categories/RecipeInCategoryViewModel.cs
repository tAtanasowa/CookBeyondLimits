namespace CookBeyondLimits.Web.ViewModels.Categories
{
    using System.Globalization;

    using AutoMapper;
    using CookBeyondLimits.Data.Models;
    using CookBeyondLimits.Services.Mapping;

    public class RecipeInCategoryViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        private const int ShortDescriptionLength = 100;

        public string Title { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public string ShortDescription =>
                      this.Description?.Length > ShortDescriptionLength
                      ? this.Description?.Substring(0, ShortDescriptionLength) + "..."
                      : this.Description;

        public string UserUserName { get; set; }

        public string CreatedOn { get; set; }

        public int ReviewsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeInCategoryViewModel>().ForMember(
                m => m.CreatedOn,
                opt => opt.MapFrom(x => x.CreatedOn.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture)));
        }
    }
}