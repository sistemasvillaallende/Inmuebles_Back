using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Entities
{
    public class Inmuebles : DALBase
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public int cod_barrio { get; set; }
        public int nro_bad { get; set; }
        public string Nombre { get; set; }
        public bool exhimido { get; set; }
        public bool jubilado { get; set; }
        public int cod_barrio_dom_esp { get; set; }
        public string nom_barrio_dom_esp { get; set; }
        public int cod_calle_dom_esp { get; set; }
        public string nom_calle_dom_esp { get; set; }
        public int nro_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public string ciudad_dom_esp { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }
        public bool union_tributaria { get; set; }
        public bool edificado { get; set; }
        public bool parquizado { get; set; }
        public bool baldio_sucio { get; set; }
        public bool construccion { get; set; }
        public int cod_uso { get; set; }
        public Single superficie { get; set; }
        public string piso_dpto { get; set; }
        public int cod_calle_pf { get; set; }
        public int nro_dom_pf { get; set; }
        public string cod_postal { get; set; }
        public string ultimo_periodo { get; set; }
        public DateTime? fecha_cambio_domicilio { get; set; }
        public string ocupante { get; set; }
        public bool emite_cedulon { get; set; }
        public bool baldio_country { get; set; }
        public bool debito_automatico { get; set; }
        public int nro_secuencia { get; set; }
        public int cod_situacion_judicial { get; set; }
        public DateTime? fecha_alta { get; set; }
        public string clave_pago { get; set; }
        public bool municipal { get; set; }
        public string email_envio_cedulon { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public Int16 cod_tipo_per_elegido { get; set; }
        public Int16 con_deuda { get; set; }
        public decimal saldo_adeudado { get; set; }
        public Single superficie_edificada { get; set; }
        public Int16 cod_estado { get; set; }
        public Int16 cedulon_digital { get; set; }
        public Int16 oculto { get; set; }
        public string nro_doc_ocupante { get; set; }
        public string cuit_ocupante { get; set; }
        public int nro_bad_ocupante { get; set; }
        public string cod_categoria_zona_liq { get; set; }
        public int tipo_ph { get; set; }
        public DateTime? fecha_tipo_ph { get; set; }
        public string cuil { get; set; }
        public DateTime? fecha_vecino_digital { get; set; }
        public string cuit_vecino_digital { get; set; }
        public string LAT { get; set; }
        public string LONG { get; set; }
        public string DIR_GOOGLE { get; set; }
        public int total_row { get; set; }
        public AUDITORIA.Auditoria objAuditoria { get; set; }
        public Inmuebles()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            cod_barrio = 0;
            nro_bad = 0;
            Nombre = string.Empty;
            exhimido = false;
            jubilado = false;
            cod_barrio_dom_esp = 0;
            nom_barrio_dom_esp = string.Empty;
            cod_calle_dom_esp = 0;
            nom_calle_dom_esp = string.Empty;
            nro_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            ciudad_dom_esp = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
            union_tributaria = false;
            edificado = false;
            parquizado = false;
            baldio_sucio = false;
            construccion = false;
            cod_uso = 0;
            superficie = 0;
            piso_dpto = string.Empty;
            cod_calle_pf = 0;
            nro_dom_pf = 0;
            cod_postal = string.Empty;
            ultimo_periodo = string.Empty;
            fecha_cambio_domicilio = null;// DateTime.Now;
            ocupante = string.Empty;
            emite_cedulon = false;
            baldio_country = false;
            debito_automatico = false;
            nro_secuencia = 0;
            cod_situacion_judicial = 0;
            fecha_alta = null; // DateTime.Now;
            clave_pago = string.Empty;
            municipal = false;
            email_envio_cedulon = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            cod_tipo_per_elegido = 0;
            con_deuda = 0;
            saldo_adeudado = 0;
            superficie_edificada = 0;
            cod_estado = 0;
            cedulon_digital = 0;
            oculto = 0;
            nro_doc_ocupante = string.Empty;
            cuit_ocupante = string.Empty;
            nro_bad_ocupante = 0;
            cod_categoria_zona_liq = string.Empty;
            tipo_ph = 0;
            fecha_tipo_ph = null;// DateTime.Now;
            cuil = string.Empty;
            fecha_vecino_digital = null;// DateTime.Now;
            cuit_vecino_digital = string.Empty;
            LAT = string.Empty;
            LONG = string.Empty;
            DIR_GOOGLE = string.Empty;
            objAuditoria = new AUDITORIA.Auditoria();
            total_row = 0;


        }

        private static List<Inmuebles> mapeo(SqlDataReader dr)
        {
            List<Inmuebles> lst = new List<Inmuebles>();
            Inmuebles obj;
            if (dr.HasRows)
            {
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int nro_bad = dr.GetOrdinal("nro_bad");
                int Nombre = dr.GetOrdinal("Nombre");
                int exhimido = dr.GetOrdinal("exhimido");
                int jubilado = dr.GetOrdinal("jubilado");
                int cod_barrio_dom_esp = dr.GetOrdinal("cod_barrio_dom_esp");
                int nom_barrio_dom_esp = dr.GetOrdinal("nom_barrio_dom_esp");
                int cod_calle_dom_esp = dr.GetOrdinal("cod_calle_dom_esp");
                int nom_calle_dom_esp = dr.GetOrdinal("nom_calle_dom_esp");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int piso_dpto_esp = dr.GetOrdinal("piso_dpto_esp");
                int ciudad_dom_esp = dr.GetOrdinal("ciudad_dom_esp");
                int provincia_dom_esp = dr.GetOrdinal("provincia_dom_esp");
                int pais_dom_esp = dr.GetOrdinal("pais_dom_esp");
                int union_tributaria = dr.GetOrdinal("union_tributaria");
                int edificado = dr.GetOrdinal("edificado");
                int parquizado = dr.GetOrdinal("parquizado");
                int baldio_sucio = dr.GetOrdinal("baldio_sucio");
                int construccion = dr.GetOrdinal("construccion");
                int cod_uso = dr.GetOrdinal("cod_uso");
                int superficie = dr.GetOrdinal("superficie");
                int piso_dpto = dr.GetOrdinal("piso_dpto");
                int cod_calle_pf = dr.GetOrdinal("cod_calle_pf");
                int nro_dom_pf = dr.GetOrdinal("nro_dom_pf");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int ultimo_periodo = dr.GetOrdinal("ultimo_periodo");
                int fecha_cambio_domicilio = dr.GetOrdinal("fecha_cambio_domicilio");
                int ocupante = dr.GetOrdinal("ocupante");
                int emite_cedulon = dr.GetOrdinal("emite_cedulon");
                int baldio_country = dr.GetOrdinal("baldio_country");
                int debito_automatico = dr.GetOrdinal("debito_automatico");
                int nro_secuencia = dr.GetOrdinal("nro_secuencia");
                int cod_situacion_judicial = dr.GetOrdinal("cod_situacion_judicial");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int clave_pago = dr.GetOrdinal("clave_pago");
                int municipal = dr.GetOrdinal("municipal");
                int email_envio_cedulon = dr.GetOrdinal("email_envio_cedulon");
                int telefono = dr.GetOrdinal("telefono");
                int celular = dr.GetOrdinal("celular");
                int cod_tipo_per_elegido = dr.GetOrdinal("cod_tipo_per_elegido");
                int con_deuda = dr.GetOrdinal("con_deuda");
                int saldo_adeudado = dr.GetOrdinal("saldo_adeudado");
                int superficie_edificada = dr.GetOrdinal("superficie_edificada");
                int cod_estado = dr.GetOrdinal("cod_estado");
                int cedulon_digital = dr.GetOrdinal("cedulon_digital");
                int oculto = dr.GetOrdinal("oculto");
                int nro_doc_ocupante = dr.GetOrdinal("nro_doc_ocupante");
                int cuit_ocupante = dr.GetOrdinal("cuit_ocupante");
                int nro_bad_ocupante = dr.GetOrdinal("nro_bad_ocupante");
                int cod_categoria_zona_liq = dr.GetOrdinal("cod_categoria_zona_liq");
                int tipo_ph = dr.GetOrdinal("tipo_ph");
                int fecha_tipo_ph = dr.GetOrdinal("fecha_tipo_ph");
                int cuil = dr.GetOrdinal("cuil");
                int fecha_vecino_digital = dr.GetOrdinal("fecha_vecino_digital");
                int cuit_vecino_digital = dr.GetOrdinal("cuit_vecino_digital");
                int LAT = dr.GetOrdinal("LAT");
                int LONG = dr.GetOrdinal("LONG");
                int DIR_GOOGLE = dr.GetOrdinal("DIR_GOOGLE");
                int TOTAL = dr.GetOrdinal("TOTAL");
                while (dr.Read())
                {
                    obj = new Inmuebles();
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(cod_barrio)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(exhimido)) { obj.exhimido = dr.GetBoolean(exhimido); }
                    if (!dr.IsDBNull(jubilado)) { obj.jubilado = dr.GetBoolean(jubilado); }
                    if (!dr.IsDBNull(cod_barrio_dom_esp)) { obj.cod_barrio_dom_esp = dr.GetInt32(cod_barrio_dom_esp); }
                    if (!dr.IsDBNull(nom_barrio_dom_esp)) { obj.nom_barrio_dom_esp = dr.GetString(nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(cod_calle_dom_esp)) { obj.cod_calle_dom_esp = dr.GetInt32(cod_calle_dom_esp); }
                    if (!dr.IsDBNull(nom_calle_dom_esp)) { obj.nom_calle_dom_esp = dr.GetString(nom_calle_dom_esp); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(piso_dpto_esp)) { obj.piso_dpto_esp = dr.GetString(piso_dpto_esp); }
                    if (!dr.IsDBNull(ciudad_dom_esp)) { obj.ciudad_dom_esp = dr.GetString(ciudad_dom_esp); }
                    if (!dr.IsDBNull(provincia_dom_esp)) { obj.provincia_dom_esp = dr.GetString(provincia_dom_esp); }
                    if (!dr.IsDBNull(pais_dom_esp)) { obj.pais_dom_esp = dr.GetString(pais_dom_esp); }
                    if (!dr.IsDBNull(union_tributaria)) { obj.union_tributaria = dr.GetBoolean(union_tributaria); }
                    if (!dr.IsDBNull(edificado)) { obj.edificado = dr.GetBoolean(edificado); }
                    if (!dr.IsDBNull(parquizado)) { obj.parquizado = dr.GetBoolean(parquizado); }
                    if (!dr.IsDBNull(baldio_sucio)) { obj.baldio_sucio = dr.GetBoolean(baldio_sucio); }
                    if (!dr.IsDBNull(construccion)) { obj.construccion = dr.GetBoolean(construccion); }
                    if (!dr.IsDBNull(cod_uso)) { obj.cod_uso = dr.GetInt32(cod_uso); }
                    if (!dr.IsDBNull(superficie)) { obj.superficie = dr.GetFloat(superficie); }
                    if (!dr.IsDBNull(piso_dpto)) { obj.piso_dpto = dr.GetString(piso_dpto); }
                    if (!dr.IsDBNull(cod_calle_pf)) { obj.cod_calle_pf = dr.GetInt32(cod_calle_pf); }
                    if (!dr.IsDBNull(nro_dom_pf)) { obj.nro_dom_pf = dr.GetInt32(nro_dom_pf); }
                    if (!dr.IsDBNull(cod_postal)) { obj.cod_postal = dr.GetString(cod_postal); }
                    if (!dr.IsDBNull(ultimo_periodo)) { obj.ultimo_periodo = dr.GetString(ultimo_periodo); }
                    if (!dr.IsDBNull(fecha_cambio_domicilio)) { obj.fecha_cambio_domicilio = dr.GetDateTime(fecha_cambio_domicilio); }
                    if (!dr.IsDBNull(ocupante)) { obj.ocupante = dr.GetString(ocupante); }
                    if (!dr.IsDBNull(emite_cedulon)) { obj.emite_cedulon = dr.GetBoolean(emite_cedulon); }
                    if (!dr.IsDBNull(baldio_country)) { obj.baldio_country = dr.GetBoolean(baldio_country); }
                    if (!dr.IsDBNull(debito_automatico)) { obj.debito_automatico = dr.GetBoolean(debito_automatico); }
                    if (!dr.IsDBNull(nro_secuencia)) { obj.nro_secuencia = dr.GetInt32(nro_secuencia); }
                    if (!dr.IsDBNull(cod_situacion_judicial)) { obj.cod_situacion_judicial = dr.GetInt32(cod_situacion_judicial); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(clave_pago)) { obj.clave_pago = dr.GetString(clave_pago); }
                    if (!dr.IsDBNull(municipal)) { obj.municipal = dr.GetBoolean(municipal); }
                    if (!dr.IsDBNull(email_envio_cedulon)) { obj.email_envio_cedulon = dr.GetString(email_envio_cedulon); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(cod_tipo_per_elegido)) { obj.cod_tipo_per_elegido = dr.GetInt16(cod_tipo_per_elegido); }
                    if (!dr.IsDBNull(con_deuda)) { obj.con_deuda = dr.GetInt16(con_deuda); }
                    if (!dr.IsDBNull(saldo_adeudado)) { obj.saldo_adeudado = dr.GetDecimal(saldo_adeudado); }
                    if (!dr.IsDBNull(superficie_edificada)) { obj.superficie_edificada = dr.GetFloat(superficie_edificada); }
                    if (!dr.IsDBNull(cod_estado)) { obj.cod_estado = dr.GetInt16(cod_estado); }
                    if (!dr.IsDBNull(cedulon_digital)) { obj.cedulon_digital = dr.GetInt16(cedulon_digital); }
                    if (!dr.IsDBNull(oculto)) { obj.oculto = dr.GetInt16(oculto); }
                    if (!dr.IsDBNull(nro_doc_ocupante)) { obj.nro_doc_ocupante = dr.GetString(nro_doc_ocupante); }
                    if (!dr.IsDBNull(cuit_ocupante)) { obj.cuit_ocupante = dr.GetString(cuit_ocupante); }
                    if (!dr.IsDBNull(nro_bad_ocupante)) { obj.nro_bad_ocupante = dr.GetInt32(nro_bad_ocupante); }
                    if (!dr.IsDBNull(cod_categoria_zona_liq)) { obj.cod_categoria_zona_liq = dr.GetString(cod_categoria_zona_liq); }
                    if (!dr.IsDBNull(tipo_ph)) { obj.tipo_ph = dr.GetInt32(tipo_ph); }
                    if (!dr.IsDBNull(fecha_tipo_ph)) { obj.fecha_tipo_ph = dr.GetDateTime(fecha_tipo_ph); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(fecha_vecino_digital)) { obj.fecha_vecino_digital = dr.GetDateTime(fecha_vecino_digital); }
                    if (!dr.IsDBNull(cuit_vecino_digital)) { obj.cuit_vecino_digital = dr.GetString(cuit_vecino_digital); }
                    if (!dr.IsDBNull(LAT)) { obj.LAT = dr.GetString(LAT); }
                    if (!dr.IsDBNull(LONG)) { obj.LONG = dr.GetString(LONG); }
                    if (!dr.IsDBNull(DIR_GOOGLE)) { obj.DIR_GOOGLE = dr.GetString(DIR_GOOGLE); }
                    if (!dr.IsDBNull(TOTAL)) { obj.total_row = dr.GetInt32(TOTAL); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        private static List<Inmuebles> mapeo2(SqlDataReader dr)
        {
            List<Inmuebles> lst = new List<Inmuebles>();
            Inmuebles obj;
            if (dr.HasRows)
            {
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int nro_bad = dr.GetOrdinal("nro_bad");
                int Nombre = dr.GetOrdinal("Nombre");
                int exhimido = dr.GetOrdinal("exhimido");
                int jubilado = dr.GetOrdinal("jubilado");
                int cod_barrio_dom_esp = dr.GetOrdinal("cod_barrio_dom_esp");
                int nom_barrio_dom_esp = dr.GetOrdinal("nom_barrio_dom_esp");
                int cod_calle_dom_esp = dr.GetOrdinal("cod_calle_dom_esp");
                int nom_calle_dom_esp = dr.GetOrdinal("nom_calle_dom_esp");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int piso_dpto_esp = dr.GetOrdinal("piso_dpto_esp");
                int ciudad_dom_esp = dr.GetOrdinal("ciudad_dom_esp");
                int provincia_dom_esp = dr.GetOrdinal("provincia_dom_esp");
                int pais_dom_esp = dr.GetOrdinal("pais_dom_esp");
                int union_tributaria = dr.GetOrdinal("union_tributaria");
                int edificado = dr.GetOrdinal("edificado");
                int parquizado = dr.GetOrdinal("parquizado");
                int baldio_sucio = dr.GetOrdinal("baldio_sucio");
                int construccion = dr.GetOrdinal("construccion");
                int cod_uso = dr.GetOrdinal("cod_uso");
                int superficie = dr.GetOrdinal("superficie");
                int piso_dpto = dr.GetOrdinal("piso_dpto");
                int cod_calle_pf = dr.GetOrdinal("cod_calle_pf");
                int nro_dom_pf = dr.GetOrdinal("nro_dom_pf");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int ultimo_periodo = dr.GetOrdinal("ultimo_periodo");
                int fecha_cambio_domicilio = dr.GetOrdinal("fecha_cambio_domicilio");
                int ocupante = dr.GetOrdinal("ocupante");
                int emite_cedulon = dr.GetOrdinal("emite_cedulon");
                int baldio_country = dr.GetOrdinal("baldio_country");
                int debito_automatico = dr.GetOrdinal("debito_automatico");
                int nro_secuencia = dr.GetOrdinal("nro_secuencia");
                int cod_situacion_judicial = dr.GetOrdinal("cod_situacion_judicial");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int clave_pago = dr.GetOrdinal("clave_pago");
                int municipal = dr.GetOrdinal("municipal");
                int email_envio_cedulon = dr.GetOrdinal("email_envio_cedulon");
                int telefono = dr.GetOrdinal("telefono");
                int celular = dr.GetOrdinal("celular");
                int cod_tipo_per_elegido = dr.GetOrdinal("cod_tipo_per_elegido");
                int con_deuda = dr.GetOrdinal("con_deuda");
                int saldo_adeudado = dr.GetOrdinal("saldo_adeudado");
                int superficie_edificada = dr.GetOrdinal("superficie_edificada");
                int cod_estado = dr.GetOrdinal("cod_estado");
                int cedulon_digital = dr.GetOrdinal("cedulon_digital");
                int oculto = dr.GetOrdinal("oculto");
                int nro_doc_ocupante = dr.GetOrdinal("nro_doc_ocupante");
                int cuit_ocupante = dr.GetOrdinal("cuit_ocupante");
                int nro_bad_ocupante = dr.GetOrdinal("nro_bad_ocupante");
                int cod_categoria_zona_liq = dr.GetOrdinal("cod_categoria_zona_liq");
                int tipo_ph = dr.GetOrdinal("tipo_ph");
                int fecha_tipo_ph = dr.GetOrdinal("fecha_tipo_ph");
                int cuil = dr.GetOrdinal("cuil");
                int fecha_vecino_digital = dr.GetOrdinal("fecha_vecino_digital");
                int cuit_vecino_digital = dr.GetOrdinal("cuit_vecino_digital");
                int LAT = dr.GetOrdinal("LAT");
                int LONG = dr.GetOrdinal("LONG");
                int DIR_GOOGLE = dr.GetOrdinal("DIR_GOOGLE");

                while (dr.Read())
                {
                    obj = new Inmuebles();
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }
                    if (!dr.IsDBNull(cod_barrio)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(exhimido)) { obj.exhimido = dr.GetBoolean(exhimido); }
                    if (!dr.IsDBNull(jubilado)) { obj.jubilado = dr.GetBoolean(jubilado); }
                    if (!dr.IsDBNull(cod_barrio_dom_esp)) { obj.cod_barrio_dom_esp = dr.GetInt32(cod_barrio_dom_esp); }
                    if (!dr.IsDBNull(nom_barrio_dom_esp)) { obj.nom_barrio_dom_esp = dr.GetString(nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(cod_calle_dom_esp)) { obj.cod_calle_dom_esp = dr.GetInt32(cod_calle_dom_esp); }
                    if (!dr.IsDBNull(nom_calle_dom_esp)) { obj.nom_calle_dom_esp = dr.GetString(nom_calle_dom_esp); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(piso_dpto_esp)) { obj.piso_dpto_esp = dr.GetString(piso_dpto_esp); }
                    if (!dr.IsDBNull(ciudad_dom_esp)) { obj.ciudad_dom_esp = dr.GetString(ciudad_dom_esp); }
                    if (!dr.IsDBNull(provincia_dom_esp)) { obj.provincia_dom_esp = dr.GetString(provincia_dom_esp); }
                    if (!dr.IsDBNull(pais_dom_esp)) { obj.pais_dom_esp = dr.GetString(pais_dom_esp); }
                    if (!dr.IsDBNull(union_tributaria)) { obj.union_tributaria = dr.GetBoolean(union_tributaria); }
                    if (!dr.IsDBNull(edificado)) { obj.edificado = dr.GetBoolean(edificado); }
                    if (!dr.IsDBNull(parquizado)) { obj.parquizado = dr.GetBoolean(parquizado); }
                    if (!dr.IsDBNull(baldio_sucio)) { obj.baldio_sucio = dr.GetBoolean(baldio_sucio); }
                    if (!dr.IsDBNull(construccion)) { obj.construccion = dr.GetBoolean(construccion); }
                    if (!dr.IsDBNull(cod_uso)) { obj.cod_uso = dr.GetInt32(cod_uso); }
                    if (!dr.IsDBNull(superficie)) { obj.superficie = dr.GetFloat(superficie); }
                    if (!dr.IsDBNull(piso_dpto)) { obj.piso_dpto = dr.GetString(piso_dpto); }
                    if (!dr.IsDBNull(cod_calle_pf)) { obj.cod_calle_pf = dr.GetInt32(cod_calle_pf); }
                    if (!dr.IsDBNull(nro_dom_pf)) { obj.nro_dom_pf = dr.GetInt32(nro_dom_pf); }
                    if (!dr.IsDBNull(cod_postal)) { obj.cod_postal = dr.GetString(cod_postal); }
                    if (!dr.IsDBNull(ultimo_periodo)) { obj.ultimo_periodo = dr.GetString(ultimo_periodo); }
                    if (!dr.IsDBNull(fecha_cambio_domicilio)) { obj.fecha_cambio_domicilio = dr.GetDateTime(fecha_cambio_domicilio); }
                    if (!dr.IsDBNull(ocupante)) { obj.ocupante = dr.GetString(ocupante); }
                    if (!dr.IsDBNull(emite_cedulon)) { obj.emite_cedulon = dr.GetBoolean(emite_cedulon); }
                    if (!dr.IsDBNull(baldio_country)) { obj.baldio_country = dr.GetBoolean(baldio_country); }
                    if (!dr.IsDBNull(debito_automatico)) { obj.debito_automatico = dr.GetBoolean(debito_automatico); }
                    if (!dr.IsDBNull(nro_secuencia)) { obj.nro_secuencia = dr.GetInt32(nro_secuencia); }
                    if (!dr.IsDBNull(cod_situacion_judicial)) { obj.cod_situacion_judicial = dr.GetInt32(cod_situacion_judicial); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(clave_pago)) { obj.clave_pago = dr.GetString(clave_pago); }
                    if (!dr.IsDBNull(municipal)) { obj.municipal = dr.GetBoolean(municipal); }
                    if (!dr.IsDBNull(email_envio_cedulon)) { obj.email_envio_cedulon = dr.GetString(email_envio_cedulon); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(cod_tipo_per_elegido)) { obj.cod_tipo_per_elegido = dr.GetInt16(cod_tipo_per_elegido); }
                    if (!dr.IsDBNull(con_deuda)) { obj.con_deuda = dr.GetInt16(con_deuda); }
                    if (!dr.IsDBNull(saldo_adeudado)) { obj.saldo_adeudado = dr.GetDecimal(saldo_adeudado); }
                    if (!dr.IsDBNull(superficie_edificada)) { obj.superficie_edificada = dr.GetFloat(superficie_edificada); }
                    if (!dr.IsDBNull(cod_estado)) { obj.cod_estado = dr.GetInt16(cod_estado); }
                    if (!dr.IsDBNull(cedulon_digital)) { obj.cedulon_digital = dr.GetInt16(cedulon_digital); }
                    if (!dr.IsDBNull(oculto)) { obj.oculto = dr.GetInt16(oculto); }
                    if (!dr.IsDBNull(nro_doc_ocupante)) { obj.nro_doc_ocupante = dr.GetString(nro_doc_ocupante); }
                    if (!dr.IsDBNull(cuit_ocupante)) { obj.cuit_ocupante = dr.GetString(cuit_ocupante); }
                    if (!dr.IsDBNull(nro_bad_ocupante)) { obj.nro_bad_ocupante = dr.GetInt32(nro_bad_ocupante); }
                    if (!dr.IsDBNull(cod_categoria_zona_liq)) { obj.cod_categoria_zona_liq = dr.GetString(cod_categoria_zona_liq); }
                    if (!dr.IsDBNull(tipo_ph)) { obj.tipo_ph = dr.GetInt32(tipo_ph); }
                    if (!dr.IsDBNull(fecha_tipo_ph)) { obj.fecha_tipo_ph = dr.GetDateTime(fecha_tipo_ph); }
                    if (!dr.IsDBNull(cuil)) { obj.cuil = dr.GetString(cuil); }
                    if (!dr.IsDBNull(fecha_vecino_digital)) { obj.fecha_vecino_digital = dr.GetDateTime(fecha_vecino_digital); }
                    if (!dr.IsDBNull(cuit_vecino_digital)) { obj.cuit_vecino_digital = dr.GetString(cuit_vecino_digital); }
                    if (!dr.IsDBNull(LAT)) { obj.LAT = dr.GetString(LAT); }
                    if (!dr.IsDBNull(LONG)) { obj.LONG = dr.GetString(LONG); }
                    if (!dr.IsDBNull(DIR_GOOGLE)) { obj.DIR_GOOGLE = dr.GetString(DIR_GOOGLE); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Inmuebles> read()
        {
            try
            {
                List<Inmuebles> lst = new List<Inmuebles>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Inmuebles";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Inmuebles getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Inmuebles WHERE");
                sql.AppendLine("circunscripcion = @circunscripcion");
                sql.AppendLine("AND seccion = @seccion");
                sql.AppendLine("AND manzana = @manzana");
                sql.AppendLine("AND parcela = @parcela");
                sql.AppendLine("AND p_h = @p_h");
                Inmuebles? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
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
                    List<Inmuebles> lst = mapeo2(dr);
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
        public static int insert(Inmuebles obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Inmuebles(");
                sql.AppendLine("circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(", cod_barrio");
                sql.AppendLine(", nro_bad");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", exhimido");
                sql.AppendLine(", jubilado");
                sql.AppendLine(", cod_barrio_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp");
                sql.AppendLine(", cod_calle_dom_esp");
                sql.AppendLine(", nom_calle_dom_esp");
                sql.AppendLine(", nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp");
                sql.AppendLine(", ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp");
                sql.AppendLine(", union_tributaria");
                sql.AppendLine(", edificado");
                sql.AppendLine(", parquizado");
                sql.AppendLine(", baldio_sucio");
                sql.AppendLine(", construccion");
                sql.AppendLine(", cod_uso");
                sql.AppendLine(", superficie");
                sql.AppendLine(", piso_dpto");
                sql.AppendLine(", cod_calle_pf");
                sql.AppendLine(", nro_dom_pf");
                sql.AppendLine(", cod_postal");
                sql.AppendLine(", ultimo_periodo");
                sql.AppendLine(", fecha_cambio_domicilio");
                sql.AppendLine(", ocupante");
                sql.AppendLine(", emite_cedulon");
                sql.AppendLine(", baldio_country");
                sql.AppendLine(", debito_automatico");
                sql.AppendLine(", nro_secuencia");
                sql.AppendLine(", cod_situacion_judicial");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", clave_pago");
                sql.AppendLine(", municipal");
                sql.AppendLine(", email_envio_cedulon");
                sql.AppendLine(", telefono");
                sql.AppendLine(", celular");
                sql.AppendLine(", cod_tipo_per_elegido");
                sql.AppendLine(", con_deuda");
                sql.AppendLine(", saldo_adeudado");
                sql.AppendLine(", superficie_edificada");
                sql.AppendLine(", cod_estado");
                sql.AppendLine(", cedulon_digital");
                sql.AppendLine(", oculto");
                sql.AppendLine(", nro_doc_ocupante");
                sql.AppendLine(", cuit_ocupante");
                sql.AppendLine(", nro_bad_ocupante");
                sql.AppendLine(", cod_categoria_zona_liq");
                sql.AppendLine(", tipo_ph");
                sql.AppendLine(", fecha_tipo_ph");
                sql.AppendLine(", cuil");
                sql.AppendLine(", FECHA_VECINO_DIGITAL");
                sql.AppendLine(", CUIT_VECINO_DIGITAL");
                sql.AppendLine(", LAT");
                sql.AppendLine(", LONG");
                sql.AppendLine(", DIR_GOOGLE");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(", @cod_barrio");
                sql.AppendLine(", @nro_bad");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @exhimido");
                sql.AppendLine(", @jubilado");
                sql.AppendLine(", @cod_barrio_dom_esp");
                sql.AppendLine(", @nom_barrio_dom_esp");
                sql.AppendLine(", @cod_calle_dom_esp");
                sql.AppendLine(", @nom_calle_dom_esp");
                sql.AppendLine(", @nro_dom_esp");
                sql.AppendLine(", @piso_dpto_esp");
                sql.AppendLine(", @ciudad_dom_esp");
                sql.AppendLine(", @provincia_dom_esp");
                sql.AppendLine(", @pais_dom_esp");
                sql.AppendLine(", @union_tributaria");
                sql.AppendLine(", @edificado");
                sql.AppendLine(", @parquizado");
                sql.AppendLine(", @baldio_sucio");
                sql.AppendLine(", @construccion");
                sql.AppendLine(", @cod_uso");
                sql.AppendLine(", @superficie");
                sql.AppendLine(", @piso_dpto");
                sql.AppendLine(", @cod_calle_pf");
                sql.AppendLine(", @nro_dom_pf");
                sql.AppendLine(", @cod_postal");
                sql.AppendLine(", @ultimo_periodo");
                sql.AppendLine(", @fecha_cambio_domicilio");
                sql.AppendLine(", @ocupante");
                sql.AppendLine(", @emite_cedulon");
                sql.AppendLine(", @baldio_country");
                sql.AppendLine(", @debito_automatico");
                sql.AppendLine(", @nro_secuencia");
                sql.AppendLine(", @cod_situacion_judicial");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @clave_pago");
                sql.AppendLine(", @municipal");
                sql.AppendLine(", @email_envio_cedulon");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @celular");
                sql.AppendLine(", @cod_tipo_per_elegido");
                sql.AppendLine(", @con_deuda");
                sql.AppendLine(", @saldo_adeudado");
                sql.AppendLine(", @superficie_edificada");
                sql.AppendLine(", @cod_estado");
                sql.AppendLine(", @cedulon_digital");
                sql.AppendLine(", @oculto");
                sql.AppendLine(", @nro_doc_ocupante");
                sql.AppendLine(", @cuit_ocupante");
                sql.AppendLine(", @nro_bad_ocupante");
                sql.AppendLine(", @cod_categoria_zona_liq");
                sql.AppendLine(", @tipo_ph");
                sql.AppendLine(", @fecha_tipo_ph");
                sql.AppendLine(", @cuil");
                sql.AppendLine(", @fecha_vecino_digital");
                sql.AppendLine(", @cuit_vecino_digital");
                sql.AppendLine(", @LAT");
                sql.AppendLine(", @LONG");
                sql.AppendLine(", @DIR_GOOGLE");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@exhimido", obj.exhimido);
                    cmd.Parameters.AddWithValue("@jubilado", obj.jubilado);
                    cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", obj.cod_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@cod_calle_dom_esp", obj.cod_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@union_tributaria", obj.union_tributaria);
                    cmd.Parameters.AddWithValue("@edificado", obj.edificado);
                    cmd.Parameters.AddWithValue("@parquizado", obj.parquizado);
                    cmd.Parameters.AddWithValue("@baldio_sucio", obj.baldio_sucio);
                    cmd.Parameters.AddWithValue("@construccion", obj.construccion);
                    cmd.Parameters.AddWithValue("@cod_uso", obj.cod_uso);
                    cmd.Parameters.AddWithValue("@superficie", obj.superficie);
                    cmd.Parameters.AddWithValue("@piso_dpto", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@cod_calle_pf", obj.cod_calle_pf);
                    cmd.Parameters.AddWithValue("@nro_dom_pf", obj.nro_dom_pf);
                    cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@ultimo_periodo", obj.ultimo_periodo);
                    cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                    cmd.Parameters.AddWithValue("@ocupante", obj.ocupante);
                    cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@baldio_country", obj.baldio_country);
                    cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                    cmd.Parameters.AddWithValue("@nro_secuencia", obj.nro_secuencia);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    cmd.Parameters.AddWithValue("@municipal", obj.municipal);
                    cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@cod_tipo_per_elegido", obj.cod_tipo_per_elegido);
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    cmd.Parameters.AddWithValue("@superficie_edificada", obj.superficie_edificada);
                    cmd.Parameters.AddWithValue("@cod_estado", obj.cod_estado);
                    cmd.Parameters.AddWithValue("@cedulon_digital", obj.cedulon_digital);
                    cmd.Parameters.AddWithValue("@oculto", obj.oculto);
                    cmd.Parameters.AddWithValue("@nro_doc_ocupante", obj.nro_doc_ocupante);
                    cmd.Parameters.AddWithValue("@cuit_ocupante", obj.cuit_ocupante);
                    cmd.Parameters.AddWithValue("@nro_bad_ocupante", obj.nro_bad_ocupante);
                    cmd.Parameters.AddWithValue("@cod_categoria_zona_liq", obj.cod_categoria_zona_liq);
                    cmd.Parameters.AddWithValue("@tipo_ph", obj.tipo_ph);
                    cmd.Parameters.AddWithValue("@fecha_tipo_ph", obj.fecha_tipo_ph);
                    cmd.Parameters.AddWithValue("@cuil", obj.cuil);
                    cmd.Parameters.AddWithValue("@fecha_vecino_digital", obj.fecha_vecino_digital);
                    cmd.Parameters.AddWithValue("@cuit_vecino_digital", obj.cuit_vecino_digital);
                    cmd.Parameters.AddWithValue("@LAT", obj.LAT);
                    cmd.Parameters.AddWithValue("@LONG", obj.LONG);
                    cmd.Parameters.AddWithValue("@DIR_GOOGLE", obj.DIR_GOOGLE);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void update(Inmuebles obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Inmuebles SET");
                sql.AppendLine("cod_barrio=@cod_barrio");
                //sql.AppendLine(", nro_bad=@nro_bad");
                //sql.AppendLine(", Nombre=@Nombre");
                //sql.AppendLine(", exhimido=@exhimido");
                //sql.AppendLine(", jubilado=@jubilado");
                sql.AppendLine(", cod_barrio_dom_esp=@cod_barrio_dom_esp");
                sql.AppendLine(", nom_barrio_dom_esp=@nom_barrio_dom_esp");
                sql.AppendLine(", cod_calle_dom_esp=@cod_calle_dom_esp");
                sql.AppendLine(", nom_calle_dom_esp=@nom_calle_dom_esp");
                sql.AppendLine(", nro_dom_esp=@nro_dom_esp");
                sql.AppendLine(", piso_dpto_esp=@piso_dpto_esp");
                sql.AppendLine(", ciudad_dom_esp=@ciudad_dom_esp");
                sql.AppendLine(", provincia_dom_esp=@provincia_dom_esp");
                sql.AppendLine(", pais_dom_esp=@pais_dom_esp");
                //sql.AppendLine(", union_tributaria=@union_tributaria");
                //sql.AppendLine(", edificado=@edificado");
                //sql.AppendLine(", parquizado=@parquizado");
                //sql.AppendLine(", baldio_sucio=@baldio_sucio");
                //sql.AppendLine(", construccion=@construccion");
                sql.AppendLine(", cod_uso=@cod_uso");
                sql.AppendLine(", superficie=@superficie");
                sql.AppendLine(", piso_dpto=@piso_dpto");
                sql.AppendLine(", cod_calle_pf=@cod_calle_pf");
                sql.AppendLine(", nro_dom_pf=@nro_dom_pf");
                sql.AppendLine(", cod_postal=@cod_postal");
                sql.AppendLine(", ultimo_periodo=@ultimo_periodo");
                sql.AppendLine(", fecha_cambio_domicilio=@fecha_cambio_domicilio");
                sql.AppendLine(", ocupante=@ocupante");
                sql.AppendLine(", emite_cedulon=@emite_cedulon");
                //sql.AppendLine(", baldio_country=@baldio_country");
                //sql.AppendLine(", debito_automatico=@debito_automatico");
                //sql.AppendLine(", nro_secuencia=@nro_secuencia");
                //sql.AppendLine(", cod_situacion_judicial=@cod_situacion_judicial");
                //sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", clave_pago=@clave_pago");
                //sql.AppendLine(", municipal=@municipal");
                //sql.AppendLine(", email_envio_cedulon=@email_envio_cedulon");
                sql.AppendLine(", telefono=@telefono");
                sql.AppendLine(", celular=@celular");
                //sql.AppendLine(", cod_tipo_per_elegido=@cod_tipo_per_elegido");
                //sql.AppendLine(", con_deuda=@con_deuda");
                //sql.AppendLine(", saldo_adeudado=@saldo_adeudado");
                //sql.AppendLine(", superficie_edificada=@superficie_edificada");
                //sql.AppendLine(", cod_estado=@cod_estado");
                sql.AppendLine(", cedulon_digital=@cedulon_digital");
                //sql.AppendLine(", oculto=@oculto");
                //sql.AppendLine(", nro_doc_ocupante=@nro_doc_ocupante");
                //sql.AppendLine(", cuit_ocupante=@cuit_ocupante");
                //sql.AppendLine(", nro_bad_ocupante=@nro_bad_ocupante");
                sql.AppendLine(", cod_categoria_zona_liq=@cod_categoria_zona_liq");
                sql.AppendLine(", tipo_ph=@tipo_ph");
                if (obj.fecha_tipo_ph != null)
                    sql.AppendLine(", fecha_tipo_ph=@fecha_tipo_ph");
                sql.AppendLine(", cuil=@cuil");
                sql.AppendLine(", fecha_vecino_digital=@fecha_vecino_digital");
                sql.AppendLine(", cuit_vecino_digital=@cuit_vecino_digital");
                //sql.AppendLine(", LAT=@LAT");
                //sql.AppendLine(", LONG=@LONG");
                //sql.AppendLine(", DIR_GOOGLE=@DIR_GOOGLE");
                sql.AppendLine("WHERE");
                sql.AppendLine("circunscripcion=@circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND p_h=@p_h");

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                cmd.Parameters.AddWithValue("@cod_barrio", obj.cod_barrio);
                //cmd.Parameters.AddWithValue("@nro_bad", obj.nro_bad);
                //cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                //cmd.Parameters.AddWithValue("@exhimido", obj.exhimido);
                //cmd.Parameters.AddWithValue("@jubilado", obj.jubilado);
                cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", obj.cod_barrio_dom_esp);
                cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", obj.nom_barrio_dom_esp);
                cmd.Parameters.AddWithValue("@cod_calle_dom_esp", obj.cod_calle_dom_esp);
                cmd.Parameters.AddWithValue("@nom_calle_dom_esp", obj.nom_calle_dom_esp);
                cmd.Parameters.AddWithValue("@nro_dom_esp", obj.nro_dom_esp);
                cmd.Parameters.AddWithValue("@piso_dpto_esp", obj.piso_dpto_esp);
                cmd.Parameters.AddWithValue("@ciudad_dom_esp", obj.ciudad_dom_esp);
                cmd.Parameters.AddWithValue("@provincia_dom_esp", obj.provincia_dom_esp);
                cmd.Parameters.AddWithValue("@pais_dom_esp", obj.pais_dom_esp);
                //cmd.Parameters.AddWithValue("@union_tributaria", obj.union_tributaria);
                //cmd.Parameters.AddWithValue("@edificado", obj.edificado);
                //cmd.Parameters.AddWithValue("@parquizado", obj.parquizado);
                //cmd.Parameters.AddWithValue("@baldio_sucio", obj.baldio_sucio);
                //cmd.Parameters.AddWithValue("@construccion", obj.construccion);
                cmd.Parameters.AddWithValue("@cod_uso", obj.cod_uso);
                cmd.Parameters.AddWithValue("@superficie", obj.superficie);
                cmd.Parameters.AddWithValue("@piso_dpto", obj.piso_dpto);
                cmd.Parameters.AddWithValue("@cod_calle_pf", obj.cod_calle_pf);
                cmd.Parameters.AddWithValue("@nro_dom_pf", obj.nro_dom_pf);
                cmd.Parameters.AddWithValue("@cod_postal", obj.cod_postal);
                cmd.Parameters.AddWithValue("@ultimo_periodo", obj.ultimo_periodo);
                cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ocupante", obj.ocupante);
                cmd.Parameters.AddWithValue("@emite_cedulon", obj.emite_cedulon);
                //cmd.Parameters.AddWithValue("@baldio_country", obj.baldio_country);
                //cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                //cmd.Parameters.AddWithValue("@nro_secuencia", obj.nro_secuencia);
                //cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                //cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                //cmd.Parameters.AddWithValue("@municipal", obj.municipal);
                //cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
                //cmd.Parameters.AddWithValue("@cod_tipo_per_elegido", obj.cod_tipo_per_elegido);
                //cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                //cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                //cmd.Parameters.AddWithValue("@superficie_edificada", obj.superficie_edificada);
                //cmd.Parameters.AddWithValue("@cod_estado", obj.cod_estado);
                cmd.Parameters.AddWithValue("@cedulon_digital", obj.cedulon_digital);
                //cmd.Parameters.AddWithValue("@oculto", obj.oculto);
                //cmd.Parameters.AddWithValue("@nro_doc_ocupante", obj.nro_doc_ocupante);
                //cmd.Parameters.AddWithValue("@cuit_ocupante", obj.cuit_ocupante);
                //cmd.Parameters.AddWithValue("@nro_bad_ocupante", obj.nro_bad_ocupante);
                cmd.Parameters.AddWithValue("@cod_categoria_zona_liq", obj.cod_categoria_zona_liq);
                cmd.Parameters.AddWithValue("@tipo_ph", obj.tipo_ph);
                if (obj.fecha_tipo_ph != null)
                    cmd.Parameters.AddWithValue("@fecha_tipo_ph", obj.fecha_tipo_ph);
                cmd.Parameters.AddWithValue("@cuil", obj.cuil);
                cmd.Parameters.AddWithValue("@fecha_vecino_digital", obj.fecha_vecino_digital ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cuit_vecino_digital", obj.cuit_vecino_digital);
                //cmd.Parameters.AddWithValue("@LAT", obj.LAT);
                //cmd.Parameters.AddWithValue("@LONG", obj.LONG);
                //cmd.Parameters.AddWithValue("@DIR_GOOGLE", obj.DIR_GOOGLE);
                cmd.ExecuteNonQuery();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void delete(Inmuebles obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Inmuebles ");
                sql.AppendLine("WHERE");
                sql.AppendLine("circunscripcion=@circunscripcion");
                sql.AppendLine("AND seccion=@seccion");
                sql.AppendLine("AND manzana=@manzana");
                sql.AppendLine("AND parcela=@parcela");
                sql.AppendLine("AND p_h=@p_h");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int cir, int sec, int man, int par, int p_h, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Inmuebles");
                sql.AppendLine("WHERE");
                sql.AppendLine("circunscripcion = @circunscripcion");
                sql.AppendLine("AND seccion = @seccion");
                sql.AppendLine("AND manzana = @manzana");
                sql.AppendLine("AND parcela = @parcela");
                sql.AppendLine("AND p_h = @p_h");

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el inmueble", ex);
            }
        }


        /////
        ///
        // public async static Task<int> Count()
        // {
        //     try
        //     {
        //         int count = 0;
        //         string sql = @"SELECT count(*) 
        //                        FROM Inmuebles (nolock)";
        //         //Where Baja=@baja";
        //         using (SqlConnection con = GetConnectionSIIMVA())
        //         {
        //             SqlCommand cmd = con.CreateCommand();
        //             cmd.CommandType = CommandType.Text;
        //             cmd.CommandText = sql;
        //             //cmd.Parameters.AddWithValue("@baja", baja);
        //             await cmd.Connection.OpenAsync();
        //             count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        //             return count;
        //         }
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }

        public static int Count()
        {
            try
            {
                int count = 0;
                string sql = @"SELECT count(*)        
                               FROM Inmuebles (nolock)";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string armoDenominacion(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                StringBuilder denominacion = new StringBuilder();

                if (cir < 10)
                    denominacion.AppendFormat("CIR: 0{0} - ", cir);
                if (cir > 9 && cir < 100)
                    denominacion.AppendFormat("CIR: {0} - ", cir);

                if (sec < 10)
                    denominacion.AppendFormat("SEC: 0{0} - ", sec);
                if (sec > 9 && sec < 100)
                    denominacion.AppendFormat("SEC: {0} - ", sec);

                if (man < 10)
                    denominacion.AppendFormat("MAN: 00{0} - ", man);
                if (man > 9 && man < 100)
                    denominacion.AppendFormat("MAN: 0{0} - ", man);
                if (man > 99)
                    denominacion.AppendFormat("MAN: {0} - ", man);

                if (par < 10)
                    denominacion.AppendFormat("PAR: 00{0} - ", par);
                if (par > 9 && par < 100)
                    denominacion.AppendFormat("PAR: 0{0} - ", par);
                if (par > 99)
                    denominacion.AppendFormat("PAR: {0} - ", par);

                if (p_h < 10)
                    denominacion.AppendFormat("P_H: 00{0}", p_h);
                if (p_h > 9 && p_h < 100)
                    denominacion.AppendFormat("P_H: 0{0}", p_h);
                if (p_h > 99)
                    denominacion.AppendFormat("P_H: {0}", p_h);

                return denominacion.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string armoDenominacion2(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                StringBuilder denominacion = new StringBuilder();

                if (cir < 10)
                    denominacion.AppendFormat("0{0}", cir);
                if (cir > 9 && cir < 100)
                    denominacion.AppendFormat("{0}", cir);

                if (sec < 10)
                    denominacion.AppendFormat("0{0}", sec);
                if (sec > 9 && sec < 100)
                    denominacion.AppendFormat("{0}", sec);

                if (man < 10)
                    denominacion.AppendFormat("00{0}", man);
                if (man > 9 && man < 100)
                    denominacion.AppendFormat("0{0}", man);
                if (man > 99)
                    denominacion.AppendFormat("{0}", man);

                if (par < 10)
                    denominacion.AppendFormat("00{0}", par);
                if (par > 9 && par < 100)
                    denominacion.AppendFormat("0{0}", par);
                if (par > 99)
                    denominacion.AppendFormat("{0}", par);

                if (p_h < 10)
                    denominacion.AppendFormat("00{0}", p_h);
                if (p_h > 9 && p_h < 100)
                    denominacion.AppendFormat("0{0}", p_h);
                if (p_h > 99)
                    denominacion.AppendFormat("{0}", p_h);

                return denominacion.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string armoDenominacion3(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                StringBuilder denominacion = new StringBuilder();

                if (cir < 10)
                    denominacion.AppendFormat("0{0}-", cir);
                if (cir > 9 && cir < 100)
                    denominacion.AppendFormat("{0}-", cir);

                if (sec < 10)
                    denominacion.AppendFormat("0{0}-", sec);
                if (sec > 9 && sec < 100)
                    denominacion.AppendFormat("{0}-", sec);

                if (man < 10)
                    denominacion.AppendFormat("00{0}-", man);
                if (man > 9 && man < 100)
                    denominacion.AppendFormat("0{0}-", man);
                if (man > 99)
                    denominacion.AppendFormat("{0}-", man);

                if (par < 10)
                    denominacion.AppendFormat("00{0}-", par);
                if (par > 9 && par < 100)
                    denominacion.AppendFormat("0{0}-", par);
                if (par > 99)
                    denominacion.AppendFormat("{0}-", par);
                if (p_h < 10)
                    denominacion.AppendFormat("00{0}", p_h);
                if (p_h > 9 && p_h < 100)
                    denominacion.AppendFormat("0{0}", p_h);
                if (p_h > 99)
                    denominacion.AppendFormat("{0}", p_h);
                return denominacion.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Inmuebles> GetInmueblesPaginado(string buscarPor, string strParametro,
            int registro_desde, int registro_hasta)
        {
            try
            {
                List<Inmuebles> lst = new List<Inmuebles>();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PAGINACION_TASA";

                    cmd.Parameters.AddWithValue("@filtro", buscarPor);
                    cmd.Parameters.AddWithValue("@valor_filtro", strParametro);
                    cmd.Parameters.AddWithValue("@pagina_inicio", registro_desde);
                    cmd.Parameters.AddWithValue("@cant_registros", registro_hasta);
                    SqlParameter total_row = new SqlParameter("@total_row", SqlDbType.Int);
                    total_row.Direction = ParameterDirection.Output;
                    total_row.Value = 0;
                    cmd.Parameters.Add(total_row);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Inmuebles> GetAllExhimidos()
        {
            try
            {
                List<Inmuebles> lst = new List<Inmuebles>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Inmuebles Where exhimido=1";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Inmuebles GetInmuebleByDenominacion(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Inmuebles");
                sql.AppendLine("WHERE ");
                sql.AppendLine("circunscripcion = @circunscripcion");
                sql.AppendLine("AND seccion = @seccion");
                sql.AppendLine("AND manzana = @manzana");
                sql.AppendLine("AND parcela = @parcela");
                sql.AppendLine("AND p_h = @p_h");
                Inmuebles? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    obj = new Inmuebles();
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
                    List<Inmuebles> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Combo> Tipos_documentos()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT cod_tipo_documento, des_tipo_documento FROM TIPOS_DOCUMENTOS";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
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
        public static List<Combo> Situacion_judicial()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " select cod_situacion_judicial, descripcion \r\nfrom SITUACION_JUDICIAL";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Tipos_PH()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "  select*\r\nfrom TIPOS_PH_CAT";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Categorias_liq_zona()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT 1 as codigo, categoria FROM CATEGORIAS_LIQUIDACION_TASA";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
                            //if (!dr.IsDBNull(2)) { obj.campo_enlace = string.Empty; }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Combo> Calles(string descripcion)
        {
            try
            {
                List<Combo> lst = new();
                Combo obj;
                string strSQL = @"SELECT  
                                    cod_calle,
                                    nom_calle
                                  FROM CALLES
                                  WHERE  nom_calle LIKE @nombre_aproximado
                                  ORDER BY nom_calle";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (descripcion.Length > 0)
                        descripcion += "%";
                    else
                        descripcion = "%";
                    cmd.Parameters.AddWithValue("@nombre_aproximado", descripcion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0))
                            {
                                obj.value = Convert.ToString(dr.GetInt32(0));
                                obj.text = dr.GetString(1);
                            }

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
        public static List<Combo> Barrios(string descripcion)
        {
            try
            {
                List<Combo> lst = new();
                Combo obj;
                string strSQL = @"SELECT  
                                    cod_barrio,
                                    nom_barrio
                                  FROM BARRIOS
                                  WHERE  nom_barrio LIKE @nombre_aproximado
                                  ORDER BY nom_barrio";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (descripcion.Length > 0)
                        descripcion += "%";
                    else
                        descripcion = "%";
                    cmd.Parameters.AddWithValue("@nombre_aproximado", descripcion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0))
                            {
                                obj.value = Convert.ToString(dr.GetInt32(0));
                                obj.text = dr.GetString(1);
                            }
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
        public static List<Combo> Uso_inmueble(string descripcion)
        {
            try
            {
                List<Combo> lst = new();
                Combo obj;
                string strSQL = @"SELECT  
                                    cod_uso,  
                                    des_uso
                                  FROM USOS_INMUEBLES
                                  WHERE  des_uso LIKE @nombre_aproximado
                                  ORDER BY des_uso";
                using (SqlConnection cn = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (descripcion.Length > 0)
                        descripcion += "%";
                    else
                        descripcion = "%";
                    cmd.Parameters.AddWithValue("@nombre_aproximado", descripcion);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Combo();
                            if (!dr.IsDBNull(0))
                            {
                                obj.value = Convert.ToString(dr.GetInt32(0));
                                obj.text = dr.GetString(1);
                            }
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
        public static List<Combo> ListarCategoriasTasa()
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

        #region Frentes
        public static List<FrentesInmueble> FrentesXInmueble(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                List<FrentesInmueble> lst = new List<FrentesInmueble>();
                FrentesInmueble obj = new();

                string SQL = @"SELECT* FROM FRENTES_X_INMUEBLE
                   WHERE circunscripcion=@circunscripcion AND
                   seccion=@seccion AND
                   manzana=@manzana AND
                   parcela=@parcela AND
                   p_h=@p_h";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new FrentesInmueble();
                            if (!dr.IsDBNull(0)) { obj.circunscripcion = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.seccion = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.manzana = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.parcela = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.p_h = dr.GetInt32(4); }
                            if (!dr.IsDBNull(5)) { obj.nro_frente = dr.GetInt32(5); }
                            if (!dr.IsDBNull(6)) { obj.cod_calle = dr.GetInt32(6); }
                            if (!dr.IsDBNull(7)) { obj.nro_domicilio = dr.GetInt32(7); }
                            if (!dr.IsDBNull(8)) { obj.metros_frente = dr.GetFloat(8); }
                            if (!dr.IsDBNull(9)) { obj.cod_zona = dr.GetInt32(9); }

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


        public static List<Zonas> GetZonas(int? cod_zona)
        {
            try
            {
                List<Zonas> lst = new List<Zonas>();
                Zonas obj = new();

                string SQL = @"     SELECT * 
                                    FROM ZONAS 
                                    WHERE @cod_zona IS NULL OR cod_zona = @cod_zona;";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;

                    if (cod_zona.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@cod_zona", cod_zona);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cod_zona", DBNull.Value);
                    }
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Zonas();
                            if (!dr.IsDBNull(0)) { obj.cod_zona = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nom_zona = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.tasa_basica_edificado = dr.GetDecimal(2); }
                            if (!dr.IsDBNull(3)) { obj.excedente_edificado = dr.GetDecimal(3); }
                            if (!dr.IsDBNull(4)) { obj.tasa_basica_baldio = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.excedente_baldio = dr.GetDecimal(5); }

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

        public static int ObtenerUltimoNroFrente(SqlConnection con, SqlTransaction trx, int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {

            SqlCommand cmd = new SqlCommand(@"
                                SELECT ISNULL(MAX(nro_frente), 0) 
                                FROM FRENTES_X_INMUEBLE 
                                WHERE circunscripcion = @circunscripcion 
                                  AND seccion = @seccion 
                                  AND manzana = @manzana 
                                  AND parcela = @parcela 
                                  AND p_h = @p_h", con, trx);

            cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
            cmd.Parameters.AddWithValue("@seccion", seccion);
            cmd.Parameters.AddWithValue("@manzana", manzana);
            cmd.Parameters.AddWithValue("@parcela", parcela);
            cmd.Parameters.AddWithValue("@p_h", p_h);

            return (int)cmd.ExecuteScalar();
        }


        public static void InsertFrente(int circunscripcion, int seccion, int manzana, int parcela, int p_h, int nro_frente, int cod_calle, int nro_domicilio, float metros_frente, int cod_zona, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string SQL = @"INSERT INTO FRENTES_X_INMUEBLE 
                       (circunscripcion, seccion, manzana, parcela, p_h, nro_frente, cod_calle, nro_domicilio, metros_frente, cod_zona)
                       VALUES 
                       (@circunscripcion, @seccion, @manzana, @parcela, @p_h, @nro_frente, @cod_calle, @nro_domicilio, @metros_frente, @cod_zona)";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;

                cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                cmd.Parameters.AddWithValue("@seccion", seccion);
                cmd.Parameters.AddWithValue("@manzana", manzana);
                cmd.Parameters.AddWithValue("@parcela", parcela);
                cmd.Parameters.AddWithValue("@p_h", p_h);
                cmd.Parameters.AddWithValue("@nro_frente", nro_frente);
                cmd.Parameters.AddWithValue("@cod_calle", cod_calle);
                cmd.Parameters.AddWithValue("@nro_domicilio", nro_domicilio);
                cmd.Parameters.AddWithValue("@metros_frente", metros_frente);
                cmd.Parameters.AddWithValue("@cod_zona", cod_zona);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar en FRENTES_X_INMUEBLE", ex);
            }
        }

        public static void UpdateFrente(FrentesInmueble obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string SQL = @"UPDATE FRENTES_X_INMUEBLE 
                       SET cod_calle = @cod_calle, 
                           nro_domicilio = @nro_domicilio, 
                           metros_frente = @metros_frente, 
                           cod_zona = @cod_zona 
                       WHERE nro_frente = @nro_frente
                         AND circunscripcion = @circunscripcion
                         AND seccion = @seccion
                         AND manzana = @manzana
                         AND parcela = @parcela
                         AND p_h = @p_h";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;

                cmd.Parameters.AddWithValue("@cod_calle", obj.cod_calle);
                cmd.Parameters.AddWithValue("@nro_domicilio", obj.nro_domicilio);
                cmd.Parameters.AddWithValue("@metros_frente", obj.metros_frente);
                cmd.Parameters.AddWithValue("@cod_zona", obj.cod_zona);

                cmd.Parameters.AddWithValue("@nro_frente", obj.nro_frente);
                cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                cmd.Parameters.AddWithValue("@p_h", obj.p_h);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el frente en FRENTES_X_INMUEBLE", ex);
            }
        }


        public static void DeleteFrente(int circunscripcion, int seccion, int manzana, int parcela, int p_h, int nro_frente, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string query = @"DELETE FROM FRENTES_X_INMUEBLE 
                         WHERE circunscripcion = @circunscripcion 
                           AND seccion = @seccion 
                           AND manzana = @manzana 
                           AND parcela = @parcela 
                           AND p_h = @p_h 
                           AND nro_frente = @nro_frente";

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@circunscripcion", circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@manzana", manzana);
                    cmd.Parameters.AddWithValue("@parcela", parcela);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Parameters.AddWithValue("@nro_frente", nro_frente);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el frente en FRENTES_X_INMUEBLE", ex);
            }
        }


        public static List<Combo> GetCalle(string? nomcalle)
        {
            try
            {
                string strSQL = @"	SELECT
                            cod_calle,
                            nom_calle
                          FROM Calles
                          WHERE
                             (@nomcalle IS NULL OR @nomcalle = '' OR nom_calle LIKE @nomcalle + '%')
                          ORDER BY
                              nom_calle";
                List<Combo> lst = new List<Combo>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nomcalle", nomcalle + "%");
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Combo? obj;
                    obj = new Combo();
                    obj.text = "TODAS LAS CALLES";
                    obj.value = "0";
                    lst.Add(obj);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                            if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }
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

        public static List<Barrios> GetBarrios(string? barrio)
        {
            try
            {
                string strSQL = @"	
                                SELECT 
                                COD_BARRIO, 
                                NOM_BARRIO, 
                                BarrioCerrado 
                            FROM 
                                BARRIOS b 
                            WHERE 
                                (@nom_barrio IS NULL OR @nom_barrio = '' OR NOM_BARRIO LIKE '%' + @nom_barrio + '%');";
                List<Barrios> lst = new List<Barrios>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    if (string.IsNullOrEmpty(barrio))
                    {
                        cmd.Parameters.AddWithValue("@nom_barrio", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@nom_barrio", barrio);
                    }
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Barrios obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Barrios();
                            if (!dr.IsDBNull(0)) { obj.cod_barrio = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nom_barrio = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.BarrioCerrado = dr.GetInt16(2); }
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

        #endregion


        public static DatosConexionAgua GetDatosConexionAgua(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                DatosConexionAgua obj = new DatosConexionAgua();

                string SQL = @"                      
                            select i.Nombre, i.circunscripcion, i.seccion, i.manzana, i.parcela, i.p_h
                            , c.NOM_CALLE, i.nro_dom_pf, b.NOM_BARRIO, ca.Manzana_Oficial, ca.Lote_Oficial, ca.Superficie
                            , domicilio= c.NOM_CALLE + ' Nº ' + cast(i.nro_dom_pf as varchar(10)) + ' de Barrio ' + b.NOM_BARRIO
                            from INMUEBLES i left join CALLES c on c.COD_CALLE= i.cod_calle_pf
                            left join BARRIOS b  on b.COD_BARRIO= i.cod_barrio
                            left join CATASTRO ca on ca.Circunscripcion= i.circunscripcion and ca.seccion= i.seccion
                            and ca.manzana= i.manzana and ca.parcela= i.parcela and ca.P_H= i.p_h
                            where i.circunscripcion= @circunscripcion and i.seccion= @seccion
                            and i.manzana= @manzana and i.parcela= @parcela and i.p_h = @p_h";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        if (!dr.IsDBNull(0)) obj.nombre = dr.GetString(0);
                        if (!dr.IsDBNull(1)) obj.circunscripcion = dr.GetInt32(1);
                        if (!dr.IsDBNull(2)) obj.seccion = dr.GetInt32(2);
                        if (!dr.IsDBNull(3)) obj.manzana = dr.GetInt32(3);
                        if (!dr.IsDBNull(4)) obj.parcela = dr.GetInt32(4);
                        if (!dr.IsDBNull(5)) obj.p_h = dr.GetInt32(5);
                        if (!dr.IsDBNull(6)) obj.nom_calle = dr.GetString(6);
                        if (!dr.IsDBNull(7)) obj.nro_dom_pf = dr.GetInt32(7);
                        if (!dr.IsDBNull(8)) obj.nom_barrio = dr.GetString(8);
                        if (!dr.IsDBNull(9)) obj.manzana_oficial = dr.GetString(9);
                        if (!dr.IsDBNull(10)) obj.lote_oficial = dr.GetString(10);
                        if (!dr.IsDBNull(11)) obj.superficie = dr.GetFloat(11);
                        if (!dr.IsDBNull(12)) obj.domicilio = dr.GetString(12);
                    }

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de conexion de agua", ex);
            }

        }

        #region Domicilio Postal
        public static DatosDomicilio DatosDomicilioPostal(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                DatosDomicilio obj = new DatosDomicilio();

                string SQL = @"  SELECT  
                                 nom_calle_dom_esp, 
                                 cod_calle_dom_esp, 
                                 piso_dpto_esp, 
                                 cod_barrio_dom_esp, 
                                 nom_barrio_dom_esp, 
                                 ciudad_dom_esp, 
                                 provincia_dom_esp, 
                                 pais_dom_esp, 
                                 cod_postal, 
                                 email_envio_cedulon, 
                                 telefono, 
                                 celular, 
                                 cuit_ocupante, 
                                 fecha_cambio_domicilio,
                                 nro_bad,
                                 nro_dom_esp
                             FROM 
                                 INMUEBLES 
                             WHERE 
                                 circunscripcion = @circunscripcion 
                                 AND seccion = @seccion
                                 AND manzana = @manzana 
                                 AND parcela = @parcela 
                                 AND p_h = @p_h;";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        if (!dr.IsDBNull(0)) obj.nom_calle_dom_esp = dr.GetString(0);
                        if (!dr.IsDBNull(1)) obj.cod_calle_dom_esp = dr.GetInt32(1);
                        if (!dr.IsDBNull(2)) obj.piso_dpto_esp = dr.GetString(2);
                        if (!dr.IsDBNull(3)) obj.cod_barrio_dom_esp = dr.GetInt32(3);
                        if (!dr.IsDBNull(4)) obj.nom_barrio_dom_esp = dr.GetString(4);
                        if (!dr.IsDBNull(5)) obj.ciudad_dom_esp = dr.GetString(5);
                        if (!dr.IsDBNull(6)) obj.provincia_dom_esp = dr.GetString(6);
                        if (!dr.IsDBNull(7)) obj.pais_dom_esp = dr.GetString(7);
                        if (!dr.IsDBNull(8)) obj.cod_postal = dr.GetString(8);
                        if (!dr.IsDBNull(9)) obj.email_envio_cedulon = dr.GetString(9);
                        if (!dr.IsDBNull(10)) obj.telefono = dr.GetString(10);
                        if (!dr.IsDBNull(11)) obj.celular = dr.GetString(11);
                        if (!dr.IsDBNull(12)) obj.cuit_ocupante = dr.GetString(12);
                        if (!dr.IsDBNull(13)) obj.fecha_cambio_domicilio = dr.GetDateTime(13);
                        if (!dr.IsDBNull(14)) obj.nro_bad = dr.GetInt32(14);
                        if (!dr.IsDBNull(15)) obj.nro_dom_esp = dr.GetInt32(15);
                    }

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de domicilio posta", ex);
            }

        }


        public static void ModificarBadec(string telefono, string email, string cuit, string celular, int nro_bad, SqlConnection con, SqlTransaction trx)
        {
            {
                try
                {
                    string SQL = @"UPDATE BADEC
                       SET TELEFONO = @telefono, 
                           E_MAIL = @email, 
                           CUIT = @cuit, 
                           CELULAR = @celular 
                       WHERE NRO_BAD = @nro_bad ";

                    SqlCommand cmd = con.CreateCommand();
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;

                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Parameters.AddWithValue("@celular", celular);
                    cmd.Parameters.AddWithValue("@nro_bad", nro_bad);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar datos de contacto en badec", ex);
                }
            }
        }

        public static void ActualizarDatosDomicilio(int cir, int sec, int man, int par, int p_h, DatosDomicilio datos, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string SQL = @"UPDATE INMUEBLES 
                       SET 
                           nom_calle_dom_esp = @nom_calle_dom_esp, 
                           cod_calle_dom_esp = @cod_calle_dom_esp, 
                           piso_dpto_esp = @piso_dpto_esp, 
                           cod_barrio_dom_esp = @cod_barrio_dom_esp, 
                           nom_barrio_dom_esp = @nom_barrio_dom_esp, 
                           ciudad_dom_esp = @ciudad_dom_esp, 
                           provincia_dom_esp = @provincia_dom_esp, 
                           pais_dom_esp = @pais_dom_esp, 
                           cod_postal = @cod_postal, 
                           email_envio_cedulon = @email_envio_cedulon, 
                           telefono = @telefono, 
                           celular = @celular, 
                           cuit_ocupante = @cuit_ocupante, 
                           fecha_cambio_domicilio = @fecha_cambio_domicilio, 
                           nro_bad = @nro_bad,
                           nro_dom_esp =@nro_dom_esp
                           
                       WHERE 
                           circunscripcion = @circunscripcion 
                           AND seccion = @seccion
                           AND manzana = @manzana 
                           AND parcela = @parcela 
                           AND p_h = @p_h;";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Transaction = trx;

                cmd.Parameters.AddWithValue("@nom_calle_dom_esp", datos.nom_calle_dom_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_calle_dom_esp", datos.cod_calle_dom_esp);
                cmd.Parameters.AddWithValue("@piso_dpto_esp", datos.piso_dpto_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_barrio_dom_esp", datos.cod_barrio_dom_esp);
                cmd.Parameters.AddWithValue("@nom_barrio_dom_esp", datos.nom_barrio_dom_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ciudad_dom_esp", datos.ciudad_dom_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@provincia_dom_esp", datos.provincia_dom_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@pais_dom_esp", datos.pais_dom_esp ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_postal", datos.cod_postal ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@email_envio_cedulon", datos.email_envio_cedulon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", datos.telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@celular", datos.celular ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cuit_ocupante", datos.cuit_ocupante ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", DateTime.Now);
                cmd.Parameters.AddWithValue("@nro_bad", datos.nro_bad);
                cmd.Parameters.AddWithValue("@nro_dom_esp", datos.nro_dom_esp);

                cmd.Parameters.AddWithValue("@circunscripcion", cir);
                cmd.Parameters.AddWithValue("@seccion", sec);
                cmd.Parameters.AddWithValue("@manzana", man);
                cmd.Parameters.AddWithValue("@parcela", par);
                cmd.Parameters.AddWithValue("@p_h", p_h);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los datos de domicilio", ex);
            }
        }



        public static Combo GetBarrioXCalle(int cod_calle, int nro_dom) //, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                Combo obj = null;
                string SQL = @"
                                 SELECT 
                                     b.COD_BARRIO, 
                                     b.NOM_BARRIO 
                                 FROM 
                                     CALLES_X_BARRIO cxb
                                 INNER JOIN 
                                     BARRIOS b ON cxb.COD_BARRIO = b.COD_BARRIO
                                 WHERE 
                                     cxb.COD_CALLE = @cod_calle 
                                     AND @nro_dom BETWEEN cxb.desde AND cxb.hasta;";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@cod_calle", cod_calle);
                    cmd.Parameters.AddWithValue("@nro_dom", nro_dom);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows && dr.Read())
                    {

                        obj = new Combo();
                        if (!dr.IsDBNull(0)) { obj.value = Convert.ToString(dr.GetInt32(0)); }
                        if (!dr.IsDBNull(1)) { obj.text = Convert.ToString(dr.GetString(1)); }

                    }
                    return obj;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al intentar obtener el barrio por calle.", ex);
            }
        }


        #endregion

        public static decimal MontoDeuda(int cir, int sec, int man, int par, int p_h)
        {
            try
            {

                decimal monto = 0;
                string SQL = @"   SELECT SUM(DEBE)-SUM(HABER)
                                         FROM CTASCTES_INMUEBLES
                                         WHERE
                                         CIRCUNSCRIPCION =@circunscripcion AND
                                         SECCION=@seccion AND
                                         MANZANA=@manzana AND
                                         PARCELA=@parcela AND
                                         P_H=@p_h;";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@circunscripcion", cir);
                    cmd.Parameters.AddWithValue("@seccion", sec);
                    cmd.Parameters.AddWithValue("@manzana", man);
                    cmd.Parameters.AddWithValue("@parcela", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        monto = Convert.ToDecimal(result);
                    }

                    return monto;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener monto deuda", ex);
            }

        }


        public static void EliminarParcelaXInmueble(int cir, int sec, int man, int par, int p_h, SqlConnection con, SqlTransaction trx)
        {
            {
                try
                {
                    string query = @"  DELETE
                                          FROM Parcelas_x_Inmueble
                                          WHERE
                                              circunscripcion = @cir AND
                                              seccion = @sec AND
                                              manzana = @man AND
                                              parcela_unificada = @par AND
                                              p_h_unificado = @p_h;";

                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = trx;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@cir", cir);
                        cmd.Parameters.AddWithValue("@sec", sec);
                        cmd.Parameters.AddWithValue("@man", man);
                        cmd.Parameters.AddWithValue("@par", par);
                        cmd.Parameters.AddWithValue("@p_h", p_h);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el frente en Parcela por Inmueble", ex);
                }


            }

        }



        public static DatosBaldio GetDatosBaldios(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                DatosBaldio obj = new DatosBaldio();

                string SQL = @"   select
                                  Nombre = Convert(char(25), b.nombre),
                                  nro_bad = b.nro_bad,
                                  cir = RIGHT('00' + CAST(i.circunscripcion AS VARCHAR(2)), 2),
                                  sec = RIGHT('00' + CAST(i.seccion AS VARCHAR(2)), 2),
                                  man = RIGHT('000' + CAST(i.manzana AS VARCHAR(3)), 3),
                                  par = RIGHT('000' + CAST(i.parcela AS VARCHAR(3)), 3),
                                  p_h = RIGHT('000' + CAST(i.p_h AS VARCHAR(3)), 3),
                                  calle = CONVERT(CHAR(20), c.nom_calle),
                                  nro = i.nro_dom_pf,
                                  barrio = ' Bº ' + Convert(varchar(20), Ltrim(Rtrim(i.nom_barrio_dom_esp))),
                                  cod_postal = i.cod_postal,
                                  ISNULL(Convert(varchar(20),Ltrim(Rtrim(i.nom_calle_dom_esp))) ,' ')  + ' ' +
                                  ISNULL(Convert(varchar(5),i.nro_dom_esp) ,' ') + ' ' +
                                  ISNULL(i.piso_dpto,'') + ' - Bº ' + ISNULL(Convert(varchar(20),Ltrim(Rtrim(i.nom_barrio_dom_esp))),' ') as Domicilio,
                                  ISNULL(i.ciudad_dom_esp,'') + ' - CP. ' + isnull(i.cod_postal,' ') as ciudad ,
                                  i.provincia_dom_esp,
                                  i.pais_dom_esp
                                  FROM inmuebles i, badec b, barrios a, calles c
                                  WHERE
                                  i.nro_bad=b.nro_bad and
                                  i.cod_barrio=a.cod_barrio and
                                  i.cod_calle_pf=c.cod_calle and
                                  i.circunscripcion=@cir and
                                  i.seccion=@sec and
                                  i.manzana=@man and
                                  i.parcela=@par and
                                  i.p_h=@p_h
                                  order by
                                  i.cod_postal,
                                  i.nom_calle_dom_esp,
                                  i.nro_dom_esp";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        if (!dr.IsDBNull(0)) obj.nombre = dr.GetString(0);
                        if (!dr.IsDBNull(1)) obj.nro_bad = dr.GetInt32(1);
                        if (!dr.IsDBNull(2)) obj.circunscripcion = int.Parse(dr.GetString(2));
                        if (!dr.IsDBNull(3)) obj.seccion = int.Parse(dr.GetString(3));
                        if (!dr.IsDBNull(4)) obj.manzana = int.Parse(dr.GetString(4));
                        if (!dr.IsDBNull(5)) obj.parcela = int.Parse(dr.GetString(5));
                        if (!dr.IsDBNull(6)) obj.p_h = int.Parse(dr.GetString(6));
                        if (!dr.IsDBNull(7)) obj.calle = dr.GetString(7);
                        if (!dr.IsDBNull(8)) obj.nro = dr.GetInt32(8);
                        if (!dr.IsDBNull(9)) obj.barrio = dr.GetString(9);
                        if (!dr.IsDBNull(10)) obj.cod_postal = dr.GetString(10);
                        if (!dr.IsDBNull(11)) obj.domicilio = dr.GetString(11);
                        if (!dr.IsDBNull(12)) obj.ciudad = dr.GetString(12);
                        if (!dr.IsDBNull(13)) obj.provincia_dom_esp = dr.GetString(13);
                        if (!dr.IsDBNull(14)) obj.pais_dom_esp = dr.GetString(14);

                    }

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos Baldio", ex);
            }

        }

        public static List<Datos_Inm_Concepto> GetInmueblesByConcepto(int cod_concepto)
        {
            try
            {
                List<Datos_Inm_Concepto> lst = new List<Datos_Inm_Concepto>();
                Datos_Inm_Concepto obj = null;

                string SQL = @"  SELECT 
                                ci.cod_concepto_inmueble,
                                ci.des_concepto_inmueble,
                                i.circunscripcion,
                                i.seccion,
                                i.manzana,
                                i.parcela,
                                i.p_h,
                                di.porcentaje,
                                di.monto,
                                c.NOM_CALLE,
                                i.nro_dom_pf,
                                i.nro_bad,
                                b.NOMBRE,
                                di.activo,
                                di.fecha_alta_registro,
                                di.anio_desde,
                                di.anio_hasta
                            FROM 
                                INMUEBLES i
                            LEFT JOIN 
                                DESCADIC_X_INMUEBLE di
                                ON i.circunscripcion = di.circunscripcion
                                AND i.seccion = di.seccion
                                AND i.manzana = di.manzana
                                AND i.parcela = di.parcela
                                AND i.p_h = di.p_h
                            LEFT JOIN 
                               CONCEPTOS_INMUEBLE ci
                               ON di.cod_concepto_inmueble = ci.cod_concepto_inmueble
                            LEFT JOIN 
                               BADEC b
                               ON i.nro_bad = b.NRO_BAD
                            LEFT JOIN 
                               CALLES c
                                  ON i.cod_calle_pf = c.COD_CALLE
                            WHERE 
                               di.cod_concepto_inmueble IN (@cod_concepto)
                            ORDER BY 
                               ci.cod_concepto_inmueble,
                               i.circunscripcion,
                               i.seccion,
                                  i.manzana,
                                  i.parcela,
                                  i.p_h;";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@cod_concepto", cod_concepto);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows && dr.Read())
                    {
                        while (dr.Read())
                        {

                            obj = new();
                            if (!dr.IsDBNull(0)) obj.cod_concepto_inmueble = dr.GetInt32(0);
                            if (!dr.IsDBNull(1)) obj.des_concepto_inmueble = dr.GetString(1);
                            if (!dr.IsDBNull(2)) obj.circunscripcion = dr.GetInt32(2);
                            if (!dr.IsDBNull(3)) obj.seccion = dr.GetInt32(3);
                            if (!dr.IsDBNull(4)) obj.manzana = dr.GetInt32(4);
                            if (!dr.IsDBNull(5)) obj.parcela = dr.GetInt32(5);
                            if (!dr.IsDBNull(6)) obj.p_h = dr.GetInt32(6);
                            if (!dr.IsDBNull(7)) obj.porcentaje = dr.GetDecimal(7);
                            if (!dr.IsDBNull(8)) obj.monto = dr.GetDecimal(8);
                            if (!dr.IsDBNull(9)) obj.nom_calle = dr.GetString(9);
                            if (!dr.IsDBNull(10)) obj.nro_dom_pf = dr.GetInt32(10);
                            if (!dr.IsDBNull(11)) obj.nro_bad = dr.GetInt32(11);
                            if (!dr.IsDBNull(12)) obj.nombre = dr.GetString(12);
                            if (!dr.IsDBNull(13)) obj.activo = Convert.ToBoolean(dr.GetInt16(13));
                            if (!dr.IsDBNull(14)) obj.fecha_alta_registro = dr.GetDateTime(14);
                            if (!dr.IsDBNull(15)) obj.anio_desde = dr.GetInt32(15);
                            if (!dr.IsDBNull(16)) obj.anio_hasta = dr.GetInt32(16);

                            lst.Add(obj);
                        }

                    }

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de Inmuebles por concepto", ex);
            }

        }

    }

}

