using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Domain.Models
{
    [Table("inventoryitem")]

    public class InventoryItem
    {
        [Key]
        [Column("guid")]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("serialnumber")]
        public required string SerialNumber { get; set; }

        [Required]
        [Column("categoryId")]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        [MaxLength(255)]
        [Column("type")]
        public string? Type { get; set; }

        [Column("disposable")]
        public bool Disposable { get; set; }
        public required Category Category { get; set; }
    }
}
