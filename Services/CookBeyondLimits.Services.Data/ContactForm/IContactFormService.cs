namespace CookBeyondLimits.Services.Data.ContactForm
{
    using System.Threading.Tasks;

    public interface IContactFormService
    {
        Task Create(string name, string email, string title, string content);
    }
}
