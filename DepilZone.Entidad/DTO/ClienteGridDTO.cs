using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ClienteGridDTO
    {
        public int Id { get; set; }
        public string NombresCompletos 
        { 
            get 
            {
                return Nombres + " " + Apellidos;
            }  
        }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Seudonimo { get; set; }
        public int? IdGenero { get; set; }
        public string Genero { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string MedioContacto { get; set; }
        public string Publicidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad
        {
            get 
            {
                if (FechaNacimiento == null)
                {
                    return 0;
                }
                else
                {
                    DateTime fechaNacimientoTemp = (DateTime)FechaNacimiento;
                    DateTime fechaActual = DateTime.Today;
                    if (fechaNacimientoTemp > fechaActual)
                    {
                        return 0;
                    }
                    else
                    {
                        int edad = fechaActual.Year - fechaNacimientoTemp.Year;
                        return (fechaNacimientoTemp.Month > fechaActual.Month) ? --edad : edad;
                    }
                }
              
            }
        }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
        public string SerieFirma { get; set; }
        public string SerieHuella { get; set; }
        public int? IdDocumentoIdentidadTipo { get; set; }
        public string DocumentoIdentidadTipo { get; set; }
        public string Documento { get; set; }
        public string IdUbicacion { get; set; }
        public string IdHistoriaClinica { get; set; }
    }
}
