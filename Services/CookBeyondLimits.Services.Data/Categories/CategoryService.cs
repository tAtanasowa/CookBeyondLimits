namespace CookBeyondLimits.Services.Data.Categories
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateAllAsync(string[] categoryNames)
        {
            foreach (var categoryName in categoryNames)
            {
                var category = new Category
                {
                    Name = categoryName,
                };

                await this.categoryRepository.AddAsync(category);
            }

            await this.categoryRepository.SaveChangesAsync();
        }
    }
}
