using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Price { get; set; }
    }
}
