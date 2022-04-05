using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstronomyDAL;
using AstronomyDP;
using Newtonsoft.Json;
using RestSharp;

namespace AstronomyBL
{
    public class UserValidation
    {
        private User_reader UserCollection;

        public UserValidation()
        {
            UserCollection = new User_reader();
        }

        public bool ValidateUser(string Username, string Password)
        {
            var Exist = (from MyUser in UserCollection.UsersDetails
                         where MyUser.UserName == Username && MyUser.Password == Password
                         select MyUser);
            return Exist.Any();
        }
    }
}
