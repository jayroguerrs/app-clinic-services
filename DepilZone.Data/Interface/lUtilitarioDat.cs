using System.Threading.Tasks;
namespace DepilZone.Data.Interface
{
    public interface IUtilitarioDat
    {
        Task<string> Encriptar(string text);
        Task<string> Desencriptar(string text);

    }
}
