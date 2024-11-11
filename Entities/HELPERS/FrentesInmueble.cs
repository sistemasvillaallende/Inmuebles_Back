namespace Web_Api_Inm.Entities.HELPERS
{
    public class FrentesInmueble
    {
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public int nro_frente { get; set; }
        public int cod_calle { get; set; }
        public int nro_domicilio { get; set; }
        public float metros_frente { get; set; }
        public int cod_zona { get; set; }


        public FrentesInmueble()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            nro_frente = 0;
            cod_calle = 0;
            nro_domicilio = 0;
            metros_frente = 0.0f;
            cod_zona = 0;
        }


    }
}
