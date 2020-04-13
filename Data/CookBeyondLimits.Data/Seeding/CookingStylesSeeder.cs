namespace CookBeyondLimits.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookBeyondLimits.Services.Data.CookingStyles;

    using Microsoft.Extensions.DependencyInjection;

    internal class CookingStylesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CookingStyles.Any())
            {
                return;
            }

            var cookingStyleService = serviceProvider.GetRequiredService<ICookingStylesService>();

            var cookingStyleTypes = new string[]
            {
                "BBQ & Grilling",
                "Budget Cooking",
                "Cooking for Kids",
                "Cooking for Two",
                "Gourmet",
                "Quick & Easy",
                "Slow Cooker",
                "Vegetarian",
                "Vegan",
            };

            await cookingStyleService.CreateAllAsync(cookingStyleTypes);
        }
    }
}
