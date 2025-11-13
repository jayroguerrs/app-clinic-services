using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IEmailDat
    {
        Task<int> EnvioEmail(EmailEnvioDTO model);
    }
}