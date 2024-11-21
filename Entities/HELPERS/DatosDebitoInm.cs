namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosDebitoInm
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
        public string pri_per_debitado { get; set; }
        public string ultimo_per_deb { get; set; }

        public DatosDebitoInm()
        {
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            nombre = String.Empty;
            nro_documento = String.Empty;
            telefono = String.Empty;
            fecha_alta = DateTime.Now;
            fecha_baja = null;
            cod_tarjeta = 0;
            pri_per_debitado = String.Empty;
            ultimo_per_deb = String.Empty;

        }
    }
}