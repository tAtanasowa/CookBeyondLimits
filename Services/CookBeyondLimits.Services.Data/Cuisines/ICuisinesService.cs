namespace CookBeyondLimits.Services.Data.Cuisines
{
    using System.Threading.Tasks;

    public interface ICuisinesService
    {
        Task CreateAllAsync(string[] cuisineTypes);
    }
}
