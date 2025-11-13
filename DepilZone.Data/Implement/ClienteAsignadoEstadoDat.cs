using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ClienteAsignadoEstadoDat : IClienteAsignadoEstadoDat
    {
        private readonly string _connectionString;

        public ClienteAsignadoEstadoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ClienteAsignadoEstadoDTO>> Listado()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignadoEstado_Listado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // READERS


        static async Task<List<ClienteAsignadoEstadoDTO>> ReadListado(DbDataReader reader)
        {
            try
            {
                List<ClienteAsignadoEstadoDTO> lista = new List<ClienteAsignadoEstadoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteAsignadoEstadoDTO obj = new ClienteAsignadoEstadoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Estado = reader["Estado"].ToString(),
                        Color = reader["Color"].ToString()
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
