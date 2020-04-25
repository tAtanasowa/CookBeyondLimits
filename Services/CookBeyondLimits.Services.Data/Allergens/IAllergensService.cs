namespace CookBeyondLimits.Services.Data.Allergens
{
    using System.Threading.Tasks;

    public interface IAllergensService
    {
        Task CreateAllAsync(string[] allergenNames);
    }
}
