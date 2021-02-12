using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Shortcut;

namespace Services
{
    public class ShortcutService : IShortcutService
    {
        private readonly IRepository<Shortcut, int> shortcutsRepository;

        public ShortcutService(IRepository<Shortcut, int> shortcutsRepository)
        {
            this.shortcutsRepository = shortcutsRepository;
        }

        // This is Domain type service(shoul not return view model)
        public async Task CreateShortcutAsync(int applicationId, int categoryId, string description, string keyCombination)
        {
            var newShortcut = new Shortcut
            {
                ApplicationId = applicationId,
                CategoryId = categoryId,
                Description = description,
                KeyCombination = keyCombination,
            };

            await this.shortcutsRepository.AddAsync(newShortcut);
        }



    }
}
