using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class ClienteAsignadoDat : IClienteAsignadoDat
    {
        private readonly string _connectionString;

        public ClienteAsignadoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<ClienteAsignadoDTO>> ObtenerAsignacion(int tipoCliente, int idSede, DateTime fechaCita, int asignado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_ObtenerCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pTipoCliente", tipoCliente);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pAsignado", asignado);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerAsignacion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<int> Insertar(ClienteAsignarListaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDatos", JsonSerializer.Serialize(model.ClientesAsignados));

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<int> Reasignar(ClienteAsignarListaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_Reasignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDatos", JsonSerializer.Serialize(model.ClientesAsignados));

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_ObtenerAsignados", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pFechaCofirmacion", fechaConfirmacion);
                cmd.Parameters.AddWithValue("pTipoCliente", tipoCliente);
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);
                cmd.Parameters.AddWithValue("pAsignadoPor", asignadoPor);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarAsignados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<List<ClienteAsignadoDTO>> BuscarParaReasignados(DateTime fechaConfirmacion, int tipoCliente, int idTipo, int idSede, int asignadoA, int asignadoPor)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_ObtenerParaReasignados", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pFechaCofirmacion", fechaConfirmacion);
                cmd.Parameters.AddWithValue("pTipoCliente", tipoCliente);
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);
                cmd.Parameters.AddWithValue("pAsignadoPor", asignadoPor);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarParaReasignados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ClienteAsignadoDTO>> BuscarAsignadosUsuario(DateTime fechaConfirmacion,int asignadoA)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_ObtenerAsignadosUsuario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pFechaCofirmacion", fechaConfirmacion);
                cmd.Parameters.AddWithValue("pAsignadoA", asignadoA);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarAsignados(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Trabajar(ClienteAsignadoDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_Trabajar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pCitas", JsonSerializer.Serialize(model.Citas) );
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdEstadoCliente", model.IdEstadoCliente);
                cmd.Parameters.AddWithValue("pId", model.Id);

                var reader = await cmd.ExecuteReaderAsync();
                bool Exito = false;
                string Mensaje = "";
                string MensajeDetalle = "";


                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito) {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        MensajeDetalle = Convert.ToString(reader["MensajeDetalle"]);
                        throw new AlertException(Mensaje);
                    }
                }

                conn.Close();

                return Exito;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<bool> MarcarVisto(List<int> model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_MarcarVisto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pClientes", JsonSerializer.Serialize(model));

                var reader = await cmd.ExecuteReaderAsync();
                bool Exito = false;
                string Mensaje = "";
                string MensajeDetalle = "";


                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    if (!Exito)
                    {
                        Mensaje = Convert.ToString(reader["Mensaje"]);
                        MensajeDetalle = Convert.ToString(reader["MensajeDetalle"]);
                        throw new AlertException(Mensaje);
                    }
                }

                conn.Close();

                return Exito;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<List<ClientAsignadoHistoriaDTO>> ObtenerHistoria(int idClientAsignado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_ClienteAsignado_ObtenerHistorial", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandTimeout = 360
                };
                cmd.Parameters.AddWithValue("pIdClienteAsignado", idClientAsignado);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerHistoria(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // READERS


        static async Task<List<ClienteAsignadoDTO>> ReadObtenerAsignacion(DbDataReader reader)
        {
            try
            {
                List<ClienteAsignadoDTO> lista = new List<ClienteAsignadoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteAsignadoDTO obj = new ClienteAsignadoDTO
                    {
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        TipoCliente = reader["Tipo"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["Fecha"])
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


        static async Task<List<ClienteAsignadoDTO>> ReadBuscarAsignados(DbDataReader reader)
        {
            try
            {
                List<ClienteAsignadoDTO> lista = new List<ClienteAsignadoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteAsignadoDTO obj = new ClienteAsignadoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Telefono = Convert.ToString(reader["Celular"]),
                        UsuOperadorNombre = Convert.ToString(reader["AsignadoANombre"]),
                        UsuOperador = Convert.ToString(reader["AsignadoAUsuario"]),
                        Tipo = reader["Tipo"].ToString(),
                        UsuRegistroNombre = Convert.ToString(reader["AsignadoPorNombre"]),
                        UsuRegistro = Convert.ToString(reader["AsignadoPorUsuario"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        EstadoColor = Convert.ToString(reader["EstadoColor"]),
                        TipoCliente = Convert.ToString(reader["TipoCliente"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdEstadoCliente = DBNull.Value == reader["IdEstadoCliente"] ? (int?)null : Convert.ToInt32(reader["IdEstadoCliente"]),
                        EstadoCliente = DBNull.Value == reader["EstadoCliente"] ? null : Convert.ToString(reader["EstadoCliente"]),
                        EstadoClienteColor = DBNull.Value == reader["EstadoClienteColor"] ? null : Convert.ToString(reader["EstadoClienteColor"]),
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

        static async Task<List<ClienteAsignadoDTO>> ReadBuscarParaReasignados(DbDataReader reader)
        {
            try
            {
                List<ClienteAsignadoDTO> lista = new List<ClienteAsignadoDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteAsignadoDTO obj = new ClienteAsignadoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Telefono = Convert.ToString(reader["Celular"]),
                        UsuOperadorNombre = Convert.ToString(reader["AsignadoANombre"]),
                        UsuOperador = Convert.ToString(reader["AsignadoAUsuario"]),
                        Tipo = reader["Tipo"].ToString(),
                        UsuRegistroNombre = Convert.ToString(reader["AsignadoPorNombre"]),
                        UsuRegistro = Convert.ToString(reader["AsignadoPorUsuario"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        EstadoColor = Convert.ToString(reader["EstadoColor"]),
                        TipoCliente = Convert.ToString(reader["TipoCliente"]),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdEstadoCliente = DBNull.Value == reader["IdEstadoCliente"] ? (int?)null : Convert.ToInt32(reader["IdEstadoCliente"]),
                        EstadoCliente = DBNull.Value == reader["EstadoCliente"] ? null : Convert.ToString(reader["EstadoCliente"]),
                        EstadoClienteColor = DBNull.Value == reader["EstadoClienteColor"] ? null : Convert.ToString(reader["EstadoClienteColor"]),
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


        static async Task<List<ClientAsignadoHistoriaDTO>> ReadObtenerHistoria(DbDataReader reader)
        {
            try
            {
                List<ClientAsignadoHistoriaDTO> lista = new List<ClientAsignadoHistoriaDTO>();
                while (await reader.ReadAsync())
                {
                    ClientAsignadoHistoriaDTO obj = new ClientAsignadoHistoriaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdClienteAsignado = Convert.ToInt32(reader["IdClienteAsignado"]),
                        AsignadoA = Convert.ToString(reader["AsignadoA"]),
                        AsignadoPor = Convert.ToString(reader["AsignadoPor"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
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
