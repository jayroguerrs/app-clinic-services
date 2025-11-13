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
    public class LibroReclamacionDat : ILibroReclamacionDat
    {
        private readonly string _connectionString;
        public LibroReclamacionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_LibroReclamacion_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaRegistro", model.FechaRegistro);
                cmd.Parameters.AddWithValue("pNombres", model.Nombres);
                cmd.Parameters.AddWithValue("pIdDepartamento", model.IdDepartamento);
                cmd.Parameters.AddWithValue("pIdProvincia", model.IdProvincia);
                cmd.Parameters.AddWithValue("pIdDistrito", model.IdDistrito);
                cmd.Parameters.AddWithValue("pDomicilio", model.Domicilio);
                cmd.Parameters.AddWithValue("pNumeroDocumento", model.NumeroDocumento);
                cmd.Parameters.AddWithValue("pTelefono", model.Telefono);
                cmd.Parameters.AddWithValue("pEmail", model.Email);
                cmd.Parameters.AddWithValue("pNombrePadres", model.NombrePadres);
                cmd.Parameters.AddWithValue("pTipoBien", model.TipoBien);
                cmd.Parameters.AddWithValue("pMontoReclamado", model.MontoReclamado);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pDetalle", model.Detalle);
                cmd.Parameters.AddWithValue("pPedido", model.Pedido);
                cmd.Parameters.AddWithValue("pTipoReclamacion", model.TipoReclamacion);
                cmd.Parameters.AddWithValue("pEstadoReclamacion", model.EstadoReclamacion);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pZonaCorporal", model.ZonaCorporal);
                var reader = await cmd.ExecuteReaderAsync();
                return await ReadItem(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<string>> ObtenerPlantilla(int idTabla) {
            using SqlConnection conn = GetConnection();
            await conn.OpenAsync();
            using SqlCommand cmd = new SqlCommand("SP_PlantillaHTML_Consultar", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("pIdTabla", idTabla);
            var reader = await cmd.ExecuteReaderAsync();

            Respuesta<string> obj = new Respuesta<string>
            {
                Response = Convert.ToString(reader["Descripcion"])
            };
            return obj;
        }
        static async Task<Respuesta<LibroReclamacionDTO>> ReadItem(DbDataReader reader)
        {
            Respuesta<LibroReclamacionDTO> obj = new Respuesta<LibroReclamacionDTO>
            {
                Response = new LibroReclamacionDTO()
            };
            while (await reader.ReadAsync())
            {
                obj.Exito = Convert.ToBoolean(reader["Exito"]);
                obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                obj.ErrorDetalle = Convert.ToString(reader["ErrorDetalle"]);
                obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                if (obj.Exito)
                {
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    obj.Response.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.Response.Nombres = reader["Nombres"].ToString();
                    obj.Response.Departamento = Convert.ToString(reader["Departamento"]);
                    obj.Response.Provincia = Convert.ToString(reader["Provincia"]);
                    obj.Response.Distrito = Convert.ToString(reader["Distrito"]);
                    obj.Response.Domicilio = Convert.ToString(reader["Domicilio"]);
                    obj.Response.NumeroDocumento = reader["NumeroDocumento"].ToString();
                    obj.Response.Telefono = reader["Telefono"].ToString();
                    obj.Response.Email = reader["Email"].ToString();
                    obj.Response.NombrePadres = reader["NombrePadres"].ToString();
                    obj.Response.Tipo = Convert.ToString(reader["Tipo"]);
                    obj.Response.Detalle = reader["Detalle"].ToString();
                    obj.Response.Pedido = reader["Pedido"].ToString();
                    obj.Response.TipoReclamo = Convert.ToString(reader["TipoReclamo"]);
                    obj.Response.MontoReclamado = Convert.ToDecimal(reader["MontoReclamado"]);
                    obj.Response.EstadoReclamacion = Convert.ToInt32(reader["EstadoReclamacion"]);
                    obj.Response.EmailCC = reader["EmailCC"].ToString();
                }
            }
            return obj;
        }
    }
}
