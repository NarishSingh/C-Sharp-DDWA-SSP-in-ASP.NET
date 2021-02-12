using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmployeeMS.Models.ViewModels
{
    public class AddEmplVM
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        
        public string PhoneNum { get; set; }
        
        public int DeptId { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}