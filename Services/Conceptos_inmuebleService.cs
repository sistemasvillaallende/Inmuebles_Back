using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public class Conceptos_inmuebleService : IConceptos_inmuebleService
    {
        public Conceptos_inmueble getByPk(int cod_concepto_inmueble)
        {
            try
            {
                return Conceptos_inmueble.getByPk(cod_concepto_inmueble);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Conceptos_inmueble> read()
        {
            try
            {
                return Conceptos_inmueble.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Conceptos_inmueble obj)
        {
            try
            {
                return Conceptos_inmueble.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Conceptos_inmueble obj)
        {
            try
            {
                Conceptos_inmueble.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Conceptos_inmueble obj)
        {
            try
            {
                Conceptos_inmueble.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

