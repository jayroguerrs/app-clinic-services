using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ClienteEncuestaDat : IClienteEncuestaDat
    {
        private readonly string _connectionString;

        public ClienteEncuestaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ClienteEncuestaDTO>> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteEncuesta_ObtenerReporteGeneral", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", IdSede);
                cmd.Parameters.AddWithValue("pFdesde", Fdesde);
                cmd.Parameters.AddWithValue("pFhasta", Fhasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReporteGeneral(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CE_PreguntaDTO>> ObtenerReporteGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteEncuesta_ObtenerGraficoGeneral", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", IdSede);
                cmd.Parameters.AddWithValue("fechaDesde", Fdesde);
                cmd.Parameters.AddWithValue("fechaHasta", Fhasta);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadReporteGeneralGrafico(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<List<ClienteEncuestaDTO>> ReadReporteGeneral(DbDataReader reader)
        {
            try
            {
                List<ClienteEncuestaDTO> collection = new List<ClienteEncuestaDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteEncuestaDTO obj = new ClienteEncuestaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Cliente = reader["Cliente"].ToString(),
                        Distrito = reader["Distrito"] == DBNull.Value ? null : reader["Distrito"].ToString(),
                        Sede = reader["Sede"].ToString(),
                        VEfectividadTratamiento = reader["VEfectividadTratamiento"].ToString(),
                        VAtencionCliente = reader["VAtencionCliente"].ToString(),
                        VClaridadInformativa = reader["VClaridadInformativa"].ToString(),
                        VBrindoInformacionPromo = reader["VBrindoInformacionPromo"].ToString(),
                        VMedio = reader["VMedio"].ToString(),
                        Sugerencias = reader["Sugerencias"] == DBNull.Value ? null : reader["Sugerencias"].ToString(),
                        VEspecialista = reader["VEspecialista"].ToString(),
                        FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                    };
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        static async Task<List<CE_PreguntaDTO>> ReadReporteGeneralGrafico(DbDataReader reader)
        {
            try
            {
                // Primero obtenemos las preguntas
                List<CE_PreguntaDTO> preguntas = new List<CE_PreguntaDTO>();
                List<CE_Resultado> dd = new List<CE_Resultado>();
                while (await reader.ReadAsync())
                {
                    CE_PreguntaDTO obj = new CE_PreguntaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Resultados = new List<CE_Resultado>()
                    };
                    preguntas.Add(obj);
                }

                // Luego obtenemos las respuestas agrupadas
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        var resultado = new CE_Resultado()
                        {
                            Total = Convert.ToInt32(reader["Valor"]),
                            Item = reader["Item"].ToString()
                        };

                        int idTipo = Convert.ToInt32(reader["IdTipo"]);
                        // Buscamos su tipo de pregunta a la cual pertenece y se incrustamos la respuesta
                       preguntas.Find(p => p.Id == idTipo).Resultados.Add(resultado);
                        dd.Add(resultado);
                    }
                }


                return preguntas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
