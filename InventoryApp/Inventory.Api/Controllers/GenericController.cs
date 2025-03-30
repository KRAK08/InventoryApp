using Inventory.Api.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IUnitOfWork<T> _unitOfWork;

        public GenericController(IUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var data = await _unitOfWork.GetAsync(id);
            return Ok(data.Result);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var list = await _unitOfWork.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T entity)
        {
            return Ok(await _unitOfWork.CreateAsync(entity));
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T entity)
        {
            return Ok(await _unitOfWork.UpdateAsync(entity));
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _unitOfWork.DeleteAsync(id));
        }
    }
}