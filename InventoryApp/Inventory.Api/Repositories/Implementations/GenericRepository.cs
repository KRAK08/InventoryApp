using Inventory.Api.Data;
using Inventory.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual async Task<ActionResult<T>> CreateAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResult<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException!.Message.Contains("duplicate"))
                    {
                        return DbUpdateExceptionActionResponse();
                    }
                }

                return new ActionResult<T>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        public virtual async Task<ActionResult<T>> DeleteAsync(int id)
        {
            var row = await _dbset.FindAsync(id);
            if (row == null)
            {
                return new ActionResult<T>()
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }
            try
            {
                _dbset.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResult<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new ActionResult<T>
                {
                    WasSuccess = false,
                    Message = "No se borró el elemento"
                };
            }
        }

        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            return new ActionResult<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _dbset.ToListAsync()
            };
        }

        public virtual async Task<ActionResult<T>> GetAsync(int id)
        {
            var result = await _dbset.FindAsync(id);
            if (result == null)
            {
                return new ActionResult<T>()
                {
                    WasSuccess = true,
                    Result = result
                };
            }
            return new ActionResult<T>
            {
                WasSuccess = false,
                Message = "No se encontró el registro"
            };
        }

        public virtual async Task<ActionResult<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResult<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException!.Message.Contains("duplicate"))
                    {
                        return DbUpdateExceptionActionResponse();
                    }
                }

                return new ActionResult<T>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        private ActionResult<T> DbUpdateExceptionActionResponse()
        {
            return new ActionResult<T>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear."
            };
        }

        private ActionResult<T> ExceptionActionResponse(Exception exception)
        {
            return new ActionResult<T>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
    }
}