namespace CookBeyondLimits.Services.Data.CookingStyles
{
    using System.Threading.Tasks;

    public interface ICookingStylesService
    {
        Task CreateAllAsync(string[] cookingStyleTypes);
    }
}
