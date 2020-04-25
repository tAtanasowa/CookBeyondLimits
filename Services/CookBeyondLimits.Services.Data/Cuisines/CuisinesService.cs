namespace CookBeyondLimits.Services.Data.Cuisines
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class CuisinesService : ICuisinesService
    {
        private readonly IDeletableEntityRepository<Cuisine> cuisinesRepository;

        public CuisinesService(IDeletableEntityRepository<Cuisine> cuisinesRepository)
        {
            this.cuisinesRepository = cuisinesRepository;
        }

        public async Task CreateAllAsync(string[] cuisineTypes)
        {
            foreach (var cuisineType in cuisineTypes)
            {
                var cuisine = new Cuisine
                {
                    Type = cuisineType,
                };

                await this.cuisinesRepository.AddAsync(cuisine);
            }

            await this.cuisinesRepository.SaveChangesAsync();
        }
    }
}
