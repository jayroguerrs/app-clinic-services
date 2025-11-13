using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class DocumentoIdentidadTipoDat : IDocumentoIdentidadTipoDat
    {
        private readonly string _connectionString;

        public DocumentoIdentidadTipoDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<IEnumerable<DocumentoIdentidadTipoEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_DocumentoIdentidadTipo_Obtener", conn)
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

        // READERS

        static async Task<IEnumerable<DocumentoIdentidadTipoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<DocumentoIdentidadTipoEnt> lista = new List<DocumentoIdentidadTipoEnt>();
                while (await reader.ReadAsync())
                {
                    DocumentoIdentidadTipoEnt obj = new DocumentoIdentidadTipoEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString()
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
