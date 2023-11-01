using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Helpers;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InmueblesController : Controller
    {
        DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
        private IInmueblesService _InmueblesService;

        public InmueblesController(IInmueblesService InmueblesService)
        {
            _InmueblesService = InmueblesService;
        }

        [HttpGet]
        public ActionResult Updateinmueble(Inmuebles obj)
        {

            var inmueble = _InmueblesService.getByPk(obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
            if (inmueble.circunscripcion == 0)
            {
                return BadRequest(new { message = @"Información, no se encontro este Inmueble " });
            }
            else
            {
                _InmueblesService.update(obj);
            }
            return Ok(inmueble);

        }

        [HttpGet]
        public ActionResult Categorias_liq_zona()
        {
            var zonas = _InmueblesService.Categorias_liq_zona();
            return Ok(zonas);
        }

        [HttpGet]
        public PaginadorGenerico<Entities.Inmuebles> GetInmueblesPaginado(string buscarPor = "",
            string strParametro = "", int pagina = 0, int registros_por_pagina = 10)
        {
            List<Entities.Inmuebles> _Inmueble;
            PaginadorGenerico<Entities.Inmuebles> _PaginadorInmueble;

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            _Inmueble = _InmueblesService.GetInmueblesPaginado(buscarPor, strParametro, pagina,
                registros_por_pagina);

            if (_Inmueble != null && _Inmueble.Count() > 0)
            {
                _TotalRegistros = _Inmueble[0].total_row;
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
                _PaginadorInmueble = new PaginadorGenerico<Entities.Inmuebles>()
                {
                    RegistrosPorPagina = registros_por_pagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaPor = buscarPor,
                    Parametro = strParametro,
                    Resultado = _Inmueble
                };

                if (_PaginadorInmueble.TotalRegistros == 0)
                {
                    //return BadRequest(new { message = "No se encontraron los datos..." });
                }
                return _PaginadorInmueble;
            }
            else
                return null;
        }
        [HttpGet]
        public PaginadorGenerico<Entities.Inmuebles> GetInmueblesPaginadoDenominacion(
            int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            List<Entities.Inmuebles> _Inmueble;
            PaginadorGenerico<Entities.Inmuebles> _PaginadorInmueble;

            string strParametro = _InmueblesService.armoDenominacion2(circunscripcion,
                seccion, manzana, parcela, p_h);

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            _Inmueble = _InmueblesService.GetInmueblesPaginado("denominacion", strParametro, 0,
                2);

            if (_Inmueble != null && _Inmueble.Count() > 0)
            {
                _TotalRegistros = 1;
                _TotalPaginas = 1;
                _PaginadorInmueble = new PaginadorGenerico<Entities.Inmuebles>()
                {
                    RegistrosPorPagina = 1,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = 1,
                    BusquedaPor = "denominacion",
                    Parametro = strParametro,
                    Resultado = _Inmueble
                };

                if (_PaginadorInmueble.TotalRegistros == 0)
                {
                    //return BadRequest(new { message = "No se encontraron los datos..." });
                }
                return _PaginadorInmueble;
            }
            else
                return null;
        }

        //[HttpPost]
        //public IActionResult InformeCtaCteCompleto(int cir, int sec, int man, int par, int p_h, string per, Auditoria objA)
        //{
        //    var reporte = _InmueblesService.InformeCtaCteCompleto(cir, sec, man, par, p_h, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble " });
        //    }
        //    return Ok(reporte);
        //}

        //[HttpPost]
        //public IActionResult InformeCtaCteSolodeuda(int cir, int sec, int man, int par, int p_h, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA)
        //{
        //    var reporte = _InmueblesService.InformeCtaCteSoloDeuda(cir, sec, man, par, p_h, categoria_deuda, categoria_deuda2, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble " });
        //    }
        //    return Ok(reporte);
        //}

        [HttpGet]
        public IActionResult ListarCategoriasTasa()
        {
            var categorias = _InmueblesService.ListarCategoriasTasa();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Resumendeuda(int cir, int sec, int man, int par, int p_h, int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA)
        {
            var resumen = _InmueblesService.Resumendeuda(cir, sec, man, par, p_h, tipo_consulta, periodo, cate_deuda_desde, cate_deuda_hasta, objA);
            if (resumen.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble!!!" });
            }
            return Ok(resumen);
        }
    }
}
