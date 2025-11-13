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
    public class ConfiguracionDat  : IConfiguracionDat
    {
        private readonly string _connectionString;

        public ConfiguracionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ConfiguracionEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

        public async Task<IEnumerable<ConfiguracionEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Maquina_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
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
        public async Task<ConfiguracionEnt> ObtenerByIdConfiguracion(Int32 IdConfiguracion)
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

        public async Task<Respuesta<ConfiguracionEnt>> Insertar(ConfiguracionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("CodigoTabla", model.CodigoTabla);
                cmd.Parameters.AddWithValue("Tabla", model.Tabla);
                cmd.Parameters.AddWithValue("Valor", model.Valor);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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
        public async Task<Respuesta<ConfiguracionEnt>> Modificar(ConfiguracionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Configuracion_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdConfiguracion", model.IdConfiguracion);
                cmd.Parameters.AddWithValue("CodigoTabla", model.CodigoTabla);
                cmd.Parameters.AddWithValue("Tabla", model.Tabla);
                cmd.Parameters.AddWithValue("Valor", model.Valor);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
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

        static async Task<ConfiguracionEnt> Read(DbDataReader reader)
        {
            try
            {
                ConfiguracionEnt obj = new ConfiguracionEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdConfiguracion = reader["IdConfiguracion"].ToString();
                    obj.CodigoTabla = reader["CodigoTabla"].ToString();
                    obj.Tabla = reader["Tabla"].ToString();
                    obj.Valor = reader["Valor"].ToString();
                    obj.Descripcion = reader["Descripcion"].ToString();
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<ConfiguracionEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ConfiguracionEnt> obj = new Respuesta<ConfiguracionEnt>();
                obj.Response = new ConfiguracionEnt();
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdConfiguracion = Convert.ToString(reader["IdConfiguracion"]);
                    obj.Response.CodigoTabla = Convert.ToString(reader["CodigoTabla"]);
                    obj.Response.Tabla = Convert.ToString(reader["Tabla"]);
                    obj.Response.Valor = Convert.ToString(reader["Valor"]);
                    obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<ConfiguracionEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                //obj.IdPerfil = reader.IsDBNull(4) ? null : reader.GetFieldValue<string>(4);
                //reader.IsDBNull(5) ? DateTime.MinValue : reader.GetFieldValue<DateTime>(5);
                ConfiguracionEnt obj = null;
                IList<ConfiguracionEnt> lista = new List<ConfiguracionEnt>();
                while (await reader.ReadAsync())
                {
                    obj = new ConfiguracionEnt();
                    obj.IdConfiguracion = reader["IdConfiguracion"].ToString();
                    obj.CodigoTabla = reader["CodigoTabla"].ToString();
                    obj.Tabla = reader["Tabla"].ToString();
                    obj.Valor = reader["Valor"].ToString();
                    obj.Descripcion = reader["Descripcion"].ToString();
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
