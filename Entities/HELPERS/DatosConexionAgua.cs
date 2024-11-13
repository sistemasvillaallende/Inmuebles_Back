namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosConexionAgua
    {
        public string nombre { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string nom_calle { get; set; }
        public int nro_dom_pf { get; set; }
        public string nom_barrio { get; set; }
        public string manzana_oficial { get; set; }
        public string lote_oficial { get; set; }
        public float superficie { get; set; }
        public string domicilio { get; set; }
        public int dia_actual { get; set; }
        public string mes_actual { get; set; }
        public int anio_actual { get; set; }

        public DatosConexionAgua()
        {
            nombre = string.Empty;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            nom_calle = string.Empty;
            nro_dom_pf = 0;
            nom_barrio = string.Empty;
            manzana_oficial = string.Empty;
            lote_oficial = string.Empty;
            superficie = 0f;
            domicilio = string.Empty;
            dia_actual = 0;
            mes_actual = string.Empty;
            anio_actual = 0;
        }
    }
}
