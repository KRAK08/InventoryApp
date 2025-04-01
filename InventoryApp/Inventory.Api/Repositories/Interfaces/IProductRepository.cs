using InventoryApp.Shared.Entities;

namespace Inventory.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ActionResult<Product>> GetAsync(int id);

        Task<ActionResult<IEnumerable<Product>>> GetAllAsync();
    }
}