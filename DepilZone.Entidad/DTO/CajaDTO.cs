using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CajaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public int IdEstado { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Apertura { get; set; }
        public bool AbrirCaja { get; set; }
        public string FechaHoraAperturaStr { get; set; }
        public DateTime? FechaHoraApertura { get; set; }
        public string FechaApertura
        {
            get
            {
                string fechaApertura = "";
                if (FechaHoraApertura != null)
                {
                    fechaApertura = ((DateTime)FechaHoraApertura).ToString("dd-MM-yyyy");
                }
                return fechaApertura;
            }
        }
        public int IdUsuarioResponsable { get; set; }

        public string UsuarioResponsable { get; set; } 
    }
}
