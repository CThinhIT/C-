using System.ComponentModel.DataAnnotations;

namespace ProductClient.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Price { get; set; }
    }
}
