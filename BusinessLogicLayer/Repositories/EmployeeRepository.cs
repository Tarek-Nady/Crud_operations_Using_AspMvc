using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public  class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        public readonly MvcAppDbContext _dbContext;
        public EmployeeRepository(MvcAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeesByName(string name)
                => _dbContext.Employees.Where(E=>E.Name.Contains(name));
        
    }
}
