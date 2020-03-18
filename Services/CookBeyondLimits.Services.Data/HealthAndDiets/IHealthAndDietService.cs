namespace CookBeyondLimits.Services.Data.HealthAndDiets
{
    using System.Threading.Tasks;

    public interface IHealthAndDietService
    {
        Task CreateAllAsync(string[] healthAndDietTypes);
    }
}
