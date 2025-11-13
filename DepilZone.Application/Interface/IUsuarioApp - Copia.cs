
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IUtilitarioApp
    {
        Task<string> Encriptar(string text);
        Task<string> Desencriptar(string text);

    }
}
