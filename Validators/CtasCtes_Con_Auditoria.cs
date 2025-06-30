using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Validators;


public class CtasCtesConAuditoriaValidator : AbstractValidator<CtasCtes_Con_Auditoria>
{
    public CtasCtesConAuditoriaValidator()
    {
        RuleFor(x => x.cir).InclusiveBetween(0, int.MaxValue).When(x => x.cir != 0);
        RuleFor(x => x.sec).InclusiveBetween(0, int.MaxValue).When(x => x.sec != 0);
        RuleFor(x => x.man).InclusiveBetween(0, int.MaxValue).When(x => x.man != 0);
        RuleFor(x => x.par).InclusiveBetween(0, int.MaxValue).When(x => x.par != 0);
        RuleFor(x => x.p_h).InclusiveBetween(0, int.MaxValue).When(x => x.p_h != 0);

        RuleForEach(x => x.lstCtastes)
            .SetValidator(new CtasctesInmueblesValidator())
            .When(x => x.lstCtastes != null && x.lstCtastes.Count > 0);
        /*
        RuleFor(x => x.auditoria)
            .SetValidator(new AuditoriaValidator())
            .When(x => x.auditoria != null);
        */
      
    }
}