using System.ComponentModel.DataAnnotations;

namespace AttributesSSV.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is bool b)
            {
                return b; //casts to bool and returns
            }

            return false;
        }
    }
}