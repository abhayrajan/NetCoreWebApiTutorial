using Microsoft.AspNetCore.Builder;

namespace Sogeti.Solution.Service.Training.Middleware
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorrelationModule(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationModule>();
        }
    }
}
