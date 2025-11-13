using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PromocionPrecioDat: IPromocionPrecioDat
    {
        private readonly string _connectionString;
        public PromocionPrecioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionPrecio_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocionZona", model.IdPromocionZona);
                cmd.Parameters.AddWithValue("pIdPromocionBloque", model.IdPromocionBloque);
                cmd.Parameters.AddWithValue("pPrecio", model.Precio);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);

                var reader = await cmd.ExecuteReaderAsync();
                var obj = new Respuesta<PromocionPrecioEnt>
                {
                    Response = new PromocionPrecioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        var objModel = new PromocionPrecioEnt
                        {
                            IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                            IdPromocionBloque = Convert.ToInt32(reader["IdPromocionBloque"]),
                            IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString()
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

        public async Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int IdPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionPrecio_ObtenerByIdPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", IdPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                List<PromocionPrecioEnt> lista = new List<PromocionPrecioEnt>();
                while (await reader.ReadAsync())
                {
                    var obj = new PromocionPrecioEnt
                    {
                        IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                        IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                        IdPromocionBloque = Convert.ToInt32(reader["IdPromocionBloque"]),
                        Precio = Convert.ToDecimal(reader["Precio"])
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Precio_Zona_Promocion_Obener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdZona", idzona);
                cmd.Parameters.AddWithValue("pSesiones", sesiones);
                cmd.Parameters.AddWithValue("pIdPromocion", idpromocion);
                var reader = await cmd.ExecuteReaderAsync();
                List<PrecioZonaPromocion> lista = new List<PrecioZonaPromocion>();
                while (await reader.ReadAsync())
                {
                    var obj = new PrecioZonaPromocion
                    {
                        Precio = Convert.ToInt32(reader["Precio"])
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionPrecio_Delete", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocionPrecio", IdPromocionPrecio);

                var reader = await cmd.ExecuteReaderAsync();
                var obj = new Respuesta<PromocionPrecioEnt>
                {
                    Response = new PromocionPrecioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                }

                conn.Close();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
