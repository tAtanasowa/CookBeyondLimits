namespace CookBeyondLimits.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookBeyondLimits.Services.Data.Cuisines;

    using Microsoft.Extensions.DependencyInjection;

    internal class CuisinesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cuisines.Any())
            {
                return;
            }

            var cuisineService = serviceProvider.GetRequiredService<ICuisinesService>();

            var cuisineTypes = new string[]
            {
                "Bulgarian",
                "Chinese",
                "Indian",
                "Japanese",
                "Southern",
                "Thai",
                "American",
                "French",
                "Greek",
                "Italian",
                "Mexican",
            };

            await cuisineService.CreateAllAsync(cuisineTypes);
        }
    }
}
