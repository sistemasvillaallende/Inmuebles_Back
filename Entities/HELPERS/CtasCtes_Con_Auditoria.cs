namespace Web_Api_Inm.Entities.HELPERS
{
    public class CtasCtes_Con_Auditoria
    {
        public string dominio { get; set; }
        public List<Ctasctes_automotores> lstCtasTes { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }

        public CtasCtes_Con_Auditoria()
        {
            dominio = string.Empty;
            lstCtasTes = new List<Ctasctes_automotores>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
