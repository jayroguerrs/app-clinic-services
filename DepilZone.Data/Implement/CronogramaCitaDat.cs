using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement
{
    public class CronogramaCitaDat : ICronogramaCitaDat
    {
        private readonly string _connectionString;

        public CronogramaCitaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<int> Insertar(CronogramaCitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("pUuid", model.Uuid);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdZona", model.IdZona);
                cmd.Parameters.AddWithValue("pIdTratamiento", model.IdTratamiento);
                cmd.Parameters.AddWithValue("pPrecio", model.Precio);
                //cmd.Parameters.AddWithValue("pSemanas", JsonSerializer.Serialize(model.Semanas));
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdPreferente", model.IdPreferente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Modificar(CronogramaCitaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCronograma", model.Id);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdZona", model.IdZona);
                cmd.Parameters.AddWithValue("pIdTratamiento", model.IdTratamiento);
                cmd.Parameters.AddWithValue("pPrecio", model.Precio);
                //cmd.Parameters.AddWithValue("pSemanas", JsonSerializer.Serialize(model.Semanas));
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadModificar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<CronogramaCitaDTO> BuscarCronograma(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_Buscar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
               // cmd.Parameters.AddWithValue("pUuid", uuid);
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarByUuid(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        /*public async Task<List<CronogramaCitaSemanaDTO>> ListarSemanas(string uuid, int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_BuscarSemanas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUuid", uuid);
                cmd.Parameters.AddWithValue("pId", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarSemanas(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }*/



        public async Task<List<CronogramaCitaDTO>> ListarPorCliente(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_BuscarPorCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarPorCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<CronogramaCita_CitaDTO>> ListarCitas(int idCronograma)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CronogramaCita_ListarCitas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCronograma", idCronograma);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListarCitas(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        //****************************************************************** READERS

        static async Task<int> ReadInsertar(DbDataReader reader)
        {
            try
            {
                int exito = 0;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                while (await reader.ReadAsync())
                {
                    exito = Convert.ToInt32(reader["Id"]);
                    if (exito == 0)
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

        static async Task<bool> ReadModificar(DbDataReader reader)
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

        static async Task<CronogramaCitaDTO> ReadBuscarByUuid(DbDataReader reader)
        {
            try
            {
                bool exito = true;
                string mensaje = "";
                string detalle = "";
                int codigoError = 0;
                CronogramaCitaDTO cronogramaCitaDTO = new CronogramaCitaDTO();
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

                    cronogramaCitaDTO.Id = Convert.ToInt32(reader["Id"]);
                    //cronogramaCitaDTO.Uuid = Convert.ToString(reader["Uuid"]);
                    cronogramaCitaDTO.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cronogramaCitaDTO.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                    cronogramaCitaDTO.IdSede = Convert.ToInt32(reader["IdSede"]);
                    cronogramaCitaDTO.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    cronogramaCitaDTO.IdTratamiento = Convert.ToInt32(reader["IdTratamiento"]);
                    cronogramaCitaDTO.Tratamiento = Convert.ToString(reader["Tratamiento"]);
                    cronogramaCitaDTO.IdZona = Convert.ToInt32(reader["IdZona"]);
                    cronogramaCitaDTO.Precio = Convert.ToDecimal(reader["Precio"]);
                    //cronogramaCitaDTO.Semanas = JsonSerializer.Deserialize<List<CronogramaCitaSemanaDTO>>(Convert.ToString(reader["Semanas"]));
                    cronogramaCitaDTO.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    cronogramaCitaDTO.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    cronogramaCitaDTO.IdUsuarioModifico = DBNull.Value == reader["IdUsuarioRegistro"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    cronogramaCitaDTO.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);

                    cronogramaCitaDTO.UsuarioRegistro = DBNull.Value == reader["UsuarioRegistro"] ? null : Convert.ToString(reader["UsuarioRegistro"]);
                    cronogramaCitaDTO.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);

                    cronogramaCitaDTO.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);

                }

                return cronogramaCitaDTO;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        /*static async Task<List<CronogramaCitaSemanaDTO>> ReadListarSemanas(DbDataReader reader)
        {
            try
            {
                List<CronogramaCitaSemanaDTO> collection = new List<CronogramaCitaSemanaDTO>();
                while (await reader.ReadAsync())
                {
                    collection = new List<CronogramaCitaSemanaDTO>(JsonSerializer.Deserialize<List<CronogramaCitaSemanaDTO>>(Convert.ToString(reader["Semanas"])));
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }*/


        static async Task<List<CronogramaCitaDTO>> ReadListarPorCliente(DbDataReader reader)
        {
            try
            {
                List<CronogramaCitaDTO> collection = new List<CronogramaCitaDTO>();
                while (await reader.ReadAsync())
                {
                    CronogramaCitaDTO obj = new CronogramaCitaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    //obj.Uuid = Convert.ToString(reader["Uuid"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                    obj.UsuarioRegistro = Convert.ToString(reader["UsuarioRegistro"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.IdUsuarioModifico = DBNull.Value == reader["IdUsuarioModifico"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioModifico"]);
                    obj.UsuarioModifico = DBNull.Value == reader["UsuarioModifico"] ? null : Convert.ToString(reader["UsuarioModifico"]);
                    obj.FechaModifico = DBNull.Value == reader["FechaModifico"] ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.IdTratamiento = Convert.ToInt32(reader["IdTratamiento"]);
                    obj.Tratamiento = Convert.ToString(reader["Tratamiento"]);
                    obj.Precio = Convert.ToDecimal(reader["Precio"]);
                    obj.ServicioNombreCorto = Convert.ToString(reader["ServicioNombreCorto"]);
                    obj.ServicioColor = Convert.ToString(reader["ServicioColor"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdZona = Convert.ToInt32(reader["IdZona"]);
                    obj.Zona = Convert.ToString(reader["Zona"]);
                    obj.NumeroCitas = Convert.ToInt32(reader["NumeroCitas"]);
                    obj.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<CronogramaCita_CitaDTO>> ReadListarCitas(DbDataReader reader)
        {
            try
            {
                List<CronogramaCita_CitaDTO> collection = new List<CronogramaCita_CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CronogramaCita_CitaDTO obj = new CronogramaCita_CitaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    //obj.Uuid = Convert.ToString(reader["Uuid"]);
                    obj.Fecha = Convert.ToDateTime(reader["FechaCita"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    obj.Detalles = new List<Cita360DetallesDTO>(JsonSerializer.Deserialize<List<Cita360DetallesDTO>>(Convert.ToString(reader["Detalles"])));
                    obj.IdPreferente = Convert.ToInt32(reader["IdPreferente"]);


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