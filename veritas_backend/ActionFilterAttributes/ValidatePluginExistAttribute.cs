using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using veritas_backend.Manager;

namespace veritas_backend.ActionFilterAttributes
{
    public class ValidatePluginExistsAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var pluginManager = context.HttpContext.RequestServices.GetService<PluginManager>();

            string pluginName = context.RouteData.Values["pluginName"]?.ToString();

            if (!pluginManager.ContainsPlugin(pluginName))
            {
                context.Result = new BadRequestObjectResult($"Plugin '{pluginName}' does not exist.");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
