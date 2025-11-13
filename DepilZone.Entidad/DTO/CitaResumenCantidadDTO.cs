using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class DashBoardDTO
    {
        public string Mes { get; set; }
        public int Anio { get; set; }
        public int DiaInicioMes { get; set; }
        public int DiaTerminoMes { get; set; }

        public IList<DashboardElementosPermitidosDTO> ElementosPermitidos { get; set; }
        public CitaResumenCantidadDTO ResumenCantidad { get; set; }
        public IList<CitaUltimaAtendidadDTO> UltimasAtendidas { get; set; }
        public IList<CitaAtendidaSemanalDTO> CitasSemanal { get; set; }
        public IList<CitaAtendidaAnualDTO> CitasAnual { get; set; }
        public IList<CitaAtendidaMensualDTO> CitasMensual { get; set; }
        public IList<CitaAtendidaZonaCantidadDTO> CitasZonasAtendidas { get; set; }
    }

    public class DashboardElementosPermitidosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class CitaResumenCantidadDTO
    {
        public int CitasTotales { get; set; }
        public int CitasRegistradas { get; set; }
        public int CitasConfirmadas { get; set; }
        public int CitasAtendidas { get; set; }
        public int CitasCanceladas { get; set; }
        public int CitasAnuladas { get; set; }
        public int CitasReprogramadas { get; set; }

        public int CitasPendientes {
            get
            {
                return CitasRegistradas + CitasConfirmadas + CitasReprogramadas;
            }
        }

        public double PorcentajeTotal
        {
            get
            {
                return 100.00;
            }
        }
        public double PorcentajeCitasRealizadas
        {
            get
            {
                if (CitasPendientes + CitasCanceladas + CitasAtendidas != 0)
                {
                    return ((double)CitasAtendidas * 100) / (double)(CitasPendientes + CitasCanceladas + CitasAtendidas);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double PorcentajeCitasCanceladas
        {
            get
            {
                if (CitasPendientes + CitasCanceladas + CitasAtendidas != 0)
                {
                    return ((double)CitasCanceladas * 100) / (double)(CitasPendientes + CitasAtendidas + CitasCanceladas);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double PorcentajeCitasPendientes
        {
            get
            {
                return (100 - (PorcentajeCitasRealizadas + PorcentajeCitasCanceladas));
                //if (CitasPendientes + CitasCanceladas + CitasAtendidas != 0)
                //{
                //    return ((double)CitasPendientes * 100) / (double)(CitasCanceladas + CitasAtendidas + CitasPendientes);
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }

        //public IList<string> Porcentajes
        //{
        //    get
        //    {
        //        List<string> _porcentajes = new List<string>();
        //        _porcentajes.Add(PorcentajeCitasRealizadas.ToString("0.00"));
        //        _porcentajes.Add(PorcentajeCitasCanceladas.ToString("0.00"));
        //        PorcentajeCitasPendientes = 100 - (PorcentajeCitasRealizadas + PorcentajeCitasCanceladas);
        //        _porcentajes.Add(PorcentajeCitasPendientes.ToString("0.00"));
        //        return _porcentajes;
        //    }
        //}


    }
    public class CitaUltimaAtendidadDTO
    {
        public int IdCliente { get; set; }
        public string Foto { get; set;  }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string HoraInicio { get; set; }
    }
    public class CitaAtendidaSemanalDTO
    {
        public string Day { get; set; }
        public int Value { get; set; }
    }
    public class CitaAtendidaAnualDTO
    {
        public string Year { get; set; }
        public int Value { get; set; }
        public int Value2 { get; set; }
    }
    public class CitaAtendidaMensualDTO
    {
        public string Average { get; set; }
        public int Value { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string[] Color 
        {
            get 
            {
                string[] colores = { Color1, Color2 };
                return colores;
            }
        }
    }
    public class CitaAtendidaZonaCantidadDTO
    {
        public string ZonaCorporal { get; set; }
        public int Valor { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string[] Color
        {
            get
            {
                string[] colores = { Color1, Color2 };
                return colores;
            }
        }
    }
}
