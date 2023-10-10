using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public class InmueblesServices : IInmueblesService
    {
        public List<Inmuebles> GetInmueblesPaginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta)
        {
            try
            {
                return Inmuebles.GetInmueblesPaginado(buscarPor, strParametro,
                    registro_desde, registro_hasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Inmuebles getByPk(
        int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Entities.Inmuebles.getByPk(circunscripcion, seccion,
                    manzana, parcela, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string armoDenominacion(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return Entities.Inmuebles.armoDenominacion(cir, sec,
                    man, par, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string armoDenominacion2(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return Entities.Inmuebles.armoDenominacion2(cir, sec,
                    man, par, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string armoDenominacion3(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return Entities.Inmuebles.armoDenominacion3(cir, sec,
                    man, par, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}