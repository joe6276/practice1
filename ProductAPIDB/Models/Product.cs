using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPIDB.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = default!;
        public Guid CategoryId { get; set; }
    }
}
