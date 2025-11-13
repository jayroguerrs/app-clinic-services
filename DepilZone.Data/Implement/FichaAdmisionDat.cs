using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class FichaAdmisionDat : IFichaAdmisionDat
    {
        private readonly string _connectionString;
        public FichaAdmisionDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        //public async Task<Respuesta<ClienteEnt>> Insertar(FichaAdmisionEnt model)
        //{
        //    using SqlConnection conn = GetConnection();
        //    await conn.OpenAsync();
        //    using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_Insertar", conn)
        //    {
        //        CommandType = System.Data.CommandType.StoredProcedure
        //    };
        //    cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
        //    cmd.Parameters.AddWithValue("pPaisCelular", model.Cliente.PaisCelular1);
        //    cmd.Parameters.AddWithValue("pCelular", model.Cliente.Celular1);
        //    cmd.Parameters.AddWithValue("pNumeroDocumento", model.Cliente.Documento);
        //    cmd.Parameters.AddWithValue("pNombres", model.Cliente.Nombres);
        //    cmd.Parameters.AddWithValue("pApellidos", model.Cliente.Apellidos);
        //    cmd.Parameters.AddWithValue("pFechaNacimiento", model.Cliente.FechaNacimiento);
        //    cmd.Parameters.AddWithValue("pIdGenero", model.Cliente.IdGenero);
        //    cmd.Parameters.AddWithValue("pZonasConsultar", JsonSerializer.Serialize(model.ZonasConsultar));
        //    cmd.Parameters.AddWithValue("pZonasRealizar", JsonSerializer.Serialize(model.ZonasRealizar));
        //    cmd.Parameters.AddWithValue("pPatologias", JsonSerializer.Serialize(model.Patologias));
        //    cmd.Parameters.AddWithValue("pPatologiaRespuestas", JsonSerializer.Serialize(model.PatologiaRespuestas));
        //    cmd.Parameters.AddWithValue("pMedicacionActual", model.MedicacionActual);
        //    cmd.Parameters.AddWithValue("pIndiqueMedicacion", model.IndiqueMedicacion);
        //    cmd.Parameters.AddWithValue("pAplicaProductoMedicado", model.AplicaProductoMedicado);
        //    cmd.Parameters.AddWithValue("pAntecedentePatologico", model.AntecedentePatologico);
        //    cmd.Parameters.AddWithValue("pObservaciones", model.Observaciones);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    return await ReadItem(reader);
        //}
        //static async Task<Respuesta<FichaAdmisionEnt>> ReadItem(DbDataReader reader)
        //{
        //    Respuesta<FichaAdmisionEnt> obj = new Respuesta<FichaAdmisionEnt>
        //    {
        //        Response = new FichaAdmisionEnt()
        //    };
        //    while (await reader.ReadAsync())
        //    {
        //        obj.Exito = Convert.ToBoolean(reader["Exito"]);
        //        obj.Mensaje = Convert.ToString(reader["Mensaje"]);
        //        obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
        //        obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
        //        if (obj.Exito)
        //        {
        //            obj.Response.Id = Convert.ToInt32(reader["Id"]);
        //            obj.Response.FechaRegistro= Convert.ToDateTime(reader["FechaRegistro"].ToString());
        //            obj.Response.IdCliente =  Convert.ToInt32(reader["IdCliente"].ToString());
        //        }
        //    }
        //    return obj;
        //}

        public async Task<FichaAdmisionDTO> ObtenerFichaById(int idFichaAdmision)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdFichaAdmision", idFichaAdmision);
                var reader = await cmd.ExecuteReaderAsync();

                var output = await ReadObtenerById(reader);
                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditarFichaAdmision(FichaAdmisionDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("SP_FichaAdmision_ModificarById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdFichaAdmision", model.Id);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuarioEdita);
                cmd.Parameters.AddWithValue("pPatologias", JsonSerializer.Serialize(model.Patologias) );
                var reader = await cmd.ExecuteReaderAsync();

                bool output = false;
                while (await reader.ReadAsync())
                {
                    output = Convert.ToBoolean(reader["Exito"]);
                }

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READER

        static async Task<FichaAdmisionDTO> ReadObtenerById(SqlDataReader reader)
        {
            try
            {
                FichaAdmisionDTO obj = new FichaAdmisionDTO();
                /*while (await reader.ReadAsync())
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
                }*/

                //Leer Mensaje Nota
                List<FichaAdmisionPatologiaDTO> patologias = new List<FichaAdmisionPatologiaDTO>();
               
                while (await reader.ReadAsync())
                {
                    FichaAdmisionPatologiaDTO patologia = new FichaAdmisionPatologiaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(reader["Activo"])
                    };
                    patologias.Add(patologia);
                }
                obj.Patologias = patologias;
               


                /*List<HC_Zonas> zonasConsultar = new List<HC_Zonas>();
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
                obj.ZonasRealizar = zonasRealizar;*/


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
