using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Web_Api_Inm.Services;
using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Conceptos_inmuebleController : Controller
    {

        private IConceptos_inmuebleService _Conceptos_inmuebleService;
        private IDescadic_x_inmuebleService _Descadic_x_inmuebleService;
        public Conceptos_inmuebleController(
            IConceptos_inmuebleService Conceptos_inmuebleService,
            IDescadic_x_inmuebleService descadic_x_inmuebleService)
        {
            _Conceptos_inmuebleService = Conceptos_inmuebleService;
            _Descadic_x_inmuebleService = descadic_x_inmuebleService;
        }
        [HttpGet]
        public ActionResult<List<Conceptos_inmueble>> readConceptos()
        {
            var conceptos = _Conceptos_inmuebleService.read();

            return Ok(conceptos);
        }
        [HttpGet]
        public ActionResult<List<Descadic_x_inmueble>> listConceptosXinmueble(int cir, int sec,
            int man, int par, int p_h)
        {
            var conceptos = _Descadic_x_inmuebleService.listConceptosXinmueble(
                cir, sec, man, par, p_h);

            return Ok(conceptos);
        }
        [HttpPost]
        public IActionResult UpdateConcepto(Descadic_x_inmueble obj, string usuario)
        {
            //
            obj.objAuditoria.usuario = usuario;
            //

            _Descadic_x_inmuebleService.update(obj);
            var Inmueble = _Descadic_x_inmuebleService.getByPk(obj.circunscripcion,
                obj.seccion, obj.manzana, obj.parcela, obj.p_h, obj.cod_concepto_inmueble);
            if (Inmueble == null)
            {
                return Ok(new { message = "Error no se pudo modificar el concepto." });
            }
            return Ok(Inmueble);
        }
        [HttpPost]
        public IActionResult AddConcepto(Descadic_x_inmueble obj, string usuario)
        {
            //
            obj.objAuditoria.usuario = usuario;
            //
            _Descadic_x_inmuebleService.insert(obj);
            var inmueble = _Descadic_x_inmuebleService.getByPk(obj.circunscripcion,
                obj.seccion, obj.manzana, obj.parcela, obj.p_h, obj.cod_concepto_inmueble);
            if (inmueble == null)
            {
                return Ok(new { message = "Error no se pudo agregar el concepto." });
            }
            return Ok(inmueble);
        }
        [HttpPost]
        public IActionResult DeleteConcepto(Descadic_x_inmueble obj, string usuario)
        {
            obj.objAuditoria.usuario = usuario;
            _Descadic_x_inmuebleService.delete(obj);

            var inmueble = _Descadic_x_inmuebleService.getByPk(obj.circunscripcion,
                obj.seccion, obj.manzana, obj.parcela, obj.p_h, obj.cod_concepto_inmueble);
            /*if (inmueble != null)
            {
                return Ok(new { message = "Error no se pudo eliminar el concepto." });
            }*/
            return Ok(inmueble);
        }

    }
}
