using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class EmpresaDat : IEmpresaDat
	{
        private readonly string _connectionString;

        public EmpresaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<EmpresaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Empresa_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                return null; // await ReadItems(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Empresa_EmisionTicketByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS

        static async Task<EmpresaEmisionTicketDTO> ReadItems(DbDataReader reader)
        {
            try
            {
                EmpresaEmisionTicketDTO obj = new EmpresaEmisionTicketDTO();
                while (await reader.ReadAsync())
                {
                    obj.RazonSocial = Convert.ToString(reader["RazonSocialEmisor"]);
                    obj.RUC = Convert.ToString(reader["RucEmisor"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.DireccionBySede = Convert.ToString(reader["DireccionLocal"]);
                    obj.Telefonos = Convert.ToString(reader["Telefonos"]);
                    obj.SerieNumeroComprobante = Convert.ToString(reader["Ticket"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Documento = Convert.ToString(reader["Documento"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                    obj.Vuelto = Convert.ToDecimal(reader["Vuelto"]);
                    obj.IdTipoComprobante = Convert.ToInt32(reader["IdTipoComprobante"]);
                    obj.BoletaPdfBase64 = Convert.ToString(reader["BoletaPdfBase64"]);
                    obj.SunatUrlPdf = DBNull.Value == reader["SunatUrlPdf"] ? null : Convert.ToString(reader["SunatUrlPdf"]);
                    obj.SunatUrlXml = DBNull.Value == reader["SunatUrlXml"] ? null : Convert.ToString(reader["SunatUrlXml"]);
                    obj.SunatUrlCdr = DBNull.Value == reader["SunatUrlCdr"] ? null : Convert.ToString(reader["SunatUrlCdr"]);
                }

                //Leer los avisos
                List<DetalleTicketEmisionDTO> detalles = new List<DetalleTicketEmisionDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        DetalleTicketEmisionDTO detalle = new DetalleTicketEmisionDTO()
                        {
                            ZonaCorporal = reader["ZonaCorporal"].ToString(),
                            Sesion = Convert.ToInt32(reader["Sesion"]),
                            Precio = Convert.ToDecimal(reader["Precio"])
                        };
                        detalles.Add(detalle);
                    }
                }

                obj.Detalle = detalles;



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
