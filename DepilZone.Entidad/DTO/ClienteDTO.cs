using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string IdTexto
        {
            get
            {
                return Id.ToString("000000");
            }
        }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Seudonimo { get; set; }
        public int? IdGenero { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Correo { get; set; }
        public int? IdDocumentoIdentidadTipo { get; set; }
        public string Documento { get; set; }
        public string IdUbicacion { get; set; }

        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string MedioContacto { get; set; }
        public string Publicidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public string SerieFirma { get; set; }
        public string SerieHuella { get; set; }
        public string IdHistoriaClinica { get; set; }

        public int Incidencias { get; set; }
        public int NumCitas { get; set; }
        public int NumCitasDepilacion { get; set; }
        public int NumCitasBlanqueamiento { get; set; }
        public int NumCitasTratamientoFacial { get; set; }
        public int NumCitasCorporalHollywood { get; set; }
        public int NumCitasExfoliacion { get; set; }
        public int NumCitasDermatologia { get; set; }
        public int NumCitasCorporal { get; set; }
        public int NumCitasHollywood { get; set; }

        public int NumZonas { get; set; }
        public int Edad {
            get {
                if(FechaNacimiento == null) 
                {
                    return 0;
                } 
                else 
                {
                    DateTime fechaActual = DateTime.Today;
                    DateTime fechaNacimiento = (DateTime)FechaNacimiento;
                    if (fechaNacimiento > fechaActual)
                    {
                        return 0;
                    }
                    else
                    {
                        int edad = fechaActual.Year - fechaNacimiento.Year;
                        return (fechaNacimiento.Month > fechaActual.Month) ? --edad : edad;
                    }
                }
            }
        }

        public int IdMedioContacto { get; set; }
        public string OtroMedioContacto { get; set; }
        public string Foto { get; set; }

        public string? Genero { get; set; }

        public IList<CitaMensajeNotaEnt> CitaNotas { get; set; }

        public OClientedDocumentoDTO ClienteDocumento { get; set; }

        public DateTime FechaEncuesta { get; set; }
        public string Encuesta { get; set; }
        public int PaisCelular1 { get; set; }
        public int? PaisCelular2 { get; set; }


        public int IdEspecialista { get; set; }
        public string? Especialista { get; set; }


        public int? IdUsuarioModifico { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
    }

    public class OClientedDocumentoDTO
    {
        public int? Id { get; set; }
        public string? Documento { get; set; }
        public string? TipoDocumento { get; set; }
    }

    public class ClienteAccesoDTO
    {
        public int IdCliente { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? IdUsuarioModifico { get; set; }

        public bool Registrado { get; set; }

        // secondary
        public string? UsuarioModifico { get; set; }
    }



    public class ClienteNuevoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? TipoCliente { get; set; }
        public string? Genero { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Documento { get; set; }
        public string? MedioContacto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Distrito { get; set; }
    }


}
