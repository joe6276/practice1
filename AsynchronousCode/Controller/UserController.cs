using AsynchronousCode.Models;
using AsynchronousCode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousCode.Controller
{
    internal class UserController
    {
        /// <summary>
        /// Fake UI 
        /// </summary>
        private readonly UserService _userservice;
        public UserController()
        {
            _userservice = new UserService();
        }

        public async Task getUsers()
        {
            var users = await _userservice.getUSers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.name} drives {user.car}");
                Console.WriteLine("\n");
            }
        }

        public async Task addUser()
        {
            Console.WriteLine(" Enter your Name : ");
            var name = Console.ReadLine();

            Console.WriteLine(" Enter your Car : ");
            var car = Console.ReadLine();

            if(car != null && name !=null) 
            {
                var newUser=new AddUser()
                {
                    name = name,
                    car = car

                };

               var response = await _userservice.addUser(newUser);
                Console.WriteLine(response);
            }
        }


        public async Task updateUser()
        {

            Console.WriteLine(" Enter ID : ");
            var id = Console.ReadLine();


            Console.WriteLine(" Enter your Name : ");
            var name = Console.ReadLine();

            Console.WriteLine(" Enter your Car : ");
            var car = Console.ReadLine();

            if (car != null && name != null && id !=null)
            {
                var newUser = new AddUser()
                {
                    name = name,
                    car = car

                };

                var response=await _userservice.updateUser(newUser,id);
                Console.WriteLine(response);
            }
        }
    }
}
