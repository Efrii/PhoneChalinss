using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;
using PhoneChalin.ViewModels;

namespace PhoneChalin.Repositories.Data
{
    public class AccountRepository : GenericRepository<User, string>
    {
        public AccountRepository() : base("Account/")
        {

        }

        public HttpStatusCode Register(Register register)
        {
            var postTask = client.PostAsJsonAsync<Register>(request +"Register", register);
            postTask.Wait();

            var result = postTask.Result;

            return result.StatusCode;
        }
    }
}
