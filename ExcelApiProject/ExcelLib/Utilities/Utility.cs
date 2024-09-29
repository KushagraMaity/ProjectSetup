using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLib.Utilities
{
    internal static class Utility
    {
        public static DataTable ConvertModelToDataTable(dynamic model)
        {
            return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(model));
        }

        public static DataSet ConvertModelToDataSet<T>(List<List<T>> model)
        {
            DataSet ds = new DataSet();
            foreach (var modelItem in model)
            {
                ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(model)));
            }

            return ds;
        }
    }
}
