namespace ViewModels.Shortcut
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;
    using ViewModels.Category;

    public class ShortcutCreateInputModel
    {
        public string KeyCombination { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public int ApplicationId { get; set; }

        public IEnumerable<Application> Applications { get; set; }
    }
}
