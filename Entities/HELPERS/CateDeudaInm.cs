namespace Web_Api_Inm.Entities.HELPERS
{
    public class CateDeudaInm
    {
        public int cod_categoria { get; set; }
        public string des_categoria { get; set; }
        public int id_subRubro { get; set; }
        public int tipo_deuda { get; set; }
        public CateDeudaInm()
        {
            cod_categoria = 0;
            des_categoria = string.Empty;
            id_subRubro = 0;
            tipo_deuda = 0;

        }


    }
}