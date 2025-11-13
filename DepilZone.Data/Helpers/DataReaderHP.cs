using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Helpers
{
    public static class DataReaderHP
    {
        public static async Task<List<Dictionary<string, object>>> ToDictionaryListAsync(this DbDataReader reader)
        {
            var list = new List<Dictionary<string, object>>();

            while (await reader.ReadAsync())
            {
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict[reader.GetName(i)] = reader[i] != DBNull.Value ? reader[i] : null;
                }
                list.Add(dict);
            }

            return list;
        }
    }
}
