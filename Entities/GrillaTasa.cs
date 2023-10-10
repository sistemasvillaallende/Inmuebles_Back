using System.Data;
using System.Data.SqlClient;

namespace Web_Api_Inm.Entities
{
    public class GrillaTasa : DALBase
    {
        public int cir { get; set; }
        public int sec { get; set; }
        public int man { get; set; }
        public int par { get; set; }
        public int p_h { get; set; }
        public int nro_procuracion { get; set; }
        public string descripcion_estado { get; set; }
        public string nombre_procurador { get; set; }
        public decimal saldo { get; set; }
        public string fecha_comienzo_procuracion { get; set; }
        public string fecha_comienzo_estado { get; set; }
        public string fecha_fin_estado { get; set; }

        public GrillaTasa()
        {
            cir = int.MinValue;
            sec = int.MinValue;
            man = int.MinValue;
            par = int.MinValue;
            p_h = int.MinValue;
            nro_procuracion = 0;
            descripcion_estado = string.Empty;
            nombre_procurador = string.Empty;
            saldo = 0;
            fecha_comienzo_procuracion = string.Empty;
            fecha_comienzo_estado = string.Empty;
            fecha_fin_estado = string.Empty;
        }

        public static GrillaTasa DetalleProcuracion(int nro_proc)
        {
            try
            {
                GrillaTasa obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_proc_readInm_x_nro";
                    cmd.Parameters.AddWithValue("@cod_proc", nro_proc);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int cir = dr.GetOrdinal("cir");
                        int sec = dr.GetOrdinal("sec");
                        int man = dr.GetOrdinal("man");
                        int par = dr.GetOrdinal("par");
                        int p_h = dr.GetOrdinal("PH");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int descripcion_estado = dr.GetOrdinal("descripcion_estado");
                        int nombre_procurador = dr.GetOrdinal("nombre_procurador");
                        int saldo = dr.GetOrdinal("saldo");
                        int fecha_comienzo_procuracion = dr.GetOrdinal("fecha_comienzo_procuracion");
                        int fecha_comienzo_estado = dr.GetOrdinal("fecha_comienzo_estado");
                        int fecha_fin_estado = dr.GetOrdinal("fecha_fin_estado");

                        while (dr.Read())
                        {
                            obj = new GrillaTasa();
                            if (!dr.IsDBNull(cir)) { obj.cir = int.Parse(dr.GetString(cir)); }
                            if (!dr.IsDBNull(sec)) { obj.sec = int.Parse(dr.GetString(sec)); }
                            if (!dr.IsDBNull(man)) { obj.man = int.Parse(dr.GetString(man)); }
                            if (!dr.IsDBNull(par)) { obj.par = int.Parse(dr.GetString(par)); }
                            if (!dr.IsDBNull(p_h)) { obj.p_h = int.Parse(dr.GetString(p_h)); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(descripcion_estado)) { obj.descripcion_estado = dr.GetString(descripcion_estado); }
                            if (!dr.IsDBNull(nombre_procurador)) { obj.nombre_procurador = dr.GetString(nombre_procurador); }
                            if (!dr.IsDBNull(saldo)) { obj.saldo = dr.GetDecimal(saldo); }
                            if (!dr.IsDBNull(fecha_comienzo_procuracion)) { obj.fecha_comienzo_procuracion = dr.GetDateTime(fecha_comienzo_procuracion).ToShortDateString(); }
                            if (!dr.IsDBNull(fecha_comienzo_estado)) { obj.fecha_comienzo_estado = dr.GetDateTime(fecha_comienzo_estado).ToShortDateString(); }
                            if (!dr.IsDBNull(fecha_fin_estado)) { obj.fecha_fin_estado = dr.GetDateTime(fecha_fin_estado).ToShortDateString(); }
                        }

                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

