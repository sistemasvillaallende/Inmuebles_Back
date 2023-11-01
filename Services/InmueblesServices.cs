using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Entities.INM;
using WSAfip;
using static System.Collections.Specialized.BitVector32;

namespace Web_Api_Inm.Services
{
    public class InmueblesServices : IInmueblesService
    {
        public void update(Inmuebles obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    obj.objAuditoria.identificacion = Entities.Inmuebles.armoDenominacion3(obj.circunscripcion, obj.seccion,
                        obj.manzana, obj.parcela, obj.p_h);
                    obj.objAuditoria.proceso = "MODIFICACION INMUEBLE";
                    obj.objAuditoria.detalle = JsonConvert.SerializeObject(Inmuebles.getByPk(obj.circunscripcion, obj.seccion, obj.manzana,
                        obj.parcela, obj.p_h));
                    obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Inmuebles.update(obj);
                    AuditoriaD.InsertAuditoria(obj.objAuditoria);
                    //scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Inmuebles> GetInmueblesPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta)
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
        public List<Combo> Categorias_liq_zona()
        {
            try
            {
                return Inmuebles.Categorias_liq_zona();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inmuebles getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
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
                return Entities.Inmuebles.armoDenominacion(cir, sec, man, par, p_h);
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
                return Entities.Inmuebles.armoDenominacion2(cir, sec, man, par, p_h);
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
                return Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
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
                    objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
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
                    objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
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
        public List<Combo> ListarCategoriasTasa()
        {
            try
            {
                return Inmuebles.ListarCategoriasTasa();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Informes> Resumendeuda(int cir, int sec, int man, int par, int p_h, 
            int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
                    objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
                return Informes.Resumendeuda(cir,sec, man, par, p_h, tipo_consulta, periodo, cate_deuda_desde, cate_deuda_hasta);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}