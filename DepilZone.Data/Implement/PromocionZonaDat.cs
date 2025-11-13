using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PromocionZonaDat: IPromocionZonaDat
    {
        private readonly string _connectionString;
        public PromocionZonaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<PromocionZonaDTO>> Obtener(int IdPromocion, int IdGenero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("pIdGenero", IdGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems2(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int IdPromocion, int IdGenero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_ObtenerByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdPromocion", IdPromocion);
                cmd.Parameters.AddWithValue("pIdGenero", IdGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems2(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByIdsZonasCorporales(string idsZonasCorporales)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_ObtenerPorZonasCorporales", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdsZonasCorporales", idsZonasCorporales);
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

        public async Task<List<PromocionZonaDTO>> ListarByZona(int idZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_ListarByZona", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdZona", idZona);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarByZona(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<Respuesta<PromocionZonaDTO>> Insertar(PromocionZonaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("pIdZona", model.IdZona);
                cmd.Parameters.AddWithValue("pSexo", model.IdGenero);
                cmd.Parameters.AddWithValue("pPrecioBase", model.PrecioBase);
                cmd.Parameters.AddWithValue("pActivo", model.Activo);
                cmd.Parameters.AddWithValue("pPromocionPrecios", JsonSerializer.Serialize(model.PromocionPrecios));
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                var reader = await cmd.ExecuteReaderAsync();
                Respuesta<PromocionZonaDTO> obj = new Respuesta<PromocionZonaDTO>
                {
                    Response = new PromocionZonaDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        var objModel = new PromocionZonaDTO
                        {
                            IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                            Activo = Convert.ToInt32(reader["Activo"]),
                        };
                        obj.Response = objModel;
                    }
                }


                conn.Close();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<PromocionZonaEnt>> ModificarPrecioBase(PromocionZonaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_Modificar_PrecioBase", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocionZona", model.IdPromocionZona);
                cmd.Parameters.AddWithValue("pPrecioBase", model.PrecioBase);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
                var reader = await cmd.ExecuteReaderAsync();
                Respuesta<PromocionZonaEnt> obj = new Respuesta<PromocionZonaEnt>
                {
                    Response = new PromocionZonaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        var objModel = new PromocionZonaEnt
                        {
                            IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            IdGenero = Convert.ToInt32(reader["IdGenero"]),
                            PrecioBase = Convert.ToDecimal(reader["PrecioBase"])
                        };
                        obj.Response = objModel;
                    }
                }

                conn.Close();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<IEnumerable<PromocionZonaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<PromocionZonaDTO> lista = new List<PromocionZonaDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = Mapear(reader);
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<PromocionZonaDTO>> ReadItems2(DbDataReader reader)
        {
            try
            {
                IList<PromocionZonaDTO> lista = new List<PromocionZonaDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = Mapear2(reader);
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static PromocionZonaDTO Mapear(DbDataReader reader)
        {
            try
            {
                var obj = new PromocionZonaDTO
                {
                    IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                    IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                    IdZona = Convert.ToInt32(reader["IdZona"]),
                    Sexo = reader["IdGenero"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                    IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                    PrecioPromocion = Convert.ToDecimal(reader["Precio"]),
                };


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static PromocionZonaDTO Mapear2(DbDataReader reader)
        {
            try
            {
                var obj = new PromocionZonaDTO
                {
                    IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                    IdZona = Convert.ToInt32(reader["IdZona"]),
                    Sexo = reader["IdGenero"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                    IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                };

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<PromocionZonaEnt>> DeleteById(int IdPromocionZona)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocionZona", IdPromocionZona);

                var reader = await cmd.ExecuteReaderAsync();
                var obj = new Respuesta<PromocionZonaEnt>
                {
                    Response = new PromocionZonaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<int>> DeleteByIds(string Ids)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionZona_DeleteByIds", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                List<int> ids_array = new List<int>();
                foreach (var item in Ids.Split(','))
                {
                    ids_array.Add(Convert.ToInt32(item));
                }
                var d = JsonSerializer.Serialize(ids_array);
            
                cmd.Parameters.AddWithValue("pIds", JsonSerializer.Serialize(ids_array) );

                var reader = await cmd.ExecuteReaderAsync();
                List<int> respuesta = new List<int>();
                bool Exito = false;
                string Mensaje = "";

                var a = d;

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    Mensaje = Convert.ToString(reader["Mensaje"]);

                    if (!Exito) {
                        throw new AlertException(Mensaje);
                    }

                    respuesta  = new List<int>(JsonSerializer.Deserialize<List<int>>(Convert.ToString(reader["Ids"])));
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS
        static async Task<List<PromocionZonaDTO>> ReadListarByZona(DbDataReader reader)
        {
            try
            {
                List<PromocionZonaDTO> collection = new List<PromocionZonaDTO>();
                while (await reader.ReadAsync())
                {
                    PromocionZonaDTO obj = new PromocionZonaDTO()
                    {
                        Id = Convert.ToInt32(reader["IdPromocionZona"]),
                        IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Promocion = Convert.ToString(reader["Promocion"]),
                        IdZona = Convert.ToInt32(reader["IdZona"]),
                        IdGenero = Convert.ToInt32(reader["IdGenero"]),
                        PrecioBase = Convert.ToInt32(reader["PrecioBase"]),
                        PrecioPromocion = Convert.ToInt32(reader["PrecioPromocion"]),
                    };
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
