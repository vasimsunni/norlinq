using NoteApp.Core.Repository;
using NoteApp.Services.Note;

namespace NoteApp.Infrastructure.Configuration
{
    public static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Dependency Injection for services
            services.AddScoped<INoteService, NoteService>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            //Dependency Injection for repo

            //Generic repo registration to allow all repos for entity. Must be scoped
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
