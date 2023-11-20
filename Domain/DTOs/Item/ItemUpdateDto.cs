namespace Domain.DTOs.Item
{
    public class ItemUpdateDto
    {
        public int Id { get; }
        public string? Title { get; set; }
        
        public string? Manufacture { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        
        public int? Stock { get; set; }

        public ItemUpdateDto(int id)
        {
            Id = id;
        }
    }
}