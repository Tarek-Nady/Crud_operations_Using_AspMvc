using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartmentRepository : IGenaricRepository<Department>
    {
        IQueryable<Department> GetDepartmentByName(string name);

    }
}
