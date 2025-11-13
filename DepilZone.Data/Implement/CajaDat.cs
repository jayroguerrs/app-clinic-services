using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class CajaDat : ICajaDat
	{
        private readonly string _connectionString;

        public CajaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CajaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Caja__ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CajaEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_ConsultarApertura", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();

                CajaValidacionDTO obj = new CajaValidacionDTO();
                while (await reader.ReadAsync())
                {
                    obj.CajaPermitida = Convert.ToBoolean(reader["CajaPermitida"]);
                    obj.Mensaje = reader["Mensaje"].ToString();
                    obj.Turno = Convert.ToInt32(reader["Turno"]);
                }
                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CajaEnt>> Insertar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CajaEnt>> Modificar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_AbrirCerrar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", model.Id);
                cmd.Parameters.AddWithValue("pAbrirCaja", model.AbrirCaja);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                cmd.Parameters.AddWithValue("pFechaApertura", model.FechaHoraAperturaStr);
                cmd.Parameters.AddWithValue("pSaldoInicial", model.SaldoInicial);
                cmd.Parameters.AddWithValue("pTurno", model.Turno);

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
        public async Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_CuadreTicket", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", idCaja);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemCuadre(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }
        public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_VerificaEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", idCaja);
                cmd.Parameters.AddWithValue("pFechaCaja", fecha);
                var reader = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CajaSeguimientoDiarioDTO> SeguimientoDiario(DateTime fecha, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_SeguimientoDiario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadSeguimientoDiario(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS

        static async Task<CajaEnt> Read(DbDataReader reader)
        {
            try
            {
                CajaEnt obj = new CajaEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.UsuarioResponsable = Convert.ToString(reader["UsuarioResponsable"]);
                    obj.IdUsuarioResponsable = Convert.ToInt32(reader["IdUsuarioResponsable"]);
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<Respuesta<CajaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CajaEnt> obj = new Respuesta<CajaEnt>
                {
                    Response = new CajaEnt()
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
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<CajaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CajaEnt> lista = new List<CajaEnt>();
                while (await reader.ReadAsync())
                {
                    CajaEnt obj = new CajaEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Apertura = reader["Apertura"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaHoraApertura = reader["FechaHoraApertura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaHoraApertura"]),
                        UsuarioResponsable = reader["UsuarioResponsable"].ToString(),
                        IdUsuarioResponsable = Convert.ToInt32(reader["IdUsuarioResponsable"])
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<IEnumerable<CajaEnt>> ReadObtener(DbDataReader reader)
        {
            try
            {
                IList<CajaEnt> lista = new List<CajaEnt>();
                while (await reader.ReadAsync())
                {
                    CajaEnt obj = new CajaEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Apertura = reader["Apertura"].ToString(),
                        Turno = Convert.ToInt32(reader["Turno"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaHoraApertura = reader["FechaHoraApertura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaHoraApertura"]),
                        FechaHoraCierre = reader["FechaHoraCierre"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaHoraCierre"]),
                        UsuarioResponsable = reader["UsuarioResponsable"].ToString(),
                        UsuarioResponsableCierre = reader["UsuarioResponsableCierre"].ToString(),
                        IdUsuarioResponsableCierre = Convert.ToInt32(reader["IdUsuarioResponsableCierre"]),
                        IdUsuarioResponsable = Convert.ToInt32(reader["IdUsuarioResponsable"])
                    };
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<CajaCuadreDTO> ReadItemCuadre(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";

                List<CajaDiarioDTO> aperturas = new List<CajaDiarioDTO>();
                List<CajaCuadreTipoPagoDTO> cuadreTipoPago = new List<CajaCuadreTipoPagoDTO>();
                List<TipoPagoEnt> tiposPago = new List<TipoPagoEnt>();

                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito) {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        throw new AlertException(Mensaje);
                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        aperturas.Add(
                            new CajaDiarioDTO() {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdCaja = Convert.ToInt32(reader["IdCaja"]),
                                FechaHoraApertura = Convert.ToDateTime(reader["FechaHoraApertura"]),
                                FechaHoraCierre = DBNull.Value == reader["FechaHoraCierre"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaHoraCierre"]),
                                SaldoInicial = Convert.ToDecimal(reader["SaldoInicial"]),
                                SaldoCierre = Convert.ToDecimal(reader["SaldoFinal"]),
                                IdUsuarioApertura = Convert.ToInt32(reader["IdUsuarioResponsable"]),
                                IdUsuarioCierre = Convert.ToInt32(reader["IdUsuarioCierre"]),
                                Turno = Convert.ToInt32(reader["Turno"]),
                                UsuarioApertura = Convert.ToString(reader["UsuarioApertura"]),
                                UsuarioCierre = DBNull.Value == reader["UsuarioCierre"] ? null : Convert.ToString(reader["UsuarioCierre"]),
                            }
                        );
                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        tiposPago.Add(
                            new TipoPagoEnt() {
                                IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]),
                                Descripcion = Convert.ToString(reader["Descripcion"])
                            }
                        );;
                    }
                }

                aperturas.ForEach(x =>
                {
                    tiposPago.ForEach(tp =>
                    {
                        cuadreTipoPago.Add(
                            new CajaCuadreTipoPagoDTO()
                            {
                                IdTipoPago = tp.IdTipoPago,
                                TipoPago = tp.Descripcion,
                                Total = 0,
                                PagoEfectivo = 0,
                                PagoTarjeta = 0,
                                Turno = x.Turno
                            }
                        );
                    });
                });

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        var cuadre = cuadreTipoPago.Find(x => (x.IdTipoPago == Convert.ToInt32(reader["IdTipoPago"]) && x.Turno == Convert.ToInt32(reader["Turno"])) );
                        if (cuadre != null) {
                            cuadre.Total = Convert.ToDecimal(reader["Total"]);
                            cuadre.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                            cuadre.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        }
                    }
                }

                CajaCuadreDTO obj = new CajaCuadreDTO()
                {
                    Aperturas = aperturas,
                    Cuadres = cuadreTipoPago
                };

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<CajaSeguimientoDiarioDTO> ReadSeguimientoDiario(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";

                List<CajaEntidadDTO> cajas = new List<CajaEntidadDTO>();
                List<TipoPagoEnt> tiposPago = new List<TipoPagoEnt>();
                List<CajaTipoPagoDTO> cajaTiposPago = new List<CajaTipoPagoDTO>();


                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        throw new AlertException(Mensaje);
                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        cajas.Add(
                            new CajaEntidadDTO()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Total = Convert.ToDecimal(reader["Total"]),
                            }
                        );
                    }
                }

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        tiposPago.Add(
                            new TipoPagoEnt()
                            {
                                IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]),
                                Descripcion = Convert.ToString(reader["Descripcion"])
                            }
                        ); ;
                    }
                }

                cajas.ForEach(x =>
                {
                    tiposPago.ForEach(tp =>
                    {
                        cajaTiposPago.Add(
                            new CajaTipoPagoDTO()
                            {
                                IdCaja = x.Id,
                                IdTipoPago = tp.IdTipoPago,
                                TipoPago = tp.Descripcion,
                                Total = 0,
                                PagoEfectivo = 0,
                                PagoTarjeta = 0
                            }
                        );
                    });
                });

                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        var cuadre = cajaTiposPago.Find(x => (x.IdTipoPago == Convert.ToInt32(reader["IdTipoPago"]) && x.IdCaja == Convert.ToInt32(reader["IdCaja"])));
                        if (cuadre != null)
                        {
                            cuadre.Total = Convert.ToDecimal(reader["Total"]);
                            cuadre.PagoEfectivo = Convert.ToDecimal(reader["PagoEfectivo"]);
                            cuadre.PagoTarjeta = Convert.ToDecimal(reader["PagoTarjeta"]);
                        }
                    }
                }

                CajaSeguimientoDiarioDTO obj = new CajaSeguimientoDiarioDTO()
                {
                    Cajas = cajas,
                    Ingresos = cajaTiposPago
                };

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
