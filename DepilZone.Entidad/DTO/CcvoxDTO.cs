using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class CcvoxDTO
    {
        public string celular1;
        public string celular2;
    }

    public class NumerosClienteDTO
    {
        public string Celular1;
        public string Celular2;
        public int IdCliente;
    }

    public class ResponseRedirect
    {
        public string TypeClient { get; set; }
        public string Redirect { get; set; }
        public string? Identificator { get; set; }
    }
}
