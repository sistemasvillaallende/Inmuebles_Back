namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosDomicilio
    {
        public string nom_calle_dom_esp { get; set; }
        public int cod_calle_dom_esp { get; set; }
        public string piso_dpto_esp { get; set; }
        public int cod_barrio_dom_esp { get; set; }
        public string nom_barrio_dom_esp { get; set; }
        public string ciudad_dom_esp { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }
        public string cod_postal { get; set; }
        public string email_envio_cedulon { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string cuit_ocupante { get; set; }
        public DateTime? fecha_cambio_domicilio { get; set; }
        public int nro_bad { get; set; }
        public int nro_dom_esp  { get; set; }

        public DatosDomicilio()
        {
            nom_calle_dom_esp = string.Empty;
            cod_calle_dom_esp = 0;
            piso_dpto_esp = string.Empty;
            cod_barrio_dom_esp = 0;
            nom_barrio_dom_esp = string.Empty;
            ciudad_dom_esp = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
            cod_postal = string.Empty;
            email_envio_cedulon = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            cuit_ocupante = string.Empty;
            fecha_cambio_domicilio = null;
            nro_bad = 0;
            nro_dom_esp =0;
        }
    }
}