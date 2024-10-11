using ExcelApi.Model;
using ExcelLib.CsvHelper;
using ExcelLib.OpenXmlUtility;

namespace ExcelApi.Services
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection srv)
        {

            srv.AddScoped<ExtendedOpenXml>();
            srv.AddScoped<CsvHelper>();
            srv.AddSingleton<UserDetails>();
        }
    }
}
