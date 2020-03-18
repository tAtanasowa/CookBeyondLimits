namespace CookBeyondLimits.Web.Areas.Administration.Controllers
{
    using CookBeyondLimits.Common;
    using CookBeyondLimits.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
