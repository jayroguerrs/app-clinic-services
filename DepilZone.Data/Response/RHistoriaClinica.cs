using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Response
{
    public class RHistoriaClinica
    {
        
        public Object RespuestaByHistoria(HistoriaClinicaDTO model)
        {
            try
            {
                var response = new
                {
                    FechaHistoria = model.FechaHistoria,
                    IdFichaAdmision = model.IdFichaAdmision,
                    IdCliente = model.IdCliente,
                    NombreCompleto = model.NombreCompleto,
                    Telefono = model.Telefono,
                    Domicilio = model.Domicilio,
                    Edad = model.Edad,
                    FechaNacimiento = model.FechaNacimiento,
                    EstadoCivil = model.EstadoCivil,
                    FototipoPiel = model.FototipoPiel,
                    TipoDocumento = model.TipoDocumento,
                    Documento = model.Documento,
                    Profesion = model.Profesion,
                    Email = model.Email,

                    AlergMedicamentos = model.AlergiasMedicamentosas,
                    AntecMedico = model.AntPerMedicos,
                    AntecQuirurgico = model.AntPerQuirurgicos,
                    AntecTrataFarmaco = model.AntTratFarmacologicos,
                    AntecTrataEstetic = model.AntTratEstPrev,

                    Patologias = model.Patologias,

                    Peso = model.Peso,
                    Altura = model.Altura,
                    NumeroHijos = model.NumeroHijos,

                    TipoCicatrizacion = model.TipoCicatrizacion,

                    BebeAlcohol = model.BebeAlcohol,

                    EsFumador = model.EsFumador,

                    TieneMedicacion = model.TieneMedicacion,
                    IndiqueMedicacion = model.IndiqueMedicacion,
                    ComunicacionCliente = model.ComunicacionCliente,

                    Ultimos12meses = model.Ultimos12meses,
                    AntecedenteFamiliar = model.AntecedenteFamiliar,
                    ReaccionAlergicaCutanea = model.ReaccionAlergicaCutanea,
                    EmbarazoSospecha = model.EmbarazoSospecha,
                    CigarrosAldia = model.CigarrosAldia,
                    IdMedioContacto = model.IdMedioContacto,
                    Genero = model.Genero,

                    Observaciones = model.Observaciones,
                    IdEstado = model.IdEstado,
                    ZonasConsultar = model.ZonasConsultar,
                    ZonasRealizar = model.ZonasRealizar
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Object RespuestaInsertar(HistoriaClinicaDTO model)
        {
            try
            {
                var response = new
                {
                    Id = model.Id,
                    IdCliente = model.IdCliente,
                    IdUsuarioRegistro = model.IdUsuarioRegistro,
                    FechaHistoria = model.FechaHistoria,
                    FechaRegistro = model.FechaRegistro
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<object> RespuestaListarByCliente(List<FichaAdmisionDTO> collection)
        {
            try
            {
                List<object> lista = new List<object>();
                foreach (FichaAdmisionDTO historia in collection)
                {
                    object response = new
                    {
                        Id = historia.Id,
                        IdCliente = historia.IdCliente,
                        FechaRegistro = historia.FechaRegistra,
                        FechaModifico = historia.FechaEdita,
                        UsuarioRegistro = historia.UsuarioRegistra,
                        UsuarioModifico = historia.UsuarioEdita
                    };
                    lista.Add(response);
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
