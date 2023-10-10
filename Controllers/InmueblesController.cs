using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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
        [HttpGet]
        public Entities.Inmuebles getByPk(
    int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return _InmueblesService.getByPk(circunscripcion, seccion,
                    manzana, parcela, p_h);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
