using System.Transactions;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.INM;
using static System.Collections.Specialized.BitVector32;

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

        public List<Informes> InformeCtaCteSoloDeuda(int cir, int sec, int man, int par, int p_h, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", cir.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            sec.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            man.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            par.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
                return Informes.InformeCtaCteSoloDeuda(cir, sec, man, par, p_h, categoria_deuda, categoria_deuda2, per);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Informes> InformeCtaCteCompleto(int cir, int sec, int man, int par, int p_h, string per, Auditoria objA)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", cir.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            sec.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            man.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            par.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
                return Informes.InformeCtaCteCompleto(cir, sec, man, par, p_h, per);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}