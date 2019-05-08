using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.DataBaseService.DbElement;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.DataBaseService
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }


        public DbSet<Employee> TBL_Employee { get; set; }


      



    }

}
