using System.Collections.Generic;

namespace EmployeeMS.Models.Stubs
{
    public class DeptRepoStub
    {
        private static List<Department> _departments;

        static DeptRepoStub()
        {
            _departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                new Department
                {
                    Id = 2,
                    Name = "Finance"
                },
                new Department
                {
                    Id = 3,
                    Name = "Sales"
                }
            };
        }

        public static List<Department> ReadAllDepartments()
        {
            return _departments;
        }
    }
}