﻿using Newtonsoft.Json;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using System.Data.SqlClient;

namespace Web_Api_Inm.Services
{
    public class Descadic_x_inmuebleService : IDescadic_x_inmuebleService
    {
        public List<Descadic_x_inmueble> getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h,
    int cod_concepto_inmueble)
        {
            try
            {
                return Descadic_x_inmueble.getByPk(circunscripcion, seccion, manzana, parcela, p_h, cod_concepto_inmueble);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Descadic_x_inmueble> listConceptosXinmueble(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Descadic_x_inmueble.listConceptosXinmueble(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Descadic_x_inmueble> read()
        {
            try
            {
                return Descadic_x_inmueble.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Descadic_x_inmueble obj)
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
                            if (obj.objAuditoria == null)
                            {
                                Auditoria audit = new Auditoria();
                                obj.objAuditoria = audit;

                            }
                            int id = 0;
                            obj.objAuditoria.identificacion = Entities.Inmuebles.armoDenominacion3(
                                obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
                            obj.objAuditoria.proceso = "MODIFICACION DE CONCEPTO";
                            obj.objAuditoria.detalle = JsonConvert.SerializeObject(
                                Entities.Inmuebles.getByPk(
                                obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h));
                            obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            id = Descadic_x_inmueble.insert(obj, con, trx);
                            AuditoriaD.InsertAuditoria(obj.objAuditoria, con, trx);
                            trx.Commit();
                            return id;
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
        public void update(Descadic_x_inmueble obj)
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

                            if (obj.objAuditoria == null)
                            {
                                Auditoria audit = new Auditoria();
                                obj.objAuditoria = audit;

                            }

                            obj.objAuditoria.identificacion = Entities.Inmuebles.armoDenominacion3(
                         obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
                            obj.objAuditoria.proceso = "MODIFICACION DE CONCEPTO";
                            obj.objAuditoria.detalle = Entities.Inmuebles.armoDenominacion(
                                obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
                            obj.objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Descadic_x_inmueble.update(obj, con, trx);
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
        public void delete(Descadic_x_inmueble obj)
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

                             if (obj.objAuditoria == null)
                            {
                                Auditoria audit = new Auditoria();
                                obj.objAuditoria = audit;

                            }

                            Auditoria objAuditoria = new Entities.AUDITORIA.Auditoria();
                            objAuditoria.identificacion = Entities.Inmuebles.armoDenominacion3(
                                obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
                            objAuditoria.proceso = "BAJA DE CONCEPTO";
                            objAuditoria.detalle = JsonConvert.SerializeObject(
                                Entities.Inmuebles.getByPk(
                                obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h));
                            objAuditoria.observaciones += string.Format(" Fecha auditoria: {0}", DateTime.Now);
                            Descadic_x_inmueble.delete(obj, con, trx);
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

