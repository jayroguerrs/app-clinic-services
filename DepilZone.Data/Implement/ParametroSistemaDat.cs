using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ParametroSistemaDat : IParametroSistemaDat
    {
        private readonly string _connectionString;
        public ParametroSistemaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ParametroSistema_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", Id);
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
        public async Task<IEnumerable<ParametroSistemaEnt>> ObtenerParametrosEmail()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ParametroSistema_ObtenerConfgCorreo", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemEmail(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<string>> ObtenerLinkQA()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_ObtenerLinkQA", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemLinkQa(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el link QA", ex);
            }
        }


        public async Task<List<ParametroSistemaEnt>> ObtenerParametros()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ParametroSistema_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerParametros(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> ObtenerValorByParametro(string Parametro)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ParametroSistema_ObtenerValorByParametro", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                string output = "";
                while (await reader.ReadAsync())
                {
                    output = Convert.ToString(reader["Valor"]);
                }

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<Respuesta<ParametroSistemaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ParametroSistemaEnt> obj = new Respuesta<ParametroSistemaEnt>
                {
                    Response = new ParametroSistemaEnt()
                };
                obj.Exito = true;
                while (await reader.ReadAsync())
                {
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    obj.Response.Parametro = reader["Parametro"].ToString();
                    obj.Response.Valor = reader["Valor"].ToString();
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<string>> ReadItemLinkQa(DbDataReader reader)
        {
            try
            {
                Respuesta<string> obj = new Respuesta<string>
                {
                    Response = ""
                };
                obj.Exito = true;
                while (await reader.ReadAsync())
                {
                    obj.Response = reader["Valor"].ToString();
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<ParametroSistemaEnt>> ReadItemEmail(DbDataReader reader)
        {
            try
            {
                IList<ParametroSistemaEnt> parametros = new List<ParametroSistemaEnt>();
                while (await reader.ReadAsync())
                {
                    parametros.Add(new ParametroSistemaEnt()
                    {
                        Valor = reader["Valor"].ToString(),
                        Parametro = reader["Parametro"].ToString(),
                        Id = Convert.ToInt32(reader["Id"])
                    });
                }


                return parametros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ParametroSistemaEnt>> ReadObtenerParametros(DbDataReader reader)
        {
            try
            {
                List<ParametroSistemaEnt> parametros = new List<ParametroSistemaEnt>();
                while (await reader.ReadAsync())
                {
                    parametros.Add(new ParametroSistemaEnt()
                    {
                        Valor = reader["Valor"].ToString(),
                        Parametro = reader["Parametro"].ToString(),
                        Id = Convert.ToInt32(reader["Id"])
                    });
                }


                return parametros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}