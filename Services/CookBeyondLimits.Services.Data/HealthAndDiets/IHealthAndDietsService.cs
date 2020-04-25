namespace CookBeyondLimits.Services.Data.HealthAndDiets
{
    using System.Threading.Tasks;

    public interface IHealthAndDietsService
    {
        Task CreateAllAsync(string[] healthAndDietTypes);
    }
}
