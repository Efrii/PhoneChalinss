using System;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GenericRepository<Employee, int>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
