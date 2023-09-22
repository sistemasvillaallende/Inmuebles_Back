using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Entities
{
    public class Vehiculos : DALBase
    {
        public string dominio { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public bool nacional { get; set; }
        public int anio { get; set; }
        public int nro_bad { get; set; }
        public int codigo_vehiculo { get; set; }
        public float peso_cm3 { get; set; }
        public DateTime? fecha_cambio_dominio { get; set; }
        public string dominio_anterior { get; set; }
        public DateTime? fecha_alta { get; set; }
        public bool tipo_alta { get; set; }
        public bool baja { get; set; }
        public DateTime? fecha_baja { get; set; }
        public int tipo_baja { get; set; }
        public string per_ult { get; set; }
        public string codigo_cip { get; set; }
        public string variante { get; set; }
        public bool exento { get; set; }
        public bool tributa_minimo { get; set; }
        public string nro_motor { get; set; }
        public int cod_barrio_dom_esp { get; set; }
        public string nom_barrio_dom_esp { get; set; }
        public int cod_calle_dom_esp { get; set; }
        public string nom_calle_dom_esp { get; set; }
        public int nro_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public string ciudad_dom_esp { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }
        public string cod_postal_dom_esp { get; set; }
        public DateTime? fecha_cambio_domicilio { get; set; }
        public DateTime? fecha_exencion { get; set; }
        public DateTime? fecha_vto_exencion { get; set; }
        public string causa_exencion { get; set; }
        public DateTime? fecha_ingreso { get; set; }
        public bool emite_cedulon { get; set; }
        public int cod_registro_auto { get; set; }
        public string responsable { get; set; }
        public string porcentaje { get; set; }
        public string sexo { get; set; }
        public int cod_alta { get; set; }
        public int cod_baja { get; set; }
        public bool debito_automatico { get; set; }
        public int nro_secuencia { get; set; }
        public int cod_situacion_judicial { get; set; }
        public string codigo_cip_ant { get; set; }
        public string codigo_acara { get; set; }
        public string nombre { get; set; }
        public int cod_tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public int cod_tipo_liquidacion { get; set; }
        public string clave_pago { get; set; }
        public decimal monto { get; set; }
        public string email_envio_cedulon { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public DateTime? fecha_cambio_radicacion { get; set; }
        public short cedulon_digital { get; set; }
        public string usuario { get; set; }
        public string usuariomodifica { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string clave_pago2 { get; set; }
        public string cuit { get; set; }
        public string cuit_vecino_digital { get; set; }
        public DateTime? fecha_vecino_digital { get; set; }
        public short con_deuda { get; set; }
        public decimal saldo_adeudado { get; set; }
        public DateTime? fecha_baja_real { get; set; }
        public DateTime? fecha_denuncia_vta { get; set; }
        public Auditoria objAuditoria { get; set; }
        //public List<Ctasctes_automotores> lstCtasctes { get; set; }
        //
        //campos que se usan como datos enlazados
        //
        public Vehiculos()
        {
            dominio = string.Empty;
            marca = string.Empty;
            modelo = string.Empty;
            nacional = false;
            anio = 0;
            nro_bad = 0;
            codigo_vehiculo = 0;
            peso_cm3 = 0;
            fecha_cambio_dominio = null;
            dominio_anterior = string.Empty;
            fecha_alta = null;
            tipo_alta = false;
            baja = false;
            fecha_baja = null;
            tipo_baja = 0;
            per_ult = string.Empty;
            codigo_cip = string.Empty;
            variante = string.Empty;
            exento = false;
            tributa_minimo = false;
            nro_motor = string.Empty;
            cod_barrio_dom_esp = 0;
            nom_barrio_dom_esp = string.Empty;
            cod_calle_dom_esp = 0;
            nom_calle_dom_esp = string.Empty;
            nro_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            ciudad_dom_esp = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
            cod_postal_dom_esp = string.Empty;
            fecha_cambio_domicilio = null;
            fecha_exencion = null;
            fecha_vto_exencion = null;
            causa_exencion = string.Empty;
            fecha_ingreso = null;
            emite_cedulon = false;
            cod_registro_auto = 0;
            responsable = string.Empty;
            porcentaje = string.Empty;
            sexo = string.Empty;
            cod_alta = 0;
            cod_baja = 0;
            debito_automatico = false;
            nro_secuencia = 0;
            cod_situacion_judicial = 0;
            codigo_cip_ant = string.Empty;
            codigo_acara = string.Empty;
            nombre = string.Empty;
            cod_tipo_documento = 0;
            nro_documento = string.Empty;
            cod_tipo_liquidacion = 0;
            clave_pago = string.Empty;
            monto = 0;
            email_envio_cedulon = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            fecha_cambio_radicacion = null;
            cedulon_digital = 0;
            usuario = string.Empty;
            usuariomodifica = string.Empty;
            fecha_modificacion = null;
            clave_pago2 = string.Empty;
            cuit = string.Empty;
            cuit_vecino_digital = string.Empty;
            fecha_vecino_digital = null;
            con_deuda = 0;
            saldo_adeudado = 0;
            fecha_baja_real = null;
            fecha_denuncia_vta = null;
            objAuditoria = new Auditoria();
            //lstCtasctes = new List<Ctasctes_automotores>();

        }
        private static List<Vehiculos> mapeo(SqlDataReader dr)
        {
            DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
            List<Vehiculos> lst = new();
            Vehiculos obj;
            if (dr.HasRows)
            {
                int dominio = dr.GetOrdinal("dominio");
                int marca = dr.GetOrdinal("marca");
                int modelo = dr.GetOrdinal("modelo");
                int nacional = dr.GetOrdinal("nacional");
                int anio = dr.GetOrdinal("anio");
                int nro_bad = dr.GetOrdinal("nro_bad");
                int codigo_vehiculo = dr.GetOrdinal("codigo_vehiculo");
                int peso_cm3 = dr.GetOrdinal("peso_cm3");
                int fecha_cambio_dominio = dr.GetOrdinal("fecha_cambio_dominio");
                int dominio_anterior = dr.GetOrdinal("dominio_anterior");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int tipo_alta = dr.GetOrdinal("tipo_alta");
                int baja = dr.GetOrdinal("baja");
                int fecha_baja = dr.GetOrdinal("fecha_baja");
                int tipo_baja = dr.GetOrdinal("tipo_baja");
                int per_ult = dr.GetOrdinal("per_ult");
                int codigo_cip = dr.GetOrdinal("codigo_cip");
                int variante = dr.GetOrdinal("variante");
                int exento = dr.GetOrdinal("exento");
                int tributa_minimo = dr.GetOrdinal("tributa_minimo");
                int nro_motor = dr.GetOrdinal("nro_motor");
                int cod_barrio_dom_esp = dr.GetOrdinal("cod_barrio_dom_esp");
                int nom_barrio_dom_esp = dr.GetOrdinal("nom_barrio_dom_esp");
                int cod_calle_dom_esp = dr.GetOrdinal("cod_calle_dom_esp");
                int nom_calle_dom_esp = dr.GetOrdinal("nom_calle_dom_esp");
                int nro_dom_esp = dr.GetOrdinal("nro_dom_esp");
                int piso_dpto_esp = dr.GetOrdinal("piso_dpto_esp");
                int ciudad_dom_esp = dr.GetOrdinal("ciudad_dom_esp");
                int provincia_dom_esp = dr.GetOrdinal("provincia_dom_esp");
                int pais_dom_esp = dr.GetOrdinal("pais_dom_esp");
                int cod_postal_dom_esp = dr.GetOrdinal("cod_postal_dom_esp");
                int fecha_cambio_domicilio = dr.GetOrdinal("fecha_cambio_domicilio");
                int fecha_exencion = dr.GetOrdinal("fecha_exencion");
                int fecha_vto_exencion = dr.GetOrdinal("fecha_vto_exencion");
                int causa_exencion = dr.GetOrdinal("causa_exencion");
                int fecha_ingreso = dr.GetOrdinal("fecha_ingreso");
                int emite_cedulon = dr.GetOrdinal("emite_cedulon");
                int cod_registro_auto = dr.GetOrdinal("cod_registro_auto");
                int responsable = dr.GetOrdinal("responsable");
                int porcentaje = dr.GetOrdinal("porcentaje");
                int sexo = dr.GetOrdinal("sexo");
                int cod_alta = dr.GetOrdinal("cod_alta");
                int cod_baja = dr.GetOrdinal("cod_baja");
                int debito_automatico = dr.GetOrdinal("debito_automatico");
                int nro_secuencia = dr.GetOrdinal("nro_secuencia");
                int cod_situacion_judicial = dr.GetOrdinal("cod_situacion_judicial");
                int codigo_cip_ant = dr.GetOrdinal("codigo_cip_ant");
                int codigo_acara = dr.GetOrdinal("codigo_acara");
                int nombre = dr.GetOrdinal("nombre");
                int cod_tipo_documento = dr.GetOrdinal("cod_tipo_documento");
                int nro_documento = dr.GetOrdinal("nro_documento");
                int cod_tipo_liquidacion = dr.GetOrdinal("cod_tipo_liquidacion");
                int clave_pago = dr.GetOrdinal("clave_pago");
                int monto = dr.GetOrdinal("monto");
                int email_envio_cedulon = dr.GetOrdinal("email_envio_cedulon");
                int telefono = dr.GetOrdinal("telefono");
                int celular = dr.GetOrdinal("celular");
                int fecha_cambio_radicacion = dr.GetOrdinal("fecha_cambio_radicacion");
                int cedulon_digital = dr.GetOrdinal("cedulon_digital");
                int usuario = dr.GetOrdinal("usuario");
                int usuariomodifica = dr.GetOrdinal("usuariomodifica");
                int fecha_modificacion = dr.GetOrdinal("fecha_modificacion");
                int clave_pago2 = dr.GetOrdinal("clave_pago2");
                int cuit = dr.GetOrdinal("cuit");
                int cuit_vecino_digital = dr.GetOrdinal("cuit_vecino_digital");
                int fecha_vecino_digital = dr.GetOrdinal("fecha_vecino_digital");
                int con_deuda = dr.GetOrdinal("con_deuda");
                int saldo_adeudado = dr.GetOrdinal("saldo_adeudado");
                int fecha_baja_real = dr.GetOrdinal("fecha_baja_real");
                int fecha_denuncia_vta = dr.GetOrdinal("fecha_denuncia_vta");
                while (dr.Read())
                {
                    obj = new Vehiculos();
                    if (!dr.IsDBNull(dominio)) { obj.dominio = dr.GetString(dominio); }
                    if (!dr.IsDBNull(marca)) { obj.marca = dr.GetString(marca); }
                    if (!dr.IsDBNull(modelo)) { obj.modelo = dr.GetString(modelo); }
                    if (!dr.IsDBNull(nacional)) { obj.nacional = dr.GetBoolean(nacional); }
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(codigo_vehiculo)) { obj.codigo_vehiculo = dr.GetInt32(codigo_vehiculo); }
                    if (!dr.IsDBNull(peso_cm3)) { obj.peso_cm3 = dr.GetFloat(peso_cm3); }
                    if (!dr.IsDBNull(fecha_cambio_dominio)) { obj.fecha_cambio_dominio = Convert.ToDateTime(dr.GetDateTime(fecha_cambio_dominio), culturaFecArgentina); }
                    if (!dr.IsDBNull(dominio_anterior)) { obj.dominio_anterior = dr.GetString(dominio_anterior); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = Convert.ToDateTime(dr.GetDateTime(fecha_alta), culturaFecArgentina); }
                    if (!dr.IsDBNull(tipo_alta)) { obj.tipo_alta = dr.GetBoolean(tipo_alta); }
                    if (!dr.IsDBNull(baja)) { obj.baja = dr.GetBoolean(baja); }
                    if (!dr.IsDBNull(fecha_baja)) { obj.fecha_baja = Convert.ToDateTime(dr.GetDateTime(fecha_baja), culturaFecArgentina); }
                    if (!dr.IsDBNull(tipo_baja)) { obj.tipo_baja = dr.GetInt32(tipo_baja); }
                    if (!dr.IsDBNull(per_ult)) { obj.per_ult = dr.GetString(per_ult); }
                    if (!dr.IsDBNull(codigo_cip)) { obj.codigo_cip = dr.GetString(codigo_cip); }
                    if (!dr.IsDBNull(variante)) { obj.variante = dr.GetString(variante); }
                    if (!dr.IsDBNull(exento)) { obj.exento = dr.GetBoolean(exento); }
                    if (!dr.IsDBNull(tributa_minimo)) { obj.tributa_minimo = dr.GetBoolean(tributa_minimo); }
                    if (!dr.IsDBNull(nro_motor)) { obj.nro_motor = dr.GetString(nro_motor); }
                    if (!dr.IsDBNull(cod_barrio_dom_esp)) { obj.cod_barrio_dom_esp = dr.GetInt32(cod_barrio_dom_esp); }
                    if (!dr.IsDBNull(nom_barrio_dom_esp)) { obj.nom_barrio_dom_esp = dr.GetString(nom_barrio_dom_esp); }
                    if (!dr.IsDBNull(cod_calle_dom_esp)) { obj.cod_calle_dom_esp = dr.GetInt32(cod_calle_dom_esp); }
                    if (!dr.IsDBNull(nom_calle_dom_esp)) { obj.nom_calle_dom_esp = dr.GetString(nom_calle_dom_esp); }
                    if (!dr.IsDBNull(nro_dom_esp)) { obj.nro_dom_esp = dr.GetInt32(nro_dom_esp); }
                    if (!dr.IsDBNull(piso_dpto_esp)) { obj.piso_dpto_esp = dr.GetString(piso_dpto_esp); }
                    if (!dr.IsDBNull(ciudad_dom_esp)) { obj.ciudad_dom_esp = dr.GetString(ciudad_dom_esp); }
                    if (!dr.IsDBNull(provincia_dom_esp)) { obj.provincia_dom_esp = dr.GetString(provincia_dom_esp); }
                    if (!dr.IsDBNull(pais_dom_esp)) { obj.pais_dom_esp = dr.GetString(pais_dom_esp); }
                    if (!dr.IsDBNull(cod_postal_dom_esp)) { obj.cod_postal_dom_esp = dr.GetString(cod_postal_dom_esp); }
                    if (!dr.IsDBNull(fecha_cambio_domicilio)) { obj.fecha_cambio_domicilio = dr.GetDateTime(fecha_cambio_domicilio); }
                    if (!dr.IsDBNull(fecha_exencion)) { obj.fecha_exencion = Convert.ToDateTime(dr.GetDateTime(fecha_exencion), culturaFecArgentina); }
                    if (!dr.IsDBNull(fecha_vto_exencion)) { obj.fecha_vto_exencion = Convert.ToDateTime(dr.GetDateTime(fecha_vto_exencion), culturaFecArgentina); }
                    if (!dr.IsDBNull(causa_exencion)) { obj.causa_exencion = dr.GetString(causa_exencion); }
                    if (!dr.IsDBNull(fecha_ingreso)) { obj.fecha_ingreso = Convert.ToDateTime(dr.GetDateTime(fecha_ingreso), culturaFecArgentina); }
                    if (!dr.IsDBNull(emite_cedulon)) { obj.emite_cedulon = dr.GetBoolean(emite_cedulon); }
                    if (!dr.IsDBNull(cod_registro_auto)) { obj.cod_registro_auto = dr.GetInt32(cod_registro_auto); }
                    if (!dr.IsDBNull(responsable)) { obj.responsable = dr.GetString(responsable); }
                    if (!dr.IsDBNull(porcentaje)) { obj.porcentaje = dr.GetString(porcentaje); }
                    if (!dr.IsDBNull(sexo)) { obj.sexo = dr.GetString(sexo); }
                    if (!dr.IsDBNull(cod_alta)) { obj.cod_alta = dr.GetInt32(cod_alta); }
                    if (!dr.IsDBNull(cod_baja)) { obj.cod_baja = dr.GetInt32(cod_baja); }
                    if (!dr.IsDBNull(debito_automatico)) { obj.debito_automatico = dr.GetBoolean(debito_automatico); }
                    if (!dr.IsDBNull(nro_secuencia)) { obj.nro_secuencia = dr.GetInt32(nro_secuencia); }
                    if (!dr.IsDBNull(cod_situacion_judicial)) { obj.cod_situacion_judicial = dr.GetInt32(cod_situacion_judicial); }
                    if (!dr.IsDBNull(codigo_cip_ant)) { obj.codigo_cip_ant = dr.GetString(codigo_cip_ant); }
                    if (!dr.IsDBNull(codigo_acara)) { obj.codigo_acara = dr.GetString(codigo_acara); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(cod_tipo_documento)) { obj.cod_tipo_documento = dr.GetInt32(cod_tipo_documento); }
                    if (!dr.IsDBNull(nro_documento)) { obj.nro_documento = dr.GetString(nro_documento); }
                    if (!dr.IsDBNull(cod_tipo_liquidacion)) { obj.cod_tipo_liquidacion = dr.GetInt32(cod_tipo_liquidacion); }
                    if (!dr.IsDBNull(clave_pago)) { obj.clave_pago = dr.GetString(clave_pago); }
                    if (!dr.IsDBNull(monto)) { obj.monto = dr.GetDecimal(monto); }
                    if (!dr.IsDBNull(email_envio_cedulon)) { obj.email_envio_cedulon = dr.GetString(email_envio_cedulon); }
                    if (!dr.IsDBNull(telefono)) { obj.telefono = dr.GetString(telefono); }
                    if (!dr.IsDBNull(celular)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(fecha_cambio_radicacion)) { obj.fecha_cambio_radicacion = dr.GetDateTime(fecha_cambio_radicacion); }
                    if (!dr.IsDBNull(cedulon_digital)) { obj.cedulon_digital = dr.GetInt16(cedulon_digital); }
                    if (!dr.IsDBNull(usuario)) { obj.usuario = dr.GetString(usuario); }
                    if (!dr.IsDBNull(usuariomodifica)) { obj.usuariomodifica = dr.GetString(usuariomodifica); }
                    if (!dr.IsDBNull(fecha_modificacion)) { obj.fecha_modificacion = Convert.ToDateTime(dr.GetDateTime(fecha_modificacion), culturaFecArgentina); }
                    if (!dr.IsDBNull(clave_pago2)) { obj.clave_pago2 = dr.GetString(clave_pago2); }
                    if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(cuit_vecino_digital)) { obj.cuit_vecino_digital = dr.GetString(cuit_vecino_digital); }
                    if (!dr.IsDBNull(fecha_vecino_digital)) { obj.fecha_vecino_digital = Convert.ToDateTime(dr.GetDateTime(fecha_vecino_digital), culturaFecArgentina); }
                    if (!dr.IsDBNull(con_deuda)) { obj.con_deuda = dr.GetInt16(con_deuda); }
                    if (!dr.IsDBNull(saldo_adeudado)) { obj.saldo_adeudado = dr.GetDecimal(saldo_adeudado); }
                    if (!dr.IsDBNull(fecha_baja_real)) { obj.fecha_baja_real = Convert.ToDateTime(dr.GetDateTime(fecha_baja_real), culturaFecArgentina); }
                    if (!dr.IsDBNull(fecha_denuncia_vta)) { obj.fecha_denuncia_vta = Convert.ToDateTime(dr.GetDateTime(fecha_denuncia_vta), culturaFecArgentina); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public async static Task<int> Count()
        {
            try
            {
                int count = 0;
                string sql = @"SELECT count(*) 
                               FROM Vehiculos (nolock)";
                //Where Baja=@baja";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    //cmd.Parameters.AddWithValue("@baja", baja);
                    await cmd.Connection.OpenAsync();
                    count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    return count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Vehiculos> read()
        {
            try
            {
                List<Vehiculos> lst = new List<Vehiculos>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Vehiculos (nolock)";
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
        public async static Task<List<Vehiculos>> GetAllPaginado(int registro_desde, int registro_hasta)
        {
            try
            {
                List<Vehiculos> lst = new List<Vehiculos>();
                string sql = @" SELECT *
                                FROM (
                                    SELECT ROW_NUMBER() OVER (ORDER BY dominio) AS RowNum, *
                                    FROM VEHICULOS (nolock)
                                ) AS tabla_numerada
                                WHERE 
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By Dominio";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@desde", registro_desde);
                    cmd.Parameters.AddWithValue("@hasta", registro_hasta);
                    await cmd.Connection.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async static Task<List<Vehiculos>> GetVehiculosPaginado(string buscarPor, string strParametro, int registro_desde, int registro_hasta)
        {
            bool busquedaSi = false;
            try
            {
                List<Vehiculos> lst = new List<Vehiculos>();
                string sql = @" SELECT *
                                FROM (
                                    SELECT ROW_NUMBER() OVER (ORDER BY dominio) AS RowNum, *
                                    FROM VEHICULOS (nolock)
                                ) AS tabla_numerada";
                //WHERE
                //RowNum BETWEEN @desde AND @hasta
                //ORDER By Dominio
                string sqlWhere = "";
                if (!string.IsNullOrEmpty(buscarPor))
                {
                    switch (buscarPor)
                    {
                        case "dominio":
                            sqlWhere = @" WHERE
                                dominio=@parametro AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By Dominio";
                            break;
                        case "cuit":
                            sqlWhere = @" WHERE
                                cuit=Convert(varchar(11),@parametro) AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By Dominio";
                            break;
                        case "titular":
                            sqlWhere = @" WHERE
                                nombre like @parametro + '%' AND
                                RowNum BETWEEN @desde AND @hasta
                                ORDER By Dominio";
                            break;
                        default:
                            break;
                    }
                }
                if (sqlWhere.Length > 0)
                {
                    busquedaSi = true;
                    sql += sqlWhere;
                }
                else
                {
                    busquedaSi = false;
                    sql += " WHERE RowNum BETWEEN @desde AND @hasta ORDER By Dominio";
                }
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@desde", registro_desde);
                    cmd.Parameters.AddWithValue("@hasta", registro_hasta);
                    if (busquedaSi)
                        cmd.Parameters.AddWithValue("@parametro", strParametro);
                    await cmd.Connection.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Vehiculos> GetAllActivos()
        {
            try
            {
                List<Vehiculos> lst = new List<Vehiculos>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Vehiculos (nolock) Where Baja=0";
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
        public static List<Vehiculos> GetAllBajas()
        {
            try
            {
                List<Vehiculos> lst = new List<Vehiculos>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Vehiculos Where Baja=1";
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
        public static Vehiculos GetAutoByDominio(string dominio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Vehiculos");
                sql.AppendLine("WHERE DOMINIO = @dominio");
                Vehiculos? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    obj = new Vehiculos();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@dominio", dominio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Vehiculos> lst = mapeo(dr);
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
        public static int insert(Vehiculos obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Vehiculos(");
                sql.AppendLine("DOMINIO");
                sql.AppendLine(", MARCA");
                sql.AppendLine(", MODELO");
                sql.AppendLine(", NACIONAL");
                sql.AppendLine(", ANIO");
                sql.AppendLine(", NRO_BAD");
                sql.AppendLine(", CODIGO_VEHICULO");
                sql.AppendLine(", PESO_CM3");
                //sql.AppendLine(", FECHA_CAMBIO_DOMINIO");
                //sql.AppendLine(", DOMINIO_ANTERIOR");
                sql.AppendLine(", FECHA_ALTA");
                sql.AppendLine(", TIPO_ALTA");
                sql.AppendLine(", BAJA");
                //sql.AppendLine(", FECHA_BAJA");
                //sql.AppendLine(", TIPO_BAJA");
                sql.AppendLine(", PER_ULT");
                sql.AppendLine(", CODIGO_CIP");
                sql.AppendLine(", VARIANTE");
                sql.AppendLine(", EXENTO");
                sql.AppendLine(", TRIBUTA_MINIMO");
                sql.AppendLine(", NRO_MOTOR");
                sql.AppendLine(", COD_BARRIO_DOM_ESP");
                sql.AppendLine(", NOM_BARRIO_DOM_ESP");
                sql.AppendLine(", COD_CALLE_DOM_ESP");
                sql.AppendLine(", NOM_CALLE_DOM_ESP");
                sql.AppendLine(", NRO_DOM_ESP");
                sql.AppendLine(", PISO_DPTO_ESP");
                sql.AppendLine(", CIUDAD_DOM_ESP");
                sql.AppendLine(", PROVINCIA_DOM_ESP");
                sql.AppendLine(", PAIS_DOM_ESP");
                sql.AppendLine(", COD_POSTAL_DOM_ESP");
                //sql.AppendLine(", fecha_cambio_domicilio");
                //sql.AppendLine(", fecha_exencion");
                //sql.AppendLine(", fecha_vto_exencion");
                //sql.AppendLine(", causa_exencion");
                sql.AppendLine(", fecha_ingreso");
                sql.AppendLine(", Emite_cedulon");
                sql.AppendLine(", Cod_registro_auto");
                sql.AppendLine(", Responsable");
                sql.AppendLine(", Porcentaje");
                sql.AppendLine(", Sexo");
                sql.AppendLine(", Cod_alta");
                sql.AppendLine(", Cod_baja");
                sql.AppendLine(", debito_automatico");
                //sql.AppendLine(", nro_secuencia");
                sql.AppendLine(", cod_situacion_judicial");
                //sql.AppendLine(", codigo_cip_ant");
                sql.AppendLine(", codigo_acara");
                sql.AppendLine(", nombre");
                sql.AppendLine(", cod_tipo_documento");
                sql.AppendLine(", nro_documento");
                sql.AppendLine(", cod_tipo_liquidacion");
                sql.AppendLine(", clave_pago");
                //sql.AppendLine(", monto");
                sql.AppendLine(", email_envio_cedulon");
                sql.AppendLine(", telefono");
                sql.AppendLine(", celular");
                //sql.AppendLine(", Fecha_cambio_radicacion");
                sql.AppendLine(", cedulon_digital");
                sql.AppendLine(", usuario");
                sql.AppendLine(", usuariomodifica");
                sql.AppendLine(", fecha_modificacion");
                //sql.AppendLine(", clave_pago2");
                sql.AppendLine(", CUIT");
                if (obj.cuit_vecino_digital.Length > 0)
                {
                    sql.AppendLine(", CUIT_VECINO_DIGITAL");
                    sql.AppendLine(", FECHA_VECINO_DIGITAL");
                }
                sql.AppendLine(", con_deuda");
                //sql.AppendLine(", saldo_adeudado");
                //sql.AppendLine(", Fecha_baja_real");
                //sql.AppendLine(", Fecha_denuncia_vta");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@DOMINIO");
                sql.AppendLine(", @MARCA");
                sql.AppendLine(", @MODELO");
                sql.AppendLine(", @NACIONAL");
                sql.AppendLine(", @ANIO");
                sql.AppendLine(", @NRO_BAD");
                sql.AppendLine(", @CODIGO_VEHICULO");
                sql.AppendLine(", @PESO_CM3");
                //sql.AppendLine(", @FECHA_CAMBIO_DOMINIO");
                //sql.AppendLine(", @DOMINIO_ANTERIOR");
                sql.AppendLine(", @FECHA_ALTA");
                sql.AppendLine(", @TIPO_ALTA");
                sql.AppendLine(", @BAJA");
                //sql.AppendLine(", @FECHA_BAJA");
                //sql.AppendLine(", @TIPO_BAJA");
                sql.AppendLine(", @PER_ULT");
                sql.AppendLine(", @CODIGO_CIP");
                sql.AppendLine(", @VARIANTE");
                sql.AppendLine(", @EXENTO");
                sql.AppendLine(", @TRIBUTA_MINIMO");
                sql.AppendLine(", @NRO_MOTOR");
                sql.AppendLine(", @COD_BARRIO_DOM_ESP");
                sql.AppendLine(", @NOM_BARRIO_DOM_ESP");
                sql.AppendLine(", @COD_CALLE_DOM_ESP");
                sql.AppendLine(", @NOM_CALLE_DOM_ESP");
                sql.AppendLine(", @NRO_DOM_ESP");
                sql.AppendLine(", @PISO_DPTO_ESP");
                sql.AppendLine(", @CIUDAD_DOM_ESP");
                sql.AppendLine(", @PROVINCIA_DOM_ESP");
                sql.AppendLine(", @PAIS_DOM_ESP");
                sql.AppendLine(", @COD_POSTAL_DOM_ESP");
                //sql.AppendLine(", @fecha_cambio_domicilio");
                //sql.AppendLine(", @fecha_exencion");
                //sql.AppendLine(", @fecha_vto_exencion");
                //sql.AppendLine(", @causa_exencion");
                sql.AppendLine(", @fecha_ingreso");
                sql.AppendLine(", @Emite_cedulon");
                sql.AppendLine(", @Cod_registro_auto");
                sql.AppendLine(", @Responsable");
                sql.AppendLine(", @Porcentaje");
                sql.AppendLine(", @Sexo");
                sql.AppendLine(", @Cod_alta");
                sql.AppendLine(", @Cod_baja");
                sql.AppendLine(", @debito_automatico");
                //sql.AppendLine(", @nro_secuencia");
                sql.AppendLine(", @cod_situacion_judicial");
                //sql.AppendLine(", @codigo_cip_ant");
                sql.AppendLine(", @codigo_acara");
                sql.AppendLine(", @nombre");
                sql.AppendLine(", @cod_tipo_documento");
                sql.AppendLine(", @nro_documento");
                sql.AppendLine(", @cod_tipo_liquidacion");
                sql.AppendLine(", @clave_pago");
                //sql.AppendLine(", @monto");
                sql.AppendLine(", @email_envio_cedulon");
                sql.AppendLine(", @telefono");
                sql.AppendLine(", @celular");
                //sql.AppendLine(", @Fecha_cambio_radicacion");
                sql.AppendLine(", @cedulon_digital");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @usuariomodifica");
                sql.AppendLine(", @fecha_modificacion");
                //sql.AppendLine(", @clave_pago2");
                sql.AppendLine(", @CUIT");
                if (obj.cuit_vecino_digital.Length > 0)
                {
                    sql.AppendLine(", @CUIT_VECINO_DIGITAL");
                    sql.AppendLine(", @FECHA_VECINO_DIGITAL");
                }
                sql.AppendLine(", @con_deuda");
                //sql.AppendLine(", @saldo_adeudado");
                //sql.AppendLine(", @Fecha_baja_real");
                //sql.AppendLine(", @Fecha_denuncia_vta");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DOMINIO", obj.dominio);
                    cmd.Parameters.AddWithValue("@MARCA", obj.marca);
                    cmd.Parameters.AddWithValue("@MODELO", obj.modelo);
                    cmd.Parameters.AddWithValue("@NACIONAL", obj.nacional);
                    cmd.Parameters.AddWithValue("@ANIO", obj.anio);
                    cmd.Parameters.AddWithValue("@NRO_BAD", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@CODIGO_VEHICULO", obj.codigo_vehiculo);
                    cmd.Parameters.AddWithValue("@PESO_CM3", obj.peso_cm3);
                    //cmd.Parameters.AddWithValue("@FECHA_CAMBIO_DOMINIO", obj.fecha_cambio_dominio);
                    //cmd.Parameters.AddWithValue("@DOMINIO_ANTERIOR", obj.dominio_anterior);                    
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", Convert.ToDateTime(obj.fecha_alta, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@TIPO_ALTA", obj.tipo_alta);
                    cmd.Parameters.AddWithValue("@BAJA", obj.baja);
                    //cmd.Parameters.AddWithValue("@FECHA_BAJA", obj.fecha_baja);
                    //cmd.Parameters.AddWithValue("@TIPO_BAJA", obj.tipo_baja);
                    cmd.Parameters.AddWithValue("@PER_ULT", obj.per_ult);
                    cmd.Parameters.AddWithValue("@CODIGO_CIP", obj.codigo_cip);
                    cmd.Parameters.AddWithValue("@VARIANTE", obj.variante);
                    cmd.Parameters.AddWithValue("@EXENTO", obj.exento);
                    cmd.Parameters.AddWithValue("@TRIBUTA_MINIMO", obj.tributa_minimo);
                    cmd.Parameters.AddWithValue("@NRO_MOTOR", obj.nro_motor);
                    cmd.Parameters.AddWithValue("@COD_BARRIO_DOM_ESP", obj.cod_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@NOM_BARRIO_DOM_ESP", obj.nom_barrio_dom_esp);
                    cmd.Parameters.AddWithValue("@COD_CALLE_DOM_ESP", obj.cod_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@NOM_CALLE_DOM_ESP", obj.nom_calle_dom_esp);
                    cmd.Parameters.AddWithValue("@NRO_DOM_ESP", obj.nro_dom_esp);
                    cmd.Parameters.AddWithValue("@PISO_DPTO_ESP", obj.piso_dpto_esp);
                    cmd.Parameters.AddWithValue("@CIUDAD_DOM_ESP", obj.ciudad_dom_esp);
                    cmd.Parameters.AddWithValue("@PROVINCIA_DOM_ESP", obj.provincia_dom_esp);
                    cmd.Parameters.AddWithValue("@PAIS_DOM_ESP", obj.pais_dom_esp);
                    cmd.Parameters.AddWithValue("@COD_POSTAL_DOM_ESP", obj.cod_postal_dom_esp);
                    //cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                    //cmd.Parameters.AddWithValue("@fecha_exencion", obj.fecha_exencion);
                    //cmd.Parameters.AddWithValue("@fecha_vto_exencion", obj.fecha_vto_exencion);
                    //cmd.Parameters.AddWithValue("@causa_exencion", obj.causa_exencion);
                    cmd.Parameters.AddWithValue("@fecha_ingreso", Convert.ToDateTime(obj.fecha_ingreso, culturaFecArgentina));
                    cmd.Parameters.AddWithValue("@Emite_cedulon", obj.emite_cedulon);
                    cmd.Parameters.AddWithValue("@Cod_registro_auto", obj.cod_registro_auto);
                    cmd.Parameters.AddWithValue("@Responsable", obj.responsable);
                    cmd.Parameters.AddWithValue("@Porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@Sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@Cod_alta", obj.cod_alta);
                    cmd.Parameters.AddWithValue("@Cod_baja", obj.cod_baja);
                    cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                    //cmd.Parameters.AddWithValue("@nro_secuencia", obj.nro_secuencia);
                    cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                    //cmd.Parameters.AddWithValue("@codigo_cip_ant", obj.codigo_cip_ant);
                    cmd.Parameters.AddWithValue("@codigo_acara", obj.codigo_acara);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@cod_tipo_documento", obj.cod_tipo_documento);
                    cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                    cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", obj.cod_tipo_liquidacion);
                    cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                    //cmd.Parameters.AddWithValue("@monto", obj.monto);
                    cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    //cmd.Parameters.AddWithValue("@Fecha_cambio_radicacion", obj.fecha_cambio_radicacion);
                    cmd.Parameters.AddWithValue("@cedulon_digital", obj.cedulon_digital);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@usuariomodifica", obj.usuariomodifica);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", Convert.ToDateTime(obj.fecha_modificacion, culturaFecArgentina));
                    //cmd.Parameters.AddWithValue("@clave_pago2", obj.clave_pago2);
                    cmd.Parameters.AddWithValue("@CUIT", obj.cuit);
                    if (obj.cuit_vecino_digital.Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@CUIT_VECINO_DIGITAL", obj.cuit_vecino_digital);
                        cmd.Parameters.AddWithValue("@FECHA_VECINO_DIGITAL", Convert.ToDateTime(obj.fecha_vecino_digital));
                    }
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    //cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    //cmd.Parameters.AddWithValue("@Fecha_baja_real", obj.fecha_baja_real);
                    //cmd.Parameters.AddWithValue("@Fecha_denuncia_vta", obj.fecha_denuncia_vta);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void update(Vehiculos obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Vehiculos SET");
                sql.AppendLine("MARCA=@MARCA");
                sql.AppendLine(", NACIONAL=@NACIONAL");
                sql.AppendLine(", ANIO=@ANIO");
                sql.AppendLine(", NRO_BAD=@NRO_BAD");
                sql.AppendLine(", CODIGO_VEHICULO=@CODIGO_VEHICULO");
                sql.AppendLine(", PESO_CM3=@PESO_CM3");
                sql.AppendLine(", PER_ULT=@PER_ULT");
                sql.AppendLine(", CODIGO_CIP=@CODIGO_CIP");
                sql.AppendLine(", VARIANTE=@VARIANTE");
                sql.AppendLine(", EXENTO=@EXENTO");
                sql.AppendLine(", TRIBUTA_MINIMO=@TRIBUTA_MINIMO");
                sql.AppendLine(", NRO_MOTOR=@NRO_MOTOR");
                sql.AppendLine(", Responsable=@Responsable");
                sql.AppendLine(", Porcentaje=@Porcentaje");
                sql.AppendLine(", Sexo=@Sexo");
                sql.AppendLine(", cod_tipo_liquidacion=@cod_tipo_liquidacion");
                if (obj.fecha_modificacion != null)
                {
                    sql.AppendLine(", usuariomodifica=@usuariomodifica");
                    sql.AppendLine(", fecha_modificacion=@fecha_modificacion");
                }
                sql.AppendLine(", CUIT=@CUIT");
                sql.AppendLine("WHERE");
                sql.AppendLine("DOMINIO=@DOMINIO");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DOMINIO", obj.dominio);
                    cmd.Parameters.AddWithValue("@MARCA", obj.marca);
                    cmd.Parameters.AddWithValue("@MODELO", obj.modelo);
                    cmd.Parameters.AddWithValue("@NACIONAL", obj.nacional);
                    cmd.Parameters.AddWithValue("@ANIO", obj.anio);
                    cmd.Parameters.AddWithValue("@NRO_BAD", obj.nro_bad);
                    cmd.Parameters.AddWithValue("@CODIGO_VEHICULO", obj.codigo_vehiculo);
                    cmd.Parameters.AddWithValue("@PESO_CM3", obj.peso_cm3);
                    cmd.Parameters.AddWithValue("@PER_ULT", obj.per_ult);
                    cmd.Parameters.AddWithValue("@CODIGO_CIP", obj.codigo_cip);
                    cmd.Parameters.AddWithValue("@VARIANTE", obj.variante);
                    cmd.Parameters.AddWithValue("@EXENTO", obj.exento);
                    cmd.Parameters.AddWithValue("@TRIBUTA_MINIMO", obj.tributa_minimo);
                    cmd.Parameters.AddWithValue("@NRO_MOTOR", obj.nro_motor);
                    cmd.Parameters.AddWithValue("@Responsable", obj.responsable);
                    cmd.Parameters.AddWithValue("@Porcentaje", obj.porcentaje);
                    cmd.Parameters.AddWithValue("@Sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", obj.cod_tipo_liquidacion);
                    if (obj.fecha_modificacion != null)
                    {
                        cmd.Parameters.AddWithValue("@usuariomodifica", obj.usuariomodifica);
                        cmd.Parameters.AddWithValue("@fecha_modificacion", Convert.ToDateTime(obj.fecha_modificacion, culturaFecArgentina));
                    }
                    cmd.Parameters.AddWithValue("@CUIT", obj.cuit);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void update(SqlConnection cn, SqlTransaction trx, Vehiculos obj)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Vehiculos SET");
                sql.AppendLine("MARCA=@MARCA");
                //sql.AppendLine(", MODELO=@MODELO");
                sql.AppendLine(", NACIONAL=@NACIONAL");
                sql.AppendLine(", ANIO=@ANIO");
                sql.AppendLine(", NRO_BAD=@NRO_BAD");
                sql.AppendLine(", CODIGO_VEHICULO=@CODIGO_VEHICULO");
                sql.AppendLine(", PESO_CM3=@PESO_CM3");
                //sql.AppendLine(", FECHA_CAMBIO_DOMINIO=@FECHA_CAMBIO_DOMINIO");
                //sql.AppendLine(", DOMINIO_ANTERIOR=@DOMINIO_ANTERIOR");
                //sql.AppendLine(", FECHA_ALTA=@FECHA_ALTA");
                //sql.AppendLine(", TIPO_ALTA=@TIPO_ALTA");
                //sql.AppendLine(", BAJA=@BAJA");
                //sql.AppendLine(", FECHA_BAJA=@FECHA_BAJA");
                //sql.AppendLine(", TIPO_BAJA=@TIPO_BAJA");
                sql.AppendLine(", PER_ULT=@PER_ULT");
                sql.AppendLine(", CODIGO_CIP=@CODIGO_CIP");
                sql.AppendLine(", VARIANTE=@VARIANTE");
                sql.AppendLine(", EXENTO=@EXENTO");
                sql.AppendLine(", TRIBUTA_MINIMO=@TRIBUTA_MINIMO");
                sql.AppendLine(", NRO_MOTOR=@NRO_MOTOR");
                //sql.AppendLine(", COD_BARRIO_DOM_ESP=@COD_BARRIO_DOM_ESP");
                //sql.AppendLine(", NOM_BARRIO_DOM_ESP=@NOM_BARRIO_DOM_ESP");
                //sql.AppendLine(", COD_CALLE_DOM_ESP=@COD_CALLE_DOM_ESP");
                //sql.AppendLine(", NOM_CALLE_DOM_ESP=@NOM_CALLE_DOM_ESP");
                //sql.AppendLine(", NRO_DOM_ESP=@NRO_DOM_ESP");
                //sql.AppendLine(", PISO_DPTO_ESP=@PISO_DPTO_ESP");
                //sql.AppendLine(", CIUDAD_DOM_ESP=@CIUDAD_DOM_ESP");
                //sql.AppendLine(", PROVINCIA_DOM_ESP=@PROVINCIA_DOM_ESP");
                //sql.AppendLine(", PAIS_DOM_ESP=@PAIS_DOM_ESP");
                //sql.AppendLine(", COD_POSTAL_DOM_ESP=@COD_POSTAL_DOM_ESP");
                //sql.AppendLine(", fecha_cambio_domicilio=@fecha_cambio_domicilio");
                //sql.AppendLine(", fecha_exencion=@fecha_exencion");
                //sql.AppendLine(", fecha_vto_exencion=@fecha_vto_exencion");
                //sql.AppendLine(", causa_exencion=@causa_exencion");
                //sql.AppendLine(", fecha_ingreso=@fecha_ingreso");
                //sql.AppendLine(", Emite_cedulon=@Emite_cedulon");
                //sql.AppendLine(", Cod_registro_auto=@Cod_registro_auto");
                sql.AppendLine(", Responsable=@Responsable");
                sql.AppendLine(", Porcentaje=@Porcentaje");
                sql.AppendLine(", Sexo=@Sexo");
                //sql.AppendLine(", Cod_alta=@Cod_alta");
                //sql.AppendLine(", Cod_baja=@Cod_baja");
                //sql.AppendLine(", debito_automatico=@debito_automatico");
                //sql.AppendLine(", nro_secuencia=@nro_secuencia");
                //sql.AppendLine(", cod_situacion_judicial=@cod_situacion_judicial");
                //sql.AppendLine(", codigo_cip_ant=@codigo_cip_ant");
                //sql.AppendLine(", codigo_acara=@codigo_acara");
                //sql.AppendLine(", nombre=@nombre");
                //sql.AppendLine(", cod_tipo_documento=@cod_tipo_documento");
                //sql.AppendLine(", nro_documento=@nro_documento");
                sql.AppendLine(", cod_tipo_liquidacion=@cod_tipo_liquidacion");
                //sql.AppendLine(", clave_pago=@clave_pago");
                //sql.AppendLine(", monto=@monto");
                //sql.AppendLine(", email_envio_cedulon=@email_envio_cedulon");
                //sql.AppendLine(", telefono=@telefono");
                //sql.AppendLine(", celular=@celular");
                //sql.AppendLine(", Fecha_cambio_radicacion=@Fecha_cambio_radicacion");
                //sql.AppendLine(", cedulon_digital=@cedulon_digital");
                //sql.AppendLine(", usuario=@usuario");
                if (obj.fecha_modificacion != null)
                {
                    sql.AppendLine(", usuariomodifica=@usuariomodifica");
                    sql.AppendLine(", fecha_modificacion=@fecha_modificacion");
                }
                //sql.AppendLine(", clave_pago2=@clave_pago2");
                sql.AppendLine(", CUIT=@CUIT");
                //sql.AppendLine(", CUIT_VECINO_DIGITAL=@CUIT_VECINO_DIGITAL");
                //sql.AppendLine(", FECHA_VECINO_DIGITAL=@FECHA_VECINO_DIGITAL");
                //sql.AppendLine(", con_deuda=@con_deuda");
                //sql.AppendLine(", saldo_adeudado=@saldo_adeudado");
                //sql.AppendLine(", Fecha_baja_real=@Fecha_baja_real");
                //sql.AppendLine(", Fecha_denuncia_vta=@Fecha_denuncia_vta");
                sql.AppendLine("WHERE");
                sql.AppendLine("DOMINIO=@DOMINIO");
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@DOMINIO", obj.dominio);
                cmd.Parameters.AddWithValue("@MARCA", obj.marca);
                cmd.Parameters.AddWithValue("@MODELO", obj.modelo);
                cmd.Parameters.AddWithValue("@NACIONAL", obj.nacional);
                cmd.Parameters.AddWithValue("@ANIO", obj.anio);
                cmd.Parameters.AddWithValue("@NRO_BAD", obj.nro_bad);
                cmd.Parameters.AddWithValue("@CODIGO_VEHICULO", obj.codigo_vehiculo);
                cmd.Parameters.AddWithValue("@PESO_CM3", obj.peso_cm3);
                //cmd.Parameters.AddWithValue("@FECHA_CAMBIO_DOMINIO", obj.fecha_cambio_dominio);
                //cmd.Parameters.AddWithValue("@DOMINIO_ANTERIOR", obj.dominio_anterior);
                //cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.fecha_alta);
                //cmd.Parameters.AddWithValue("@TIPO_ALTA", obj.tipo_alta);
                //cmd.Parameters.AddWithValue("@BAJA", obj.baja);
                //cmd.Parameters.AddWithValue("@FECHA_BAJA", obj.fecha_baja);
                //cmd.Parameters.AddWithValue("@TIPO_BAJA", obj.tipo_baja);
                cmd.Parameters.AddWithValue("@PER_ULT", obj.per_ult);
                cmd.Parameters.AddWithValue("@CODIGO_CIP", obj.codigo_cip);
                cmd.Parameters.AddWithValue("@VARIANTE", obj.variante);
                cmd.Parameters.AddWithValue("@EXENTO", obj.exento);
                cmd.Parameters.AddWithValue("@TRIBUTA_MINIMO", obj.tributa_minimo);
                cmd.Parameters.AddWithValue("@NRO_MOTOR", obj.nro_motor);
                //cmd.Parameters.AddWithValue("@COD_BARRIO_DOM_ESP", obj.cod_barrio_dom_esp);
                //cmd.Parameters.AddWithValue("@NOM_BARRIO_DOM_ESP", obj.nom_barrio_dom_esp);
                //cmd.Parameters.AddWithValue("@COD_CALLE_DOM_ESP", obj.cod_calle_dom_esp);
                //cmd.Parameters.AddWithValue("@NOM_CALLE_DOM_ESP", obj.nom_calle_dom_esp);
                //cmd.Parameters.AddWithValue("@NRO_DOM_ESP", obj.nro_dom_esp);
                //cmd.Parameters.AddWithValue("@PISO_DPTO_ESP", obj.piso_dpto_esp);
                //cmd.Parameters.AddWithValue("@CIUDAD_DOM_ESP", obj.ciudad_dom_esp);
                //cmd.Parameters.AddWithValue("@PROVINCIA_DOM_ESP", obj.provincia_dom_esp);
                //cmd.Parameters.AddWithValue("@PAIS_DOM_ESP", obj.pais_dom_esp);
                //cmd.Parameters.AddWithValue("@COD_POSTAL_DOM_ESP", obj.cod_postal_dom_esp);
                //cmd.Parameters.AddWithValue("@fecha_cambio_domicilio", obj.fecha_cambio_domicilio);
                //cmd.Parameters.AddWithValue("@fecha_exencion", obj.fecha_exencion);
                //cmd.Parameters.AddWithValue("@fecha_vto_exencion", obj.fecha_vto_exencion);
                //cmd.Parameters.AddWithValue("@causa_exencion", obj.causa_exencion);
                //cmd.Parameters.AddWithValue("@fecha_ingreso", obj.fecha_ingreso);
                //cmd.Parameters.AddWithValue("@Emite_cedulon", obj.emite_cedulon);
                //cmd.Parameters.AddWithValue("@Cod_registro_auto", obj.cod_registro_auto);
                cmd.Parameters.AddWithValue("@Responsable", obj.responsable);
                cmd.Parameters.AddWithValue("@Porcentaje", obj.porcentaje);
                cmd.Parameters.AddWithValue("@Sexo", obj.sexo);
                //cmd.Parameters.AddWithValue("@Cod_alta", obj.cod_alta);
                //cmd.Parameters.AddWithValue("@Cod_baja", obj.cod_baja);
                //cmd.Parameters.AddWithValue("@debito_automatico", obj.debito_automatico);
                //cmd.Parameters.AddWithValue("@nro_secuencia", obj.nro_secuencia);
                //cmd.Parameters.AddWithValue("@cod_situacion_judicial", obj.cod_situacion_judicial);
                //cmd.Parameters.AddWithValue("@codigo_cip_ant", obj.codigo_cip_ant);
                //cmd.Parameters.AddWithValue("@codigo_acara", obj.codigo_acara);
                //cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                //cmd.Parameters.AddWithValue("@cod_tipo_documento", obj.cod_tipo_documento);
                //cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                cmd.Parameters.AddWithValue("@cod_tipo_liquidacion", obj.cod_tipo_liquidacion);
                //cmd.Parameters.AddWithValue("@clave_pago", obj.clave_pago);
                //cmd.Parameters.AddWithValue("@monto", obj.monto);
                //cmd.Parameters.AddWithValue("@email_envio_cedulon", obj.email_envio_cedulon);
                //cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                //cmd.Parameters.AddWithValue("@celular", obj.celular);
                //cmd.Parameters.AddWithValue("@Fecha_cambio_radicacion", obj.fecha_cambio_radicacion);
                //cmd.Parameters.AddWithValue("@cedulon_digital", obj.cedulon_digital);
                //cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                if (obj.fecha_modificacion != null)
                {
                    cmd.Parameters.AddWithValue("@usuariomodifica", obj.usuariomodifica);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", Convert.ToDateTime(obj.fecha_modificacion, culturaFecArgentina));
                }
                //cmd.Parameters.AddWithValue("@clave_pago2", obj.clave_pago2);
                cmd.Parameters.AddWithValue("@CUIT", obj.cuit);
                //cmd.Parameters.AddWithValue("@CUIT_VECINO_DIGITAL", obj.cuit_vecino_digital);
                //cmd.Parameters.AddWithValue("@FECHA_VECINO_DIGITAL", obj.fecha_vecino_digital);
                //cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                //cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                //cmd.Parameters.AddWithValue("@Fecha_baja_real", obj.fecha_baja_real);
                //cmd.Parameters.AddWithValue("@Fecha_denuncia_vta", obj.fecha_denuncia_vta);
                cmd.Transaction = trx;
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void delete(SqlConnection cn, SqlTransaction trx, Vehiculos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Vehiculos ");
                sql.AppendLine("WHERE");
                sql.AppendLine("DOMINIO=@dominio");
                //
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@DOMINIO", obj.dominio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Combos
        public static List<Combo> Causa_baja_auto()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT Codigo=cod_causa,
                                        Causa=des_causa                                                
                                        FROM CAUSAS_BAJA_AUTOS
                                        ORDER BY cod_causa";
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
        public static List<Combo> Tipos_vehiculos()
        {
            try
            {
                List<Combo> lst = new List<Combo>();
                Combo obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select codigo_vehiculo, descripcion_vehiculo from TIPOS_VEHICULOS";
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
        public static List<Codigos_cip> CodigosCip(string marca, int anio)
        {
            try
            {
                string sql = @"SELECT  
                                   a.Marca, 
                                   a.modelo,
                                   a.Tipo,
                                   a.Variante,
                                   a.Codigo_cip,
                                   b.anio,
                                   b.base_imponible
                                FROM CODIGOS_CIP_ACARA a
                                JOIN CIP_BASES_IMPONIBLES_ACARA b on
                                a.codigo_cip=b.codigo_cip and
                                b.anio=@anio
                                WHERE  a.marca + ' ' + a.modelo  LIKE @nombre_aproximado
                                ORDER BY a.marca, a.tipo, a.variante, a.codigo_cip";
                List<Codigos_cip> lst = new List<Codigos_cip>();
                Codigos_cip obj;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@nombre_aproximado", marca + "%");
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Codigos_cip();
                            if (!dr.IsDBNull(0)) { obj.marca = Convert.ToString(dr.GetString(0)); }
                            if (!dr.IsDBNull(1)) { obj.modelo = Convert.ToString(dr.GetString(1)); }
                            if (!dr.IsDBNull(2)) { obj.tipo = Convert.ToString(dr.GetString(2)); }
                            if (!dr.IsDBNull(3)) { obj.variante = Convert.ToString(dr.GetString(3)); }
                            if (!dr.IsDBNull(4)) { obj.codigo_cip = Convert.ToString(dr.GetString(4)); }
                            if (!dr.IsDBNull(5)) { obj.anio = Convert.ToInt32(dr.GetInt32(5)); }
                            if (!dr.IsDBNull(5)) { obj.base_imponible = Convert.ToDecimal(dr.GetDecimal(6)); }
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
        public static List<Codigos_cip> CodigosCip(string marca)
        {
            try
            {
                string sql = @"SELECT  
                                   a.Marca, 
                                   a.modelo,
                                   a.Tipo,
                                   a.Variante,
                                   a.Codigo_cip,
                                   b.anio,
                                   b.base_imponible
                                FROM CODIGOS_CIP_ACARA a
                                JOIN CIP_BASES_IMPONIBLES_ACARA b on
                                a.codigo_cip=b.codigo_cip                                
                                WHERE  a.marca + ' ' + a.modelo LIKE @nombre_aproximado
                                ORDER BY a.marca, a.tipo, a.variante, a.codigo_cip";
                List<Codigos_cip> lst = new();
                Codigos_cip obj;
                using SqlConnection con = GetConnectionSIIMVA();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nombre_aproximado", marca + "%");
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj = new Codigos_cip();
                        if (!dr.IsDBNull(0)) { obj.marca = Convert.ToString(dr.GetString(0)); }
                        if (!dr.IsDBNull(1)) { obj.modelo = Convert.ToString(dr.GetString(1)); }
                        if (!dr.IsDBNull(2)) { obj.tipo = Convert.ToString(dr.GetString(2)); }
                        if (!dr.IsDBNull(3)) { obj.variante = Convert.ToString(dr.GetString(3)); }
                        if (!dr.IsDBNull(4)) { obj.codigo_cip = Convert.ToString(dr.GetString(4)); }
                        if (!dr.IsDBNull(5)) { obj.anio = Convert.ToInt32(dr.GetInt32(5)); }
                        if (!dr.IsDBNull(5)) { obj.base_imponible = Convert.ToDecimal(dr.GetDecimal(6)); }
                        lst.Add(obj);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Ver Dominio por Cuit y Actualiza Vecino Cumplidor
        public static async Task<List<Vehiculos>> VerDominiosxcuit(string strcuit)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"SELECT DOMINIO, MARCA, modelo, ANIO, 
                            nombre, FECHA_BAJA, nro_documento, 
                            CUIT, CUIT_VECINO_DIGITAL, 
                            con_deuda, saldo_adeudado
                            FROM VEHICULOS
                            WHERE CUIT=@cuit";

                List<Vehiculos> lst = new();
                Vehiculos? obj = null;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@cuit", strcuit);
                    await cmd.Connection.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    if (dr.HasRows)
                    {
                        int dominio = dr.GetOrdinal("dominio");
                        int marca = dr.GetOrdinal("marca");
                        int modelo = dr.GetOrdinal("modelo");
                        int anio = dr.GetOrdinal("anio");
                        int cuit = dr.GetOrdinal("cuit");
                        int cuit_vecino_digital = dr.GetOrdinal("cuit_vecino_digital");
                        int con_deuda = dr.GetOrdinal("con_deuda");
                        int saldo_adeudado = dr.GetOrdinal("saldo_adeudado");
                        while (dr.Read())
                        {
                            obj = new Vehiculos();
                            if (!dr.IsDBNull(dominio)) { obj.dominio = dr.GetString(dominio); }
                            if (!dr.IsDBNull(marca)) { obj.marca = dr.GetString(marca); }
                            if (!dr.IsDBNull(modelo)) { obj.modelo = dr.GetString(modelo); }
                            if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                            if (!dr.IsDBNull(cuit)) { obj.cuit = dr.GetString(cuit); }
                            if (!dr.IsDBNull(cuit_vecino_digital)) { obj.cuit_vecino_digital = dr.GetString(cuit_vecino_digital); }
                            if (!dr.IsDBNull(con_deuda)) { obj.con_deuda = dr.GetInt16(con_deuda); }
                            if (!dr.IsDBNull(saldo_adeudado)) { obj.saldo_adeudado = dr.GetDecimal(saldo_adeudado); }
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
        public static bool ActualizarVecinoCumplidor(string dominio, string periodo)
        {
            try
            {
                bool retorno = false;
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CALCULA_DEUDA_AUTOMOTORES_INDIVIDUAL";
                    cmd.Connection.OpenAsync();
                    cmd.Parameters.AddWithValue("@dominio", dominio);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.ExecuteNonQueryAsync();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        public static void Bajalogicavehiculo(string dominio, int cod_baja, string fecha_real_tramite)
        {
            try
            {
                DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine(@"UPDATE Vehiculos SET");
                //tengo que armar un case medio rebuscado
                //pq dependiendo el tipo de baja usa algunos datos
                //if Data_Auto.VehiculosFecha_Baja.IsNull = true then
                //begin
                //Data_Auto.VEHICULOSBAJA.Value       := True;
                //end;
                switch (cod_baja)
                {
                    case 630:
                    case 632:
                    case 635:
                    case 636:
                    case 637:
                        sql.AppendLine(@"baja=1,");
                        sql.AppendLine(@"tipo_baja=9,");
                        sql.AppendLine(@"fecha_baja=GetDate(),");
                        sql.AppendLine(@"exento=1");
                        if (fecha_real_tramite.Length > 0)
                            sql.AppendLine(@",fecha_baja_real=" + Convert.ToDateTime(fecha_real_tramite, culturaFecArgentina));
                        break;
                    case 638:
                    case 639:
                    case 640:
                        sql.AppendLine(@"baja=1,");
                        sql.AppendLine(@"tipo_baja=9,");
                        sql.AppendLine(@"exento=1,");
                        sql.AppendLine(@"fecha_baja=GetDate()");
                        break;
                    case 888:
                        sql.AppendLine(@"baja=1,");
                        sql.AppendLine(@"tipo_baja=8,");
                        sql.AppendLine(@"fecha_baja=GetDate(),");
                        sql.AppendLine(@"exento=1");
                        if (fecha_real_tramite.Length > 0)
                        {
                            sql.AppendLine(@",fecha_cambio_radicacion='" + Convert.ToDateTime(fecha_real_tramite, culturaFecArgentina) + "'");
                            sql.AppendLine(@",fecha_baja_real='" + Convert.ToDateTime(fecha_real_tramite, culturaFecArgentina) + "'");
                        }
                        break;
                    case 889:
                        sql.AppendLine(@"tipo_baja=7,");
                        sql.AppendLine(@"fecha_denuncia_vta='" + Convert.ToDateTime(fecha_real_tramite, culturaFecArgentina) + "'");
                        sql.AppendLine(@",exento=1");
                        break;
                    case 890:
                        sql.AppendLine(@"baja=1,");
                        sql.AppendLine(@"tipo_baja=9,");
                        sql.AppendLine(@"fecha_baja=GetDate(),");
                        sql.AppendLine(@"exento=True");
                        if (fecha_real_tramite.Length > 0)
                            sql.AppendLine(@",fecha_baja_real='" + Convert.ToDateTime(fecha_real_tramite, culturaFecArgentina) + "'");
                        break;
                    default:
                        sql.AppendLine(@"baja=1,");
                        sql.AppendLine(@"tipo_baja=" + cod_baja);
                        sql.AppendLine(@",fecha_baja=GetDate()");
                        break;
                }
                sql.AppendLine("WHERE");
                sql.AppendLine("dominio=@dominio");
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@dominio", dominio);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                //return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Cambio_dominio(string nuevo_dominio, string dominio_ant)
        {
            try
            {
                string strSQL = string.Empty;
                strSQL = @"UPDATE VEHICULOS
                            SET dominio=@nuevo_dominio,
                                dominio_anterior=@dominio_ant,
                                fecha_cambio_dominio=Getdate()
                          WHERE dominio=@dominio_ant";
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@nuevo_dominio", nuevo_dominio);
                    cmd.Parameters.AddWithValue("@dominio_ant", dominio_ant);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

