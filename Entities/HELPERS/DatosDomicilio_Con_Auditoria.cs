namespace Web_Api_Inm.Entities.HELPERS
{
    public class DatosDomicilio_Con_Auditoria
    {
        public DatosDomicilio datosDomicilio{ get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public DatosDomicilio_Con_Auditoria()
        {
            datosDomicilio = new DatosDomicilio();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}