using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneChalin.Context;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;
using PhoneChalin.ViewModels;

namespace PhoneChalin.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<Role> GetRole()
        {
            var data = myContext.Roles.ToList();

            return data;
        }

        public User Get(string username, string password)
        {
            var data = myContext.Users.
                Include(x => x.Employee).
                Include(x => x.UserRoles).
                ThenInclude(x => x.Role).
                Where(x => x.Username == username).
                Where(x => x.Password == password).
                SingleOrDefault();

            return data;
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
            myContext.Set<User>().Add(user);
            var data = myContext.SaveChanges();
            return data;
            throw new NotImplementedException();
        }
    }
}
