using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PerfilDat: IPerfilDat
    {
        private readonly string _connectionString;
        public PerfilDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<PerfilEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Perfil_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Perfil_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemDTO(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Perfil_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", perfil.Nombre);
                cmd.Parameters.AddWithValue("pPerfilDetalle", JsonSerializer.Serialize(perfil.PerfilDetalle));
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

        public async Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Perfil_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPerfil", perfil.IdPerfil);
                cmd.Parameters.AddWithValue("pNombre", perfil.Nombre);
                cmd.Parameters.AddWithValue("pPerfilDetalle", JsonSerializer.Serialize(perfil.PerfilDetalle));
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

        // READERS

        static async Task<IEnumerable<PerfilEnt>> ReadItemsListado(DbDataReader reader)
        {
            try
            {
                IList<PerfilEnt> lista = new List<PerfilEnt>();
                while (await reader.ReadAsync())
                {
                    PerfilEnt obj = new PerfilEnt
                    {
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        Nombre = reader["Nombre"].ToString()
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
        static async Task<Respuesta<PerfilEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PerfilEnt> obj = new Respuesta<PerfilEnt>
                {
                    Response = new PerfilEnt()
                };

                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        obj.Response.Nombre = reader["Nombre"].ToString();
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PerfilConfiguracionDTO> ReadItemDTO(DbDataReader reader)
        {
            try
            {
                PerfilConfiguracionDTO perfilOpciones = new PerfilConfiguracionDTO();
                perfilOpciones.Detalle = new List<PerfilDetalleDTO>();

                while (await reader.ReadAsync())
                {
                    perfilOpciones.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    perfilOpciones.Nombre = reader["Nombre"].ToString();
                }


                //Menus
                if (reader.NextResult())
                {
                    perfilOpciones.Menus = new List<MenuDTO>();
                    while (await reader.ReadAsync())
                    {
                        perfilOpciones.Menus.Add(new MenuDTO
                        {
                            Id = reader["Id"].ToString(),
                            IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                            Title = reader["Title"].ToString(),
                            Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                            Url = reader["Url"].ToString(),
                            Type = reader["Type"].ToString(),
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Seleccionado = Convert.ToBoolean(reader["Seleccionado"])
                        });

                        if (Convert.ToBoolean(reader["Seleccionado"]))
                        {
                            perfilOpciones.Detalle.Add(new PerfilDetalleDTO
                            {
                                Id = 0,
                                IdPerfil = perfilOpciones.IdPerfil,
                                IdElemento = Convert.ToInt32(reader["IdMenu"]),
                                IdTipoElemento = 1
                            });
                        }
                    }
                    perfilOpciones.Menus = OrdenarMenuPadreHijos(perfilOpciones.Menus.ToList(), null);
                }

                //Dashboard elementos
                if (reader.NextResult())
                {
                    perfilOpciones.DashboardElementos = new List<DashboardElementoDTO>();
                    while (await reader.ReadAsync())
                    {
                        perfilOpciones.DashboardElementos.Add(new DashboardElementoDTO
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Descripcion = Convert.ToString(reader["Descripcion"]),
                            Seleccionado = Convert.ToBoolean(reader["Seleccionado"])
                        });

                        if (Convert.ToBoolean(reader["Seleccionado"]))
                        {
                            perfilOpciones.Detalle.Add(new PerfilDetalleDTO
                            {
                                Id = 0,
                                IdPerfil = perfilOpciones.IdPerfil,
                                IdElemento = Convert.ToInt32(reader["Id"]),
                                IdTipoElemento = 2
                            });
                        }
                    }
                }



                return perfilOpciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static IList<MenuDTO> OrdenarMenuPadreHijos(List<MenuDTO> Menus, int? IdPadre)
        {
            try
            {
                List<MenuDTO> MenuResultado = new List<MenuDTO>();

                //obtener los datos del nivel indicado
                List<MenuDTO> menuNivel = Menus.Where(x => x.IdPadre == IdPadre).ToList();
                foreach (MenuDTO menu in menuNivel)
                {
                    MenuDTO menuDto = new MenuDTO
                    {
                        Id = menu.Id,
                        Title = menu.Title,
                        IdPadre = menu.IdPadre,
                        Type = menu.Type,
                        Url = menu.Url,
                        Icon = menu.Icon,
                        IdMenu = menu.IdMenu,
                        Nivel = menu.Nivel,
                        Seleccionado = menu.Seleccionado,
                        Children = OrdenarMenuPadreHijos(Menus, menu.IdMenu)
                    };
                    MenuResultado.Add(menuDto);
                }

                return MenuResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
