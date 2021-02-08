namespace Web.Models.Shortcut
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Entities;

    public class ShortcutCreateInputModel
    {
        public string KeyCombination { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }

        public int ApplicationId { get; set; }
    }
}
