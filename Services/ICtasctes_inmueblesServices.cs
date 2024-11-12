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
        public GrillaTasa DetalleProcuracion(int nro_proc);
        public List<DETALLE_DEUDA> DetalleDeuda(int nroTransaccion);
        public PlanPago DetPlanPago(int nro_plan);
        public List<LstDeudaInm> getListDeudaInm(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public List<Ctasctes_inmuebles> read();
        public Ctasctes_inmuebles getByPk(int tipo_transaccion, int nro_transaccion, int nro_pago_parcial);
        public int insert(Ctasctes_inmuebles obj);
        public void update(Ctasctes_inmuebles obj);
        public void delete(Ctasctes_inmuebles obj);
        public List<LstDeudaTasa> getListDeudaTasa(int cir, int sec, int man, int par, int p_h);
        public List<LstDeudaTasa> getListDeudaTasaProcurada(int cir, int sec, int man, int par, int p_h);
        public List<LstDeudaTasa> getListDeudaTasaNoVencida(int cir, int sec, int man, int par, int p_h);
        public List<Combo> ListarCategoriasTasa();

        // Deudas
         public List<Ctasctes_inmuebles> ListarDeudasXTasa(int cir, int sec, int man, int par, int p_h);
         public List<CateDeudaInm> ListarCategoriaDeudas();
         public void NuevaDeuda(CtasCtes_Con_Auditoria obj);
         public void ModificarDeuda(CtasCtes_Con_Auditoria obj);
         public void EliminarDeuda(int cir, int sec, int man, int par, int p_h, int nro_transaccion, Auditoria obj);

    }
}
