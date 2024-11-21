using System.Data.SqlClient;
using Newtonsoft.Json;
using Web_Api_Inm;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Services;

namespace Web_Api_Auto.Services
{
    public class DebitosInmuebleService : IDebitosInmuebleService
    {


        public DatosDebitoInm GetDebitoByInm(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                return Debitos_inmueble.GetDebitoByInm(cir, sec, man, par, p_h);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertDebito(Debitos_Inm_auditoria obj)
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

                            obj.auditoria.identificacion = Inmuebles.armoDenominacion3(obj.debito.circunscripcion, obj.debito.seccion, obj.debito.manzana, obj.debito.parcela, obj.debito.p_h); ;
                            obj.auditoria.proceso = "ALTA_DEBITO_INMUEBLE";
                            obj.auditoria.detalle = JsonConvert.SerializeObject(obj.debito);
                            obj.auditoria.observaciones = string.Format(" Fecha nuevo Debito automatico: {0} ", DateTime.Now);
                            Debitos_inmueble.InsertDebito(obj.debito, con, trx);
                            Debitos_inmueble.UpdateInmuebleDebito(obj.debito.circunscripcion, obj.debito.seccion, obj.debito.manzana, obj.debito.parcela, obj.debito.p_h, true, con, trx);
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

        public void UpdateDebito(Debitos_Inm_auditoria obj)
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
                            obj.auditoria.identificacion = Inmuebles.armoDenominacion3(obj.debito.circunscripcion, obj.debito.seccion, obj.debito.manzana, obj.debito.parcela, obj.debito.p_h); 
                            obj.auditoria.proceso = "MODIFICA_DEBITO_INMUEBLE";
                            obj.auditoria.detalle = JsonConvert.SerializeObject(obj.debito);
                            obj.auditoria.observaciones = string.Format(" Fecha modificacion Debito automatico: {0} ", DateTime.Now);
                            Debitos_inmueble.UpdateDebito(obj.debito, con, trx);
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
        public void EliminarDebito(int cir, int sec, int man, int par, int p_h, Auditoria obj)
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
                            obj.identificacion = Inmuebles.armoDenominacion3(cir, sec, man, par, p_h); 
                            obj.proceso = "ELIMINA_DEBITO_INMUEBLE";
                            obj.detalle = JsonConvert.SerializeObject(Inmuebles.getByPk(cir,sec,man,par,p_h));
                            obj.observaciones = string.Format(" Fecha eliminar debito: {0} ", DateTime.Now);
                            Debitos_inmueble.DeleteDebito(cir,sec,man,par,p_h, con, trx);
                            Debitos_inmueble.UpdateInmuebleDebito(cir,sec,man,par,p_h, false, con, trx);
                            AuditoriaD.InsertAuditoria(obj, con, trx);
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