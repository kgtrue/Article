using Articles.Core.Application.Common.Interfaces.Contracts;
using Microsoft.Extensions.DependencyInjection;
namespace Articles.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IArticleSearchRepo, ArticleSolrSearchRepo>();
            return services;
        }
    }
}
