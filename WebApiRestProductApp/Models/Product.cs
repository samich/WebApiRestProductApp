namespace WebApiRestProductApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public Decimal Price { get; set; }
    }
}
