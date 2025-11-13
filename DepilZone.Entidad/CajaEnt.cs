using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad
{
	public class CajaEnt
	{
        public int Id { get; set; }
        public string Descripcion { get; set; }
		public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistra { get; set; }
		public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }
        public int? IdUsuarioResponsable { get; set; }
        public bool AbrirCaja { get; set; }
        public string FechaHoraAperturaStr { get; set; }
        public string FechaHoraCierreStr { get; set; }
        public decimal SaldoInicial { get; set; }

        // secondary
        public DateTime? FechaHoraApertura { get; set; }
        public DateTime? FechaHoraCierre { get; set; }
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
        public string FechaCierre
        {
            get
            {
                string fechaCierre = "";
                if (FechaHoraCierre != null)
                {
                    fechaCierre = ((DateTime)FechaHoraCierre).ToString("dd-MM-yyyy");
                }
                return fechaCierre;
            }
        }
        public string Sede { get; set; }
        public string Apertura { get; set; }
        public string UsuarioResponsable { get; set; }
        public string UsuarioResponsableCierre { get; set; }
        public int IdUsuarioResponsableCierre { get; set; }
        public int Turno { get; set; }
    }
}
