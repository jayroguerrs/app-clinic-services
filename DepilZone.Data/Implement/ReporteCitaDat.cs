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
    public class ReporteCitaDat : IReporteCitaDat
    {
        private readonly string _connectionString;
        public ReporteCitaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<EspecialistaDTO>> ObtenerEspecialistasCitas(int idSede, DateTime fechaInicio, DateTime fechaTermino, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ReporteEspecialistaAtendidos", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaTermino);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdUsuarioAtendio", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerEspecialistasCitas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EspecialistaCitaDTO>> ObtenerEspecialistasCitasDetalle(int idUsuario, DateTime fecha, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ReporteEspecialistaCitas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuarioAtendio", idUsuario);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerEspecialistasCitasDetalle(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CronogramaCitasAtendidasDTO>> ObtenerCronogramaCitasAtendidas(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ReporteCitas_CronogramaAtendidas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaHasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerCronogramaCitasAtendidas(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReporteAtendidosDiariosDTO>> ReporteAtendidosDiarios(DateTime fecha, int idSede, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Reporte_Atendidos", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReporteAtendidosDiarios(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<List<EspecialistaDTO>> ReadObtenerEspecialistasCitas(DbDataReader reader)
        {
            try
            {
                List<EspecialistaDTO> lista = new List<EspecialistaDTO>();
                while (await reader.ReadAsync())
                {
                    EspecialistaDTO obj = new EspecialistaDTO
                    {

                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        CitasAtendidas = new List<ReporteCitaDTO>()
                    };
                    lista.Add(obj);
                }


                List<ReporteCitaDTO> reportes = new List<ReporteCitaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        reportes.Add(new ReporteCitaDTO()
                        {
                            fechacita = Convert.ToString(reader["Fecha"]),
                            cantidad = Convert.ToInt32(reader["Citas"]),
                            idUsuarioAtendio = Convert.ToInt32(reader["idUsuarioAtendio"])
                        });
                    }
                }

                foreach (EspecialistaDTO especialista in lista)
                {
                    especialista.CitasAtendidas = reportes.FindAll(x => x.idUsuarioAtendio == especialista.Id);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<EspecialistaCitaDTO>> ReadObtenerEspecialistasCitasDetalle(DbDataReader reader)
        {
            try
            {
                List<EspecialistaCitaDTO> lista = new List<EspecialistaCitaDTO>();
                while (await reader.ReadAsync())
                {
                    EspecialistaCitaDTO obj = new EspecialistaCitaDTO
                    {

                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Hora = Convert.ToString(reader["Hora"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        ProximaCitaAtendida = DBNull.Value == reader["ProximaCitaAtendida"] ? (DateTime?)null : Convert.ToDateTime(reader["ProximaCitaAtendida"]),
                        IdProximaCitaAtendida = DBNull.Value == reader["IdProximaCitaAtendida"] ? (int?)null : Convert.ToInt32(reader["IdProximaCitaAtendida"]),

                        FechaProximaCita = DBNull.Value == reader["FechaProximaCita"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaProximaCita"]),
                        IdProximaCita = DBNull.Value == reader["IdProximaCita"] ? (int?)null : Convert.ToInt32(reader["IdProximaCita"]),
                        ColorProximaCita = DBNull.Value == reader["ColorProximaCita"] ? null : Convert.ToString(reader["ColorProximaCita"]),
                        EstadoProximaCita = DBNull.Value == reader["EstadoProximaCita"] ? null : Convert.ToString(reader["EstadoProximaCita"]),
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

        static async Task<List<CronogramaCitasAtendidasDTO>> ReadObtenerCronogramaCitasAtendidas(DbDataReader reader)
        {
            try
            {
                List<CronogramaCitasAtendidasDTO> lista = new List<CronogramaCitasAtendidasDTO>();
                while (await reader.ReadAsync())
                {
                    CronogramaCitasAtendidasDTO obj = new CronogramaCitasAtendidasDTO
                    {

                        Sede = Convert.ToString(reader["Sede"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        H8 = Convert.ToInt32(reader["H8"]),
                        H9 = Convert.ToInt32(reader["H9"]),
                        H10 = Convert.ToInt32(reader["H10"]),
                        H11 = Convert.ToInt32(reader["H11"]),
                        H12 = Convert.ToInt32(reader["H12"]),
                        H13 = Convert.ToInt32(reader["H13"]),
                        H14 = Convert.ToInt32(reader["H14"]),
                        H15 = Convert.ToInt32(reader["H15"]),
                        H16 = Convert.ToInt32(reader["H16"]),
                        H17 = Convert.ToInt32(reader["H17"]),
                        H18 = Convert.ToInt32(reader["H18"]),
                        H19 = Convert.ToInt32(reader["H19"]),
                        H20 = Convert.ToInt32(reader["H20"]),
                        H21 = Convert.ToInt32(reader["H21"])
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


        static async Task<List<ReporteAtendidosDiariosDTO>> ReadReporteAtendidosDiarios(DbDataReader reader)
        {
            try
            {
                List<ReporteAtendidosDiariosDTO> lista = new List<ReporteAtendidosDiariosDTO>();
                while (await reader.ReadAsync())
                {
                    ReporteAtendidosDiariosDTO obj = new ReporteAtendidosDiariosDTO
                    {

                        IdCronograma = Convert.ToInt32(reader["IdCronograma"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        TipoCita = Convert.ToString(reader["TipoCita"]),
                        Fecha = Convert.ToString(reader["Fecha"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Servicio = Convert.ToString(reader["Servicio"]),
                        NumeroBox = Convert.ToInt32(reader["NumeroBox"]),
                        IdMaquinaMarca = reader["IdMaquinaMarca"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMaquinaMarca"]),
                        MaquinaMarca = reader["MaquinaMarca"] == DBNull.Value ? null : Convert.ToString(reader["MaquinaMarca"]),
                        Sesion = Convert.ToInt32(reader["Sesion"]),
                        ZonaClienteAntiguo = Convert.ToString(reader["ZonaClienteAntiguo"]),
                        ZonaNuevaCliente = Convert.ToString(reader["ZonaNuevaCliente"]),
                        ZonaClienteNuevo = Convert.ToString(reader["ZonaClienteNuevo"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Promocion = Convert.ToString(reader["Promocion"]),
                        MedioContactoOrigen = reader["MedioContactoOrigen"] == DBNull.Value ? null : Convert.ToString(reader["MedioContactoOrigen"]),
                        UsuarioAgendo = reader["UsuarioAgendo"] == DBNull.Value ? null : Convert.ToString(reader["UsuarioAgendo"]),
                        AtendidoPor = reader["AtendidoPor"] == DBNull.Value ? null : Convert.ToString(reader["AtendidoPor"]),
                        Sede = reader["Sede"] == DBNull.Value ? null : Convert.ToString(reader["Sede"]),
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
