namespace ProductAPIDB.Models.DTOS
{
    public class LoginResponse
    {

        public UserResponse User { get; set; }

        public string Token { get; set; }=string.Empty;
    }
}
