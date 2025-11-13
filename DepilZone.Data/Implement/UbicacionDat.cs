using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DepilZone.Data
{
    public class UbicacionDat : IUbicacionDat
    {
        private readonly string _connectionString;
        public UbicacionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<UbicacionEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Ubicacion_Obtener", conn)
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

        public async Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamento()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Ubicacion_Obtener_Departamento", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsDepartamento(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CiudadDTO>> ObtenerCiudad_ByDepartamento(string iddepartamento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Ubicacion_Obtener_Ciudad_ByDepartamento", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdDepartamento", iddepartamento);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCiudad(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DistritoDTO>> ObtenerDistrito_ByCiudad_ByDepartamento(string idciudad, string iddepartamento)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Ubicacion_Obtener_Distrito_ByCiudad_ByDepartamento", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Ciudad", idciudad);
                cmd.Parameters.AddWithValue("Departamento", iddepartamento);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsDistrito(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS


        static async Task<IEnumerable<UbicacionEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<UbicacionEnt> lista = new List<UbicacionEnt>();
                while (await reader.ReadAsync())
                {
                    UbicacionEnt obj = new UbicacionEnt
                    {
                        IdUbicacion = reader["IdUbicacion"].ToString(),
                        Distrito = reader["Distrito"].ToString(),
                        Ciudad = reader["Ciudad"].ToString(),
                        Departamento = reader["Departamento"].ToString()
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

        static async Task<IEnumerable<DepartamentoDTO>> ReadItemsDepartamento(DbDataReader reader)
        {
            try
            {
                IList<DepartamentoDTO> lista = new List<DepartamentoDTO>();
                while (await reader.ReadAsync())
                {
                    DepartamentoDTO obj = new DepartamentoDTO
                    {
                        IdDepartamento = reader["IdDepartamento"].ToString(),
                        Departamento = reader["Departamento"].ToString()
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
        static async Task<IEnumerable<CiudadDTO>> ReadItemsCiudad(DbDataReader reader)
        {
            try
            {
                IList<CiudadDTO> lista = new List<CiudadDTO>();
                while (await reader.ReadAsync())
                {
                    CiudadDTO obj = new CiudadDTO
                    {
                        IdCiuda = reader["IdCiuda"].ToString(),
                        Ciudad = reader["Ciudad"].ToString()
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
        //DistritoDTO
        static async Task<IEnumerable<DistritoDTO>> ReadItemsDistrito(DbDataReader reader)
        {
            try
            {
                IList<DistritoDTO> lista = new List<DistritoDTO>();
                while (await reader.ReadAsync())
                {
                    DistritoDTO obj = new DistritoDTO
                    {
                        IdUbicacion = reader["IdUbicacion"].ToString(),
                        Distrito = reader["Distrito"].ToString()
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
