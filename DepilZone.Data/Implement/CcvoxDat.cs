using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DepilZone.Data.Implement
{
    public class CcvoxDat : ICcvoxDat
    {
        private readonly string _connectionString;

        public CcvoxDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<ResponseRedirect> EsCliente2(string numero)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                string urlBase = "";
                using (SqlCommand cmdView = new SqlCommand("SELECT Valor FROM ApiUrlCcvox", conn))
                {
                    var result = await cmdView.ExecuteScalarAsync();
                    if (result != null)
                        urlBase = result.ToString();
                }

                using SqlCommand cmd = new SqlCommand("SP_Ccvox_NumeroDeClientes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener2(reader, numero, urlBase);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        static async Task<ResponseRedirect> ReadItemsObtener2(DbDataReader reader, string numero, string urlBase)
        {
            try
            {
                var numerosClientes = new Dictionary<string, List<int>>();
                var idClientes = new Dictionary<int, int>();
                var numerosPreferentes = new Dictionary<string, int>();

                // Inicializamos la respuesta con valores predeterminados.
                var obj_res = new ResponseRedirect
                {
                    TypeClient = "",
                    Identificator = "0",  // Valor predeterminado de "0"
                    //Redirect = "https://qa.depilzone.com.pe:5037/"  // Valor predeterminado
                    Redirect = urlBase  // Valor predeterminado
                };

                // Leemos los datos del reader
                while (await reader.ReadAsync())
                {
                    string celular1 = reader["Celular1"]?.ToString();
                    string celular2 = reader["Celular2"]?.ToString();
                    int idCliente = Convert.ToInt32(reader["IdCliente"]);

                    // Solo agregamos los números al diccionario si no están vacíos
                    if (!string.IsNullOrEmpty(celular1))
                    {
                        if (!numerosClientes.ContainsKey(celular1))
                        {
                            numerosClientes[celular1] = new List<int>();
                        }

                        numerosClientes[celular1].Add(idCliente);
                    }

                    if (!string.IsNullOrEmpty(celular2))
                    {
                        if (!numerosClientes.ContainsKey(celular2))
                        {
                            numerosClientes[celular2] = new List<int>();
                        }

                        numerosClientes[celular2].Add(idCliente);
                    }
                    idClientes[idCliente] = idCliente;
                }

                // Si el número es menor a 9 dígitos, asumimos que es un IdCliente
                if (numero.Length < 9 && int.TryParse(numero, out int idBusqueda) && idClientes.ContainsKey(idBusqueda))
                {
                    obj_res.TypeClient = "CLIENT";
                    obj_res.Identificator = idBusqueda.ToString();
                    obj_res.Redirect = $"{urlBase}ClientePerfil/{idBusqueda}/General";
                    return obj_res;
                }

                if (numerosClientes.ContainsKey(numero))
                {
                    var clientes = numerosClientes[numero];
                    if (clientes.Count > 1)
                    {
                        obj_res.TypeClient = "CLIENTS";
                        obj_res.Identificator = string.Join(",", clientes);
                        obj_res.Redirect = $"{urlBase}Inicio?idClientes={string.Join("-", clientes)}";
                    }
                    else
                    {
                        obj_res.TypeClient = "CLIENT";
                        obj_res.Identificator = clientes[0].ToString();
                        obj_res.Redirect = $"{urlBase}ClientePerfil/{clientes[0]}/General";
                    }
                    return obj_res;
                }
                // Preferente
                if (await reader.NextResultAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string celularPreferente = reader["Numero"]?.ToString()?.Replace(" ", "");
                        int idPreferente = Convert.ToInt32(reader["IdPreferente"]);

                        if (!string.IsNullOrEmpty(celularPreferente))
                            numerosPreferentes[celularPreferente] = idPreferente;
                    }

                    if (numerosPreferentes.ContainsKey(numero))
                    {
                        obj_res.TypeClient = "PREFERENTE";
                        obj_res.Identificator = numerosPreferentes[numero].ToString();
                        obj_res.Redirect = $"{urlBase}Preferente?id_preferente={numerosPreferentes[numero]}";
                    }
                    else
                    {
                        obj_res.TypeClient = "NEW";
                        obj_res.Identificator = null;
                        obj_res.Redirect = $"{urlBase}Cliente?newClient=true&clientNumber={numero}";
                    }
                }
                return obj_res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
