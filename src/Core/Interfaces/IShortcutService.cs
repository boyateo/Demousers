namespace Core.Interfaces
{
    using System.Threading.Tasks;

    public interface IShortcutService
    {
        Task CreateShortcutAsync(int applicationId, int categoryId, string description, string keyCombination);
    }
}
