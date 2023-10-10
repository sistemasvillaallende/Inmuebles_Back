using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public interface IInmueblesService
    {
        public List<Inmuebles> GetInmueblesPaginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta);

        public Inmuebles getByPk(
        int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public string armoDenominacion(int cir, int sec, int man, int par, int p_h);
        public string armoDenominacion2(int cir, int sec, int man, int par, int p_h);
        public string armoDenominacion3(int cir, int sec, int man, int par, int p_h);
    }
}
