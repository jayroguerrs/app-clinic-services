using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ClienteBusquedaCitasDat : IClienteBusquedaCitasDat
    {
        private readonly string _connectionString;

        public ClienteBusquedaCitasDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<ClienteResultDTO>> BusquedaCliente(string datoCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_Busqueda", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader, datoCliente);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<VerTotalesDTO>> VerCitasTotales(DateTime fechaCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Ver_Totales", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsVerTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseCitasBusquedaPorIdDTO> BusquedaCitaPorId(int IdCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Busqueda_Id", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCita", IdCita);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerCitaPorId(reader, true);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<ResponseCitasClienteCcvoxDTO>> ObtenerClienteCitasCcvox(int[] ids)
        {
            try
            {
                var respuesta = new List<ResponseCitasClienteCcvoxDTO>();
                var resultados = new List<ResponseCitasClienteDTO>(); 

                foreach (var idCliente in ids)
                {
                    var obj = new ResponseCitasClienteCcvoxDTO();
                    ResponseCitasClienteDTO citasDeCliente = await ObtenerClienteCitas(idCliente);
                    string nombreCliente = await ObtenerNombreDeClientes(idCliente);

                    if (citasDeCliente != null)
                    {
                        obj.Citas = citasDeCliente.Citas;
                        obj.NombreCliente = nombreCliente;
                        obj.Id = idCliente;
                    }

                    respuesta.Add(obj);
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseCitasClienteDTO> ObtenerClienteCitas(int IdCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cliente_Citas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerCitas(reader, false);

                conn.Close();             

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> ObtenerNombreDeClientes(int IdCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Nombres_De_Clientes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerNombreCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public async Task<ResponseCitasClienteDTO> ObtenerCitasGlobales(DateTime fechaCita, int? Pagina, int? RowsPerPage, int? Sede, int? EstadoCita, int? Servicio, int? TipoCliente, int? TipoCita, string? HoraDesde, string? HoraHasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Global_Citas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                if (Pagina == null)
                {
                    Pagina = 1;
                    RowsPerPage = 100;
                }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("PageNumber", Pagina);
                cmd.Parameters.AddWithValue("RowsPerPage", RowsPerPage);

                cmd.Parameters.AddWithValue("Sede", Sede);
                cmd.Parameters.AddWithValue("TipoCliente", TipoCliente);
                cmd.Parameters.AddWithValue("TipoCita", TipoCita);
                cmd.Parameters.AddWithValue("EstadoCita", EstadoCita);
                cmd.Parameters.AddWithValue("Servicio", Servicio);

                cmd.Parameters.AddWithValue("pHoraInicio", HoraDesde);
                cmd.Parameters.AddWithValue("pHoraTermino", HoraHasta);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtenerCitas(reader, true);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static async Task<string> ReadItemsObtenerNombreCliente(DbDataReader reader)
        {
            string nombreCompleto = "";
            while (await reader.ReadAsync())
            {
                nombreCompleto = $"{Convert.ToString(reader["Nombres"])} {Convert.ToString(reader["Apellidos"])}";
                
            }

            return nombreCompleto;
        }

        static async Task<IEnumerable<ClienteResultDTO>> ReadItemsObtener(DbDataReader reader, string datoCliente)
        {
            try
            {
                int maxItems = 5;
                IList<ClienteResultDTO> lista = new List<ClienteResultDTO>();
                bool esNumero = long.TryParse(datoCliente, out long documento);

                string[] palabrasBusqueda = datoCliente.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                while (await reader.ReadAsync())
                {
                    if (lista.Count >= maxItems)
                    {
                        break;
                    }

                    string nombreCompleto = $"{Convert.ToString(reader["Nombres"])} {Convert.ToString(reader["Apellidos"])}";
                    string documentoCliente = Convert.ToString(reader["Documento"]);
                    string celular1 = Convert.ToString(reader["Celular1"]);
                    string celular2 = Convert.ToString(reader["Celular2"]);

                    if (esNumero && datoCliente.Length < 9)
                    {
                        if (documentoCliente.Contains(datoCliente))
                        {
                            ClienteResultDTO obj = new ClienteResultDTO
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Cliente = $"{Convert.ToString(reader["Nombres"])} {Convert.ToString(reader["Apellidos"])} (DNI): {Convert.ToString(reader["Documento"])}",
                                Nombre = nombreCompleto,
                            };
                            lista.Add(obj);
                        }
                    }
                    else if (esNumero && datoCliente.Length == 9)
                    {
                        if (celular1.Contains(datoCliente) || celular2.Contains(datoCliente))
                        {
                            ClienteResultDTO obj = new ClienteResultDTO
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Cliente = $"{Convert.ToString(reader["Nombres"])} {Convert.ToString(reader["Apellidos"])} (DNI): {Convert.ToString(reader["Documento"])}",
                                Nombre = nombreCompleto,
                            };
                            lista.Add(obj);
                        }
                    }
                    else
                    {
                        bool coincide = true;
                        foreach (var palabra in palabrasBusqueda)
                        {
                            if (nombreCompleto.IndexOf(palabra, StringComparison.OrdinalIgnoreCase) < 0)
                            {
                                coincide = false;
                                break;
                            }
                        }

                        if (coincide)
                        {
                            ClienteResultDTO obj = new ClienteResultDTO
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Cliente = $"{Convert.ToString(reader["Nombres"])} {Convert.ToString(reader["Apellidos"])} (DNI): {Convert.ToString(reader["Documento"])}",
                                Nombre = nombreCompleto,
                            };
                            lista.Add(obj);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<IEnumerable<VerTotalesDTO>> ReadItemsVerTotales(DbDataReader reader)
        {
            try
            {
                var lista = new List<VerTotalesDTO>();

                // Primer resultset: citas
                while (await reader.ReadAsync())
                {
                    lista.Add(new VerTotalesDTO
                    {
                        Cantidad = Convert.ToInt32(reader["CantidadCitas"]),
                        Estado = reader["Estado"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                       
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw; // `throw ex` pierde el stack trace original
            }
        }


        static async Task<ResponseCitasClienteDTO> ReadItemsObtenerCitas(DbDataReader reader, bool esListadoGlobal)
        {
            try
            {
                var result = new ResponseCitasClienteDTO();
                var lista = new List<CitasClienteDTO>();
                bool hayPagadoUno = false;

                // Primer resultset: citas
                while (await reader.ReadAsync())
                {
                    if (Convert.ToInt32(reader["Pagado"]) == 1)
                        hayPagadoUno = true;

                    lista.Add(new CitasClienteDTO
                    {
                        FechaCita = reader["FechaCita"] == DBNull.Value ? "" : Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),

                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]),
                        IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),
                        Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]),
                        ClienteNuevo = esListadoGlobal ? reader["ClienteNuevo"].ToString() : null,
                        NuevoCliente = null,
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        NombreCliente = reader["Nombres"].ToString() + " " + reader["Apellidos"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino =reader["HoraTermino"] == DBNull.Value ? "" : reader["HoraTermino"].ToString(),
                        PrecioDePagoFinal = reader["PrecioDePagoFinal"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["PrecioDePagoFinal"]),
                        Pagado = reader["Pagado"] == DBNull.Value ? false : Convert.ToBoolean(reader["Pagado"]),
                        Estado = reader["Estado"] == DBNull.Value ? "" : Convert.ToString(reader["Estado"]),
                        IdCronograma = reader["IdCronograma"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCronograma"]),
                        Nombres = reader["Nombres"] == DBNull.Value ? "" : reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"] == DBNull.Value ? "" : reader["Apellidos"].ToString(),
                        NumerosCelulares = $"{reader["Celular1"]?.ToString() ?? ""} - {reader["Celular2"]?.ToString() ?? ""}",
                        SeudonimoPaciente = reader["Seudonimo"]?.ToString() ?? "",
                        IdFichaAdmision = null,
                        IdTipoComprobante = reader["IdTipoComprobante"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdTipoComprobante"]),
                        IdTipoPago = reader["TipoDePago"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TipoDePago"]),
                        ColorTipoPago = reader["Color"]?.ToString() ?? ""
                    });
                }

                // Segundo resultset: zonas
                Dictionary<int, string> zonasDict = new();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        int idCita = Convert.ToInt32(reader["IdCita"]);
                        string zonas = Convert.ToString(reader["Zonas"]);
                        zonasDict[idCita] = zonas;
                    }
                }

                // Asignar zonas de forma optimizada
                foreach (var cita in lista)
                {
                    if (zonasDict.TryGetValue(cita.IdCita, out var zonas))
                        cita.Zonas = zonas.Split("***");
                    else
                        cita.Zonas = Array.Empty<string>();
                }

                if (await reader.NextResultAsync() && esListadoGlobal == true)
                {
                    if (await reader.ReadAsync())
                    {
                        result.Total = Convert.ToInt32(reader["TotalCitas"]);
                    }
                }

                result.EsNuevoCliente = hayPagadoUno ? "No Nuevo" : "Nuevo";
                result.Citas = lista;
                return result;
            }
            catch (Exception ex)
            {
                throw; // `throw ex` pierde el stack trace original
            }
        }



        static async Task<ResponseCitasBusquedaPorIdDTO> ReadItemsObtenerCitaPorId(DbDataReader reader, bool esListadoGlobal)
        {
            try
            {
                ResponseCitasBusquedaPorIdDTO result = new ResponseCitasBusquedaPorIdDTO();

                string clienteNuevo = "Nuevo";
                bool hayPagadoUno = false;

                IList<CitasBusquedaPorIdDTO> lista = new List<CitasBusquedaPorIdDTO>();
                while (await reader.ReadAsync())
                {
                    if (Convert.ToInt32(reader["Pagado"]) == 1)
                    {
                        hayPagadoUno = true; // Marca la bandera si encontramos un "Pagado" = 1
                    }

                    CitasBusquedaPorIdDTO obj = new CitasBusquedaPorIdDTO
                    {

                        FechaCita = Convert.ToDateTime(reader["FechaCita"]).ToString("dd-MM-yyyy"),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),//x
                        IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]),//x
                        IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),//x
                        IdPreferente = Convert.ToInt32(reader["IdPreferente"]),//x
                        IdSede = Convert.ToInt32(reader["IdSede"]),//x
                        IdServicio = Convert.ToInt32(reader["IdServicio"]),//x
                        Total = Convert.ToDecimal(reader["Total"]),

                        ClienteNuevo = esListadoGlobal ? reader["ClienteNuevo"].ToString() : null,
                        NuevoCliente = null,
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),//x

                        NombreCliente = esListadoGlobal ? reader["Nombres"].ToString() + " " + reader["Apellidos"].ToString() : "",
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino = reader["HoraTermino"].ToString(),

                        PrecioDePagoFinal = reader["PrecioDePagoFinal"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["PrecioDePagoFinal"]),
                        CelularCliente = reader["Celular1"] == DBNull.Value ? "" : reader["Celular1"].ToString(),

                        Pagado = reader["Pagado"] == DBNull.Value ? false : Convert.ToBoolean(reader["Pagado"]),
                        Estado = reader["Estado"] == DBNull.Value ? "" : Convert.ToString(reader["Estado"]),

                        IdCronograma = reader["IdCronograma"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCronograma"]),

                        Nombres = reader["Nombres"] == DBNull.Value ? "" : reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"] == DBNull.Value ? "" : reader["Apellidos"].ToString(),
                        NumerosCelulares = (reader["Celular1"] == DBNull.Value ? "" : reader["Celular1"].ToString()) + " - " + (reader["Celular2"] == DBNull.Value ? "" : reader["Celular2"].ToString()),
                        SeudonimoPaciente = reader["Seudonimo"] == DBNull.Value ? "" : reader["Seudonimo"].ToString(),
                        IdFichaAdmision = (Int32?)null,
                        IdTipoComprobante = reader["IdTipoComprobante"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdTipoComprobante"]),

                        IdTipoPago = reader["TipoDePago"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TipoDePago"]),
                        ColorTipoPago = reader["Color"]?.ToString() ?? ""
                    };

                    lista.Add(obj);
                }

                List<ZonasContatenadasDTO> zonasConcatenadas = new List<ZonasContatenadasDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ZonasContatenadasDTO zonas = new ZonasContatenadasDTO()
                        {
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            //TotalCita = Convert.ToDouble(reader["Total"]),
                            ZonaContatenada = Convert.ToString(reader["Zonas"])

                        };
                        zonasConcatenadas.Add(zonas);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron zonas para las citas.");
                }


                foreach (CitasBusquedaPorIdDTO cita in lista)
                {
                    if (zonasConcatenadas != null && zonasConcatenadas.Count > 0)
                    {
                        var item = (from zona in zonasConcatenadas where zona.IdCita == cita.IdCita select zona).FirstOrDefault();
                        if (item != null)
                        {
                            cita.Zonas = item.ZonaContatenada.Split("***");
                        }
                        else
                        {
                            cita.Zonas = [];
                        }
                    }
                }


                if (hayPagadoUno)
                {
                    clienteNuevo = "No Nuevo";
                }

                result.EsNuevoCliente = clienteNuevo;
                result.Citas = lista;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
