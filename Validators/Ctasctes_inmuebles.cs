using FluentValidation;
using Web_Api_Inm;

public class CtasctesInmueblesValidator : AbstractValidator<Ctasctes_inmuebles>
{
    public CtasctesInmueblesValidator()
    {
        RuleFor(x => x.tipo_transaccion).InclusiveBetween(0, int.MaxValue).When(x => x.tipo_transaccion != 0);
        RuleFor(x => x.nro_transaccion).InclusiveBetween(0, int.MaxValue).When(x => x.nro_transaccion != 0);
        RuleFor(x => x.circunscripcion).InclusiveBetween(0, int.MaxValue).When(x => x.circunscripcion != 0);
        RuleFor(x => x.seccion).InclusiveBetween(0, int.MaxValue).When(x => x.seccion != 0);
        RuleFor(x => x.manzana).InclusiveBetween(0, int.MaxValue).When(x => x.manzana != 0);
        RuleFor(x => x.parcela).InclusiveBetween(0, int.MaxValue).When(x => x.parcela != 0);
        RuleFor(x => x.p_h).InclusiveBetween(0, int.MaxValue).When(x => x.p_h != 0);

        RuleFor(x => x.fecha_transaccion).Must(BeAValidDate).When(x => x.fecha_transaccion.HasValue);
        RuleFor(x => x.periodo).MaximumLength(10).When(x => !string.IsNullOrEmpty(x.periodo));

        RuleFor(x => x.nro_pago_parcial).GreaterThanOrEqualTo(0).When(x => x.nro_pago_parcial != 0);
        RuleFor(x => x.monto_original).GreaterThanOrEqualTo(0).When(x => x.monto_original != 0);
        RuleFor(x => x.nro_plan).GreaterThan(0).When(x => x.nro_plan.HasValue);
        RuleFor(x => x.debe).GreaterThanOrEqualTo(0).When(x => x.debe != 0);
        RuleFor(x => x.haber).GreaterThanOrEqualTo(0).When(x => x.haber != 0);
        RuleFor(x => x.categoria_deuda).GreaterThanOrEqualTo(0).When(x => x.categoria_deuda != 0);
        RuleFor(x => x.nro_procuracion).GreaterThan(0).When(x => x.nro_procuracion.HasValue);
        RuleFor(x => x.vencimiento).Must(BeAValidDate).When(x => x.vencimiento.HasValue);
        RuleFor(x => x.nro_cedulon).GreaterThanOrEqualTo(0).When(x => x.nro_cedulon != 0);
        RuleFor(x => x.monto_pagado).GreaterThanOrEqualTo(0).When(x => x.monto_pagado != 0);
        RuleFor(x => x.recargo).GreaterThanOrEqualTo(0).When(x => x.recargo != 0);
        RuleFor(x => x.honorarios).GreaterThanOrEqualTo(0).When(x => x.honorarios != 0);
        RuleFor(x => x.iva_hons).GreaterThanOrEqualTo(0).When(x => x.iva_hons != 0);
        RuleFor(x => x.tipo_deuda).InclusiveBetween((short)0, short.MaxValue).When(x => x.tipo_deuda != 0);
        RuleFor(x => x.decreto).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.decreto));
        RuleFor(x => x.observaciones).MaximumLength(255).When(x => !string.IsNullOrEmpty(x.observaciones));
        RuleFor(x => x.nro_cedulon_paypertic).GreaterThanOrEqualTo(0).When(x => x.nro_cedulon_paypertic != 0);

        RuleFor(x => x.des_movimiento).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.des_movimiento));
        RuleFor(x => x.des_categoria).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.des_categoria));
        RuleFor(x => x.deuda).GreaterThanOrEqualTo(0).When(x => x.deuda != 0);
        RuleFor(x => x.sel).InclusiveBetween(0, int.MaxValue).When(x => x.sel != 0);
        RuleFor(x => x.costo_financiero).GreaterThanOrEqualTo(0).When(x => x.costo_financiero != 0);
        RuleFor(x => x.des_rubro).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.des_rubro));
        RuleFor(x => x.cod_tipo_per).GreaterThanOrEqualTo(0).When(x => x.cod_tipo_per != 0);
        RuleFor(x => x.sub_total).GreaterThanOrEqualTo(0).When(x => x.sub_total != 0);
    }

    private bool BeAValidDate(DateTime? date)
    {
        return date.HasValue && date.Value > DateTime.MinValue;
    }
}
