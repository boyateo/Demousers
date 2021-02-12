namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Category;

    public class CategoriesController : Controller
    {
        private readonly IRepository<Category, int> categoriesRepository;

        public CategoriesController(IRepository<Category, int> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriesCreateInputModel input)
        {
            var newCategory = new Category
            {
                Name = input.Name,
            };
            await this.categoriesRepository.AddAsync(newCategory);

            return this.Ok();
        }
    }
}
