namespace CookBeyondLimits.Services.Data.Allergens
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class AllergensService : IAllergensService
    {
        private readonly IRepository<Allergen> allergensRepository;

        public AllergensService(IRepository<Allergen> allergensRepository)
        {
            this.allergensRepository = allergensRepository;
        }

        public async Task CreateAllAsync(string[] allergenNames)
        {
            foreach (var allergenName in allergenNames)
            {
                var allergen = new Allergen
                {
                    Name = allergenName,
                };

                await this.allergensRepository.AddAsync(allergen);
            }

            await this.allergensRepository.SaveChangesAsync();
        }
    }
}
