using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Domain.Models
{
    [Table("inventoryitems")]

    public class InventoryItem
    {
        [Key]
        [Column("guid")]
        public Guid Guid { get; set; }

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

        [MaxLength(255)]
        [Column("image")]
        public string? Image { get; set; }

        [MaxLength(255)]
        [Column("imageurl")]
        public string? ImageUrl { get; set; }
    }
}
