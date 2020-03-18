namespace CookBeyondLimits.Services.Data.CookingStyles
{
    using System.Threading.Tasks;

    public interface ICookingStyleService
    {
        Task CreateAllAsync(string[] cookingStyleTypes);
    }
}
