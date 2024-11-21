using Microsoft.AspNetCore.Mvc;
using Web_Api_Inm.Services;

namespace Web_Api_Auto.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarjetasDebitoController : Controller
    {

        private ITarjetasDebitoService _TarjetasDebitoService;
        public TarjetasDebitoController(ITarjetasDebitoService TarjetasDebitosServices)
        {
            _TarjetasDebitoService = TarjetasDebitosServices;
        }

        [HttpGet]
        public ActionResult GetAllTarjetasDebito()
        {
            var lst = _TarjetasDebitoService.GetAllTarjetasDebito();
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }

    }
}