using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class DetalleCitaHorarioDat : IDetalleCitaHorarioDat
	{
        private readonly string _connectionString;

        public DetalleCitaHorarioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<DetalleCitaHorarioEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Notas_Obtener", conn)
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
                
        public async Task<DetalleCitaHorarioEnt> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
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

        public async Task<Respuesta<DetalleCitaHorarioEnt>> Insertar(DetalleCitaHorarioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Detalle_Cita_Horario_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("IdSeguimientoCita", model.IdSeguimientoCita);
                cmd.Parameters.AddWithValue("IdHorarioMinutos", model.IdHorarioMinutos);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
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
        public async Task<Respuesta<DetalleCitaHorarioEnt>> Modificar(DetalleCitaHorarioEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdDetalleCitaHorario", model.IdDetalleCitaHorario);
                cmd.Parameters.AddWithValue("IdHorarioMinutos", model.IdHorarioMinutos);
                cmd.Parameters.AddWithValue("IdCita", model.IdCita);
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
       
        public async Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina, int IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Detalle_Cita_Horario_Obtener_Por_Horario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("horainicio", horainicio);
                cmd.Parameters.AddWithValue("horafin", horafin);
                cmd.Parameters.AddWithValue("IdMaquina", IdMaquina);
                cmd.Parameters.AddWithValue("IdSede", IdSede);
                var reader = await cmd.ExecuteReaderAsync();
                RangoHorarioEnt obj = null;
                IList<RangoHorarioEnt> lista = new List<RangoHorarioEnt>();
                while (await reader.ReadAsync())
                {
                    obj = new RangoHorarioEnt
                    {
                        IdHorarioMinutos = Convert.ToInt32(reader["IdHorarioMinutos"]),
                        Hora = reader["Hora"].ToString(),
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


        // READERS

        static async Task<IEnumerable<DetalleCitaHorarioEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<DetalleCitaHorarioEnt> lista = new List<DetalleCitaHorarioEnt>();
                while (await reader.ReadAsync())
                {
                    DetalleCitaHorarioEnt obj = new DetalleCitaHorarioEnt
                    {
                        IdDetalleCitaHorario = reader.GetFieldValue<int>(0),
                        IdHorarioMinutos = Convert.ToInt32(reader["IdHorarioMinutos"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
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

        static async Task<DetalleCitaHorarioEnt> Read(DbDataReader reader)
        {
            try
            {
                DetalleCitaHorarioEnt obj = new DetalleCitaHorarioEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdDetalleCitaHorario = Convert.ToInt32(reader["IdDetalleCitaHorario"]);
                    obj.IdHorarioMinutos = Convert.ToInt32(reader["IdHorarioMinutos"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<DetalleCitaHorarioEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<DetalleCitaHorarioEnt> obj = new Respuesta<DetalleCitaHorarioEnt>
                {
                    Response = new DetalleCitaHorarioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdDetalleCitaHorario = Convert.ToInt32(reader["IdDetalleCitaHorario"]);
                        obj.Response.IdHorarioMinutos = Convert.ToInt32(reader["IdHorarioMinutos"]);
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                    }
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
