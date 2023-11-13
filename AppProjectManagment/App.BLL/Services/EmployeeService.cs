using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using App.BLL.Services.Contracts;
namespace App.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }



        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(object id)
        {
            return await _repository.GetById(id);
        }


        public async Task<int> AddEmployee(Employee employee)
        {
            return await _repository.Insert(employee);
        }


        public async Task<int> UpdateEmployee(Employee employee)
        {
            return await _repository.Update(employee);
        }

        public async Task<int> DeleteEmployee(object id)
        {
            return await _repository.Delete(id);
        }
    }
}
