using System;
using System.ComponentModel.DataAnnotations;

namespace AttributesSSV.Attributes
{
    public class NoWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dt)
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}