using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application, int> applicatonRepository;

        public ApplicationService(IRepository<Application, int> applicatonRepository)
        {
            this.applicatonRepository = applicatonRepository;
        }

        public async Task CreateApplicatio(string name, string version)
        {
            var newApplication = new Application()
            {
                Name = name,
                Version = version,
            };

            await this.applicatonRepository.AddAsync(newApplication);
        }

        public IEnumerable<Application> ListAll()
        {
            var applications = applicatonRepository.ListAllAsyncAsQuery()
                .OrderBy(x =>x.Name)
                .ThenBy(x=>x.Version)
                .Select(x => new Application() 
                {
                   Name = x.Name,
                   Version = x.Version,
                }).ToList();

            return applications;
        }
    }
}
