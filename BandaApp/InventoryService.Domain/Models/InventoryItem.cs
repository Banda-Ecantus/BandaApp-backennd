using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Domain.Models
{
    [Table("InventoryItems")]

    public class InventoryItem
    {
        [Key]
        public Guid Guid { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int SerialNumber { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        public required string Assets { get; set; } //Patrimonio
    }
}
