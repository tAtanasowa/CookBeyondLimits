namespace CookBeyondLimits.Services.Data.Allergens
{
    using System.Threading.Tasks;

    public interface IAllergenService
    {
        Task CreateAllAsync(string[] allergenNames);
    }
}
