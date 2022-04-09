using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstronomyDP;

namespace AstronomyDAL
{
    public class User_reader
    {
        public List<Users> UsersDetails { get; set; }

        public User_reader()
        {
            using (APDBEntities context = new APDBEntities())
            {
                UsersDetails = (from U in context.Users
                                select U).ToList();
            }

        }

        public void AddNewUser(Users user)
        {
            UsersDetails.Add(user);
            using (APDBEntities context = new APDBEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
