using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public  class MvcAppDbContext:IdentityDbContext<ApplicationUser>
    {
        public MvcAppDbContext(DbContextOptions<MvcAppDbContext> options):base (options) 
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server =. ;Database= MvcApp;Trusted_Connection=true;"); // MultipleActiveResultSets =true;

        public DbSet<Department> Departments { get; set; }

        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }
    }
}
