using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteConsultaDniDTO
    {
        public string _token { get; set; }
        public string dni { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public double TiempoProcesamiento { get; set; }
        public string Respuesta { get; set; }
    }

    public class ClienteConsultaTelefonoDTO
    {
        public string _token { get; set; }
        public string numero { get; set; }
        public string operador { get; set; }

        public string reCaptchaToken { get; set; }
    }

    public class RClienteConsultaTelefonoDTO
    {
        public string Numero { get; set; }
        public string operador { get; set; }
        public string fechaConsulta { get; set; }
    }
}
