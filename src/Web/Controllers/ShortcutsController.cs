namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Shortcut;

    public class ShortcutsController : Controller
    {
        private readonly IShortcutService shortcutService;
        private readonly IRepository<Category, int> categoriesRepository;
        private readonly IRepository<Application, int> applicatonRepository;

        public ShortcutsController(
            IShortcutService shortcutService,
            IRepository<Category, int> categoriesRepository,
            IRepository<Application, int> applicatonRepository)
        {
            this.shortcutService = shortcutService;
            this.categoriesRepository = categoriesRepository;
            this.applicatonRepository = applicatonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // TODO: use services
            var categories = await this.categoriesRepository.ListAllAsync();
            var categoriesItems = categories.Select(x => x).OrderBy(x => x.Name).ToList();
            var applications = await this.applicatonRepository.ListAllAsync();
            var applicationsItems = applications.Select(x => x).OrderBy(x => x.Name).ToList();

            var vm = new ShortcutCreateInputModel
            {
                Categories = categoriesItems,
                Applications = applicationsItems,
            };

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShortcutCreateInputModel input)
        {
            await this.shortcutService.CreateShortcutAsync(input.ApplicationId, input.CategoryId, input.Description, input.KeyCombination);

            return this.Ok();
        }
    }
}
