using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace
{
    public class Persona : DALBase
    {
        public int nro_bad { get; set; }
        public bool interno { get; set; }
        public bool persona { get; set; }
        public bool contribuyente { get; set; }
        public string tipo_instit { get; set; }
        public string nombre { get; set; }
        public string tip_doc { get; set; }
        public string nro_doc { get; set; }
        public int cod_calle { get; set; }
        public int nro_dom { get; set; }
        public int cod_barrio { get; set; }
        public int cod_postal { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public int cod_nivel_vida { get; set; }
        public int cod_vip { get; set; }
        public int codigo_actividad { get; set; }
        public string telefono { get; set; }
        public string e_mail { get; set; }
        public int nro_contrib { get; set; }
        public string piso_dpto { get; set; }
        public string nombre_calle { get; set; }
        public string nombre_barrio { get; set; }
        public string titulo { get; set; }
        public string cuit { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_alta { get; set; }
        public int id_tip_doc { get; set; }
        public string cod_postal_arg { get; set; }
        public string celular { get; set; }
        public string usuario { get; set; }
        public string subsistema { get; set; }

        public Persona()
        {
            nro_bad = 0;
            interno = false;
            persona = false;
            contribuyente = false;
            tipo_instit = string.empty;
            nombre = string.Empty;
            tip_doc = string.Empty;
            nro_doc = string.Empty;
            cod_calle = 0;
            nro_dom = 0;
            cod_barrio = 0;
            cod_postal = 0;
            localidad = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            cod_nivel_vida = 0;
            cod_vip = 0;
            codigo_actividad = 0;
            telefono = string.Empty;
            e_mail = string.Empty;
            nro_contrib = 0;
            piso_dpto = string.Empty;
            nombre_calle = string.Empty;
            nombre_barrio = string.Empty;
            titulo = string.Empty;
            cuit = string.Empty;
            sexo = string.Empty;
            fecha_alta = DateTime.Now;
            id_tip_doc = 0;
            cod_postal_arg = string.Empty;
            celular = string.Empty;
            usuario = string.Empty;
            subsistema = string.Empty;
        }

        private static List<Persona> mapeo(SqlDataReader dr)
        {
            List<Persona> lst = new List<Persona>();
            Persona obj;
            if (dr.HasRows)
            {
                int nro_bad = dr.GetOrdinal("nro_bad");
                int interno = dr.GetOrdinal("interno");
                int persona = dr.GetOrdinal("persona");
                int contribuyente = dr.GetOrdinal("contribuyente");
                int tipo_instit = dr.GetOrdinal("tipo_instit");
                int nombre = dr.GetOrdinal("nombre");
                int tip_doc = dr.GetOrdinal("tip_doc");
                int nro_doc = dr.GetOrdinal("nro_doc");
                int cod_calle = dr.GetOrdinal("cod_calle");
                int nro_dom = dr.GetOrdinal("nro_dom");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int localidad = dr.GetOrdinal("localidad");
                int provincia = dr.GetOrdinal("provincia");
                int pais = dr.GetOrdinal("pais");
                int cod_nivel_vida = dr.GetOrdinal("cod_nivel_vida");
                int cod_vip = dr.GetOrdinal("cod_vip");
                int codigo_actividad = dr.GetOrdinal("codigo_actividad");
                int telefono = dr.GetOrdinal("telefono");
                int e_mail = dr.GetOrdinal("e_mail");
                int nro_contrib = dr.GetOrdinal("nro_contrib");
                int piso_dpto = dr.GetOrdinal("piso_dpto");
                int nombre_calle = dr.GetOrdinal("nombre_calle");
                int nombre_barrio = dr.GetOrdinal("nombre_barrio");
                int titulo = dr.GetOrdinal("titulo");
                int cuit = dr.GetOrdinal("cuit");
                int sexo = dr.GetOrdinal("sexo");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int id_tip_doc = dr.GetOrdinal("id_tip_doc");
                int cod_postal_arg = dr.GetOrdinal("cod_postal_arg");
                int celular = dr.GetOrdinal("celular");
                int usuario = dr.GetOrdinal("usuario");
                int subsistema = dr.GetOrdinal("subsistema");



                while (dr.Read())
                {
                    obj = new Persona();
                    if (!dr.IsDBNull(NRO_BAD)) { obj.NRO_BAD = dr.GetInt32(NRO_BAD); }
                    if (!dr.IsDBNull(INTERNO)) { obj.INTERNO = dr.GetBoolean(INTERNO); }
                    if (!dr.IsDBNull(PERSONA)) { obj.PERSONA = dr.GetBoolean(PERSONA); }
                    if (!dr.IsDBNull(CONTRIBUYENTE)) { obj.CONTRIBUYENTE = dr.GetBoolean(CONTRIBUYENTE); }
                    if (!dr.IsDBNull(TIPO_INSTIT)) { obj.TIPO_INSTIT = dr.GetString(TIPO_INSTIT); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(TIP_DOC)) { obj.TIP_DOC = dr.GetString(TIP_DOC); }
                    if (!dr.IsDBNull(NRO_DOC)) { obj.NRO_DOC = dr.GetString(NRO_DOC); }
                    if (!dr.IsDBNull(COD_CALLE)) { obj.COD_CALLE = dr.GetInt32(COD_CALLE); }
                    if (!dr.IsDBNull(NRO_DOM)) { obj.NRO_DOM = dr.GetInt32(NRO_DOM); }
                    if (!dr.IsDBNull(COD_BARRIO)) { obj.COD_BARRIO = dr.GetInt32(COD_BARRIO); }
                    if (!dr.IsDBNull(COD_POSTAL)) { obj.COD_POSTAL = dr.GetInt32(COD_POSTAL); }
                    if (!dr.IsDBNull(LOCALIDAD)) { obj.LOCALIDAD = dr.GetString(LOCALIDAD); }
                    if (!dr.IsDBNull(PROVINCIA)) { obj.PROVINCIA = dr.GetString(PROVINCIA); }
                    if (!dr.IsDBNull(PAIS)) { obj.PAIS = dr.GetString(PAIS); }
                    if (!dr.IsDBNull(COD_NIVEL_VIDA)) { obj.COD_NIVEL_VIDA = dr.GetInt32(COD_NIVEL_VIDA); }
                    if (!dr.IsDBNull(COD_VIP)) { obj.COD_VIP = dr.GetInt32(COD_VIP); }
                    if (!dr.IsDBNull(CODIGO_ACTIVIDAD)) { obj.CODIGO_ACTIVIDAD = dr.GetInt32(CODIGO_ACTIVIDAD); }
                    if (!dr.IsDBNull(TELEFONO)) { obj.TELEFONO = dr.GetString(TELEFONO); }
                    if (!dr.IsDBNull(E_MAIL)) { obj.E_MAIL = dr.GetString(E_MAIL); }
                    if (!dr.IsDBNull(NRO_CONTRIB)) { obj.NRO_CONTRIB = dr.GetInt32(NRO_CONTRIB); }
                    if (!dr.IsDBNull(PISO_DPTO)) { obj.PISO_DPTO = dr.GetString(PISO_DPTO); }
                    if (!dr.IsDBNull(NOMBRE_CALLE)) { obj.NOMBRE_CALLE = dr.GetString(NOMBRE_CALLE); }
                    if (!dr.IsDBNull(NOMBRE_BARRIO)) { obj.NOMBRE_BARRIO = dr.GetString(NOMBRE_BARRIO); }
                    if (!dr.IsDBNull(TITULO)) { obj.TITULO = dr.GetString(TITULO); }
                    if (!dr.IsDBNull(CUIT)) { obj.CUIT = dr.GetString(CUIT); }
                    if (!dr.IsDBNull(SEXO)) { obj.SEXO = dr.GetString(SEXO); }
                    if (!dr.IsDBNull(FECHA_ALTA)) { obj.FECHA_ALTA = dr.GetDateTime(FECHA_ALTA); }
                    if (!dr.IsDBNull(ID_TIP_DOC)) { obj.ID_TIP_DOC = dr.GetInt32(ID_TIP_DOC); }
                    if (!dr.IsDBNull(COD_POSTAL_ARG)) { obj.COD_POSTAL_ARG = dr.GetString(COD_POSTAL_ARG); }
                    if (!dr.IsDBNull(CELULAR)) { obj.CELULAR = dr.GetString(CELULAR); }
                    if (!dr.IsDBNull(USUARIO)) { obj.USUARIO = dr.GetString(USUARIO); }
                    if (!dr.IsDBNull(SUBSISTEMA)) { obj.SUBSISTEMA = dr.GetString(SUBSISTEMA); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Persona> read()
        {
            try
            {
                List<Persona> lst = new List<Persona>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Badecinmuebles";
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

        public static Persona getByPk(
        int NRO_BAD)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Badecinmuebles WHERE");
                sql.AppendLine("NRO_BAD = @NRO_BAD");
                Persona obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_BAD", NRO_BAD);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Persona> lst = mapeo(dr);
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

        public static int insert(Persona obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Badecinmuebles(");
                sql.AppendLine("INTERNO");
                sql.AppendLine(", PERSONA");
                sql.AppendLine(", CONTRIBUYENTE");
                sql.AppendLine(", TIPO_INSTIT");
                sql.AppendLine(", NOMBRE");
                sql.AppendLine(", TIP_DOC");
                sql.AppendLine(", NRO_DOC");
                sql.AppendLine(", COD_CALLE");
                sql.AppendLine(", NRO_DOM");
                sql.AppendLine(", COD_BARRIO");
                sql.AppendLine(", COD_POSTAL");
                sql.AppendLine(", LOCALIDAD");
                sql.AppendLine(", PROVINCIA");
                sql.AppendLine(", PAIS");
                sql.AppendLine(", COD_NIVEL_VIDA");
                sql.AppendLine(", COD_VIP");
                sql.AppendLine(", CODIGO_ACTIVIDAD");
                sql.AppendLine(", TELEFONO");
                sql.AppendLine(", E_MAIL");
                sql.AppendLine(", NRO_CONTRIB");
                sql.AppendLine(", PISO_DPTO");
                sql.AppendLine(", NOMBRE_CALLE");
                sql.AppendLine(", NOMBRE_BARRIO");
                sql.AppendLine(", TITULO");
                sql.AppendLine(", CUIT");
                sql.AppendLine(", SEXO");
                sql.AppendLine(", FECHA_ALTA");
                sql.AppendLine(", ID_TIP_DOC");
                sql.AppendLine(", COD_POSTAL_ARG");
                sql.AppendLine(", CELULAR");
                sql.AppendLine(", USUARIO");
                sql.AppendLine(", SUBSISTEMA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@INTERNO");
                sql.AppendLine(", @PERSONA");
                sql.AppendLine(", @CONTRIBUYENTE");
                sql.AppendLine(", @TIPO_INSTIT");
                sql.AppendLine(", @NOMBRE");
                sql.AppendLine(", @TIP_DOC");
                sql.AppendLine(", @NRO_DOC");
                sql.AppendLine(", @COD_CALLE");
                sql.AppendLine(", @NRO_DOM");
                sql.AppendLine(", @COD_BARRIO");
                sql.AppendLine(", @COD_POSTAL");
                sql.AppendLine(", @LOCALIDAD");
                sql.AppendLine(", @PROVINCIA");
                sql.AppendLine(", @PAIS");
                sql.AppendLine(", @COD_NIVEL_VIDA");
                sql.AppendLine(", @COD_VIP");
                sql.AppendLine(", @CODIGO_ACTIVIDAD");
                sql.AppendLine(", @TELEFONO");
                sql.AppendLine(", @E_MAIL");
                sql.AppendLine(", @NRO_CONTRIB");
                sql.AppendLine(", @PISO_DPTO");
                sql.AppendLine(", @NOMBRE_CALLE");
                sql.AppendLine(", @NOMBRE_BARRIO");
                sql.AppendLine(", @TITULO");
                sql.AppendLine(", @CUIT");
                sql.AppendLine(", @SEXO");
                sql.AppendLine(", @FECHA_ALTA");
                sql.AppendLine(", @ID_TIP_DOC");
                sql.AppendLine(", @COD_POSTAL_ARG");
                sql.AppendLine(", @CELULAR");
                sql.AppendLine(", @USUARIO");
                sql.AppendLine(", @SUBSISTEMA");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@INTERNO", obj.INTERNO);
                    cmd.Parameters.AddWithValue("@PERSONA", obj.PERSONA);
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", obj.CONTRIBUYENTE);
                    cmd.Parameters.AddWithValue("@TIPO_INSTIT", obj.TIPO_INSTIT);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@TIP_DOC", obj.TIP_DOC);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.NRO_DOC);
                    cmd.Parameters.AddWithValue("@COD_CALLE", obj.COD_CALLE);
                    cmd.Parameters.AddWithValue("@NRO_DOM", obj.NRO_DOM);
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.COD_BARRIO);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.COD_POSTAL);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.LOCALIDAD);
                    cmd.Parameters.AddWithValue("@PROVINCIA", obj.PROVINCIA);
                    cmd.Parameters.AddWithValue("@PAIS", obj.PAIS);
                    cmd.Parameters.AddWithValue("@COD_NIVEL_VIDA", obj.COD_NIVEL_VIDA);
                    cmd.Parameters.AddWithValue("@COD_VIP", obj.COD_VIP);
                    cmd.Parameters.AddWithValue("@CODIGO_ACTIVIDAD", obj.CODIGO_ACTIVIDAD);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.TELEFONO);
                    cmd.Parameters.AddWithValue("@E_MAIL", obj.E_MAIL);
                    cmd.Parameters.AddWithValue("@NRO_CONTRIB", obj.NRO_CONTRIB);
                    cmd.Parameters.AddWithValue("@PISO_DPTO", obj.PISO_DPTO);
                    cmd.Parameters.AddWithValue("@NOMBRE_CALLE", obj.NOMBRE_CALLE);
                    cmd.Parameters.AddWithValue("@NOMBRE_BARRIO", obj.NOMBRE_BARRIO);
                    cmd.Parameters.AddWithValue("@TITULO", obj.TITULO);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@SEXO", obj.SEXO);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.FECHA_ALTA);
                    cmd.Parameters.AddWithValue("@ID_TIP_DOC", obj.ID_TIP_DOC);
                    cmd.Parameters.AddWithValue("@COD_POSTAL_ARG", obj.COD_POSTAL_ARG);
                    cmd.Parameters.AddWithValue("@CELULAR", obj.CELULAR);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.USUARIO);
                    cmd.Parameters.AddWithValue("@SUBSISTEMA", obj.SUBSISTEMA);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Persona obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Badecinmuebles SET");
                sql.AppendLine("INTERNO=@INTERNO");
                sql.AppendLine(", PERSONA=@PERSONA");
                sql.AppendLine(", CONTRIBUYENTE=@CONTRIBUYENTE");
                sql.AppendLine(", TIPO_INSTIT=@TIPO_INSTIT");
                sql.AppendLine(", NOMBRE=@NOMBRE");
                sql.AppendLine(", TIP_DOC=@TIP_DOC");
                sql.AppendLine(", NRO_DOC=@NRO_DOC");
                sql.AppendLine(", COD_CALLE=@COD_CALLE");
                sql.AppendLine(", NRO_DOM=@NRO_DOM");
                sql.AppendLine(", COD_BARRIO=@COD_BARRIO");
                sql.AppendLine(", COD_POSTAL=@COD_POSTAL");
                sql.AppendLine(", LOCALIDAD=@LOCALIDAD");
                sql.AppendLine(", PROVINCIA=@PROVINCIA");
                sql.AppendLine(", PAIS=@PAIS");
                sql.AppendLine(", COD_NIVEL_VIDA=@COD_NIVEL_VIDA");
                sql.AppendLine(", COD_VIP=@COD_VIP");
                sql.AppendLine(", CODIGO_ACTIVIDAD=@CODIGO_ACTIVIDAD");
                sql.AppendLine(", TELEFONO=@TELEFONO");
                sql.AppendLine(", E_MAIL=@E_MAIL");
                sql.AppendLine(", NRO_CONTRIB=@NRO_CONTRIB");
                sql.AppendLine(", PISO_DPTO=@PISO_DPTO");
                sql.AppendLine(", NOMBRE_CALLE=@NOMBRE_CALLE");
                sql.AppendLine(", NOMBRE_BARRIO=@NOMBRE_BARRIO");
                sql.AppendLine(", TITULO=@TITULO");
                sql.AppendLine(", CUIT=@CUIT");
                sql.AppendLine(", SEXO=@SEXO");
                sql.AppendLine(", FECHA_ALTA=@FECHA_ALTA");
                sql.AppendLine(", ID_TIP_DOC=@ID_TIP_DOC");
                sql.AppendLine(", COD_POSTAL_ARG=@COD_POSTAL_ARG");
                sql.AppendLine(", CELULAR=@CELULAR");
                sql.AppendLine(", USUARIO=@USUARIO");
                sql.AppendLine(", SUBSISTEMA=@SUBSISTEMA");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_BAD=@NRO_BAD");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@INTERNO", obj.INTERNO);
                    cmd.Parameters.AddWithValue("@PERSONA", obj.PERSONA);
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", obj.CONTRIBUYENTE);
                    cmd.Parameters.AddWithValue("@TIPO_INSTIT", obj.TIPO_INSTIT);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@TIP_DOC", obj.TIP_DOC);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.NRO_DOC);
                    cmd.Parameters.AddWithValue("@COD_CALLE", obj.COD_CALLE);
                    cmd.Parameters.AddWithValue("@NRO_DOM", obj.NRO_DOM);
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.COD_BARRIO);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.COD_POSTAL);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.LOCALIDAD);
                    cmd.Parameters.AddWithValue("@PROVINCIA", obj.PROVINCIA);
                    cmd.Parameters.AddWithValue("@PAIS", obj.PAIS);
                    cmd.Parameters.AddWithValue("@COD_NIVEL_VIDA", obj.COD_NIVEL_VIDA);
                    cmd.Parameters.AddWithValue("@COD_VIP", obj.COD_VIP);
                    cmd.Parameters.AddWithValue("@CODIGO_ACTIVIDAD", obj.CODIGO_ACTIVIDAD);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.TELEFONO);
                    cmd.Parameters.AddWithValue("@E_MAIL", obj.E_MAIL);
                    cmd.Parameters.AddWithValue("@NRO_CONTRIB", obj.NRO_CONTRIB);
                    cmd.Parameters.AddWithValue("@PISO_DPTO", obj.PISO_DPTO);
                    cmd.Parameters.AddWithValue("@NOMBRE_CALLE", obj.NOMBRE_CALLE);
                    cmd.Parameters.AddWithValue("@NOMBRE_BARRIO", obj.NOMBRE_BARRIO);
                    cmd.Parameters.AddWithValue("@TITULO", obj.TITULO);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@SEXO", obj.SEXO);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.FECHA_ALTA);
                    cmd.Parameters.AddWithValue("@ID_TIP_DOC", obj.ID_TIP_DOC);
                    cmd.Parameters.AddWithValue("@COD_POSTAL_ARG", obj.COD_POSTAL_ARG);
                    cmd.Parameters.AddWithValue("@CELULAR", obj.CELULAR);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.USUARIO);
                    cmd.Parameters.AddWithValue("@SUBSISTEMA", obj.SUBSISTEMA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Persona obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Badecinmuebles ");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_BAD=@NRO_BAD");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_BAD", obj.NRO_BAD);
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

