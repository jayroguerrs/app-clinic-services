using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PreferenteHistorialDat : IPreferenteHistorialDat
    {
        private readonly string _connectionString;
        public PreferenteHistorialDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<PreferenteHistorialDTO>> Obtener(int idPreferente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PreferenteHistorial_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPreferente", idPreferente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS


        static async Task<List<PreferenteHistorialDTO>> ReadObtener(DbDataReader reader)
        {
            try
            {
                List<PreferenteHistorialDTO> collection = new List<PreferenteHistorialDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteHistorialDTO obj = new PreferenteHistorialDTO();


                    obj.Id = Convert.ToInt32(reader["id"]);
                    obj.IdPreferente = Convert.ToInt32(reader["idPreferente"]);
                    obj.IdEstado = Convert.ToInt32(reader["idEstado"]);
                    //obj.IdEstadoAtencion = DBNull.Value == reader["idEstadoAtencion"] ? (int?)null : Convert.ToInt32(reader["idEstadoAtencion"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["idUsuarioRegistro"]);
                    obj.IdTeleoperador = DBNull.Value == reader["idTeleoperador"] ? (int?)null : Convert.ToInt32(reader["idTeleoperador"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["fechaRegistro"]);

                    obj.Observacion = new List<string>(JsonSerializer.Deserialize<List<string>>(Convert.ToString(reader["Observacion"])));

                    obj.Estado = Convert.ToString(reader["estado"]);
                    obj.EstadoAtencion = DBNull.Value == reader["estadoAtencion"] ? null : Convert.ToString(reader["estadoAtencion"]);
                    obj.ComentarioAtencion = DBNull.Value == reader["ComentarioAtencion"] ? null : Convert.ToString(reader["ComentarioAtencion"]);
                    obj.Teleoperador = DBNull.Value == reader["teleoperador"] ? null : Convert.ToString(reader["teleoperador"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["usuarioRegistro"]);

                    obj.DatosModificados = DBNull.Value == reader["DatosModificados"] ? "" : Convert.ToString(reader["DatosModificados"]);
                    collection.Add(obj);

                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
