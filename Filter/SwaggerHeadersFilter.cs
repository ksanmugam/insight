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
                Description = "Version of the API endpoint requested by the client. Must be set to a positive integer. The endpoint should respond with the highest supported version between x-min-v and x-v. If the value of x-min-v is equal to or higher than the value of x-v then the x-min-v header should be treated as absent. If all versions requested are not supported then the endpoint MUST respond with a 406 Not Acceptable."
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-min-v",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "integer" },
                Description = "Minimum version of the API endpoint requested by the client. Must be set to a positive integer if provided. The endpoint should respond with the highest supported version between x-min-v and x-v. If all versions requested are not supported then the endpoint MUST respond with a 406 Not Acceptable."
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-fapi-interaction-id",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string", Format = "uuid" },
                Description = "An [RFC4122] UUID used as a correlation id. If provided, the data holder MUST play back this value in the x-fapi-interaction-id response header. If not provided a [RFC4122] UUID value is required to be provided in the response header to track the interaction."
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-fapi-auth-date",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "The time when the customer last logged in to the Data Recipient Software Product as described in [FAPI-1.0-Baseline]. Required for all resource calls (customer present and unattended). Not required for unauthenticated calls."
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-fapi-customer-ip-address",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "The customer's original IP address if the customer is currently logged in to the Data Recipient Software Product. The presence of this header indicates that the API is being called in a customer present context. Not to be included for unauthenticated calls."
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-cds-client-headers",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "The customer's original standard http headers Base64 encoded, including the original User-Agent header, if the customer is currently logged in to the Data Recipient Software Product. Mandatory for customer present calls. Not required for unattended or unauthenticated calls."
            });
        }
    }
}
