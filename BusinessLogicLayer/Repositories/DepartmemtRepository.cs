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
    public class DepartmemtRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public readonly MvcAppDbContext _dbContext;

        public DepartmemtRepository(MvcAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

   

        public IQueryable<Department> GetDepartmentByName(string name)
                 => _dbContext.Departments.Where(D => D.Name.Contains(name));

    }
}
