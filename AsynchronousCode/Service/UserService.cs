using AsynchronousCode.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousCode.Service
{
    internal class UserService
    {

        private readonly string _URL = "http://localhost:3000/users";
        public readonly HttpClient _httpClient;
        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<User>> getUSers()
        {
            //make a request
            var response= await _httpClient.GetAsync(_URL);
            var content = await response.Content.ReadAsStringAsync();// equivalent to .JSON() method in JS
            //we need to convert from JSON to List<Users>
            var users= JsonConvert.DeserializeObject<List<User>>(content);

            if(response.IsSuccessStatusCode && users !=null)
            {
                return users;
            }

            return new List<User>();
        }

        public async Task<string> addUser(AddUser newUser)
        {
            //

            var user = JsonConvert.SerializeObject(newUser);// preparing it for the request
            var body= new StringContent(user, Encoding.UTF8, "application/json");//Json. Stringfy()
            var response= await _httpClient.PostAsync(_URL, body);

            if(response.IsSuccessStatusCode )
            {
                return "user Added";
            }

            return "Request Failed";

        }

        public async Task<string> updateUser(AddUser updateduser, string id)
        {
            var user = JsonConvert.SerializeObject(updateduser);// preparing it for the request
            var body = new StringContent(user, Encoding.UTF8, "application/json");//Json. Stringfy()
            var response = await _httpClient.PutAsync(_URL+"/"+id, body);


            if (response.IsSuccessStatusCode)
            {
                return "user Updated";
            }

            return "Request Failed";
        }
    }
}
