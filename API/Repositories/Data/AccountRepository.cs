using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public User GetLogin(string username, string password)
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
            myContext.Set<User>().Update(user);
            var data = myContext.SaveChanges();

            return data;
        }

        public int Register(Register register)
        {
            var emp = new Employee
            {
                NipEmployee = register.NipEmployee,
                NameEmployee = register.NameEmployee,
                GenderEmployee = register.GenderEmployee,
                AgeEmployee = register.AgeEmployee,
                StatusEmployer = register.StatusEmployee
            };

            register.IdEmployee = emp.IdEmployee;
            myContext.Employees.Add(emp);
            myContext.SaveChanges();

            var user = new User
            {
                Id = emp.IdEmployee,
                Email = register.Email,
                Username = register.Username,
                Password = register.Password
            };

            register.IdEmployee = user.Id;
            myContext.Users.Add(user);

            List<UserRole> userRole = new List<UserRole>();

            foreach (var item in register.UserRoles)
            {
                UserRole role = new UserRole()
                {
                    IdUser = user.Id,
                    IdRole = item.IdRole
                };

                userRole.Add(role);
                myContext.UserRoles.Add(role);
            }

            var data = myContext.SaveChanges();

            return data;
        }
    }
}
