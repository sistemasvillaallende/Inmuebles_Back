using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Entities
{
    public class Cedulones2 : DALBase
    {
        public long nro_cedulon { get; set; }
        public DateTime? fecha_emision { get; set; }
        public int subsistema { get; set; }
        public int tipo_cedulon { get; set; }
        public bool no_pagado { get; set; }
        public bool activo { get; set; }
        public int nro_emision { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string periodo { get; set; }
        public DateTime? vencimiento_1 { get; set; }
        public decimal monto_1 { get; set; }
        public DateTime? vencimiento_2 { get; set; }
        public decimal monto_2 { get; set; }
        public decimal contado { get; set; }
        public decimal cheques { get; set; }
        public decimal monto_arreglo { get; set; }
        public string nro_decreto { get; set; }
        public int nro_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public string local_esp { get; set; }
        public string nom_calle_dom_esp { get; set; }
        public string nom_barrio_dom_esp { get; set; }
        public string ciudad_dom_esp { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }
        public string codigo_postal_dom_esp { get; set; }
        public int nro_badec { get; set; }
        public int nro_contrib { get; set; }
        public string nom_badec { get; set; }
        public string nom_calle_pf { get; set; }
        public int nro_dom_pf { get; set; }
        public string dominio { get; set; }
        public int legajo { get; set; }
        public int imprime { get; set; }
        public string tipo_cem { get; set; }
        public int manzana_cem { get; set; }
        public int lote_cem { get; set; }
        public int parcela_cem { get; set; }
        public int nivel_cem { get; set; }
        public int nro_causa { get; set; }
        public int anio { get; set; }
        public int nro_procuracion { get; set; }
        public List<VCtasctes> lstDeuda { get; set; }

        public Cedulones2()
        {
            nro_cedulon = 0;
            fecha_emision = null;
            subsistema = 0;
            tipo_cedulon = 0;
            no_pagado = false;
            activo = false;
            nro_emision = 0;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            periodo = string.Empty;
            vencimiento_1 = null;
            monto_1 = 0;
            vencimiento_2 = null;
            monto_2 = 0;
            contado = 0;
            cheques = 0;
            monto_arreglo = 0;
            nro_decreto = string.Empty;
            nro_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            local_esp = string.Empty;
            nom_calle_dom_esp = string.Empty;
            nom_barrio_dom_esp = string.Empty;
            ciudad_dom_esp = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
            codigo_postal_dom_esp = string.Empty;
            nro_badec = 0;
            nro_contrib = 0;
            nom_badec = string.Empty;
            nom_calle_pf = string.Empty;
            nro_dom_pf = 0;
            dominio = string.Empty;
            legajo = 0;
            imprime = 0;
            tipo_cem = string.Empty;
            manzana_cem = 0;
            lote_cem = 0;
            parcela_cem = 0;
            nivel_cem = 0;
            nro_causa = 0;
            anio = 0;
            nro_procuracion = 0;
            lstDeuda = new List<VCtasctes>();
        }

        private static List<Cedulones2> mapeo(SqlDataReader dr)
        {
            List<Cedulones2> lst = new List<Cedulones2>();
            Cedulones2 obj;
            if (dr.HasRows)
            {
                int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                int fecha_emision = dr.GetOrdinal("fecha_emision");
                int subsistema = dr.GetOrdinal("subsistema");
                int tipo_cedulon = dr.GetOrdinal("tipo_cedulon");
                int no_pagado = dr.GetOrdinal("no_pagado");
                int activo = dr.GetOrdinal("activo");
                int nro_emision = dr.GetOrdinal("nro_emision");
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int periodo = dr.GetOrdinal("periodo");
                int vencimiento_1 = dr.GetOrdinal("vencimiento_1");
                int monto_1 = dr.GetOrdinal("monto_1");
                int vencimiento_2 = dr.GetOrdinal("vencimiento_2");
                int monto_2 = dr.GetOrdinal("monto_2");
                int contado = dr.GetOrdinal("contado");
                int cheques = dr.GetOrdinal("cheques");
                int monto_arreglo = dr.GetOrdinal("monto_arreglo");
                int nro_decreto = dr.GetOrdinal("nro_decreto");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int piso_dpto_esp = dr.GetOrdinal("piso_dpto_esp");
                int local_esp = dr.GetOrdinal("local_esp");
                int nom_calle_dom_esp = dr.GetOrdinal("nom_calle_dom_esp");
                int nom_barrio_dom_esp = dr.GetOrdinal("nom_barrio_dom_esp");
                int ciudad_dom_esp = dr.GetOrdinal("ciudad_dom_esp");
                int provincia_dom_esp = dr.GetOrdinal("provincia_dom_esp");
                int pais_dom_esp = dr.GetOrdinal("pais_dom_esp");
                int codigo_postal_dom_esp = dr.GetOrdinal("codigo_postal_dom_esp");
                int nro_badec = dr.GetOrdinal("nro_badec");
                int nro_contrib = dr.GetOrdinal("nro_contrib");
                int nom_badec = dr.GetOrdinal("nom_badec");
                int nom_calle_pf = dr.GetOrdinal("nom_calle_pf");
                int nro_dom_pf = dr.GetOrdinal("nro_dom_pf");
                int dominio = dr.GetOrdinal("dominio");
                int legajo = dr.GetOrdinal("legajo");
                int imprime = dr.GetOrdinal("imprime");
                int tipo_cem = dr.GetOrdinal("tipo_cem");
                int manzana_cem = dr.GetOrdinal("manzana_cem");
                int lote_cem = dr.GetOrdinal("lote_cem");
                int parcela_cem = dr.GetOrdinal("parcela_cem");
                int nivel_cem = dr.GetOrdinal("nivel_cem");
                int nro_causa = dr.GetOrdinal("nro_causa");
                int anio = dr.GetOrdinal("anio");
                int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                while (dr.Read())
                {
                    obj = new Cedulones2();
                    if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                    if (!dr.IsDBNull(fecha_emision)) { obj.fecha_emision = dr.GetDateTime(fecha_emision); }
                    if (!dr.IsDBNull(subsistema)) { obj.subsistema = dr.GetInt32(subsistema); }
                    if (!dr.IsDBNull(tipo_cedulon)) { obj.tipo_cedulon = dr.GetInt32(tipo_cedulon); }
                    if (!dr.IsDBNull(no_pagado)) { obj.no_pagado = dr.GetBoolean(no_pagado); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    if (!dr.IsDBNull(nro_emision)) { obj.nro_emision = dr.GetInt32(nro_emision); }
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(vencimiento_1)) { obj.vencimiento_1 = dr.GetDateTime(vencimiento_1); }
                    if (!dr.IsDBNull(monto_1)) { obj.monto_1 = dr.GetDecimal(monto_1); }
                    if (!dr.IsDBNull(vencimiento_2)) { obj.vencimiento_2 = dr.GetDateTime(vencimiento_2); }
                    if (!dr.IsDBNull(monto_2)) { obj.monto_2 = dr.GetDecimal(monto_2); }
                    if (!dr.IsDBNull(contado)) { obj.contado = dr.GetDecimal(contado); }
                    if (!dr.IsDBNull(cheques)) { obj.cheques = dr.GetDecimal(cheques); }
                    if (!dr.IsDBNull(monto_arreglo)) { obj.monto_arreglo = dr.GetDecimal(monto_arreglo); }
                    if (!dr.IsDBNull(nro_decreto)) { obj.nro_decreto = dr.GetString(nro_decreto); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(piso_dpto_esp)) { obj.piso_dpto_esp = dr.GetString(piso_dpto_esp); }
                    if (!dr.IsDBNull(local_esp)) { obj.local_esp = dr.GetString(local_esp); }
                    if (!dr.IsDBNull(nom_calle_dom_esp)) { obj.nom_calle_dom_esp = dr.GetString(nom_calle_dom_esp); }
                    if (!dr.IsDBNull(nom_barrio_dom_esp)) { obj.nom_barrio_dom_esp = dr.GetString(nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(ciudad_dom_esp)) { obj.ciudad_dom_esp = dr.GetString(ciudad_dom_esp); }
                    if (!dr.IsDBNull(provincia_dom_esp)) { obj.provincia_dom_esp = dr.GetString(provincia_dom_esp); }
                    if (!dr.IsDBNull(pais_dom_esp)) { obj.pais_dom_esp = dr.GetString(pais_dom_esp); }
                    if (!dr.IsDBNull(codigo_postal_dom_esp)) { obj.codigo_postal_dom_esp = dr.GetString(codigo_postal_dom_esp); }
                    if (!dr.IsDBNull(nro_badec)) { obj.nro_badec = dr.GetInt32(nro_badec); }
                    if (!dr.IsDBNull(nro_contrib)) { obj.nro_contrib = dr.GetInt32(nro_contrib); }
                    if (!dr.IsDBNull(nom_badec)) { obj.nom_badec = dr.GetString(nom_badec); }
                    if (!dr.IsDBNull(nom_calle_pf)) { obj.nom_calle_pf = dr.GetString(nom_calle_pf); }
                    if (!dr.IsDBNull(nro_dom_pf)) { obj.nro_dom_pf = dr.GetInt32(nro_dom_pf); }
                    if (!dr.IsDBNull(dominio)) { obj.dominio = dr.GetString(dominio); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(imprime)) { obj.imprime = dr.GetInt32(imprime); }
                    if (!dr.IsDBNull(tipo_cem)) { obj.tipo_cem = dr.GetString(tipo_cem); }
                    if (!dr.IsDBNull(manzana_cem)) { obj.manzana_cem = dr.GetInt32(manzana_cem); }
                    if (!dr.IsDBNull(lote_cem)) { obj.lote_cem = dr.GetInt32(lote_cem); }
                    if (!dr.IsDBNull(parcela_cem)) { obj.parcela_cem = dr.GetInt32(parcela_cem); }
                    if (!dr.IsDBNull(nivel_cem)) { obj.nivel_cem = dr.GetInt32(nivel_cem); }
                    if (!dr.IsDBNull(nro_causa)) { obj.nro_causa = dr.GetInt32(nro_causa); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Cedulones2> read()
        {
            try
            {
                List<Cedulones2> lst = new List<Cedulones2>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cedulones2";
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
        public static Cedulones2 getByPk(int nro_cedulon)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cedulones2 WHERE");
                sql.AppendLine("nro_cedulon = @nro_cedulon");
                Cedulones2 obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", nro_cedulon);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Cedulones2> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(Cedulones2 obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cedulones2(");
                sql.AppendLine("nro_cedulon");
                sql.AppendLine(", fecha_emision");
                sql.AppendLine(", subsistema");
                sql.AppendLine(", tipo_cedulon");
                sql.AppendLine(", no_pagado");
                sql.AppendLine(", activo");
                sql.AppendLine(", nro_emision");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", periodo");
                sql.AppendLine(", vencimiento_1");
                sql.AppendLine(", monto_1");
                sql.AppendLine(", vencimiento_2");
                sql.AppendLine(", monto_2");
                sql.AppendLine(", contado");
                sql.AppendLine(", cheques");
                sql.AppendLine(", monto_arreglo");
                sql.AppendLine(", nro_decreto");
                sql.AppendLine(", nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp");
                sql.AppendLine(", local_esp");
                sql.AppendLine(", nom_calle_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp");
                sql.AppendLine(", ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp");
                sql.AppendLine(", codigo_postal_dom_esp");
                sql.AppendLine(", nro_badec");
                sql.AppendLine(", nro_contrib");
                sql.AppendLine(", nom_badec");
                sql.AppendLine(", nom_calle_pf");
                sql.AppendLine(", nro_dom_pf");
                sql.AppendLine(", dominio");
                sql.AppendLine(", legajo");
                sql.AppendLine(", imprime");
                sql.AppendLine(", tipo_cem");
                sql.AppendLine(", manzana_cem");
                sql.AppendLine(", lote_cem");
                sql.AppendLine(", parcela_cem");
                sql.AppendLine(", nivel_cem");
                sql.AppendLine(", nro_causa");
                sql.AppendLine(", anio");
                sql.AppendLine(", nro_procuracion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_cedulon");
                sql.AppendLine(", @fecha_emision");
                sql.AppendLine(", @subsistema");
                sql.AppendLine(", @tipo_cedulon");
                sql.AppendLine(", @no_pagado");
                sql.AppendLine(", @activo");
                sql.AppendLine(", @nro_emision");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @vencimiento_1");
                sql.AppendLine(", @monto_1");
                sql.AppendLine(", @vencimiento_2");
                sql.AppendLine(", @monto_2");
                sql.AppendLine(", @contado");
                sql.AppendLine(", @cheques");
                sql.AppendLine(", @monto_arreglo");
                sql.AppendLine(", @nro_decreto");
                sql.AppendLine(", @nro_dom_esp");
                sql.AppendLine(", @piso_dpto_esp");
                sql.AppendLine(", @local_esp");
                sql.AppendLine(", @nom_calle_dom_esp");
                sql.AppendLine(", @nom_barrio_dom_esp");
                sql.AppendLine(", @ciudad_dom_esp");
                sql.AppendLine(", @provincia_dom_esp");
                sql.AppendLine(", @pais_dom_esp");
                sql.AppendLine(", @codigo_postal_dom_esp");
                sql.AppendLine(", @nro_badec");
                sql.AppendLine(", @nro_contrib");
                sql.AppendLine(", @nom_badec");
                sql.AppendLine(", @nom_calle_pf");
                sql.AppendLine(", @nro_dom_pf");
                sql.AppendLine(", @dominio");
                sql.AppendLine(", @legajo");
                sql.AppendLine(", @imprime");
                sql.AppendLine(", @tipo_cem");
                sql.AppendLine(", @manzana_cem");
                sql.AppendLine(", @lote_cem");
                sql.AppendLine(", @parcela_cem");
                sql.AppendLine(", @nivel_cem");
                sql.AppendLine(", @nro_causa");
                sql.AppendLine(", @anio");
                sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@fecha_emision", obj.fecha_emision);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@tipo_cedulon", obj.tipo_cedulon);
                    cmd.Parameters.AddWithValue("@no_pagado", obj.no_pagado);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@vencimiento_1", obj.vencimiento_1);
                    cmd.Parameters.AddWithValue("@monto_1", obj.monto_1);
                    cmd.Parameters.AddWithValue("@vencimiento_2", obj.vencimiento_2);
                    cmd.Parameters.AddWithValue("@monto_2", obj.monto_2);
                    cmd.Parameters.AddWithValue("@contado", obj.contado);
                    cmd.Parameters.AddWithValue("@cheques", obj.cheques);
                    cmd.Parameters.AddWithValue("@monto_arreglo", obj.monto_arreglo);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", obj.local_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@codigo_postal_dom_esp", obj.codigo_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_badec", obj.nro_badec);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@nom_badec", obj.nom_badec);
                    cmd.Parameters.AddWithValue("@nom_calle_pf", obj.nom_calle_pf);
                    cmd.Parameters.AddWithValue("@nro_dom_pf", obj.nro_dom_pf);
                    cmd.Parameters.AddWithValue("@dominio", obj.dominio);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@imprime", obj.imprime);
                    cmd.Parameters.AddWithValue("@tipo_cem", obj.tipo_cem);
                    cmd.Parameters.AddWithValue("@manzana_cem", obj.manzana_cem);
                    cmd.Parameters.AddWithValue("@lote_cem", obj.lote_cem);
                    cmd.Parameters.AddWithValue("@parcela_cem", obj.parcela_cem);
                    cmd.Parameters.AddWithValue("@nivel_cem", obj.nivel_cem);
                    cmd.Parameters.AddWithValue("@nro_causa", obj.nro_causa);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void update(Cedulones2 obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cedulones2 SET");
                sql.AppendLine("fecha_emision=@fecha_emision");
                sql.AppendLine(", subsistema=@subsistema");
                sql.AppendLine(", tipo_cedulon=@tipo_cedulon");
                sql.AppendLine(", no_pagado=@no_pagado");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine(", nro_emision=@nro_emision");
                sql.AppendLine(", circunscripcion=@circunscripcion");
                sql.AppendLine(", seccion=@seccion");
                sql.AppendLine(", manzana=@manzana");
                sql.AppendLine(", parcela=@parcela");
                sql.AppendLine(", p_h=@p_h");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", vencimiento_1=@vencimiento_1");
                sql.AppendLine(", monto_1=@monto_1");
                sql.AppendLine(", vencimiento_2=@vencimiento_2");
                sql.AppendLine(", monto_2=@monto_2");
                sql.AppendLine(", contado=@contado");
                sql.AppendLine(", cheques=@cheques");
                sql.AppendLine(", monto_arreglo=@monto_arreglo");
                sql.AppendLine(", nro_decreto=@nro_decreto");
                sql.AppendLine(", nro_dom_esp=@nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp=@piso_dpto_esp");
                sql.AppendLine(", local_esp=@local_esp");
                sql.AppendLine(", nom_calle_dom_esp=@nom_calle_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp=@nom_barrio_dom_esp");
                sql.AppendLine(", ciudad_dom_esp=@ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp=@provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp=@pais_dom_esp");
                sql.AppendLine(", codigo_postal_dom_esp=@codigo_postal_dom_esp");
                sql.AppendLine(", nro_badec=@nro_badec");
                sql.AppendLine(", nro_contrib=@nro_contrib");
                sql.AppendLine(", nom_badec=@nom_badec");
                sql.AppendLine(", nom_calle_pf=@nom_calle_pf");
                sql.AppendLine(", nro_dom_pf=@nro_dom_pf");
                sql.AppendLine(", dominio=@dominio");
                sql.AppendLine(", legajo=@legajo");
                sql.AppendLine(", imprime=@imprime");
                sql.AppendLine(", tipo_cem=@tipo_cem");
                sql.AppendLine(", manzana_cem=@manzana_cem");
                sql.AppendLine(", lote_cem=@lote_cem");
                sql.AppendLine(", parcela_cem=@parcela_cem");
                sql.AppendLine(", nivel_cem=@nivel_cem");
                sql.AppendLine(", nro_causa=@nro_causa");
                sql.AppendLine(", anio=@anio");
                sql.AppendLine(", nro_procuracion=@nro_procuracion");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_cedulon=@nro_cedulon");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@fecha_emision", obj.fecha_emision);
                    cmd.Parameters.AddWithValue("@subsistema", obj.subsistema);
                    cmd.Parameters.AddWithValue("@tipo_cedulon", obj.tipo_cedulon);
                    cmd.Parameters.AddWithValue("@no_pagado", obj.no_pagado);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Parameters.AddWithValue("@nro_emision", obj.nro_emision);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@vencimiento_1", obj.vencimiento_1);
                    cmd.Parameters.AddWithValue("@monto_1", obj.monto_1);
                    cmd.Parameters.AddWithValue("@vencimiento_2", obj.vencimiento_2);
                    cmd.Parameters.AddWithValue("@monto_2", obj.monto_2);
                    cmd.Parameters.AddWithValue("@contado", obj.contado);
                    cmd.Parameters.AddWithValue("@cheques", obj.cheques);
                    cmd.Parameters.AddWithValue("@monto_arreglo", obj.monto_arreglo);
                    cmd.Parameters.AddWithValue("@nro_decreto", obj.nro_decreto);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", obj.local_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@codigo_postal_dom_esp", obj.codigo_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_badec", obj.nro_badec);
                    cmd.Parameters.AddWithValue("@nro_contrib", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@nom_badec", obj.nom_badec);
                    cmd.Parameters.AddWithValue("@nom_calle_pf", obj.nom_calle_pf);
                    cmd.Parameters.AddWithValue("@nro_dom_pf", obj.nro_dom_pf);
                    cmd.Parameters.AddWithValue("@dominio", obj.dominio);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@imprime", obj.imprime);
                    cmd.Parameters.AddWithValue("@tipo_cem", obj.tipo_cem);
                    cmd.Parameters.AddWithValue("@manzana_cem", obj.manzana_cem);
                    cmd.Parameters.AddWithValue("@lote_cem", obj.lote_cem);
                    cmd.Parameters.AddWithValue("@parcela_cem", obj.parcela_cem);
                    cmd.Parameters.AddWithValue("@nivel_cem", obj.nivel_cem);
                    cmd.Parameters.AddWithValue("@nro_causa", obj.nro_causa);
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(Cedulones2 obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cedulones2 ");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_cedulon=@nro_cedulon");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static long InsertCedulon(Cedulones2 oCedulon, SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine(@"INSERT INTO Cedulones2 (
                 nro_cedulon, fecha_emision, subsistema, tipo_cedulon, no_pagado, activo, nro_emision, circunscripcion, seccion, 
                 manzana, parcela, p_h, periodo, vencimiento_1, monto_1, vencimiento_2, monto_2, contado, cheques, monto_arreglo, 
                 nro_dom_esp, piso_dpto_esp, local_esp, nom_calle_dom_esp, nom_barrio_dom_esp, ciudad_dom_esp, provincia_dom_esp, 
                 pais_dom_esp, codigo_postal_dom_esp, nro_badec, nro_contrib, nom_badec, nom_calle_pf, nro_dom_pf, dominio, 
                 legajo, imprime, tipo_cem, manzana_cem, lote_cem, parcela_cem, nivel_cem)
                 VALUES(@nro_cedulon, GETDATE(), @subsistema, @tipo_cedulon, @no_pagado, @activo, @nro_emision, @circunscripcion, 
                 @seccion, @manzana, @parcela, @p_h, @periodo, 
                 // @vencimiento_1, 
                 @monto_1, 
                 // @vencimiento_2, 
                 DATEADD(dd,5,GETDATE()), @monto_2, @contado, @cheques, @monto_arreglo, @nro_dom_esp, @piso_dpto_esp, @local_esp, 
                 @nom_calle_dom_esp, @nom_barrio_dom_esp, @ciudad_dom_esp, @provincia_dom_esp, @pais_dom_esp, @codigo_postal_dom_esp, 
                 @nro_badec, @nro_contrib, @nom_badec, @nom_calle_pf, @nro_dom_pf, @dominio, @legajo, @imprime, @tipo_cem, @manzana_cem, 
                 @lote_cem, @parcela_cem, @nivel_cem)");

                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                oCedulon.nro_cedulon = GetMaxID("Cedulones2", "nro_cedulon");
                cmd.Parameters.AddWithValue("@nro_cedulon", oCedulon.nro_cedulon);
                //cmd.Parameters.AddWithValue("@fecha_emision", oCedulon.fecha_emision));
                cmd.Parameters.AddWithValue("@subsistema", oCedulon.subsistema);
                cmd.Parameters.AddWithValue("@tipo_cedulon", oCedulon.tipo_cedulon);
                cmd.Parameters.AddWithValue("@no_pagado", oCedulon.no_pagado);
                cmd.Parameters.AddWithValue("@activo", oCedulon.activo);
                cmd.Parameters.AddWithValue("@nro_emision", oCedulon.nro_emision);
                cmd.Parameters.AddWithValue("@circunscripcion", oCedulon.circunscripcion);
                cmd.Parameters.AddWithValue("@seccion", oCedulon.seccion);
                cmd.Parameters.AddWithValue("@manzana", oCedulon.manzana);
                cmd.Parameters.AddWithValue("@parcela", oCedulon.parcela);
                cmd.Parameters.AddWithValue("@p_h", oCedulon.p_h);
                cmd.Parameters.AddWithValue("@periodo", oCedulon.periodo);
                // cmd.Parameters.AddWithValue("@vencimiento_1", oCedulon.vencimiento_1));
                cmd.Parameters.AddWithValue("@monto_1", oCedulon.monto_1);
                //cmd.Parameters.AddWithValue("@vencimiento_2", oCedulon.vencimiento_2));
                cmd.Parameters.AddWithValue("@monto_2", oCedulon.monto_2);
                cmd.Parameters.AddWithValue("@contado", oCedulon.contado);
                cmd.Parameters.AddWithValue("@cheques", oCedulon.cheques);
                cmd.Parameters.AddWithValue("@monto_arreglo", oCedulon.monto_arreglo);
                cmd.Parameters.AddWithValue("@nro_dom_esp", oCedulon.nro_dom_esp);
                cmd.Parameters.AddWithValue("@piso_dpto_esp", oCedulon.piso_dpto_esp);
                cmd.Parameters.AddWithValue("@local_esp", oCedulon.local_esp);
                cmd.Parameters.AddWithValue("@nom_calle_dom_esp", oCedulon.nom_calle_dom_esp);
                cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", oCedulon.nom_barrio_dom_esp);
                cmd.Parameters.AddWithValue("@ciudad_dom_esp", oCedulon.ciudad_dom_esp);
                cmd.Parameters.AddWithValue("@provincia_dom_esp", oCedulon.provincia_dom_esp);
                cmd.Parameters.AddWithValue("@pais_dom_esp", oCedulon.pais_dom_esp);
                cmd.Parameters.AddWithValue("@codigo_postal_dom_esp", oCedulon.codigo_postal_dom_esp);
                cmd.Parameters.AddWithValue("@nro_badec", oCedulon.nro_badec);
                cmd.Parameters.AddWithValue("@nro_contrib", oCedulon.nro_contrib);
                if (oCedulon.nom_badec.Length > 40)
                    cmd.Parameters.AddWithValue("@nom_badec", oCedulon.nom_badec.Substring(0, 38));
                else
                    cmd.Parameters.AddWithValue("@nom_badec", oCedulon.nom_badec); ;
                cmd.Parameters.AddWithValue("@nom_calle_pf", oCedulon.nom_calle_pf);
                cmd.Parameters.AddWithValue("@nro_dom_pf", oCedulon.nro_dom_pf);
                cmd.Parameters.AddWithValue("@dominio", oCedulon.dominio);
                cmd.Parameters.AddWithValue("@legajo", oCedulon.legajo);
                cmd.Parameters.AddWithValue("@imprime", oCedulon.imprime);
                cmd.Parameters.AddWithValue("@tipo_cem", oCedulon.tipo_cem);
                cmd.Parameters.AddWithValue("@manzana_cem", oCedulon.manzana_cem);
                cmd.Parameters.AddWithValue("@lote_cem", oCedulon.lote_cem);
                cmd.Parameters.AddWithValue("@parcela_cem", oCedulon.parcela_cem);
                cmd.Parameters.AddWithValue("@nivel_cem", oCedulon.nivel_cem);
                //
                cmd.ExecuteNonQuery();
                InsertDetalleCedulon(oCedulon, cn, trx);
                return oCedulon.nro_cedulon;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw new Exception(e.ToString());
            }

        }
        public static void InsertDetalleCedulon(Cedulones2 oCedulon, SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"set nocount off;
                           INSERT INTO Deudas_x_cedulon3
                           (nro_cedulon, nro_transaccion, monto_pagado, descuento_anticipo, 
                            vencimiento_transaccion, pago_parcial, categoria_deuda)
                            VALUES(@nro_cedulon, @nro_transaccion, @monto_pagado, @descuento_anticipo,
                            DATEADD(dd, 5, GETDATE()), @pago_parcial, @categoria_deuda)";
                decimal descuento = 0;
                long nro_cedulon = oCedulon.nro_cedulon;
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Transaction = trx;
                cmd.Parameters.AddWithValue("@nro_cedulon", 0);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@monto_pagado", 0);
                cmd.Parameters.AddWithValue("@descuento_anticipo", 0);
                //cmd.Parameters.AddWithValue("@vencimiento_transaccion", null));
                cmd.Parameters.AddWithValue("@pago_parcial", false);
                cmd.Parameters.AddWithValue("@categoria_deuda", 0);
                foreach (var item in oCedulon.lstDeuda)
                {
                    cmd.Parameters["@nro_cedulon"].Value = nro_cedulon;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.Parameters["@monto_pagado"].Value = item.importe;
                    cmd.Parameters["@descuento_anticipo"].Value = descuento;
                    cmd.Parameters["@pago_parcial"].Value = item.pago_parcial;
                    cmd.Parameters["@categoria_deuda"].Value = item.categoria_deuda;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query! " + e.ToString());
                throw new Exception("Error en detalle de cedulon! " + e.ToString());
            }
        }
        public static long InsertCedulonScope(Cedulones2 oCedulon,  SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine(@"INSERT INTO Cedulones2 (
                 nro_cedulon, fecha_emision, subsistema, tipo_cedulon, no_pagado, activo, nro_emision, circunscripcion, seccion, 
                 manzana, parcela, p_h, periodo, vencimiento_1, monto_1, vencimiento_2, monto_2, contado, cheques, monto_arreglo, 
                 nro_dom_esp, piso_dpto_esp, local_esp, nom_calle_dom_esp, nom_barrio_dom_esp, ciudad_dom_esp, provincia_dom_esp, 
                 pais_dom_esp, codigo_postal_dom_esp, nro_badec, nro_contrib, nom_badec, nom_calle_pf, nro_dom_pf, dominio, 
                 legajo, imprime, tipo_cem, manzana_cem, lote_cem, parcela_cem, nivel_cem)
                 VALUES(@nro_cedulon, GETDATE(), @subsistema, @tipo_cedulon, @no_pagado, @activo, @nro_emision, @circunscripcion, 
                 @seccion, @manzana, @parcela, @p_h, @periodo, 
                 // @vencimiento_1, 
                 @monto_1, 
                 // @vencimiento_2, 
                 DATEADD(dd,5,GETDATE()), @monto_2, @contado, @cheques, @monto_arreglo, @nro_dom_esp, @piso_dpto_esp, @local_esp, 
                 @nom_calle_dom_esp, @nom_barrio_dom_esp, @ciudad_dom_esp, @provincia_dom_esp, @pais_dom_esp, @codigo_postal_dom_esp, 
                 @nro_badec, @nro_contrib, @nom_badec, @nom_calle_pf, @nro_dom_pf, @dominio, @legajo, @imprime, @tipo_cem, @manzana_cem, 
                 @lote_cem, @parcela_cem, @nivel_cem)");
               // using (SqlConnection cn = GetConnection())
                //{
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    oCedulon.nro_cedulon = GetMaxID("Cedulones2", "nro_cedulon");
                    cmd.Parameters.AddWithValue("@nro_cedulon", oCedulon.nro_cedulon);
                    //cmd.Parameters.AddWithValue("@fecha_emision", oCedulon.fecha_emision));
                    cmd.Parameters.AddWithValue("@subsistema", oCedulon.subsistema);
                    cmd.Parameters.AddWithValue("@tipo_cedulon", oCedulon.tipo_cedulon);
                    cmd.Parameters.AddWithValue("@no_pagado", oCedulon.no_pagado);
                    cmd.Parameters.AddWithValue("@activo", oCedulon.activo);
                    cmd.Parameters.AddWithValue("@nro_emision", oCedulon.nro_emision);
                    cmd.Parameters.AddWithValue("@circunscripcion", oCedulon.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", oCedulon.seccion);
                    cmd.Parameters.AddWithValue("@manzana", oCedulon.manzana);
                    cmd.Parameters.AddWithValue("@parcela", oCedulon.parcela);
                    cmd.Parameters.AddWithValue("@p_h", oCedulon.p_h);
                    cmd.Parameters.AddWithValue("@periodo", oCedulon.periodo);
                    // cmd.Parameters.AddWithValue("@vencimiento_1", oCedulon.vencimiento_1));
                    cmd.Parameters.AddWithValue("@monto_1", oCedulon.monto_1);
                    //cmd.Parameters.AddWithValue("@vencimiento_2", oCedulon.vencimiento_2));
                    cmd.Parameters.AddWithValue("@monto_2", oCedulon.monto_2);
                    cmd.Parameters.AddWithValue("@contado", oCedulon.contado);
                    cmd.Parameters.AddWithValue("@cheques", oCedulon.cheques);
                    cmd.Parameters.AddWithValue("@monto_arreglo", oCedulon.monto_arreglo);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", oCedulon.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", oCedulon.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@local_esp", oCedulon.local_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", oCedulon.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", oCedulon.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", oCedulon.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", oCedulon.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", oCedulon.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@codigo_postal_dom_esp", oCedulon.codigo_postal_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_badec", oCedulon.nro_badec);
                    cmd.Parameters.AddWithValue("@nro_contrib", oCedulon.nro_contrib);
                    if (oCedulon.nom_badec.Length > 40)
                        cmd.Parameters.AddWithValue("@nom_badec", oCedulon.nom_badec.Substring(0, 38));
                    else
                        cmd.Parameters.AddWithValue("@nom_badec", oCedulon.nom_badec); ;
                    cmd.Parameters.AddWithValue("@nom_calle_pf", oCedulon.nom_calle_pf);
                    cmd.Parameters.AddWithValue("@nro_dom_pf", oCedulon.nro_dom_pf);
                    cmd.Parameters.AddWithValue("@dominio", oCedulon.dominio);
                    cmd.Parameters.AddWithValue("@legajo", oCedulon.legajo);
                    cmd.Parameters.AddWithValue("@imprime", oCedulon.imprime);
                    cmd.Parameters.AddWithValue("@tipo_cem", oCedulon.tipo_cem);
                    cmd.Parameters.AddWithValue("@manzana_cem", oCedulon.manzana_cem);
                    cmd.Parameters.AddWithValue("@lote_cem", oCedulon.lote_cem);
                    cmd.Parameters.AddWithValue("@parcela_cem", oCedulon.parcela_cem);
                    cmd.Parameters.AddWithValue("@nivel_cem", oCedulon.nivel_cem);
                    //
                    //cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    InsertDetalleCedulonScope(oCedulon, con, trx);
                    return oCedulon.nro_cedulon;
               // }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw new Exception(e.ToString());
            }

        }
        public static void InsertDetalleCedulonScope(Cedulones2 oCedulon, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"set nocount off;
                           INSERT INTO Deudas_x_cedulon3
                           (nro_cedulon, nro_transaccion, monto_pagado, descuento_anticipo, 
                            vencimiento_transaccion, pago_parcial, categoria_deuda)
                            VALUES(@nro_cedulon, @nro_transaccion, @monto_pagado, @descuento_anticipo,
                            DATEADD(dd, 5, GETDATE()), @pago_parcial, @categoria_deuda)";
                decimal descuento = 0;
                long nro_cedulon = oCedulon.nro_cedulon;
               // using (SqlConnection cn = GetConnection())
               // {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = trx;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@nro_cedulon", 0);
                    cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                    cmd.Parameters.AddWithValue("@monto_pagado", 0);
                    cmd.Parameters.AddWithValue("@descuento_anticipo", 0);
                    //cmd.Parameters.AddWithValue("@vencimiento_transaccion", null));
                    cmd.Parameters.AddWithValue("@pago_parcial", false);
                    cmd.Parameters.AddWithValue("@categoria_deuda", 0);
                    foreach (var item in oCedulon.lstDeuda)
                    {
                        cmd.Parameters["@nro_cedulon"].Value = nro_cedulon;
                        cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                        cmd.Parameters["@monto_pagado"].Value = item.importe;
                        cmd.Parameters["@descuento_anticipo"].Value = descuento;
                        cmd.Parameters["@pago_parcial"].Value = item.pago_parcial;
                        cmd.Parameters["@categoria_deuda"].Value = item.categoria_deuda;
                        cmd.ExecuteNonQuery();
                    }
               // }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query! " + e.ToString());
                throw new Exception("Error en detalle de cedulon! " + e.ToString());
            }
        }



    }
}

