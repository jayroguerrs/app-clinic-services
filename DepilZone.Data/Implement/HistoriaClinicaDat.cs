using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class HistoriaClinicaDat : IHistoriaClinicaDat
    {
        private readonly string _connectionString;
        public HistoriaClinicaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<HistoriaClinicaDTO> ObtenerDetallesCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_ObtenerClienteDetalle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadDetallesCliente(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HistoriaClinicaDTO> ObtenerDetallesById(int idFichaAdmision)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_DetalleById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdFichaAdmision", idFichaAdmision);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadFichaAdmisionDetalle(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<HistoriaClinicaDTO> Insertar(HistoriaClinicaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pFechaHistoria", model.FechaHistoria);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadInsertar(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<FichaAdmisionDTO>> ListarByCliente(int idCliente)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_ListarParaCliente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadListarByCliente(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FichaAdmisionDTO>> ListarByClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_ListarParaClientePorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadListarByCliente(reader);
                conn.Close();


                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Anular(int idHistoria, int idUsuario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_HistoriaClinica_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdHistoria", idHistoria);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", idUsuario);
                var reader = await cmd.ExecuteReaderAsync();

                var Exito = 0;
                string Mensaje = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToInt32(reader["Exito"]);
                    Mensaje = reader["Mensaje"].ToString();
                }
                conn.Close();

                if(Exito == 0)
                {
                    throw new SystemException(Mensaje);
                }

                return Exito == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS
        static async Task<HistoriaClinicaDTO> ReadFichaAdmisionDetalle(SqlDataReader reader)
        {
            try
            {
                HistoriaClinicaDTO obj = new HistoriaClinicaDTO();
                while (await reader.ReadAsync())
                {
                    int Exito = Convert.ToInt32(reader["Exito"]);
                    string ErrorMensaje = reader["Mensaje"].ToString();

                    if (Exito == 1)
                    {
                        obj.FechaHistoria = Convert.ToDateTime(reader["FechaHistoria"]);
                        obj.IdFichaAdmision = reader["IdFichaAdmision"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdFichaAdmision"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.NombreCompleto = reader["NombreCompleto"].ToString();
                        obj.Telefono = reader["Telefono"] == DBNull.Value ? null : reader["Telefono"].ToString();
                        obj.Domicilio = reader["Domicilio"] == DBNull.Value ? null : reader["Domicilio"].ToString();
                        obj.Edad = reader["Edad"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Edad"]);
                        obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                        obj.EstadoCivil = reader["EstadoCivil"] == DBNull.Value ? null : reader["EstadoCivil"].ToString();
                        obj.FototipoPiel = reader["FototipoPiel"] == DBNull.Value ? null : reader["FototipoPiel"].ToString();
                        obj.Documento = reader["Documento"] == DBNull.Value ? null : reader["Documento"].ToString();
                        obj.TipoDocumento = reader["TipoDocumento"] == DBNull.Value ? null : reader["TipoDocumento"].ToString();
                        obj.Profesion = reader["Profesion"] == DBNull.Value ? null : reader["Profesion"].ToString();
                        obj.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();


                        obj.AlergiasMedicamentosas = reader["AlergiasMedicamentosas"] == DBNull.Value ? null : reader["AlergiasMedicamentosas"].ToString();
                        obj.AntPerMedicos = reader["AntPerMedicos"] == DBNull.Value ? null : reader["AntPerMedicos"].ToString();
                        obj.AntPerQuirurgicos = reader["AntPerQuirurgicos"] == DBNull.Value ? null : reader["AntPerQuirurgicos"].ToString();
                        obj.AntTratFarmacologicos = reader["AntTratFarmacologicos"] == DBNull.Value ? null : reader["AntTratFarmacologicos"].ToString();
                        obj.AntTratEstPrev = reader["AntTratEstPrev"] == DBNull.Value ? null : reader["AntTratEstPrev"].ToString();

                        obj.Peso = reader["Peso"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Peso"]);
                        obj.Altura = reader["Altura"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Altura"]);
                        obj.NumeroHijos = reader["NumeroHijos"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroHijos"]);

                        obj.TipoCicatrizacion = reader["TipoCicatrizacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TipoCicatrizacion"]);

                        obj.BebeAlcohol = reader["BebeAlcohol"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BebeAlcohol"]);
                        obj.EsFumador = reader["EsFumador"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["EsFumador"]);

                        obj.TieneMedicacion = reader["TieneMedicacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TieneMedicacion"]);
                        obj.IndiqueMedicacion = reader["IndiqueMedicacion"] == DBNull.Value ? null : reader["IndiqueMedicacion"].ToString();

                        obj.ComunicacionCliente = reader["IdComunicacionCliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdComunicacionCliente"]);

                        obj.Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString();

                        obj.Ultimos12meses = reader["Ultimos12meses"] == DBNull.Value ? null : reader["Ultimos12meses"].ToString();
                        obj.AntecedenteFamiliar = reader["AntecedenteFamiliar"] == DBNull.Value ? null : reader["AntecedenteFamiliar"].ToString();
                        obj.ReaccionAlergicaCutanea = reader["ReaccionAlergicaCutanea"] == DBNull.Value ? null : reader["ReaccionAlergicaCutanea"].ToString();

                        obj.EmbarazoSospecha = reader["EmbarazoSospecha"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["EmbarazoSospecha"]);

                        obj.CigarrosAldia = reader["CigarrosAldia"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CigarrosAldia"]);

                        obj.IdMedioContacto = reader["IdMedioContacto"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Genero = reader["Genero"] == DBNull.Value ? null : reader["Genero"].ToString();
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    }
                    else
                    {
                        throw new SystemException(ErrorMensaje);
                    }
                }

                //Leer Mensaje Nota
                List<HC_Patologia> patologias = new List<HC_Patologia>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        HC_Patologia patologia = new HC_Patologia()
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Activo = Convert.ToInt32(reader["Activo"]) == 1 ? true : false
                        };
                        patologias.Add(patologia);
                    }
                    obj.Patologias = patologias;
                }


                List<HC_Zonas> zonasConsultar = new List<HC_Zonas>();
                List<HC_Zonas> zonasRealizar = new List<HC_Zonas>();
                //Leer las zonas consultar y realizar
                if (obj.IdFichaAdmision != null)
                {
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            HC_Zonas zona = new HC_Zonas()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            zonasConsultar.Add(zona);
                        }
                    }
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            HC_Zonas zona = new HC_Zonas()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            zonasRealizar.Add(zona);
                        }
                    }
                }

                obj.ZonasConsultar = zonasConsultar;
                obj.ZonasRealizar = zonasRealizar;


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<HistoriaClinicaDTO> ReadDetallesCliente(SqlDataReader reader)
        {
            try
            {
                HistoriaClinicaDTO obj = new HistoriaClinicaDTO();
                while (await reader.ReadAsync())
                {
                    int Exito = Convert.ToInt32(reader["Exito"]);
                    string ErrorMensaje = reader["Mensaje"].ToString();

                    if (Exito == 1)
                    {
                        obj.FechaHistoria = Convert.ToDateTime(reader["FechaHistoria"]);
                        obj.IdFichaAdmision = reader["IdFichaAdmision"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdFichaAdmision"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.NombreCompleto = reader["NombreCompleto"].ToString();
                        obj.Telefono = reader["Telefono"] == DBNull.Value ? null : reader["Telefono"].ToString();
                        obj.Domicilio = reader["Domicilio"] == DBNull.Value ? null : reader["Domicilio"].ToString();
                        obj.Edad = reader["Edad"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Edad"]);
                        obj.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]);
                        obj.EstadoCivil = reader["EstadoCivil"] == DBNull.Value ? null : reader["EstadoCivil"].ToString();
                        obj.FototipoPiel = reader["FototipoPiel"] == DBNull.Value ? null : reader["FototipoPiel"].ToString();
                        obj.Documento = reader["Documento"] == DBNull.Value ? null : reader["Documento"].ToString();
                        obj.TipoDocumento = reader["TipoDocumento"] == DBNull.Value ? null : reader["TipoDocumento"].ToString();
                        obj.Profesion = reader["Profesion"] == DBNull.Value ? null : reader["Profesion"].ToString();
                        obj.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();


                        obj.AlergiasMedicamentosas = reader["AlergiasMedicamentosas"] == DBNull.Value ? null : reader["AlergiasMedicamentosas"].ToString();
                        obj.AntPerMedicos = reader["AntPerMedicos"] == DBNull.Value ? null : reader["AntPerMedicos"].ToString();
                        obj.AntPerQuirurgicos = reader["AntPerQuirurgicos"] == DBNull.Value ? null : reader["AntPerQuirurgicos"].ToString();
                        obj.AntTratFarmacologicos = reader["AntTratFarmacologicos"] == DBNull.Value ? null : reader["AntTratFarmacologicos"].ToString();
                        obj.AntTratEstPrev = reader["AntTratEstPrev"] == DBNull.Value ? null : reader["AntTratEstPrev"].ToString();

                        obj.Peso = reader["Peso"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Peso"]);
                        obj.Altura = reader["Altura"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Altura"]);
                        obj.NumeroHijos = reader["NumeroHijos"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NumeroHijos"]);

                        obj.TipoCicatrizacion = reader["TipoCicatrizacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TipoCicatrizacion"]);

                        obj.BebeAlcohol = reader["BebeAlcohol"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BebeAlcohol"]);
                        obj.EsFumador = reader["EsFumador"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["EsFumador"]);

                        obj.TieneMedicacion = reader["TieneMedicacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TieneMedicacion"]);
                        obj.IndiqueMedicacion = reader["IndiqueMedicacion"] == DBNull.Value ? null : reader["IndiqueMedicacion"].ToString();

                        obj.ComunicacionCliente = reader["IdComunicacionCliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdComunicacionCliente"]);

                        obj.Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString();

                        obj.Ultimos12meses = reader["Ultimos12meses"] == DBNull.Value ? null : reader["Ultimos12meses"].ToString();
                        obj.AntecedenteFamiliar = reader["AntecedenteFamiliar"] == DBNull.Value ? null : reader["AntecedenteFamiliar"].ToString();
                        obj.ReaccionAlergicaCutanea = reader["ReaccionAlergicaCutanea"] == DBNull.Value ? null : reader["ReaccionAlergicaCutanea"].ToString();

                        obj.EmbarazoSospecha = reader["EmbarazoSospecha"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["EmbarazoSospecha"]);

                        obj.CigarrosAldia = reader["CigarrosAldia"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CigarrosAldia"]);

                        obj.IdMedioContacto = reader["IdMedioContacto"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Genero = reader["Genero"] == DBNull.Value ? null : reader["Genero"].ToString();
                        obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    }
                    else
                    {
                        throw new SystemException(ErrorMensaje);
                    }
                }

                //Leer Mensaje Nota
                List<HC_Patologia> patologias = new List<HC_Patologia>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        HC_Patologia patologia = new HC_Patologia()
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Activo = Convert.ToInt32(reader["Activo"]) == 1 ? true : false
                        };
                        patologias.Add(patologia);
                    }
                    obj.Patologias = patologias;
                }


                List<HC_Zonas> zonasConsultar = new List<HC_Zonas>();
                List<HC_Zonas> zonasRealizar = new List<HC_Zonas>();
                //Leer las zonas consultar y realizar
                if ( obj.IdFichaAdmision != null)
                {
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            HC_Zonas zona = new HC_Zonas()
                            {
                                Id =Convert.ToInt32( reader["Id"] ),
                                Nombre = reader["Nombre"].ToString()
                            };
                            zonasConsultar.Add(zona);
                        }
                    }
                    if (reader.NextResult())
                    {
                        while (await reader.ReadAsync())
                        {
                            HC_Zonas zona = new HC_Zonas()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString()
                            };
                            zonasRealizar.Add(zona);
                        }
                    }
                }

                obj.ZonasConsultar = zonasConsultar;
                obj.ZonasRealizar = zonasRealizar;


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<HistoriaClinicaDTO> ReadInsertar(SqlDataReader reader)
        {
            try
            {
                HistoriaClinicaDTO obj = new HistoriaClinicaDTO();
                while (await reader.ReadAsync())
                {
                    bool Exito = Convert.ToBoolean(reader["Exito"]);
                    string Mensaje = reader["Mensaje"].ToString();

                    if (Exito)
                    {
                        obj.Id = reader["Id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Id"]);
                        obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.IdUsuarioRegistro = Convert.ToInt32(reader["IdUsuarioRegistro"]);
                        obj.FechaHistoria = Convert.ToDateTime(reader["FechaHistoria"]);
                        obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    }
                    else
                    {
                        throw new SystemException(Mensaje);
                    }
                    
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<FichaAdmisionDTO>> ReadListarByCliente(SqlDataReader reader)
        {
            try
            {
                List<FichaAdmisionDTO> collection = new List<FichaAdmisionDTO>();
                while (await reader.ReadAsync())
                {
                    FichaAdmisionDTO obj = new FichaAdmisionDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.UsuarioRegistra = reader["UsuarioRegistro"].ToString();
                    obj.UsuarioEdita = DBNull.Value == reader["UsuarioEdito"] ? null :reader["UsuarioEdito"].ToString();

                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.FechaEdita = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null :  Convert.ToDateTime(reader["FechaModifico"]);

                    collection.Add(obj);
                }
                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
