namespace CookBeyondLimits.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CookBeyondLimits.Common;
    using CookBeyondLimits.Services.Data.Categories;
    using CookBeyondLimits.Services.Data.ContactForm;
    using CookBeyondLimits.Services.Messaging;
    using CookBeyondLimits.Web.ViewModels;
    using CookBeyondLimits.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly ICategoriesService categoriesService;
        private readonly IContactFormService contactService;

        public HomeController(
            IEmailSender emailSender,
            ICategoriesService categoriesService,
            IContactFormService contactService)
        {
            this.emailSender = emailSender;
            this.categoriesService = categoriesService;
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories = this.categoriesService.GetAll<IndexCategoryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.contactService.Create(model.Name, model.Email, model.Title, model.Content);

            await this.emailSender.SendEmailAsync(
                model.Email,
                model.Name,
                GlobalConstants.SystemEmail,
                model.Title,
                model.Content);

            return this.RedirectToAction(nameof(this.ThankYou));
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
