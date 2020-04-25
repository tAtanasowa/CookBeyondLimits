namespace CookBeyondLimits.Services.Data.CookingStyles
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class CookingStylesService : ICookingStylesService
    {
        private readonly IDeletableEntityRepository<CookingStyle> cookingStylesRepository;

        public CookingStylesService(IDeletableEntityRepository<CookingStyle> cookingStylesRepository)
        {
            this.cookingStylesRepository = cookingStylesRepository;
        }

        public async Task CreateAllAsync(string[] cookingStyleTypes)
        {
            foreach (var cookingStyleType in cookingStyleTypes)
            {
                var cookingStyle = new CookingStyle
                {
                    Type = cookingStyleType,
                };

                await this.cookingStylesRepository.AddAsync(cookingStyle);
            }

            await this.cookingStylesRepository.SaveChangesAsync();
        }
    }
}
