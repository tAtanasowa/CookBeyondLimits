namespace CookBeyondLimits.Services.Data.Allergens
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class AllergenService : IAllergenService
    {
        private readonly IRepository<Allergen> allergenRepository;

        public AllergenService(IRepository<Allergen> allergenRepository)
        {
            this.allergenRepository = allergenRepository;
        }

        public async Task CreateAllAsync(string[] allergenNames)
        {
            foreach (var allergenName in allergenNames)
            {
                var allergen = new Allergen
                {
                    Name = allergenName,
                };

                await this.allergenRepository.AddAsync(allergen);
            }

            await this.allergenRepository.SaveChangesAsync();
        }
    }
}
