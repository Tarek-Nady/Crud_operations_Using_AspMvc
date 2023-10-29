using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmemtRepository) 
        {
            EmployeeRepository= employeeRepository;
            DepartmentRepository = departmemtRepository;
        }
    }
}
