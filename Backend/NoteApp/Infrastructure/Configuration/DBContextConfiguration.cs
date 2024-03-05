using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace NoteApp.Infrastructure.Configuration
{
    public static class DBContextConfiguration
    {
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(AppSettingConfiguration.AppSets.ConnectionString));

            return services;
        }
    }
}
