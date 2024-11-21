using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Services
{
    public interface IDebitosInmuebleService
    {
        public  DatosDebitoInm GetDebitoByInm(int cir, int sec, int man, int par, int p_h);
        public void InsertDebito(Debitos_Inm_auditoria obj);
        public void UpdateDebito(Debitos_Inm_auditoria obj);
        public void EliminarDebito(int cir, int sec, int man, int par, int p_h, Auditoria obj);
    }
}