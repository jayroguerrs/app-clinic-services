using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement
{
	public class EmpresaApp : IEmpresaApp
	{
        private readonly IEmpresaDom _IEmpresaDom;
        public EmpresaApp(IEmpresaDom IEmpresaDom)
        {
            this._IEmpresaDom = IEmpresaDom;
        }

        public async Task<IEnumerable<EmpresaEnt>> Obtener()
        {
            return await _IEmpresaDom.Obtener();
        }
        public async Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita)
        {
            try
            {
                EmpresaEmisionTicketDTO output = await _IEmpresaDom.ObtenerEmpresaEmisionTicketByCita(idCita);

                if (output.SunatUrlPdf != null) {
                    using (WebClient client = new WebClient())
                    {
                        var bytes = client.DownloadData(output.SunatUrlPdf);
                        output.BoletaPdfBase64 = Convert.ToBase64String(bytes);
                    }
                
                }

                

                return output;
            }
            catch (Exception ex )
            {

                throw ex;
            }
            
        }
    }
}
