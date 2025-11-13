using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class EquipoLaserDat : IEquipoLaserDat
    {
        private readonly string _connectionString;

        public EquipoLaserDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<EquipoLaserEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_EquipoLaser_Obtener", conn)
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

        // Readers
        static async Task<IEnumerable<EquipoLaserEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<EquipoLaserEnt> lista = new List<EquipoLaserEnt>();
                while (await reader.ReadAsync())
                {
                    EquipoLaserEnt obj = new EquipoLaserEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"] == DBNull.Value ? null : reader["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
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
