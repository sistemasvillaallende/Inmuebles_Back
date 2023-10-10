using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Entities.INM;
using WSAfip;
using static System.Net.Mime.MediaTypeNames;

namespace Web_Api_Inm.Services
{
    public class Ctasctes_inmueblesServices : ICtasctes_inmueblesServices
    {
        public List<Periodos> IniciarCtacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.IniciarCtacte(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_iniciar_ctacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h, List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                string string_detalle = " Periodos incluidos : ";
                using (TransactionScope scope = new TransactionScope())
                {
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", circunscripcion.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                         seccion.ToString().PadLeft(2, Convert.ToChar("0")),
                                         manzana.ToString().PadLeft(2, Convert.ToChar("0")),
                                         parcela.ToString().PadLeft(3, Convert.ToChar("0")),
                                         p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "INICIALIZACION CUENTA INMUEBLES";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    foreach (var item in lst)
                    {
                        string_detalle += string.Format("Periodo {0} : ", item.periodo);
                    }
                    objA.detalle += string_detalle;
                    Ctasctes_inmuebles.Confirma_iniciar_ctacte(circunscripcion, seccion, manzana, parcela, p_h, lst);
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Ctasctes_inmuebles> ListarCtacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h, int tipo_consulta,
                                                        int cate_deuda_desde, int cate_deuda_hasta)
        {
            try
            {
                return Ctasctes_inmuebles.ListarCtacte(circunscripcion, seccion, manzana, parcela, p_h,
                    tipo_consulta, cate_deuda_desde, cate_deuda_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            try
            {
                return Ctasctes_inmuebles.Datos_transaccion(tipo_transaccion, nro_transaccion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Ctasctes_inmuebles> Listar_periodos_a_cancelar(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.Listar_periodos_a_cancelar(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_cancelacion_ctasctes(int tipo_transaccion, int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string
                    string_detalle = "Se Elimino total o parcial: ";
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", cir.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            sec.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            man.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            par.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "CANCELACION CUENTA CORRIENTE";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Ctasctes_inmuebles.InsertCancelacioMasiva(tipo_transaccion, cir, sec, man, par, p_h, lst);
                    Ctasctes_inmuebles.MarcopagadalaCtacte(cir, sec, man, par, p_h, lst);
                    foreach (var item in lst)
                    {
                        string_detalle += string.Format("Periodo {0} : ", item.periodo);
                    }
                    objA.detalle = string_detalle;
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Ctasctes_inmuebles> Listar_Periodos_cancelados(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.Listar_Periodos_cancelados(cir, sec, man, par, p_h);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_elimina_cancelacion(int cir, int sec, int man, int par, int p_h,
            List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string string_detalle = "Se cancelo total o parcial: ";
                    objA.identificacion =
                        string.Format("{0}-{1}-{2}-{3}-{4}", cir.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            sec.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            man.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            par.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "CANCELACION CUENTA CORRIENTE";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Ctasctes_inmuebles.Confirma_elimina_cancelacion(cir, sec, man, par, p_h, lst);
                    Ctasctes_inmuebles.MarconopagadalaCtacte(cir, sec, man, par, p_h, lst);
                    foreach (var item in lst)
                    {
                        //Ctasctes_inmuebles.Confirma_elimina_cancelacion(item.nro_transaccion, item);
                        string_detalle += string.Format("Periodo {0} : ", item.periodo);
                    }
                    objA.detalle = string_detalle;
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Ctasctes_inmuebles> Listar_periodos_a_reliquidar(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.Listar_periodos_a_reliquidar(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Confirma_reliquidacion(int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string string_detalle = "Se Reliquido los : ";
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", circunscripcion.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            seccion.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            manzana.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            parcela.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "RECALCULO DEUDA INMUEBLES";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0} ", DateTime.Now);
                    Ctasctes_inmuebles.Confirma_reliquidacion(circunscripcion, seccion, manzana, parcela, p_h, lst);
                    foreach (var item in lst)
                    {
                        string_detalle += string.Format("Periodo {0} : ", item.periodo);
                    }
                    objA.detalle = string_detalle;
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Ctasctes_inmuebles> Reliquidar_periodos(int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            List<Ctasctes_inmuebles> lst)
        {
            try
            {
                List<Ctasctes_inmuebles> lstCtasctes = new();
                using (TransactionScope scope = new TransactionScope())
                {
                    lstCtasctes = Ctasctes_inmuebles.Reliquidar_periodos(circunscripcion, seccion, manzana, parcela, p_h, lst);
                    scope.Complete();
                }
                return lstCtasctes;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Ctasctes_inmuebles> PeriodosRecalculo(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.PeriodosRecalculo(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DETALLE_PAGO DetallePago(int nroCedulon, int nroTransaccion)
        {
            try
            {
                DETALLE_PAGO objDet = DETALLE_PAGO.read(nroCedulon, nroTransaccion);
                return objDet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<DETALLE_DEUDA> DetalleDeuda(int nroTransaccion)
        {
            try
            {
                return DETALLE_DEUDA.read(nroTransaccion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public PlanPago DetPlanPago(int nro_plan)
        {
            try
            {
                PlanPago objPlan = PlanPago.get(nro_plan);
                objPlan.procuraciones_incluidas = PlanPago.getProcuraciones(nro_plan, 4);

                return objPlan;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<LstDeudaInm> getListDeudaInm(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                List<LstDeudaInm> lst = LstDeudaInm.getListDeudaInm(circunscripcion, seccion, manzana, parcela, p_h);

                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Ctasctes_inmuebles getByPk(int tipo_transaccion, int nro_transaccion, int nro_pago_parcial)
        {
            try
            {
                return Ctasctes_inmuebles.getByPk(tipo_transaccion, nro_transaccion, nro_pago_parcial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ctasctes_inmuebles> read()
        {
            try
            {
                return Ctasctes_inmuebles.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ctasctes_inmuebles obj)
        {
            try
            {
                return Ctasctes_inmuebles.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ctasctes_inmuebles obj)
        {
            try
            {
                Ctasctes_inmuebles.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ctasctes_inmuebles obj)
        {
            try
            {
                Ctasctes_inmuebles.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GrillaTasa DetalleProcuracion(int nro_proc)
        {
            try
            {
                return GrillaTasa.DetalleProcuracion(nro_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LstDeudaTasa> getListDeudaTasa(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                List<LstDeudaTasa> lst = LstDeudaTasa.getListDeudaTasa(cir, sec, man, par, p_h);

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LstDeudaTasa> getListDeudaTasaProcurada(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return LstDeudaTasa.getListDeudaTasaProcurada(cir, sec, man, par, p_h);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<LstDeudaTasa> getListDeudaTasaNoVencida(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return LstDeudaTasa.getListDeudaTasaNoVencida(cir, sec, man, par, p_h);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Combo> ListarCategoriasTasa()
        {
            try
            {
                return Entities.Inmuebles.ListarCategoriasTasa();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
