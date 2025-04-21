using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BigPurpleBank.Filter
{
    public class SwaggerHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-v",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema { Type = "integer" },
                Description = "Mandatory version header"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-min-v",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "integer" },
                Description = "Optional minimum version"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-fapi-interaction-id",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string", Format = "uuid" },
                Description = "Optional UUID for interaction tracking"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-fapi-auth-date",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "Auth date for customer-present calls"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-cds-client-headers",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "Base64 encoded client metadata"
            });
        }
    }
}
