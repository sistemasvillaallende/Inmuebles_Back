using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_Inm.Entities.INM
{
    public class LstDeudaInm : DALBase
    {
        public string periodo { get; set; }
        public decimal monto_original { get; set; }
        public decimal debe { get; set; }
        public string vencimiento { get; set; }
        public string desCategoria { get; set; }
        public int pagado { get; set; }
        public int nroTtransaccion { get; set; }
        public int categoriaDeuda { get; set; }
        public int nro_cedulon_paypertic { get; set; }
        public decimal recargo { get; set; }
        public bool pago_parcial { get; set; }
        public decimal pago_a_cuenta { get; set; }

        public LstDeudaInm()
        {
            periodo = string.Empty;
            monto_original = 0;
            debe = 0;
            vencimiento = string.Empty;
            desCategoria = string.Empty;
            pagado = 0;
            nroTtransaccion = 0;
            categoriaDeuda = 0;
            nro_cedulon_paypertic = 0;
            recargo = 0;
            pago_parcial = false;
            pago_a_cuenta = 0;
        }
        public static List<LstDeudaInm> getListDeudaInm(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            List<LstDeudaInm> oLstAuto = new List<LstDeudaInm>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection? cn = null;
            StringBuilder strSQL = new StringBuilder();

            strSQL.AppendLine("SELECT C.periodo, C.monto_original, C.debe -");
            strSQL.AppendLine("(SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE");
            strSQL.AppendLine("C2.nro_transaccion=C.nro_transaccion  AND");
            strSQL.AppendLine("C2.circunscripcion = C.circunscripcion " +
                "AND C2.seccion=C.seccion" +
                "AND C2.manzana=C.manzana" +
                "AND C2.parcela=C.parcela" +
                "AND C2.p_h=C.p_h" +
                ") as debe,");
            strSQL.AppendLine("vencimiento, b.des_categoria,");
            strSQL.AppendLine("c.pagado, c.nro_transaccion, c.categoria_deuda, c.nro_cedulon_paypertic,");
            strSQL.AppendLine("c.recargo,");
            strSQL.AppendLine("C.pago_parcial,");
            strSQL.AppendLine("(SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE");
            strSQL.AppendLine("C2.nro_transaccion=C.nro_transaccion  AND");            
            strSQL.AppendLine("C2.circunscripcion = C.circunscripcion " +
               "AND C2.seccion=C.seccion" +
               "AND C2.manzana=C.manzana" +
               "AND C2.parcela=C.parcela" +
               "AND C2.p_h=C.p_h" +
               ") as pago_a_cuenta,");
            strSQL.AppendLine("FROM CTASCTES_INMUEBLES C");
            strSQL.AppendLine("inner join CATE_DEUDA_INMUEBLE b on c.categoria_deuda = b.cod_categoria");
            strSQL.AppendLine("WHERE");
            strSQL.AppendLine("c.pagado = 0");
            strSQL.AppendLine("AND c.tipo_transaccion = 1");
            strSQL.AppendLine("AND c.deuda_activa = 1");
            strSQL.AppendLine("AND c.nro_plan IS NULL");
            strSQL.AppendLine("AND c.nro_procuracion IS NULL");
            strSQL.AppendLine("AND c.dominio = @dominio");


            cmd = new SqlCommand();

            //cmd.Parameters.Add(new SqlParameter("@dominio", dominio));

            try
            {
                cn = GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaInm oAuto = new LstDeudaInm();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oAuto.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oAuto.monto_original = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oAuto.debe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {
                        oAuto.vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oAuto.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oAuto.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oAuto.nroTtransaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("categoria_deuda")))
                    { oAuto.categoriaDeuda = dr.GetInt32(dr.GetOrdinal("categoria_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oAuto.recargo = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oAuto.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }

                    oLstAuto.Add(oAuto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstAuto;
        }

    }
}
