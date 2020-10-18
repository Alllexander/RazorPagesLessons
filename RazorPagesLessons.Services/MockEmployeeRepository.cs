using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0, Name = "Mary", Email = "mary@test.ua", PhotoPath = "avatar2.png", Department = Dept.HR
                },
                new Employee()
                {
                    Id = 1, Name = "Mark", Email = "mark@test.ua", PhotoPath = "avatar.png", Department = Dept.IT
                },
                new Employee()
                {
                    Id = 2, Name = "Kolyan", Email = "Kolyan@test.ua", PhotoPath = "avatar4.png", Department = Dept.IT
                },
                new Employee()
                {
                    Id = 3, Name = "Shawn", Email = "Shawn@test.ua", PhotoPath = "avatar5.png", Department = Dept.Payroll
                },
                new Employee()
                {
                    Id = 4, Name = "Jenifer", Email = "Jenifer@test.ua", PhotoPath = "avatar3.png", Department = Dept.HR
                },
                new Employee()
                {
                    Id = 5, Name = "Олександр", Email = "Oleksandr@test.ua", Department = Dept.Payroll
                },
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(X500DistinguishedName => X500DistinguishedName.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _employeeList.FirstOrDefault(X500DistinguishedName => X500DistinguishedName.Id == id);

            if (employeeToDelete != null)
                _employeeList.Remove(employeeToDelete);

            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;

            if (dept.HasValue)
                query = query.Where(x => x.Department == dept.Value);

            return query.GroupBy(x => x.Department)
                                .Select(x => new DeptHeadCount()
                                {
                                    Departament = x.Key.Value,
                                    Count = x.Count()
                                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee updateEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(X500DistinguishedName => X500DistinguishedName.Id == updateEmployee.Id);

            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Department = updateEmployee.Department;
                employee.PhotoPath = updateEmployee.PhotoPath;                
            }

            return employee;
        }
    }
}
