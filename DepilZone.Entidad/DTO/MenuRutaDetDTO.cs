using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class MenuRutaDetDTO
    {
        public int Id { get; set; }
        public int IdMenu { get; set; }
        public string Proceso { get; set; }        
        public string Metodo { get; set; }                
        public string Estado { get; set; }
        public string CodMenu { get; set; }
    }
    public class MenuPrivilegioDetDTO
    {
        public int Id { get; set; }
        public List<int> Privilegios { get; set; } = new List<int>();
        public string Ruta { get; set; }
    }
}
