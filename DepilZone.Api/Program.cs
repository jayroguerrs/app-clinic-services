using DepilZone.Api.Controllers;
using DepilZone.Api.CustomFilter;
using DepilZone.Api.Hubs;
using DepilZone.Api.Services;
using DepilZone.Application.Implement;
using DepilZone.Application.Implement.C360;
using DepilZone.Application.Implement.Facturacion;
using DepilZone.Application.Implement.Test;
using DepilZone.Application.Interface;
using DepilZone.Application.Interface.C360;
using DepilZone.Application.Interface.Facturacion;
using DepilZone.Application.Interface.Test;
using DepilZone.Data;
using DepilZone.Data.Implement;
using DepilZone.Data.Implement.C360;
using DepilZone.Data.Implement.Facturacion;
using DepilZone.Data.Implement.Test;
using DepilZone.Data.ImplementC360;
using DepilZone.Data.Interface;
using DepilZone.Data.Interface.C360;
using DepilZone.Data.Interface.Facturacion;
using DepilZone.Data.Interface.Test;
using DepilZone.Domain;
using DepilZone.Domain.Implement;
using DepilZone.Domain.Implement.C360;
using DepilZone.Domain.Implement.Test;
using DepilZone.Domain.Interface;
using DepilZone.Domain.Interface.C360;
using DepilZone.Domain.Interface.Test;
using DepilZone.Entidad;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using static DepilZone.Api.Controllers.CajaController;
using static DepilZone.Api.Controllers.CitaController;
using static DepilZone.Api.Controllers.PreferenteController;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddSingleton(sp => builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found"));

// Configuración de servicios Login personalizados
builder.Services.Configure<configEnt>(builder.Configuration)
    .AddSingleton(sp => sp.GetRequiredService<IOptions<configEnt>>().Value);

// Configuración de SignalR
builder.Services.AddSignalR();

// Configuración de autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op =>
    {
        var key = builder.Configuration["JWT:Key"] ?? throw new InvalidOperationException("JWT key not configured.");
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        op.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = symmetricKey 
        };

        op.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Error de autenticación: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {

                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var result = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    message = "Acceso denegado. No tienes autorización para acceder a este recurso.",
                    statusCode = StatusCodes.Status401Unauthorized 

                });
                return context.Response.WriteAsync(result);
            }
        };
    });


builder.Services.AddSingleton<TokenService>(); // Registrar TokenService
//builder.Services.AddSingleton<List<string>>(new List<string> { "ADMN", "SIST" });

builder.Services.AddScoped<IChatService, ChatService>();

// Servicios de aplicación
// Test
builder.Services.AddTransient<IParameterSystemDat, ParameterSystemDat>();
builder.Services.AddTransient<IParameterSystemDom, ParameterSystemDom>();
builder.Services.AddTransient<IParameterSystemApp, ParameterSystemApp>();

// Form
builder.Services.AddTransient<IFormularioDat, FormularioDat>();
builder.Services.AddTransient<IFormularioDom, FormularioDom>();
builder.Services.AddTransient<IFormularioApp, FormularioApp>();

// Seguridad Auditoria
builder.Services.AddTransient<ISegAuditoriaDat, SegAuditoriaDat>();
builder.Services.AddTransient<ISegAuditoriaDom, SegAuditoriaDom>();
builder.Services.AddTransient<ISegAuditoriaApp, SegAuditoriaApp>();

//usuario
builder.Services.AddTransient<IUsuarioDat, UsuarioDat>();
builder.Services.AddTransient<IUsuarioDom, UsuarioDom>();
builder.Services.AddTransient<IUsuarioApp, UsuarioApp>();

builder.Services.AddTransient<IPerfilDat, PerfilDat>();
builder.Services.AddTransient<IPerfilDom, PerfilDom>();
builder.Services.AddTransient<IPerfilApp, PerfilApp>();

//cliente
builder.Services.AddTransient<IClienteDat, ClienteDat>();
builder.Services.AddTransient<IClienteDom, ClienteDom>();
builder.Services.AddTransient<IClienteApp, ClienteApp>();

//maquina
builder.Services.AddTransient<IMaquinaDat, MaquinaDat>();
builder.Services.AddTransient<IMaquinaDom, MaquinaDom>();
builder.Services.AddTransient<IMaquinaApp, MaquinaApp>();

//Ubicacion 
builder.Services.AddTransient<IUbicacionDat, UbicacionDat>();
builder.Services.AddTransient<IUbicacionDom, UbicacionDom>();
builder.Services.AddTransient<IUbicacionApp, UbicacionApp>();

//ZONAS
builder.Services.AddTransient<IZonaCorporalDat, ZonaCorporalDat>();
builder.Services.AddTransient<IZonaCorporalDom, ZonaCorporalDom>();
builder.Services.AddTransient<IZonaCorporalApp, ZonaCorporalApp>();

//SEDE
builder.Services.AddTransient<ISedeDat, SedeDat>();
builder.Services.AddTransient<ISedeDom, SedeDom>();
builder.Services.AddTransient<ISedeApp, SedeApp>();

//Promocion
builder.Services.AddTransient<IPromocionDat, PromocionDat>();
builder.Services.AddTransient<IPromocionDom, PromocionDom>();
builder.Services.AddTransient<IPromocionApp, PromocionApp>();

//Promocion Categoria
builder.Services.AddTransient<IPromocionCategoriaDat, PromocionCategoriaDat>();
builder.Services.AddTransient<IPromocionCategoriaDom, PromocionCategoriaDom>();
builder.Services.AddTransient<IPromocionCategoriaApp, PromocionCategoriaApp>();

//Promocion
builder.Services.AddTransient<IPromocionBloqueDat, PromocionBloqueDat>();
builder.Services.AddTransient<IPromocionBloqueDom, PromocionBloqueDom>();
builder.Services.AddTransient<IPromocionBloqueApp, PromocionBloqueApp>();

//PromocionZona 
builder.Services.AddTransient<IPromocionZonaDat, PromocionZonaDat>();
builder.Services.AddTransient<IPromocionZonaDom, PromocionZonaDom>();
builder.Services.AddTransient<IPromocionZonaApp, PromocionZonaApp>();

//IPromocionPrecioApp
builder.Services.AddTransient<IPromocionPrecioDat, PromocionPrecioDat>();
builder.Services.AddTransient<IPromocionPrecioDom, PromocionPrecioDom>();
builder.Services.AddTransient<IPromocionPrecioApp, PromocionPrecioApp>();

//Configuracion
builder.Services.AddTransient<IConfiguracionDat, ConfiguracionDat>();
builder.Services.AddTransient<IConfiguracionDom, ConfiguracionDom>();
builder.Services.AddTransient<IConfiguracionApp, ConfiguracionApp>();

//ConfiguracionRepl
builder.Services.AddTransient<IConfiguracionReplDat, ConfiguracionReplDat>();
builder.Services.AddTransient<IConfiguracionReplDom, ConfiguracionReplDom>();
builder.Services.AddTransient<IConfiguracionReplApp, ConfiguracionReplApp>();

//DOCUMENTOS
builder.Services.AddTransient<IDocumentoDat, DocumentoDat>();
builder.Services.AddTransient<IDocumentoDom, DocumentoDom>();
builder.Services.AddTransient<IDocumentoApp, DocumentoApp>();

//TIPOS DE DOCUMENTOS
builder.Services.AddTransient<IDocumentoTipoDat, DocumentoTipoDat>();
builder.Services.AddTransient<IDocumentoTipoDom, DocumentoTipoDom>();
builder.Services.AddTransient<IDocumentoTipoApp, DocumentoTipoApp>();

//DOCUMENTO PLANTILLAS
builder.Services.AddTransient<IDocumentoPlantillaDat, DocumentoPlantillaDat>();
builder.Services.AddTransient<IDocumentoPlantillaDom, DocumentoPlantillaDom>();
builder.Services.AddTransient<IDocumentoPlantillaApp, DocumentoPlantillaApp>();

//DOCUMENTOS DEL CLIENTE
builder.Services.AddTransient<IClienteDocumentoDat, ClienteDocumentoDat>();
builder.Services.AddTransient<IClienteDocumentoDom, ClienteDocumentoDom>();
builder.Services.AddTransient<IClienteDocumentoApp, ClienteDocumentoApp>();

//ENVIO DE CORREO API
builder.Services.AddTransient<IEmailDat, EmailDat>();
builder.Services.AddTransient<IEmailDom, EmailDom>();
builder.Services.AddTransient<IEmailApp, EmailApp>();

//TIPO DE CITA
builder.Services.AddTransient<ICitaTipoDat, CitaTipoDat>();
builder.Services.AddTransient<ICitaTipoDom, CitaTipoDom>();
builder.Services.AddTransient<ICitaTipoApp, CitaTipoApp>();

//PROMOCION PLANTILLA
builder.Services.AddTransient<IPromocionPlantillaDat, PromocionPlantillaDat>();
builder.Services.AddTransient<IPromocionPlantillaDom, PromocionPlantillaDom>();
builder.Services.AddTransient<IPromocionPlantillaApp, PromocionPlantillaApp>();

//Preferente
builder.Services.AddTransient<IPreferenteDat, PreferenteDat>();
builder.Services.AddTransient<IPreferenteDom, PreferenteDom>();
builder.Services.AddTransient<IPreferenteApp, PreferenteApp>();

//MEDIOCONTACTO
builder.Services.AddTransient<IMedioContactoDat, MedioContactoDat>();
builder.Services.AddTransient<IMedioContactoDom, MedioContactoDom>();
builder.Services.AddTransient<IMedioContactoApp, MedioContactoApp>();

//COMENTARIO
builder.Services.AddTransient<IComentarioDat, ComentarioDat>();
builder.Services.AddTransient<IComentarioDom, ComentarioDom>();
builder.Services.AddTransient<IComentarioApp, ComentarioApp>();

//ESTADO
builder.Services.AddTransient<IEstadoDat, EstadoDat>();
builder.Services.AddTransient<IEstadoDom, EstadoDom>();
builder.Services.AddTransient<IEstadoApp, EstadoApp>();

//Genero
builder.Services.AddTransient<IGeneroDat, GeneroDat>();
builder.Services.AddTransient<IGeneroDom, GeneroDom>();
builder.Services.AddTransient<IGeneroApp, GeneroApp>();

//Documento Identidad Tipo
builder.Services.AddTransient<IDocumentoIdentidadTipoDat, DocumentoIdentidadTipoDat>();
builder.Services.AddTransient<IDocumentoIdentidadTipoDom, DocumentoIdentidadTipoDom>();
builder.Services.AddTransient<IDocumentoIdentidadTipoApp, DocumentoIdentidadTipoApp>();

//Documento Identidad Tipo
builder.Services.AddTransient<ICitaTipoDat, CitaTipoDat>();
builder.Services.AddTransient<ICitaTipoDom, CitaTipoDom>();
builder.Services.AddTransient<ICitaTipoApp, CitaTipoApp>();

//MAQUINASEDE
builder.Services.AddTransient<IMaquinaSedeDat, MaquinaSedeDat>();
builder.Services.AddTransient<IMaquinaSedeDom, MaquinaSedeDom>();
builder.Services.AddTransient<IMaquinaSedeApp, MaquinaSedeApp>();

//MAQUINAMARCA
builder.Services.AddTransient<IMaquinaMarcaDat, MaquinaMarcaDat>();
builder.Services.AddTransient<IMaquinaMarcaDom, MaquinaMarcaDom>();
builder.Services.AddTransient<IMaquinaMarcaApp, MaquinaMarcaApp>();

//CITA
builder.Services.AddTransient<ICitaDat, CitaDat>();
builder.Services.AddTransient<ICitaDom, CitaDom>();
builder.Services.AddTransient<ICitaApp, CitaApp>();

//ANUNCIO
builder.Services.AddTransient<IAnuncioDat, AnuncioDat>();
builder.Services.AddTransient<IAnuncioDom, AnuncioDom>();
builder.Services.AddTransient<IAnuncioApp, AnuncioApp>();

//TIPOCLIENTE
builder.Services.AddTransient<DepilZone.Data.Interface.ITipoClienteDat, DepilZone.Data.Implement.TipoClienteDat>();
builder.Services.AddTransient<DepilZone.Data.Interface.ITipoClienteDom, DepilZone.Domain.Implement.TipoClienteDom>();
builder.Services.AddTransient<DepilZone.Application.Interface.ITipoClienteApp, DepilZone.Application.Implement.TipoClienteApp>();

//CHAT
builder.Services.AddTransient<IChatDat, ChatDat>();
builder.Services.AddTransient<IChatDom, ChatDom>();
builder.Services.AddTransient<IChatApp, ChatApp>();

//NOTAS
builder.Services.AddTransient<ICitaMensajeNotaDat, CitaMensajeNotaDat>();
builder.Services.AddTransient<ICitaMensajeNotaDom, CitaMensajeNotaDom>();
builder.Services.AddTransient<ICitaMensajeNotaApp, CitaMensajeNotaApp>();

//AVISOS
builder.Services.AddTransient<ICitaMensajeAvisoDat, CitaMensajeAvisoDat>();
builder.Services.AddTransient<ICitaMensajeAvisoDom, CitaMensajeAvisoDom>();
builder.Services.AddTransient<ICitaMensajeAvisosApp, CitaMensajeAvisoApp>();

//Detalle
builder.Services.AddTransient<ICitaMensajeDetalleDat, CitaMensajeDetalleDat>();
builder.Services.AddTransient<ICitaMensajeDetalleDom, CitaMensajeDetalleDom>();
builder.Services.AddTransient<ICitaMensajeDetalleApp, CitaMensajeDetalleApp>();

//Seguimiento Cita
builder.Services.AddTransient<ICitaSeguimientoDat, CitaSeguimientoDat>();
builder.Services.AddTransient<ICitaSeguimientoDom, CitaSeguimientoDom>();
builder.Services.AddTransient<ICitaSeguimientoApp, CitaSeguimientoApp>();

//DETALLE DE CITAS
builder.Services.AddTransient<ICitaDetalleDat, CitaDetalleDat>();
builder.Services.AddTransient<ICitaDetalleDom, CitaDetalleDom>();
builder.Services.AddTransient<ICitaDetalleApp, CitaDetalleApp>();

//DETALLE DE CITAS HORARIOS
builder.Services.AddTransient<IDetalleCitaHorarioDat, DetalleCitaHorarioDat>();
builder.Services.AddTransient<IDetalleCitaHorarioDom, DetalleCitaHorarioDom>();
builder.Services.AddTransient<IDetalleCitaHorarioApp, DetalleCitaHorarioApp>();

//CAJA
builder.Services.AddTransient<ICajaDat, CajaDat>();
builder.Services.AddTransient<ICajaDom, CajaDom>();
builder.Services.AddTransient<ICajaApp, CajaApp>();

builder.Services.AddTransient<IHlpReporteDat, HlpReporteDat>();
builder.Services.AddTransient<IHlpReporteDom, HlpReporteDom>();
builder.Services.AddTransient<IHlpReporteApp, HlpReporteApp>();

//POS
builder.Services.AddTransient<IPosDat, PosDat>();
builder.Services.AddTransient<IPosDom, PosDom>();

//VENTA
builder.Services.AddTransient<IVentaDat, VentaDat>();
builder.Services.AddTransient<IVentaDom, VentaDom>();
builder.Services.AddTransient<IVentaApp, VentaApp>();

//EMPRESA
builder.Services.AddTransient<IEmpresaDat, EmpresaDat>();
builder.Services.AddTransient<IEmpresaDom, EmpresaDom>();
builder.Services.AddTransient<IEmpresaApp, EmpresaApp>();

//HISTORIA CLINICA
builder.Services.AddTransient<IHistoriaClinicaDat, HistoriaClinicaDat>();
builder.Services.AddTransient<IHistoriaClinicaDom, HistoriaClinicaDom>();
builder.Services.AddTransient<IHistoriaClinicaApp, HistoriaClinicaApp>();

//EVOLUCION DEL TRATAMIENTO
builder.Services.AddTransient<IEvolucionTratamientoDat, EvolucionTratamientoDat>();
builder.Services.AddTransient<IEvolucionTratamientoDom, EvolucionTratamientoDom>();
builder.Services.AddTransient<IEvolucionTratamientoApp, EvolucionTratamientoApp>();

//ROLES
builder.Services.AddTransient<IRolesDat, RolesDat>();
builder.Services.AddTransient<IRolesDom, RolesDom>();
builder.Services.AddTransient<IRolesApp, RolesApp>();

//MENU
builder.Services.AddTransient<IMenuDat, MenuDat>();
builder.Services.AddTransient<IMenuDom, MenuDom>();
builder.Services.AddTransient<IMenuApp, MenuApp>();

//CITA ASIGNADA
builder.Services.AddTransient<ICitaAsignadaDat, CitaAsignadaDat>();
builder.Services.AddTransient<ICitaAsignadaDom, CitaAsignadaDom>();
builder.Services.AddTransient<ICitaAsignadaApp, CitaAsignadaApp>();

//CLIENTE RECURRENTE
builder.Services.AddTransient<IClienteRecurrenteDat, ClienteRecurrenteDat>();
builder.Services.AddTransient<IClienteRecurrenteDom, ClienteRecurrenteDom>();
builder.Services.AddTransient<IClienteRecurrenteApp, ClienteRecurrenteApp>();

//REPORTE ZONAS
builder.Services.AddTransient<IReporteZonasDat, ReporteZonasDat>();
builder.Services.AddTransient<IReporteZonasDom, ReporteZonasDom>();
builder.Services.AddTransient<IReporteZonasApp, ReporteZonasApp>();

//APERTURAYCIERRE
builder.Services.AddTransient<IAperturaDat, AperturaDat>();
builder.Services.AddTransient<IAperturaDom, AperturaDom>();
builder.Services.AddTransient<IAperturaApp, AperturaApp>();

//TURNO
builder.Services.AddTransient<ITurnoDat, TurnoDat>();
builder.Services.AddTransient<ITurnoDom, TurnoDom>();
builder.Services.AddTransient<ITurnoApp, TurnoApp>();

//EGRESOS
builder.Services.AddTransient<IEgresoDat, EgresoDat>();
builder.Services.AddTransient<IEgresoDom, EgresoDom>();
builder.Services.AddTransient<IEgresoApp, EgresoApp>();

//TIPOCOMPROBANTE
builder.Services.AddTransient<ITipoComprobanteDat, TipoComprobanteDat>();
builder.Services.AddTransient<ITipoComprobanteDom, TipoComprobanteDom>();
builder.Services.AddTransient<ITipoComprobanteApp, TipoComprobanteApp>();

//LIBRORECLAMACION
builder.Services.AddTransient<ILibroReclamacionDat, LibroReclamacionDat>();
builder.Services.AddTransient<ILibroReclamacionDom, LibroReclamacionDom>();
builder.Services.AddTransient<ILibroReclamacionApp, LibroReclamacionApp>();
//LIBRORECLAMACION
builder.Services.AddTransient<IParametroSistemaDat, ParametroSistemaDat>();
builder.Services.AddTransient<IParametroSistemaDom, ParametroSistemaDom>();
builder.Services.AddTransient<IParametroSistemaApp, ParametroSistemaApp>();
//PATOLOGIA
builder.Services.AddTransient<IPatologiaDat, PatologiaDat>();
builder.Services.AddTransient<IPatologiaDom, PatologiaDom>();
builder.Services.AddTransient<IPatologiaApp, PatologiaApp>();
//FICHAADMISION
builder.Services.AddTransient<IFichaAdmisionDat, FichaAdmisionDat>();
builder.Services.AddTransient<IFichaAdmisionDom, FichaAdmisionDom>();
builder.Services.AddTransient<IFichaAdmisionApp, FichaAdmisionApp>();
//EVOLUCIONCITAMENSUAL
builder.Services.AddTransient<IEvolucionCitaMensualDat, EvolucionCitaMensualDat>();
builder.Services.AddTransient<IEvolucionCitaMensualDom, EvolucionCitaMensualDom>();
builder.Services.AddTransient<IEvolucionCitaMensualApp, EvolucionCitaMensualApp>();


// EQUIPO LASER
builder.Services.AddTransient<IEquipoLaserDat, EquipoLaserDat>();
builder.Services.AddTransient<IEquipoLaserDom, EquipoLaserDom>();
builder.Services.AddTransient<IEquipoLaserApp, EquipoLaserApp>();

// CITA MOTIVO ESTADO
builder.Services.AddTransient<ICitaEstadoMotivoDat, CitaEstadoMotivoDat>();
builder.Services.AddTransient<ICitaEstadoMotivoDom, CitaEstadoMotivoDom>();
builder.Services.AddTransient<ICitaEstadoMotivoApp, CitaEstadoMotivoApp>();

// CITA MOTIVO
builder.Services.AddTransient<ICitaMotivoDat, CitaMotivoDat>();
builder.Services.AddTransient<ICitaMotivoDom, CitaMotivoDom>();
builder.Services.AddTransient<ICitaMotivoApp, CitaMotivoApp>();

// ALTERNATIVA MEDICION
builder.Services.AddTransient<IAlternativaMedicionDat, AlternativaMedicionDat>();
builder.Services.AddTransient<IAlternativaMedicionDom, AlternativaMedicionDom>();
builder.Services.AddTransient<IAlternativaMedicionApp, AlternativaMedicionApp>();

// CITA MEDICION
builder.Services.AddTransient<ICitaMedicionDat, CitaMedicionDat>();
builder.Services.AddTransient<ICitaMedicionDom, CitaMedicionDom>();
builder.Services.AddTransient<ICitaMedicionApp, CitaMedicionApp>();

// TIPO MEDICION
builder.Services.AddTransient<ITipoMedicionDat, TipoMedicionDat>();
builder.Services.AddTransient<ITipoMedicionDom, TipoMedicionDom>();
builder.Services.AddTransient<ITipoMedicionApp, TipoMedicionApp>();

// CLIENTE CONTRATO
builder.Services.AddTransient<IClienteContratoDat, ClienteContratoDat>();
builder.Services.AddTransient<IClienteContratoDom, ClienteContratoDom>();
builder.Services.AddTransient<IClienteContratoApp, ClienteContratoApp>();

// CLIENTE ENCUESTA
builder.Services.AddTransient<IClienteEncuestaDat, ClienteEncuestaDat>();
builder.Services.AddTransient<IClienteEncuestaDom, ClienteEncuestaDom>();
builder.Services.AddTransient<IClienteEncuestaApp, ClienteEncuestaApp>();

// CUPONES
builder.Services.AddTransient<IDescuentoDat, DescuentoDat>();
builder.Services.AddTransient<IDescuentoDom, DescuentoDom>();
builder.Services.AddTransient<IDescuentoApp, DescuentoApp>();

// FORMULARIO ENCUESTA
builder.Services.AddTransient<IFormularioEncuestaDat, FormularioEncuestaDat>();
builder.Services.AddTransient<IFormularioEncuestaDom, FormularioEncuestaDom>();
builder.Services.AddTransient<IFormularioEncuestaApp, FormularioEncuestaApp>();


// FORMULARIO ENCUESTA
builder.Services.AddTransient<IReporteCitaDat, ReporteCitaDat>();
builder.Services.AddTransient<IReporteCitaDom, ReporteCitaDom>();
builder.Services.AddTransient<IReporteCitaApp, ReporteCitaApp>();


// FORMULARIO CLIENTE INCIDENCIA
builder.Services.AddTransient<IClienteIncidenciaDat, ClienteIncidenciaDat>();
builder.Services.AddTransient<IClienteIncidenciaDom, ClienteIncidenciaDom>();
builder.Services.AddTransient<IClienteIncidenciaApp, ClienteIncidenciaApp>();

// FORMULARIO INCIDENCIA
builder.Services.AddTransient<IIncidenciaDat, IncidenciaDat>();
builder.Services.AddTransient<IIncidenciaDom, IncidenciaDom>();
builder.Services.AddTransient<IIncidenciaApp, IncidenciaApp>();

// SERVICIOS
builder.Services.AddTransient<DepilZone.Data.Interface.IServicioDat, DepilZone.Data.Implement.ServicioDat>();
builder.Services.AddTransient<DepilZone.Data.Interface.IServicioDom, DepilZone.Domain.Implement.ServicioDom>();
builder.Services.AddTransient<DepilZone.Application.Interface.IServicioApp, DepilZone.Application.Implement.ServicioApp>();

// CLIENTE ACCESO
builder.Services.AddTransient<IClienteAccesoDat, ClienteAccesoDat>();
builder.Services.AddTransient<IClienteAccesoDom, ClienteAccesoDom>();
builder.Services.AddTransient<IClienteAccesoApp, ClienteAccesoApp>();

// Tecnologias
builder.Services.AddTransient<ITecnologiaDat, TecnologiaDat>();
builder.Services.AddTransient<ITecnologiaDom, TecnologiaDom>();
builder.Services.AddTransient<ITecnologiaApp, TecnologiaApp>();

// Tratamientos
builder.Services.AddTransient<ITratamientoDat, TratamientoDat>();
builder.Services.AddTransient<ITratamientoDom, TratamientoDom>();
builder.Services.AddTransient<ITratamientoApp, TratamientoApp>();

// Tratamientos
builder.Services.AddTransient<IReporteClienteDat, ReporteClienteDat>();
builder.Services.AddTransient<IReporteClienteDom, ReporteClienteDom>();
builder.Services.AddTransient<IReporteClienteApp, ReporteClienteApp>();




/** 
 * CORPORAL 360 - START
 * **/

builder.Services.AddTransient<IUtilitarioDat, UtilitarioDat>();
builder.Services.AddTransient<IUtilitarioDom, UtilitarioDom>();
builder.Services.AddTransient<IUtilitarioApp, UtilitarioApp>();


// CRONOGRAMA CITA
builder.Services.AddTransient<ICronogramaCitaDat, CronogramaCitaDat>();
builder.Services.AddTransient<ICronogramaCitaDom, CronogramaCitaDom>();
builder.Services.AddTransient<ICronogramaCitaApp, CronogramaCitaApp>();


// MAQUINA SEDE
builder.Services.AddTransient<IMaquinaSede360Dat, MaquinaSede360Dat>();
builder.Services.AddTransient<IMaquinaSede360Dom, MaquinaSede360Dom>();
builder.Services.AddTransient<IMaquinaSede360App, MaquinaSede360App>();

// SERVICIOS
builder.Services.AddTransient<DepilZone.Data.Interface.C360.IServicioDat, DepilZone.Data.ImplementC360.ServicioDat>();
builder.Services.AddTransient<DepilZone.Data.Interface.C360.IServicioDom, DepilZone.Domain.Implement.C360.ServicioDom>();
builder.Services.AddTransient<DepilZone.Application.Interface.C360.IServicioApp, DepilZone.Application.Implement.C360.ServicioApp>();

// CASOS
builder.Services.AddTransient<ICasoDat, CasoDat>();
builder.Services.AddTransient<ICasoDom, CasoDom>();
builder.Services.AddTransient<ICasoApp, CasoApp>();

// ZONAS
builder.Services.AddTransient<IZonaDat, ZonaDat>();
builder.Services.AddTransient<IZonaDom, ZonaDom>();
builder.Services.AddTransient<IZonaApp, ZonaApp>();

// CASOS
builder.Services.AddTransient<ITipoCitaDat, TipoCitaDat>();
builder.Services.AddTransient<ITipoCitaDom, TipoCitaDom>();
builder.Services.AddTransient<ITipoCitaApp, TipoCitaApp>();

// CATEGORIA
builder.Services.AddTransient<ICategoriaDat, CategoriaDat>();
builder.Services.AddTransient<ICategoriaDom, CategoriaDom>();
builder.Services.AddTransient<ICategoriaApp, CategoriaApp>();

// SALAS
builder.Services.AddTransient<ISalaDat, SalaDat>();
builder.Services.AddTransient<ISalaDom, SalaDom>();
builder.Services.AddTransient<ISalaApp, SalaApp>();

// TIPO CLIENTE
builder.Services.AddTransient<DepilZone.Data.Interface.C360.ITipoClienteDat, DepilZone.Data.ImplementC360.TipoClienteDat>();
builder.Services.AddTransient<DepilZone.Data.Interface.C360.ITipoClienteDom, DepilZone.Domain.Implement.C360.TipoClienteDom>();
builder.Services.AddTransient<DepilZone.Application.Interface.C360.ITipoClienteApp, DepilZone.Application.Implement.C360.TipoClienteApp>();


// CITA 360DepilZone.
builder.Services.AddTransient<ICita360Dat, Cita360Dat>();
builder.Services.AddTransient<ICita360Dom, Cita360Dom>();
builder.Services.AddTransient<ICita360App, Cita360App>();

// CITA DETALLE 360
builder.Services.AddTransient<ICitaDetalle360Dat, CitaDetalle360Dat>();
builder.Services.AddTransient<ICitaDetalle360Dom, CitaDetalle360Dom>();
builder.Services.AddTransient<ICitaDetalle360App, CitaDetalle360App>();

// CITA SEGUIMIENTO 360
builder.Services.AddTransient<ICitaSeguimiento360Dat, CitaSeguimiento360Dat>();
builder.Services.AddTransient<ICitaSeguimiento360Dom, CitaSeguimiento360Dom>();
builder.Services.AddTransient<ICitaSeguimiento360App, CitaSeguimiento360App>();

// CRONOGRAMA SEGUIMIENTO
builder.Services.AddTransient<ICronogramaSeguimientoDat, CronogramaSeguimientoDat>();
builder.Services.AddTransient<ICronogramaSeguimientoDom, CronogramaSeguimientoDom>();
builder.Services.AddTransient<ICronogramaSeguimientoApp, CronogramaSeguimientoApp>();

//Preferente
builder.Services.AddTransient<IReportePreferenteDat, ReportePreferenteDat>();
builder.Services.AddTransient<IReportePreferenteDom, ReportePreferenteDom>();
builder.Services.AddTransient<IReportePreferenteApp, ReportePreferenteApp>();


//Historial Operaciones
builder.Services.AddTransient<IHistorialOperacionesDat, HistorialOperacionesDat>();
builder.Services.AddTransient<IHistorialOperacionesDom, HistorialOperacionesDom>();
builder.Services.AddTransient<IHistorialOperacionesApp, HistorialOperacionesApp>();


builder.Services.AddTransient<IPlantillaDat, PlantillaDat>();
builder.Services.AddTransient<IPlantillaDom, PlantillaDom>();
builder.Services.AddTransient<IPlantillaApp, PlantillaApp>();


builder.Services.AddTransient<IFacturaSerieDat, FacturaSerieDat>();
builder.Services.AddTransient<IFacturaSerieDom, FacturaSerieDom>();
builder.Services.AddTransient<IFacturaSerieApp, FacturaSerieApp>();

//Permisos
builder.Services.AddTransient<IPermisosDat, PermisosDat>();
builder.Services.AddTransient<IPermisosDom, PermisosDom>();
builder.Services.AddTransient<IPermisosApp, PermisosApp>();

/** 
 * CORPORAL 360 - END
 * **/


/***************************************************************
 * FACTURACION - START
 */

builder.Services.AddTransient<IFacturaTokenDat, FacturaTokenDat>();
builder.Services.AddTransient<IFacturaTokenDom, FacturaTokenDom>();
builder.Services.AddTransient<IFacturaTokenApp, FacturaTokenApp>();


builder.Services.AddTransient<IFacturaTipoDocumentoDat, FacturaTipoDocumentoDat>();
builder.Services.AddTransient<IFacturaTipoDocumentoDom, FacturaTipoDocumentoDom>();
builder.Services.AddTransient<IFacturaTipoDocumentoApp, FacturaTipoDocumentoApp>();


builder.Services.AddTransient<IFacturaDatosClienteDat, FacturaDatosClienteDat>();
builder.Services.AddTransient<IFacturaDatosClienteDom, FacturaDatosClienteDom>();
builder.Services.AddTransient<IFacturaDatosClienteApp, FacturaDatosClienteApp>();


builder.Services.AddTransient<IFacturaTipoIgvDat, FacturaTipoIgvDat>();
builder.Services.AddTransient<IFacturaTipoIgvDom, FacturaTipoIgvDom>();
builder.Services.AddTransient<IFacturaTipoIgvApp, FacturaTipoIgvApp>();


builder.Services.AddTransient<IFacturaPorcentajeIgvDat, FacturaPorcentajeIgvDat>();
builder.Services.AddTransient<IFacturaPorcentajeIgvDom, FacturaPorcentajeIgvDom>();
builder.Services.AddTransient<IFacturaPorcentajeIgvApp, FacturaPorcentajeIgvApp>();


builder.Services.AddTransient<IFacturaTransaccionSunatDat, FacturaTransaccionSunatDat>();
builder.Services.AddTransient<IFacturaTransaccionSunatDom, FacturaTransaccionSunatDom>();
builder.Services.AddTransient<IFacturaTransaccionSunatApp, FacturaTransaccionSunatApp>();


builder.Services.AddTransient<IFacturaMonedaDat, FacturaMonedaDat>();
builder.Services.AddTransient<IFacturaMonedaDom, FacturaMonedaDom>();
builder.Services.AddTransient<IFacturaMonedaApp, FacturaMonedaApp>();


builder.Services.AddTransient<IFacturacionElectronicaDat, FacturacionElectronicaDat>();
builder.Services.AddTransient<IFacturacionElectronicaDom, FacturacionElectronicaDom>();
builder.Services.AddTransient<IFacturacionElectronicaApp, FacturacionElectronicaApp>();

builder.Services.AddTransient<IComprobanteAnulacionDat, ComprobanteAnulacionDat>();
builder.Services.AddTransient<IComprobanteAnulacionDom, ComprobanteAnulacionDom>();
builder.Services.AddTransient<IComprobanteAnulacionApp, ComprobanteAnulacionApp>();


builder.Services.AddTransient<IComprobanteUnidadMedidaDat, ComprobanteUnidadMedidaDat>();
builder.Services.AddTransient<IComprobanteUnidadMedidaDom, ComprobanteUnidadMedidaDom>();
builder.Services.AddTransient<IComprobanteUnidadMedidaApp, ComprobanteUnidadMedidaApp>();


builder.Services.AddTransient<IComprobanteTipoNotaCreditoDat, ComprobanteTipoNotaCreditoDat>();
builder.Services.AddTransient<IComprobanteTipoNotaCreditoDom, ComprobanteTipoNotaCreditoDom>();
builder.Services.AddTransient<IComprobanteTipoNotaCreditoApp, ComprobanteTipoNotaCreditoApp>();


builder.Services.AddTransient<IComprobanteTipoNotaDebitoDat, ComprobanteTipoNotaDebitoDat>();
builder.Services.AddTransient<IComprobanteTipoNotaDebitoDom, ComprobanteTipoNotaDebitoDom>();
builder.Services.AddTransient<IComprobanteTipoNotaDebitoApp, ComprobanteTipoNotaDebitoApp>();


builder.Services.AddTransient<IComprobanteSerieDat, ComprobanteSerieDat>();
builder.Services.AddTransient<IComprobanteSerieDom, ComprobanteSerieDom>();
builder.Services.AddTransient<IComprobanteSerieApp, ComprobanteSerieApp>();

builder.Services.AddTransient<IComprobanteEntidadTipoPagoDat, ComprobanteEntidadTipoPagoDat>();
builder.Services.AddTransient<IComprobanteEntidadTipoPagoDom, ComprobanteEntidadTipoPagoDom>();
builder.Services.AddTransient<IComprobanteEntidadTipoPagoApp, ComprobanteEntidadTipoPagoApp>();


builder.Services.AddTransient<IComprobanteElectronicoDat, ComprobanteElectronicoDat>();
builder.Services.AddTransient<IComprobanteElectronicoDom, ComprobanteElectronicoDom>();
builder.Services.AddTransient<IComprobanteElectronicoApp, ComprobanteElectronicoApp>();


builder.Services.AddTransient<IComprobanteElectronicoAnuladoDat, ComprobanteElectronicoAnuladoDat>();
builder.Services.AddTransient<IComprobanteElectronicoAnuladoDom, ComprobanteElectronicoAnuladoDom>();
builder.Services.AddTransient<IComprobanteElectronicoAnuladoApp, ComprobanteElectronicoAnuladoApp>();

builder.Services.AddTransient<IMaquinaSedePerfilDat, MaquinaSedePerfilDat>();
builder.Services.AddTransient<IMaquinaSedePerfilDom, MaquinaSedePerfilDom>();
builder.Services.AddTransient<IMaquinaSedePerfilApp, MaquinaSedePerfilApp>();


builder.Services.AddTransient<IAtencionClienteDat, AtencionClienteDat>();
builder.Services.AddTransient<IAtencionClienteDom, AtencionClienteDom>();
builder.Services.AddTransient<IAtencionClienteApp, AtencionClienteApp>();


builder.Services.AddTransient<IZonaTratamientoDat, ZonaTratamientoDat>();
builder.Services.AddTransient<IZonaTratamientoDom, ZonaTratamientoDom>();
builder.Services.AddTransient<IZonaTratamientoApp, ZonaTratamientoApp>();


builder.Services.AddTransient<IZonaSesionTratamientoDat, ZonaSesionTratamientoDat>();
builder.Services.AddTransient<IZonaSesionTratamientoDom, ZonaSesionTratamientoDom>();
builder.Services.AddTransient<IZonaSesionTratamientoApp, ZonaSesionTratamientoApp>();


builder.Services.AddTransient<IPreferenteAtencionCategoriaDat, PreferenteAtencionCategoriaDat>();
builder.Services.AddTransient<IPreferenteAtencionCategoriaDom, PreferenteAtencionCategoriaDom>();
builder.Services.AddTransient<IPreferenteAtencionCategoriaApp, PreferenteAtencionCategoriaApp>();


builder.Services.AddTransient<IPreferenteAtencionOpcionDat, PreferenteAtencionOpcionDat>();
builder.Services.AddTransient<IPreferenteAtencionOpcionDom, PreferenteAtencionOpcionDom>();
builder.Services.AddTransient<IPreferenteAtencionOpcionApp, PreferenteAtencionOpcionApp>();


builder.Services.AddTransient<IClienteAsignadoDat, ClienteAsignadoDat>();
builder.Services.AddTransient<IClienteAsignadoDom, ClienteAsignadoDom>();
builder.Services.AddTransient<IClienteAsignadoApp, ClienteAsignadoApp>();

builder.Services.AddTransient<IClienteAsignadoEstadoDat, ClienteAsignadoEstadoDat>();
builder.Services.AddTransient<IClienteAsignadoEstadoDom, ClienteAsignadoEstadoDom>();
builder.Services.AddTransient<IClienteAsignadoEstadoApp, ClienteAsignadoEstadoApp>();


builder.Services.AddTransient<IPreferenteHistorialDat, PreferenteHistorialDat>();
builder.Services.AddTransient<IPreferenteHistorialDom, PreferenteHistorialDom>();
builder.Services.AddTransient<IPreferenteHistorialApp, PreferenteHistorialApp>();

//Nuevos servicios 19/12/2024 
builder.Services.AddTransient<IControlDeCitaDat, ControlDeCitaDat>();
builder.Services.AddTransient<IControlDeCitaDom, ControlDeCitaDom>();
builder.Services.AddTransient<IControlDeCitaApp, ControlDeCitaApp>();


//CCVOX Endpoints
builder.Services.AddTransient<ICcvoxDat, CcvoxDat>();
builder.Services.AddTransient<ICcvoxDom, CcvoxDom>();
builder.Services.AddTransient<ICcvoxApp, CcvoxApp>();

//Busqueda Cliente Nuevo Dashboard
builder.Services.AddTransient<IClienteBusquedaCitasDat, ClienteBusquedaCitasDat>();
builder.Services.AddTransient<IClienteBusquedaCitasDom, ClienteBusquedaCitasDom>();
builder.Services.AddTransient<IClienteBusquedaCitasApp, ClienteBusquedaCitasApp>();

/**
* FACTURACION - END
**************************************************************/
//builder.Services.AddScoped<LandingFilterAttribute>();

// =============================================================
// ✅ SIGNALR
// =============================================================
builder.Services.AddTransient<SignalHub, SignalHub>();

// =============================================================
// ✅ CONTROLADORES Y SERVICIOS HOSTEADOS
// =============================================================
builder.Services.AddTransient<ChatController, ChatController>();
builder.Services.AddTransient<PreferenteController, PreferenteController>();
builder.Services.AddControllers();

builder.Services.AddHostedService<PreferenteMonitor>();
builder.Services.AddHostedService<MyTestHostedService>();
builder.Services.AddHostedService<AbrirCajaHostedService>();
builder.Services.AddHostedService<CerrarCajaHostedService>();

// =============================================================
// ✅ CORS CONFIGURATION
// =============================================================
var allowedOrigins = new[]
{
    "https://clinic.depilzone.net",
    "https://landing.depilzone.com.pe",
    "https://test.depilzone.com.pe",
    "http://localhost:4200" // habilitado solo para desarrollo
};

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// =============================================================
// ✅ SWAGGER CONFIGURATION
// =============================================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DepilZone API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT con el prefijo Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    c.OperationFilter<Add401Response>();
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// =============================================================
// ✅ VERIFICAR CONEXIÓN A BASE DE DATOS
// =============================================================
using (var scope = app.Services.CreateScope())
{
    var connectionString = scope.ServiceProvider.GetRequiredService<string>();
    using SqlConnection conn = new(connectionString);
    try
    {
        await conn.OpenAsync();
        Console.WriteLine("✅ Conexión a la base de datos establecida exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error al intentar conectar a la base de datos: {ex.Message}");
    }
}

// =============================================================
// ✅ SWAGGER & ENTORNO
// =============================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var swaggerProvider = app.Services.GetRequiredService<ISwaggerProvider>();
    var swagger = swaggerProvider.GetSwagger("v1");

    using (var writer = new StringWriter())
    {
        var yamlWriter = new OpenApiYamlWriter(writer);
        swagger.SerializeAsV3(yamlWriter);
        System.IO.File.WriteAllText("swagger.yaml", writer.ToString());
    }
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

// =============================================================
// ✅ PIPELINE PRINCIPAL
// =============================================================
app.UseHttpsRedirection();
app.UseRouting();

// ⚠️ Importante: aplicar CORS antes del middleware personalizado
app.UseCors("AllowSpecificOrigins");

// =============================================================
// ✅ MIDDLEWARE DE VALIDACIÓN DE ORIGEN Y HEADERS PERSONALIZADOS
// =============================================================
app.Use(async (context, next) =>
{
    var expectedVersion = "3.2.1"; // versión actual del front Angular
    var expectedAppKey = "5ZbxPw{ert[0g3|igy#*nbXH%jb?s5"; // clave compartida

    var origin = context.Request.Headers["Origin"].ToString();
    var appVersion = context.Request.Headers["App-Version"].ToString();
    var appKey = context.Request.Headers["Backend"].ToString();

    // 1️⃣ Permitir automáticamente peticiones preflight (OPTIONS)
    if (context.Request.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
    {
        context.Response.StatusCode = StatusCodes.Status204NoContent;
        return;
    }

    // 2️⃣ Validar el origen (solo si existe)
    if (!string.IsNullOrEmpty(origin) && !allowedOrigins.Contains(origin))
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Origen no autorizado.");
        return;
    }

    // 3️⃣ Validar headers personalizados (App-Version y Backend)
    if (string.IsNullOrEmpty(appKey) || appKey != expectedAppKey)
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Aplicación no autorizada.");
        return;
    }

    if (string.IsNullOrEmpty(appVersion) || appVersion != expectedVersion)
    {
        context.Response.StatusCode = StatusCodes.Status426UpgradeRequired;
        await context.Response.WriteAsync("Versión del cliente no permitida. Actualiza tu aplicación.");
        return;
    }

    await next();
});

// =============================================================
// ✅ AUTENTICACIÓN Y RUTEO
// =============================================================
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalHub>("apiSignal");

app.Run();
