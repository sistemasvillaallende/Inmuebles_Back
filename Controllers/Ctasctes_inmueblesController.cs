using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Helpers;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ctasctes_inmueblesController : Controller
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
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_iniciar_ctacte(obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Inicializacion de la Cuenta Cte!" });
            }
            return Ok(obj.lstCtastes);
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
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_cancelacion_ctasctes(tipo_transaccion, obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Cancelacion Operativa!" });

            }
            return Ok(obj.lstCtastes);
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
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_elimina_cancelacion(obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Cancelar porque no hay Datos!" });
            }
            return Ok(obj.lstCtastes);
        }

        [HttpGet]
        public IActionResult Listar_periodos_a_reliquidar(int cir, int sec, int man, int par, int p_h)
        {
            var ctasctes = _Ctasctes_inmueblesServices.Listar_periodos_a_reliquidar(cir, sec, man, par, p_h);
            if (ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se Encontraron Periodos para Reliquidar para el Inmuebles " });
            }
            return Ok(ctasctes);
        }

        [HttpPost]
        public IActionResult Reliquidar_periodos(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst)
        {
            var ctasctes = _Ctasctes_inmueblesServices.Reliquidar_periodos(cir, sec, man, par, p_h, lst);
            if (ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se pudo Reliquidar, llamar a la Oficina de Sistemas!" });
            }
            return Ok(ctasctes);

        }
        [HttpPost]
        public IActionResult Confirma_reliquidacion(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_inmueblesServices.Confirma_reliquidacion(obj.cir, obj.sec, obj.man, obj.par, obj.p_h, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Reliquidacion de los Periodos de este Inmueble !" });
            }
            return Ok(obj.lstCtastes);

        }
        [HttpGet]
        public ActionResult<List<Ctasctes_inmuebles>> ListarCtacte(
            int cir, int sec, int man, int par, int p_h, int tipo_consulta,
            int cate_deuda_desde, int cate_deuda_hasta)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.ListarCtacte(
                cir, sec, man, par, p_h, tipo_consulta, cate_deuda_desde, cate_deuda_hasta);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult<List<DETALLE_DEUDA>> DetalleDeuda(int nro_transaccion)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.DetalleDeuda(nro_transaccion);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetalleProcuracion(int nro_proc)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.DetalleProcuracion(nro_proc);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetallePlan(int nro_plan)
        {
            var Ctasctes = _Ctasctes_inmueblesServices.DetPlanPago(nro_plan);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult<string> Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            var Transaccion = _Ctasctes_inmueblesServices.Datos_transaccion(tipo_transaccion, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult DetallePago(int nro_cedulon, int nro_transaccion)
        {
            var Transaccion = _Ctasctes_inmueblesServices.DetallePago(nro_cedulon, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult getListDeudaTasa(int cir, int sec, int man, int par, int p_h)
        {
            var lstDeuda = _Ctasctes_inmueblesServices.getListDeudaTasa(cir, sec, man, par, p_h);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpGet]
        public ActionResult getListDeudaTasaNoVencida(int cir, int sec, int man, int par, int p_h)
        {
            var lstDeuda = _Ctasctes_inmueblesServices.getListDeudaTasaNoVencida(cir, sec, man, par, p_h);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpGet]
        public ActionResult getListDeudaTasaProcurada(int cir, int sec, int man, int par, int p_h)
        {
            var lstDeuda = _Ctasctes_inmueblesServices.getListDeudaTasaProcurada(cir, sec, man, par, p_h);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpGet]
        public ActionResult<List<Combo>> ListarCategoriasTasa()
        {
            var categorias = _Ctasctes_inmueblesServices. ListarCategoriasTasa();
            return Ok(categorias);
        }

          [HttpGet]
        public IActionResult ListarDeudasXLegajo(int cir, int sec, int man, int par, int p_h)
        {
            var lst = _Ctasctes_inmueblesServices.ListarDeudasXTasa(cir, sec, man, par, p_h);

            if (lst.Count == 0)
            {
                return BadRequest(new { message ="La lista de deudas es nula"});
            }

            return Ok(lst);
        }

        [HttpGet]
        public IActionResult ListarCategoriaDeuda()
        {
            var lst = _Ctasctes_inmueblesServices.ListarCategoriaDeudas();

            if (lst.Count == 0)
            {
                return BadRequest(new { message ="La lista de deudas es nula"});
            }

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult NuevaDeuda(CtasCtes_Con_Auditoria obj)
        {
            var objCta = obj.lstCtastes[0];

            if (objCta.monto_original <= 0)
            {
                return BadRequest(new { message ="Monto Original Incorrecto."});
            }
            if (objCta.debe <= 0)
            {
                return BadRequest(new { message ="Debe Incorrecto."});
            }

            if (objCta.debe < objCta.monto_original)
            {
                return BadRequest(new { message ="El Monto Original debe ser menor o igual que lo que se debe."});
            }
            if (objCta.categoria_deuda != 1)
            {
                objCta.periodo = GeneradorPeriodo.GenerarPeriodoAleatorio();
                objCta.vencimiento = null;
            }
            if (objCta.categoria_deuda == 1)
            {
                var regex = new Regex(@"^\d{4}/\d{2}$");
                if (!regex.IsMatch(objCta.periodo))
                {
                    return BadRequest(new { message = "El campo 'periodo' debe estar en el formato 'yyyy/MM' y tener exactamente 7 caracteres."});
                }
            }

            _Ctasctes_inmueblesServices.NuevaDeuda(obj);
            return Ok(new { message = "Se genero nueva deuda" });

        }


        [HttpPut]
        public IActionResult ModificarDeuda(CtasCtes_Con_Auditoria obj)
        {
            var objCta = obj.lstCtastes[0];

            if (objCta.monto_original <= 0)
            {
                return BadRequest(new { message = "Monto Original Incorrecto." });
            }
            if (objCta.debe <= 0)
            {
                return BadRequest(new { message = "Debe Incorrecto." });
            }

            if (objCta.debe < objCta.monto_original)
            {
                return BadRequest(new { message = "El Monto Original debe ser menor o igual que lo que se debe." });
            }

            if (objCta.categoria_deuda != 1)
            {
                objCta.periodo = GeneradorPeriodo.GenerarPeriodoAleatorio();
                objCta.vencimiento = null;
            }
            _Ctasctes_inmueblesServices.ModificarDeuda(obj);
            return Ok(new { message = $"Se modificó la deuda {obj.lstCtastes[0].nro_transaccion}" });
        }

        [HttpDelete]
        public IActionResult EliminarDeuda(int cir, int sec, int man, int par, int p_h, int nro_transaccion, Auditoria obj)
        {
            _Ctasctes_inmueblesServices.EliminarDeuda(cir, sec, man, par, p_h, nro_transaccion, obj);
            return Ok(new { message = $"Se elimino la deuda {nro_transaccion} correctamente" });

        }
    }
}
