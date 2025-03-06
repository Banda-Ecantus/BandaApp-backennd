using InventoryService.Domain.Models;

namespace InventoryService.Application.DTOS
{
    public class InventoryItemDto
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }

        public string? Description { get; set; }

        public required string SerialNumber { get; set; }

        public Guid CategoryId { get; set; }

        public string? Type { get; set; }

        public bool Disposable { get; set; }
        public required Category Category { get; set; }
    }
}
