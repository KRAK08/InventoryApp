using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}