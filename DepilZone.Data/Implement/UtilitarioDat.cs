using DepilZone.Data.Interface;
using System;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class UtilitarioDat : IUtilitarioDat
    {
        public async Task<string> Encriptar(string text)
        {
            try
            {
                return DBConn.EncryptString(text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Desencriptar(string text)
        {
            try
            {
                return DBConn.DecryptString(text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 

}
