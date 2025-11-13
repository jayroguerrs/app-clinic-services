using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PromocionBloqueDat : IPromocionBloqueDat
    {
        private readonly string _connectionString;
        public PromocionBloqueDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionBloque_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", model.IdPromocion);
                cmd.Parameters.AddWithValue("pRangoIni", model.RangoIni);
                cmd.Parameters.AddWithValue("pRangoFin", model.RangoFin);
                cmd.Parameters.AddWithValue("pDescuentoPorcentaje", model.DescuentoPorcentaje);
                cmd.Parameters.AddWithValue("pDescuentoFijo", model.DescuentoFijo);
                cmd.Parameters.AddWithValue("pAumentFijo", model.AumentFijo);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
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
        public async Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionBloque_ObtenerByIdPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPromocion", IdPromocion);
                var reader = await cmd.ExecuteReaderAsync();
                var Lista_PromocionBloque = new List<PromocionBloqueEnt>();
                while (await reader.ReadAsync())
                {
                    var obj = Mapear(reader);
                    Lista_PromocionBloque.Add(obj);
                }

                conn.Close();

                return Lista_PromocionBloque;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_PromocionBloque_GrabarPlantillas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pPromocionBloques", JsonSerializer.Serialize(promocionBloques));
                var reader = await cmd.ExecuteReaderAsync();
                var Lista_PromocionBloque = new List<PromocionBloqueEnt>();
                while (await reader.ReadAsync())
                {
                    var obj = Mapear(reader);
                    Lista_PromocionBloque.Add(obj);
                }

                conn.Close();

                return Lista_PromocionBloque;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<Respuesta<PromocionBloqueEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PromocionBloqueEnt> obj = new Respuesta<PromocionBloqueEnt>
                {
                    Response = new PromocionBloqueEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response = Mapear(reader);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static PromocionBloqueEnt Mapear(DbDataReader reader)
        {
            try
            {
                var obj = new PromocionBloqueEnt
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
                    RangoIni = Convert.ToInt32(reader["RangoIni"].ToString()),
                    RangoFin = Convert.ToInt32(reader["RangoFin"].ToString()),
                    DescuentoPorcentaje = Convert.ToDecimal(reader["DescuentoPorcentaje"]),
                    DescuentoFijo = Convert.ToDecimal(reader["DescuentoFijo"]),
                    AumentFijo = Convert.ToDecimal(reader["AumentFijo"]),
                    Plantilla = reader["Plantilla"].ToString()
                };


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
