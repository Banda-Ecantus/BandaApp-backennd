using InventoryService.Domain.Models;

namespace InventoryService.Application.DTOS
{
    public class InventoryItemDto
    {
        public Guid? Guid { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public required string SerialNumber { get; set; }

        public required Guid CategoryId { get; set; }

        public string? Type { get; set; }

        public bool Disposable { get; set; } = false;
        public bool Allocated { get; set; } = false;
        public  Category? Category { get; set; }
    }
}
