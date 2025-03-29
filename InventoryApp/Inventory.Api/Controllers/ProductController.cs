using Inventory.Api.UnitsOfWork.Interfaces;
using InventoryApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : GenericController<Product>
    {
        public ProductController(IUnitOfWork<Product> unitOfWork) : base(unitOfWork)
        {
        }
    }
}