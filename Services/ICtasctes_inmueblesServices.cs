using System.Data.SqlClient;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Entities.INM;

namespace Web_Api_Inm.Services
{
    public interface ICtasctes_inmueblesServices
    {
        public List<Periodos> IniciarCtacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public List<Ctasctes_inmuebles> ListarCtacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h, int tipo_consulta,
         int cate_deuda_desde, int cate_deuda_hasta);
        public List<Ctasctes_inmuebles> PeriodosRecalculo(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public string Datos_transaccion(int tipo_transaccion, int nro_transaccion);
        public List<Ctasctes_inmuebles> Listar_periodos_a_cancelar(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public List<Ctasctes_inmuebles> Listar_Periodos_cancelados(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public void Confirma_elimina_cancelacion(int circunscripcion, int seccion, int manzana, int parcela, int p_h, 
            List<Ctasctes_inmuebles> lst, Auditoria objA);
        public void Confirma_cancelacion_ctasctes(int tipo_transaccion,
            int circunscripcion, int seccion, int manzana, int parcela, int p_h, List<Ctasctes_inmuebles> lst, Auditoria objA);
        public List<Ctasctes_inmuebles> Listar_periodos_a_reliquidar(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public void Confirma_reliquidacion(int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            List<Ctasctes_inmuebles> lst, Auditoria objA);
        public List<Ctasctes_inmuebles> Reliquidar_periodos(int circunscripcion, int seccion, int manzana, int parcela, int p_h, 
            List<Ctasctes_inmuebles> lst);
        public void Confirma_iniciar_ctacte(int circunscripcion, int seccion, int manzana, int parcela, int p_h, 
            List<Ctasctes_inmuebles> lst, Auditoria objA);
        public DETALLE_PAGO DetallePago(int nroCedulon, int nroTransaccion);
        public List<DETALLE_DEUDA> DetalleDeuda(int nroTransaccion);
        public GrillaInm DetalleProcuracion(int nro_proc);
        public PlanPago DetPlanPago(int nro_plan);
        public List<LstDeudaInm> getListDeudaInm(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
    }
}
