using System;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class BuyerRepository : GenericRepository<Buyer, int>
    {
        public BuyerRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
