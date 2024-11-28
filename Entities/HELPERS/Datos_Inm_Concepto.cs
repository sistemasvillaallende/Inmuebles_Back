namespace Web_Api_Inm.Entities.HELPERS
{

    public class Datos_Inm_Concepto
    {
        public int cod_concepto_inmueble { get; set; }
        public string des_concepto_inmueble { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public decimal porcentaje { get; set; }
        public decimal monto { get; set; }
        public string nom_calle { get; set; }
        public int nro_dom_pf { get; set; }
        public int nro_bad { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_alta_registro { get; set; }
        public int anio_desde { get; set; }
        public int anio_hasta { get; set; }

        public Datos_Inm_Concepto(){

            cod_concepto_inmueble = 0;
            des_concepto_inmueble = string.Empty;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            porcentaje = 0m;
            monto = 0m;
            nom_calle = string.Empty;
            nro_dom_pf = 0;
            nro_bad = 0;
            nombre = string.Empty;
            activo = false;
            fecha_alta_registro = null;
            anio_desde = 0;
            anio_hasta = 0;

    }
}

}