using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class EmpleadoDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string value
        {
            get
            {
                return IdUsuario.ToString();
            }
        }
        public string label
        {
            get
            {
                return $"{Nombre} | {Usuario}";
            }
        }
    }
}
