using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class MaquinaSedeDat : IMaquinaSedeDat
    {
        private readonly string _connectionString;
        public MaquinaSedeDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> Obtener(int idEstado)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsGrilla(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerByNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
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
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerBySede", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdSede", IdSede);
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
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string Nombre, int IdSede)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerByFiltros", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                Nombre = Nombre == "null" ? null : Nombre;

                cmd.Parameters.AddWithValue("Nombre", Nombre);
                cmd.Parameters.AddWithValue("IdSede", IdSede);
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

        public async Task<MaquinaSedeEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<MaquinaSedeEnt>> Insertar(MaquinaSedeEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("IdSede", model.IdSede);
                cmd.Parameters.AddWithValue("HoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("HoraFin", model.HoraFin);
                cmd.Parameters.AddWithValue("Descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdFicticio", model.IdFicticio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<MaquinaSedeEnt>> Modificar(MaquinaSedeEnt model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdFicticio", model.IdFicticio);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraFin", model.HoraFin);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarPorSedeyServicio(int idUsuario, int idSede, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerBySedeByServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarPorSedeyServicio(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MaquinaSedeGridDTO>> BuscarFicticios(int idUsuario, int idSede, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_MaquinaSede_ObtenerFicticios", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarFicticios(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<MaquinaSedeEnt> Read(DbDataReader reader)
        {
            try
            {
                MaquinaSedeEnt obj = new MaquinaSedeEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdFicticio = Convert.ToInt32(reader["IdFicticio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.HoraInicio = reader["HoraInicio"].ToString();
                    obj.HoraFin = reader["HoraFin"].ToString();
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<MaquinaSedeEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<MaquinaSedeEnt> obj = new Respuesta<MaquinaSedeEnt>
                {
                    Response = new MaquinaSedeEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.Id = Convert.ToInt32(reader["Id"]);
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        static async Task<IEnumerable<MaquinaSedeGridDTO>> ReadItemsGrilla(DbDataReader reader)
        {
            try
            {
                IList<MaquinaSedeGridDTO> lista = new List<MaquinaSedeGridDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSedeGridDTO obj = new MaquinaSedeGridDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraFin = reader["HoraFin"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Maquina = reader["Maquina"].ToString(),
                        Sede = reader["Sede"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdFicticio = Convert.ToInt32(reader["IdFicticio"]),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Color = Convert.ToString(reader["Color"]),
                        IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        Tecnologias = new List<TecnologiaSDTO>(JsonSerializer.Deserialize<List<TecnologiaSDTO>>(Convert.ToString(reader["Tecnologias"]))),
                        Perfiles = new List<MaquinaSedePerfilDTO>(JsonSerializer.Deserialize<List<MaquinaSedePerfilDTO>>(Convert.ToString(reader["Perfiles"]))),
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

        static async Task<IEnumerable<MaquinaSedeGridDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<MaquinaSedeGridDTO> lista = new List<MaquinaSedeGridDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSedeGridDTO obj = new MaquinaSedeGridDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraFin = reader["HoraFin"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        Sede = reader["Sede"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdSede = Convert.ToInt32(reader["IdSede"])
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


        static async Task<List<MaquinaSedeGridDTO>> ReadBuscarPorSedeyServicio(DbDataReader reader)
        {
            try
            {
                List<MaquinaSedeGridDTO> collection = new List<MaquinaSedeGridDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSedeGridDTO obj = new MaquinaSedeGridDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdFicticio = Convert.ToInt32(reader["IdFicticio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.Maquina = Convert.ToString(reader["Maquina"]);
                    obj.HoraInicio = reader["HoraInicio"].ToString();
                    obj.HoraFin = reader["HoraFin"].ToString();
                    obj.Color = Convert.ToString(reader["Color"]);
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<MaquinaSedeGridDTO>> ReadBuscarFicticios(DbDataReader reader)
        {
            try
            {
                List<MaquinaSedeGridDTO> collection = new List<MaquinaSedeGridDTO>();
                while (await reader.ReadAsync())
                {
                    MaquinaSedeGridDTO obj = new MaquinaSedeGridDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdFicticio = Convert.ToInt32(reader["IdFicticio"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    obj.Maquina = Convert.ToString(reader["Maquina"]);
                    obj.HoraInicio = reader["HoraInicio"].ToString();
                    obj.HoraFin = reader["HoraFin"].ToString();
                    obj.IdServicio = DBNull.Value == reader["IdServicio"] ? (int?)null : Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = DBNull.Value == reader["Servicio"] ? null : Convert.ToString(reader["Servicio"]);
                    obj.ServicioColor = DBNull.Value == reader["ServicioColor"] ? null : Convert.ToString(reader["ServicioColor"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}