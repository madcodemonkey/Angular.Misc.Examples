using Microsoft.Extensions.DependencyInjection;

namespace ACME.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddAcmeServices(this IServiceCollection sc)
        {

            sc.AddScoped<IToolReportService, ToolReportService>();
            sc.AddScoped<IZipService, ZipService>();

            return sc;
        }
    }
}
