namespace CookBeyondLimits.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CookBeyondLimits.Services.Data.HealthAndDiets;

    using Microsoft.Extensions.DependencyInjection;

    internal class HealthAndDietsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.HealthAndDiets.Any())
            {
                return;
            }

            var healthAndDietService = serviceProvider.GetRequiredService<IHealthAndDietsService>();

            var healthAndDietTypes = new string[]
            {
                "Easy & Healthy",
                "Healthy Desserts",
                "Diabetic",
                "Dairy Free",
                "Gluten Free",
                "Weight-Loss",
                "High Fiber",
                "Low Calorie",
                "Low Carb",
                "Low Fat",
            };

            await healthAndDietService.CreateAllAsync(healthAndDietTypes);
        }
    }
}
