namespace Core.Entities
{
    public class Application : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Version { get; set; }
    }
}
