using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class TipoComprobanteDat : ITipoComprobanteDat
    {
        private readonly string _connectionString;
        public TipoComprobanteDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<TipoComprobanteEnt>> Obtener()
        {

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoComprobante_Obtener", conn)
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
        
        public async Task<TipoComprobanteEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoComprobante_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", id);
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

        public async Task<Respuesta<TipoComprobanteEnt>> Insertar(TipoComprobanteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoComprobante_Insertar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion.ToUpper());
                cmd.Parameters.AddWithValue("pAbreviatura", model.Abreviatura.ToUpper());
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRespuesta(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<Respuesta<TipoComprobanteEnt>> Modificar(TipoComprobanteEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_TipoComprobante_Modificar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pAbreviatura", model.Abreviatura);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadRespuesta(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public async Task<List<TipoComprobanteEnt>> ObtenerToPuntoVenta(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_TipoComprobante_ListarParaPuntoVenta", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerToPuntoVenta(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        // READERS

        static async Task<TipoComprobanteEnt> ReadItem(DbDataReader reader)
        {
            try
            {
                TipoComprobanteEnt obj = new TipoComprobanteEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.Abreviatura = reader["Abreviatura"].ToString();
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.Valor = Convert.ToString(reader["Valor"]);
                    obj.PuntoVenta = Convert.ToBoolean(reader["PuntoVenta"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        static async Task<IEnumerable<TipoComprobanteEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<TipoComprobanteEnt> lista = new List<TipoComprobanteEnt>();
                while (await reader.ReadAsync())
                {
                    TipoComprobanteEnt obj = new TipoComprobanteEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Abreviatura = reader["Abreviatura"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
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

        static async Task<Respuesta<TipoComprobanteEnt>> ReadRespuesta(DbDataReader reader)
        {
            try
            {
                Respuesta<TipoComprobanteEnt> obj = new Respuesta<TipoComprobanteEnt>
                {
                    Response = new TipoComprobanteEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        obj.Response.Abreviatura = Convert.ToString(reader["Abreviatura"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    }
                }

                
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<TipoComprobanteEnt>> ReadObtenerToPuntoVenta(DbDataReader reader)
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


                List<TipoComprobanteEnt> lista = new List<TipoComprobanteEnt>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        TipoComprobanteEnt obj = new TipoComprobanteEnt
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Abreviatura = reader["Abreviatura"].ToString(),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Valor = reader["Valor"] == DBNull.Value ? null : Convert.ToString(reader["Valor"]),
                            PuntoVenta = Convert.ToBoolean(reader["PuntoVenta"])
                        };

                        lista.Add(obj);
                    }
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
