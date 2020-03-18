namespace CookBeyondLimits.Services.Data.Categories
{
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task CreateAllAsync(string[] categoryNames);
    }
}
