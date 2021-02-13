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
        private readonly ICategoryService categoryService;
        private readonly IApplicationService applicationService;

        public ShortcutsController(
            IShortcutService shortcutService,
            ICategoryService categoryService,
            IApplicationService applicationService)
        {
            this.shortcutService = shortcutService;
            this.categoryService = categoryService;
            this.applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            // TODO: use services
            var categories = this.categoryService.ListAll();
            var applications = this.applicationService.ListAll();

            var vm = new ShortcutCreateInputModel
            {
                // TODO: ????????????
                Categories = (List<Category>)categories,
                Applications = (List<Application>)applications,
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
