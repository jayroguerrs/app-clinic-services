using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class PromocionPlantillaDat : IPromocionPlantillaDat
    {
        private readonly string _connectionString;
        public PromocionPlantillaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<PromocionPlantillaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Plantilla_Obtener", conn)
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

        public async Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(Int32 IdPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Plantilla_ObtenerByIdPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocion", IdPromocion);
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
        public async Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Plantilla_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("Alias", model.Alias);
                cmd.Parameters.AddWithValue("Concepto", model.Concepto);
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

        public async Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Plantilla_ObtenerByLikeAlias", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Alias", Alias);
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

        public async Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Promocion_Plantilla_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdPromocionPlantilla", model.IdPromocionPlantilla);
                cmd.Parameters.AddWithValue("IdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("Alias", model.Alias);
                cmd.Parameters.AddWithValue("Concepto", model.Concepto);
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

        static async Task<PromocionPlantillaEnt> Read(DbDataReader reader)
        {
            try
            {
                PromocionPlantillaEnt obj = new PromocionPlantillaEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdPromocionPlantilla = Convert.ToInt32(reader["IdPromocionPlantilla"]);
                    obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
                    obj.Alias = Convert.ToString(reader["Alias"]);
                    obj.Concepto = Convert.ToString(reader["Concepto"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<PromocionPlantillaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PromocionPlantillaEnt> obj = new Respuesta<PromocionPlantillaEnt>
                {
                    Response = new PromocionPlantillaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdPromocionPlantilla = Convert.ToInt32(reader["IdPromocionPlantilla"]);
                    obj.Response.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
                    obj.Response.Alias = Convert.ToString(reader["Alias"]);
                    obj.Response.Concepto = Convert.ToString(reader["Concepto"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<PromocionPlantillaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<PromocionPlantillaEnt> lista = new List<PromocionPlantillaEnt>();
                while (await reader.ReadAsync())
                {
                    PromocionPlantillaEnt obj = new PromocionPlantillaEnt
                    {
                        IdPromocionPlantilla = reader.GetFieldValue<int>(0),
                        IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                        Alias = reader["Alias"].ToString(),
                        Concepto = reader["Concepto"].ToString()
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
