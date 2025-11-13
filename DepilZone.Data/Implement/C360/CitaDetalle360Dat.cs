using DepilZone.Data.Interface.C360;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement.C360
{
    public class CitaDetalle360Dat : ICitaDetalle360Dat
    {

        private readonly string _connectionString;

        public CitaDetalle360Dat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<List<Cita360DetallesDTO>> BuscarByCita(int idCita)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaDetalle360_BuscarByCita", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarByCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        //****************************************************************** READERS


        static async Task<List<Cita360DetallesDTO>> ReadBuscarByCita(DbDataReader reader)
        {
            try
            {
                List<Cita360DetallesDTO> collection = new List<Cita360DetallesDTO>();
                while (await reader.ReadAsync())
                {
                    Cita360DetallesDTO obj = new Cita360DetallesDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdZona = Convert.ToInt32(reader["IdZona"]);
                    obj.IdUsuarioAgendado = DBNull.Value == reader["IdUsuarioAgendado"] ? (int?)null : Convert.ToInt32(reader["IdUsuarioAgendado"]);
                    obj.UsuarioAgendado = DBNull.Value == reader["UsuarioAgendado"] ? null : Convert.ToString(reader["UsuarioAgendado"]);
                    obj.Zona = Convert.ToString(reader["Zona"]);
                    obj.Precio = Convert.ToDecimal(reader["Precio"]);
                    obj.Minutos = Convert.ToInt32(reader["Minutos"]);
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.Promocion = Convert.ToString(reader["Promocion"]);
                    obj.IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]);
                    obj.IdTecnologia = DBNull.Value == reader["IdTecnologia"] ? (int?)null : Convert.ToInt32(reader["IdTecnologia"]);
                    obj.Tecnologia = DBNull.Value == reader["Tecnologia"] ? null : Convert.ToString(reader["Tecnologia"]);
                    obj.IdMedioContactoOrigen = DBNull.Value == reader["IdMedioContactoOrigen"] ? (int?)null : Convert.ToInt32(reader["IdMedioContactoOrigen"]);

                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

    }
}