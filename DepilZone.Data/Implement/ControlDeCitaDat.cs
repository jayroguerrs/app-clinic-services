using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ControlDeCitaDat : IControlDeCitaDat
    {
        private readonly string _connectionString;

        public ControlDeCitaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<ControlDeCitaDTO>> ObtenerDiezCitas()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("GetTop10CitaDetalle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ControlDeCitasByUserResponseDTO> ObtenerCitas(int IdUsuarioOperador, int Pagina, int RowsPerPage, DateTime? FechaInicio, DateTime? FechaFin, string? Busqueda, string? Pagado, string? Estado, int? MostrarPagadosMensual, int? MostrarAbonado, int? OcultarAnulados)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerCitasRegistradasPaginacion2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdUsuarioOperador", IdUsuarioOperador);
                cmd.Parameters.AddWithValue("PageNumber", Pagina);
                cmd.Parameters.AddWithValue("RowsPerPage", RowsPerPage);
                cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("NombrePaciente", Busqueda);
                cmd.Parameters.AddWithValue("Pagados", Pagado);
                cmd.Parameters.AddWithValue("Estado", Estado);
                cmd.Parameters.AddWithValue("MostrarPagadosMensual", MostrarPagadosMensual);
                cmd.Parameters.AddWithValue("MostrarAbonado", MostrarAbonado);
                cmd.Parameters.AddWithValue("OcultarAnulados", OcultarAnulados);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCitasByUser(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ObtenerCitasExcel(int IdUsuarioOperador, DateTime? FechaInicio, DateTime? FechaFin, int? OcultarAnulados, string? Estado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerCitasRegistradasPaginacion2Excel", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdUsuarioOperador", IdUsuarioOperador);
                cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("OcultarAnulados", OcultarAnulados);
                cmd.Parameters.AddWithValue("Estado", Estado);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCitasByUserExcel(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateFinalPayment(int IdCita, decimal PrecioDePagoFinal, int idUsuario, int? TipoPago)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ActualizarPrecioDePago", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCita", IdCita);
                cmd.Parameters.AddWithValue("PrecioDePagoFinal", PrecioDePagoFinal);
                cmd.Parameters.AddWithValue("IdUsuarioPago", idUsuario);
                cmd.Parameters.AddWithValue("TipoPago", TipoPago);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await XFinalPayment(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<IEnumerable<Notificacion>> ListadoDeNotificaciones(int IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerNotificaciones", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdSede", IdSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadNotificacionesPorSede(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GeneralResponse<bool>> CompletarNotificacion(int IdNotificacion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_NotificacionCompleta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdNotificacion", IdNotificacion);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await XCompletarNotificacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> ObtenerTotalDeNotificaciones(int IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ObtenerTotalDeNotificaciones", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdSede", IdSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadTotalNotificacionesPorSede(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<totalNotificaionPorSede> EnviarNotificaionDePago(int IdOperador, int IdTipoSede, string NombreOperador, int IdCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Notificacion_Pagar_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUserSend", IdOperador);
                //Se pone el id de jdiaz por ahora
                cmd.Parameters.AddWithValue("pIdUserRecive", 1117);
                cmd.Parameters.AddWithValue("pIdTipoSede", IdTipoSede);
                cmd.Parameters.AddWithValue("pNombreUsuario", NombreOperador);
                cmd.Parameters.AddWithValue("pIdCita", IdCita);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAsignarNotificacionDePago(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateZonaFinalPayment(int IdDetalle, decimal PrecioNuevoDePagoFinal, int IdCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ActualizarZonaPrecioDePago", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdDetalle", IdDetalle);
                cmd.Parameters.AddWithValue("NuevoPagoFinal", PrecioNuevoDePagoFinal);
                cmd.Parameters.AddWithValue("pIdCita", IdCita);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await XFinalZonaPayment(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        static async Task<IEnumerable<ControlDeCitaDTO>> ReadItemsObtener(DbDataReader reader)
        {
            try
            {
                IList<ControlDeCitaDTO> lista = new List<ControlDeCitaDTO>();
                while (await reader.ReadAsync())
                {
                    ControlDeCitaDTO obj = new ControlDeCitaDTO
                    {
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy")
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

        static async Task<GeneralResponse<UpdateFinalPaymentDTO>> XFinalPayment(DbDataReader reader)
        {
            try
            {
                GeneralResponse<UpdateFinalPaymentDTO> generalRes = new GeneralResponse<UpdateFinalPaymentDTO>
                {
                    Data = new UpdateFinalPaymentDTO()
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Pago actualizado exitosamente.";
                    generalRes.Status = 200;
                    Console.WriteLine(reader);

                    generalRes.Data.IdCita = Convert.ToInt32(reader["IdCita"]);
                    generalRes.Data.PrecioDePagoFinal = Convert.ToDecimal(reader["PrecioDePagoFinal"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<GeneralResponse<bool>> XCompletarNotificacion(DbDataReader reader)
        {
            try
            {
                GeneralResponse<bool> generalRes = new GeneralResponse<bool>
                {
                    Data = false
                };


                if (await reader.ReadAsync()) 
                {
                    generalRes.Message = "Notificacion actualizado exitosamente.";
                    generalRes.Status = 200;

                    generalRes.Data = true;
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<GeneralResponse<UpdateFinalPaymentDTO>> XFinalZonaPayment(DbDataReader reader)
        {
            try
            {
                GeneralResponse<UpdateFinalPaymentDTO> generalRes = new GeneralResponse<UpdateFinalPaymentDTO>
                {
                    Data = new UpdateFinalPaymentDTO()
                };


                if (await reader.ReadAsync())
                {
                    generalRes.Message = "Pago actualizado exitosamente.";
                    generalRes.Status = 200;
                    Console.WriteLine(reader);

                    generalRes.Data.IdCita = Convert.ToInt32(reader["Id"]);
                    generalRes.Data.PrecioDePagoFinal = Convert.ToDecimal(reader["Precio"]);
                }

                return generalRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<ControlDeCitasByUserResponseDTO> ReadCitasByUser(DbDataReader reader)
        {
            try
            {
                ControlDeCitasByUserResponseDTO result = new ControlDeCitasByUserResponseDTO();

                IList<ControlDeCitasByUserDTO> lista = new List<ControlDeCitasByUserDTO>();
                while (await reader.ReadAsync())
                {
                    ControlDeCitasByUserDTO obj = new ControlDeCitasByUserDTO
                    {
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        FechaPagado = reader["FechaPagado"] != DBNull.Value ? Convert.ToDateTime(reader["FechaPagado"]).ToString("dd-MM-yyyy") : null,
                        IdCita = Convert.ToInt32(reader["ID Cita"]),
                        Paciente = Convert.ToString(reader["Paciente"]),
                        ClienteNuevo = Convert.ToString(reader["Cliente Nuevo"]),
                        Celular = Convert.ToString(reader["Celular"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        NombreSede = Convert.ToString(reader["NombreSede"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        MedioDeContacto = Convert.ToString(reader["Medio de Contacto"]),
                        PagoFinal = reader["Pago Final"] != DBNull.Value ?  Convert.ToDecimal(reader["Pago Final"]) : 0,
                        PrecioDePagoFinal = reader["Precio de Pago Final"] != DBNull.Value ? Convert.ToDecimal(reader["Precio de Pago Final"]) : 0,

                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Abonado = reader["Abonado"] != DBNull.Value ? Convert.ToBoolean(reader["Abonado"]) : Convert.ToBoolean(0),
                        Id = Convert.ToInt32(reader["Id"]),

                        Habilitado = Convert.ToBoolean(reader["Habilitado"]),
                        IdTipoComision = Convert.ToInt32(reader["Tipo de Comision"]),

                        SesionInicial = Convert.ToInt32(reader["SesionInicio"]),
                        SesionFinal = Convert.ToInt32(reader["SesionFinal"]),
                        Notificado = Convert.ToBoolean(reader["NotificacionEstado"]),

                        TipoCita = reader["TipoDeCita"] != DBNull.Value ? Convert.ToString(reader["TipoDeCita"]) : "",
                        IdTipoCita = reader["IdTipoCita"] != DBNull.Value ? Convert.ToInt32(reader["IdTipoCita"]) : 0,
                        EstadoCliente = reader["EstadoCliente"] != DBNull.Value ? Convert.ToString(reader["EstadoCliente"]) : "",

                        UsuarioRegistra = reader["UsuarioRegistra"] != DBNull.Value ? Convert.ToString(reader["UsuarioRegistra"]) : "",
                    };
                    // Verifica si ya existe un objeto con el mismo IdCita
                    var existing = lista.FirstOrDefault(x => x.IdCita == obj.IdCita);
                    if (existing != null)
                    {
                        // Si existe, inicializa la propiedad Children si no está creada
                        if (existing.Children == null)
                        {
                            existing.Children = new List<ControlDeCitasByUserDTO>();
                        }

                        // Agrega el objeto actual como un hijo, pero conserva el PagoFinal
                        obj.Estado = null;
                        obj.PrecioDePagoFinal = null;
                        existing.Children.Add(obj);
                    }
                    else
                    {
                        // Si no existe, crea un nuevo objeto pero sin PagoFinal
                        obj.PagoFinal = 0; // Aseguramos que el objeto principal tenga PagoFinal = 0
                        obj.Total = 0;
                        obj.Id = 0;
                        lista.Add(obj);

                        // Luego, crea el hijo con el PagoFinal real
                        ControlDeCitasByUserDTO childObj = new ControlDeCitasByUserDTO
                        {
                            FechaCita = obj.FechaCita,
                            FechaPagado = obj.FechaPagado,
                            IdCita = obj.IdCita,
                            Paciente = obj.Paciente,
                            ClienteNuevo = obj.ClienteNuevo,
                            Celular = obj.Celular,
                            Total = Convert.ToDecimal(reader["Total"]),
                            NombreSede = obj.NombreSede,
                            IdSede = obj.IdSede,
                            Estado = null,
                            //Estado = obj.Estado,
                            MedioDeContacto = obj.MedioDeContacto,
                            PagoFinal = reader["Pago Final"] != DBNull.Value ? Convert.ToDecimal(reader["Pago Final"]) : 0, // Aquí le asignamos el PagoFinal real
                            PrecioDePagoFinal = null,
                            IdCliente = obj.IdCliente,
                            IdPreferente = obj.IdPreferente,
                            IdServicio = obj.IdServicio,
                            Abonado = obj.Abonado,
                            Id = Convert.ToInt32(reader["Id"]),
                            Habilitado = obj.Habilitado,
                            IdTipoComision = obj.IdTipoComision,
                            SesionInicial = obj.SesionInicial,
                            SesionFinal = obj.SesionFinal,
                            Notificado = obj.Notificado
                        };

                        // Agregar el hijo a la propiedad Children
                        obj.Children = new List<ControlDeCitasByUserDTO> { childObj };
                    
                    }

                }

                foreach (var parent in lista)
                {
                    if (parent.Children != null && parent.Children.Any())
                    {
                        if (parent.Children.Count == 1)
                        {
                            var unicoChild = parent.Children.First();
                            parent.PagoFinal = unicoChild.PagoFinal;
                            parent.Total = unicoChild.Total;
                            parent.Children = null; // Establecer Children en null
                            parent.Id = unicoChild.Id;
                        }
                        else
                        {
                            // Sumar valores de todos los hijos
                            parent.PagoFinal = parent.Children
                                                           .Where(child => child.Habilitado)
                                                           .Sum(child => child.PagoFinal);


                            parent.Total = parent.Children
                                            .Where(child => child.Habilitado)
                                            .Sum(child => child.Total);
                        }

                    }
                }

                if (await reader.NextResultAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.Total = Convert.ToInt32(reader["TotalRecords"]);
                        result.Citas = lista;
                    }
                }

                //Comision total

                if (await reader.NextResultAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MontoTotal = reader["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotal"]) : 0;
                        result.PorcentajeSobreMontoTotal = reader["PorcentajeSobreMontoTotal"] != DBNull.Value ? Math.Round(Convert.ToDecimal(reader["PorcentajeSobreMontoTotal"]), 1) : 0;
                    }
                }

                //Primera Comision

                if (await reader.NextResultAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MontoPrimeraComisionTotal = reader["MontoTotalUno"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotalUno"]) : 0;
                        result.PorcentajeSobreMontoPrimeraComisionTotal = reader["PorcentajeSobreMontoTotalUno"] != DBNull.Value ? Math.Round(Convert.ToDecimal(reader["PorcentajeSobreMontoTotalUno"]), 1) : 0;
                    }
                }


                //Segunda Comision 

                if (await reader.NextResultAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MontoSegundaComisionTotal = reader["MontoTotalDos"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotalDos"]) : 0;
                        result.PorcentajeSobreMontoSegundaComisionTotal = reader["PorcentajeSobreMontoTotalDos"] != DBNull.Value ? Math.Round(Convert.ToDecimal(reader["PorcentajeSobreMontoTotalDos"]), 1) : 0;
                    }
                }

                //Tercera Comision 

                if (await reader.NextResultAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MontoTercerComisionTotal = reader["MontoTotalTres"] != DBNull.Value ? Convert.ToDecimal(reader["MontoTotalTres"]) : 0;
                        result.PorcentajeSobreMontoTercerComisionTotal = reader["PorcentajeSobreMontoTotalTres"] != DBNull.Value ? Math.Round(Convert.ToDecimal(reader["PorcentajeSobreMontoTotalTres"]), 1) : 0;
                    }
                }


                return result;
                //return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ReadCitasByUserExcel(DbDataReader reader)
        {
            try
            {
                IList<ControlDeCitasByUserExcelDTO> lista = new List<ControlDeCitasByUserExcelDTO>();
                while (await reader.ReadAsync())
                {
                    ControlDeCitasByUserExcelDTO obj = new ControlDeCitasByUserExcelDTO
                    {
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        IdCita = Convert.ToInt32(reader["ID Cita"]),
                        Paciente = Convert.ToString(reader["Paciente"]),
                        ClienteNuevo = Convert.ToString(reader["Cliente Nuevo"]),
                        Celular = Convert.ToString(reader["Celular"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        NombreSede = Convert.ToString(reader["NombreSede"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        MedioDeContacto = Convert.ToString(reader["Medio de Contacto"]),
                        PrecioDePagoFinal = reader["Precio de Pago Final"] != DBNull.Value ? Convert.ToDecimal(reader["Precio de Pago Final"]) : 0,
                        TipoCita = reader["TipoDeCita"] != DBNull.Value ? Convert.ToString(reader["TipoDeCita"]) : "",
                        EstadoCliente = reader["EstadoCliente"] != DBNull.Value ? Convert.ToString(reader["EstadoCliente"]) : "",
                        UsuarioRegistra = reader["UsuarioRegistra"] != DBNull.Value ? Convert.ToString(reader["UsuarioRegistra"]) : ""
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

        static async Task<totalNotificaionPorSede> ReadAsignarNotificacionDePago(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                totalNotificaionPorSede totalNotificaciones = null;
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                    if (!success)
                    {
                        throw new SystemException(mensaje);
                    }

                    totalNotificaciones = new totalNotificaionPorSede()
                    {
                        CantidadSurco = Convert.ToInt32(reader["CantidadSurco"]),
                        CantidadMegaplaza = Convert.ToInt32(reader["CantidadMegaplaza"]),
                        CantidadPueblolibre = Convert.ToInt32(reader["CantidadPuebloLibre"]),
                        IdSedeNotifiacion = Convert.ToInt32(reader["IdSedeNotificacion"]),
                    };

                    //totalNotificaionPorSede = Convert.ToInt32(reader["CantidadTotalNotificaciones"]);
                }

                if (totalNotificaciones == null)
                {
                    throw new SystemException("No se encontraron notificaciones.");
                }

                return totalNotificaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<Notificacion>> ReadNotificacionesPorSede(DbDataReader reader)
        {
            try
            {
                IList<Notificacion> lista = new List<Notificacion>();
                while (await reader.ReadAsync())
                {
                    Notificacion obj = new Notificacion
                    {
                        NombreOperador = Convert.ToString(reader["Nombre"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        CelularCliente = Convert.ToString(reader["Celular"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]).ToString("yyyy-MM-dd"),
                        IdNotificacion = Convert.ToInt32(reader["Id"])
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


        static async Task<int> ReadTotalNotificacionesPorSede(DbDataReader reader)
        {
            try
            {
                int totalDeNotificaciones = 0;
                while (await reader.ReadAsync())
                {
                    totalDeNotificaciones = Convert.ToInt32(reader["TotalNotificaciones"]);
                }

                return totalDeNotificaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
