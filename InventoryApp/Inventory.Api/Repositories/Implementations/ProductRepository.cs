using Inventory.Api.Data;
using Inventory.Api.Repositories.Interfaces;
using InventoryApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResult<Product>> GetAsync(int id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return new ActionResult<Product>
                {
                    WasSuccess = false,
                    Message = "No se encontro el registro."
                };
            }
            return new ActionResult<Product>
            {
                WasSuccess = true,
                Result = data
            };
        }

        public override async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            var list = await _context.Products.ToListAsync();
            if (list == null)
            {
                return new ActionResult<IEnumerable<Product>>
                {
                    WasSuccess = false,
                    Message = "No hay registros."
                };
            }
            return new ActionResult<IEnumerable<Product>>
            {
                WasSuccess = true,
                Result = list
            };
        }
    }
}