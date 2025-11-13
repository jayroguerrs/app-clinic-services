using DepilZone.Data.Interface.Test;
using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.Test;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement.Test
{
    public class ParameterSystemDat : IParameterSystemDat
    {
        private readonly string _connectionString;

        public ParameterSystemDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<ParameterSystemResponseDTO> Create(ParameterSystemDTO model)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();

            using var command = new SqlCommand("SP_ParametroSistema_Test", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@pId", model.Id);

            var outputValueParameter = new SqlParameter("@pValor", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputValueParameter);

            var outputMsgParameter = new SqlParameter("@pMsg", SqlDbType.NVarChar, 1000)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputMsgParameter);

            await command.ExecuteNonQueryAsync();

            var value = (int)outputValueParameter.Value;
            var message = (string)outputMsgParameter.Value;

            return new ParameterSystemResponseDTO
            {
                Value = value,
                Message = message
            };

        }
    }
}
