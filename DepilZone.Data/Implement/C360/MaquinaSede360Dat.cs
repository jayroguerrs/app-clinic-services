using DepilZone.Data.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement.C360
{
    public class MaquinaSede360Dat : IMaquinaSede360Dat
    {
        private readonly string _connectionString;

        public MaquinaSede360Dat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<List<MaquinaSede360DisponibleDTO>> BuscarFechaDisponible(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede360_BuscarFechaDisponible", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaDesde);
                cmd.Parameters.AddWithValue("pFechaFin", fechaHasta);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdSede", idSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarFechaDisponible(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<MaquinaSede360DTO>> VerMaquinaDisponible(DateTime fecha, int idServicio, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede360_VerDisponible", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdSede", idSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadVerMaquinaDisponible(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<MaquinaSede360DTO> VerMaquinaDisponibleById(int IdMaquina, DateTime fecha, int idServicio, int idSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede360_VerDisponibleById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdMaquina", IdMaquina);
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdSede", idSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadVerMaquinaDisponibleById(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> AsignarTecnologias(int idMaquinaSede, MaquinaSedeTecnologia360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("MaquinaSedeTecnologia_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdMaquinaSede", idMaquinaSede);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pTecnologias", JsonSerializer.Serialize(model.Tecnologias));

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAsignarTecnologias(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<TecnologiaDTO>> ListarTecnologias(int idMaquinaSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("MaquinaSedeTecnologia_ListarTecnologias", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdMaquinaSede", idMaquinaSede);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarTecnologias(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        //****************************************************************** READERS

        static async Task<List<MaquinaSede360DisponibleDTO>> ReadBuscarFechaDisponible(DbDataReader reader)
        {
            try
            {
                List<MaquinaSede360DisponibleDTO> collection = new List<MaquinaSede360DisponibleDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSede360DisponibleDTO obj = new MaquinaSede360DisponibleDTO();
                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.Porcentaje = Convert.ToInt32(reader["Porcentaje"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.Sede = DBNull.Value == reader["Sede"] ? null : Convert.ToString(reader["Sede"]);

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<MaquinaSede360DTO>> ReadVerMaquinaDisponible(DbDataReader reader)
        {
            try
            {
                List<MaquinaSede360DTO> collection = new List<MaquinaSede360DTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSede360DTO obj = new MaquinaSede360DTO();
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.Porcentaje = Convert.ToInt32(reader["Porcentaje"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.Sede = DBNull.Value == reader["Sede"] ? null : Convert.ToString(reader["Sede"]);
                    obj.Maquina = DBNull.Value == reader["Maquina"] ? null : Convert.ToString(reader["Maquina"]);
                    obj.Tecnologias = new List<TecnologiaSDTO>(JsonSerializer.Deserialize<List<TecnologiaSDTO>>(Convert.ToString(reader["Tecnologias"])));

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<MaquinaSede360DTO> ReadVerMaquinaDisponibleById(DbDataReader reader)
        {
            try
            {
                MaquinaSede360DTO obj = new MaquinaSede360DTO();
                while (await reader.ReadAsync())
                {
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.Porcentaje = Convert.ToInt32(reader["Porcentaje"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.Sede = DBNull.Value == reader["Sede"] ? null : Convert.ToString(reader["Sede"]);
                    obj.Maquina = DBNull.Value == reader["Maquina"] ? null : Convert.ToString(reader["Maquina"]);
                    obj.Tecnologias = new List<TecnologiaSDTO>(JsonSerializer.Deserialize<List<TecnologiaSDTO>>(Convert.ToString(reader["Tecnologias"])));
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<bool> ReadAsignarTecnologias(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToBoolean(reader["Exito"]);
                    if (!exito)
                    {
                        mensaje = Convert.ToString(reader["Mensaje"]);
                        codigoError = Convert.ToInt32(reader["ErrorNumero"]);
                        detalle = Convert.ToString(reader["ErrorDetalle"]);
                        throw new AlertException(mensaje);
                    }
                }

                return exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<TecnologiaDTO>> ReadListarTecnologias(DbDataReader reader)
        {
            try
            {
                List<TecnologiaDTO> collection = new List<TecnologiaDTO>();
                while (await reader.ReadAsync())
                {
                    TecnologiaDTO obj = new TecnologiaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}