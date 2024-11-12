namespace Web_Api_Inm.Entities.HELPERS
{
    public class Frentes_Con_Auditoria
    {
        public FrentesInmueble frente { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public Frentes_Con_Auditoria()
        {
            frente = new FrentesInmueble();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}