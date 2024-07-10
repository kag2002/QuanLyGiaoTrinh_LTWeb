using BTH1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTL.Models.Authentication
{
    public class AuthenicationQuyen : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
                if(context.HttpContext.Session.GetString("Quyen") == "0")
                {
                    context.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                        {"Controller","Home" },
                        {"Action", "ErrorLayout" }
                   });
                }
            
        }
    }
}
