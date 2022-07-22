using System;
using System.Collections.Generic;
using System.Linq;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;

namespace PhoneChalin.Repositories.Data
{
    public class BuyerRepository : GenericRepository<Buyer, int>
    {
        public BuyerRepository() : base("buyer/")
        {

        }  
    }
}
