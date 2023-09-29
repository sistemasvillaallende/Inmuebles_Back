namespace Web_Api_Inm.Entities.HELPERS
{
    public class CtasCtes_Con_Auditoria
    {
        public int cir { get; set; }
        public int sec { get; set; }
        public int man { get; set; }
        public int par { get; set; }
        public int p_h { get; set; }
        public List<Ctasctes_inmuebles> lstCtastes { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public CtasCtes_Con_Auditoria()
        {
            cir = 0;
            sec = 0;
            man = 0;
            par = 0;
            p_h = 0;
            lstCtastes = new List<Ctasctes_inmuebles>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
