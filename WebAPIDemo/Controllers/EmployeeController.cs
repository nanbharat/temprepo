using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.DataBaseService.DbElement;
using WebAPIDemo.Service;
using WebAPIDemo.ServiceImpl;

namespace WebAPIDemo.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployee<Employee> mEmployeeService;


        public EmployeeController(IEmployee<Employee> EmployeeService)
        {
          mEmployeeService = EmployeeService;

        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("api/employee/GetData")]
        public IActionResult GetData()
        {
             var list = mEmployeeService.GetAllEmployee().ToList();

            return Json(list);
        }



    }
}