using System.ComponentModel.DataAnnotations;

namespace WebApiRestProductApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
    }
}
