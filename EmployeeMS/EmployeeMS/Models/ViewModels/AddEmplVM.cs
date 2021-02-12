using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeMS.Models.ViewModels
{
    public class AddEmplVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public int DeptId { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}