using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeMS.Models.Stubs;
using EmployeeMS.Models.ViewModels;

namespace EmployeeMS.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            //construct VM using Linq
            IEnumerable<EmplListVM> model = from e in EmplRepoStub.ReadAllEmployees()
                join d in DeptRepoStub.ReadAllDepartments()
                    on e.DepartmentId equals d.Id
                select new EmplListVM
                {
                    Name = e.FirstName + " " + e.LastName,
                    DeptName = d.Name,
                    PhoneNum = e.PhoneNum,
                    EmplId = e.Id
                };

            //method syntax equivalent
            /*
            IEnumerable<EmplListVM> model2 = EmplRepoStub.ReadAllEmployees()
                .Join(
                    DeptRepoStub.ReadAllDepartments(),
                    empl => empl.DepartmentId,
                    dept => dept.Id,
                    (empl, dept) => new EmplListVM
                    {
                        Name = empl.FirstName + " " + empl.LastName,
                        DeptName = dept.Name,
                        PhoneNum = empl.PhoneNum,
                        EmplId = empl.Id
                    }
                );
                */

            return View(model);
        }
    }
}