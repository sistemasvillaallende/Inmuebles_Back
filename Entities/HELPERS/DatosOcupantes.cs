namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosOcupantes
    {

        public string ocupante { get; set; }
        public int nro_bad { get; set; }
        public string nombre { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }


        public DatosOcupantes()
        {
            ocupante = String.Empty;
            nro_bad = 0;
            nombre = String.Empty;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;

        }
    }
}