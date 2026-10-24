using System.ComponentModel.DataAnnotations;

namespace Academix.Web.ViewModels.CustomValidationAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is not DateTime date)
            {
                return false;
            }

            return date >= DateTime.Now;
        }
    }
}
