using FluentValidation;
using Web_Api_Inm.Entities;

public class InmueblesValidator : AbstractValidator<Inmuebles>
{
    public InmueblesValidator()
    {
        // Campos int NOT NULL
        RuleFor(x => x.circunscripcion).GreaterThanOrEqualTo(0);
        RuleFor(x => x.seccion).GreaterThanOrEqualTo(0);
        RuleFor(x => x.manzana).GreaterThanOrEqualTo(0);
        RuleFor(x => x.parcela).GreaterThanOrEqualTo(0);
        RuleFor(x => x.p_h).GreaterThanOrEqualTo(0);
        RuleFor(x => x.nro_bad).GreaterThanOrEqualTo(0);
        RuleFor(x => x.cod_calle_pf).GreaterThanOrEqualTo(0);
        RuleFor(x => x.nro_dom_pf).GreaterThanOrEqualTo(0);

        // Campos int NULL (sin HasValue)
        RuleFor(x => x.cod_barrio).GreaterThanOrEqualTo(0).When(x => x.cod_barrio != null);
        RuleFor(x => x.cod_barrio_dom_esp).GreaterThanOrEqualTo(0).When(x => x.cod_barrio_dom_esp != null);
        RuleFor(x => x.cod_calle_dom_esp).GreaterThanOrEqualTo(0).When(x => x.cod_calle_dom_esp != null);
        RuleFor(x => x.nro_dom_esp).GreaterThanOrEqualTo(0).When(x => x.nro_dom_esp != null);
        RuleFor(x => x.cod_uso).GreaterThanOrEqualTo(0).When(x => x.cod_uso != null);
        RuleFor(x => x.nro_secuencia).GreaterThanOrEqualTo(0).When(x => x.nro_secuencia != null);
        RuleFor(x => x.cod_situacion_judicial).GreaterThanOrEqualTo(0).When(x => x.cod_situacion_judicial != null);
        RuleFor(x => x.nro_bad_ocupante).GreaterThanOrEqualTo(0).When(x => x.nro_bad_ocupante != null);
        RuleFor(x => x.tipo_ph).GreaterThanOrEqualTo(0).When(x => x.tipo_ph != null);

        // Campos smallint NULL
        /*
        RuleFor(x => x.cod_tipo_per_elegido).GreaterThanOrEqualTo(0).When(x => x.cod_tipo_per_elegido != null);
        RuleFor(x => x.con_deuda).GreaterThanOrEqualTo(0).When(x => x.con_deuda != null);
        RuleFor(x => x.cod_estado).GreaterThanOrEqualTo(0).When(x => x.cod_estado != null);
        RuleFor(x => x.cedulon_digital).GreaterThanOrEqualTo(0).When(x => x.cedulon_digital != null);
        RuleFor(x => x.oculto).GreaterThanOrEqualTo(0).When(x => x.oculto != null);
        */
        // Campos decimal NULL
        RuleFor(x => x.saldo_adeudado).GreaterThanOrEqualTo(0).When(x => x.saldo_adeudado != null);

        // Campos real NULL
        RuleFor(x => x.superficie).GreaterThanOrEqualTo(0).When(x => x.superficie != null);
        RuleFor(x => x.superficie_edificada).GreaterThanOrEqualTo(0).When(x => x.superficie_edificada != null);

        // Campos string con longitud máxima
        RuleFor(x => x.Nombre).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.Nombre));
        RuleFor(x => x.nom_barrio_dom_esp).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.nom_barrio_dom_esp));
        RuleFor(x => x.nom_calle_dom_esp).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.nom_calle_dom_esp));
        RuleFor(x => x.piso_dpto_esp).MaximumLength(15).When(x => !string.IsNullOrWhiteSpace(x.piso_dpto_esp));
        RuleFor(x => x.ciudad_dom_esp).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.ciudad_dom_esp));
        RuleFor(x => x.provincia_dom_esp).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.provincia_dom_esp));
        RuleFor(x => x.pais_dom_esp).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.pais_dom_esp));
        RuleFor(x => x.cod_postal).MaximumLength(4).When(x => !string.IsNullOrWhiteSpace(x.cod_postal));
        RuleFor(x => x.ultimo_periodo).MaximumLength(7).When(x => !string.IsNullOrWhiteSpace(x.ultimo_periodo));
        RuleFor(x => x.ocupante).MaximumLength(40).When(x => !string.IsNullOrWhiteSpace(x.ocupante));
        RuleFor(x => x.clave_pago).MaximumLength(19).When(x => !string.IsNullOrWhiteSpace(x.clave_pago));
        RuleFor(x => x.email_envio_cedulon).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.email_envio_cedulon));
        RuleFor(x => x.telefono).MaximumLength(30).When(x => !string.IsNullOrWhiteSpace(x.telefono));
        RuleFor(x => x.celular).MaximumLength(30).When(x => !string.IsNullOrWhiteSpace(x.celular));
        RuleFor(x => x.nro_doc_ocupante).MaximumLength(10).When(x => !string.IsNullOrWhiteSpace(x.nro_doc_ocupante));
        RuleFor(x => x.cuit_ocupante).MaximumLength(13).When(x => !string.IsNullOrWhiteSpace(x.cuit_ocupante));
        RuleFor(x => x.cuil).MaximumLength(13).When(x => !string.IsNullOrWhiteSpace(x.cuil));
        RuleFor(x => x.cuit_vecino_digital).MaximumLength(20).When(x => !string.IsNullOrWhiteSpace(x.cuit_vecino_digital));
        RuleFor(x => x.cod_categoria_zona_liq).MaximumLength(1).When(x => !string.IsNullOrWhiteSpace(x.cod_categoria_zona_liq));
        //RuleFor(x => x.categoria_iva).MaximumLength(10).When(x => !string.IsNullOrWhiteSpace(x.categoria_iva));
        RuleFor(x => x.piso_dpto).MaximumLength(10).When(x => !string.IsNullOrWhiteSpace(x.piso_dpto));
        //RuleFor(x => x.nro_local).MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.nro_local));
        RuleFor(x => x.LAT).MaximumLength(1000).When(x => !string.IsNullOrWhiteSpace(x.LAT));
        RuleFor(x => x.LONG).MaximumLength(1000).When(x => !string.IsNullOrWhiteSpace(x.LONG));
        RuleFor(x => x.DIR_GOOGLE).MaximumLength(1000).When(x => !string.IsNullOrWhiteSpace(x.DIR_GOOGLE));

        // Validar fechas sin HasValue
        RuleFor(x => x.fecha_cambio_domicilio).LessThanOrEqualTo(DateTime.Now).When(x => x.fecha_cambio_domicilio != null);
        RuleFor(x => x.fecha_alta).LessThanOrEqualTo(DateTime.Now).When(x => x.fecha_alta != null);
        RuleFor(x => x.fecha_vecino_digital).LessThanOrEqualTo(DateTime.Now).When(x => x.fecha_vecino_digital != null);
        RuleFor(x => x.fecha_tipo_ph).LessThanOrEqualTo(DateTime.Now).When(x => x.fecha_tipo_ph != null);
    }
}
