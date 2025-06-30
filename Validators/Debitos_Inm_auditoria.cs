using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Validators;


public class DebitosInmAuditoriaValidator : AbstractValidator<Debitos_Inm_auditoria>
{
    public DebitosInmAuditoriaValidator()
    {
        RuleFor(x => x.debito)
            .SetValidator(new DebitosInmuebleValidator())
            .When(x => x.debito != null);

        RuleFor(x => x.auditoria)
            .SetValidator(new AuditoriaValidator())
            .When(x => x.auditoria != null);
    }
}