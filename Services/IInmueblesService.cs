using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Entities.INM;

namespace Web_Api_Inm.Services
{
    public interface IInmueblesService
    {
        public Inmuebles getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
        public void update(Inmuebles obj);
        public List<Inmuebles> GetInmueblesPaginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta);
        public List<Combo> Categorias_liq_zona();
        public string armoDenominacion(int cir, int sec, int man, int par, int p_h);
        public string armoDenominacion2(int cir, int sec, int man, int par, int p_h);
        public string armoDenominacion3(int cir, int sec, int man, int par, int p_h);
        public List<Informes> InformeCtaCteSoloDeuda(int cir, int sec, int man, int par, int p_h, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA);
        public List<Informes> InformeCtaCteCompleto(int cir, int sec, int man, int par, int p_h, string per, Auditoria objA);
        public List<Combo> ListarCategoriasTasa();

        public List<Informes> Resumendeuda(int cir, int sec, int man, int par, int p_h,
            int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA);

        public int Count();

        // FRENTES

        public List<FrentesInmueble> FrentesXInmueble(int cir, int sec, int man, int par, int p_h);
        public List<Zonas> GetZonas(int? cod_zona);
        public List<Combo> GetCalle(string? nom_calle);
        public List<Barrios> GetBarrios(string? barrio);
        public void InsertFrente(Frentes_Con_Auditoria obj);
        public void UpdateFrente(Frentes_Con_Auditoria obj);
        public void DeleteFrente(int cir, int sec, int man, int par, int p_h, int nro_frente, Auditoria obj);
        // FIN FRENTES
        public DatosConexionAgua GetDatos(int cir, int sec, int man, int par, int p_h, string? nombre_titular);

        // DOMICILIO POSTAL
        public DatosDomicilio DatosDomicilioPostal(int cir, int sec, int man, int par, int p_h);
        public void ActualizarDatosDomicilio( int cir, int sec, int man, int par, int p_h, DatosDomicilio_Con_Auditoria obj);

        public Combo GetBarrioXCalle(int cod_calle, int nro_dom);

        public void EliminarParcelaXInmueble(int cir, int sec, int man, int par, int p_h, Auditoria obj);
        public decimal MontoDeuda(int cir, int sec, int man, int par, int p_h);
    }
}
