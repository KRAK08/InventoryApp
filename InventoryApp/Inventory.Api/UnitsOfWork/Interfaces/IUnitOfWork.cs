using Inventory.Api.Repositories;

namespace Inventory.Api.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<ActionResult<T>> CreateAsync(T entity);

        Task<ActionResult<T>> UpdateAsync(T entity);

        Task<ActionResult<T>> DeleteAsync(int id);

        Task<ActionResult<IEnumerable<T>>> GetAllAsync();

        Task<ActionResult<T>> GetAsync(int id);
    }
}