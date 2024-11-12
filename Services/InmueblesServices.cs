using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using System.Data.SqlClient;
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
        public Inmuebles getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Inmuebles.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void update(Inmuebles obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {

                            obj.objAuditoria.identificacion = Entities.Inmuebles.armoDenominacion3(obj.circunscripcion, obj.seccion,
    obj.manzana, obj.parcela, obj.p_h);
                            obj.objAuditoria.proceso = "MODIFICACION INMUEBLE";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(Inmuebles.getByPk(obj.circunscripcion, obj.seccion, obj.manzana,
                                obj.parcela, obj.p_h));
                            obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Inmuebles.update(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }

                    }
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
            List<Informes> informesInformeCtaCteSoloDeuda;
            try
            {
                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
                            objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA, con, trx);
                            informesInformeCtaCteSoloDeuda = Informes.InformeCtaCteSoloDeuda(cir, sec, man, par, p_h, categoria_deuda, categoria_deuda2, per, con, trx);
                            trx.Commit();
                            return informesInformeCtaCteSoloDeuda;
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Informes> InformeCtaCteCompleto(int cir, int sec, int man, int par, int p_h, string per, Auditoria objA)
        {
            List<Informes> informesCtaCte;
            try
            {

                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
                            objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA, con, trx);

                            informesCtaCte = Informes.InformeCtaCteCompleto(cir, sec, man, par, p_h, per, con, trx);
                            trx.Commit();
                            return informesCtaCte;

                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }

                    }
                }
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

            List<Informes> resumen;
            try
            {

                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            objA.identificacion = Entities.Inmuebles.armoDenominacion3(cir, sec, man, par, p_h);
                            objA.proceso = "IMPRIME_DEUDA_INMUEBLE";
                            objA.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            AuditoriaD.InsertAuditoria(objA);
                            resumen = Informes.Resumendeuda(cir, sec, man, par, p_h, tipo_consulta, periodo, cate_deuda_desde, cate_deuda_hasta, con, trx);
                            trx.Commit();
                            return resumen;

                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            try
            {
                int count = Entities.Inmuebles.Count();
                return count;
                //return Entities.Inmuebles.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FrentesInmueble> FrentesXInmueble(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                var lst = Inmuebles.FrentesXInmueble(cir, sec, man, par, p_h);
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Zonas> GetZonas(int? cod_zona)
        {
            try
            {
                var lst = Inmuebles.GetZonas(cod_zona);
                return lst;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Combo> GetCalle(string? nom_calle)
        {
            try
            {
                var lst = Inmuebles.GetCalle(nom_calle);
                return lst;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertFrente(Frentes_Con_Auditoria obj)
        {

            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.auditoria.identificacion = "";
                            obj.auditoria.proceso = "INSERTAR NUEVO FRENTE";
                            obj.auditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            int nro_frente = Inmuebles.ObtenerUltimoNroFrente(con, trx, obj.frente.circunscripcion, obj.frente.seccion, obj.frente.manzana, obj.frente.parcela, obj.frente.p_h);
                            Inmuebles.InsertFrente(nro_frente + 1, obj.frente.cod_calle, obj.frente.nro_domicilio, obj.frente.metros_frente, obj.frente.cod_zona, con, trx);
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpdateFrente(Frentes_Con_Auditoria obj)
        {

            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.auditoria.identificacion = "";
                            obj.auditoria.proceso = "MODIFICAR FRENTE";
                            obj.auditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Inmuebles.UpdateFrente(obj.frente, con, trx);
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFrente(Frentes_Con_Auditoria obj)
        {

            try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.auditoria.identificacion = "";
                            obj.auditoria.proceso = "ELIMINAR FRENTE";
                            obj.auditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Inmuebles.DeleteFrente(obj.frente.circunscripcion,obj.frente.seccion,obj.frente.manzana,obj.frente.parcela,obj.frente.p_h,obj.frente.nro_frente,con,trx);
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
