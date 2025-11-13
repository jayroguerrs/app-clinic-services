using System;
using System.Collections.Generic;

namespace DepilZone.Entidad.DTO
{
    public class EvolucionTratamientoDTO
    {
        public int Id { get; set; }
        public int IdCita { get; set; }

        public List<EvolucionTratamientoZonaDTO> Zonas { get;set; }

        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string? UsuarioModifico { get; set; }
        public string? UsuarioAtendio { get; set; }


        public int IdEstado { get; set; }

        // ALTERS
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int IdUsuarioAtendio { get; set; }

    }

    public class EvolucionTratamientoZonaDTO
    {
        public int Id { get; set; }
        public int IdEvolucionTratamiento { get; set; }
        public int IdCitaDetalle { get; set; }
        public int Sesion { get; set; }
        public int? PrototipoPiel { get; set; }

        public int? FototipoPiel { get; set; }

        public string? Zona { get; set; }

        public List<EvolucionTratamientoDosisDTO> Dosis { get; set; }

        public ET_EquipoLaserDTO? EquipoLaser { get; set; }

        public int? IdEquipoLaser { get; set; }

        public int Edema { get; set; }
        public int Eritema { get; set; }
        public int Dolor { get; set; }
        public int Agujas { get; set; }
        public int Quemaduras { get; set; }

        public string? Comentario { get; set; }
        public string? ComentarioCliente { get; set; }
        public string? ComentarioSesion { get; set; }
        public string? Foto1 { get; set; }
        public string? Foto2 { get; set; }

        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string? UsuarioModifico { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }


        public int IdEstado { get; set; }

        public bool HasEdit { get; set; }

    }

    public class EvolucionTratamientoDosisDTO
    {
        public int Id { get; set; }
        public int IdEvolucionTratamientoZona { get; set; }
        public int IdZona { get; set; }
        public string Zona { get; set; }
        public string? ValorJulios { get; set; }
        public string? ValorContinuo { get; set; }
        public string? ValorStackMovil { get; set; }
        public string? ValorStackFijo { get; set; }

    }

    public class ET_EquipoLaserDTO
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class ET_ZonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ET_ZonaFotosDTO
    {
        public string? Foto1 { get; set; }
        public string? Foto2 { get; set; }
    }

}
