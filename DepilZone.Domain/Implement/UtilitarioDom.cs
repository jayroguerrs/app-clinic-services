using DepilZone.Data.Interface;
using System.Threading.Tasks;

namespace DepilZone.Domain
{
    public class UtilitarioDom: IUtilitarioDom
    {

        private readonly IUtilitarioDat _IUtilitarioDat;
        public UtilitarioDom(IUtilitarioDat IUtilitarioDat)
        {
            this._IUtilitarioDat = IUtilitarioDat;
        }

        public async Task<string> Encriptar(string text)
        {
            return await this._IUtilitarioDat.Encriptar(text);
        }
        public async Task<string> Desencriptar(string text)
        {
            return await this._IUtilitarioDat.Desencriptar(text);
        }
    }
}
