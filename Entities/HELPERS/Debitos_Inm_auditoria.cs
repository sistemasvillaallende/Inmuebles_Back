namespace Web_Api_Inm.Entities.HELPERS
{
    public class Debitos_Inm_auditoria
    {
    
        public Debitos_inmueble debito { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }  

        public Debitos_Inm_auditoria() { 
            
            debito = new Debitos_inmueble();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}