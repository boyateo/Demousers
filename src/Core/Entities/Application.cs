namespace Core.Entities
{
    using System.Collections.Generic;

    public class Application : BaseEntity<int>
    {
        public Application()
        {
            this.Shortcuts = new HashSet<Shortcut>();
        }

        public string Name { get; set; }

        public string Version { get; set; }

        public string ImageUri { get; set; }

        // Db relations
        public virtual IEnumerable<Shortcut> Shortcuts { get; set; }
    }
}
