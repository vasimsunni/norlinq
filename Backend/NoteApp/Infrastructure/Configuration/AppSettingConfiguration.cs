namespace NoteApp.Infrastructure.Configuration
{
    public static class AppSettingConfiguration
    {
        public static AppSet AppSets;

        public static IServiceCollection LoadSettings(this IServiceCollection services, IConfiguration configuration)
        {
            AppSettings(configuration);

            return services;
        }

        public static AppSet AppSettings(this IConfiguration configuration)
        {
            if (AppSets == null)
            {
                PopulateSettings(configuration);
            }

            return AppSets;
        }

        private static void PopulateSettings(IConfiguration configuration)
        {
            AppSets = new AppSet();
            AppSets.ConnectionString = configuration.GetVal("ConnectionString:DevDB");
            AppSets.APIBaseURL = configuration.GetVal("Utility:APIBaseURL");
            AppSets.CORSEnabledURL = configuration.GetVal("CORS:EnabledUrl");
        }

        public static string GetVal(this IConfiguration configuration, string key)
        {
            try
            {
                return configuration[key].ToString();
            }
            catch (Exception ex) { }
            return "";
        }

    }

    public class AppSet
    {
        public string ConnectionString { get; set; }
        public string APIBaseURL { get; set; }
        public string CORSEnabledURL { get; set; }
    }
}
