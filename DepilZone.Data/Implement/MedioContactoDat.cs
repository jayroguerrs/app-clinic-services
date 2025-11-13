using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class MedioContactoDat : IMedioContactoDat
    {
        private readonly string _connectionString;
        public MedioContactoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<MedioContactoEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MedioContacto_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<IEnumerable<MedioContactoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                MedioContactoEnt obj = null;
                IList<MedioContactoEnt> lista = new List<MedioContactoEnt>();
                while (await reader.ReadAsync())
                {
                    obj = new MedioContactoEnt();
                    obj.Id = reader.GetFieldValue<int>(0);
                    obj.Nombre = reader["Nombre"].ToString();
                    obj.Tipo = reader["Tipo"] as Int32? ?? 0;
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
