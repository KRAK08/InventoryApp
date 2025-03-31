using Inventory.Api.Repositories;
using Inventory.Api.Repositories.Interfaces;
using Inventory.Api.UnitsOfWork.Interfaces;
using InventoryApp.Shared.Entities;

namespace Inventory.Api.UnitsOfWork.Implementations
{
    public class CategoryUnitOfwork : GenericUnitOfWork<Category>, ICategoryUnitOfWork
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUnitOfwork(IRepository<Category> repository, ICategoryRepository categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<ActionResult<Category>> GetAsync(int id) => await _categoryRepository.GetAsync(id);

        public override async Task<ActionResult<IEnumerable<Category>>> GetAllAsync() => await _categoryRepository.GetAllAsync();
    }
}