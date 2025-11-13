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
	public class ReporteZonasDat : IReporteZonasDat
	{
        private readonly string _connectionString;
        public ReporteZonasDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<ReporteZonaDTO>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zonas_Maximo", conn)
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
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zonas_Maximo_Fechas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
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
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zonas_Minimo", conn)
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
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Zonas_Minimo_Fechas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
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

        public async Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Sunat_Ple", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadPleItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<IEnumerable<ReporteCitaDTO>> Obtenercita()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_ReporteCitas_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCitaItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_ReporteCitas_Obtener_fecha", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCitaItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Especialistas_obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIEspecialistastems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Especialistas_obtener_fecha", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadIEspecialistastems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<IEnumerable<PleEnt>> ReadPleItems(DbDataReader reader)
        {
            try
            {
                IList<PleEnt> lista = new List<PleEnt>();
                while (await reader.ReadAsync())
                {
                    PleEnt obj = new PleEnt
                    {

                        Periodo = Convert.ToString(reader["Periodo"]),
                        numerodeoperacion = Convert.ToString(reader["numerodeoperacion"]),
                        tipodeasiento = Convert.ToString(reader["tipodeasiento"]),
                        FechaEmision = Convert.ToString(reader["FechaEmision"]),
                        IdTipoDocumento = Convert.ToString(reader["IdTipoDocumento"]),
                        Serie = Convert.ToString(reader["Serie"]),
                        Correlativo = Convert.ToString(reader["Correlativo"]),
                        NumeroInicial = Convert.ToString(reader["NumeroInicial"]),
                        NumeroFinal = Convert.ToString(reader["NumeroFinal"]),
                        tipoidentificador = Convert.ToString(reader["tipoidentificador"]),
                        Documento = Convert.ToString(reader["Documento"]),
                        RazonSocial = Convert.ToString(reader["RazonSocial"]),
                        ValorFacturadodelaexportacion = Convert.ToString(reader["ValorFacturadodelaexportacion"]),
                        BaseImponibleoperaciongravada = Convert.ToString(reader["BaseImponibleoperaciongravada"]),
                        Descuentodelabaseimponible = Convert.ToString(reader["Descuentodelabaseimponible"]),
                        ImpuestoGeneraldelasVentas = Convert.ToString(reader["ImpuestoGeneraldelasVentas"]),
                        DescuentosImpuestoGeneraldelasVentas = Convert.ToString(reader["DescuentosImpuestoGeneraldelasVentas"]),
                        OPExoneradas = Convert.ToString(reader["OPExoneradas"]),
                        OPInafecta = Convert.ToString(reader["OPInafecta"]),
                        ISC = Convert.ToString(reader["ISC"]),
                        basedearroz = Convert.ToString(reader["basedearroz"]),
                        IgvArrozPilado = Convert.ToString(reader["IgvArrozPilado"]),
                        OtrosCargos = Convert.ToString(reader["OtrosCargos"]),
                        ImporteTotal = Convert.ToString(reader["ImporteTotal"]),
                        CodigoMoneda = Convert.ToString(reader["CodigoMoneda"]),
                        TipodeCambio = Convert.ToString(reader["TipodeCambio"]),
                        Fechadeemionmodifica = Convert.ToString(reader["Fechadeemionmodifica"]),
                        tipomodifica = Convert.ToString(reader["tipomodifica"]),
                        seriemodifica = Convert.ToString(reader["seriemodifica"]),
                        correlativomodifica = Convert.ToString(reader["correlativomodifica"]),
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
        static async Task<IEnumerable<EspecialistasDTO>> ReadIEspecialistastems(DbDataReader reader)
        {
            try
            {
                IList<EspecialistasDTO> lista = new List<EspecialistasDTO>();
                while (await reader.ReadAsync())
                {
                    EspecialistasDTO obj = new EspecialistasDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        //id = Convert.ToString(reader["id"]),
                        especialistas = Convert.ToString(reader["especialistas"]),
                        Cantidaddeateciones = Convert.ToInt32(reader["Cantidaddeateciones"]),

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
        static async Task<IEnumerable<ReporteZonaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<ReporteZonaDTO> lista = new List<ReporteZonaDTO>();
                while (await reader.ReadAsync())
                {
                    ReporteZonaDTO obj = new ReporteZonaDTO
                    {
                        id = Convert.ToInt32(reader["id"]),
                        //id = Convert.ToString(reader["id"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        CantidadAtendidas = Convert.ToInt32(reader["CantidadAtendidas"]),

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
        static async Task<IEnumerable<ReporteCitaDTO>> ReadCitaItems(DbDataReader reader)
        {
            try
            {
                IList<ReporteCitaDTO> lista = new List<ReporteCitaDTO>();
                while (await reader.ReadAsync())
                {
                    ReporteCitaDTO obj = new ReporteCitaDTO
                    {
                        //idcita = Convert.ToInt32(reader["idcita"]),
                        fechacita = Convert.ToString(reader["fechacita"]),
                        cantidad = Convert.ToInt32(reader["cantidad"]),

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
