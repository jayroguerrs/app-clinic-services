using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class Add401Response : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Responses.Add("401", new OpenApiResponse
        {
            Description = "Acceso denegado. No tienes autorización para acceder a este recurso.",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/json"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = new Dictionary<string, OpenApiSchema>
                        {
                            ["message"] = new OpenApiSchema { Type = "string" },
                            ["statusCode"] = new OpenApiSchema { Type = "integer" }
                        },
                        Required = new HashSet<string> { "message", "statusCode" }
                    }
                }
            }
        });
    }
}
