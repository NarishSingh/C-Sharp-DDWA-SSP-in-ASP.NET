using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeMS.Models;
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
            /*
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
                */

            //method syntax equivalent
            IEnumerable<EmplListVM> model = EmplRepoStub.ReadAllEmployees()
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

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmplVM model = new AddEmplVM
            {
                Departments = GetDepartmentsSelectListItems()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmplVM model)
        {
            if (!ModelState.IsValid)
            {
                //have to manually reload select list item list as nothing is coming back from model data
                model.Departments = GetDepartmentsSelectListItems();
                return View(model); //return them to add page on fail
            }

            Employee add = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNum = model.PhoneNum,
                DepartmentId = model.DeptId
            };

            EmplRepoStub.CreateEmployee(add);

            return RedirectToAction("List"); //redirect them to list view on completion
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee empl = EmplRepoStub.ReadEmployee(id);

            var model = new EditEmplVM
            {
                EmployeeId = empl.Id,
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                DeptId = empl.DepartmentId,
                PhoneNum = empl.PhoneNum,
                Departments = GetDepartmentsSelectListItems()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEmplVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Departments = GetDepartmentsSelectListItems();
                return View(model);
            }

            Employee edit = new Employee
            {
                Id = model.EmployeeId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNum = model.PhoneNum,
                DepartmentId = model.DeptId
            };

            EmplRepoStub.EditEmployee(edit);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmplRepoStub.DeleteEmployee(id);

            return RedirectToAction("List");
        }

        /*HELPERS*/
        /// <summary>
        /// Load Departments for drop down selects
        /// </summary>
        /// <returns>List of SelectListItem's for Views</returns>
        private static List<SelectListItem> GetDepartmentsSelectListItems()
        {
            return DeptRepoStub.ReadAllDepartments()
                .Select(
                    d => new SelectListItem
                    {
                        Text = d.Name,
                        Value = d.Id.ToString()
                    }
                )
                .ToList();
        }
    }
}