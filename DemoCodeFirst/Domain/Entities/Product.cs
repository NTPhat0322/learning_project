using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCodeFirst.Domain.Entities
{
    public class Product : AuditableEntity
    {
        [Key] // Primary key attribute 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Cho phép DB tự sinh
        public Guid Id { get; set; }
        [Required] // Not null attribute
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 999999)] // Price range validation
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; } // Foreign key to Category
        public Category? Category { get; set; } = null!; // Navigation property
    }
}
