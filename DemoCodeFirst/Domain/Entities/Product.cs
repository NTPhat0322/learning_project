using System.ComponentModel.DataAnnotations;

namespace DemoCodeFirst.Domain.Entities
{
    public class Product
    {
        [Key] // Primary key attribute 
        public Guid Id { get; set; }
        [Required] // Not null attribute
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 999999)] // Price range validation
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
