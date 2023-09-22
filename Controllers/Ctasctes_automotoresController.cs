using Microsoft.AspNetCore.Mvc;
using Web_Api_Auto.Entities.AUDITORIA;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    //[Route("api/[controller]/[action]")]
    [Route("[controller]/[action]")]
    public class Ctasctes_automotoresController : ControllerBase
    {

        private ICtasctes_inmueblesServices _CtasctesServices;
        public Ctasctes_automotoresController(ICtasctes_inmueblesServices CtasctesServices)
        {
            _CtasctesServices = CtasctesServices;
        }

        [HttpGet]
        public IActionResult IniciarCtacte(string dominio)
        {
            var lista = _CtasctesServices.IniciarCtacte(dominio);
            if (lista.Count == 0)
            {
                return BadRequest(new { message = "No Hay Periodo para iniciar la Ctacte de este Vehiculo" });
            }
            return Ok(lista);
        }

        [HttpGet]
        public IActionResult PeriodosRecalculo(string dominio)
        {
            var Ctasctes = _CtasctesServices.PeriodosRecalculo(dominio);
            if (Ctasctes == null)
            { return BadRequest(new { message = "No hay Periodo para Recalcular!" }); }
            return Ok(Ctasctes);
        }

        [HttpGet]
        public ActionResult<List<Ctasctes_automotores>> ListarCtacte(string dominio, int tipo_consulta, int cate_deuda_desde, int cate_deuda_hasta)
        {
            var Ctasctes = _CtasctesServices.ListarCtacte(dominio, tipo_consulta, cate_deuda_desde, cate_deuda_hasta);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult<List<Ctasctes_automotores>> DetalleDeuda(int nro_transaccion)
        {
            var Ctasctes = _CtasctesServices.DetalleDeuda(nro_transaccion);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetalleProcuracion(int nro_proc)
        {
            var Ctasctes = _CtasctesServices.DetalleProcuracion(nro_proc);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetallePlan(int nro_plan)
        {
            var Ctasctes = _CtasctesServices.DetPlanPago(nro_plan);

            return Ok(Ctasctes);
        }
        [HttpPost]
        public IActionResult Confirma_iniciar_ctacte(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _CtasctesServices.Confirma_iniciar_ctacte(obj.dominio, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Inicializacion de la Cuenta Cte!" });

            }
            return Ok(obj.lstCtasTes);
        }

        [HttpGet]
        public IActionResult Listar_periodos_a_cancelar(string dominio)
        {
            var Ctasctes = _CtasctesServices.Listar_periodos_a_cancelar(dominio);
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
                _CtasctesServices.Confirma_elimina_cancelacion(obj.dominio, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Cancelar porque no hay Datos!" });
            }
            return Ok(obj.lstCtasTes);
        }

        [HttpGet]
        public ActionResult<List<Ctasctes_automotores>> Listar_Periodos_cancelados(string dominio)
        {
            var Ctasctes = _CtasctesServices.Listar_Periodos_cancelados(dominio);
            if (Ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Ctasctes);
        }

        [HttpGet]
        public ActionResult<string> Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            var Transaccion = _CtasctesServices.Datos_transaccion(tipo_transaccion, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult DetallePago(int nro_cedulon, int nro_transaccion)
        {
            var Transaccion = _CtasctesServices.DetallePago(nro_cedulon, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult getListDeudaAuto(string dominio)
        {
            var lstDeuda = _CtasctesServices.getListDeudaAuto(dominio);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpPost]
        public IActionResult Confirma_cancelacion_ctasctes(int tipo_transaccion, CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _CtasctesServices.Confirma_cancelacion_ctasctes(tipo_transaccion, obj.dominio, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Cancelacion Operativa porque no hay Datos!" });

            }
            return Ok(obj.lstCtasTes);
        }
        [HttpGet]
        public IActionResult Listar_periodos_a_reliquidar(string dominio)
        {
            var ctasctes = _CtasctesServices.Listar_periodos_a_reliquidar(dominio);
            if (ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se pudo Encontrar Periodos para Reliquidar!" });
            }
            return Ok(ctasctes);

        }

        [HttpPost]
        public IActionResult Confirma_reliquidacion(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtasTes.Count > 0)
            {
                _CtasctesServices.Confirma_reliquidacion(obj.dominio, obj.lstCtasTes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Reliquidacion de los Periodos de este Vehiculo!" });

            }
            return Ok(obj.lstCtasTes);

        }


    }
}
