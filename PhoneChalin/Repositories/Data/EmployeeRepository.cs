using System;
using PhoneChalin.Models;

namespace PhoneChalin.Repositories.Data
{
    public class EmployeeRepository : GenericRepository<Employee, int>
    {
        public EmployeeRepository() : base("employee/")
        {

        }
    }
}
