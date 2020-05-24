using Articles.Core.Application.Common.Interfaces;
using Articles.Core.Application.Common.Interfaces.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Articles.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArticleDbContext>(options => options.UseSqlServer(                
                string.Format(
                    configuration.GetConnectionString("ConnectionFormat"),
                    configuration["SqlServerName"],
                    configuration["SqlServerPort"],
                    configuration["SqlServerCatalog"],
                    configuration["SqlServerUser"],
                    configuration["SqlServerPassword"])
                ));
            services.AddScoped<IArticleDbContext>(provider => provider.GetService<ArticleDbContext>());
            services.AddScoped<IArticleRepo, ArticleRepo>();
            services.AddScoped<IAuthorRepo, AuthorRepo>();
            services.AddScoped<IArticleSearchRepo, ArticleRepo>();
            return services;
        }
    }
}
