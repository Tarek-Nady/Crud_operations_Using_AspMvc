using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class GenaricRepository<T>:IGenaricRepository<T> where T : class
    {
        public readonly MvcAppDbContext dbContext;
        public GenaricRepository(MvcAppDbContext _dbContext)
        {
            //dbContext= new MvcAppDbContext(); This is not Used
            dbContext = _dbContext;
        }

        public async Task< int> Add(T T)
        {
           await dbContext.Set<T>().AddAsync(T);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<int> Delete(T T)
        {
            dbContext.Set<T>().Remove(T);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
            => await dbContext.Set<T>().FindAsync(id);
            //=> dbContext.Set<T>().Where(D => D.Id == id).FirstOrDefault();


        public async Task<IEnumerable<T>> GetAll()
        {
            if(typeof(T)==typeof(Employee))
                return (IEnumerable<T>) await dbContext.Set<Employee>().Include(E=>E.Department).ToListAsync();

           
            return await dbContext.Set<T>().ToListAsync();

        }

        public async Task<int> Update(T T)
        {
            dbContext.Set<T>().Update(T);
            return await dbContext.SaveChangesAsync();
        }
    }
}
