using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class MenuDat : IMenuDat
    {
        private readonly string _connectionString;
        public MenuDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Menu_ObtenerParaMenu", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
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

        // READERS

        static async Task<IEnumerable<MenuDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                List<MenuDTO> lista = new List<MenuDTO>();
                while (await reader.ReadAsync())
                {
                    MenuDTO obj = new MenuDTO
                    {
                        IdMenu = Convert.ToInt32(reader["IdMenu"]),
                        IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                        Title = reader["Title"].ToString(),
                        IdMenuTipo = reader["IdMenuTipo"].ToString(),
                        Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                        Url = reader["Url"].ToString(),
                        Id = reader["Id"].ToString(),
                        Visible = Convert.ToBoolean(reader["Visible"]),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Type = reader["Type"].ToString()

                    };
                    lista.Add(obj);
                }
                IList<MenuDTO> resultado = OrdenarMenuPadreHijos(lista, null);



                return resultado;
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
