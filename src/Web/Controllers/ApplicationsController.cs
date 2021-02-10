namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Web.Models.Application;
    using Web.Models.Shortcut;

    public class ApplicationsController : Controller
    {
        private readonly IRepository<Application, int> applicationsRepository;

        public ApplicationsController(IRepository<Application, int> applicationsRepository)
        {
            this.applicationsRepository = applicationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationCreateInputModel input)
        {
            var newApplication = new Application
            {
                Name = input.Name,
                Version = input.Version,
            };

            await this.applicationsRepository.AddAsync(newApplication);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var applicationBeingEdited = await this.applicationsRepository.GetByIdAsync(id);

            if (applicationBeingEdited == null)
            {
                return this.NotFound();
            }

            var viewmodel = new ApplicationEditInputModel
            {
                Name = applicationBeingEdited.Name,
                Version = applicationBeingEdited.Version,
            };

            return this.View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationEditInputModel input)
        {
            var applicationBeingEdited = await this.applicationsRepository.GetByIdAsync(input.Id);
            applicationBeingEdited.Name = input.Name;
            applicationBeingEdited.Version = input.Version;

            await this.applicationsRepository.UpdateAsync(applicationBeingEdited);

            return this.Redirect("/");
        }
    }
}
