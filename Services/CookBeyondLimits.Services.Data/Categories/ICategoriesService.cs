namespace CookBeyondLimits.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task CreateAllAsync(List<(string Name, string ImageUrl)> categories);

        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
