using DepilZone.Data.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class HlpReporteDat : IHlpReporteDat
    {
        private readonly string _connectionString;

        public HlpReporteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<List<Dictionary<string, object>>> lstTipRepo()
        {
            var result = new List<Dictionary<string, object>>();

            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("SP_SEL_HlpReporte", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();                            
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.GetValue(i);
                                row[columnName] = value;
                            }

                            result.Add(row);
                        }
                    }
                }
            }

            return result;
        }
    }
}
