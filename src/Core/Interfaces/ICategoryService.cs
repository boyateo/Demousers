namespace Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Core.Entities;

    public interface ICategoryService
    {
        Task CreateCategory(string name);

        IEnumerable<Category> ListAll();
    }
}
