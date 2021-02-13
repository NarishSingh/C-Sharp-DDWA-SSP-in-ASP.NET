using System.Collections.Generic;
using System.Linq;

namespace EmployeeMS.Models.Stubs
{
    public class EmplRepoStub
    {
        private static List<Employee> _employees;

        static EmplRepoStub()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1, FirstName = "Jenny",
                    LastName = "Jones",
                    PhoneNum = "888-888-8888",
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2, FirstName = "Bob",
                    LastName = "Ross",
                    PhoneNum = "555-888-8888",
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 3, FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNum = "678-888-1234",
                    DepartmentId = 3
                }
            };
        }

        public static void CreateEmployee(Employee e)
        {
            if (_employees.Any())
            {
                e.Id = _employees.Max(empl => empl.Id) + 1;
            }
            else
            {
                e.Id = 1;
            }

            _employees.Add(e);
        }

        public static void EditEmployee(Employee e)
        {
            _employees[_employees.FindIndex(empl => empl.Id == e.Id)] = e;
        }

        public static void DeleteEmployee(int id)
        {
            _employees.RemoveAll(empl => empl.Id == id);
        }

        public static Employee ReadEmployee(int id)
        {
            return _employees.FirstOrDefault(empl => empl.Id == id);
        }

        public static List<Employee> ReadAllEmployees()
        {
            return _employees;
        }
    }
}