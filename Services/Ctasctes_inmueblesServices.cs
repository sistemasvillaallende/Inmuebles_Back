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
                return Ctasctes_inmuebles.IniciarCtacte(circunscripcion,seccion, manzana, parcela, p_h);
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
        public List<Ctasctes_inmuebles> Listar_Periodos_cancelados(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Ctasctes_inmuebles.Listar_Periodos_cancelados(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Confirma_elimina_cancelacion(int circunscripcion, int seccion, int manzana, int parcela, int p_h, 
            List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string string_detalle = "Se cancelo total o parcial: ";
                    objA.identificacion =
                        string.Format("{0}-{1}-{2}-{3}-{4}",circunscripcion.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            seccion.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            manzana.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            parcela.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3,Convert.ToChar("0")));
                    objA.proceso = "CANCELACION CUENTA CORRIENTE";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    foreach (var item in lst)
                    {
                        Ctasctes_inmuebles.Confirma_elimina_cancelacion(item.nro_transaccion, item);
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
        public void Confirma_cancelacion_ctasctes(int tipo_transaccion, int circunscripcion, int seccion, int manzana, int parcela, int p_h, List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    string
                    string_detalle = "Se Elimino total o parcial: ";
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", circunscripcion.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            seccion.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            manzana.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            parcela.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "ELIMINA CANCELACION OPERATIVA";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    foreach (var item in lst)
                    {
                        Ctasctes_inmuebles.Confirma_cancelacion_ctasctes(tipo_transaccion, item);
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
            SqlTransaction? trx = null;
            try
            {
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    string string_detalle = "Se Reliquido los : ";
                    objA.identificacion = string.Format("{0}-{1}-{2}-{3}-{4}", circunscripcion.ToString().PadRight(2, Convert.ToChar("0")).Substring(2, 2),
                                                            seccion.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            manzana.ToString().PadLeft(2, Convert.ToChar("0")),
                                                            parcela.ToString().PadLeft(3, Convert.ToChar("0")),
                                                            p_h.ToString().PadLeft(3, Convert.ToChar("0")));
                    objA.proceso = "RECALCULO DEUDA INMUEBLES";
                    objA.detalle = "";
                    objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    cn.Open();
                    trx = cn.BeginTransaction();
                    Ctasctes_inmuebles.Confirma_reliquidacion(cn, trx, circunscripcion, seccion, manzana, parcela, p_h, lst);
                    foreach (var item in lst)
                    {
                        string_detalle += string.Format("Periodo {0} : ", item.periodo);
                    }
                    objA.detalle = string_detalle;
                    AuditoriaD.InsertAuditoria(cn, trx, objA);
                    trx.Commit();
                }
            }
            catch (Exception)
            {
                trx.Rollback();
                throw;
            }
        }
        public List<Ctasctes_inmuebles> Reliquidar_periodos(int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            try
            {
                List<Ctasctes_inmuebles> lstCtasctes = new();
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    cn.Open();
                    lstCtasctes = Ctasctes_inmuebles.Reliquidar_periodos(cn, circunscripcion, seccion, manzana, parcela, p_h, lst);
                }
                return lstCtasctes;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Confirma_iniciar_ctacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h, List<Ctasctes_inmuebles> lst, Auditoria objA)
        {
            SqlTransaction? trx = null;
            try
            {
                string string_detalle = " Periodos incluidos : ";
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    cn.Open();
                    trx = cn.BeginTransaction();
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
                    Ctasctes_inmuebles.Confirma_iniciar_ctacte(cn, trx, circunscripcion, seccion, manzana, parcela, p_h, lst);
                    AuditoriaD.InsertAuditoria(cn, trx, objA);
                    trx.Commit();
                }
            }
            catch (Exception)
            {
                trx.Rollback();
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
        public GrillaInm DetalleProcuracion(int nro_proc)
        {
            try
            {
                return GrillaInm.DetalleProcuracion(nro_proc);
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
    }
}
