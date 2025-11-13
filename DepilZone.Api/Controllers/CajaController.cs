using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCrontab;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CajaController : Controller
    {
        private readonly ICajaApp _caja;
        private readonly IHlpReporteApp _tipRepo;
        public CajaController(ICajaApp CajaApp, IHlpReporteApp hlpRepoApp)
        {
            this._caja = CajaApp;
            this._tipRepo = hlpRepoApp;
        }

        [HttpGet]
        [CustomFilter("000193")]
        public async Task<IEnumerable<CajaEnt>> Get()
        {
            return await _caja.Obtener();
        }
        [HttpGet("{id}")]
        [CustomFilter("000194")]
        public async Task<CajaEnt> Get(int id)
        {
            return await _caja.ObtenerById(id);
        }
        [HttpPost]
        [CustomFilter("000195")]
        public async Task<Respuesta<CajaEnt>> Post(CajaEnt model)
        {
            return await _caja.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000196")]
        public async Task<Respuesta<CajaEnt>> Put(CajaEnt model)
        {
            return await _caja.Modificar(model);
        }
        [HttpPut("abrirCerrar")]
        [CustomFilter("000197")]
        public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
        {
            return await _caja.AbrirCerrar(model);
        }
        [HttpGet("search/{str}")]
        [CustomFilter("000198")]
        public async Task<IEnumerable<CajaEnt>> LikeNombre(string str)
        {
            return await _caja.ObtenerByLikeNombre(str);
        }
        [HttpGet("consultarAperturaCaja/{idsede}")]
        [CustomFilter("000199")]
        public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede)
        {
            return await _caja.ConsultarAperturaCaja(idsede);
        }
        [HttpGet("cuadre/{fecha}/{idCaja}/{idUsuario}")]
        [CustomFilter("000200")]
        public async Task<ActionResult> CuadreDeCaja(DateTime fecha, int idCaja, int idUsuario)
        {
            try
            {
                var data = await _caja.CuadreDeCaja(fecha, idCaja, idUsuario);
                return Ok(new
                {
                    data = data,
                    error = new { },
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }

        }
        [HttpGet("verificaEstado/{fecha}/{idCaja}")]
        [CustomFilter("000201")]
        public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
        {
            return await _caja.VerificaEstadoCaja(fecha, idCaja);
        }
        [HttpGet("seguimiento-diario/{fecha}/{idUsuario}")]
        [CustomFilter("000202")]
        public async Task<ActionResult> SeguimientoDiario(DateTime fecha, int idUsuario)
        {
            try
            {
                var data = await _caja.SeguimientoDiario(fecha, idUsuario);
                return Ok(new
                {
                    data = data,
                    error = new { },
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }

        }
        [HttpGet("tipo-reporte")]
        [CustomFilter("000203")]
        public async Task<ActionResult> lstTipoReporte()
        {
            try
            {                
                var data = await _tipRepo.lstTipRepo();

                return Ok(new
                {
                    data = data,
                    error = new { },
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        // abrir automaticamente la caja
        public class AbrirCajaHostedService : BackgroundService
        {
            private CrontabSchedule _schedule;
            private DateTime _nextRun;
            //private readonly IServicioApp _servicioApp;
            private readonly ICajaApp _cajaApp;

            private string Schedule => "* 0-0 6 * * *"; //Todos los dias a las 6:00 de la mañana


            public AbrirCajaHostedService(ICajaApp ICajaApp)
            {
                _cajaApp = ICajaApp;


                _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                do
                {
                    var now = DateTime.Now;
                    var nextrun = _schedule.GetNextOccurrence(now);
                    if (now > _nextRun)
                    {
                        try
                        {
                            IEnumerable<CajaEnt> cajas = await _cajaApp.Obtener();

                            // ✅ Apertura regular si está cerrada (a la hora programada)
                            foreach (CajaEnt caja in cajas)
                            {
                                if (caja.Apertura == "Cerrada")
                                {
                                    CajaEnt cajaApertura = new CajaEnt()
                                    {
                                        AbrirCaja = true,
                                        FechaHoraAperturaStr = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"),
                                        Id = caja.Id,
                                        IdUsuarioResponsable = 543,
                                        SaldoInicial = 0,
                                        Turno = 1
                                    };

                                    await _cajaApp.AbrirCerrar(cajaApertura);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                    }

                    await Task.Delay(30000, stoppingToken); // 30 segundos
                }
                while (!stoppingToken.IsCancellationRequested);
            }

        }

        public class CerrarCajaHostedService : BackgroundService
        {
            private CrontabSchedule _schedule;
            private DateTime _nextRun;
            //private readonly IServicioApp _servicioApp;
            private readonly ICajaApp _cajaApp;

            private string Schedule => "* 0-59 5 * * *"; //Todos los dias a las 5:59 de la mañana


            public CerrarCajaHostedService(ICajaApp ICajaApp)
            {
                _cajaApp = ICajaApp;


                _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                do
                {
                    var now = DateTime.Now;
                    var nextrun = _schedule.GetNextOccurrence(now);
                    if (now > _nextRun)
                    {
                        try
                        {
                            IEnumerable<CajaEnt> cajas = await _cajaApp.Obtener();

                            // ✅ Apertura regular si está cerrada (a la hora programada)
                            foreach (CajaEnt caja in cajas)
                            {
                                if (caja.Apertura == "Abierta")
                                {
                                    CajaEnt cajaApertura = new CajaEnt()
                                    {
                                        AbrirCaja = false,
                                        FechaHoraAperturaStr = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"),
                                        Id = caja.Id,
                                        IdUsuarioResponsable = 543,
                                        SaldoInicial = 0,
                                        Turno = 1
                                    };

                                    await _cajaApp.AbrirCerrar(cajaApertura);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                    }

                    await Task.Delay(30000, stoppingToken); // 30 segundos
                }
                while (!stoppingToken.IsCancellationRequested);
            }

        }



        [HttpPost("upload")]
        [CustomFilter("000204")]
        public async Task<IActionResult> UploadFile([FromForm] PosDTO model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest("Error en carga de archivo !!!");
            }

            if (model.TipRep == "RV")
            {
                List<PosSale> transactions = new List<PosSale>();

                using (var stream = new MemoryStream())
                {
                    await model.File.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataset = reader.AsDataSet();
                        var table = dataset.Tables[0];

                        for (int i = 2; i < table.Rows.Count; i++)
                        {
                            var row = table.Rows[i];

                            PosSale modPos = new PosSale();

                            modPos.Tipo_Operacion = string.IsNullOrEmpty(row[0]?.ToString()) ? "" : row[0].ToString();
                            modPos.Tipo_Comprobante = string.IsNullOrEmpty(row[1]?.ToString()) ? "" : row[1].ToString();
                            modPos.Comprobante = string.IsNullOrEmpty(row[2]?.ToString()) ? "" : row[2].ToString();
                            modPos.Fecha_Emision = string.IsNullOrEmpty(row[3]?.ToString()) ? "" : row[3].ToString();
                            modPos.Documento = string.IsNullOrEmpty(row[4]?.ToString()) ? "" : row[4].ToString();
                            modPos.Estado = string.IsNullOrEmpty(row[5]?.ToString()) ? "" : row[5].ToString();
                            modPos.Razon_Social = string.IsNullOrEmpty(row[6]?.ToString()) ? "" : row[6].ToString();
                            modPos.Cod_Afectación = string.IsNullOrEmpty(row[7]?.ToString()) ? "" : row[7].ToString();
                            modPos.Codigo = string.IsNullOrEmpty(row[8]?.ToString()) ? "" : row[8].ToString();
                            modPos.Descripción = string.IsNullOrEmpty(row[9]?.ToString()) ? "" : row[9].ToString();
                            modPos.Cantidad = string.IsNullOrEmpty(row[10]?.ToString()) ? 0 : Convert.ToInt32(row[10].ToString());
                            modPos.U_M = string.IsNullOrEmpty(row[11]?.ToString()) ? "" : row[11].ToString();
                            modPos.Precio_Unitario = string.IsNullOrEmpty(row[12]?.ToString()) ? 0 : Convert.ToDecimal(row[12]);
                            modPos.Valor_Unitario = string.IsNullOrEmpty(row[13]?.ToString()) ? 0 : Convert.ToDecimal(row[13]);
                            modPos.Valor_Venta = string.IsNullOrEmpty(row[14]?.ToString()) ? 0 : Convert.ToDecimal(row[14]);
                            modPos.Descuento_Venta = string.IsNullOrEmpty(row[15]?.ToString()) ? 0 : Convert.ToDecimal(row[15]);
                            modPos.Igv = string.IsNullOrEmpty(row[16]?.ToString()) ? 0 : Convert.ToDecimal(row[16]);
                            modPos.Importe = string.IsNullOrEmpty(row[17]?.ToString()) ? 0 : Convert.ToDecimal(row[17]);
                            modPos.Adicional = string.IsNullOrEmpty(row[18]?.ToString()) ? 0 : Convert.ToDecimal(row[18]);
                            modPos.Moneda = string.IsNullOrEmpty(row[19]?.ToString()) ? "" : row[19].ToString();
                            modPos.Cond_Pago = row[20].ToString();
                            modPos.Forma_Pago = row[21].ToString();
                            modPos.Orden_Compra = row[22].ToString();
                            modPos.Op_Gravadas = string.IsNullOrEmpty(row[23].ToString()) ? 0 : Convert.ToDecimal(row[23]);
                            modPos.Op_Exoneradas = string.IsNullOrEmpty(row[24].ToString()) ? 0 : Convert.ToDecimal(row[24]);
                            modPos.Op_Inafectas = string.IsNullOrEmpty(row[25].ToString()) ? 0 : Convert.ToDecimal(row[25]);
                            modPos.Op_Gratuitas = string.IsNullOrEmpty(row[26].ToString()) ? 0 : Convert.ToDecimal(row[26]);
                            modPos.Descuento_Op = string.IsNullOrEmpty(row[27].ToString()) ? 0 : Convert.ToDecimal(row[27]);
                            modPos.Igv_Op = string.IsNullOrEmpty(row[28].ToString()) ? 0 : Convert.ToDecimal(row[28]);
                            modPos.Total = string.IsNullOrEmpty(row[29].ToString()) ? 0 : Convert.ToDecimal(row[29]);
                            modPos.Peso_Bruto = string.IsNullOrEmpty(row[30].ToString()) ? 0 : Convert.ToDecimal(row[30]);
                            modPos.Um_Pesobruto = string.IsNullOrEmpty(row[31]?.ToString()) ? "" : row[31].ToString();
                            modPos.Importe_Baja = string.IsNullOrEmpty(row[32].ToString()) ? 0 : Convert.ToDecimal(row[32]);
                            modPos.Punto_Venta = string.IsNullOrEmpty(row[33]?.ToString()) ? "" : row[33].ToString();
                            modPos.Numero_Documento = string.IsNullOrEmpty(row[34]?.ToString()) ? "" : row[34].ToString();
                            modPos.Razon_Social_Cl = string.IsNullOrEmpty(row[35]?.ToString()) ? "" : row[35].ToString();
                            modPos.Direccion_Cliente = string.IsNullOrEmpty(row[36]?.ToString()) ? "" : row[36].ToString();
                            modPos.Adicionales = string.IsNullOrEmpty(row[37]?.ToString()) ? "" : row[37].ToString();
                            modPos.IdSede = model.IdSede;
                            modPos.IdUser = model.IdUser;

                            transactions.Add(modPos);
                        }
                    }

                    // Inserción en la base de datos
                    foreach (var transaction in transactions)
                    {
                        await _caja.InsSale(transaction);
                    }
                }
            }
            else if(model.TipRep == "RI"){

                List<PosIzip> transactions = new List<PosIzip>();

                using (var stream = new MemoryStream())
                {
                    await model.File.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataset = reader.AsDataSet();
                        var table = dataset.Tables[0];
                        
                        int _x = 2;
                        for (int i = 2; i < table.Rows.Count; i++)
                        {                            
                            PosIzip modPos = new PosIzip();                            

                            modPos.CODIGO = string.IsNullOrEmpty(table.Rows[_x][1]?.ToString()) ? "" : table.Rows[_x][1]?.ToString();
                            modPos.TIPO_MOVIMIENTO = string.IsNullOrEmpty(table.Rows[_x][2]?.ToString()) ? "" : table.Rows[_x][2]?.ToString();
                            modPos.TIPO_CAPTURA = string.IsNullOrEmpty(table.Rows[_x][3].ToString()) ? "" : table.Rows[_x][3]?.ToString();
                            modPos.TRANSACCION = string.IsNullOrEmpty(table.Rows[_x][4]?.ToString()) ? "" : table.Rows[_x][4]?.ToString();
                            modPos.FECHA_TRANSACCION = string.IsNullOrEmpty(table.Rows[_x][5]?.ToString()) ? "" : table.Rows[_x][5]?.ToString();
                            modPos.HORA_TRANSACCION = string.IsNullOrEmpty(table.Rows[_x][6]?.ToString()) ? "" : table.Rows[_x][6]?.ToString();
                            modPos.FECHA_CIERRE_LOTE = string.IsNullOrEmpty(table.Rows[_x][7]?.ToString()) ? "" : table.Rows[_x][7]?.ToString();
                            modPos.FECHA_PROCESO = string.IsNullOrEmpty(table.Rows[_x][8]?.ToString()) ? "" : table.Rows[_x][8]?.ToString();
                            modPos.FECHA_ABONO = string.IsNullOrEmpty(table.Rows[_x][9]?.ToString()) ? "" : table.Rows[_x][9]?.ToString();
                            modPos.ESTADO = string.IsNullOrEmpty(table.Rows[_x][10]?.ToString()) ? "" : table.Rows[_x][10]?.ToString();
                            modPos.IMPORTE = string.IsNullOrEmpty(table.Rows[_x][11]?.ToString()) ? 0 : Convert.ToDecimal(table.Rows[_x][11]?.ToString());
                            modPos.COMISION = string.IsNullOrEmpty(table.Rows[_x][12]?.ToString()) ? 0 : Convert.ToDecimal(table.Rows[_x][12]?.ToString());
                            modPos.IGV = string.IsNullOrEmpty(table.Rows[_x][13]?.ToString()) ? 0 : Convert.ToDecimal(table.Rows[_x][13]?.ToString());
                            modPos.IMPORTE_NETO = string.IsNullOrEmpty(table.Rows[_x][14]?.ToString()) ? 0 : Convert.ToDecimal(table.Rows[_x][14]?.ToString());
                            modPos.ABONO_LOTE = string.IsNullOrEmpty(table.Rows[_x][15]?.ToString()) ? 0 : Convert.ToDecimal(table.Rows[_x][15]?.ToString());
                            modPos.NUM_LOTE = string.IsNullOrEmpty(table.Rows[_x][16]?.ToString()) ? "" : table.Rows[_x][16]?.ToString();
                            modPos.TERMINAL = string.IsNullOrEmpty(table.Rows[_x][17]?.ToString()) ? "" : table.Rows[_x][17]?.ToString();
                            modPos.NUM_REF = string.IsNullOrEmpty(table.Rows[_x][18]?.ToString()) ? "" : table.Rows[_x][18]?.ToString();
                            modPos.MARCA_TARJETA = string.IsNullOrEmpty(table.Rows[_x][19]?.ToString()) ? "" : table.Rows[_x][19]?.ToString();
                            modPos.NUM_TARJETA = string.IsNullOrEmpty(table.Rows[_x][20]?.ToString()) ? "" : table.Rows[_x][20]?.ToString();
                            modPos.CODIGO_AUTORIZACION = table.Rows[_x][21]?.ToString();
                            modPos.CUOTAS = table.Rows[_x][22]?.ToString();
                            modPos.OBSERVACIONES = table.Rows[_x][23]?.ToString();
                            modPos.MONEDA = string.IsNullOrEmpty(table.Rows[_x][24]?.ToString()) ? "" : table.Rows[_x][24]?.ToString();
                            modPos.SERIE_TERMINAL = string.IsNullOrEmpty(table.Rows[_x][25]?.ToString()) ? "" : table.Rows[_x][25]?.ToString();
                            modPos.IdSede = model.IdSede;
                            modPos.IdUser = model.IdUser;

                            transactions.Add(modPos);

                            _x++;
                        }
                    }

                    // Inserción en la base de datos
                    foreach (var transaction in transactions)
                    {
                        await _caja.InsIzip(transaction);
                    }
                }
            }
            
            try
            {                
                return Ok(new
                {
                    data = "Ok",
                    error = new { },
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }       
    }
}
