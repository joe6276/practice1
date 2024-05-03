using System.ComponentModel.DataAnnotations;

namespace ProductAPIDB.Models.DTOS
{
    public class AddCategory
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
