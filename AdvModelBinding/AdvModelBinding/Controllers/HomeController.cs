using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvModelBinding.Models;
using AdvModelBinding.Models.BdayModels;
using AdvModelBinding.Models.CategoryModels;

namespace AdvModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckboxList()
        {
            //load list of categories then convert them to ViewModel with Linq to create anon types
            var model = new CategoryPickerViewModel
            {
                CheckboxItems =
                (
                    from category in CategoryRepoStub.GetAll()
                    select new CategoryCheckboxItem
                    {
                        Category = category,
                        IsSelected = false
                    }
                ).ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckboxList(CategoryPickerViewModel model)
        {
            //use Linq query to select ticked categories
            var selectedIds = model.CheckboxItems
                .Where(c => c.IsSelected)
                .Select(c => c.Category.CategoryId);

            return View("PickResults", selectedIds);
        }

        [HttpGet]
        public ActionResult BdayForm()
        {
            return View(new BdayPerson());
        }

        [HttpPost]
        public ActionResult BdayForm([ModelBinder(typeof(BdayPersonBinder))]BdayPerson model)
        {
            return View(model);
        }
    }
}