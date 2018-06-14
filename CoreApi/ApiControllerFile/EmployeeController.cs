using System.Collections.Generic;
using CoreDAC.EmployeeDal;
using CoreDAC.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CoreApi.ApiControllerFile
{

    public class EmployeeController : Controller
    {
        [HttpGet]
        [Route("api/Employee/getAllEmployee")]
        public IEnumerable<Employee> Get()
        {
            EmployeeDal emp = new EmployeeDal();
            return emp.GetAllEmployee();
        }
    }
}
