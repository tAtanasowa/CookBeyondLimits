namespace CookBeyondLimits.Services.Data.ContactForm
{
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;

    public class ContactFormService : IContactFormService
    {
        private readonly IRepository<ContactFormEntry> contactsRepository;

        public ContactFormService(IRepository<ContactFormEntry> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        public async Task Create(string name, string email, string title, string content)
        {
            var contactFormEntry = new ContactFormEntry
            {
                Name = name,
                Email = email,
                Title = title,
                Content = content,
            };

            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();
        }
    }
}
