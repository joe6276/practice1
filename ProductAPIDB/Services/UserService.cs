using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using ProductAPIDB.Data;
using ProductAPIDB.Models;
using ProductAPIDB.Models.DTOS;
using ProductAPIDB.Services.IServices;

namespace ProductAPIDB.Services
{
    public class UserService : IUser
    {
        private readonly IMapper _mapper;
        private readonly ApplicationAuthContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwt _jwt;
        public UserService(IMapper mapper, ApplicationAuthContext dbContext, UserManager<User> userManager,IJwt jwt, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt;

        }
        public async Task<string> addUser(RegisterUser registerUser)
        {
             var newUser = _mapper.Map<User>(registerUser);

            try
            {
                var result = await _userManager.CreateAsync(newUser,registerUser.Password);

                if(result.Succeeded)
                {
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<bool> AssignRole(string Email, string roleName)
        {
            var user = _context.Users.Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefault();

            if(user != null)
            {
                //check if role exist
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //creat the role
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                };

                //assign the role

               await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }

            return false;
        }

        public async Task<LoginResponse> login(LoginDetails loginRequest)
        {
          //  check username/email

            var user = _context.Users.Where(x=>x.UserName.ToLower()== loginRequest.Email.ToLower()).FirstOrDefault();

            //check if password is valid
            bool isValid= await  _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if(!isValid || user==null)
            {
                //wrong credential
                return new LoginResponse()
                {
                    User = null,
                    Token = ""
                };
            }
            var userResponse =_mapper.Map<UserResponse>(user);

            //get user roles
            var roles =await _userManager.GetRolesAsync(user);
            var token = _jwt.generateToken(user, roles);
            return new LoginResponse()
            {
                User = userResponse,
                Token = token
            };
        }

        
    }
}
