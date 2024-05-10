using Microsoft.AspNetCore.Identity;

namespace ProductAPIDB.Models
{
    public class User:IdentityUser
    {

        public string Name { get; set; } = string.Empty;
    }
}
