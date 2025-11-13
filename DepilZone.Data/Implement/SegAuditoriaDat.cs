using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class SegAuditoriaDat : ISegAuditoriaDat
    {
        private readonly string _connectionString;

        public SegAuditoriaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<bool> Insertar(SegAuditoriaDTO model)
        {
            Boolean flag = false;

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("sp_regaccionesactividades_aud", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("vi_idusuario", model.idusuario);
                cmd.Parameters.AddWithValue("vv_tipoopcion", model.tipo_opcion);
                cmd.Parameters.AddWithValue("vv_des_operacion", model.des_operacion);
                cmd.Parameters.AddWithValue("vv_des_nombreusuario", model.des_nombre_usuario);
                cmd.Parameters.AddWithValue("vv_des_nombremaquina", model.des_nombre_maquina);
                cmd.Parameters.AddWithValue("vv_des_usuariowindows", model.des_usuario_windows);
                cmd.Parameters.AddWithValue("vv_des_sistema", model.des_sistema);
                cmd.Parameters.AddWithValue("vv_des_usuariosistema", model.des_usuario_sistema);

                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    flag = true;
                }

                conn.Close();

                return flag;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
