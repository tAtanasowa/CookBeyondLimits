namespace CookBeyondLimits.Web.Controllers
{
    using CookBeyondLimits.Data.Common.Repositories;
    using CookBeyondLimits.Data.Models;
    using CookBeyondLimits.Web.ViewModels.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RecipesController : BaseController
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public RecipesController(IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }



        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Create(RecipeCreateInputModel recipeCreateInputModel)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(recipeCreateInputModel);
        //    }
        //}
    }
}
