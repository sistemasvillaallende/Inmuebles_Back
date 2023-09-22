using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Web_Api_Inm.Entities
{
    public class DETALLE_DEUDA : DALBase
    {
        public string concepto { get; set; }
        public decimal importe { get; set; }
        public DETALLE_DEUDA()
        {
            concepto = string.Empty;
            importe = 0;
        }

        public static List<DETALLE_DEUDA> read(int nroTransaccion)
        {
            try
            {
                DETALLE_DEUDA obj = null;
                List<DETALLE_DEUDA> lst = new List<DETALLE_DEUDA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = @"
                                        SELECT 
	                                        B.des_concepto_dominio,
	                                        A.importe_actual
                                        FROM DETALLE_DEUDA_AUTO A
                                        INNER JOIN CONCEPTOS_AUTO B 
                                        ON A.cod_concepto_item=B.cod_concepto_dominio
                                        WHERE nro_transaccion = @nroTransaccion";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nroTransaccion", nroTransaccion);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int des_concepto_dominio = dr.GetOrdinal("des_concepto_dominio");
                        int importe_actual = dr.GetOrdinal("importe_actual");

                        while (dr.Read())
                        {
                            obj = new DETALLE_DEUDA();
                            if (!dr.IsDBNull(des_concepto_dominio))
                            { obj.concepto = dr.GetString(des_concepto_dominio); }
                            if (!dr.IsDBNull(importe_actual))
                            { obj.importe = dr.GetDecimal(importe_actual); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
