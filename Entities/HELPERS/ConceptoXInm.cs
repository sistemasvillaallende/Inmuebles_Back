namespace Web_Api_Inm.Entities.HELPERS
{
    public class ConceptoXInm
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public ConceptoXInm()
        {
            codigo = 0;
            descripcion = string.Empty;
            tipo = string.Empty;
        }


    }
}
