using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class SegAuditoriaDTO
    {     
        public string num_correlativo { get; set; }
        public int? idusuario { get; set; }
        public string tipo_opcion { get; set; }
        public string des_operacion { get; set; }
        public string des_nombre_usuario { get; set; }
        public string des_nombre_maquina { get; set; }
        public string des_usuario_windows { get; set; }
        public string des_sistema { get; set; }
        public DateTime fec_fecha_server { get; set; }
        public string des_usuario_sistema { get; set; }
    }
}
