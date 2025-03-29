using Inventory.Api.Repositories;
using Inventory.Api.Repositories.Interfaces;
using Inventory.Api.UnitsOfWork.Interfaces;

namespace Inventory.Api.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericUnitOfWork(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<ActionResult<T>> CreateAsync(T entity) => await _repository.CreateAsync(entity);

        public virtual async Task<ActionResult<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<ActionResult<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public virtual async Task<ActionResult<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    }
}