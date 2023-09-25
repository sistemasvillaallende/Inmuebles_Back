using Microsoft.AspNetCore.Mvc;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ctasctes_inmueblesController : ControllerBase
    {
        private ICtasctes_inmueblesServices _Ctasctes_inmueblesServices;
        public Ctasctes_inmueblesController(ICtasctes_inmueblesServices Ctasctes_InmueblesServices)
        {
            _Ctasctes_inmueblesServices = Ctasctes_InmueblesServices;
        }


        [HttpGet]
        public IActionResult IniciarCtacte(int cir, int sec, int man, int par, int p_h)
        {
            var lista = _Ctasctes_inmueblesServices.IniciarCtacte(cir, sec, man, par, p_h);
            if (lista.Count == 0)
            {
                return BadRequest(new { message = "No Hay Periodo para iniciar la Ctacte de este Inmueble" });
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Confirma_iniciar_ctacte(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_iniciar_ctacte(obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Inicializacion de la Cuenta Cte!" });
            }
            return Ok(obj.lstCtasTes);
        }

        [HttpGet]
        public IActionResult Listar_periodos_a_cancelar(int cir, int sec, int man, int par, int p_h)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.Listar_periodos_a_cancelar(cir, sec, man, par, p_h);
            if (Ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Ctasctes);
        }

        [HttpPost]
        public IActionResult Confirma_cancelacion_ctasctes(int tipo_transaccion, CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_cancelacion_ctasctes(tipo_transaccion, obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Cancelacion Operativa!" });

            }
            return Ok(obj.lstCtasTes);
        }

        [HttpGet]
        public ActionResult<List<Ctasctes_inmuebles>> Listar_Periodos_cancelados(int cir, int sec, int man, int par, int p_h)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.Listar_Periodos_cancelados(cir, sec, man, par, p_h);
            if (Ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Ctasctes);
        }

        [HttpPost]
        public IActionResult Confirma_elimina_cancelacion(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_elimina_cancelacion(obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Cancelar porque no hay Datos!" });
            }
            return Ok(obj.lstCtasTes);
        }

    }
}
