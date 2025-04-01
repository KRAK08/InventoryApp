using Inventory.Api.Data;
using Inventory.Api.Repositories.Interfaces;
using InventoryApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            var list = await _context.Categories.Include(c => c.Products).ToListAsync();
            if (list != null)
            {
                return new ActionResult<IEnumerable<Category>>
                {
                    WasSuccess = true,
                    Result = list
                };
            }
            return new ActionResult<IEnumerable<Category>>
            {
                WasSuccess = false,
                Message = "No hay categorías registradas."
            };
        }

        public override async Task<ActionResult<Category>> GetAsync(int id)
        {
            var data = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (data != null)
            {
                return new ActionResult<Category>
                {
                    WasSuccess = true,
                    Result = data
                };
            }
            return new ActionResult<Category>
            {
                WasSuccess = false,
                Message = "No se encontró el registro."
            };
        }
    }
}