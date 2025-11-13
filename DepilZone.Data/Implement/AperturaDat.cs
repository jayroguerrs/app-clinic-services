using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class AperturaDat : IAperturaDat
	{
        private readonly string _connectionString;

        public AperturaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<ListadoAperturayCierreEnt>> Insertar(ListadoAperturayCierreEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCaja", model.IdCaja);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdTurno", model.IdTurno);
                cmd.Parameters.AddWithValue("FechaApertura", model.FechaApertura);
                cmd.Parameters.AddWithValue("HoraApertura", model.HoraApertura);
                cmd.Parameters.AddWithValue("FechaCierre", model.FechaCierre);
                cmd.Parameters.AddWithValue("ischeckapertura", model.ischeckapertura);
                cmd.Parameters.AddWithValue("ischeckcierre", model.ischeckcierre);
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
        public async Task<IEnumerable<ListadoAperturayCierreEnt>> Obtenerlistadoaperturaycierreporfechayidturno(DateTime fechaInicio, int idturno, int idcaja)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Obtener_porfechayturno", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@pidturno", idturno);
                cmd.Parameters.AddWithValue("@pidcaja", idcaja);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIListadoAperturatems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<ListadoAperturayCierreEnt>> Modificar(ListadoAperturayCierreEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdApertura", model.IdApertura);
                cmd.Parameters.AddWithValue("IdCaja", model.IdCaja);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("IdTurno", model.IdTurno);
                cmd.Parameters.AddWithValue("FechaApertura", model.FechaApertura);
                cmd.Parameters.AddWithValue("HoraApertura", model.HoraApertura);
                cmd.Parameters.AddWithValue("FechaCierre", model.FechaCierre);
                cmd.Parameters.AddWithValue("ischeckapertura", model.ischeckapertura);
                cmd.Parameters.AddWithValue("ischeckcierre", model.ischeckcierre);
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
        public async Task<IEnumerable<ReporteAperturaEnt>> reportecierre(DateTime fechaInicio, int idturno)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Listado_CierreCaja", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@pidturno", idturno);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIReporteAperturatems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<ReporteAperturaEnt>> montototal(DateTime fechaInicio, int idturno)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Montototal_CierreCaja", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@pidturno", idturno);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIReporteMontototalAperturatems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<ReporteAperturaEnt>> principal(DateTime fechaInicio, int idturno, int idcaja)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Apertura_Listado_Principal", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@pidturno", idturno);
                cmd.Parameters.AddWithValue("@pidcaja", idcaja);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIReporteprincipalAperturatems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        // Readers

        static async Task<Respuesta<ListadoAperturayCierreEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<ListadoAperturayCierreEnt> obj = new Respuesta<ListadoAperturayCierreEnt>
                {
                    Response = new ListadoAperturayCierreEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.Response.IdApertura = Convert.ToInt32(reader["IdApertura"]);
                    obj.Response.descripcion = Convert.ToString(reader["descripcion"]);
                    obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Response.Turno = Convert.ToString(reader["Turno"]);
                    obj.Response.FechaApertura = Convert.ToDateTime(reader["FechaApertura"]);
                    obj.Response.HoraApertura = Convert.ToString(reader["HoraApertura"]);
                    obj.Response.FechaCierre = Convert.ToDateTime(reader["FechaCierre"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<ListadoAperturayCierreEnt>> ReadIListadoAperturatems(DbDataReader reader)
        {
            try
            {
                IList<ListadoAperturayCierreEnt> lista = new List<ListadoAperturayCierreEnt>();
                while (await reader.ReadAsync())
                {
                    ListadoAperturayCierreEnt obj = new ListadoAperturayCierreEnt
                    {
                        IdApertura = Convert.ToInt32(reader["IdApertura"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        descripcion = Convert.ToString(reader["descripcion"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        IdTurno = Convert.ToInt32(reader["IdTurno"]),
                        Turno = Convert.ToString(reader["Turno"]),
                        FechaApertura = Convert.ToDateTime(reader["FechaApertura"]),
                        //HoraApertura = Convert.ToString(reader["HoraApertura"]),
                        FechaCierre = Convert.ToDateTime(reader["FechaCierre"]),
                        ischeckapertura = Convert.ToBoolean(reader["ischeckapertura"]),
                        ischeckcierre = Convert.ToBoolean(reader["ischeckcierre"]),
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
        
        static async Task<IEnumerable<ReporteAperturaEnt>> ReadIReporteAperturatems(DbDataReader reader)
        {
            try
            {
                IList<ReporteAperturaEnt> lista = new List<ReporteAperturaEnt>();
                while (await reader.ReadAsync())
                {
                    ReporteAperturaEnt obj = new ReporteAperturaEnt
                    {
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        NumeroDocumento = Convert.ToString(reader["NumeroDocumento"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Caja = Convert.ToString(reader["Caja"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        Cliente = Convert.ToString(reader["Cliente"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdDocumento = Convert.ToInt32(reader["IdDocumento"]),
                        Documento = Convert.ToString(reader["Documento"]),
                        IdTipoPago = Convert.ToInt32(reader["IdTipoPago"]),
                        TipodePago = Convert.ToString(reader["TipodePago"]),
                        Pagado = Convert.ToString(reader["Pagado"]),
                        Fecha = Convert.ToString(reader["Fecha"]),
                        hora = Convert.ToString(reader["hora"]),
                        usuarioregistro = Convert.ToString(reader["usuarioregistro"])
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
        static async Task<IEnumerable<ReporteAperturaEnt>> ReadIReporteMontototalAperturatems(DbDataReader reader)
        {
            try
            {
                IList<ReporteAperturaEnt> lista = new List<ReporteAperturaEnt>();
                while (await reader.ReadAsync())
                {
                    ReporteAperturaEnt obj = new ReporteAperturaEnt
                    {
                        Pagado = Convert.ToString(reader["Pagado"]),
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
        static async Task<IEnumerable<ReporteAperturaEnt>> ReadIReporteprincipalAperturatems(DbDataReader reader)
        {
            try
            {
                IList<ReporteAperturaEnt> lista = new List<ReporteAperturaEnt>();
                while (await reader.ReadAsync())
                {
                    ReporteAperturaEnt obj = new ReporteAperturaEnt
                    {
                        Caja = Convert.ToString(reader["Caja"]),
                        IdCaja = Convert.ToInt32(reader["IdCaja"]),
                        Usuario = Convert.ToString(reader["Usuario"]),
                        Fecha = Convert.ToString(reader["Fecha"]),
                        Efectivo = Convert.ToString(reader["Efectivo"]),
                        Tarjetadecredito = Convert.ToString(reader["Tarjetadecredito"]),
                        Deposito = Convert.ToString(reader["Deposito"]),
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
    }
}
