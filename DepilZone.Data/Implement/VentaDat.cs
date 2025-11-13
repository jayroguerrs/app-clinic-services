using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class VentaDat : IVentaDat
	{
        private readonly string _connectionString;
        public VentaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoComprobante, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_GetSerieNumero", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoComprobante", idTipoComprobante);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCalculoItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_ObtenerTipoPago", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadobtenertipopagoItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<VentaEnt>> Insertar(VentaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCaja", model.IdCaja);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdMoneda", model.IdMoneda);
                cmd.Parameters.AddWithValue("pIdTipoPago", model.IdTipoPago);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);

                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pNumero", model.Numero);

                cmd.Parameters.AddWithValue("pTotal", model.pTotal);
                cmd.Parameters.AddWithValue("pEfectivo", model.pEfectivo);
                cmd.Parameters.AddWithValue("pVuelto", model.pVuelto);

                cmd.Parameters.AddWithValue("pCodigoOperacion", model.CodigoOperacion);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistra", model.IdUsuarioRegistra);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);

                cmd.Parameters.AddWithValue("pIdEmpresa", model.IdEmpresa);
                cmd.Parameters.AddWithValue("Detalles", JsonSerializer.Serialize(model.Detalles));

                cmd.Parameters.AddWithValue("pIdUsuarioAtendidoPor", model.IdUsuarioAtendidoPor);
                cmd.Parameters.AddWithValue("pSiguienteCita", model.SiguienteCita);
                cmd.Parameters.AddWithValue("pNumeroDocumentoIdentidad", model.NumeroDocumentoIdentidad);

                cmd.Parameters.AddWithValue("pZonasEliminadas", JsonSerializer.Serialize(model.ZonasEliminadas));

                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);

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
        public async Task<Respuesta<CitaEnt>> ActualizarCitaPagada(VentaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_CitaPagada", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdTipoComprobante", model.IdTipoComprobante);
                cmd.Parameters.AddWithValue("pIdTipoPago", model.IdTipoPago);
                cmd.Parameters.AddWithValue("pSerie", model.Serie);
                cmd.Parameters.AddWithValue("pNumero", model.Numero);
                cmd.Parameters.AddWithValue("pIdUsuarioAtendidoPor", model.IdUsuarioAtendidoPor);
                cmd.Parameters.AddWithValue("pSiguienteCita", model.SiguienteCita);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistra", model.IdUsuarioRegistra);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pNumeroDocumentoIdentidad", model.NumeroDocumentoIdentidad);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pZonasEliminadas", JsonSerializer.Serialize(model.ZonasEliminadas));


                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemCitaPagada(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<VentaTicketDTO>> ObtenerTickets(int idsede, DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_ObtenerTickets", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdsede", idsede);
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadTickets(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public async Task<Respuesta<VentaEnt>> AnularVentaTicket(int idVenta, int idUsuarioModifica)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_AnularTicketByIdVenta", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdVenta", idVenta);
                cmd.Parameters.AddWithValue("pIdUsuarioModifica", idUsuarioModifica);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaderAnulacionItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ReenvioDTO>> reenvio(string Documento, int tipooper, string fecha)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("usp_FacturacionElectronica", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Documento", Documento);
                cmd.Parameters.AddWithValue("tipooper", tipooper);
                cmd.Parameters.AddWithValue("fecha", fecha);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadreenvioItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_Obtener_Id", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idventa", idventa);
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
        public async Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_Obtener_Id_NumeroDocumento", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("NumeroDocumento", NumeroDocumento);
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
        public async Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Validacion_Usuario_Factura_Cita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idusuario", idusuario);
                cmd.Parameters.AddWithValue("idcita", idcita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadvalidacionItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_Obtener_Id_Cita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idcita", idcita);
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

        public async Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int idcita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Facturacion_Detalle_Cita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idcita", idcita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaddetallecitaItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DETALLEVENTA_OBTENER", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaddetalleItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DETALLEVENTA_OBTENER_ID", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idventa", idventa);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReaddetalleidItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VentaDTO>> ObtenerVentasTotales(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_VentaObtenerTotal", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                cmd.Parameters.AddWithValue("pNumeroSesion", numeroSesion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadVentasTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VentaPotencialDTO>> ReportePotencialVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Venta_Reporte_Potencial", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaDesde", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaHasta", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReportePotencialVenta(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS


        static async Task<Respuesta<CitaEnt>> ReadItemCitaPagada(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaEnt> obj = new Respuesta<CitaEnt>
                {
                    Response = new CitaEnt()
                };

                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<UltimaSerieDTO> ReadCalculoItems(DbDataReader reader)
        {
            try
            {
                UltimaSerieDTO obj = new UltimaSerieDTO();
                while (await reader.ReadAsync())
                {
                    obj.Serie = Convert.ToString(reader["Serie"]);
                    obj.Numero = Convert.ToInt32(reader["Numero"]).ToString("00000000");
                    obj.IdCaja = Convert.ToInt32(reader["Idcaja"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        static async Task<IEnumerable<ReenvioDTO>> ReadreenvioItems(DbDataReader reader)
        {
            try
            {
                IList<ReenvioDTO> lista = new List<ReenvioDTO>();
                while (await reader.ReadAsync())
                {
                    ReenvioDTO obj = new ReenvioDTO
                    {

                        Documento = Convert.ToString(reader["Documento"]),

                        valor = Convert.ToString(reader["valor"]),

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
        static async Task<IEnumerable<AperturaEnd>> ReadvalidacionItems(DbDataReader reader)
        {
            try
            {
                IList<AperturaEnd> lista = new List<AperturaEnd>();
                while (await reader.ReadAsync())
                {
                    AperturaEnd obj = new AperturaEnd
                    {
                        Exito = Convert.ToString(reader["Exito"]),
                        Mensaje = Convert.ToString(reader["Mensaje"]),
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
        static async Task<Respuesta<VentaEnt>> ReaderAnulacionItems(DbDataReader reader)
        {
            try
            {
                Respuesta<VentaEnt> obj = new Respuesta<VentaEnt>
                {
                    Response = new VentaEnt()
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
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCaja = Convert.ToInt32(reader["IdCaja"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdMoneda = Convert.ToInt32(reader["IdMoneda"]);
                        obj.Response.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        obj.Response.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                        obj.Response.Serie = Convert.ToString(reader["Serie"]);
                        obj.Response.Numero = Convert.ToString(reader["Numero"]);
                        obj.Response.pSubTotal = Convert.ToDecimal(reader["pSubTotal"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<VentaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<VentaEnt> obj = new Respuesta<VentaEnt>
                {
                    Response = new VentaEnt()
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
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCaja = Convert.ToInt32(reader["IdCaja"]);
                        obj.Response.Serie = Convert.ToString(reader["Serie"]);
                        obj.Response.Numero = Convert.ToString(reader["Numero"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdMoneda = Convert.ToInt32(reader["IdMoneda"]);
                        obj.Response.pTotal = Convert.ToDecimal(reader["pTotal"]);
                        obj.Response.IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]);
                        obj.Response.CodigoOperacion = Convert.ToString(reader["CodigoOperacion"]);
                        obj.Response.FechaPago = Convert.ToDateTime(reader["FechaPago"]);
                        obj.Response.IdUsuarioRegistra = Convert.ToInt32(reader["IdUsuarioRegistra"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IEnumerable<TipoPagoEnt>> ReadobtenertipopagoItems(DbDataReader reader)
        {
            try
            {
                IList<TipoPagoEnt> lista = new List<TipoPagoEnt>();
                while (await reader.ReadAsync())
                {
                    TipoPagoEnt obj = new TipoPagoEnt
                    {
                        IdTipoPago = reader.GetFieldValue<int>(0),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Estado = Convert.ToInt32(reader["Estado"]),
                        Valor = Convert.ToString(reader["Valor"]),
                        Entidad = Convert.ToBoolean(reader["Entidad"]),
                        NumOperacion = Convert.ToBoolean(reader["NumOperacion"]),
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

        static async Task<IEnumerable<DetalleventaEnt>> ReaddetalleItems(DbDataReader reader)
        {
            try
            {
                IList<DetalleventaEnt> lista = new List<DetalleventaEnt>();
                while (await reader.ReadAsync())
                {
                    DetalleventaEnt obj = new DetalleventaEnt
                    {
                        DVenta = reader.GetFieldValue<int>(0),
                        NumeroDocumento = reader["NumeroDocumento"].ToString(),
                        Serie = Convert.ToString(reader["Serie"]),
                        Numero = Convert.ToString(reader["Numero"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        IdZona = Convert.ToInt32(reader["IdZona"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        pImporte = Convert.ToDecimal(reader["pImporte"]),
                        pTotal = Convert.ToDecimal(reader["pTotal"]),
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
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
        static async Task<IEnumerable<DetalleventaEnt>> ReaddetalleidItems(DbDataReader reader)
        {
            try
            {
                IList<DetalleventaEnt> lista = new List<DetalleventaEnt>();
                while (await reader.ReadAsync())
                {
                    DetalleventaEnt obj = new DetalleventaEnt
                    {
                        DVenta = reader.GetFieldValue<int>(0),
                        NumeroDocumento = reader["NumeroDocumento"].ToString(),
                        Serie = Convert.ToString(reader["Serie"]),
                        Numero = Convert.ToString(reader["Numero"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        IdZona = Convert.ToInt32(reader["IdZona"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        pImporte = Convert.ToDecimal(reader["pImporte"]),
                        pTotal = Convert.ToDecimal(reader["pTotal"]),
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        consolidado = Convert.ToString(reader["consolidado"]),
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

        static async Task<IEnumerable<DetalleCitaFacturacionEnt>> ReaddetallecitaItems(DbDataReader reader)
        {
            try
            {
                IList<DetalleCitaFacturacionEnt> lista = new List<DetalleCitaFacturacionEnt>();
                while (await reader.ReadAsync())
                {
                    DetalleCitaFacturacionEnt obj = new DetalleCitaFacturacionEnt
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        Documento = Convert.ToString(reader["Documento"]),
                        Total = Convert.ToDecimal(reader["total"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        Caja = Convert.ToString(reader["Caja"]),
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
        static async Task<IEnumerable<VentaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<VentaEnt> lista = new List<VentaEnt>();
                while (await reader.ReadAsync())
                {
                    VentaEnt obj = new VentaEnt
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        Serie = Convert.ToString(reader["Serie"]),
                        Numero = Convert.ToString(reader["Numero"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdMoneda = Convert.ToInt32(reader["IdMoneda"]),
                        pDescuento = Convert.ToDecimal(reader["pDescuento"]),
                        pRecargo = Convert.ToDecimal(reader["pRecargo"]),
                        pVuelto = Convert.ToDecimal(reader["pVuelto"]),
                        pTotal = Convert.ToDecimal(reader["pTotal"]),
                        pIgv = Convert.ToDecimal(reader["pIgv"]),
                        IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]),
                        CodigoOperacion = Convert.ToString(reader["CodigoOperacion"]),
                        FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                        IdUsuarioRegistra = Convert.ToInt32(reader["IdUsuarioRegistra"]),
                        FechaEmision = Convert.ToDateTime(reader["FechaEmision"]),
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

        static async Task<IEnumerable<VentaTicketDTO>> ReadTickets(DbDataReader reader)
        {
            try
            {
                IList<VentaTicketDTO> lista = new List<VentaTicketDTO>();
                while (await reader.ReadAsync())
                {
                    VentaTicketDTO obj = new VentaTicketDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Ticket = Convert.ToString(reader["Ticket"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        PTotal = Convert.ToDecimal(reader["PTotal"]),
                        Concepto = Convert.ToString(reader["Concepto"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        FechaModifica = reader["FechaModifica"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifica"].ToString()),
                        UsuarioModifica = reader["UsuarioModifica"] == DBNull.Value ? null : reader["UsuarioModifica"].ToString(),
                        Zonas = Convert.ToString(reader["Zonas"]),
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

        static async Task<List<VentaDTO>> ReadVentasTotales(DbDataReader reader)
        {
            try
            {
                List<VentaDTO> lista = new List<VentaDTO>();
                while (await reader.ReadAsync())
                {
                    VentaDTO obj = new VentaDTO
                    {
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        TotalVenta = Convert.ToDecimal(reader["TotalVenta"]),
                        Fecha = Convert.ToDateTime( reader["Fecha"] )
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


        static async Task<List<VentaPotencialDTO>> ReadReportePotencialVenta(DbDataReader reader)
        {
            string dd = "";
            try
            {
                List<VentaPotencialDTO> lista = new List<VentaPotencialDTO>();
                while (await reader.ReadAsync())
                {
                    dd = Convert.ToString(reader["Citas"]);
                    var aa = dd;
                    VentaPotencialDTO obj = new VentaPotencialDTO
                    {
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        MedioContacto = Convert.ToString(reader["MedioContacto"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        ClienteActivo = Convert.ToString(reader["ClienteActivo"]),
                        Servicio = Convert.ToString(reader["Servicio"]),
                        Citas = new List<VentaPotencial_CitasDTO>(JsonSerializer.Deserialize<List<VentaPotencial_CitasDTO>>(Convert.ToString(reader["Citas"])))
                    };
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                dd = dd;
                throw ex;
            }
        }


    }
}
