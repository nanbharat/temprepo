using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.DataBaseService;
using WebAPIDemo.DataBaseService.DbElement;
using WebAPIDemo.Service;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.ServiceImpl
{
    public class EmployeeService<TEntity> : IEmployee<TEntity> where TEntity : class
    {

       public readonly DatabaseContext mDbContext;
        public readonly DbSet<TEntity> set;
      

        public EmployeeService(DatabaseContext DbContext)
        {
            mDbContext = DbContext;
        }


        public IEnumerable<TEntity> GetAllEmployee()
        {
            var list = mDbContext.Set<TEntity>().ToList();

            if(list.Any())
            {
                return list;
            }

            return null;
            
        }


        public IEnumerable<TEntity> GetConditionalData(Func<TEntity,bool> condition)
        {
            var list = mDbContext.Set<TEntity>().Where(condition).ToList();
            if( list.Any() )
            {
                return list;
            }

            return null;
        }

        public TEntity Insert( TEntity ele )
        {
            try
            {
                mDbContext.Set<TEntity>().Add(ele);
                mDbContext.SaveChanges();
                return ele;
            }
            catch( Exception ex )
            {
                return null;
            }
        }

        //public TEntity Update(TEntity ele)
        //{
        //    mDbContext.Set<TEntity>().Entry<TEntity>().State = EntityState.Modified;

        //}

        public void Delete( TEntity  ele )
        {
          
                mDbContext.Set<TEntity>().Remove(ele);
                mDbContext.SaveChanges();
           
            
        }
    }
}
