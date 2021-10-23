using ManagementStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStudent.Repositories
{
    public class AuthenticationRepository
    {
        ManageDbContext myDb = new ManageDbContext();
        public bool checkLogin(string username, string password)
        {
            var user = myDb.users.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User getInformationByUserName(string username)
        {
            return myDb.users.Where(u => u.username == username).FirstOrDefault();
        }
        
    }
}