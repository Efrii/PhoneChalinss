using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;

namespace PhoneChalin.Repositories.Data
{
    public class SupplierRepository : GenericRepository<Supplier, int>
    {
        public SupplierRepository() : base("Supplier/")
        {

        }
    }
}
