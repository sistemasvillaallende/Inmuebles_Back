using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Transactions;
using System.Xml;
using Newtonsoft.Json;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Services
{
    public class VehiculosService : IVehiculosService
    {
        //public async Task<Vehiculos> GetByDominio(string dominio)
        //{
        //    try
        //    {
        //        return await Vehiculos.GetByDominio(dominio);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public Vehiculos GetAutoByDominio(string dominio)
        {
            try
            {
                return Vehiculos.GetAutoByDominio(dominio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Vehiculos> GetAllActivos()
        {
            try
            {
                return Vehiculos.GetAllActivos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Vehiculos> GetAllBajas()
        {
            try
            {
                return Vehiculos.GetAllBajas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Vehiculos> read()
        {
            try
            {
                return Vehiculos.read();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int insert(Vehiculos obj)
        {
            try
            {
                return Vehiculos.insert(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void update(Vehiculos obj)
        {
            SqlTransaction? trx = null;
            try
            {
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    cn.Open();
                    trx = cn.BeginTransaction();
                    obj.objAuditoria.identificacion = obj.dominio;
                    obj.objAuditoria.proceso = "MODIFICACION VEHICULO";
                    obj.objAuditoria.detalle = JsonConvert.SerializeObject(Vehiculos.GetAutoByDominio(obj.dominio));
                    obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Vehiculos.update(cn, trx, obj);
                    AuditoriaD.InsertAuditoria(cn, trx, obj.objAuditoria);
                    trx.Commit();
                }
            }
            catch (Exception)
            {
                //trx.Rollback();
                throw;
            }
        }
        public void delete(Vehiculos obj)
        {
            SqlTransaction? trx = null;
            try
            {
                using (SqlConnection cn = DALBase.GetConnectionSIIMVA())
                {
                    cn.Open();
                    trx = cn.BeginTransaction();
                    obj.objAuditoria.identificacion = obj.dominio;
                    obj.objAuditoria.proceso = "ELIMINAR VEHICULO";
                    obj.objAuditoria.detalle = JsonConvert.SerializeObject(Vehiculos.GetAutoByDominio(obj.dominio));
                    obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    Vehiculos.delete(cn, trx, obj);
                    AuditoriaD.InsertAuditoria(cn, trx, obj.objAuditoria);
                    trx.Commit();
                }
            }
            catch (Exception)
            {
                trx.Rollback();
                throw;
            }
        }
        public List<Combo> Causa_baja_auto()
        {
            try
            {
                return Vehiculos.Causa_baja_auto();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> Tipos_vehiculos()
        {
            try
            {
                return Vehiculos.Tipos_vehiculos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> Tipos_documentos()
        {
            try
            {
                return Vehiculos.Tipos_documentos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> Situacion_judicial()
        {
            try
            {
                return Vehiculos.Situacion_judicial();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Codigos_cip> CodigosCip(string marca, int anio)
        {
            try
            {
                return Vehiculos.CodigosCip(marca, anio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Codigos_cip> CodigosCip(string marca)
        {
            try
            {
                return Vehiculos.CodigosCip(marca);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> Count()
        {
            try
            {
                return await Vehiculos.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Vehiculos>> GetAllPaginado(int registro_desde, int registro_hasta)
        {
            try
            {
                return await Vehiculos.GetAllPaginado(registro_desde, registro_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Vehiculos>> GetVehiculosPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta)
        {
            try
            {
                return await Vehiculos.GetVehiculosPaginado(buscarPor, strParametro, registro_desde, registro_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Vehiculos>> VerDominiosxcuit(string strcuit)
        {
            try
            {
                return await Vehiculos.VerDominiosxcuit(strcuit);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ActualizarVecinoCumplidor(List<Vehiculos> obj)
        {
            try
            {
                DateTime fecha = DateTime.Now;
                string periodo = string.Format("{0}/{1}", fecha.Year, "00");
                string dominio = string.Empty;
                using (TransactionScope scope = new TransactionScope())
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        dominio = obj[i].dominio;
                        Vehiculos.ActualizarVecinoCumplidor(dominio, periodo);
                    }
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Combo> ListarCategoriasAuto()
        {
            {
                try
                {
                    return Ctasctes_automotores.ListarCategoriasAuto();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<TARJETAS_DEBITOS> ListarTarjetas()
        {
            {
                try
                {
                    return Ctasctes_automotores.ListarTarjetas();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<Planes_cobro> ListarPlanesdeTarjetas(int cod_tarjeta, int subsistema)
        {
            {
                try
                {
                    return Ctasctes_automotores.ListarPlanesdeTarjetas(cod_tarjeta, subsistema);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void Bajalogicavehiculo(Vehiculos obj, int cod_baja, string fecha_real_tramite)
        {
            try
            {
                string dominio = obj.dominio;
                using (TransactionScope scope = new TransactionScope())
                {
                    Vehiculos.Bajalogicavehiculo(dominio, cod_baja, fecha_real_tramite);
                    obj.objAuditoria.identificacion = obj.dominio;
                    obj.objAuditoria.proceso = "BAJA VEHICULO";
                    obj.objAuditoria.detalle = string.Format("Codigo de Baja: {0}, Fecha real Tramite: {1} ", cod_baja, fecha_real_tramite);
                    obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                    AuditoriaD.InsertAuditoria(obj.objAuditoria);
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Cambio_dominio(string nuevo_dominio, string dominio_ant, string usuario, string observaciones)
        {
            bool respuesta = false;
            try
            {
                Auditoria objA = new Auditoria();
                List<Ctasctes_automotores> lst = new List<Ctasctes_automotores>();
                using (TransactionScope scope = new())
                {
                    objA.identificacion = nuevo_dominio;
                    objA.usuario = usuario;
                    objA.proceso = "CAMBIO DOMINIO";
                    objA.detalle = string.Format("Dominio Anterior: {0}, Nuevo Dominio: {1}", dominio_ant, nuevo_dominio);
                    objA.observaciones = string.Format("Fecha auditoria: {0}, Observaciones: {1} ", DateTime.Now, observaciones);
                    //
                    Vehiculos.Cambio_dominio(nuevo_dominio, dominio_ant);
                    lst = Ctasctes_automotores.read(dominio_ant);
                    Ctasctes_automotores.Cambio_dominio_ctasctes(nuevo_dominio, dominio_ant, lst);
                    AuditoriaD.InsertAuditoria(objA);
                    scope.Complete();
                    respuesta = true;
                }
                return respuesta;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}