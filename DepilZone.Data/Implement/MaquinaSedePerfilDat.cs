using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class MaquinaSedePerfilDat : IMaquinaSedePerfilDat
    {
        private readonly string _connectionString;
        public MaquinaSedePerfilDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<bool> Insertar(MaquinaSedePerfilDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSedePerfil_AsignarPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdMaquinaSede", model.IdMaquinaSede);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdPerfiles", JsonSerializer.Serialize(model.IdPerfiles));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public async Task<List<MaquinaSedePerfilDTO>> ObtenerByMaquinaSede(int idUsuario, int idMaquinaSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSedePerfil_ListarPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdMaquinaSede", idMaquinaSede);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerByMaquinaSede(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<bool> ReadInsertar(DbDataReader reader)
        {

            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<List<MaquinaSedePerfilDTO>> ReadObtenerByMaquinaSede(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;

                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                List<MaquinaSedePerfilDTO> collection = new List<MaquinaSedePerfilDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        MaquinaSedePerfilDTO model = new MaquinaSedePerfilDTO();
                        model.Id = Convert.ToInt32(reader["Id"]);
                        model.IdMaquinaSede = Convert.ToInt32(reader["IdMaquinaSede"]);
                        model.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        model.Perfil = Convert.ToString(reader["Perfil"]);
                        model.Maquina = Convert.ToString(reader["Maquina"]);
                        collection.Add(model);
                    }
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