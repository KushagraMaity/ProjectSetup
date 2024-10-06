using ExcelApi.Model;
using ExcelLib.OpenXmlUtility;

namespace ExcelApi.Services
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection srv)
        {

            srv.AddScoped<OpenXml>();
            srv.AddSingleton<UserDetails>();
        }
    }
}
