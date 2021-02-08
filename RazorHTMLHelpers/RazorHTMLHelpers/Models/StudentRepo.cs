using System.Collections.Generic;

namespace RazorHTMLHelpers.Models
{
    public class StudentRepo
    {
        public static List<Student> ReadAllStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    Major = "Business",
                    Gpa = 3.5M
                },
                new Student
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Major = "Computer Science",
                    Gpa = 3.8M
                },
                new Student
                {
                    FirstName = "Mary",
                    LastName = "Watts",
                    Major = "English",
                    Gpa = 3.2M
                }
            };
        }
    }
}