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
    public class CitaMotivoDat : ICitaMotivoDat
    {
        private readonly string _connectionString;

        public CitaMotivoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<CitaMotivoEnt>> ListarByCitaEstado( int idCitaEstado )
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMotivo_ListarByCitaEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCitaEstado", idCitaEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCollection(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CitaMotivoEnt>> Listar()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_CitaMotivo_Listar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadCollection(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<List<CitaMotivoEnt>> ReadCollection(DbDataReader reader)
        {
            try
            {
                List<CitaMotivoEnt> lista = new List<CitaMotivoEnt>();
                while (await reader.ReadAsync())
                {
                    CitaMotivoEnt obj = new CitaMotivoEnt
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Motivo = reader["Motivo"].ToString(),
                        IdCitaEstado = Convert.ToInt32(reader["IdCitaEstado"].ToString())
                    };
                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
