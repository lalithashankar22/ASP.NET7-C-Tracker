using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace tracker.api.ValidationAttribute
{
    public class ValidationModelAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(context.ModelState.IsValid == false) 
            {
                context.Result =new  BadRequestResult();
            }
        }
    }
}
