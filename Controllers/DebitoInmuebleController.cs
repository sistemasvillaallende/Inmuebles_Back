using Microsoft.AspNetCore.Mvc;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Services;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DebitoInmuebleController : ControllerBase
    {

        private IDebitosInmuebleService _DebitoInmuebleService;
        public DebitoInmuebleController(IDebitosInmuebleService DebitoInmuebleService)
        {
            _DebitoInmuebleService = DebitoInmuebleService;
        }


        [HttpPost]
        public IActionResult NuevoDebito(Debitos_Inm_auditoria obj)
        {
            try
            {

                if (string.IsNullOrEmpty(obj.debito.nombre))
                {
                    return BadRequest(new { message = "No ingresó el nombre del titular de la tarjeta " });
                }
                if (string.IsNullOrEmpty(obj.debito.nro_documento))
                {
                    return BadRequest(new { message = "No ingresó el nro de documento del titular de la tarjeta" });
                }
                if (string.IsNullOrEmpty(obj.debito.nro_tarjeta))
                {
                    return BadRequest(new { message = "No ingresó el nro de la Tarjeta" });
                }
                if (obj.debito.nro_tarjeta.Length != 16)
                {
                    return BadRequest(new { message = "El número de la tarjeta debe tener exactamente 16 dígitos" });
                }
                if (string.IsNullOrEmpty(obj.debito.pri_per_debitado))
                {
                    return BadRequest(new { message = "No ingresó el primer periodo debitado" });
                }
                if (string.IsNullOrEmpty(obj.debito.fecha_alta.ToString()))
                {
                    return BadRequest(new { message = "No ingresó fecha de alta" });
                }

                _DebitoInmuebleService.InsertDebito(obj);
                return Ok(new { message = "Se generó nuevo débito automático" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al generar el nuevo débito automático", details = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult ModificarDebito(Debitos_Inm_auditoria obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.debito.nombre))
                {
                    return BadRequest(new { message = "No ingresó el nombre del titular de la tarjeta " });
                }
                if (string.IsNullOrEmpty(obj.debito.nro_documento))
                {
                    return BadRequest(new { message = "No ingresó el nro de documento del titular de la tarjeta" });
                }
                if (string.IsNullOrEmpty(obj.debito.nro_tarjeta))
                {
                    return BadRequest(new { message = "No ingresó el nro de la Tarjeta" });
                }
                if (obj.debito.nro_tarjeta.Length != 16)
                {
                    return BadRequest(new { message = "El número de la tarjeta debe tener exactamente 16 dígitos" });
                }
                if (string.IsNullOrEmpty(obj.debito.pri_per_debitado))
                {
                    return BadRequest(new { message = "No ingresó el primer periodo debitado" });
                }
                if (string.IsNullOrEmpty(obj.debito.fecha_alta.ToString()))
                {
                    return BadRequest(new { message = "No ingresó fecha de alta" });
                }
                _DebitoInmuebleService.UpdateDebito(obj);
                return Ok(new { message = "Se modificó débito automático" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al modificar el débito automático", details = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult EliminarDebito(int cir, int sec, int man, int par, int p_h, Auditoria obj)
        {
            try
            {
                var debito = _DebitoInmuebleService.GetDebitoByInm(cir, sec, man, par, p_h);

                if (debito == null)
                {
                    return BadRequest(new { message = $"No existe el débito del inmueble" });
                }

                _DebitoInmuebleService.EliminarDebito(cir, sec, man, par, p_h, obj);
                return Ok(new { message = "Se eliminó débito automático" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al eliminar el débito automático", details = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult GetDebitoByInmueble(int cir, int sec, int man, int par, int p_h)
        {
            var debito = _DebitoInmuebleService.GetDebitoByInm(cir, sec, man, par, p_h);

            if (debito == null)
            {
                return BadRequest(new { message = $"No existe el débito del inmueble" });
            }

            return Ok(debito);

        }



    }
}