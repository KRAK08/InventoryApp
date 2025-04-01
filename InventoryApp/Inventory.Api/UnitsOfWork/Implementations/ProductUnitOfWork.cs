using Inventory.Api.Repositories;
using Inventory.Api.Repositories.Interfaces;
using Inventory.Api.UnitsOfWork.Interfaces;
using InventoryApp.Shared.Entities;

namespace Inventory.Api.UnitsOfWork.Implementations
{
    public class ProductUnitOfWork : GenericUnitOfWork<Product>, IProductUnitOfWork
    {
        private readonly IProductRepository _productRepository;

        public ProductUnitOfWork(IRepository<Product> repository, IProductRepository productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public override async Task<ActionResult<Product>> GetAsync(int id) => await _productRepository.GetAsync(id);

        public override async Task<ActionResult<IEnumerable<Product>>> GetAllAsync() => await _productRepository.GetAllAsync();
    }
}