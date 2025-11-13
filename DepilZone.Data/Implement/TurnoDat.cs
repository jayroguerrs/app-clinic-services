using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class TurnoDat : ITurnoDat
    {
        private readonly string _connectionString;
        public TurnoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<TurnoEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Turno_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
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

        public async Task<TurnoEnt> ObtenerById(int IdTurno)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Turno_Obtener_Id", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdTurno", IdTurno);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        // READERS

        static async Task<IEnumerable<TurnoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<TurnoEnt> lista = new List<TurnoEnt>();
                while (await reader.ReadAsync())
                {
                    TurnoEnt obj = new TurnoEnt
                    {
                        idturno = Convert.ToInt32(reader["idturno"]),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        HoraInicio = Convert.ToString(reader["HoraInicio"]),
                        HoraFin = Convert.ToString(reader["HoraFin"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
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
        
        static async Task<TurnoEnt> Read(DbDataReader reader)
        {
            try
            {
                TurnoEnt obj = new TurnoEnt();
                while (await reader.ReadAsync())
                {
                    obj.idturno = Convert.ToInt32(reader["idturno"]);
                    obj.Descripcion = Convert.ToString(reader["Descripcion"]);
                    obj.HoraInicio = Convert.ToString(reader["HoraInicio"]);
                    obj.HoraFin = Convert.ToString(reader["HoraFin"]);
                    obj.Estado = Convert.ToBoolean(reader["Estado"]);
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}