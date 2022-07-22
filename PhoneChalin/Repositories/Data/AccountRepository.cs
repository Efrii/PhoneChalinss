using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;
using PhoneChalin.ViewModels;

namespace PhoneChalin.Repositories.Data
{
    public class AccountRepository
    {
        public List<Role> GetRole()
        {
            throw new NotImplementedException();
        }

        public User Get(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int ChangePassword(User user)
        {
            throw new NotImplementedException();
        }
        public int ForgetPassword(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Logout(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Register(User user)
        {
            //myContext.Set<User>().Add(user);
            //var data = myContext.SaveChanges();
            //return data;
            throw new NotImplementedException();
        }
    }
}
