namespace CookBeyondLimits.Services.Data.Cuisines
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class CuisineService : ICuisineService
    {
        private readonly IDeletableEntityRepository<Cuisine> cuisineRepository;

        public CuisineService(IDeletableEntityRepository<Cuisine> cuisineRepository)
        {
            this.cuisineRepository = cuisineRepository;
        }

        public async Task CreateAllAsync(string[] cuisineTypes)
        {
            foreach (var cuisineType in cuisineTypes)
            {
                var cuisine = new Cuisine
                {
                    Type = cuisineType,
                };

                await this.cuisineRepository.AddAsync(cuisine);
            }

            await this.cuisineRepository.SaveChangesAsync();
        }
    }
}
