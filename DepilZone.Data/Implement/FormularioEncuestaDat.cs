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
	public class FormularioEncuestaDat : IFormularioEncuestaDat
	{
        private readonly string _connectionString;
        public FormularioEncuestaDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<List<FormularioEncuestaDTO>> ObtenerListado(int idTipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_ObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListado(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<FormularioEncuestaDTO>> ObtenerListadoByCliente(int idCliente, int idTipo)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_ClienteObtenerListado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipo", idTipo);
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadListadoByCliente(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<FormularioEncuestaDTO> ObtenerById(int idFormulario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", idFormulario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadFormulario(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<bool> GuardarEncuesta(FormularioEncuestaRespuestaDTO model)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdFormulario", model.IdFormulario);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);

                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);

                cmd.Parameters.AddWithValue("pIdUsuarioRegistro", model.IdUsuarioRegistro);
                cmd.Parameters.AddWithValue("pRespuestas", JsonSerializer.Serialize( model.Respuestas ));

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<FormularioEncuestaPreguntaDTO>> ObtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_Reporte", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdFormulario", idFormulario);
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<FormularioEncuestaPreguntaDTO>> BuscarReporte(int idFormulario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_ClienteObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdFormularioRespuesta", idFormulario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadBuscarReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ClienteDTO>> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_Clientes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdFormulario", idFormulario);
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerClientes(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<FormularioEncuestaRespuestaDTO>> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario)
        {
            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_FormularioEncuesta_listarByClienteFormulario", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdFormulario", idFormulario);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerListadoByClienteFormulario(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        // READERS

        static async Task<bool> ReadInsertar(DbDataReader reader)
        {
            try
            {
                bool Exito = false;
                string Mensaje = "";
                string ErrorDetalle = "";
                while (await reader.ReadAsync())
                {
                    Exito = Convert.ToBoolean(reader["Exito"]);
                    Mensaje = reader["Mensaje"].ToString();
                    ErrorDetalle = reader["ErrorDetalle"].ToString();
                }

                return Exito;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<FormularioEncuestaDTO>> ReadListado(DbDataReader reader)
        {
            try
            {
                List<FormularioEncuestaDTO> collection = new List<FormularioEncuestaDTO>();
                while (await reader.ReadAsync())
                {
                    FormularioEncuestaDTO obj = new FormularioEncuestaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = reader["Nombre"].ToString();
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();

                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<List<FormularioEncuestaRespuestaDTO>> ReadObtenerListadoByClienteFormulario(DbDataReader reader)
        {
            try
            {
                List<FormularioEncuestaRespuestaDTO> collection = new List<FormularioEncuestaRespuestaDTO>();
                while (await reader.ReadAsync())
                {
                    FormularioEncuestaRespuestaDTO obj = new FormularioEncuestaRespuestaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<FormularioEncuestaDTO>> ReadListadoByCliente(DbDataReader reader)
        {
            try
            {
                List<FormularioEncuestaDTO> collection = new List<FormularioEncuestaDTO>();
                while (await reader.ReadAsync())
                {
                    FormularioEncuestaDTO obj = new FormularioEncuestaDTO();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombre = reader["Nombre"].ToString();
                    obj.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    obj.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                    obj.Realizado = Convert.ToBoolean( reader["Realizado"] );

                    obj.FechaModifico = reader["FechaModifico"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaModifico"]);
                    obj.UsuarioModifico = reader["UsuarioModifico"] == DBNull.Value ? null : reader["UsuarioModifico"].ToString();

                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        static async Task<FormularioEncuestaDTO> ReadFormulario(DbDataReader reader)
        {
            try
            {
                FormularioEncuestaDTO formulario = new FormularioEncuestaDTO();
                while (await reader.ReadAsync())
                {
                    formulario.Id = Convert.ToInt32(reader["Id"]);
                    formulario.Nombre = reader["Nombre"].ToString();
                    formulario.preguntas = new List<FormularioEncuestaPreguntaDTO>();
                    formulario.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                }

                List<FormularioEncuestaPreguntaDTO> preguntas = new List<FormularioEncuestaPreguntaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaPreguntaDTO pregunta = new FormularioEncuestaPreguntaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFormularioEncuesta = Convert.ToInt32(reader["IdFormularioEncuesta"]),
                            Texto = reader["Texto"].ToString(),
                            Multiple = Convert.ToBoolean(reader["Multiple"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            TipoRespuesta = reader["TipoRespuesta"].ToString(),
                            Obligatorio = Convert.ToBoolean( reader["Obligatorio"] ),
                        };
                        preguntas.Add(pregunta);
                    }
                    formulario.preguntas = preguntas;
                }


                List<FormularioEncuestaOpcionDTO> opciones = new List<FormularioEncuestaOpcionDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaOpcionDTO opcion = new FormularioEncuestaOpcionDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFormularioPregunta = Convert.ToInt32(reader["IdFormularioPregunta"]),
                            Valor = reader["Valor"].ToString(),
                            PlaceholderAdicional = reader["PlaceholderAdicional"] == DBNull.Value ? null : reader["PlaceholderAdicional"].ToString(),
                            Adicional = Convert.ToBoolean(reader["Adicional"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"])
                        };
                        opciones.Add(opcion);
                    }

                    foreach (var pregunta in formulario.preguntas)
                    {
                        pregunta.opciones = opciones.FindAll(x => x.IdFormularioPregunta == pregunta.Id);
                    }

                }


                return formulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        static async Task<List<FormularioEncuestaPreguntaDTO>> ReadObtenerReporte(DbDataReader reader)
        {
            try
            {

                List<FormularioEncuestaPreguntaDTO> preguntas = new List<FormularioEncuestaPreguntaDTO>();
                while (await reader.ReadAsync())
                {
                    FormularioEncuestaPreguntaDTO pregunta = new FormularioEncuestaPreguntaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Texto = reader["Texto"].ToString(),
                        TipoRespuesta = reader["TipoRespuesta"].ToString(),
                        Multiple = Convert.ToBoolean(reader["Multiple"]),
                        Orden = Convert.ToInt32(reader["Orden"])
                    };
                    preguntas.Add(pregunta);
                }

                List<FormularioEncuestaOpcionDTO> opciones = new List<FormularioEncuestaOpcionDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaOpcionDTO opcion = new FormularioEncuestaOpcionDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Valor = reader["Valor"].ToString(),
                            IdFormularioPregunta = Convert.ToInt32(reader["IdFormularioPregunta"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                        };
                        opciones.Add(opcion);
                    }

                    foreach (var pregunta in preguntas)
                    {
                        if(pregunta.TipoRespuesta == "radio" || pregunta.TipoRespuesta == "select" || pregunta.TipoRespuesta == "checkbox")
                        {
                            pregunta.opciones = opciones.FindAll(o => o.IdFormularioPregunta == pregunta.Id);
                        }
                        else
                        {
                            pregunta.opciones = new List<FormularioEncuestaOpcionDTO>();
                        }
                    }

                }


                List<RespuestasDTO> respuestas = new List<RespuestasDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        RespuestasDTO respuesta = new RespuestasDTO()
                        {
                            IdPregunta = Convert.ToInt32(reader["IdPregunta"]),
                            IdRespuesta = Convert.ToInt32(reader["IdRespuesta"]),
                            IdRespuestas = DBNull.Value == reader["IdRespuestas"] ? null : reader["IdRespuestas"].ToString(),
                            RespuestaTexto = DBNull.Value == reader["RespuestaTexto"] ? null : reader["RespuestaTexto"].ToString(),
                        };
                        respuestas.Add(respuesta);
                    }

                    List<RespuestasDTO> adRespuestas = new List<RespuestasDTO>();
                    foreach (RespuestasDTO resp in respuestas)
                    {
                        if(resp.IdRespuestas != null)
                        {
                            List<int> arrIds = new List<int>();
                            string[] ids = resp.IdRespuestas.Split(',');
                            foreach (string id in ids)
                            {
                                RespuestasDTO copia = resp;
                                copia.IdRespuesta = Convert.ToInt32(id);
                                adRespuestas.Add(copia);
                            }
                        }
                    }

                    foreach (RespuestasDTO resp in adRespuestas)
                    {
                        respuestas.Add(resp);
                    }

                }


                foreach (var pregunta in preguntas)
                {
                    List<string> resp = new List<string>();
                    if ( pregunta.TipoRespuesta == "textarea")
                    {
                        foreach (var respuesta in respuestas)
                        {
                            if (respuesta.IdPregunta == pregunta.Id)
                            {
                                resp.Add(respuesta.RespuestaTexto);
                            }
                        }
                    }

                    if(pregunta.TipoRespuesta == "radio" || pregunta.TipoRespuesta == "select" || pregunta.TipoRespuesta == "checkbox")
                    {
                        foreach (var opcion in pregunta.opciones)
                        {
                                opcion.Contador = respuestas.FindAll(r => r.IdRespuesta == opcion.Id).Count;
                        }
                    }

                    pregunta.Respuestas = resp;
                }


                /*List<FormularioEncuestaOpcionDTO> opciones = new List<FormularioEncuestaOpcionDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaOpcionDTO opcion = new FormularioEncuestaOpcionDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFormularioPregunta = Convert.ToInt32(reader["IdFormularioPregunta"]),
                            Valor = reader["Valor"].ToString(),
                            PlaceholderAdicional = reader["PlaceholderAdicional"] == DBNull.Value ? null : reader["PlaceholderAdicional"].ToString(),
                            Adicional = Convert.ToBoolean(reader["Adicional"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"])
                        };
                        opciones.Add(opcion);
                    }

                    foreach (var pregunta in formulario.preguntas)
                    {
                        pregunta.opciones = opciones.FindAll(x => x.IdFormularioPregunta == pregunta.Id);
                    }

                }*/


                return preguntas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<FormularioEncuestaPreguntaDTO>> ReadBuscarReporte(DbDataReader reader)
        {
            try
            {


                List<FormularioEncuestaPreguntaDTO> preguntas = new List<FormularioEncuestaPreguntaDTO>();
                while (await reader.ReadAsync())
                {
                    FormularioEncuestaPreguntaDTO pregunta = new FormularioEncuestaPreguntaDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Texto = reader["Texto"].ToString(),
                        TipoRespuesta = reader["TipoRespuesta"].ToString(),
                        Multiple = Convert.ToBoolean(reader["Multiple"]),
                        Orden = Convert.ToInt32(reader["Orden"])
                    };
                    preguntas.Add(pregunta);
                }

                List<FormularioEncuestaOpcionDTO> opciones = new List<FormularioEncuestaOpcionDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaOpcionDTO opcion = new FormularioEncuestaOpcionDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Valor = reader["Valor"].ToString(),
                            IdFormularioPregunta = Convert.ToInt32(reader["IdFormularioPregunta"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                        };
                        opciones.Add(opcion);
                    }

                    foreach (var pregunta in preguntas)
                    {
                        if (pregunta.TipoRespuesta == "radio" || pregunta.TipoRespuesta == "select" || pregunta.TipoRespuesta == "checkbox")
                        {
                            pregunta.opciones = opciones.FindAll(o => o.IdFormularioPregunta == pregunta.Id);
                        }
                        else
                        {
                            pregunta.opciones = new List<FormularioEncuestaOpcionDTO>();
                        }
                    }

                }


                List<RespuestasDTO> respuestas = new List<RespuestasDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        RespuestasDTO respuesta = new RespuestasDTO()
                        {
                            IdPregunta = Convert.ToInt32(reader["IdPregunta"]),
                            IdRespuesta = Convert.ToInt32(reader["IdRespuesta"]),
                            IdRespuestas = DBNull.Value == reader["IdRespuestas"] ? null : reader["IdRespuestas"].ToString(),
                            RespuestaTexto = DBNull.Value == reader["RespuestaTexto"] ? null : reader["RespuestaTexto"].ToString(),
                        };
                        respuestas.Add(respuesta);
                    }

                    List<RespuestasDTO> adRespuestas = new List<RespuestasDTO>();
                    foreach (RespuestasDTO resp in respuestas)
                    {
                        if (resp.IdRespuestas != null)
                        {
                            List<int> arrIds = new List<int>();
                            string[] ids = resp.IdRespuestas.Split(',');
                            foreach (string id in ids)
                            {
                                RespuestasDTO copia = resp;
                                copia.IdRespuesta = Convert.ToInt32(id);
                                adRespuestas.Add(copia);
                            }
                        }
                    }

                    foreach (RespuestasDTO resp in adRespuestas)
                    {
                        respuestas.Add(resp);
                    }

                }


                foreach (var pregunta in preguntas)
                {
                    List<string> resp = new List<string>();
                    if (pregunta.TipoRespuesta == "textarea")
                    {
                        foreach (var respuesta in respuestas)
                        {
                            if (respuesta.IdPregunta == pregunta.Id)
                            {
                                pregunta.Respuesta = respuesta.RespuestaTexto;
                            }
                        }
                    }

                    if (pregunta.TipoRespuesta == "radio" || pregunta.TipoRespuesta == "select" || pregunta.TipoRespuesta == "checkbox")
                    {
                        if(!pregunta.Multiple){
                            foreach (var opcion in pregunta.opciones)
                            {
                               opcion.Contador = respuestas.FindAll(r => r.IdRespuesta == opcion.Id).Count;
                            }
                        }
                        else
                        {
                            List<string> ids  = new List<string>( respuestas.Find(r => r.IdPregunta == pregunta.Id).IdRespuestas.Split(',') );
                            foreach (var opcion in pregunta.opciones)
                            {
                                opcion.Contador = ids.FindAll(x => x == opcion.Id.ToString()).Count;
                            }
                        }
                        
                    }

                    pregunta.Respuestas = resp;
                }


                /*List<FormularioEncuestaOpcionDTO> opciones = new List<FormularioEncuestaOpcionDTO>();
                if (reader.NextResult())
                {

                    while (await reader.ReadAsync())
                    {
                        FormularioEncuestaOpcionDTO opcion = new FormularioEncuestaOpcionDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdFormularioPregunta = Convert.ToInt32(reader["IdFormularioPregunta"]),
                            Valor = reader["Valor"].ToString(),
                            PlaceholderAdicional = reader["PlaceholderAdicional"] == DBNull.Value ? null : reader["PlaceholderAdicional"].ToString(),
                            Adicional = Convert.ToBoolean(reader["Adicional"]),
                            Orden = Convert.ToInt32(reader["Orden"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"])
                        };
                        opciones.Add(opcion);
                    }

                    foreach (var pregunta in formulario.preguntas)
                    {
                        pregunta.opciones = opciones.FindAll(x => x.IdFormularioPregunta == pregunta.Id);
                    }

                }*/


                return preguntas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<ClienteDTO>> ReadObtenerClientes(DbDataReader reader)
        {
            try
            {

                List<ClienteDTO> output = new List<ClienteDTO>();
                while (await reader.ReadAsync())
                {
                    ClienteDTO cliente = new ClienteDTO()
                    {
                        Id = Convert.ToInt32(reader["IdCliente"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Celular1 = DBNull.Value == reader["Celular1"] ? null :reader["Celular1"].ToString(),
                        FechaEncuesta = Convert.ToDateTime(reader["FechaEncuesta"]),
                        Encuesta = reader["Encuesta"].ToString(),
                    };
                    output.Add(cliente);
                }

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
