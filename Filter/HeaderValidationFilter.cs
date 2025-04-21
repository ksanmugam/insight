using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using BigPurpleBank.Models.v2;
using static BigPurpleBank.Helpers.Contants;
using Moq;
using Xunit;

namespace BigPurpleBank.Filter
{
    public class HeaderValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            // Validate 'x-v' (Mandatory)
            if (!headers.TryGetValue("x-v", out var xV) || !int.TryParse(xV, out var xVInt) || xVInt <= 0)
            {
                context.Result = new BadRequestObjectResult(new ErrorV2
                {
                    Code = ErrorCodes.InvalidField,
                    Title = "Invalid Field",
                    Detail = "The 'x-v' header must be a positive integer."
                });
                return;
            }

            // Validate 'x-min-v' (Optional but if provided, must be valid)
            int? xMinVInt = null;
            if (headers.TryGetValue("x-min-v", out var xMinV))
            {
                if (!int.TryParse(xMinV, out var xMinParsed) || xMinParsed <= 0)
                {
                    context.Result = new BadRequestObjectResult(new ErrorV2
                    {
                        Code = ErrorCodes.InvalidField,
                        Title = "Invalid Field",
                        Detail = "'x-min-v' must be a positive integer if provided."
                    });
                    return;
                }
                if (xMinParsed >= xVInt) xMinVInt = null; // Treat as absent
                else xMinVInt = xMinParsed;
            }

            // Validate Version Negotiation (If x-v or x-min-v is invalid, return 406)
            if (xVInt <= 0 || (xMinVInt.HasValue && xVInt < xMinVInt.Value))
            {
                context.Result = new ObjectResult(new ErrorV2
                {
                    Code = ErrorCodes.UnsupportedVersion,
                    Title = "Unsupported Version",
                    Detail = "The requested version is not supported."
                })
                { StatusCode = 406 }; // Not Acceptable
                return;
            }

            // Validate 'x-fapi-interaction-id' (Optional, but must be UUID if provided)
            if (headers.TryGetValue("x-fapi-interaction-id", out var interactionId) && !Guid.TryParse(interactionId, out _))
            {
                context.Result = new BadRequestObjectResult(new ErrorV2
                {
                    Code = ErrorCodes.InvalidField,
                    Title = "Invalid Field",
                    Detail = "'x-fapi-interaction-id' must be a valid UUID."
                });
                return;
            }

            // Validate 'x-fapi-auth-date' (Required for customer-present calls)
            if (headers.ContainsKey("x-fapi-auth-date") && string.IsNullOrWhiteSpace(headers["x-fapi-auth-date"]))
            {
                context.Result = new BadRequestObjectResult(new ErrorV2
                {
                    Code = ErrorCodes.MissingRequiredField,
                    Title = "Missing Required Field",
                    Detail = "'x-fapi-auth-date' is required for authenticated/customer-present calls."
                });
                return;
            }

            // Validate 'x-cds-client-headers' (Base64 encoded string if provided)
            if (headers.ContainsKey("x-cds-client-headers") && !IsBase64String(headers["x-cds-client-headers"]))
            {
                context.Result = new BadRequestObjectResult(new ErrorV2
                {
                    Code = ErrorCodes.InvalidField,
                    Title = "Invalid Field",
                    Detail = "'x-cds-client-headers' must be a valid Base64 string."
                });
                return;
            }
        }

        // This method will help validate the Base64 string
        private bool IsBase64String(string value)
        {
            Span<byte> buffer = new Span<byte>(new byte[value.Length]);
            return Convert.TryFromBase64String(value, buffer, out _);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No post-processing required
        }

    }
}
