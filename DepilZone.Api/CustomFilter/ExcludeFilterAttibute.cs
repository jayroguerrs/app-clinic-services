using Microsoft.AspNetCore.Mvc.Filters;

namespace DepilZone.Api.CustomFilter
{
    public class ExcludeFilterAttibute: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata
                .Any(attr => attr is ExcludeFilterAttibute))
            {
                return; // No aplicar el filtro
            }

            // Lógica del filtro aquí
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Lógica después de la ejecución de la acción
        }
    }
}
