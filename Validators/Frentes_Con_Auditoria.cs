using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;


public class Frentes_Con_AuditoriaValidator : AbstractValidator<Frentes_Con_Auditoria>
{
    public Frentes_Con_AuditoriaValidator()
    {
        RuleFor(x => x.frente)
            .NotNull().WithMessage("El objeto 'frente' no puede ser nulo.")
            .SetValidator(new FrentesInmuebleValidator());

        RuleFor(x => x.auditoria)
            .NotNull().WithMessage("El objeto 'auditoria' no puede ser nulo.");
        // .SetValidator(new AuditoriaValidator()); // si existe un validador para Auditoria
    }
}
