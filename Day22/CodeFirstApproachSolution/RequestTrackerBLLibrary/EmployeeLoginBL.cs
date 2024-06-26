﻿using CodeFirstApproach;
using RequestTrackerDALLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<string> CheckRole(int id)
        {
            var employee = await _repository.Get(id);
            return employee.Role;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _repository.Get(id);
            return employee;
        }

        public async Task<bool> Login(Employee employee)
        {
            var emp =await _repository.Get(employee.Id);
            if(emp != null)
            {
                if (emp.Password == employee.Password)
                    return true;
            }
            return false;   
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }
    }
}
