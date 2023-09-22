using Web_Api_Auto.Entities.AUDITORIA;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Services
{
    public interface IVehiculosService
    {
        public List<Vehiculos> read();
        public List<Vehiculos> GetAllActivos();
        public List<Vehiculos> GetAllBajas();
        //public Task<Vehiculos> GetByDominio(string dominio);
        public Vehiculos GetAutoByDominio(string dominio);
        public int insert(Vehiculos obj);
        public void update(Vehiculos obj);
        public void delete(Vehiculos obj);
        public List<Combo> Causa_baja_auto();
        public List<Combo> Tipos_vehiculos();
        public List<Combo> Tipos_documentos();
        public List<Combo> Situacion_judicial();
        public List<Codigos_cip> CodigosCip(string marca, int anio);
        public List<Codigos_cip> CodigosCip(string marca);
        public Task<int> Count();
        public Task<List<Vehiculos>> GetAllPaginado(int registro_desde, int registro_hasta);
        public Task<List<Vehiculos>> GetVehiculosPaginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta);
        public Task<List<Vehiculos>> VerDominiosxcuit(string strcuit);
        public void ActualizarVecinoCumplidor(List<Vehiculos> obj);
        public List<Combo> ListarCategoriasAuto();
        public List<TARJETAS_DEBITOS> ListarTarjetas();
        public List<Planes_cobro> ListarPlanesdeTarjetas(int cod_tarjeta, int subsistema);
        public void Bajalogicavehiculo(Vehiculos obj, int cod_baja, string fecha_real_tramite);
        public bool Cambio_dominio(string nuevo_dominio, string dominio_ant, string usuario, string observaciones);

    }
}

