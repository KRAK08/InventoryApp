using Inventory.Api.UnitsOfWork.Interfaces;
using InventoryApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : GenericController<Category>
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;

        public CategoryController(IUnitOfWork<Category> unitOfWork, ICategoryUnitOfWork categoryUnitOfWork) : base(unitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _categoryUnitOfWork.GetAsync(id);
            return Ok(data.Result);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _categoryUnitOfWork.GetAllAsync();
            return Ok(list);
        }
    }
}