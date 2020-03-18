namespace CookBeyondLimits.Services.Data.Cuisines
{
    using System.Threading.Tasks;

    public interface ICuisineService
    {
        Task CreateAllAsync(string[] cuisineTypes);
    }
}
