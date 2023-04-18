using EmployeeWebAPI.IServices;
using EmployeeWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee(EmployeeModel employeeInfo)
        {
            EmployeeModel employee = await _employeeService.AddEmployee(employeeInfo);
            //return CreatedAtAction(nameof(GetAllEmployee), new { id = employee.Employee_PK }, employee);
            return Ok(employee);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult> GetAllEmployee()
        {
            List<EmployeeModel> employeeList = await _employeeService.GetAllEmployee();
            return Ok(employeeList);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult> PutEmployee(int id, EmployeeModel employee)
        {
            var updateEmployee = await _employeeService.UpdateEmployee(id, employee);
            return Ok(updateEmployee);

        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var deleteEmployee = await _employeeService.DeleteEmployee(id);
            return Ok(deleteEmployee); ;
        }
    }
}
