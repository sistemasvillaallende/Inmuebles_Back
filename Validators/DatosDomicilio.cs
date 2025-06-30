using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;

public class DatosDomicilioValidator : AbstractValidator<DatosDomicilio>
{
    public DatosDomicilioValidator()
    {
        RuleFor(x => x.nom_calle_dom_esp)
            .NotEmpty().WithMessage("El nombre de la calle es obligatorio.");

        RuleFor(x => x.cod_calle_dom_esp)
            .GreaterThan(0).WithMessage("Debe seleccionar un código de calle válido.");

        RuleFor(x => x.nro_dom_esp)
            .GreaterThan(0).WithMessage("Debe indicar un número de domicilio válido.");

        RuleFor(x => x.cod_barrio_dom_esp)
            .GreaterThan(0).WithMessage("Debe seleccionar un código de barrio válido.");

        RuleFor(x => x.nom_barrio_dom_esp)
            .NotEmpty().WithMessage("El nombre del barrio es obligatorio.");

        RuleFor(x => x.ciudad_dom_esp)
            .NotEmpty().WithMessage("La ciudad es obligatoria.");

        RuleFor(x => x.provincia_dom_esp)
            .NotEmpty().WithMessage("La provincia es obligatoria.");

        RuleFor(x => x.pais_dom_esp)
            .NotEmpty().WithMessage("El país es obligatorio.");

        RuleFor(x => x.cod_postal)
            .NotEmpty().WithMessage("El código postal es obligatorio.")
            .Matches(@"^\d{4,10}$").WithMessage("El código postal debe ser numérico y de entre 4 y 10 dígitos.");

        RuleFor(x => x.email_envio_cedulon)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.email_envio_cedulon))
            .WithMessage("El email ingresado no es válido.");

        RuleFor(x => x.telefono)
            .MaximumLength(20).WithMessage("El teléfono no debe superar los 20 caracteres.");

        RuleFor(x => x.celular)
            .MaximumLength(20).WithMessage("El celular no debe superar los 20 caracteres.");

        RuleFor(x => x.cuit_ocupante)
            .Matches(@"^\d{11}$").When(x => !string.IsNullOrEmpty(x.cuit_ocupante))
            .WithMessage("El CUIT del ocupante debe tener 11 dígitos numéricos.");

        RuleFor(x => x.nro_bad)
            .GreaterThanOrEqualTo(0).WithMessage("El número BAD debe ser 0 o mayor.");
    }
}
