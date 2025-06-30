using FluentValidation;
using Web_Api_Inm.Entities.HELPERS;

public class FrentesInmuebleValidator : AbstractValidator<FrentesInmueble>
{
    public FrentesInmuebleValidator()
    {
        RuleFor(x => x.circunscripcion)
            .GreaterThanOrEqualTo(0).WithMessage("La circunscripción debe ser mayor o igual a 0.");

        RuleFor(x => x.seccion)
            .GreaterThanOrEqualTo(0).WithMessage("La sección debe ser mayor o igual a 0.");

        RuleFor(x => x.manzana)
            .GreaterThanOrEqualTo(0).WithMessage("La manzana debe ser mayor o igual a 0.");

        RuleFor(x => x.parcela)
            .GreaterThanOrEqualTo(0).WithMessage("La parcela debe ser mayor o igual a 0.");

        RuleFor(x => x.p_h)
            .GreaterThanOrEqualTo(0).WithMessage("El valor de p_h debe ser mayor o igual a 0.");

        RuleFor(x => x.nro_frente)
            .GreaterThanOrEqualTo(0).WithMessage("El número de frente debe ser mayor o igual a 0.");

        RuleFor(x => x.cod_calle)
            .GreaterThan(0).WithMessage("Debe especificarse un código de calle válido.");

        RuleFor(x => x.nro_domicilio)
            .GreaterThan(0).WithMessage("Debe especificarse un número de domicilio válido.");

        RuleFor(x => x.metros_frente)
            .GreaterThan(0).WithMessage("Los metros de frente deben ser mayores a 0.");

        RuleFor(x => x.cod_zona)
            .GreaterThanOrEqualTo(0).WithMessage("El código de zona debe ser mayor o igual a 0.");
    }
}
