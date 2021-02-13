namespace Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Core.Entities;

    public interface ICategoryService
    {
        // Create
        Task Create(string name);

        // Read
        IEnumerable<Category> ReadAll();
    }
}
