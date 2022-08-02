using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        private Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string token = "";
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

        public bool CekEmail(string email)
        {
            var data = myContext.Users.FirstOrDefault(x => x.Email == email);

            return data != null;
        }

        public string Token(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int ResetPassword(Register register)
        {
            var cek = CekEmail(register.Email);
            token = Token(12);
            if(cek == true)
            {
                string to = register.Email; //To address    
                string from = "@students.amikom.ac.id"; //From address    
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Reset Password " + register.NameEmployee;
                message.Body = $"This email is used to send OTP for  resetting account password.\nHere is your OTP: {token}";
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                NetworkCredential basicCredential1 = new NetworkCredential("@students.amikom.ac.id", "");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
            }

            return 0;

        }

        public int Reset(User user, string tokens)
        {
            if(token == tokens)
            {
                myContext.Set<User>().Update(user);
                var data = myContext.SaveChanges();

                return data;
            }
            else
            {
                return 0;
            }

        }

        public int Register(Register register)
        {
            var cek = CekEmail(register.Email);

            if(cek == false)
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

                //List<UserRole> userRole = new List<UserRole>();

                //foreach (var item in register.UserRoles)
                //{
                //    UserRole role = new UserRole()
                //    {
                //        IdUser = user.Id,
                //        IdRole = item.IdRole
                //    };

                //    userRole.Add(role);
                //    myContext.UserRoles.Add(role);
                //}

                var data = myContext.SaveChanges();

                return data;

            } else if(cek == true)
            {
                return 2;
            }

            return 0;
        }
    }
}
