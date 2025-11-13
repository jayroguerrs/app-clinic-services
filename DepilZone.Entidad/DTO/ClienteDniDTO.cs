using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DepilZone.Entidad.DTO
{
    public class ClienteDniDTO
    {

        [JsonPropertyName("data")]
        public dataDni data { get; set; }

    }

    public class dataDni
    {
        [JsonPropertyName("numero")]
        public string dni { get; set; }
        [JsonPropertyName("nombre_completo")]
        public string nombreCompleto { get; set; }
        [JsonPropertyName("nombres")]
        public string nombres { get; set; }

        [JsonPropertyName("apellido_paterno")]
        public string apellidoPaterno { get; set; }

        [JsonPropertyName("apellido_materno")]
        public string apellidoMaterno { get; set; }

   

    }
}
