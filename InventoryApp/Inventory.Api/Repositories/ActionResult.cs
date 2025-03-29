namespace Inventory.Api.Repositories
{
    public class ActionResult<T>
    {
        public bool WasSuccess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }
    }
}