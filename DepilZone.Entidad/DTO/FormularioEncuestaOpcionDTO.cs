using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Entidad.DTO
{
    public class FormularioEncuestaOpcionDTO
    {
        public int Id { get; set; }
        public int IdFormularioPregunta { get; set; }
        public string Valor { get; set; }
        public bool Adicional { get; set; }
        public string? PlaceholderAdicional { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int Orden { get; set; }
        public int IdEstado { get; set; }

        public int Contador { get; set; }

    }
}
