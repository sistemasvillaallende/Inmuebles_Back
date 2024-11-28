namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosBaldio
    {
        public string nombre { get; set; }
        public int nro_bad { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public string calle { get; set; }
        public int nro { get; set; }
        public string barrio { get; set; }
        public string cod_postal { get; set; }
        public string domicilio { get; set; }
        public string ciudad { get; set; }
        public string provincia_dom_esp { get; set; }
        public string pais_dom_esp { get; set; }

        public DatosBaldio()
        {
            nombre = string.Empty;
            nro_bad = 0;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            calle = string.Empty;
            nro = 0;
            barrio = string.Empty;
            cod_postal = string.Empty;
            domicilio = string.Empty;
            ciudad = string.Empty;
            provincia_dom_esp = string.Empty;
            pais_dom_esp = string.Empty;
        }


    }
}