using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DepilZone.Entidad.DTO
{
    public class ClienteRucDTO
    {
        [JsonPropertyName("data")]
        public dataRuc data { get; set; }
        
    }
    public class dataRuc {
        [JsonPropertyName("ruc")]
        public string ClienteRuc { get; set; }
        [JsonPropertyName("nombre_o_razon_social")]
        public string RazonSocial { get; set; }

    }
}
