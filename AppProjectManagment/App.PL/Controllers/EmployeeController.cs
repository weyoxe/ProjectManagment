using App.BLL.Services.Contracts;
using App.DAL.Models;

using Microsoft.AspNetCore.Mvc;

namespace App.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public  async Task<IActionResult> GetEmployees()
        {
            List<Employee> listEmployees = await _employeeService.GetAllEmployees();
            return View(listEmployees);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeById(object id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var result = await _employeeService.AddEmployee(employee);

            if (result > 0)
            {
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }

            return BadRequest("Failed to add employee");
        }
    }
}
