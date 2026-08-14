using System.Security.Claims;
using System.Threading.RateLimiting;

namespace ShoppingList_WebAPI.Extensions;

public static class RateLimitingExtensions
{
    public static IServiceCollection AddCustomRateLimiting(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
            {
                var isAuthenticated = context.User.Identity?.IsAuthenticated ?? false;

                if (isAuthenticated)
                {
                    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "unknown";
                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: $"user:{userId}",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 100,
                            Window = TimeSpan.FromMinutes(1)
                        });
                }

                var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                return RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: $"anon:{ip}",
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromMinutes(1)
                    });
            });

            options.AddPolicy("strict", context =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromMinutes(15)
                    }));
        });

        return services;
    }
}