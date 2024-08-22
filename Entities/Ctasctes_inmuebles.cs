using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_Inm.Entities.HELPERS;

using Web_Api_Inm.Entities;
using WSAfip;
using System.Runtime.ConstrainedExecution;

namespace Web_Api_Inm
{
    public class Ctasctes_inmuebles : DALBase
    {
        public int tipo_transaccion { get; set; }
        public int nro_transaccion { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public DateTime? fecha_transaccion { get; set; }
        public string periodo { get; set; }
        public bool cedulon_impreso { get; set; }
        public int nro_pago_parcial { get; set; }
        public decimal monto_original { get; set; }
        public int nro_plan { get; set; }
        public bool pagado { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public bool deuda_activa { get; set; }
        public bool pago_parcial { get; set; }
        public int categoria_deuda { get; set; }
        public int nro_procuracion { get; set; }
        public DateTime? vencimiento { get; set; }
        public int nro_cedulon { get; set; }
        public decimal monto_pagado { get; set; }
        public decimal recargo { get; set; }
        public decimal honorarios { get; set; }
        public decimal iva_hons { get; set; }
        public Int16 tipo_deuda { get; set; }
        public string decreto { get; set; }
        public string observaciones { get; set; }
        public Int64 nro_cedulon_paypertic { get; set; }
        //
        //Las propiedades de abajo son agregadadas
        //
        public string des_movimiento { get; set; }
        public string des_categoria { get; set; }
        public decimal deuda { get; set; }
        public int sel { get; set; }
        public decimal costo_financiero { get; set; }
        public string des_rubro { get; set; }
        public int cod_tipo_per { get; set; }
        public decimal sub_total { get; set; }

        public Ctasctes_inmuebles()
        {
            tipo_transaccion = 0;
            nro_transaccion = 0;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            fecha_transaccion = null;// DateTime.Now;
            periodo = string.Empty;
            cedulon_impreso = false;
            nro_pago_parcial = 0;
            monto_original = 0;
            nro_plan = 0;
            pagado = false;
            debe = 0;
            haber = 0;
            deuda_activa = false;
            pago_parcial = false;
            categoria_deuda = 0;
            nro_procuracion = 0;
            vencimiento = null;// DateTime.Now;
            nro_cedulon = 0;
            monto_pagado = 0;
            recargo = 0;
            honorarios = 0;
            iva_hons = 0;
            tipo_deuda = 0;
            decreto = string.Empty;
            observaciones = string.Empty;
            nro_cedulon_paypertic = 0;
            //
            des_movimiento = string.Empty;
            des_categoria = string.Empty;
            deuda = 0;
            sel = 0;
            costo_financiero = 0;
            des_rubro = string.Empty;
            cod_tipo_per = 0;

        }

        private static List<Ctasctes_inmuebles> mapeo(SqlDataReader dr)
        {
            List<Ctasctes_inmuebles> lst = new List<Ctasctes_inmuebles>();
            Ctasctes_inmuebles obj;
            if (dr.HasRows)
            {
                int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                int periodo = dr.GetOrdinal("periodo");
                int cedulon_impreso = dr.GetOrdinal("cedulon_impreso");
                int nro_pago_parcial = dr.GetOrdinal("nro_pago_parcial");
                int monto_original = dr.GetOrdinal("monto_original");
                int nro_plan = dr.GetOrdinal("nro_plan");
                int pagado = dr.GetOrdinal("pagado");
                int debe = dr.GetOrdinal("debe");
                int haber = dr.GetOrdinal("haber");
                int deuda_activa = dr.GetOrdinal("deuda_activa");
                int pago_parcial = dr.GetOrdinal("pago_parcial");
                int categoria_deuda = dr.GetOrdinal("categoria_deuda");
                int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                int monto_pagado = dr.GetOrdinal("monto_pagado");
                int recargo = dr.GetOrdinal("recargo");
                int honorarios = dr.GetOrdinal("honorarios");
                int iva_hons = dr.GetOrdinal("iva_hons");
                int tipo_deuda = dr.GetOrdinal("tipo_deuda");
                int decreto = dr.GetOrdinal("decreto");
                int observaciones = dr.GetOrdinal("observaciones");
                int nro_cedulon_paypertic = dr.GetOrdinal("nro_cedulon_paypertic");
                while (dr.Read())
                {
                    obj = new Ctasctes_inmuebles();
                    if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = dr.GetDateTime(fecha_transaccion); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(cedulon_impreso)) { obj.cedulon_impreso = dr.GetBoolean(cedulon_impreso); }
                    if (!dr.IsDBNull(nro_pago_parcial)) { obj.nro_pago_parcial = dr.GetInt32(nro_pago_parcial); }
                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                    if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                    if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                    if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                    if (!dr.IsDBNull(deuda_activa)) { obj.deuda_activa = dr.GetBoolean(deuda_activa); }
                    if (!dr.IsDBNull(pago_parcial)) { obj.pago_parcial = dr.GetBoolean(pago_parcial); }
                    if (!dr.IsDBNull(categoria_deuda)) { obj.categoria_deuda = dr.GetInt32(categoria_deuda); }
                    if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                    if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                    if (!dr.IsDBNull(recargo)) { obj.recargo = dr.GetDecimal(recargo); }
                    if (!dr.IsDBNull(honorarios)) { obj.honorarios = dr.GetDecimal(honorarios); }
                    if (!dr.IsDBNull(iva_hons)) { obj.iva_hons = dr.GetDecimal(iva_hons); }
                    if (!dr.IsDBNull(tipo_deuda)) { obj.tipo_deuda = dr.GetInt16(tipo_deuda); }
                    if (!dr.IsDBNull(decreto)) { obj.decreto = dr.GetString(decreto); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(nro_cedulon_paypertic)) { obj.nro_cedulon_paypertic = dr.GetInt64(nro_cedulon_paypertic); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Ctasctes_inmuebles> read()
        {
            try
            {
                List<Ctasctes_inmuebles> lst = new List<Ctasctes_inmuebles>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Ctasctes_inmuebles";
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

        public static Ctasctes_inmuebles getByPk(int tipo_transaccion, int nro_transaccion, int nro_pago_parcial)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Ctasctes_inmuebles WHERE");
                sql.AppendLine("tipo_transaccion = @tipo_transaccion");
                sql.AppendLine("AND nro_transaccion = @nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial = @nro_pago_parcial");
                Ctasctes_inmuebles obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", nro_pago_parcial);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ctasctes_inmuebles> lst = mapeo(dr);
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

        public static int insert(Ctasctes_inmuebles obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_inmuebles(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", cedulon_impreso");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", nro_plan");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", deuda_activa");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", categoria_deuda");
                sql.AppendLine(", nro_procuracion");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_cedulon");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", recargo");
                sql.AppendLine(", honorarios");
                sql.AppendLine(", iva_hons");
                sql.AppendLine(", tipo_deuda");
                sql.AppendLine(", decreto");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", nro_cedulon_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @cedulon_impreso");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @nro_plan");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @deuda_activa");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @categoria_deuda");
                sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_cedulon");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @recargo");
                sql.AppendLine(", @honorarios");
                sql.AppendLine(", @iva_hons");
                sql.AppendLine(", @tipo_deuda");
                sql.AppendLine(", @decreto");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @nro_cedulon_paypertic");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", obj.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@cedulon_impreso", obj.cedulon_impreso);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@deuda_activa", obj.deuda_activa);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@categoria_deuda", obj.categoria_deuda);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Ctasctes_inmuebles obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Ctasctes_inmuebles SET");
                sql.AppendLine("circunscripcion=@circunscripcion");
                sql.AppendLine(", seccion=@seccion");
                sql.AppendLine(", manzana=@manzana");
                sql.AppendLine(", parcela=@parcela");
                sql.AppendLine(", p_h=@p_h");
                sql.AppendLine(", fecha_transaccion=@fecha_transaccion");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", cedulon_impreso=@cedulon_impreso");
                sql.AppendLine(", monto_original=@monto_original");
                sql.AppendLine(", nro_plan=@nro_plan");
                sql.AppendLine(", pagado=@pagado");
                sql.AppendLine(", debe=@debe");
                sql.AppendLine(", haber=@haber");
                sql.AppendLine(", deuda_activa=@deuda_activa");
                sql.AppendLine(", pago_parcial=@pago_parcial");
                sql.AppendLine(", categoria_deuda=@categoria_deuda");
                sql.AppendLine(", nro_procuracion=@nro_procuracion");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", nro_cedulon=@nro_cedulon");
                sql.AppendLine(", monto_pagado=@monto_pagado");
                sql.AppendLine(", recargo=@recargo");
                sql.AppendLine(", honorarios=@honorarios");
                sql.AppendLine(", iva_hons=@iva_hons");
                sql.AppendLine(", tipo_deuda=@tipo_deuda");
                sql.AppendLine(", decreto=@decreto");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", nro_cedulon_paypertic=@nro_cedulon_paypertic");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@fecha_transaccion", obj.fecha_transaccion);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@cedulon_impreso", obj.cedulon_impreso);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@deuda_activa", obj.deuda_activa);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@categoria_deuda", obj.categoria_deuda);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Ctasctes_inmuebles obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Ctasctes_inmuebles ");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Periodos> IniciarCtacte(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                string sql = string.Empty;
                sql = @"SELECT periodo, vencimiento_1 as vencimiento, 0 as sel
                        FROM VENCIMIENTOS_PERIODOS2 V (NOLOCK)
                        WHERE
                        v.cod_tipo_per<>4 AND
                        v.periodo>='2021/00' AND
                        NOT EXISTS (SELECT * 
                            FROM Ctasctes_inmuebles C
                            WHERE C.tipo_transaccion=1 
                                AND C.circunscripcion=@cir
                                AND C.seccion=@sec
                                AND C.manzana=@man
                                AND C.parcela=@par
                                AND C.p_h=@p_h
                                AND C.periodo=V.periodo)
                                AND V.subsistema=1
                        ORDER BY V.periodo";
                List<Periodos> lst = new();
                Periodos? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int periodo = dr.GetOrdinal("periodo");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina).ToString(); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Confirma_iniciar_ctacte(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                int nro_transaccion = 0;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_inmuebles(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", cedulon_impreso");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", monto_original");
                //sql.AppendLine(", nro_plan");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", deuda_activa");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", categoria_deuda");
                //sql.AppendLine(", nro_procuracion");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_cedulon");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", recargo");
                sql.AppendLine(", honorarios");
                sql.AppendLine(", iva_hons");
                sql.AppendLine(", tipo_deuda");
                sql.AppendLine(", decreto");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", nro_cedulon_paypertic");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @cedulon_impreso");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @monto_original");
                //sql.AppendLine(", @nro_plan");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @deuda_activa");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @categoria_deuda");
                //sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_cedulon");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @recargo");
                sql.AppendLine(", @honorarios");
                sql.AppendLine(", @iva_hons");
                sql.AppendLine(", @tipo_deuda");
                sql.AppendLine(", @decreto");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @nro_cedulon_paypertic");
                sql.AppendLine(")");
                //using (SqlConnection cn = GetConnectionSIIMVA())
                //{
                nro_transaccion = GetNroTransaccion(1);
                UpdateNroTransaccion(1, nro_transaccion + lst.Count);
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@tipo_transaccion", 1);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@circunscripcion", 0);
                cmd.Parameters.AddWithValue("@seccion", 0);
                cmd.Parameters.AddWithValue("@manzana", 0);
                cmd.Parameters.AddWithValue("@parcela", 0);
                cmd.Parameters.AddWithValue("@p_h", 0);
                cmd.Parameters.AddWithValue("@fecha_transaccion", 0);
                cmd.Parameters.AddWithValue("@periodo", string.Empty);
                cmd.Parameters.AddWithValue("@cedulon_impreso", true);
                cmd.Parameters.AddWithValue("@nro_pago_parcial", 0);
                cmd.Parameters.AddWithValue("@monto_original", 0);
                //cmd.Parameters.AddWithValue("@nro_plan", null);
                cmd.Parameters.AddWithValue("@pagado", false);
                cmd.Parameters.AddWithValue("@debe", 0);
                cmd.Parameters.AddWithValue("@haber", 0);
                cmd.Parameters.AddWithValue("@deuda_activa", true);
                cmd.Parameters.AddWithValue("@pago_parcial", 0);
                cmd.Parameters.AddWithValue("@categoria_deuda", 1);
                //cmd.Parameters.AddWithValue("@nro_procuracion", null);
                cmd.Parameters.AddWithValue("@vencimiento", null);
                cmd.Parameters.AddWithValue("@nro_cedulon", 0);
                cmd.Parameters.AddWithValue("@monto_pagado", 0);
                cmd.Parameters.AddWithValue("@recargo", 0);
                cmd.Parameters.AddWithValue("@honorarios", 0);
                cmd.Parameters.AddWithValue("@iva_hons", 0);
                cmd.Parameters.AddWithValue("@tipo_deuda", 1);
                cmd.Parameters.AddWithValue("@decreto", 0);
                cmd.Parameters.AddWithValue("@observaciones", string.Empty);
                cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", 0);

                foreach (var item in lst)
                {
                    nro_transaccion += 1;
                    cmd.Parameters["@tipo_transaccion"].Value = 1;
                    cmd.Parameters["@periodo"].Value = item.periodo;
                    cmd.Parameters["@nro_transaccion"].Value = nro_transaccion;
                    cmd.Parameters["@nro_pago_parcial"].Value = 0;
                    cmd.Parameters["@circunscripcion"].Value = cir;
                    cmd.Parameters["@seccion"].Value = sec;
                    cmd.Parameters["@manzana"].Value = man;
                    cmd.Parameters["@parcela"].Value = par;
                    cmd.Parameters["@p_h"].Value = p_h;
                    cmd.Parameters["@vencimiento"].Value = item.vencimiento ?? (object)DBNull.Value;
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Ctasctes_inmuebles> PeriodosRecalculo(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT a.nro_transaccion, a.periodo, a.monto_original,
                                a.debe, a.vencimiento, v.cod_tipo_per as tipo_per
                            FROM CTASCTES_INMUEBLES a WITH (NOLOCK)
                            join VENCIMIENTOS_PERIODOS2 v on
                            v.subsistema=1 and
                            v.periodo=a.periodo
                            WHERE
                                a.circunscripcion=@cir AND
                                a.seccion=@sec AND
                                a.manzana=@man AND
                                a.parcela=@par AND
                                a.p_h=@p_h AND
                                a.tipo_transaccion=1 AND pagado=0 AND
                                a.pago_parcial=0 AND nro_plan IS null AND
                                a.nro_procuracion IS NULL AND
                                a.categoria_deuda = 1

                            UNION ALL

                            SELECT b.nro_transaccion, a.periodo, a.monto_1 as monto_original,
                                a.monto_2 as debe, a.vencimiento_1 as vencimiento,
                                4 as tipo_per
                            FROM Cedulones2 A  WITH (NOLOCK)
                            JOIN Deudas_x_cedulon3 b on
                                a.nro_cedulon=b.nro_cedulon
                            WHERE
                                a.circunscripcion=@cir AND
                                a.seccion=@sec AND
                                a.manzana=@man AND
                                a.parcela=@par AND
                                a.p_h=@p_h AND
                                A.no_pagado=1 AND
                                A.subsistema=4 and
                                A.tipo_cedulon=1 and 
                                A.activo=1
                            ORDER by A.periodo";
                List<Ctasctes_inmuebles> lst = new();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ctasctes_inmuebles? obj;
                    if (dr.HasRows)
                    {
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int tipo_per = dr.GetOrdinal("tipo_per");
                        while (dr.Read())
                        {
                            obj = new Ctasctes_inmuebles();

                            if (!dr.IsDBNull(nro_transaccion))
                            { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                            if (!dr.IsDBNull(tipo_per)) { obj.tipo_deuda = dr.GetInt16(tipo_per); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Combo> ListarCategoriasInmuebles()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CATE_DEUDA_INMUEBLE";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Combo? obj;
                    obj = new Combo();
                    obj.text = "TODAS LAS DEUDAS";
                    obj.value = "0";
                    lst.Add(obj);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<TARJETAS_DEBITOS> ListarTarjetas()
        {
            try
            {
                string sql = @"SELECT cod_tarjeta,des_tarjeta 
                           FROM TARJETAS_DEBITOS 
                           WHERE cod_paypertic IS NOT null   and activa=1";
                List<TARJETAS_DEBITOS> lst = new List<TARJETAS_DEBITOS>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    TARJETAS_DEBITOS? obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.cod_tarjeta = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.des_tarjeta = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Planes_cobro> ListarPlanesdeTarjetas(int cod_tarjeta, int subsistema)
        {
            try
            {
                List<Planes_cobro> lst = new List<Planes_cobro>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT pc.cod_plan,pc.descripcion,TD.debito,TD.des_tarjeta,
                                            pc.Con_dto_interes,pc.ali_dto_interes,pc.Con_costo_financiero,
                                            pc.ali_costo_financiero,pc.suma_descadic 
                                        FROM Planes_cobro pc 
                                        LEFT JOIN TARJETAS_DEBITOS td ON 
                                            td.cod_tarjeta = pc.cod_tarjeta 
                                        WHERE pc.subsistema=@subistema AND 
                                            pc.activo_windows=1 AND 
                                            pc.cod_tarjeta=@cod_tarjeta";
                    cmd.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                    cmd.Parameters.AddWithValue("@subsistema", subsistema);//5
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Planes_cobro? obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Planes_cobro();
                            if (!dr.IsDBNull(0)) { obj.cod_plan = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.debito = dr.GetInt16(2); }
                            if (!dr.IsDBNull(3)) { obj.des_tarjeta = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.con_dto_interes = dr.GetInt16(4); }
                            if (!dr.IsDBNull(5)) { obj.ali_dto_interes = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.con_costo_financiero = dr.GetInt16(6); }
                            if (!dr.IsDBNull(7)) { obj.ali_costo_financiero = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.suma_descadic = dr.GetBoolean(8); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Ctasctes_inmuebles> ListarCtacte(int cir, int sec, int man, int par, int p_h,
            int tipo_consulta, int cate_deuda_desde, int cate_deuda_hasta)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine(@"SELECT 
                                    movimiento=
                                        (SELECT t.Descripcion 
                                        FROM TIPOS_TRANSACCIONES t 
                                        WHERE t.tipo_transaccion=a.Tipo_transaccion), 
                                    a.tipo_transaccion, 
                                    a.nro_transaccion, 
                                    a.periodo, 
                                    a.fecha_transaccion, 
                                    a.monto_original, 
                                    a.debe, 
                                    a.haber, 
                                    a.nro_plan, 
                                    a.nro_procuracion,
                                    categoria = 
                                        (SELECT c.des_categoria 
                                        FROM CATE_DEUDA_INMUEBLE c 
                                        WHERE c.cod_categoria = a.categoria_deuda ),
                                    a.pagado,
                                    a.nro_cedulon
                                    FROM CTASCTES_INMUEBLES A WITH (NOLOCK) 
                                    WHERE  
                                      A.circunscripcion=@cir AND
                                      A.seccion=@sec AND
                                      A.manzana=@man AND
                                      A.parcela=@par AND
                                      A.p_h=@p_h AND 
                                      A.deuda_activa = 1 AND");
                if (tipo_consulta == 1)// toda la cuenta corriente
                {
                    if (cate_deuda_desde == cate_deuda_hasta)
                    {
                        strSQL.AppendLine(@"A.categoria_deuda = @categoria_desde");
                    }
                    else
                    {
                        strSQL.AppendLine(@"A.categoria_deuda between @categoria_desde and @categoria_hasta");
                    }
                    strSQL.AppendLine(@"ORDER BY PERIODO, NRO_TRANSACCION, TIPO_TRANSACCION");
                }
                else  // solo deudas
                {
                    if (cate_deuda_desde == cate_deuda_hasta)
                    {
                        strSQL.AppendLine(@"A.categoria_deuda = @categoria_desde AND");
                    }
                    else
                    {
                        strSQL.AppendLine(@"A.categoria_deuda between @categoria_desde and @categoria_hasta AND");
                    }
                    strSQL.AppendLine(@"((A.tipo_transaccion=1 AND A.pagado=0) OR (A.tipo_transaccion <> 1 AND NOT EXISTS 
                        (SELECT * FROM CTASCTES_INMUEBLES B WHERE B.tipo_transaccion = 1 AND B.nro_transaccion = A.nro_transaccion AND pagado = 1)))");
                    strSQL.AppendLine(@"ORDER BY PERIODO, NRO_TRANSACCION, TIPO_TRANSACCION");
                }
                List<Ctasctes_inmuebles> lst = new List<Ctasctes_inmuebles>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@categoria_desde", cate_deuda_desde);
                    cmd.Parameters.AddWithValue("@categoria_hasta", cate_deuda_hasta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ctasctes_inmuebles? obj;
                    if (dr.HasRows)
                    {
                        int movimiento = dr.GetOrdinal("movimiento");
                        int periodo = dr.GetOrdinal("periodo");
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int haber = dr.GetOrdinal("haber");
                        int nro_plan = dr.GetOrdinal("nro_plan");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int categoria = dr.GetOrdinal("categoria");
                        int pagado = dr.GetOrdinal("pagado");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(movimiento)) { obj.des_movimiento = dr.GetString(movimiento); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = Convert.ToDateTime(dr.GetDateTime(fecha_transaccion), culturaFecArgentina); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                            if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(categoria)) { obj.des_categoria = dr.GetString(categoria); }
                            if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            lst.Add(obj);
                        }
                    }

                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (i == 0)
                            lst[i].sub_total = -lst[i].debe + lst[i].haber;
                        else
                            lst[i].sub_total = lst[i - 1].sub_total - lst[i].debe + lst[i].haber;
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            try
            {
                string strSQL = @"SELECT A.*, B.des_categoria,
                                    des_movimiento=(SELECT t.Descripcion 
                                                FROM TIPOS_TRANSACCIONES t 
                                                WHERE t.tipo_transaccion=a.Tipo_transaccion)
                                    FROM CTASCTES_INMUEBLES A
                                    JOIN CATE_DEUDA_INMUEBLE B on
                                      A.categoria_deuda=B.cod_categoria
                                    WHERE
                                      A.tipo_transaccion=@tipo_transaccion AND
                                      A.nro_transaccion=@nro_transaccion";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder strRetorno = new StringBuilder();
                List<Ctasctes_inmuebles> lst = new List<Ctasctes_inmuebles>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ctasctes_inmuebles? obj;
                    obj = new();
                    if (dr.HasRows)
                    {
                        int des_movimiento = dr.GetOrdinal("des_movimiento");
                        int periodo = dr.GetOrdinal("periodo");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int fecha_transaccion = dr.GetOrdinal("fecha_transaccion");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int haber = dr.GetOrdinal("haber");
                        int nro_plan = dr.GetOrdinal("nro_plan");
                        int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                        int categoria = dr.GetOrdinal("des_categoria");
                        int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                        int monto_pagado = dr.GetOrdinal("monto_pagado");
                        while (dr.Read())
                        {
                            //obj = new();
                            obj.tipo_transaccion = tipo_transaccion;
                            obj.nro_transaccion = nro_transaccion;
                            if (!dr.IsDBNull(des_movimiento)) { obj.des_movimiento = dr.GetString(des_movimiento); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina); }
                            if (!dr.IsDBNull(fecha_transaccion)) { obj.fecha_transaccion = Convert.ToDateTime(dr.GetDateTime(fecha_transaccion), culturaFecArgentina); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                            if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                            if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                            if (!dr.IsDBNull(categoria)) { obj.des_categoria = dr.GetString(categoria); }
                            if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                            if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                            lst.Add(obj);
                        }
                        if (lst.Count > 0)
                            obj = lst[0];
                        strRetorno.AppendLine("Fecha Transacci�n: " + Convert.ToString(obj.fecha_transaccion, culturaFecArgentina));
                        strRetorno.AppendLine("Vencimiento: " + Convert.ToString(obj.vencimiento, culturaFecArgentina));
                        switch (obj.tipo_transaccion)
                        {
                            case 1:
                                strRetorno.AppendLine("Mov.Deuda");
                                strRetorno.AppendLine("Per�odo: " + obj.periodo);
                                strRetorno.AppendLine(obj.des_categoria.ToString());
                                if (obj.pago_parcial)
                                    strRetorno.AppendLine("Deuda con Pago Parcial");
                                strRetorno.AppendLine("Nro Transacci�n: " + obj.nro_transaccion.ToString());
                                break;
                            case 2:
                                if (obj.nro_cedulon != 0)
                                    strRetorno.AppendLine("Mov.Pago con N� Cedulon:" + obj.nro_cedulon.ToString());
                                else
                                    strRetorno.AppendLine("Mov.Pago");
                                strRetorno.AppendLine("Per�odo:" + obj.periodo.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                if (obj.pago_parcial)
                                    strRetorno.AppendLine("Pago Parcial");
                                strRetorno.AppendLine("Nro Transacci�n: " + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine("Monto Pagado:" + obj.monto_pagado.ToString());
                                break;
                            case 3:
                                strRetorno.AppendLine("Mov.Fin de Plan de Pago");
                                strRetorno.AppendLine("Plan de Pago N�:" + obj.nro_plan.ToString());
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 4:
                                strRetorno.AppendLine("Mov.Bonificaci�n por pago anticipado");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 5:
                                strRetorno.AppendLine("Mov.Ajuste Positivo");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 6:
                                strRetorno.AppendLine("Mov.Ajuste Negativo");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 7:
                                strRetorno.AppendLine("Mov.Cancelaci�n Operativa");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 8:
                                strRetorno.AppendLine("Mov.Decreto o Resoluci�n");
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            case 9:
                                strRetorno.AppendLine("Mov.Baja de Plan de Pagos");
                                strRetorno.AppendLine("Plan de Pago N�:" + obj.nro_plan.ToString());
                                strRetorno.AppendLine("Nro Transaccion:" + obj.nro_transaccion.ToString());
                                strRetorno.AppendLine(obj.des_categoria);
                                break;
                            default:
                                break;
                        }
                    }
                    if (obj.nro_cedulon > 0)
                    { strRetorno.AppendLine(Tipos_pago(obj.nro_cedulon)); }
                    string texto = strRetorno.ToString();
                    string[] lineas = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    string ret = "<div>";
                    foreach (string linea in lineas)
                    {
                        ret += string.Format("<p>{0}</p>", linea);
                    }
                    ret += "</div>";
                    return ret;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string Tipos_pago(int nro_cedulon)
        {
            try
            {
                string strSQL = @"
                                SELECT c.nro_movimiento, Tipo_pago=t.Descripcion,forma_pago=e.descripcion, 
                                CASE 
                                   WHEN c.efectivo>0 THEN 'EFECTIVO'
                                   ELSE   ''
                                   END AS EFECTIVO,
                                CASE   
                                   WHEN C.debitos>0 THEN 'DEBITO'
                                   ELSE   ''
                                   END AS DEBITO,
                                CASE   
                                   WHEN C.creditos>0 THEN 'CREDITO'
                                   ELSE   ''
                                   END AS CREDITO,
                                CASE   
                                   WHEN C.cheques>0 THEN 'CHEQUE'
                                   ELSE   ''
                                   END AS CHEQUE,
                                CASE   
                                   WHEN C.documentos>0 THEN 'DOCUMENTO'
                                   ELSE   ''
                                   END AS DOCUMENTOS,   
                                CASE   
                                   WHEN C.canje>0 THEN 'CANJE'
                                   ELSE   ''
                                   END AS CANJE,
   
                                CASE   
                                   WHEN C.bonos>0 THEN 'BONOS'
                                   ELSE   ''
                                   END AS BONOS ,     
                                CASE   
                                   WHEN C.acreditacion_bcos>0 THEN 'ACRED. BANCOS'
                                   ELSE   ''
                                   END AS BANCOS      
     
                                FROM ENTIDAD_RECAUDADORA e 
                                LEFT JOIN MOVIM_CAJA_V2 c ON e.Id_entidad=c.cod_forma_pago
                                LEFT JOIN COMPR_X_MOVIM_CAJA_V2 d ON d.nro_movimiento = c.nro_movimiento
                                LEFT JOIN TIPOS_INGRESO_PAGO t ON t.id_tipo_ingreso_pago=e.id_tipo_ingreso_pago
                                WHERE d.nro_cedulon=@nro_cedulon";
                StringBuilder strRetorno = new StringBuilder();
                List<Tipo_pago> lst = new List<Tipo_pago>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nro_cedulon", nro_cedulon);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Tipo_pago? obj;
                    obj = new();
                    if (dr.HasRows)
                    {
                        int tipo_pago = dr.GetOrdinal("tipo_pago");
                        int efectivo = dr.GetOrdinal("efectivo");
                        int debito = dr.GetOrdinal("debito");
                        int credito = dr.GetOrdinal("credito");
                        int cheque = dr.GetOrdinal("cheque");
                        int documentos = dr.GetOrdinal("documentos");
                        int canje = dr.GetOrdinal("canje");
                        int bonos = dr.GetOrdinal("bonos");
                        int bancos = dr.GetOrdinal("bancos");
                        while (dr.Read())
                        {
                            //obj = new();
                            if (!dr.IsDBNull(tipo_pago)) { obj.tipo_pago = dr.GetString(tipo_pago); }
                            if (!dr.IsDBNull(efectivo)) { obj.efectivo = dr.GetString(efectivo); }
                            if (!dr.IsDBNull(debito)) { obj.debito = dr.GetString(debito); }
                            if (!dr.IsDBNull(credito)) { obj.credito = dr.GetString(credito); }
                            if (!dr.IsDBNull(cheque)) { obj.cheque = dr.GetString(cheque); }
                            if (!dr.IsDBNull(documentos)) { obj.documentos = dr.GetString(documentos); }
                            if (!dr.IsDBNull(canje)) { obj.canje = dr.GetString(canje); }
                            if (!dr.IsDBNull(bonos)) { obj.bonos = dr.GetString(bonos); }
                            if (!dr.IsDBNull(bancos)) { obj.bancos = dr.GetString(bancos); }
                            lst.Add(obj);
                        }
                        if (lst.Count > 0)
                            obj = lst[0];
                        strRetorno.AppendLine("TIPO PAGO: " + obj.tipo_pago);
                        strRetorno.AppendLine("FORMA PAGO: " + obj.forma_pago);
                        strRetorno.AppendLine(obj.efectivo + '-' + obj.credito + '-' + obj.debito + '-' + obj.bancos + '-' +
                            obj.cheque + '-' + obj.documentos + '-' + obj.canje + '-' + obj.bonos);
                    }
                    return strRetorno.ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Ctasctes_inmuebles> Listar_periodos_a_cancelar(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT
                          C.tipo_transaccion,
                          C.nro_transaccion,
                          C.circunscripcion,
                          C.seccion,
                          C.manzana,
                          C.parcela,
                          C.p_h,
                          C.periodo, 
                          C.monto_original,
                          C.debe,
                          C.vencimiento,
                          C.categoria_deuda,
                          C.pagado,
                          C.pago_parcial,
                          deuda=C.debe -
                            (SELECT SUM(C2.haber)
                             FROM CTASCTES_INMUEBLES C2
                             WHERE C2.nro_transaccion=C.nro_transaccion) 
                        FROM CTASCTES_INMUEBLES C 
                        WHERE
                          C.circunscripcion=@cir AND
                          C.seccion=@sec AND
                          C.manzana=@man AND
                          C.parcela=@par AND
                          C.p_h=@p_h AND
                          pagado=0 AND
                          tipo_transaccion=1 AND
                          nro_plan IS NULL AND
                          nro_procuracion IS NULL
                        ORDER BY periodo";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_inmuebles> lst = new();
                Ctasctes_inmuebles? obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int categoria_deuda = dr.GetOrdinal("categoria_deuda");
                        int pagado = dr.GetOrdinal("pagado");
                        int pago_parcial = dr.GetOrdinal("pago_parcial");
                        int deuda = dr.GetOrdinal("deuda");
                        while (dr.Read())
                        {
                            obj = new();
                            obj.circunscripcion = cir;
                            obj.seccion = sec;
                            obj.manzana = man;
                            obj.parcela = par;
                            obj.p_h = p_h;
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina); }
                            if (!dr.IsDBNull(categoria_deuda)) { obj.categoria_deuda = dr.GetInt32(categoria_deuda); }
                            if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                            if (!dr.IsDBNull(pago_parcial)) { obj.pago_parcial = dr.GetBoolean(pago_parcial); }
                            if (!dr.IsDBNull(deuda)) { obj.deuda = dr.GetDecimal(deuda); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void InsertCancelacioMasiva(int tipo_transaccion, int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Ctasctes_inmuebles(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", fecha_transaccion");
                sql.AppendLine(", periodo");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", categoria_deuda");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", deuda_activa");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @fecha_transaccion");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @categoria_deuda");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @deuda_activa");
                sql.AppendLine(")");
                // using (SqlConnection con = GetConnectionSIIMVA())
                // {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                cmd.Parameters.AddWithValue("@nro_pago_parcial", 0);
                cmd.Parameters.AddWithValue("@circunscripcion", 0);
                cmd.Parameters.AddWithValue("@seccion", 0);
                cmd.Parameters.AddWithValue("@manzana", 0);
                cmd.Parameters.AddWithValue("@parcela", 0);
                cmd.Parameters.AddWithValue("@p_h", 0);
                cmd.Parameters.AddWithValue("@fecha_transaccion", DateTime.Now);
                cmd.Parameters.AddWithValue("@periodo", string.Empty);
                cmd.Parameters.AddWithValue("@monto_original", 0);
                cmd.Parameters.AddWithValue("@pagado", 1);
                cmd.Parameters.AddWithValue("@debe", 0);
                cmd.Parameters.AddWithValue("@haber", 0);
                cmd.Parameters.AddWithValue("@pago_parcial", 0);
                cmd.Parameters.AddWithValue("@vencimiento", string.Empty);
                cmd.Parameters.AddWithValue("@categoria_deuda", 0);
                cmd.Parameters.AddWithValue("@monto_pagado", 0);
                cmd.Parameters.AddWithValue("@deuda_activa", 1);
                foreach (var item in lst)
                {
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.Parameters["@tipo_transaccion"].Value = tipo_transaccion;
                    cmd.Parameters["@nro_pago_parcial"].Value = item.nro_pago_parcial;
                    cmd.Parameters["@circunscripcion"].Value = cir;
                    cmd.Parameters["@seccion"].Value = sec;
                    cmd.Parameters["@manzana"].Value = man;
                    cmd.Parameters["@parcela"].Value = par;
                    cmd.Parameters["@p_h"].Value = p_h;
                    cmd.Parameters["@fecha_transaccion"].Value = DateTime.Now;
                    cmd.Parameters["@periodo"].Value = item.periodo;
                    cmd.Parameters["@haber"].Value = item.debe;
                    cmd.Parameters["@pago_parcial"].Value = item.pago_parcial;
                    cmd.Parameters["@vencimiento"].Value = item.vencimiento ?? (object)DBNull.Value;
                    cmd.Parameters["@categoria_deuda"].Value = item.categoria_deuda;
                    cmd.Parameters["@deuda_activa"].Value = item.deuda_activa;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar la Cancelacion en la CtaCte del Inmueble ", ex);
            }
        }
        public static void MarcopagadalaCtacte(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Ctasctes_inmuebles");
                sql.AppendLine("set pagado=1");
                sql.AppendLine("WHERE circunscripcion=@circunscripcion AND ");
                sql.AppendLine("      seccion=@seccion AND ");
                sql.AppendLine("      manzana=@manzana AND ");
                sql.AppendLine("      parcela=@parcela AND ");
                sql.AppendLine("      p_h=@p_h AND ");
                sql.AppendLine("      tipo_transaccion=1 AND ");
                sql.AppendLine("      nro_transaccion=@nro_transaccion");
                // using (SqlConnection con = GetConnectionSIIMVA())
                // {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@circunscripcion", 0);
                cmd.Parameters.AddWithValue("@seccion", 0);
                cmd.Parameters.AddWithValue("@manzana", 0);
                cmd.Parameters.AddWithValue("@parcela", 0);
                cmd.Parameters.AddWithValue("@p_h", 0);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    cmd.Parameters["@circunscripcion"].Value = cir;
                    cmd.Parameters["@seccion"].Value = sec;
                    cmd.Parameters["@manzana"].Value = man;
                    cmd.Parameters["@parcela"].Value = par;
                    cmd.Parameters["@p_h"].Value = p_h;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
                // }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en la marca de la CtaCte del Inmueble", ex);
            }
        }
        public static void MarconopagadalaCtacte(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Ctasctes_inmuebles");
                sql.AppendLine("set pagado=0");
                sql.AppendLine("WHERE circunscripcion=@circunscripcion AND ");
                sql.AppendLine("      seccion=@seccion AND ");
                sql.AppendLine("      manzana=@manzana AND ");
                sql.AppendLine("      parcela=@parcela AND ");
                sql.AppendLine("      p_h=@p_h AND ");
                sql.AppendLine("      tipo_transaccion=1 AND ");
                sql.AppendLine("      nro_transaccion=@nro_transaccion");
                // using (SqlConnection con = GetConnectionSIIMVA())
                // {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@circunscripcion", 0);
                cmd.Parameters.AddWithValue("@seccion", 0);
                cmd.Parameters.AddWithValue("@manzana", 0);
                cmd.Parameters.AddWithValue("@parcela", 0);
                cmd.Parameters.AddWithValue("@p_h", 0);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                //cmd.Connection.Open();
                foreach (var item in lst)
                {
                    cmd.Parameters["@circunscripcion"].Value = cir;
                    cmd.Parameters["@seccion"].Value = sec;
                    cmd.Parameters["@manzana"].Value = man;
                    cmd.Parameters["@parcela"].Value = par;
                    cmd.Parameters["@p_h"].Value = p_h;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
                //}
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en la marca de la CtaCte del Inmueble...", ex);
            }
        }
        public static List<Ctasctes_inmuebles> Listar_Periodos_cancelados(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT tipo_transaccion, periodo, debe ,nro_transaccion 
                        FROM CTASCTES_INMUEBLES (NOLOCK)
                        WHERE
                          circunscripcion=@cir AND
                          seccion=@sec AND
                          manzana=@man AND
                          parcela=@par AND
                          p_h=@p_h AND
                          (tipo_transaccion=7 or tipo_transaccion=8)
                        ORDER BY periodo";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_inmuebles> lst = new();
                Ctasctes_inmuebles? obj;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int debe = dr.GetOrdinal("debe");
                        while (dr.Read())
                        {
                            obj = new();
                            obj.circunscripcion = cir;
                            obj.seccion = sec;
                            obj.manzana = man;
                            obj.parcela = par;
                            obj.p_h = p_h;
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Confirma_elimina_cancelacion(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"DELETE CTASCTES_INMUEBLES
                                  WHERE
                                      (tipo_transaccion=7 or tipo_transaccion=8) AND
                                      nro_transaccion=@nro_transaccion AND
                                      circunscripcion=@cir AND
                                      seccion=@sec AND
                                      manzana=@man AND
                                      parcela=@par AND
                                      p_h=@p_h";
                // using (SqlConnection con = GetConnectionSIIMVA())
                // {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                // cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@cir", cir);
                cmd.Parameters.AddWithValue("@sec", sec);
                cmd.Parameters.AddWithValue("@man", man);
                cmd.Parameters.AddWithValue("@par", par);
                cmd.Parameters.AddWithValue("@p_h", p_h);
                cmd.Parameters.AddWithValue("@nro_transaccion", 0);
                foreach (var item in lst)
                {
                    cmd.Parameters["@cir"].Value = cir;
                    cmd.Parameters["@sec"].Value = sec;
                    cmd.Parameters["@man"].Value = man;
                    cmd.Parameters["@par"].Value = par;
                    cmd.Parameters["@p_h"].Value = p_h;
                    cmd.Parameters["@nro_transaccion"].Value = item.nro_transaccion;
                    cmd.ExecuteNonQuery();
                }
                //  }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Deuda Anual
        private static void sqlUpdateCedulones2(int cir, int sec, int man, int par, int p_h,
            decimal monto_original, decimal debe, int nro_transaccion, string periodo)
        {
            try
            {
                string strSQL = @"UPDATE CEDULONES2
                                    set monto_1=@monto_1, monto_2=@monto_2
                                    FROM DEUDAS_x_CEDULON3 a
                                    WHERE a.nro_transaccion=@nro_transaccion
                                    AND CEDULONES2.nro_cedulon=a.nro_cedulon
                                    AND CEDULONES2.subsistema=1
                                    AND CEDULONES2.circunscripcion=@cir
                                    AND CEDULONES2.seccion=@sec
                                    AND CEDULONES2.manzana=@man
                                    AND CEDULONES2.parcela=@par
                                    AND CEDULONES2.p_h=@p_h
                                    AND CEDULONES2.periodo=@periodo";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@monto_1", monto_original);
                    cmd.Parameters.AddWithValue("@monto_2", debe);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void sqlUpdateDeudas_x_ced3(int cir, int sec, int man, int par, int p_h,
            decimal monto_original, int nro_transaccion, string periodo)
        {
            try
            {
                string strSQL = @"UPDATE DEUDAS_x_CEDULON3 
                                    set monto_pagado=@monto_1
                                    FROM CEDULONES2 
                                    WHERE nro_transaccion=@nro_transaccion
                                    AND CEDULONES2.nro_cedulon= DEUDAS_x_CEDULON3.nro_cedulon
                                    AND CEDULONES2.subsistema=1
                                    AND CEDULONES2.circunscripcion=@cir
                                    AND CEDULONES2.seccion=@sec
                                    AND CEDULONES2.manzana=@man
                                    AND CEDULONES2.parcela=@par
                                    AND CEDULONES2.p_h=@p_h
                                    AND CEDULONES2.periodo=@periodo";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@monto_1", monto_original);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void sqlDelete_Detalle_Anual(int nro_transaccion)
        {
            try
            {
                string strSQL = @"DELETE
                                  FROM DETALLE_DEUDA_IMN_ANUAL
                                  WHERE nro_transaccion =@nro_transaccion";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void sqlInsert_Detalle_Anual(int nro_transaccion)
        {
            try
            {
                string strSQL = @"INSERT into DETALLE_DEUDA_INM_ANUAL
                                  SELECT *
                                  FROM AUX_DETALLE_DEUDA_AUTO_RECALCULO_ANUAL
                                  WHERE nro_transaccion=@nro_transaccion";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Deuda Mensual
        private static void sqlUpdate_Ctasctes(int cir, int sec, int man, int par, int p_h,
            decimal monto_original, decimal debe, int nro_transaccion, string periodo)
        {
            try
            {
                string strSQL = @"UPDATE CTASCTES_INMUEBLES
                                    SET monto_original=@monto_1, debe=@monto_2
                                    WHERE nro_transaccion=@nro_transaccion
                                    AND tipo_transaccion=1
                                    AND circunscripcion=@cir
                                    AND seccion=@sec
                                    AND manzana=@man
                                    AND parcela=@par
                                    AND p_h=@p_h
                                    AND periodo=@periodo";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@monto_1", monto_original);
                    cmd.Parameters.AddWithValue("@monto_2", debe);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void sqlDelete_Detalle_Mensual(int nro_transaccion)
        {
            try
            {
                string strSQL = @"DELETE
                                  FROM DETALLE_DEUDA_INM
                                  WHERE nro_transaccion =@nro_transaccion";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void sqlInsert_Detalle_Mensual(int nro_transaccion)
        {
            try
            {
                string strSQL = @"INSERT into DETALLE_DEUDA_INM
                                  SELECT *
                                  FROM AUX_DETALLE_DEUDA_INM_RECALCULO
                                  WHERE nro_transaccion=@nro_transaccion";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Reliquida
        public static List<Ctasctes_inmuebles> Listar_periodos_a_reliquidar(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"SELECT a.tipo_transaccion, a.nro_transaccion, a.periodo, a.monto_original,
                              a.debe, a.vencimiento, v.cod_tipo_per
                            FROM CTASCTES_INMUEBLES a WITH (NOLOCK)
                            join VENCIMIENTOS_PERIODOS2 v on
                            v.subsistema=4 and
                            v.periodo=a.periodo
                            WHERE
                              a.circunscripcion=@cir AND
                              a.seccion=@sec AND
                              a.manzana=@man AND
                              a.parcela=@par AND
                              a.p_h=@p_h AND
                              a.tipo_transaccion=1 AND pagado=0 AND
                              a.pago_parcial=0 AND nro_plan IS null AND
                              a.nro_procuracion IS NULL AND
                              a.categoria_deuda = 1

                            UNION ALL

                            SELECT 1 as tipo_transaccion, b.nro_transaccion, a.periodo, a.monto_1 as monto_original,
                             a.monto_2 as debe, a.vencimiento_1 as vencimiento,
                             4 as cod_tipo_per
                            FROM Cedulones2 A  WITH (NOLOCK)
                            JOIN Deudas_x_cedulon3 b on
                              a.nro_cedulon=b.nro_cedulon
                            WHERE
                              a.circunscripcion=@cir AND
                              a.seccion=@sec AND
                              a.manzana=@man AND
                              a.parcela=@par AND
                              a.p_h=@p_h AND
                              A.no_pagado=1 AND
                              A.subsistema=1and
                              A.tipo_cedulon=1 and 
                              A.activo=1
                            order by A.periodo";
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                List<Ctasctes_inmuebles> lst = new();
                Ctasctes_inmuebles? obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                        int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                        int periodo = dr.GetOrdinal("periodo");
                        int monto_original = dr.GetOrdinal("monto_original");
                        int debe = dr.GetOrdinal("debe");
                        int vencimiento = dr.GetOrdinal("vencimiento");
                        int cod_tipo_per = dr.GetOrdinal("cod_tipo_per");

                        while (dr.Read())
                        {
                            obj = new();
                            obj.circunscripcion = cir;
                            obj.seccion = sec;
                            obj.manzana = man;
                            obj.parcela = par;
                            obj.p_h = p_h;
                            if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                            if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                            if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                            if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                            if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                            if (!dr.IsDBNull(vencimiento))
                            {
                                obj.vencimiento = Convert.ToDateTime(dr.GetDateTime(vencimiento), culturaFecArgentina);
                            }
                            if (!dr.IsDBNull(cod_tipo_per)) { obj.cod_tipo_per = dr.GetInt32(cod_tipo_per); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Ctasctes_inmuebles> Reliquidar_periodos(int cir, int sec, int man, int par, int p_h,
      List<Ctasctes_inmuebles> lst)
        {
            //Parametros que vienen como item en la la lst
            //string periodo, int nro_transaccion, int tipo_per
            try
            {
                int anio = 0;
                double auxmonto_original = 0;
                double auxdebe = 0;
                double valor = 1.125;
                foreach (var item in lst)
                {
                    anio = Convert.ToInt32(item.periodo.Substring(0, 4));
                    if (anio >= 2020)
                    {
                        if (item.cod_tipo_per == 1) //Periodo Mensual
                        {
                            //sp_LIQUIDA_TASA_PROP_MENSUAL_SUP_RECALCULO_2023
                            auxmonto_original = sp_RECALCULO_INMUEBLES_2023(item.circunscripcion, item.seccion, item.manzana,
                                item.parcela, item.p_h, item.periodo, item.cod_tipo_per);
                            auxdebe = auxmonto_original + Calcula_Interes(auxmonto_original, item.vencimiento);
                            item.monto_original = Convert.ToDecimal(auxmonto_original);
                            item.debe = Convert.ToDecimal(auxdebe);
                        }
                        else
                        {
                            auxmonto_original = sp_RECALCULO_INMUEBLES_ANUAL_2023(item.circunscripcion, item.seccion, item.manzana,
                                item.parcela, item.p_h, item.periodo, item.cod_tipo_per);
                            if (item.vencimiento > DateTime.Now)
                                auxdebe = auxmonto_original * valor;
                            else
                                auxdebe = auxmonto_original;
                            //auxdebe = auxmonto_original + Calcula_Interes(cn, auxmonto_original, item.vencimiento);
                            item.monto_original = Convert.ToDecimal(auxmonto_original);
                            item.debe = Convert.ToDecimal(auxdebe);
                        }
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Confirma_reliquidacion(int cir, int sec, int man, int par, int p_h, List<Ctasctes_inmuebles> lst)
        {
            try
            {
                int anio = 0;
                foreach (var item in lst)
                {
                    anio = Convert.ToInt32(item.periodo.Substring(0, 4));
                    if (anio >= 2020)
                    {
                        if (item.cod_tipo_per == 4) //Periodo Anual
                        {
                            sqlUpdateCedulones2(item.circunscripcion, item.seccion, item.manzana, item.parcela,
                                item.p_h, item.monto_original, item.debe, item.nro_transaccion, item.periodo);
                            sqlUpdateDeudas_x_ced3(item.circunscripcion, item.seccion, item.manzana, item.parcela,
                                item.p_h, item.monto_original, item.nro_transaccion, item.periodo);
                            sqlDelete_Detalle_Anual(item.nro_transaccion);
                            sqlInsert_Detalle_Anual(item.nro_transaccion);
                        }
                        else
                        {
                            sqlUpdate_Ctasctes(item.circunscripcion, item.seccion, item.manzana, item.parcela,
                                item.p_h, item.monto_original, item.debe, item.nro_transaccion, item.periodo);
                            sqlDelete_Detalle_Mensual(item.nro_transaccion);
                            sqlInsert_Detalle_Mensual(item.nro_transaccion);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static double Calcula_Interes(double auxmonto_original, DateTime? vencimiento)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                double interes = 0;
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.Calculo_Interes_4";
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@monto_original", auxmonto_original);
                    cmd.Parameters.AddWithValue("@vencimiento", Convert.ToDateTime(vencimiento, culturaFecArgentina));
                    interes = Convert.ToDouble(cmd.ExecuteScalar());
                }
                return interes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static double sp_RECALCULO_INMUEBLES_2023(int cir, int sec, int man, int par, int p_h,
            string periodo, int tipo_per)
        {
            try
            {
                double total = 0;
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_LIQUIDA_TASA_PROP_MENSUAL_SUP_RECALCULO_2023";
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", tipo_per);
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@al1ervencimiento", 0);
                    //cmd.ExecuteNonQueryAsync();
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static double sp_RECALCULO_INMUEBLES_ANUAL_2023(int cir, int sec, int man, int par, int p_h, string periodo, int tipo_per)
        {
            try
            {
                double total = 0;
                using (SqlConnection cn = GetConnectionSIIMVA())
                {


                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_LIQUIDA_TASA_PROP_ANUAL_SUP_RECALCULO_2023";
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", tipo_per);
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    //cmd.ExecuteNonQueryAsync();
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}

