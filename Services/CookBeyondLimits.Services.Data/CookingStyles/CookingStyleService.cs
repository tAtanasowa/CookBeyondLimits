namespace CookBeyondLimits.Services.Data.CookingStyles
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class CookingStyleService : ICookingStyleService
    {
        private readonly IDeletableEntityRepository<CookingStyle> cookingStyleRepository;

        public CookingStyleService(IDeletableEntityRepository<CookingStyle> cookingStyleRepository)
        {
            this.cookingStyleRepository = cookingStyleRepository;
        }

        public async Task CreateAllAsync(string[] cookingStyleTypes)
        {
            foreach (var cookingStyleType in cookingStyleTypes)
            {
                var cookingStyle = new CookingStyle
                {
                    Type = cookingStyleType,
                };

                await this.cookingStyleRepository.AddAsync(cookingStyle);
            }

            await this.cookingStyleRepository.SaveChangesAsync();
        }
    }
}
