using System.Data;
using System.Data.SqlClient;
using Web_Api_Inm.Entities.HELPERS;

namespace Web_Api_Inm.Entities
{

    public class Debitos_inmueble : DALBase
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string nombre { get; set; }
        public string nro_documento { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime? fecha_baja { get; set; }
        public int cod_tarjeta { get; set; }
        public string nro_tarjeta { get; set; }
        public string pri_per_debitado { get; set; }
        public string ultimo_per_deb { get; set; }
        public string? per_backup { get; set; }
        public string? per_pendiente_debitar { get; set; }
        public string? id_paypertic { get; set; }

        public Debitos_inmueble()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            nombre = string.Empty;
            nro_documento = string.Empty;
            telefono = string.Empty;
            fecha_alta = DateTime.Now;
            fecha_baja = null;
            nro_tarjeta = string.Empty;
            pri_per_debitado = string.Empty;
            ultimo_per_deb = string.Empty;
            per_backup = null;
            per_pendiente_debitar = null;
            id_paypertic = string.Empty;

        }



        public static DatosDebitoInm GetDebitoByInm(int cir, int sec, int man, int par, int p_h)
        {
            DatosDebitoInm debito = null;

            try
            {
                string strSQL = @"
             SELECT 
                circunscripcion, 
                seccion, 
                manzana, 
                parcela, 
                p_h,
                nombre,
                nro_documento,
                telefono,
                fecha_alta,
                fecha_baja,
                cod_tarjeta,
                pri_per_debitado,
                ultimo_per_deb
            FROM  DEBITOS_INMUEBLES
            WHERE  circunscripcion=@cir AND
                                        seccion=@sec AND
                                        manzana=@man AND
                                        parcela=@par AND
                                        p_h=@p_h";

                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@cir", cir);
                    cmd.Parameters.AddWithValue("@sec", sec);
                    cmd.Parameters.AddWithValue("@man", man);
                    cmd.Parameters.AddWithValue("@par", par);
                    cmd.Parameters.AddWithValue("@p_h", p_h);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            {
                                debito = new DatosDebitoInm();

                                if (!dr.IsDBNull(0)) { debito.circunscripcion =dr.GetInt32(0); }
                                if (!dr.IsDBNull(1)) { debito.seccion =dr.GetInt32(1); }
                                if (!dr.IsDBNull(2)) { debito.manzana =dr.GetInt32(2); }
                                if (!dr.IsDBNull(3)) { debito.parcela =dr.GetInt32(3); }
                                if (!dr.IsDBNull(4)) { debito.p_h =dr.GetInt32(4); }
                                if (!dr.IsDBNull(5)) { debito.nombre = Convert.ToString(dr.GetString(5)); }
                                if (!dr.IsDBNull(6)) { debito.nro_documento = dr.GetString(6); }
                                if (!dr.IsDBNull(7)) { debito.telefono = dr.GetString(7); }
                                if (!dr.IsDBNull(8)) { debito.fecha_alta = dr.GetDateTime(8); }
                                if (!dr.IsDBNull(9)) { debito.fecha_baja = dr.GetDateTime(8); }
                                if (!dr.IsDBNull(10)) { debito.cod_tarjeta = dr.GetInt32(10); }
                                if (!dr.IsDBNull(11)) { debito.pri_per_debitado = dr.GetString(11); }
                                if (!dr.IsDBNull(12)) { debito.ultimo_per_deb = dr.GetString(12); }

                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener información del inmueble", ex);
            }

            return debito;


        }

        public static void InsertDebito(Debitos_inmueble obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"
            INSERT INTO DEBITOS_INMUEBLES (
                circunscripcion, 
                seccion, 
                manzana, 
                parcela, 
                p_h,
                nombre,
                nro_documento,
                telefono,
                fecha_alta,
                fecha_baja,
                cod_tarjeta,
                nro_tarjeta,
                pri_per_debitado,
                ultimo_per_deb,
                per_backup,
                per_pendiente_debitar,
                id_paypertic
            ) VALUES (
                @circunscripcion, 
                @seccion, 
                @manzana, 
                @parcela, 
                @p_h,
                @nombre,
                @nro_documento,
                @telefono,
                @fecha_alta,
                @fecha_baja,
                @cod_tarjeta,
                @nro_tarjeta,
                @pri_per_debitado,
                @ultimo_per_deb,
                @per_backup,
                @per_pendiente_debitar,
                @id_paypertic
            );";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                cmd.Parameters.AddWithValue("@nro_tarjeta", obj.nro_tarjeta);
                cmd.Parameters.AddWithValue("@pri_per_debitado", obj.pri_per_debitado);
                cmd.Parameters.AddWithValue("@ultimo_per_deb", obj.ultimo_per_deb);
                cmd.Parameters.AddWithValue("@per_backup", obj.per_backup ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@per_pendiente_debitar", obj.per_pendiente_debitar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_paypertic", obj.id_paypertic);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar nuevo débito", ex);
            }
        }


        public static void UpdateDebito(Debitos_inmueble obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string query = @"
            UPDATE DEBITOS_INMUEBLES
            SET 
                nombre = @nombre,
                nro_documento = @nro_documento,
                telefono = @telefono,
                fecha_alta = @fecha_alta,
                fecha_baja = @fecha_baja,
                cod_tarjeta = @cod_tarjeta,
                nro_tarjeta = @nro_tarjeta,
                pri_per_debitado = @pri_per_debitado,
                ultimo_per_deb = @ultimo_per_deb,
                per_backup = @per_backup,
                per_pendiente_debitar = @per_pendiente_debitar,
                id_paypertic = @id_paypertic
                WHERE  circunscripcion=@cir AND
                                        seccion=@sec AND
                                        manzana=@man AND
                                        parcela=@par AND
                                        p_h=@p_h ";

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = trx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@cir", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@sec", obj.seccion);
                    cmd.Parameters.AddWithValue("@man", obj.manzana);
                    cmd.Parameters.AddWithValue("@par", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@nro_documento", obj.nro_documento);
                    cmd.Parameters.AddWithValue("@telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod_tarjeta", obj.cod_tarjeta);
                    cmd.Parameters.AddWithValue("@nro_tarjeta", obj.nro_tarjeta);
                    cmd.Parameters.AddWithValue("@pri_per_debitado", obj.pri_per_debitado);
                    cmd.Parameters.AddWithValue("@ultimo_per_deb", obj.ultimo_per_deb);
                    cmd.Parameters.AddWithValue("@per_backup", obj.per_backup ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@per_pendiente_debitar", obj.per_pendiente_debitar ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_paypertic", obj.id_paypertic);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el débito", ex);
            }
        }


        public static void DeleteDebito(int cir, int sec, int man, int par, int p_h, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string query = @"
                               DELETE FROM DEBITOS_INMUEBLES
                               WHERE  circunscripcion=@cir AND
                                        seccion=@sec AND
                                        manzana=@man AND
                                        parcela=@par AND
                                        p_h=@p_h ";

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
                throw new Exception("Error al eliminar debito automatico", ex);
            }
        }


        public static void UpdateInmuebleDebito(int cir, int sec, int man, int par, int p_h, bool valor, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string query = @"
                          UPDATE INMUEBLES
                          SET 
                              debito_automatico = @debito_automatico 
                          WHERE  circunscripcion=@cir AND
                                        seccion=@sec AND
                                        manzana=@man AND
                                        parcela=@par AND
                                        p_h=@p_h";

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
                    cmd.Parameters.AddWithValue("@debito_automatico", valor);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el débito en el inmueble", ex);
            }
        }


    }
}

