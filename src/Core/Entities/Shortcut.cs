namespace Core.Entities
{
    public class Shortcut : BaseEntity<int>
    {
        public string KeyCombination { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }

        // Db relations
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
