namespace Web_Api_Inm.Entities
{
    public class Barrios
    {
        public int cod_barrio { get; set; }
        public string nom_barrio { get; set; }
        public Int16 BarrioCerrado{ get; set; }
        public Barrios()
        {
            cod_barrio = 0;
            nom_barrio = string.Empty;
           // BarrioCerrado = false;
           BarrioCerrado = 0;
        }


    }
}
