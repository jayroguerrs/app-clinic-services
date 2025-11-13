using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class PosDTO
    {
        public IFormFile File { get; set; }
        public String TipRep { get; set; }
        public Int32 IdSede { get; set; }
        public Int32 IdUser { get; set; }
    }
}
