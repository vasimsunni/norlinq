using NoteApp.Core.Repository;

namespace NoteApp.Infrastructure.Configuration
{
    public static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Dependency Injection for services
            
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            //Dependency Injection for repo

            //Generic repo registeration to allow all repos for entity. Must be scoped
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
