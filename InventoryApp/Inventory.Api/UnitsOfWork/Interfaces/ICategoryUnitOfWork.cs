using Inventory.Api.Repositories;
using InventoryApp.Shared.Entities;

namespace Inventory.Api.UnitsOfWork.Interfaces
{
    public interface ICategoryUnitOfWork
    {
        Task<ActionResult<Category>> GetAsync(int id);

        Task<ActionResult<IEnumerable<Category>>> GetAllAsync();
    }
}