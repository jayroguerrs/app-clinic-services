using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
    public class ClienteEnt
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Seudonimo { get; set; }
        public int? IdGenero { get; set; }
        public string Celular1 { get; set; }
        public int PaisCelular1 { get; set; }
        public string Celular2 { get; set; }
        public int PaisCelular2 { get; set; }
        public string Correo { get; set; }
        public int? IdDocumentoIdentidadTipo { get; set; }
        public string Documento { get; set; }
        public int? IdEstadoCivil { get; set; }
        public string IdUbicacion { get; set; }
        public string Direccion { get; set; }
        public string Profesion { get; set; }
        public int? IdComunicacionCliente { get; set; }


        public string Publicidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public string SerieFirma { get; set; }
        public string SerieHuella { get; set; }

        public int? IdMedioContacto { get; set; }
        public string OtroMedioContacto { get; set; }
        public string Foto { get; set; }
        public string IdHistoriaClinica { get; set; }
        public int idClinic1 { get; set; }
        public bool esAdmitido { get; set; }

        public decimal? Peso { get; set; }
        public decimal? Altura { get; set; }
        public int? NumHijos { get; set; }

        public int IdPreferente { get; set; }

        public int IdEspecialista { get; set; }
        public string? Especialista { get; set; }
        public string? ruc{ get; set; }
        public string? razonSocial { get; set; }

    }
}
