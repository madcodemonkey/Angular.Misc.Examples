using Microsoft.Extensions.DependencyInjection;

namespace ACME.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddAcmeServices(this IServiceCollection sc)
        {
            // Contain static list to hold the data
            sc.AddSingleton<IStateService, StateService>();
            sc.AddSingleton<IPeopleService, PeopleService>();

            // Scoped
            sc.AddScoped<IToolReportService, ToolReportService>();
            sc.AddScoped<IZipService, ZipService>();

            return sc;
        }
    }
}
