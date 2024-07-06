using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCrud.Model;
using WebApiCrud.Data;
using AutoMapper;
using Azure;

namespace WebApiCrud.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _response;
        private IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();

            _mapper = mapper;
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public List<Employee> GetEmployees(int employeeId)
        {
           
            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                return new List<Employee> { employee };
            }
            return new List<Employee>();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                _context.SaveChanges();
            }
            return existingEmployee;
        }
    }
}
