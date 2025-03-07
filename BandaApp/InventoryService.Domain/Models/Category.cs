using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Domain.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column("guid")]
        public Guid? Guid { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }
    }
}
