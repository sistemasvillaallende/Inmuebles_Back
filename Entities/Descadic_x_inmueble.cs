using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Web_Api_Inm.Entities
{
    public class Descadic_x_inmueble : DALBase
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public int cod_concepto_inmueble { get; set; }
        public string des_concepto_inmueble { get; set; }
        public decimal porcentaje { get; set; }
        public decimal monto { get; set; }
        public DateTime vencimiento { get; set; }
        public int nro_decreto { get; set; }
        public DateTime fecha_alta_registro { get; set; }
        public Int16 activo { get; set; }
        public string observaciones { get; set; }
        public int anio_desde { get; set; }
        public int anio_hasta { get; set; }
        public AUDITORIA.Auditoria objAuditoria { get; set; }
        public Descadic_x_inmueble()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            cod_concepto_inmueble = 0;
            porcentaje = 0;
            monto = 0;
            vencimiento = DateTime.Now;
            nro_decreto = 0;
            fecha_alta_registro = DateTime.Now;
            activo = 0;
            observaciones = string.Empty;
            anio_desde = 0;
            anio_hasta = 0;
            des_concepto_inmueble = string.Empty;
        }

        private static List<Descadic_x_inmueble> mapeo(SqlDataReader dr)
        {
            List<Descadic_x_inmueble> lst = new List<Descadic_x_inmueble>();
            Descadic_x_inmueble obj;
            if (dr.HasRows)
            {
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int cod_concepto_inmueble = dr.GetOrdinal("cod_concepto_inmueble");
                int porcentaje = dr.GetOrdinal("porcentaje");
                int monto = dr.GetOrdinal("monto");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_decreto = dr.GetOrdinal("nro_decreto");
                int fecha_alta_registro = dr.GetOrdinal("fecha_alta_registro");
                int activo = dr.GetOrdinal("activo");
                int observaciones = dr.GetOrdinal("observaciones");
                int anio_desde = dr.GetOrdinal("anio_desde");
                int anio_hasta = dr.GetOrdinal("anio_hasta");
                int des_concepto_inmueble = dr.GetOrdinal("des_concepto_inmueble");
                while (dr.Read())
                {
                    obj = new Descadic_x_inmueble();
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(cod_concepto_inmueble)) { obj.cod_concepto_inmueble = dr.GetInt32(cod_concepto_inmueble); }
                    if (!dr.IsDBNull(porcentaje)) { obj.porcentaje = dr.GetDecimal(porcentaje); }
                    if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_decreto)) { obj.nro_decreto = dr.GetInt32(nro_decreto); }
                    if (!dr.IsDBNull(fecha_alta_registro)) { obj.fecha_alta_registro = dr.GetDateTime(fecha_alta_registro); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetInt16(activo); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(anio_desde)) { obj.anio_desde = dr.GetInt32(anio_desde); }
                    if (!dr.IsDBNull(anio_hasta)) { obj.anio_hasta = dr.GetInt32(anio_hasta); }
                    if (!dr.IsDBNull(des_concepto_inmueble)) { obj.des_concepto_inmueble = dr.GetString(des_concepto_inmueble); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Descadic_x_inmueble> read()
        {
            try
            {
                List<Descadic_x_inmueble> lst = new List<Descadic_x_inmueble>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT A.*, B.des_concepto_inmueble 
                                        FROM Descadic_x_inmueble A
                                        INNER JOIN CONCEPTOS_INMUEBLE B 
                                        ON A.cod_concepto_inmueble=B.cod_concepto_inmueble";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Descadic_x_inmueble> getByPk(
            int circunscripcion, int seccion, int manzana, int parcela, int p_h,
            int cod_concepto_inmueble)
        {
            try
            {
                List<Descadic_x_inmueble> lst = new List<Descadic_x_inmueble>();
                string sql = @"
                                SELECT A.*, B.des_concepto_inmueble
                                FROM Descadic_x_inmueble A
                                INNER JOIN CONCEPTOS_INMUEBLE B 
                                ON A.cod_concepto_inmueble=B.cod_concepto_inmueble 
                                WHERE circunscripcion = @circunscripcion
                                AND seccion = @seccion
                                AND manzana = @manzana
                                AND parcela = @parcela
                                AND p_h = @p_h
                                AND A.cod_concepto_inmueble=@cod_concepto_inmueble";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@manzana", manzana);
                    cmd.Parameters.AddWithValue("@parcela", parcela);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", cod_concepto_inmueble);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Descadic_x_inmueble> listConceptosXinmueble(
            int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                List<Descadic_x_inmueble> lst = new List<Descadic_x_inmueble>();
                string sql = @"
                                SELECT A.*, B.des_concepto_inmueble
                                FROM Descadic_x_inmueble A
                                INNER JOIN CONCEPTOS_INMUEBLE B 
                                ON A.cod_concepto_inmueble=B.cod_concepto_inmueble 
                                WHERE circunscripcion = @circunscripcion
                                AND seccion = @seccion
                                AND manzana = @manzana
                                AND parcela = @parcela
                                AND p_h = @p_h";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@manzana", manzana);
                    cmd.Parameters.AddWithValue("@parcela", parcela);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(Descadic_x_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Descadic_x_inmueble(");
                sql.AppendLine("circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", cod_concepto_inmueble");
                sql.AppendLine(", porcentaje");
                sql.AppendLine(", monto");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_decreto");
                sql.AppendLine(", fecha_alta_registro");
                sql.AppendLine(", activo");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", anio_desde");
                sql.AppendLine(", anio_hasta");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @cod_concepto_inmueble");
                sql.AppendLine(", @porcentaje");
                sql.AppendLine(", @monto");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_decreto");
                sql.AppendLine(", @fecha_alta_registro");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @anio_desde");
                sql.AppendLine(", @anio_hasta");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", obj.cod_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@monto", obj.monto);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    cmd.Parameters.AddWithValue("@anio_hasta", obj.anio_hasta);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Descadic_x_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Descadic_x_inmueble SET");
                sql.AppendLine("porcentaje=@porcentaje");
                sql.AppendLine(", monto=@monto");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", nro_decreto=@nro_decreto");
                sql.AppendLine(", fecha_alta_registro=@fecha_alta_registro");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", anio_desde=@anio_desde");
                sql.AppendLine(", anio_hasta=@anio_hasta");
                sql.AppendLine("WHERE");
                sql.AppendLine("circunscripcion=@circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND p_h=@p_h");
                sql.AppendLine("AND cod_concepto_inmueble=@cod_concepto_inmueble");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", obj.cod_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@monto", obj.monto);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    cmd.Parameters.AddWithValue("@fecha_alta_registro", obj.fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@anio_desde", obj.anio_desde);
                    cmd.Parameters.AddWithValue("@anio_hasta", obj.anio_hasta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Descadic_x_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Descadic_x_inmueble ");
                sql.AppendLine("WHERE");
                sql.AppendLine("circunscripcion=@circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND p_h=@p_h");
                sql.AppendLine("AND cod_concepto_inmueble=@cod_concepto_inmueble");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", obj.cod_concepto_inmueble);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
