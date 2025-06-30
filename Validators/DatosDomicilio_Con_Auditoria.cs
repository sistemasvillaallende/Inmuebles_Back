using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;

public class DatosDomicilio_Con_AuditoriaValidator : AbstractValidator<DatosDomicilio_Con_Auditoria>
{
    public DatosDomicilio_Con_AuditoriaValidator()
    {
        RuleFor(x => x.datosDomicilio)
            .NotNull().WithMessage("Debe especificar los datos del domicilio.")
            .SetValidator(new DatosDomicilioValidator());

        RuleFor(x => x.auditoria)
            .NotNull().WithMessage("Debe especificar los datos de auditoría.");
        // Si tenés un validador para AUDITORIA.Auditoria podés agregar:
        // .SetValidator(new AuditoriaValidator());
    }
}
