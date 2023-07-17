using Agora.Api.Common;
using Agora.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Agora.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory, AgoraProblemDetailsFactory>();

        return services;
    }
}
