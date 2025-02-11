namespace InventoryService.Application.DTOS
{
    public class InventoryItemDto
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SerialNumber { get; set; }
        public string? Image { get; set; }
        public string? ImageUrl { get; set; }
        public required string Assets { get; set; }
    }
}
