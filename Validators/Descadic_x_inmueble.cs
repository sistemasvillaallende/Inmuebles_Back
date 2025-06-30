using FluentValidation;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Validators;


public class Descadic_x_inmuebleValidator : AbstractValidator<Descadic_x_inmueble>
{
    public Descadic_x_inmuebleValidator()
    {
        When(x => x.circunscripcion != 0, () => RuleFor(x => x.circunscripcion).GreaterThanOrEqualTo(0));
        When(x => x.seccion != 0, () => RuleFor(x => x.seccion).GreaterThanOrEqualTo(0));
        When(x => x.manzana != 0, () => RuleFor(x => x.manzana).GreaterThanOrEqualTo(0));
        When(x => x.parcela != 0, () => RuleFor(x => x.parcela).GreaterThanOrEqualTo(0));
        When(x => x.p_h != 0, () => RuleFor(x => x.p_h).GreaterThanOrEqualTo(0));
        When(x => x.cod_concepto_inmueble != 0, () => RuleFor(x => x.cod_concepto_inmueble).GreaterThanOrEqualTo(0));
        When(x => x.nro_decreto != 0, () => RuleFor(x => x.nro_decreto).GreaterThanOrEqualTo(0));
        When(x => x.activo != 0, () => RuleFor(x => x.activo).GreaterThanOrEqualTo((short)0));
        When(x => x.anio_desde != 0, () => RuleFor(x => x.anio_desde).GreaterThanOrEqualTo(0));
        When(x => x.anio_hasta != 0, () => RuleFor(x => x.anio_hasta).GreaterThanOrEqualTo(0));

        When(x => x.porcentaje != 0, () => RuleFor(x => x.porcentaje).GreaterThanOrEqualTo(0));
        When(x => x.monto != 0, () => RuleFor(x => x.monto).GreaterThanOrEqualTo(0));

        When(x => !string.IsNullOrWhiteSpace(x.des_concepto_inmueble), () =>
            RuleFor(x => x.des_concepto_inmueble).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.observaciones), () =>
            RuleFor(x => x.observaciones).NotEmpty());

        // Fecha tipo DateTime asumimos que ya es válida si se parseó correctamente (no se valida formato)
        // Si necesitas validar que no sean fechas del pasado o futuro, lo podemos agregar
        /*
        When(x => x.objAuditoria != null, () =>
            RuleFor(x => x.objAuditoria)
            .SetValidator(new AuditoriaValidator())
            .When(x => x.objAuditoria != null));
        */
    }
}
