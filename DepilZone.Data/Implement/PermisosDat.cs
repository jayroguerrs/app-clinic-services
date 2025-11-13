using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PermisosDat : IPermisosDat
    {
        private readonly string _connectionString;

        public PermisosDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<ResponsePermisoDTO>> ObtenerPermisosPorId(int id, string permiso)
        {
            var permisos = new List<ResponsePermisoDTO>();

            using (var conn = GetConnection())
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("SP_PermisosUsuarios_ById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pId", id);
                    cmd.Parameters.AddWithValue("@vv_permisos", permiso);

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (dr.Read()) {
                            ResponsePermisoDTO mod = new ResponsePermisoDTO();
                            
                            mod.Res = dr["Res"].ToString();   
                            mod.Msg = dr["Msg"].ToString();                            
                            permisos.Add(mod);
                        }
                    }   
                }
            }

            return permisos;
        }

    }
}
