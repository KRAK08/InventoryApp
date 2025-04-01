using Inventory.Api.Repositories;
using InventoryApp.Shared.Entities;

namespace Inventory.Api.UnitsOfWork.Interfaces
{
    public interface IProductUnitOfWork
    {
        Task<ActionResult<Product>> GetAsync(int id);

        Task<ActionResult<IEnumerable<Product>>> GetAllAsync();
    }
}