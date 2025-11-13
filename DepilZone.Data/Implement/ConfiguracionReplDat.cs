using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class ConfiguracionReplDat : IConfiguracionReplDat
    {
        private readonly string _connectionString;

        public ConfiguracionReplDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ConfiguracionReplEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracionreplace_Obtener", conn)
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
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracion(Int32 IdConfiguracion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_ObtenerByIdConfiguracion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdConfiguracion", IdConfiguracion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ConfiguracionReplEnt> ObtenerByIdConfiguracionDNI(string DNI, string IdConfiguracion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_ObtenerByIdConfiguracionDNI", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("DNI", DNI);
                cmd.Parameters.AddWithValue("IdConfiguracion", IdConfiguracion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<ConfiguracionReplEnt>> Modificar(ConfiguracionReplEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_replace", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdConfiguracion", model.IdConfiguracion);
                cmd.Parameters.AddWithValue("nombreapellidoreplace", model.nombreapellidoreplace);
                cmd.Parameters.AddWithValue("dnireplace", model.dnireplace);
                cmd.Parameters.AddWithValue("zonasreplace", model.zonasreplace);
                cmd.Parameters.AddWithValue("firmaclientereplace", model.firmaclientereplace);
                cmd.Parameters.AddWithValue("firmadepilzonereplace", model.firmadepilzonereplace);
                cmd.Parameters.AddWithValue("informacion", model.informacion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<IEnumerable<ConfiguracionReplEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                //obj.IdPerfil = reader.IsDBNull(4) ? null : reader.GetFieldValue<string>(4);
                //reader.IsDBNull(5) ? DateTime.MinValue : reader.GetFieldValue<DateTime>(5);
                ConfiguracionReplEnt obj = null;
                IList<ConfiguracionReplEnt> lista = new List<ConfiguracionReplEnt>();
                while (await reader.ReadAsync())
                {
                    obj = new ConfiguracionReplEnt();
                    obj.IdConfiguracion = reader["IdConfiguracion"].ToString();
                    obj.nombreapellidoreplace = reader["nombreapellidoreplace"].ToString();
                    obj.dnireplace = reader["dnireplace"].ToString();
                    obj.zonasreplace = reader["zonasreplace"].ToString();
                    obj.firmaclientereplace = reader["firmaclientereplace"].ToString();
                    obj.firmadepilzonereplace = reader["firmadepilzonereplace"].ToString();
                    obj.@informacion = reader["@informacion"].ToString();
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<ConfiguracionReplEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ConfiguracionReplEnt> obj = new Respuesta<ConfiguracionReplEnt>();
                obj.Response = new ConfiguracionReplEnt();
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdConfiguracion = Convert.ToString(reader["IdConfiguracion"]);
                    obj.Response.nombreapellidoreplace = Convert.ToString(reader["nombreapellidoreplace"]);
                    obj.Response.dnireplace = Convert.ToString(reader["dnireplace"]);
                    obj.Response.zonasreplace = Convert.ToString(reader["zonasreplace"]);
                    obj.Response.firmaclientereplace = Convert.ToString(reader["firmaclientereplace"]);
                    obj.Response.firmadepilzonereplace = Convert.ToString(reader["firmadepilzonereplace"]);
                    obj.Response.informacion = Convert.ToString(reader["informacion"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<ConfiguracionReplEnt> Read(DbDataReader reader)
        {
            try
            {
                ConfiguracionReplEnt obj = new ConfiguracionReplEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdConfiguracion = reader["IdConfiguracion"].ToString();
                    obj.nombreapellidoreplace = reader["nombreapellidoreplace"].ToString();
                    obj.dnireplace = reader["dnireplace"].ToString();
                    obj.zonasreplace = reader["zonasreplace"].ToString();
                    obj.firmaclientereplace = reader["firmaclientereplace"].ToString();
                    obj.firmadepilzonereplace = reader["firmadepilzonereplace"].ToString();
                    obj.informacion = reader["informacion"].ToString();
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
