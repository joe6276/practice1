using System.ComponentModel.DataAnnotations;

namespace ProductAPIDB.Models.DTOS
{
    public class LoginDetails
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Password { get; set; } = string.Empty;


    }
}
