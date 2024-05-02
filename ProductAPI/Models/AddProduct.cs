using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class AddProduct
    {

        //validation

        [Required(ErrorMessage ="Product Name is Required")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Product Description is Required")]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = "Product Price is Required")]
        [Range(1,1000000000, ErrorMessage ="price out of Range")]
        public double Price { get; set; }
    }
}
