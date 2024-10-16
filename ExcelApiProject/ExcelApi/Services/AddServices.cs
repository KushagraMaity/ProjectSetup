﻿using ExcelApi.Model;
using ExcelLib.CsvHelper;
using ExcelLib.NpoiHelper;
using ExcelLib.OpenXmlHelper;
using ExcelLib.TextHelper;

namespace ExcelApi.Services
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection srv)
        {

            srv.AddScoped<ExtendedOpenXml>();
            srv.AddScoped<ExtendedNpoi>();
            srv.AddScoped<CsvHelper>();
            srv.AddScoped<TextHelper>();
            srv.AddSingleton<UserDetails>();
        }
    }
}
