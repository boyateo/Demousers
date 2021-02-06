namespace Core.Entities
{
    public class Shortcut : BaseEntity<int>
    {
        public string KeyCombination { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }
    }
}
