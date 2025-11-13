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
	public class CitaDetalleDat : ICitaDetalleDat
	{
        //public async Task<IEnumerable<CitaDetalleEnt>> Obtener()
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_Notas_Obtener", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await ReadItems(reader);
        //}
        //public async Task<CitaDetalleEnt> ObtenerById(int Id)
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdUsuario", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    cmd.Parameters.AddWithValue("Id", Id);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await Read(reader);
        //}
        //public async Task<Respuesta<CitaDetalleEnt>> Insertar(CitaDetalleEnt model)
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_Notas_Insertar", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    //cmd.Parameters.AddWithValue("IdSeguimientoCita", model.IdSeguimientoCita);
        //    cmd.Parameters.AddWithValue("IdCita", model.IdCita);
        //    cmd.Parameters.AddWithValue("IdZona", model.IdZona);
        //    cmd.Parameters.AddWithValue("sesion", model.Sesion);
        //    cmd.Parameters.AddWithValue("IdPromocionPrecio", model.IdPromocionPrecio);
        //    cmd.Parameters.AddWithValue("Precio", model.Precio);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await ReadItem(reader);
        //}
        //public async Task<Respuesta<CitaDetalleEnt>> Modificar(CitaDetalleEnt model)
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    cmd.Parameters.AddWithValue("IdCita", model.IdCita);
        //    cmd.Parameters.AddWithValue("IdZona", model.IdZona);
        //    cmd.Parameters.AddWithValue("sesion", model.Sesion);
        //    cmd.Parameters.AddWithValue("IdPromocion", model.IdPromocion);
        //    cmd.Parameters.AddWithValue("Precio", model.Precio);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await ReadItem(reader);
        //}

        private readonly string _connectionString;

        public CitaDetalleDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario, int idAccion, int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaDetalle_ObtenerHorarioNoDisponible", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdMaquina", idMaquina);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("pIdAccion", idAccion);
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();

                IList<CitaNoDisponibleDTO> lista = new List<CitaNoDisponibleDTO>();
                while (await reader.ReadAsync())
                {
                    CitaNoDisponibleDTO obj = new CitaNoDisponibleDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino = reader["HoraTermino"].ToString(),
                        MinutoInicio = (int)(TimeSpan.Parse(reader["HoraInicio"].ToString()).TotalMinutes),
                        MinutoTermino = (int)(TimeSpan.Parse(reader["HoraTermino"].ToString()).TotalMinutes),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        TipoNoDisponible = Convert.ToInt32(reader["TipoNoDisponible"]),
                        ColorFondo = reader["ColorFondo"].ToString(),
                        ColorTexto = reader["ColorTexto"].ToString(),
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetallesCitaByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaDetalle_ObtenerByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCollection(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // Readers
        static async Task<IEnumerable<CitaDetalleZonaDTO>> ReadCollection( DbDataReader reader )
        {
            try
            {
                IList<CitaDetalleZonaDTO> lista = new List<CitaDetalleZonaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDetalleZonaDTO obj = new CitaDetalleZonaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        IdCita = Convert.ToInt32(reader["IdCita"].ToString()),
                        Zona = new CD_Zona()
                        {
                            Id = Convert.ToInt32(reader["IdZona"].ToString()),
                            Nombre = reader["Zona"].ToString()
                        },
                        Sesion = Convert.ToInt32(reader["Sesion"].ToString()),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        PagoWeb = Convert.ToBoolean(reader["PagoWeb"])
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



        //static async Task<IEnumerable<CitaDetalleEnt>> ReadItems(DbDataReader reader)
        //{
        //    IList<CitaDetalleEnt> lista = new List<CitaDetalleEnt>();
        //    while (await reader.ReadAsync())
        //    {
        //        CitaDetalleEnt obj = new CitaDetalleEnt
        //        {
        //            Id = reader.GetFieldValue<int>(0),
        //            IdCita = Convert.ToInt32(reader["IdCita"]),
        //            IdZona = Convert.ToInt32(reader["IdZona"]),
        //            Sesion = Convert.ToInt32(reader["Sesion"]),
        //            IdPromocion = Convert.ToInt32(reader["IdPromocion"]),
        //            Precio = Convert.ToDecimal(reader["Precio"]),
        //        };
        //        lista.Add(obj);
        //    }
        //    return lista;
        //}
        //static async Task<CitaDetalleEnt> Read(DbDataReader reader)
        //{
        //    CitaDetalleEnt obj = new CitaDetalleEnt();
        //    while (await reader.ReadAsync())
        //    {
        //        obj.Id = Convert.ToInt32(reader["IdDetalleCita"]);
        //        obj.IdCita = Convert.ToInt32(reader["IdCita"]);
        //        obj.IdZona = Convert.ToInt32(reader["IdZona"]);
        //        obj.Sesion = Convert.ToInt32(reader["Sesion"]);
        //        obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
        //        obj.Precio = Convert.ToDecimal(reader["Precio"]);
        //    }
        //    return obj;
        //}
        //static async Task<Respuesta<CitaDetalleEnt>> ReadItem(DbDataReader reader)
        //{
        //    Respuesta<CitaDetalleEnt> obj = new Respuesta<CitaDetalleEnt>
        //    {
        //        Response = new CitaDetalleEnt()
        //    };
        //    while (await reader.ReadAsync())
        //    {
        //        obj.Exito = Convert.ToBoolean(reader["Exito"]);
        //        obj.Mensaje = Convert.ToString(reader["Mensaje"]);
        //        if (obj.Exito)
        //        {
        //            obj.Response.Id = Convert.ToInt32(reader["IdDetalleCita"]);
        //            obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
        //            obj.Response.IdZona = Convert.ToInt32(reader["IdZona"]);
        //            obj.Response.Sesion = Convert.ToInt32(reader["Sesion"]);
        //            obj.Response.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
        //            obj.Response.Precio = Convert.ToDecimal(reader["Precio"]);
        //        }
        //    }
        //    return obj;
        //}
    }
}
