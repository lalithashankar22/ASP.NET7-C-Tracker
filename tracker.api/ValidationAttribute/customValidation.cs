using System.ComponentModel.DataAnnotations;

namespace tracker.api.ValidationAttribute
{
    public class customValidation
    {
        // custom function 
            public static ValidationResult WeekendValidate(DateTime date)
            {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ? new ValidationResult("The wekeend days aren't valid") : ValidationResult.Success;
            }
     
    }
}
