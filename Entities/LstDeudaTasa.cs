using System.Data;
using System.Data.SqlClient;

namespace Web_Api_Inm.Entities
{
    public class LstDeudaTasa : DALBase
    {
        public string periodo { get; set; }
        public decimal monto_original { get; set; }
        public decimal debe { get; set; }
        public string vencimiento { get; set; }
        public string desCategoria { get; set; }
        public int pagado { get; set; }
        public int nroTtransaccion { get; set; }
        public int categoriaDeuda { get; set; }
        public Int64 nro_cedulon_paypertic { get; set; }
        public decimal recargo { get; set; }
        public bool pago_parcial { get; set; }
        public decimal pago_a_cuenta { get; set; }
        public int nro_proc { get; set; }

        public LstDeudaTasa()
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
            nro_proc = 0;
        }
        public static List<LstDeudaTasa> getListDeudaTasa(int cir, int sec,
            int man, int par, int p_h)
        {
            List<LstDeudaTasa> oLstAuto = new List<LstDeudaTasa>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql = @"
                    SELECT C.periodo, C.monto_original, C.debe -
                    (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as debe,
                    vencimiento, b.des_categoria,
                    c.pagado, c.nro_transaccion, c.categoria_deuda, c.nro_cedulon_paypertic,
                    c.recargo,
                    C.pago_parcial,
                    (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as pago_a_cuenta, C.NRO_PROCURACION
                    FROM CTASCTES_INMUEBLES C
                    inner join CATE_DEUDA_INMUEBLE b on c.categoria_deuda = b.cod_categoria
                    WHERE
                    c.pagado = 0
                    AND c.tipo_transaccion = 1
                    AND c.deuda_activa = 1
                    AND c.nro_plan IS NULL
                    AND c.nro_procuracion IS NULL
                    AND c.circunscripcion = @circunscripcion AND
                    c.seccion = @seccion AND
                    c.manzana = @manzana AND
                    c.parcela = @parcela AND
                    c.p_h = @p_h AND vencimiento <= GETDATE() ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@circunscripcion", cir));
            cmd.Parameters.Add(new SqlParameter("@seccion", sec));
            cmd.Parameters.Add(new SqlParameter("@manzana", man));
            cmd.Parameters.Add(new SqlParameter("@parcela", par));
            cmd.Parameters.Add(new SqlParameter("@p_h", p_h));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaTasa oAuto = new LstDeudaTasa();
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
                    { oAuto.nro_cedulon_paypertic = dr.GetInt64(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oAuto.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }

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
        public static List<LstDeudaTasa> getListDeudaTasaNoVencida(int cir, int sec,
            int man, int par, int p_h)
        {
            List<LstDeudaTasa> oLstAuto = new List<LstDeudaTasa>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql = @"
                    SELECT C.periodo, C.monto_original, C.debe -
                    (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as debe,
                vencimiento, b.des_categoria,
                c.pagado, c.nro_transaccion, c.categoria_deuda, c.nro_cedulon_paypertic,
                c.recargo,
                C.pago_parcial,
                    (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                    C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as pago_a_cuenta, C.NRO_PROCURACION
                    FROM CTASCTES_INMUEBLES C
                    inner join CATE_DEUDA_INMUEBLE b on c.categoria_deuda = b.cod_categoria
                WHERE
                c.pagado = 0
                AND c.tipo_transaccion = 1
                AND c.deuda_activa = 1
                AND c.nro_plan IS NULL
                AND c.nro_procuracion IS NULL
                    AND c.circunscripcion = @circunscripcion AND
                    c.seccion = @seccion AND
                    c.manzana = @manzana AND
                    c.parcela = @parcela AND
                    c.p_h = @p_h AND vencimiento <= GETDATE() ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@circunscripcion", cir));
            cmd.Parameters.Add(new SqlParameter("@seccion", sec));
            cmd.Parameters.Add(new SqlParameter("@manzana", man));
            cmd.Parameters.Add(new SqlParameter("@parcela", par));
            cmd.Parameters.Add(new SqlParameter("@p_h", p_h));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaTasa oAuto = new LstDeudaTasa();
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
                    { oAuto.nro_cedulon_paypertic = dr.GetInt64(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oAuto.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }
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
        public static List<LstDeudaTasa> getListDeudaTasaProcurada(int cir, int sec,
            int man, int par, int p_h)
        {
            List<LstDeudaTasa> oLstTasa = new List<LstDeudaTasa>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql =
                @"SELECT C.periodo, C.monto_original, C.debe -
                (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as debe,
                vencimiento, b.des_categoria,
                c.pagado, c.nro_transaccion, c.categoria_deuda, c.nro_cedulon_paypertic,
                c.recargo,
                C.pago_parcial,
                (SELECT SUM(haber) FROM CTASCTES_INMUEBLES C2 WHERE
                C2.nro_transaccion=C.nro_transaccion  AND
                    C2.circunscripcion = C.circunscripcion AND
                    C2.seccion = C.seccion AND
                    C2.manzana = C.manzana AND
                    C2.parcela = C.parcela AND
                    C2.p_h = C.p_h) as pago_a_cuenta, C.NRO_PROCURACION
                FROM CTASCTES_INMUEBLES C
                inner join CATE_DEUDA_INMUEBLE b on c.categoria_deuda = b.cod_categoria
                WHERE
                c.pagado = 0
                AND c.tipo_transaccion = 1
                AND c.deuda_activa = 1
                AND c.nro_plan IS NULL
                AND c.nro_procuracion IS NOT NULL
                    AND c.circunscripcion = @circunscripcion AND
                    c.seccion = @seccion AND
                    c.manzana = @manzana AND
                    c.parcela = @parcela AND
                    c.p_h = @p_h AND vencimiento <= GETDATE() ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@circunscripcion", cir));
            cmd.Parameters.Add(new SqlParameter("@seccion", sec));
            cmd.Parameters.Add(new SqlParameter("@manzana", man));
            cmd.Parameters.Add(new SqlParameter("@parcela", par));
            cmd.Parameters.Add(new SqlParameter("@p_h", p_h));

            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900000;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaTasa oAuto = new LstDeudaTasa();
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
                    { oAuto.nro_cedulon_paypertic = dr.GetInt64(dr.GetOrdinal("nro_cedulon_paypertic")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oAuto.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oAuto.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oAuto.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }
                    oLstTasa.Add(oAuto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstTasa;
        }
    }
}

