using System;
using System.Web.Mvc;

namespace AdvModelBinding.Models.BdayModels
{
    public class BdayPersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var person = new BdayPerson
            {
                FirstName = request.Form["FirstName"],
                LastName = request.Form["LastName"]
            };

            //reassemble the date from form parts
            int month = int.Parse(request.Form["month"]);
            int day = int.Parse(request.Form["day"]);
            int year = int.Parse(request.Form["year"]);

            person.Birthday = new DateTime(year, month, day);

            return person;
        }
    }
}