using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.DataBaseService.DbElement;

namespace WebAPIDemo.Service
{
    public interface IEmployee<TEntity>  where TEntity : class
    {
        IEnumerable<TEntity> GetAllEmployee();

    }
}
