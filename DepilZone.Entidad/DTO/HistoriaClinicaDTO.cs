using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DepilZone.Entidad.DTO
{
    public class HistoriaClinicaDTO
    {
        public int? Id { get; set; }
        public int IdCliente { get; set; }
        
        public DateTime FechaHistoria { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }

        // OUTPUT
        [AllowNull]
        public int? IdFichaAdmision { get; set; }
        [AllowNull]
        public string? NombreCompleto { get; set; }
        [AllowNull]
        public string? Telefono { get; set; }
        [AllowNull]
        public string? Domicilio { get; set; }
        [AllowNull]
        public int? Edad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [AllowNull]
        public string? EstadoCivil { get; set; }
        [AllowNull]
        public string? FototipoPiel { get; set; }
        [AllowNull]
        public string? Documento { get; set; }
        [AllowNull]
        public string? TipoDocumento { get; set; }
        [AllowNull]
        public string? Profesion { get; set; }
        [AllowNull]
        public string? Email { get; set; }

        public List<HC_Patologia> Patologias { get; set; }

        public List<HC_Zonas> ZonasConsultar { get; set; }
        public List<HC_Zonas> ZonasRealizar { get; set; }


        [AllowNull]
        public string? AlergiasMedicamentosas { get; set; }
        [AllowNull]
        public string? AntPerMedicos { get; set; }
        [AllowNull]
        public string? AntPerQuirurgicos { get; set; }
        [AllowNull]
        public string? AntTratFarmacologicos { get; set; }
        [AllowNull]
        public string? AntTratEstPrev { get; set; }

        [AllowNull]
        public decimal? Peso { get; set; }
        [AllowNull]
        public decimal? Altura { get; set; }
        [AllowNull]
        public int? NumeroHijos { get; set; }

        [AllowNull]
        public int? TipoCicatrizacion { get; set; }

        [AllowNull]
        public int? BebeAlcohol { get; set; }
        [AllowNull]
        public int? EsFumador { get; set; }

        [AllowNull]
        public int? TieneMedicacion { get; set; }
        [AllowNull]
        public string? IndiqueMedicacion { get; set; }

        [AllowNull]
        public string? Observaciones { get; set; }

        [AllowNull]
        public string UsuarioRegistro { get; set; }
        [AllowNull]
        public string UsuarioModifico { get; set; }
        [AllowNull]
        public int? ComunicacionCliente { get; set; }
        [AllowNull]
        public string? Ultimos12meses { get; set; }
        [AllowNull]
        public string? AntecedenteFamiliar { get; set; }
        [AllowNull]
        public string? ReaccionAlergicaCutanea { get; set; }
        [AllowNull]
        public int? EmbarazoSospecha { get; set; }
        [AllowNull]
        public int? CigarrosAldia { get; set; }
        [AllowNull]
        public int? IdMedioContacto { get; set; }
        [AllowNull]
        public string? Genero { get; set; }

        public int IdEstado { get; set; }

    }


    public class HC_Patologia
    {
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class HC_Zonas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
