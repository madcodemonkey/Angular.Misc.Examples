using ACME.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ACME.Web
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllAcmeServices(this IServiceCollection sc)
        {
            sc.AddAcmeServices();

            return sc;
        }
    }
}
