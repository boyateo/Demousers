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
        private readonly IRepository<Application> applicationsRepository;

        public ApplicationsController(IRepository<Application> applicationsRepository)
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

            return this.Ok();
        }
    }
}
