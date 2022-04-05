using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyDAL
{
    public class User_reader
    {
        public List<User> UsersDetails { get; set; }
        
        public User_reader()
        {
            using (AstronomyDBEntities context = new AstronomyDBEntities())
            {
                UsersDetails = (from U in context.Users
                                select U).ToList();
            } 
           
        }

        public bool AddNewUser(User user)
        {
            UsersDetails.Add(user);
            return true;
        }
    }
}
