using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Api_Inm.Entities
{
    public class Conceptos_inmueble : DALBase
    {
        public int cod_concepto_inmueble { get; set; }
        public string des_concepto_inmueble { get; set; }
        public bool suma { get; set; }
        public bool servicio_indirecto { get; set; }
        public bool activo { get; set; }

        public Conceptos_inmueble()
        {
            cod_concepto_inmueble = 0;
            des_concepto_inmueble = string.Empty;
            suma = false;
            servicio_indirecto = false;
            activo = false;
        }

        private static List<Conceptos_inmueble> mapeo(SqlDataReader dr)
        {
            List<Conceptos_inmueble> lst = new List<Conceptos_inmueble>();
            Conceptos_inmueble obj;
            if (dr.HasRows)
            {
                int cod_concepto_inmueble = dr.GetOrdinal("cod_concepto_inmueble");
                int des_concepto_inmueble = dr.GetOrdinal("des_concepto_inmueble");
                int suma = dr.GetOrdinal("suma");
                int servicio_indirecto = dr.GetOrdinal("servicio_indirecto");
                int activo = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new Conceptos_inmueble();
                    if (!dr.IsDBNull(cod_concepto_inmueble)) { obj.cod_concepto_inmueble = dr.GetInt32(cod_concepto_inmueble); }
                    if (!dr.IsDBNull(des_concepto_inmueble)) { obj.des_concepto_inmueble = dr.GetString(des_concepto_inmueble); }
                    if (!dr.IsDBNull(suma)) { obj.suma = dr.GetBoolean(suma); }
                    if (!dr.IsDBNull(servicio_indirecto)) { obj.servicio_indirecto = dr.GetBoolean(servicio_indirecto); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Conceptos_inmueble> read()
        {
            try
            {
                List<Conceptos_inmueble> lst = new List<Conceptos_inmueble>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Conceptos_inmueble";
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

        public static Conceptos_inmueble getByPk(int cod_concepto_inmueble)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Conceptos_inmueble WHERE");
                sql.AppendLine("cod_concepto_inmueble = @cod_concepto_inmueble");
                Conceptos_inmueble obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", cod_concepto_inmueble);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Conceptos_inmueble> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int insert(Conceptos_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Conceptos_inmueble(");
                sql.AppendLine("cod_concepto_inmueble");
                sql.AppendLine(", des_concepto_inmueble");
                sql.AppendLine(", suma");
                sql.AppendLine(", servicio_indirecto");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_concepto_inmueble");
                sql.AppendLine(", @des_concepto_inmueble");
                sql.AppendLine(", @suma");
                sql.AppendLine(", @servicio_indirecto");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", obj.cod_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@des_concepto_inmueble", obj.des_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@servicio_indirecto", obj.servicio_indirecto);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Conceptos_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Conceptos_inmueble SET");
                sql.AppendLine("des_concepto_inmueble=@des_concepto_inmueble");
                sql.AppendLine(", suma=@suma");
                sql.AppendLine(", servicio_indirecto=@servicio_indirecto");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto_inmueble=@cod_concepto_inmueble");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto_inmueble", obj.cod_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@des_concepto_inmueble", obj.des_concepto_inmueble);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@servicio_indirecto", obj.servicio_indirecto);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Conceptos_inmueble obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Conceptos_inmueble ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto_inmueble=@cod_concepto_inmueble");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

