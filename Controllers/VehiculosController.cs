using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using System.ServiceModel.Channels;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Web_Api_Auto.Entities.AUDITORIA;
using System.Globalization;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Helpers;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VehiculosController : ControllerBase
    {
        DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
        private IVehiculosService _VehiculosService;

        public VehiculosController(IVehiculosService VehiculosService)
        {
            _VehiculosService = VehiculosService;
        }

        [HttpGet]
        public IActionResult GetAutoByDominio(string dominio)
        {
            var resultado = _VehiculosService.GetAutoByDominio(dominio);
            if (resultado == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult NuevoVehiculo(Vehiculos obj)
        {
            _VehiculosService.insert(obj);
            var Vehiculo = _VehiculosService.GetAutoByDominio(obj.dominio);
            if (Vehiculo == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Vehiculo." });
            }
            return Ok(Vehiculo);
        }

        [HttpPost]
        public IActionResult UpdateVehiculo(Vehiculos obj)
        {
            //
            obj.fecha_cambio_dominio = DateTime.Now;
            obj.usuariomodifica = obj.objAuditoria.usuario;
            //
            _VehiculosService.update(obj);
            var Vehiculo = _VehiculosService.GetAutoByDominio(obj.dominio);
            if (Vehiculo == null)
            {
                return Ok(new { message = "Error no se pudo modificar el Vehiculo." });
            }
            return Ok(Vehiculo);
        }
        [HttpGet]
        public IActionResult GetAllActivos()
        {
            var Vehiculos = _VehiculosService.GetAllActivos();
            if (Vehiculos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Vehiculos);
        }

        [HttpGet]
        public IActionResult GetAllBajas()
        {
            var Vehiculos = _VehiculosService.GetAllBajas();
            if (Vehiculos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Vehiculos);
        }

        [HttpGet]
        public IActionResult Causa_baja_auto()
        {
            var TiposBajas = _VehiculosService.Causa_baja_auto();
            if (TiposBajas == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(TiposBajas);
        }

        [HttpGet]
        public IActionResult Tipos_vehiculos()
        {
            var TiposVehiculos = _VehiculosService.Tipos_vehiculos();
            if (TiposVehiculos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(TiposVehiculos);
        }

        [HttpGet]
        public IActionResult Situacion_judicial()
        {
            var SituacionJudicial = _VehiculosService.Situacion_judicial();
            if (SituacionJudicial == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(SituacionJudicial);
        }

        [HttpGet]
        public IActionResult Tipos_documentos()
        {
            var Tiposdocumentos = _VehiculosService.Tipos_documentos();
            if (Tiposdocumentos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tiposdocumentos);
        }

        [HttpGet]
        public IActionResult CodigosCipByMarcaAnio(string marca, int anio)
        {
            var CodigosCip = _VehiculosService.CodigosCip(marca, anio);
            if (CodigosCip == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(CodigosCip);
        }

        //[HttpGet]
        //public IActionResult CodigosCipByMarca(string marca)
        //{
        //    var CodigosCip = _VehiculosService.CodigosCip(marca);
        //    if (CodigosCip == null)
        //    {
        //        return BadRequest(new { message = "Error al obtener los datos" });
        //    }
        //    return Ok(CodigosCip);
        //}

        [HttpGet]
        public async Task<ActionResult<PaginadorGenerico<Vehiculos>>> GetVehiculosPaginado(
            string buscarPor = "0", string strParametro = "0", int pagina = 1, int registros_por_pagina = 10)
        {
            List<Vehiculos> _Vehiculos;
            PaginadorGenerico<Vehiculos> _PaginadorVehiculos;
            ///////////////////////////
            // SISTEMA DE PAGINACIÓN //
            ///////////////////////////
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Vehiculos
            _TotalRegistros = await _VehiculosService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Dominio,
            //Titular
            //Cuit
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Vehiculos = await _VehiculosService.GetVehiculosPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Vehiculos = await _VehiculosService.GetVehiculosPaginado(buscarPor, strParametro, pagina * registros_por_pagina - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorVehiculos = new PaginadorGenerico<Vehiculos>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Vehiculos
            };
            if (_PaginadorVehiculos == null)
            {
                return BadRequest(new { message = "No se encontraron los datos" });
            }
            return _PaginadorVehiculos;
        }

        [HttpGet]
        private async Task<ActionResult<PaginadorGenerico<Vehiculos>>> PaginacionConParamRequestForm()
        {
            string buscarPor = Convert.ToString(Request.Form["buscarPor"]);
            string strParametro = Convert.ToString(Request.Form["strParametro"]);
            int pagina = Convert.ToInt32(Request.Form["pagina"]);
            int registros_por_pagina = Convert.ToInt32(Request.Form["registros_por_pagina"]);
            if (buscarPor.Length == 0) { buscarPor = "0"; }
            if (strParametro.Length == 0) { strParametro = "0"; }
            if (pagina == 0) { pagina = 1; }
            if (registros_por_pagina == 0) { registros_por_pagina = 10; }
            /////////////////////////////////////////////////////////////////////////////////////////
            List<Vehiculos> _Vehiculos;
            PaginadorGenerico<Vehiculos> _PaginadorVehiculos;
            ///////////////////////////
            // SISTEMA DE PAGINACIÓN //
            ///////////////////////////
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Vehiculos
            _TotalRegistros = await _VehiculosService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Dominio,
            //Titular
            //Cuit
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Vehiculos = await _VehiculosService.GetVehiculosPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Vehiculos = await _VehiculosService.GetVehiculosPaginado(buscarPor, strParametro, pagina * registros_por_pagina - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorVehiculos = new PaginadorGenerico<Vehiculos>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Vehiculos
            };
            if (_PaginadorVehiculos == null)
            {
                return BadRequest(new { message = "No se encontraron los datos" });
            }
            return _PaginadorVehiculos;
        }

        [HttpGet]
        public async Task<IActionResult> VerDominiosxcuit(string strcuit)
        {
            var dominios = await _VehiculosService.VerDominiosxcuit(strcuit);
            if (dominios == null)
            {
                return BadRequest(new { message = "Error al obtener los datos!" });
            }
            return Ok(dominios);
        }

        [HttpPost]
        public IActionResult ActualizarVecinoCumplidor(List<Vehiculos> lst)
        {
            _VehiculosService.ActualizarVecinoCumplidor(lst);
            string dominio = lst[0].dominio.ToString();
            var vehiculos = _VehiculosService.GetAutoByDominio(dominio);
            if (vehiculos == null)
            {
                return BadRequest(new { message = @"Hubo problemas, no se pudo Actualizar 
                                                    el Vecino Cumplidor para estos Dominios" });
            }
            return Ok(vehiculos);
        }

        [HttpGet]
        public ActionResult<List<Combo>> ListarCategoriasAuto()
        {
            var categorias = _VehiculosService.ListarCategoriasAuto();
            return Ok(categorias);
        }
        [HttpGet]
        public ActionResult<List<TARJETAS_DEBITOS>> ListarTarjetas()
        {
            var Tarjetas = _VehiculosService.ListarTarjetas();
            return Ok(Tarjetas);
        }

        [HttpGet]
        public ActionResult<List<Planes_cobro>> ListarPlanesdeTarjetas(int cod_tarjeta, int subsistema)
        {
            var Planes = _VehiculosService.ListarPlanesdeTarjetas(cod_tarjeta, subsistema);
            if (Planes.Count == 0)
            { return BadRequest(new { message = "No hay Periodo para Recalcular!" }); }
            return Ok(Planes);
        }
        [HttpPost]
        public ActionResult<bool> Bajalogicavehiculo(Vehiculos obj, int cod_baja,
            string fecha_tramite, string dado_baja_por, string a_partir_de_fecha,
            string hasta_periodo, string hasta_fecha)
        {
            _VehiculosService.Bajalogicavehiculo(obj, cod_baja, fecha_tramite);
            var vehiculo = _VehiculosService.GetAutoByDominio(obj.dominio);
            if (vehiculo == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja!" });
            }
            return Ok(vehiculo);
        }

        [HttpPost]
        public IActionResult Confirma_Cambio_dominio(string nuevo_dominio, string dominio_ant, string usuario, string observaciones)
        {
            var respuesta = _VehiculosService.Cambio_dominio(nuevo_dominio, dominio_ant, usuario, observaciones);
            if (respuesta == false)
            {
                return BadRequest(new { message = "No se pudo Confirmar el Cambio de Dominio!" });
            }
            return Ok(respuesta);
        }


    }
}