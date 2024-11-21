using Web_Api_Auto.Services;
using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public class TarjetasDebitoService : ITarjetasDebitoService
    {
       
        public List<TARJETAS_DEBITOS>  GetAllTarjetasDebito()
        {
            try
            {
                return TARJETAS_DEBITOS.read();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}