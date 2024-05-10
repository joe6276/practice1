using ProductAPIDB.Models;

namespace ProductAPIDB.Services.IServices
{
    public interface IJwt
    {

        string generateToken(User user, IEnumerable<string> roles);
    }
}
