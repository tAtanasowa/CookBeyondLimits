namespace CookBeyondLimits.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookBeyondLimits.Services.Data.Categories;

    using Microsoft.Extensions.DependencyInjection;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();

            var categoryNames = new string[]
            {
                "Breakfast & Brunch",
                "Appetizers & Snacks",
                "Salads",
                "Soups",
                "Main Dishes",
                "Side Dishes",
                "Desserts",
                "Sauces & Dressings",
                "Drinks",
            };

            await categoryService.CreateAllAsync(categoryNames);
        }
    }
}
