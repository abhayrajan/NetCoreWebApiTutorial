using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sogeti.Solution.Service.Training.Common;

namespace Sogeti.Solution.Service.Training.Middleware
{
    public class CorrelationModule
    {
        private readonly RequestDelegate _next;

        public CorrelationModule(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing.
            string correlationId = context.Request.Headers[Constants.CorrelationHeader];
            if (String.IsNullOrEmpty(correlationId))
            {
                context.Request.Headers.Add(Constants.CorrelationHeader, Guid.NewGuid().ToString());
            }
            await _next.Invoke(context);

            // Clean up.
        }
    }
}
