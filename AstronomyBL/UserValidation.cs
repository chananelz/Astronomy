using AstronomyDAL;
using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool Sign_up_request(string Username, string Password, string EmailAddress, bool IsInterestedInPictures)
        {
            if ((from MyUser in UserCollection.UsersDetails
                 where MyUser.UserName == Username
                 select MyUser).Any() == true)
            {
                return false;
            }
            else if (Password.Length < 6)
            {
                return false;
            }
            else
            {
                User_reader p = new User_reader();
                User NewUser = new User
                {
                    UserName = Username,
                    Password = Password,
                    EmailAddress = EmailAddress,
                    IsIntrestedInEmails = IsInterestedInPictures
                };
                
                p.AddNewUser(NewUser);
                return true;
            }
            
        }
    }
}
