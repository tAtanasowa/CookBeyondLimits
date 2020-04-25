namespace CookBeyondLimits.Services.Data.HealthAndDiets
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class HealthAndDietsService : IHealthAndDietsService
    {
        private readonly IDeletableEntityRepository<HealthAndDiet> healthAndDietsRepository;

        public HealthAndDietsService(IDeletableEntityRepository<HealthAndDiet> healthAndDietsRepository)
        {
            this.healthAndDietsRepository = healthAndDietsRepository;
        }

        public async Task CreateAllAsync(string[] healthAndDietTypes)
        {
            foreach (var healthAndDietType in healthAndDietTypes)
            {
                var healthAndDiet = new HealthAndDiet
                {
                    Type = healthAndDietType,
                };

                await this.healthAndDietsRepository.AddAsync(healthAndDiet);
            }

            await this.healthAndDietsRepository.SaveChangesAsync();
        }
    }
}
