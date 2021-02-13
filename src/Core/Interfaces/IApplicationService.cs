namespace Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Core.Entities;

    public interface IApplicationService
    {
        Task CreateApplicatio(string name, string version);

        IEnumerable<Application> ListAll();
    }
}
