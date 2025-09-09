using LMS.Infractructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts;

namespace LMS.Infractructure.Data.Configurations
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration
                .GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));
        
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
