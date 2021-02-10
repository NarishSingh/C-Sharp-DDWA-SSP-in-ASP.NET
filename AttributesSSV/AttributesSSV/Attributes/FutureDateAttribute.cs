using System;
using System.ComponentModel.DataAnnotations;

namespace AttributesSSV.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dt)
            {
                if (DateTime.Today.AddDays(1) > dt)
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