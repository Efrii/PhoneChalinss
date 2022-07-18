using System;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class SupplierRepository : GenericRepository<Supplier, int>
    {
        public SupplierRepository(MyContext myContext) : base(myContext)
        {
            
        }
    }
}
