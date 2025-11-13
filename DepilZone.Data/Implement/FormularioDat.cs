using DepilZone.Data.Helpers;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class FormularioDat : IFormularioDat
    {
        private readonly string _connectionString;

        public FormularioDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<TipoClienteDTO>> ObtenerTipoCliente(int idUsuario)
        {
            List<TipoClienteDTO> list = new List<TipoClienteDTO>();
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_TipoCliente_Form", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Agrega el parámetro de entrada
                cmd.Parameters.AddWithValue("@vi_IdUsuario", idUsuario);

                // Ejecuta la consulta y obtiene el reader
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                list = await ReadTipoCliente(reader);
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico para excepciones de SQL
                // Puedes registrar sqlEx aquí o lanzar una nueva excepción
                throw new Exception("Error al obtener tipos de cliente.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                throw new Exception("Error inesperado al obtener tipos de cliente.", ex);
            }

            return list;
        }

        static async Task<List<TipoClienteDTO>> ReadTipoCliente(DbDataReader reader)
        {
            List<TipoClienteDTO> list = new List<TipoClienteDTO>();

            while (await reader.ReadAsync())
            {
                var obj = new TipoClienteDTO
                {
                    Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                    TipoCliente = reader["TipoCliente"] != DBNull.Value ? reader["TipoCliente"].ToString() : string.Empty
                };
                list.Add(obj);
            }

            return list;
        }

        public async Task<IEnumerable<PromocionFormDTO>> ObtenerPromocion(int idUsuario)
        {
            List<PromocionFormDTO> list = new List<PromocionFormDTO>();
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_PromocionesByMes_Form", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Agrega el parámetro de entrada
                cmd.Parameters.AddWithValue("@vi_IdUsuario", idUsuario);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                list = await ReadPromociones(reader);
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico para excepciones de SQL
                throw new Exception("Error al obtener promociones.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                throw new Exception("Error inesperado al obtener promociones.", ex);
            }

            return list;
        }

        static async Task<List<PromocionFormDTO>> ReadPromociones(DbDataReader reader)
        {
            List<PromocionFormDTO> list = new List<PromocionFormDTO>();

            while (await reader.ReadAsync())
            {
                var obj = new PromocionFormDTO
                {
                    IdPromocion = reader["IdPromocion"] != DBNull.Value ? Convert.ToInt32(reader["IdPromocion"]) : 0,
                    Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty
                };
                list.Add(obj);
            }

            return list;
        }

        public async Task<IEnumerable<ServicioPromocionDTO>> ObtenerServiciosPorPromocion(int idPromocion, int idUsuario)
        {
            List<ServicioPromocionDTO> list = new List<ServicioPromocionDTO>();
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_ServicioByProm_Form", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Agrega los parámetros de entrada
                cmd.Parameters.AddWithValue("@vi_IdPromocion", idPromocion);
                cmd.Parameters.AddWithValue("@vi_IdUsuario", idUsuario);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                list = await ReadServicios(reader);
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico para excepciones de SQL
                throw new Exception("Error al obtener servicios por promoción.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                throw new Exception("Error inesperado al obtener servicios por promoción.", ex);
            }

            return list;
        }

        static async Task<List<ServicioPromocionDTO>> ReadServicios(DbDataReader reader)
        {
            List<ServicioPromocionDTO> list = new List<ServicioPromocionDTO>();

            while (await reader.ReadAsync())
            {
                var obj = new ServicioPromocionDTO
                {
                    Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                    Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty
                };
                list.Add(obj);
            }

            return list;
        }

        public async Task<bool> RegistrarVenta(FormDTO formDTO)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_registrarVentas_DriveVentas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Agrega los parámetros de entrada del DTO
                cmd.Parameters.AddWithValue("@vi_IdTeleoperadora", formDTO.IdTeleoperadora);
                cmd.Parameters.AddWithValue("@vc_Nombre_Cliente", formDTO.NombreCliente);
                cmd.Parameters.AddWithValue("@vc_Dnicliente", formDTO.DocCliente);
                string formato = "yyyy-MM-dd";
                DateTime fechaCita;
                if (DateTime.TryParseExact(formDTO.FechaCita, formato, null, System.Globalization.DateTimeStyles.None, out fechaCita))
                {
                    cmd.Parameters.AddWithValue("@dt_Fechacita", fechaCita);
                }
                else
                {
                    throw new FormatException("El formato de la fecha es inválido.");
                }
                cmd.Parameters.AddWithValue("@vi_Tipocliente", formDTO.IdTipoCliente);
                cmd.Parameters.AddWithValue("@vi_Origen", formDTO.IdOrigen);
                cmd.Parameters.AddWithValue("@vi_Servicio", (formDTO.IdServiciosPorPromocion == null) ? 0 : formDTO.IdServiciosPorPromocion);
                cmd.Parameters.AddWithValue("@vi_IdPromociones", formDTO.IdPromociones);
                cmd.Parameters.AddWithValue("@vi_idsede", formDTO.IdSede);
                cmd.Parameters.AddWithValue("@vc_Nroorigen", formDTO.NroOrigen);
                cmd.Parameters.AddWithValue("@vc_Observaciones", formDTO.Observaciones);
                cmd.Parameters.AddWithValue("@vi_IdUsuario", formDTO.IdUsuario);

                // Ejecuta el comando
                await cmd.ExecuteNonQueryAsync();

                return true; // Devuelve true si la inserción fue exitosa
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico para excepciones de SQL
                throw new Exception("Error al registrar la venta.", sqlEx);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                throw new Exception("Error inesperado al registrar la venta.", ex);
            }
        }

        public async Task<List<Dictionary<string, object>>> ReporteVenta(FilterFormDTO filterDTO)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_registrarVentas_DriveVentas_exp", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FechaDesde", filterDTO.FechaDesde);
                cmd.Parameters.AddWithValue("@FechaHasta", filterDTO.FechaHasta);
                cmd.Parameters.AddWithValue("@vi_IdTeleoperadora", filterDTO.IdTeleoperadora.HasValue ? (object)filterDTO.IdTeleoperadora.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@vi_idsede", filterDTO.IdSede.HasValue ? (object)filterDTO.IdSede.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@vi_IdUsuario", filterDTO.IdUsuario);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                
                var result = await reader.ToDictionaryListAsync();
                return result;
            }
            catch (SqlException sqlEx)
            {                
                throw new Exception("Error al obtener reportes de venta.", sqlEx);
            }
            catch (Exception ex)
            {                
                throw new Exception("Error inesperado al obtener reportes de venta.", ex);
            }
        }
    }
}
