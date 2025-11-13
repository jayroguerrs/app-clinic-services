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
	public class CitaSeguimientoDat : ICitaSeguimientoDat
	{
        private readonly string _connectionString;

        public CitaSeguimientoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaSeguimiento_ObtenerGridByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaSeguimiento_ObtenerGridByCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaSeguimiento_ObtenerGridByClientePorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<CitaSeguimientoEnt> ObtenerById(int Id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaSeguimiento_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Respuesta<CitaSeguimientoEnt>> Insertar(CitaSeguimientoEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_CitaSeguimiento_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //cmd.Parameters.AddWithValue("IdSeguimientoCita", model.IdSeguimientoCita);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                cmd.Parameters.AddWithValue("Fecha", model.Fecha);
                cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
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
  

        // READERS

        static async Task<IEnumerable<CitaSeguimientoDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaSeguimientoDTO> lista = new List<CitaSeguimientoDTO>();
                while (await reader.ReadAsync())
                {
                    CitaSeguimientoDTO obj = new CitaSeguimientoDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Usuario = reader["Nombre"].ToString(),
                        FechaSeguimiento = Convert.ToDateTime(reader["FechaHora"].ToString()),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Detalle = reader["Detalle"].ToString()
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

        static async Task<CitaSeguimientoEnt> Read(DbDataReader reader)
        {
            try
            {
                CitaSeguimientoEnt obj = new CitaSeguimientoEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdSeguimientoCita = Convert.ToInt32(reader["IdSeguimientoCita"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Fecha = Convert.ToString(reader["Fecha"]);
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<Respuesta<CitaSeguimientoEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaSeguimientoEnt> obj = new Respuesta<CitaSeguimientoEnt>
                {
                    Response = new CitaSeguimientoEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdSeguimientoCita = Convert.ToInt32(reader["IdSeguimientoCita"]);
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Fecha = Convert.ToString(reader["Fecha"]);
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }

}
