using ExcelLib.ExcelOperation;
using ExcelApi.LibraryIntegration;
using System.Runtime.CompilerServices;

namespace ExcelApi.Services
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection srv)
        {
            srv.AddScoped<IExcelLib, XlsxLib>();
            srv.AddScoped<Xlsx>();
        }
    }
}
