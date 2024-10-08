﻿using System.Data.SqlClient;
using System.Transactions;
using Web_Api_Inm.Entities;

namespace Web_Api_Inm.Services
{
    public class CedulonesServices : ICedulonesServices
    {
        public long InsertCedulon(Cedulones2 oCedulon)
        {
            SqlConnection cn = DALBase.GetConnectionSIIMVA();
            SqlTransaction? trx = null;
            long nro_cedulon = 0;
            try
            {
                cn.Open();
                trx = cn.BeginTransaction();
                nro_cedulon = Cedulones2.InsertCedulon(oCedulon, cn, trx);
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                throw;
            }
            return nro_cedulon;
        }


        public long InsertCedulonScope(Cedulones2 oCedulon)
        {

             long nro_cedulon = 0;    
             try
            {
                using (SqlConnection con = DALBase.GetConnectionSIIMVA())

                {
                    con.Open();
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            nro_cedulon = Cedulones2.InsertCedulonScope(oCedulon,con,trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                            return nro_cedulon;

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
