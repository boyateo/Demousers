using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category, int> categoryRepository;

        public CategoryService(IRepository<Category, int> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(string name)
        {
            var newCategory = new Category
            {
                Name = name,
            };

            await this.categoryRepository.AddAsync(newCategory);
        }

        public IEnumerable<Category> ListAll()
        {
            var allCategories = this.categoryRepository.ListAllAsyncAsQuery()
                .OrderBy(x => x.Name)
                .Select(x => new Category
                {
                    Name = x.Name,
                })
                .ToList();

            return allCategories;
        }
    }
}
