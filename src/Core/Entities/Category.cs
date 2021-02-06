namespace Core.Entities
{
    using System.Collections.Generic;

    public class Category : BaseEntity<int>
    {
        public Category()
        {
            this.Shortcuts = new HashSet<Shortcut>();
        }

        public string Name { get; set; }

        // Db relations
        public virtual ICollection<Shortcut> Shortcuts { get; set; }
    }
}
