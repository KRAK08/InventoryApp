using Inventory.Api.UnitsOfWork.Interfaces;
using InventoryApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : GenericController<Product>
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public ProductController(IUnitOfWork<Product> unitOfWork, IProductUnitOfWork productUnitOfWork) : base(unitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _productUnitOfWork.GetAsync(id);
            return Ok(data.Result);
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _productUnitOfWork.GetAllAsync();
            return Ok(list);
        }
    }
}