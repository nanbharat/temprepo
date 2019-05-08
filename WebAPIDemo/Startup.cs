using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPIDemo.DataBaseService;
using WebAPIDemo.DataBaseService.DbElement;
using WebAPIDemo.Service;
using WebAPIDemo.ServiceImpl;

namespace WebAPIDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // services.AddSingleton()

            services.AddScoped(typeof(IEmployee<Employee>), typeof(EmployeeService<Employee>));
           // services.AddScoped( new ServiceDescriptor(typeof(IEmployee<Employee>),typeof( EmployeeService<Employee>));
            //services.Add(new ServiceDescriptor(typeof(IEmployee<Employee>), new EmployeeService<Employee>(new DatabaseContext())));
            //  services.AddSingleton(new ServiceDescriptor(typeof(IEmployee), new EmployeeService()));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
