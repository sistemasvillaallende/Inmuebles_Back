namespace Web_Api_Inm.Entities.HELPERS
{
    public class Zonas
    {
        public int cod_zona { get; set; }
        public string nom_zona { get; set; }
        public decimal tasa_basica_edificado { get; set; }
        public decimal excedente_edificado { get; set; }
        public decimal tasa_basica_baldio { get; set; }
        public decimal excedente_baldio { get; set; }


        public Zonas()
        {
            cod_zona = 0;
            nom_zona = string.Empty;
            tasa_basica_edificado = 0;
            excedente_edificado = 0;
            tasa_basica_baldio = 0;
            excedente_baldio = 0;
        }


    }
}
