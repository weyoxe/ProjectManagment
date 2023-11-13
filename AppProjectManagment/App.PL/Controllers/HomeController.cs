using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using App.BLL.Services.Contracts;
using App.DAL.Models;
namespace App.PL.Controllers
{
    public class HomeController : Controller
    {

      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public async Task<IActionResult> ShowEmployees()
        //{
        //    List<Employee> listEmployees = await _employeeService.GetAllEmployees();
        //    return View(listEmployees);
        //}

        //public async Task<IActionResult> InsertEmployees(Employee employee)
        //{
        //    var result = await _employeeService.AddEmployee(employee); 
        //    return Ok(employee);
        //}

        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //}
    }
}