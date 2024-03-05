namespace NoteApp.Infrastructure.Configuration
{
    public static class CORSConfiguration
    {
        public static IServiceCollection ConfigureCORS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                string corsUrls = AppSettingConfiguration.AppSets.CORSEnabledURL;
                string[] Orgins = corsUrls.Split(",");

                options.AddPolicy("CorsPolicy", p => p.WithOrigins(Orgins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }

        public static IApplicationBuilder EnableCORS(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");

            return app;
        }
    }
}
