using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;
namespace DepilZone.Data.Interface
{
    public interface IEmailDom
    {
        Task<int> EnvioEmail(EmailEnvioDTO model);
        Task<bool> SendEmailAsync(EmailEnvioDTO model);

    }
}