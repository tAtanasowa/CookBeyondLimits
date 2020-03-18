namespace CookBeyondLimits.Services.Data.HealthAndDiets
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class HealthAndDietService : IHealthAndDietService
    {
        private readonly IDeletableEntityRepository<HealthAndDiet> healthAndDietRepository;

        public HealthAndDietService(IDeletableEntityRepository<HealthAndDiet> healthAndDietRepository)
        {
            this.healthAndDietRepository = healthAndDietRepository;
        }

        public async Task CreateAllAsync(string[] healthAndDietTypes)
        {
            foreach (var healthAndDietType in healthAndDietTypes)
            {
                var healthAndDiet = new HealthAndDiet
                {
                    Type = healthAndDietType,
                };

                await this.healthAndDietRepository.AddAsync(healthAndDiet);
            }

            await this.healthAndDietRepository.SaveChangesAsync();
        }
    }
}
