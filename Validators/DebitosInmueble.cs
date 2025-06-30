using FluentValidation;
using Web_Api_Inm.Entities;

public class DebitosInmuebleValidator : AbstractValidator<Debitos_inmueble>
{
    public DebitosInmuebleValidator()
    {
        When(x => x.circunscripcion != 0, () => RuleFor(x => x.circunscripcion).GreaterThanOrEqualTo(0));
        When(x => x.seccion != 0, () => RuleFor(x => x.seccion).GreaterThanOrEqualTo(0));
        When(x => x.manzana != 0, () => RuleFor(x => x.manzana).GreaterThanOrEqualTo(0));
        When(x => x.parcela != 0, () => RuleFor(x => x.parcela).GreaterThanOrEqualTo(0));
        When(x => x.p_h != 0, () => RuleFor(x => x.p_h).GreaterThanOrEqualTo(0));
        When(x => x.cod_tarjeta != 0, () => RuleFor(x => x.cod_tarjeta).GreaterThanOrEqualTo(0));

        When(x => !string.IsNullOrWhiteSpace(x.nombre), () =>
            RuleFor(x => x.nombre).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.nro_documento), () =>
            RuleFor(x => x.nro_documento).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.telefono), () =>
            RuleFor(x => x.telefono).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.nro_tarjeta), () =>
            RuleFor(x => x.nro_tarjeta).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.pri_per_debitado), () =>
            RuleFor(x => x.pri_per_debitado).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.ultimo_per_deb), () =>
            RuleFor(x => x.ultimo_per_deb).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.per_backup), () =>
            RuleFor(x => x.per_backup).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.per_pendiente_debitar), () =>
            RuleFor(x => x.per_pendiente_debitar).NotEmpty());

        When(x => !string.IsNullOrWhiteSpace(x.id_paypertic), () =>
            RuleFor(x => x.id_paypertic).NotEmpty());

        // Fechas no se validan aquí, asumimos que ya vienen correctamente como DateTime o DateTime?
    }
}