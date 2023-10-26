using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public interface IDescadic_x_inmuebleService
    {
        public List<Descadic_x_inmueble> read();
        public List<Descadic_x_inmueble> getByPk(
            int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            int cod_concepto_inmueble);
        public int insert(Descadic_x_inmueble obj);
        public void update(Descadic_x_inmueble obj);
        public void delete(Descadic_x_inmueble obj);
        public List<Descadic_x_inmueble> listConceptosXinmueble(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
    }
}
