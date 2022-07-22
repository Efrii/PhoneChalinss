using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;

namespace PhoneChalin.Repositories.Data
{
    public class SmartphoneRepository : GenericRepository<Smartphone, int>
    {
        public SmartphoneRepository() : base("smartphone/")
        {

        }
    }
}
