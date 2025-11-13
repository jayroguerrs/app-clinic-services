using DepilZone.Data.Interface.C360;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement.C360
{
    public class Cita360Dat : ICita360Dat
    {
        private readonly string _connectionString;

        public Cita360Dat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<bool> Insertar(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCronograma", model.IdCronograma);
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
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

        public async Task<bool> Modificar(int idCita, Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                //cmd.Parameters.AddWithValue("pIdCronograma", model.IdCronograma);
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);

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


        public async Task<List<Cita360DTO>> BuscarByCronograma(int idCronograma)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_BuscarByCronograma", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCronograma", idCronograma);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarByCronograma(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Cita360DTO> BuscarById(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_BuscarById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarById(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Cancelar(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Cancelar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCancelar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Pendiente(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Pendiente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadPendiente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Anular(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAnular(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Confirmar(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Confirmar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadConfirmar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<bool> ConfirmarAsistencia(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_ConfirmarAsistencia", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadConfirmarAsistencia(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> Atender(Cita360DTOAtender model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_Atender", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdUsuarioAtendidoPor", model.IdUsuarioAtendidoPor);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pNumeroBox", model.NumeroBox);
                cmd.Parameters.AddWithValue("pIdMaquinaMarca", model.IdMaquinaMarca);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAtender(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> NoLlamar(Cita360DTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita360_NoLlamar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.MensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.MensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.MensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadAnular(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        //****************************************************************** READERS

        static async Task<bool> ReadInsertar(DbDataReader reader)
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

        static async Task<List<Cita360DTO>> ReadBuscarByCronograma(DbDataReader reader)
        {
            try
            {
                List<Cita360DTO> collection = new List<Cita360DTO>();
                while (await reader.ReadAsync())
                {
                    Cita360DTO obj = new Cita360DTO();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.HoraInicio = Convert.ToString(reader["HoraInicio"]);
                    obj.HoraTermino = Convert.ToString(reader["HoraTermino"]);
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]);
                    obj.Detalles = new List<Cita360DetallesDTO>(JsonSerializer.Deserialize<List<Cita360DetallesDTO>>(Convert.ToString(reader["Detalles"])));
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<Cita360DTO> ReadBuscarById(DbDataReader reader)
        {
            try
            {
                Cita360DTO obj = new Cita360DTO();
                while (await reader.ReadAsync())
                {
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.HoraInicio = Convert.ToString(reader["HoraInicio"]);
                    obj.HoraTermino = Convert.ToString(reader["HoraTermino"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]);
                    obj.Detalles = new List<Cita360DetallesDTO>(JsonSerializer.Deserialize<List<Cita360DetallesDTO>>(Convert.ToString(reader["Detalles"])));
                    obj.NumeroBox = Convert.ToInt32(reader["NumeroBox"]);
                    obj.IdMaquinaMarca = DBNull.Value == reader["IdMaquinaMarca"] ? 0 : Convert.ToInt32(reader["IdMaquinaMarca"]);
                    obj.AtendidoPor = DBNull.Value == reader["AtendidoPor"] ? null : Convert.ToString(reader["AtendidoPor"]);



                    // secondary
                    obj.Maquina = Convert.ToString(reader["Maquina"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.TipoCita = Convert.ToString(reader["TipoCita"]);
                }

                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<bool> ReadCancelar(DbDataReader reader)
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

        static async Task<bool> ReadPendiente(DbDataReader reader)
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

        static async Task<bool> ReadAnular(DbDataReader reader)
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

        static async Task<bool> ReadConfirmar(DbDataReader reader)
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


        static async Task<bool> ReadConfirmarAsistencia(DbDataReader reader)
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

        static async Task<bool> ReadAtender(DbDataReader reader)
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
    }
}