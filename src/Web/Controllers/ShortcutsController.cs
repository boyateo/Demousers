namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Web.Models.Shortcut;

    public class ShortcutsController : Controller
    {
        private readonly IRepository<Shortcut> repository;
        private readonly IRepository<Category> categoriesRepository;

        public ShortcutsController(IRepository<Shortcut> repository, IRepository<Category> categoriesRepository)
        {
            this.repository = repository;
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // TODO: use services
            var categories = await this.categoriesRepository.ListAllAsync();
            var items = categories.Select(x => x).OrderBy(x => x.Name).ToList();
            var vm = new ShortcutCreateInputModel
            {
                Categories = items,
            };

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShortcutCreateInputModel input)
        {
            var newShortcut = new Shortcut
            {
                Command = input.Command,
                ApplicationId = input.ApplicationId,
                CategoryId = input.CategoryId,
                Description = input.Description,
                KeyCombination = input.KeyCombination,
            };
            await this.repository.AddAsync(newShortcut);

            return this.Ok();
        }
    }
}
