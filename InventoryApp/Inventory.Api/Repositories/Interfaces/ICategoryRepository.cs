using InventoryApp.Shared.Entities;

namespace Inventory.Api.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ActionResult<Category>> GetAsync(int id);

        Task<ActionResult<IEnumerable<Category>>> GetAllAsync();
    }
}