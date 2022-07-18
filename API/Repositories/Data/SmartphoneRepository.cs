using System;
using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class SmartphoneRepository : GenericRepository<Smartphone, int>
    {
        MyContext myContext;

        public SmartphoneRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public List<Smartphone> GetAllJoin()
        {
            var smartphones = myContext.Smartphones.Include(x => x.supplierModel).ToList();

            return smartphones;
        }

    }
}
