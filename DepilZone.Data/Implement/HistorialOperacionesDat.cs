using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class HistorialOperacionesDat : IHistorialOperacionesDat
	{
        private readonly string _connectionString;
        public HistorialOperacionesDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<HistorialMensajeMasivoDTO>> ListarHistorialEnvioMasivoMensaje()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Historial_RegistroMasivoMensajeCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarHistorialEnvioMasivoMensaje(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
       

        // READERS

        static async Task<List<HistorialMensajeMasivoDTO>> ReadListarHistorialEnvioMasivoMensaje(DbDataReader reader)
        {
            try
            {
                List<HistorialMensajeMasivoDTO> collection = new List<HistorialMensajeMasivoDTO>();
                while (await reader.ReadAsync())
                {
                    HistorialMensajeMasivoDTO obj = new HistorialMensajeMasivoDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.NombreArchivo = Convert.ToString(reader["NombreArchivo"]);
                    obj.NumeroRegistros = Convert.ToInt32(reader["NumeroRegistros"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
       

    }
}
