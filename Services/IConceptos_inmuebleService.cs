using Web_Api_Inm.Entities;
namespace Web_Api_Inm.Services

{
    public interface IConceptos_inmuebleService
    {
        public List<Conceptos_inmueble> read();
        public Conceptos_inmueble getByPk(int cod_concepto_inmueble);
        public int insert(Conceptos_inmueble obj);
        public void update(Conceptos_inmueble obj);
        public void delete(Conceptos_inmueble obj);
    }
}
