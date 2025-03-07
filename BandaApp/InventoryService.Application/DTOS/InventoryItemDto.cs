using InventoryService.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryService.Application.DTOS
{
    public class InventoryItemDto
    {
        public Guid? Guid { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Número de Série é obrigatório.")]
        public required string SerialNumber { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória.")]
        public required Guid CategoryId { get; set; }

        public string? Type { get; set; }

        public bool Disposable { get; set; } = false;
        public bool Allocated { get; set; } = false;
        public  Category? Category { get; set; }
    }
}
