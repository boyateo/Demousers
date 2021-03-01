namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ViewModels;
    using ViewModels.Application;

    public class HomeController : Controller
    {
        private readonly IApplicationService applicationService;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            IApplicationService applicationService,
            ILogger<HomeController> logger)
        {
            this.applicationService = applicationService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            // TODO: add a property to mark the frequency of usage
            var threeMostFrequentlyUsedApplications = this.applicationService.ListNMostFrequentlyUsed(3);
            var vm = new ApplicationCardViewModel()
            {
                Applications = threeMostFrequentlyUsedApplications,
            };

            return this.View(vm);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
