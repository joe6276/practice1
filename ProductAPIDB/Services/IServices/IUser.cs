using Microsoft.AspNetCore.Identity.Data;
using ProductAPIDB.Models.DTOS;

namespace ProductAPIDB.Services.IServices
{
    public interface IUser
    {

        Task<string> addUser(RegisterUser registerUser);

        Task<LoginResponse> login (LoginDetails loginRequest);


        Task<bool> AssignRole(string Email, string roleName);
    }
}
