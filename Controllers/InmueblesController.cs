using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using Web_Api_Inm.Entities;
using Web_Api_Inm.Entities.AUDITORIA;
using Web_Api_Inm.Entities.HELPERS;
using Web_Api_Inm.Helpers;
using Web_Api_Inm.Services;
using WSAfip;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace Web_Api_Inm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InmueblesController : Controller
    {
        DateTimeFormatInfo culturaFecArgentina = new CultureInfo("es-AR", false).DateTimeFormat;
        private IInmueblesService _InmueblesService;

        public InmueblesController(IInmueblesService InmueblesService)
        {
            _InmueblesService = InmueblesService;
        }
        [HttpGet]
        public IActionResult getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            var resultado = _InmueblesService.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            if (resultado == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(resultado);
        }

        [HttpPut]
        public ActionResult Updateinmueble(Inmuebles obj)
        {

            var inmueble = _InmueblesService.getByPk(obj.circunscripcion, obj.seccion, obj.manzana, obj.parcela, obj.p_h);
            if (inmueble.circunscripcion == 0)
            {
                return BadRequest(new { message = @"Información, no se encontro este Inmueble " });
            }
            else
            {
                _InmueblesService.update(obj);
            }
            return Ok(inmueble);

        }

        [HttpGet]
        public ActionResult Categorias_liq_zona()
        {
            var zonas = _InmueblesService.Categorias_liq_zona();
            return Ok(zonas);
        }

        [HttpGet]
        public PaginadorGenerico<Entities.Inmuebles> GetInmueblesPaginado(string buscarPor = "",
            string strParametro = "", int pagina = 0, int registros_por_pagina = 10)
        {
            List<Entities.Inmuebles> _Inmueble;
            PaginadorGenerico<Entities.Inmuebles> _PaginadorInmueble;

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;


            _TotalRegistros = _InmueblesService.Count();
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

            if (pagina == 0)
            {
                _Inmueble = _InmueblesService.GetInmueblesPaginado(buscarPor, strParametro, pagina, registros_por_pagina);
            }
            else
            {
                _Inmueble = _InmueblesService.GetInmueblesPaginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            }

            if (_Inmueble != null && _Inmueble.Count() > 0)
            {

                _PaginadorInmueble = new PaginadorGenerico<Entities.Inmuebles>()
                {
                    RegistrosPorPagina = registros_por_pagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaPor = buscarPor,
                    Parametro = strParametro,
                    Resultado = _Inmueble
                };

                if (_PaginadorInmueble.TotalRegistros == 0)
                {
                    //return BadRequest(new { message = "No se encontraron los datos..." });
                }
                return _PaginadorInmueble;
            }
            else
                return null;
        }
        [HttpGet]
        public PaginadorGenerico<Entities.Inmuebles> GetInmueblesPaginadoDenominacion(
            int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            List<Entities.Inmuebles> _Inmueble;
            PaginadorGenerico<Entities.Inmuebles> _PaginadorInmueble;

            string strParametro = _InmueblesService.armoDenominacion2(circunscripcion,
                seccion, manzana, parcela, p_h);

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            _Inmueble = _InmueblesService.GetInmueblesPaginado("denominacion", strParametro, 0,
                2);

            if (_Inmueble != null && _Inmueble.Count() > 0)
            {
                _TotalRegistros = 1;
                _TotalPaginas = 1;
                _PaginadorInmueble = new PaginadorGenerico<Entities.Inmuebles>()
                {
                    RegistrosPorPagina = 1,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = 1,
                    BusquedaPor = "denominacion",
                    Parametro = strParametro,
                    Resultado = _Inmueble
                };

                if (_PaginadorInmueble.TotalRegistros == 0)
                {
                    //return BadRequest(new { message = "No se encontraron los datos..." });
                }
                return _PaginadorInmueble;
            }
            else
                return null;
        }

        //[HttpPost]
        //public IActionResult InformeCtaCteCompleto(int cir, int sec, int man, int par, int p_h, string per, Auditoria objA)
        //{
        //    var reporte = _InmueblesService.InformeCtaCteCompleto(cir, sec, man, par, p_h, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble " });
        //    }
        //    return Ok(reporte);
        //}

        //[HttpPost]
        //public IActionResult InformeCtaCteSolodeuda(int cir, int sec, int man, int par, int p_h, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA)
        //{
        //    var reporte = _InmueblesService.InformeCtaCteSoloDeuda(cir, sec, man, par, p_h, categoria_deuda, categoria_deuda2, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble " });
        //    }
        //    return Ok(reporte);
        //}

        [HttpGet]
        public IActionResult ListarCategoriasTasa()
        {
            var categorias = _InmueblesService.ListarCategoriasTasa();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Resumendeuda(int cir, int sec, int man, int par, int p_h, int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA)
        {
            var resumen = _InmueblesService.Resumendeuda(cir, sec, man, par, p_h, tipo_consulta, periodo, cate_deuda_desde, cate_deuda_hasta, objA);
            if (resumen.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Datos para este Inmueble!!!" });
            }
            return Ok(resumen);
        }


        [HttpGet]
        public IActionResult FrentesXInmueble(int cir, int sec, int man, int par, int p_h)
        {
            var lst = _InmueblesService.FrentesXInmueble(cir, sec, man, par, p_h);
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult GetZonas(int? cod_zona)
        {
            var lst = _InmueblesService.GetZonas(cod_zona);
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult GetCalle(string? nom_calle)
        {
            var lst = _InmueblesService.GetCalle(nom_calle);
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult GetBarrios(string? barrio)
        {
            var lst = _InmueblesService.GetBarrios(barrio);
            return Ok(lst);
        }


        [HttpPost]
        public IActionResult NuevoFrente(Frentes_Con_Auditoria obj)
        {
            _InmueblesService.InsertFrente(obj);
            if (obj.frente.nro_domicilio < 0)
            {
                return BadRequest(new { message = @" Nro de domicilio incorrecto" });
            }
            return Ok(new { message = @"Se inserto nuevo frente correctamente." });
        }


        [HttpPut]
        public IActionResult ModificarFrente(Frentes_Con_Auditoria obj)
        {
            _InmueblesService.UpdateFrente(obj);

            return Ok(new { message = @"Se actualizo  frente correctamente." });
        }

        [HttpDelete]
        public IActionResult EliminarFrente(int cir, int sec, int man, int par, int p_h, int nro_frente, Auditoria obj)
        {

            if (nro_frente == 1)
            {
                return BadRequest(new { message = @"No se puede eliminar el frente nro 1" });
            }

            _InmueblesService.DeleteFrente(cir, sec, man, par, p_h, nro_frente, obj);
            return Ok(new { message = @"Se elimino frente correctamente." });
        }

        //Frentes

        //procedure TFreinm3.NuevoClick(Sender: TObject);
        //var
        //    permiso:smallint;
        //begin
        //permiso:=Verificar_Permiso_V2(PriTasa.usuario,'FREINM');
        //if permiso=0 then
        //begin
        //Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //operacion:='Nuevo';
        //QFrentes_x_Inmueble.Append;
        //QFrentes_x_InmuebleCircunscripcion.Value:=
        //Data_Tasa.InmueblesCircunscripcion.Value;
        //QFrentes_x_InmuebleSeccion.Value:=
        //Data_Tasa.InmueblesSeccion.Value;
        //QFrentes_x_InmuebleManzana.Value:=
        //Data_Tasa.InmueblesManzana.Value;
        //QFrentes_x_InmuebleParcela.Value:=
        //Data_Tasa.InmueblesParcela.Value;
        //QFrentes_x_InmuebleP_H.Value:=
        //Data_Tasa.InmueblesP_H.Value;
        //QFrentes_x_InmuebleNro_Frente.Value:=0;
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=False;
        //Modifica.Enabled:=False;
        //Elimina.Enabled:=False;
        //Navegador.Enabled:=False;
        //Panel_Titulo.Caption:='Nuevo Frente';
        //Cod_Calle.SetFocus;
        //end;

        //procedure TFreinm3.ConfirmaClick(Sender: TObject);
        //var
        //    i: integer;
        //auxnro_frente: integer;
        //begin
        //// Nuevo
        //if operacion='Nuevo' then
        //begin
        //if (QFrentes_x_InmuebleNro_Domicilio.IsNull=True) or            -----> VALIDACION
        //(QFrentes_x_InmuebleNro_Domicilio.Value< 0) then
        //begin
        //Application.
        //MessageBox('Nº de Domicilio incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Nro_Domicilio.SetFocus;
        //Exit;
        //end;
        //Application.CreateForm(TAutoriza, Autoriza);
        //Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='NUEVO FRENTE';
        //if Autoriza.ShowModal<> mrOk then
        //begin
        //Autoriza.Free;
        //Exit;
        //end;
        //try
        //Data_Tasa.Siimva.StartTransaction;
        //QFrentes_x_Inmueble.Post;
        //Update_Frentes_x_Inmueble.Apply(ukInsert);
        //QFrentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Open;
        //QFrentes_x_Inmueble.First;
        //if QFrentes_x_InmuebleNro_Frente.Value=1 then
        //begin
        //Data_Tasa.Inmuebles.Edit;
        //Data_Tasa.InmueblesCod_Calle_Pf.Value := QFrentes_x_InmuebleCod_Calle.Value;
        //Data_Tasa.InmueblesNro_Dom_Pf.Value   := QFrentes_x_InmuebleNro_Domicilio.Value;
        ////Con la calle y el número de domicilio averigüo el barrio del inmueble
        //QCalles_x_Barrio.ParamByName('cod_calle').Value := QFrentes_x_InmuebleCod_Calle.Value;
        //QCalles_x_Barrio.Open;
        //QCalles_x_Barrio.First;
        //while not QCalles_x_Barrio.Eof do
        //begin
        //    if (QFrentes_x_InmuebleNro_Domicilio.Value >= QCalles_x_BarrioDesde.Value) and
        //        (QFrentes_x_InmuebleNro_Domicilio.Value <= (QCalles_x_BarrioHasta.Value + 100)) and
        //        (((power(-1, QFrentes_x_InmuebleNro_Domicilio.Value) > 0) and
        //        (QCalles_x_BarrioPar.Value= True)) or
        //    ((power(-1, QFrentes_x_InmuebleNro_Domicilio.Value) < 0) and
        //    (QCalles_x_BarrioImpar.Value= True)))  then
        //    begin
        //    Data_Tasa.InmueblesCod_Barrio.Value:=QCalles_x_BarrioCod_Barrio.Value;
        //    break;
        //    end;
        //    QCalles_x_Barrio.Next;
        //end;
        //QCalles_x_Barrio.Close;
        //Data_Tasa.Inmuebles.Post;
        //end;
        //Data_Tasa.AUDITOR_V2.ParamByName('@usuario').Value:=PriTasa.usuario;
        //Data_Tasa.AUDITOR_V2.ParamByName('@autorizacion').Value:=
        //Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //Data_Tasa.AUDITOR_V2.ParamByName('@identificacion').Value:=
        //Rellena_Izquierda('0',2, Data_Tasa.InmueblesCircunscripcion.AsString) + '-'
        //+ Rellena_Izquierda('0',2, Data_Tasa.InmueblesSeccion.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesManzana.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesParcela.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesP_H.AsString);
        //Data_Tasa.AUDITOR_V2.ParamByName('@observaciones').Value:=
        //Autoriza.Memo1.Lines.Text;
        //Data_Tasa.AUDITOR_V2.ParamByName('@proceso').Value:='NUEVO FRENTE';
        //Data_Tasa.AUDITOR_V2.ParamByName('@detalle').Value:=
        //'Nº de frente: '+ QFrentes_x_InmuebleNro_frente.AsString;
        //Data_Tasa.AUDITOR_V2.ExecProc;
        //Data_Tasa.Siimva.Commit;
        //except
        //Autoriza.Free;
        //Data_Tasa.Siimva.Rollback;
        //Application.MessageBox('Revise Datos.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //Autoriza.Free;
        //QFrentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Open;
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;
        //// Modifica
        //if operacion='Modifica' then
        //begin
        //if (QFrentes_x_InmuebleNro_Domicilio.IsNull=True) or
        //(QFrentes_x_InmuebleNro_Domicilio.Value< 0) then
        //begin
        //Application.
        //MessageBox('Nº de Domicilio incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Nro_Domicilio.SetFocus;
        //Exit;
        //end;
        //Application.CreateForm(TAutoriza, Autoriza);
        //Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='MODIFICA FRENTE';
        //if Autoriza.ShowModal<> mrOk then
        //begin
        //Autoriza.Free;
        //Exit;
        //end;
        //try
        //Data_Tasa.Siimva.StartTransaction;
        //Frentes_x_Inmueble.Open;
        //Frentes_x_Inmueble.FindKey([QFrentes_x_InmuebleCircunscripcion.Value,
        //                            QFrentes_x_InmuebleSeccion.Value,
        //                            QFrentes_x_InmuebleManzana.Value,
        //                            QFrentes_x_InmuebleParcela.Value,
        //                            QFrentes_x_InmuebleP_H.Value,
        //                            QFrentes_x_InmuebleNro_Frente]);
        //Data_Tasa.AUDITOR_V2.ParamByName('@usuario').Value:=PriTasa.usuario;
        //Data_Tasa.AUDITOR_V2.ParamByName('@autorizacion').Value:=
        //Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //Data_Tasa.AUDITOR_V2.ParamByName('@identificacion').Value:=
        //Rellena_Izquierda('0',2, Data_Tasa.InmueblesCircunscripcion.AsString) + '-'
        //+ Rellena_Izquierda('0',2, Data_Tasa.InmueblesSeccion.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesManzana.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesParcela.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesP_H.AsString);
        //Data_Tasa.AUDITOR_V2.ParamByName('@observaciones').Value:=
        //Autoriza.Memo1.Lines.Text;
        //Data_Tasa.AUDITOR_V2.ParamByName('@proceso').Value:='MODIFICA FRENTE';
        //Data_Tasa.AUDITOR_V2.ParamByName('@detalle').Value:=
        //'Nº Frente Modif: ' + QFrentes_x_InmuebleNro_frente.AsString +
        //' Z.Ant.: ' + IntToStr(zona_anterior) +
        //' Mtrs Frente Ant.: ' + FloatToStr(metros_anterior) +
        //' Cod. Calle Ant.: ' + IntToStr(calle_anterior);
        //Data_Tasa.AUDITOR_V2.ExecProc;
        //QFrentes_x_Inmueble.Post;
        //Update_Frentes_x_Inmueble.Apply(ukModify);
        //if QFrentes_x_InmuebleNro_Frente.Value=1 then
        //begin
        //Data_Tasa.Inmuebles.Edit;
        //Data_Tasa.InmueblesCod_Calle_Pf.Value:=
        //    QFrentes_x_InmuebleCod_Calle.Value;
        //Data_Tasa.InmueblesNro_Dom_Pf.Value:=
        //    QFrentes_x_InmuebleNro_Domicilio.Value;
        //QCalles_x_Barrio.ParamByName('cod_calle').Value:=
        //    QFrentes_x_InmuebleCod_Calle.Value;
        //QCalles_x_Barrio.Open;
        //QCalles_x_Barrio.First;
        //while not QCalles_x_Barrio.Eof do
        //begin                -------------------------------------------------------------------------------> VALIDACION
        //    if (QFrentes_x_InmuebleNro_Domicilio.Value >= QCalles_x_BarrioDesde.Value) and
        //        (QFrentes_x_InmuebleNro_Domicilio.Value <= (QCalles_x_BarrioHasta.Value + 100)) and
        //        (((power(-1, QFrentes_x_InmuebleNro_Domicilio.Value) > 0) and
        //        (QCalles_x_BarrioPar.Value= True)) or
        //    ((power(-1, QFrentes_x_InmuebleNro_Domicilio.Value) < 0) and
        //    (QCalles_x_BarrioImpar.Value= True)))  then
        //    begin
        //    Data_Tasa.InmueblesCod_Barrio.Value:=QCalles_x_BarrioCod_Barrio.Value;
        //    break;
        //    end;
        //    QCalles_x_Barrio.Next;
        //end;
        //QCalles_x_Barrio.Close;

        //Data_Tasa.Inmuebles.Post;
        //if Catastro.FindKey([Data_Tasa.InmueblesCircunscripcion.Value,
        //                        Data_Tasa.InmueblesSeccion.Value,
        //                        Data_Tasa.InmueblesManzana.Value,
        //                        Data_Tasa.InmueblesParcela.Value,
        //                        Data_Tasa.InmueblesP_H.Value]) then
        //begin
        //    Catastro.Edit;
        //CatastroCod_Calle_Pf.Value:=
        //    QFrentes_x_InmuebleCod_Calle.Value;
        //    CatastroNro_Dom_Pf.Value:=
        //    QFrentes_x_InmuebleNro_Domicilio.Value;
        //    Catastro.Post;
        //end;
        //end;
        //Data_Tasa.Siimva.Commit;
        //except
        //Autoriza.Free;
        //Frentes_x_Inmueble.Close;
        //Data_Tasa.Siimva.Rollback;
        //Application.
        //MessageBox('Revise Datos.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //Frentes_x_Inmueble.Close;
        //Autoriza.Free;
        //QFrentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Open;
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;
        //// Elimina
        //if operacion='Elimina' then
        //begin
        //Application.CreateForm(TAutoriza, Autoriza);
        //Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='BAJA FRENTE';
        //if Autoriza.ShowModal<> mrOk then
        //begin
        //Autoriza.Free;
        //Exit;
        //end;
        //try
        //Data_Tasa.Siimva.StartTransaction;
        //Data_Tasa.AUDITOR_V2.ParamByName('@usuario').Value:=PriTasa.usuario;
        //Data_Tasa.AUDITOR_V2.ParamByName('@autorizacion').Value:=
        //Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //Data_Tasa.AUDITOR_V2.ParamByName('@identificacion').Value:=
        //Rellena_Izquierda('0',2, Data_Tasa.InmueblesCircunscripcion.AsString) + '-'
        //+ Rellena_Izquierda('0',2, Data_Tasa.InmueblesSeccion.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesManzana.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesParcela.AsString) + '-'
        //+ Rellena_Izquierda('0',3, Data_Tasa.InmueblesP_H.AsString);
        //Data_Tasa.AUDITOR_V2.ParamByName('@observaciones').Value:=
        //Autoriza.Memo1.Lines.Text;
        //Data_Tasa.AUDITOR_V2.ParamByName('@proceso').Value:='BAJA FRENTE';
        ////Data_Tasa.AUDITOR_V2.ParamByName('@detalle').Value:='  ';
        ////Data_Tasa.AUDITOR_V2.ExecProc;
        //Autoriza.Free;
        //Frentes_x_Inmueble.Open;
        //Frentes_x_Inmueble.FindKey([QFrentes_x_InmuebleCircunscripcion.Value,
        //                            QFrentes_x_InmuebleSeccion.Value,
        //                            QFrentes_x_InmuebleManzana.Value,
        //                            QFrentes_x_InmuebleParcela.Value,
        //                            QFrentes_x_InmuebleP_H.Value,
        //                            QFrentes_x_InmuebleNro_Frente]);
        //Data_Tasa.AUDITOR_V2.ParamByName('@detalle').Value:='Nº Frente: '+
        //Frentes_x_InmuebleNro_frente.AsString + ' Cod Calle: ' +
        //Frentes_x_InmuebleCod_calle.AsString + ' Nro domicilio: ' +
        //Frentes_x_InmuebleNro_domicilio.AsString + ' Metros Frente: ' +
        //Frentes_x_InmuebleMetros_frente.AsString + ' Cod Zona: ' +
        //Frentes_x_InmuebleCod_zona.AsString;
        //Data_Tasa.AUDITOR_V2.ExecProc;
        //Frentes_x_Inmueble.Delete;
        //auxnro_frente:=QFrentes_x_InmuebleNro_Frente.Value;
        //i:=1;
        //QFrentes_x_Inmueble.First;
        //while not QFrentes_x_Inmueble.Eof do
        //begin
        //if QFrentes_x_InmuebleNro_Frente.Value<> auxnro_frente then
        //begin
        //    Frentes_x_Inmueble.FindKey([QFrentes_x_InmuebleCircunscripcion.Value,
        //    QFrentes_x_InmuebleSeccion.Value,
        //    QFrentes_x_InmuebleManzana.Value,
        //    QFrentes_x_InmuebleParcela.Value,
        //    QFrentes_x_InmuebleP_H.Value,
        //    QFrentes_x_InmuebleNro_Frente.Value]);
        //Frentes_x_Inmueble.Edit;
        //    Frentes_x_InmuebleNro_Frente.Value:=i;
        //    Frentes_x_Inmueble.Post;
        //    i:=i + 1;
        //end;
        //QFrentes_x_Inmueble.Next;
        //end;
        //QFrentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Open;
        //Data_Tasa.Siimva.Commit;
        //except
        //Autoriza.Free;
        //Frentes_x_Inmueble.Close;
        //Data_Tasa.Siimva.Rollback;
        //Application.
        //MessageBox('Eliminación con Problemas.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //Frentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Close;
        //QFrentes_x_Inmueble.Open;
        //Confirma.Enabled:=False;
        //Cancela.Enabled:=False;
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;


        //end;

        //procedure TFreinm3.CancelaClick(Sender: TObject);
        //begin
        //if operacion='Nuevo' then
        //begin
        //QFrentes_x_Inmueble.Cancel;
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;

        //if operacion='Modifica' then
        //begin
        //QFrentes_x_Inmueble.Cancel;
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;

        //if operacion='Elimina' then
        //begin
        //Confirma.Enabled:=False;
        //Cancela.Enabled:=False;
        //Nuevo.Enabled:=True;
        //Modifica.Enabled:=True;
        //Elimina.Enabled:=True;
        //Navegador.Enabled:=True;
        //Panel_Titulo.Caption:='Esperando Operación...';
        //Nuevo.SetFocus;
        //end;
        //end;

        //procedure TFreinm3.ModificaClick(Sender: TObject);
        //var
        //    permiso:smallint;
        //begin
        //permiso:=Verificar_Permiso_V2(PriTasa.usuario,'FREINM');
        //if permiso=0 then
        //begin
        //Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //if QFrentes_x_Inmueble.Eof then
        //begin
        //Application.
        //MessageBox('Se ha llegado al Final del Archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //Exit;
        //end;
        //operacion:='Modifica';
        //Activa_Desactiva_Controles(Panel_Trabajo);
        //Nuevo.Enabled:=False;
        //Modifica.Enabled:=False;
        //Elimina.Enabled:=False;
        //Navegador.Enabled:=False;
        //Panel_Titulo.Caption:='Modifica Frente';
        //Cod_Calle.SetFocus;
        //QFrentes_x_Inmueble.Edit;
        //zona_anterior:= QFrentes_x_Inmueblecod_zona.Value;
        //metros_anterior:= QFrentes_x_Inmueblemetros_frente.Value;
        //calle_anterior:= QFrentes_x_Inmueblecod_calle.Value;
        //end;

        //procedure TFreinm3.EliminaClick(Sender: TObject);
        //var
        //    permiso:smallint;
        //begin
        //permiso:=Verificar_Permiso_V2(PriTasa.usuario,'FREINM');
        //if permiso=0 then
        //begin
        //Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //if QFrentes_x_Inmueble.Eof then
        //begin
        //Application.
        //MessageBox('Se ha llegado al Final del Archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //Exit;
        //end;
        //if QFrentes_x_InmuebleNro_Frente.Value=1 then
        //begin
        //Application.
        //MessageBox('No puede eliminar el primer frente.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit;
        //end;
        //operacion:='Elimina';
        //Confirma.Enabled:=True;
        //Cancela.Enabled:=True;
        //Nuevo.Enabled:=False;
        //Modifica.Enabled:=False;
        //Elimina.Enabled:=False;
        //Navegador.Enabled:=False;
        //Panel_Titulo.Caption:='Elimina Frente';

        //end;

        //Querys

        //SELECT* FROM FRENTES_X_INMUEBLE
        //WHERE circunscripcion=:circunscripcion AND
        //            seccion=:seccion AND
        //            manzana=:manzana AND
        //            parcela=:parcela AND
        //            p_h=:p_h
        //dbo.ZONAS

        //////////////////////////////////////////////////////////////////////////////////////////////
        ///GestInmueble
        //sqlCategorias_liq.Open();
        //CargarCombo(sqlCategorias_liq, cmbZonaLiq,'');
        //cmbZonaLiq.Text:= Data_Tasa.INMUEBLEScod_categoria_zona_liq.AsString;
        //sqlCategorias_liq.Close();
        //select*
        //from CATEGORIAS_LIQUIDACION_TASA
        //////////////////////////////////////////////////////////////////////////////////////////////
        ///Permiso de Conexion de Agua
        ///
        // select i.Nombre, i.circunscripcion, i.seccion, i.manzana, i.parcela, i.p_h
        // , c.NOM_CALLE, i.nro_dom_pf, b.NOM_BARRIO, ca.Manzana_Oficial, ca.Lote_Oficial, ca.Superficie
        // , domicilio= c.NOM_CALLE + ' Nº ' + cast(i.nro_dom_pf as varchar(10)) + ' de Barrio ' + b.NOM_BARRIO
        // from INMUEBLES i left join CALLES c on c.COD_CALLE= i.cod_calle_pf
        // left join BARRIOS b  on b.COD_BARRIO= i.cod_barrio
        // left join CATASTRO ca on ca.Circunscripcion= i.circunscripcion and ca.seccion= i.seccion
        // and ca.manzana= i.manzana and ca.parcela= i.parcela and ca.P_H= i.p_h
        // where i.circunscripcion= :circunscripcion and i.seccion= :seccion
        // and i.manzana= :manzana and i.parcela= :parcela and i.p_h = :p_h


        [HttpGet]
        public IActionResult GetDatosConexionAgua(int cir, int sec, int man, int par, int p_h, string? nombre_titular)
        {
            var datos = _InmueblesService.GetDatos(cir, sec, man, par, p_h, nombre_titular);

            return Ok(datos);
        }



        //procedure TNotaAgua.ppDetailBand1BeforePrint(Sender: TObject);

        //begin
        //    DecodeDate(now(), anio, mes, dia);

        //case  mes of
        //    1:MesTexto:= 'ENERO';
        //    2:MesTexto:= 'FEBRERO';
        //    3:MesTexto:= 'MARZO';
        //    4:MesTexto:= 'ABRIL';
        //    5:MesTexto:= 'MAYO';
        //    6:MesTexto:= 'JUNIO';
        //    7:MesTexto:= 'JULIO';
        //    8:MesTexto:= 'AGOSTO';
        //    9:MesTexto:= 'SETIEMBRE';
        //    10:MesTexto:='OCTUBRE';
        //    11:MesTexto:= 'NOVIEMBRE';
        //    12:MesTexto:= 'DICIEMBRE';

        //end;
        //end;

        //procedure TNotaAgua.pprTextPrint(Sender: TObject);
        //    begin
        //        pprText.Paragraph.Alignment := taLeftJustify;

        //    pprText.RichText:= 'Certifico: Que el inmueble de propiedad '+ edtNombre.Text+' ubicado en '+
        //sqlNotaAguadomicilio.AsString+ ' de esta ciudad, designado catastralmente como C: '+ sqlNotaAguacircunscripcion.AsString
        //+' S:' + sqlNotaAguaseccion.AsString+ ' M:'+  sqlNotaAguamanzana.AsString + ' P:'+ sqlNotaAguaparcela.AsString
        //+' P_H:'+ sqlNotaAguap_h.AsString +' -Manzana Oficial:'+ sqlNotaAguaManzana_Oficial.AsString + ' Lote Oficial:'
        //+ sqlNotaAguaLote_Oficial.AsString +' Superficie '+ sqlNotaAguaSuperficie.AsString +' mts². esta autorizado a conectarse a la red de agua-'+#13+#10+
        //'Para ser presentado ante la Cooperativa de Obras y Serv. Publicos de Villa Allende Ltda., se extiende la '+
        //'presente en la ciudad de Villa Allende, a los ' +IntToStr(dia) +' dias del mes de '+ MesTexto + ' del año ' + inttostr(anio);
        //    end;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        [HttpGet]
        public IActionResult DatosDomicilioPostal(int cir, int sec, int man, int par, int p_h)
        {
            var datos = _InmueblesService.DatosDomicilioPostal(cir, sec, man, par, p_h);

            return Ok(datos);
        }


        [HttpPut]
        public IActionResult ActualizarDomicilioPostal(int cir, int sec, int man, int par, int p_h, DatosDomicilio_Con_Auditoria obj)
        {

            try
            {

                _InmueblesService.ActualizarDatosDomicilio(cir, sec, man, par, p_h, obj);
                return Ok(new { message = "Se ha actualizado domicilio postal correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar domicilio postal.", error = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult GetBarrioXCalle(int cod_calle, int nro_dom)
        {
            var barrio = _InmueblesService.GetBarrioXCalle(cod_calle, nro_dom);

            return Ok(barrio);
        }



        [HttpDelete]
        public IActionResult BajaInmueble(int cir, int sec, int man, int par, int p_h, Auditoria obj)
        {
            try
            {
                decimal monto = _InmueblesService.MontoDeuda(cir, sec, man, par, p_h);

                if (monto > 0)
                {
                    return BadRequest(new { message = "No se puede dar de baja por tener deudas." });
                }

                _InmueblesService.EliminarParcelaXInmueble(cir, sec, man, par, p_h, obj);
                return Ok(new { message = "Se ha dado de baja correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al intentar dar de baja el inmueble.", error = ex.Message });
            }
        }


        ///Domicilio Postal
        ///tiene permiso
        //procedure TGestInm.DpostalClick(Sender: TObject);
        //var
        //        permiso:smallint;
        //    begin
        //    permiso:=Verificar_Permiso_v2(PriTasa.usuario,'DOESPEC'); ------------------------------> PERMISO
        //    if permiso=0 then
        //    begin
        //    Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //    Exit
        //    end;
        //    //Application.CreateForm(TDatProp, DatProp);
        //    DatProp := TDatProp.Create(self);
        //    DatProp.ShowModal;
        //    FreeAndNil(DatProp);
        //end;


        //uses
        //  Datos_Tasa, ULibrary, UAutoriza, UPriTasa;
        //        var
        //          aux_barrio: string;
        //  aux_calle: string;
        //  aux_nro: string;
        //  aux_piso_dpto : string;
        //  aux_ciudad: string;
        //  aux_cod_postal: string;
        //  aux_provincia: string;
        //  aux_pais: string;
        //  aux_email, aux_telefono, aux_celular: string;
        //  accion:string;
        //  aux_cuit: string;
        //{$R*.DFM
        //    }



        //    procedure TDatProp.BuscaBarrioClick(Sender: TObject);
        //    begin
        //      InmueblesCod_Barrio_Dom_Esp.AsVariant:=
        //    Busqueda(QBarrios,'Búsqueda de Barrio');
        //    QBarrios.Open;
        //  try
        //    QBarrios.Locate('Código',InmueblesCod_Barrio_Dom_Esp.Value,[]);
        //    InmueblesNom_Barrio_Dom_Esp.Value:=
        //    QBarriosNombre.Value;
        //  except
        //  end;
        //    QBarrios.Close;
        //  InmueblesCiudad_Dom_Esp.Value:='VILLA ALLENDE';
        //  InmueblesProvincia_Dom_Esp.Value:='CORDOBA';
        //  InmueblesPais_Dom_Esp.Value:='ARGENTINA';
        //  InmueblesCod_Postal.Value:='5105';
        //end;

        //procedure TDatProp.BuscaCalleClick(Sender: TObject);
        //    begin
        //      InmueblesCod_Calle_Dom_Esp.AsVariant:=
        //    Busqueda(QCalles,'Búsqueda de Calle');
        //    QCalles.Open;
        //  try
        //    QCalles.Locate('Código',InmueblesCod_Calle_Dom_Esp.Value,[]);
        //    InmueblesNom_Calle_Dom_Esp.Value:=
        //      QCallesNombre.Value;
        //  except
        //  end;
        //    NRO_DOM_ESP.SetFocus;
        //  QCalles.Close;
        //end;

        //procedure TDatProp.CheckBox1Click(Sender: TObject);
        //    begin
        //      BuscaBarrio.Enabled:=not BuscaBarrio.Enabled;
        //    BuscaCalle.Enabled:=not BuscaCalle.Enabled;
        //    Nom_Barrio_Dom_Esp.Enabled:=not Nom_Barrio_Dom_Esp.Enabled;
        //    Nom_Calle_Dom_Esp.Enabled:=not Nom_Calle_Dom_Esp.Enabled;
        //    //Nro_Dom_Esp.Enabled:=not Nro_Dom_Esp.Enabled;
        //    Ciudad_Dom_Esp.Enabled:=not Ciudad_Dom_Esp.Enabled;
        //    COD_POSTAL.Enabled:=not COD_POSTAL.Enabled;
        //    Provincia_Dom_Esp.Enabled:=not Provincia_Dom_Esp.Enabled;
        //    Pais_Dom_Esp.Enabled:=not Pais_Dom_Esp.Enabled;
        //  if CheckBox1.Checked=False then
        //  begin
        //    InmueblesCiudad_Dom_Esp.Value:='VILLA ALLENDE';
        //    InmueblesCod_Postal.Value:='5105';
        //    InmueblesProvincia_Dom_Esp.Value:='CORDOBA';
        //    InmueblesPais_Dom_Esp.Value:='ARGENTINA';
        //  end
        //  else
        //  begin
        //    Inmueblesnom_barrio_dom_esp.Value:='';
        //    Inmueblescod_postal.Value:='';
        //   // NOM_BARRIO_DOM_ESP.Clear;
        //   // COD_POSTAL.Clear;
        //    NOM_CALLE_DOM_ESP.SetFocus;

        //  end;
        //end;


        //procedure TDatProp.COD_POSTALExit(Sender: TObject);
        //    begin
        //  if CheckBox1.Checked then
        //  begin
        //    if Inmueblescod_postal.Value='5105' then
        //    begin
        //         Application.MessageBox('No puede usar este codigo postal si es domicilio externo','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //         Inmueblescod_postal.Value:='';
        //    end;

        //  end;
        //end;

        //procedure TDatProp.confirmaClick(Sender: TObject);
        //    var
        //      cambio_domicilio: boolean;
        //  sqlUpdBadec: TQuery;
        //begin
        //   sqlUpdBadec := TQuery.Create(self);
        //   sqlUpdBadec.DatabaseName:='SIIMVA';
        //  cambio_domicilio:=False;
        //  if aux_barrio<> InmueblesNom_Barrio_Dom_Esp.Value then
        //    cambio_domicilio:=True;
        //  if aux_calle<> InmueblesNom_Calle_Dom_Esp.Value then
        //    cambio_domicilio:=True;
        //  if aux_nro<> InmueblesNro_Dom_Esp.AsString then
        //    cambio_domicilio:=True;
        //  if aux_piso_dpto<> InmueblesPiso_dpto_esp.AsString then
        //    cambio_domicilio:=True;
        //  if aux_ciudad<> InmueblesCiudad_Dom_Esp.Value then
        //    cambio_domicilio:=True;
        //  if aux_cod_postal<> Data_Tasa.InmueblesCod_postal.AsString then
        //    cambio_domicilio:=True;
        //  if aux_provincia<> InmueblesProvincia_Dom_Esp.Value then
        //    cambio_domicilio:=True;
        //  if aux_pais<> InmueblesPais_Dom_Esp.Value then
        //    cambio_domicilio:=True;
        //  if aux_email<> Inmueblesemail_envio_cedulon.Value then
        //    cambio_domicilio:=True;
        //  if aux_celular<> Inmueblescelular.Value then
        //    cambio_domicilio:=True;
        //  if aux_telefono<> InmueblesTelefono.Value then
        //    cambio_domicilio:=True;
        //  if aux_cod_postal<> Inmueblescod_postal.Value then
        //    cambio_domicilio:=True;

        // MODIFICAR

        //  if cambio_domicilio=True then
        //  begin

        //    if Length(Inmueblesemail_envio_cedulon.Value)>0 then
        //    begin
        //     if not EsEMail(Inmueblesemail_envio_cedulon.Value) then
        //     begin
        //        Application.MessageBox('Ingrese correctamente el Email...','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //        Exit;
        //     end;
        //    end;
        //    // Auditoria
        //    Application.CreateForm(TAutoriza, Autoriza);
        //    Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='MODIF. DOMICILIO POSTAL DE INMUEBLE';
        //    if (Autoriza.ShowModal<> mrOK) then
        //    begin
        //      Autoriza.Free;
        //    Exit;
        //    end; ----------------------------------------------------------> MODIFICA BADEC
        //    sqlUpdBadec.SQL.Add(' UPDATE BADEC  SET      '+
        //             	        '  TELEFONO ='+ QuotedStr(Inmueblestelefono.AsString) +' , '+
        //            	        '  E_MAIL = '+ QuotedStr(Inmueblesemail_envio_cedulon.AsString) +' ,     '+
        //                     '  CUIT = '+ QuotedStr(InmueblesCUIl.AsString) +',          '+
        //                     '  CELULAR = '+ QuotedStr(Inmueblescelular.AsString) +'     '+
        //                      '  WHERE NRO_BAD= '+ InmueblesNRO_BAD.AsString );


        //    Data_Tasa.Siimva.StartTransaction;
        //    try
        //      InmueblesFecha_Cambio_Domicilio.Value:=Now;
        //      //Inmueblesemite_cedulon.Value := True;
        //      Data_Tasa.AUDITOR_V2.ParamByName('@usuario').Value        := PriTasa.usuario;
        //      Data_Tasa.AUDITOR_V2.ParamByName('@autorizacion').Value   := Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //      Data_Tasa.AUDITOR_V2.ParamByName('@identificacion').Value := Rellena_Izquierda('0',2, IntToStr(Data_Tasa.INMUEBLEScircunscripcion.Value)) + '-'
        //        + Rellena_Izquierda('0',2, IntToStr(Data_Tasa.INMUEBLESseccion.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESmanzana.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESparcela.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESp_h.Value));
        //    Data_Tasa.AUDITOR_V2.ParamByName('@observaciones').Value   := Autoriza.Memo1.Lines.Text;
        //      Data_Tasa.AUDITOR_V2.ParamByName('@proceso').Value         := 'MODIF. DOMICILIO POSTAL DE INMUEBLE';
        //      Data_Tasa.AUDITOR_V2.ParamByName('@detalle').Value         := 'Datos Antes de Modif. ' +
        //        'Barrio: '+ aux_barrio +
        //        ' Calle: '+ aux_calle +
        //        ' Nro: '+ aux_nro +
        //        ' Piso/Dpto: ' + aux_piso_dpto +
        //        ' Ciudad: '+ aux_ciudad +
        //        ' Cod. Postal: ' + aux_cod_postal+
        //        ' Provincia: '+ aux_provincia +
        //        ' Pais: ' + aux_pais +
        //        ' Email: ' + aux_email +
        //        ' Telefono: ' + aux_telefono +
        //        ' Celular: ' + aux_celular;

        //      Autoriza.Free;
        //      Data_Tasa.AUDITOR_V2.ExecProc;

        //      Inmuebles.Post;
        //      sqlUpdBadec.ExecSQL;
        //      Data_Tasa.Inmuebles.Refresh;
        //      Data_Tasa.Siimva.Commit;
        //    except
        //      //Inmuebles.Cancel;
        //      Data_Tasa.Siimva.Rollback;
        //    Autoriza.Free;
        //      Application.MessageBox('Problemas con la Modificación de Datos...','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Exit;
        //    end;
        //  end;



        //  aux_barrio     := InmueblesNom_Barrio_Dom_Esp.Value;
        //  aux_calle      := InmueblesNom_Calle_Dom_Esp.Value;
        //  aux_nro        := InmueblesNro_Dom_Esp.AsString;
        //  aux_piso_dpto  := InmueblesPiso_dpto_esp.AsString;
        //  aux_ciudad     := InmueblesCiudad_Dom_Esp.Value;
        //  aux_cod_postal := InmueblesCod_postal.Value;
        //  aux_provincia  := InmueblesProvincia_Dom_Esp.Value;
        //  aux_pais       := InmueblesPais_Dom_Esp.Value;

        //  aux_email      := InmueblesEmail_envio_cedulon.Value;
        //  aux_telefono   := InmueblesTelefono.Value;
        //  aux_celular    := InmueblesCelular.Value;
        //  aux_cuit       := Inmueblescuil.Value;

        //  Panel_Trabajo.Enabled := False;
        //  Confirma.Enabled      := False;
        //  Cancela.Enabled       := False;
        //  BuscaCalle.Enabled    := False;
        //  BuscaBarrio.Enabled   := False;
        //  Modifica.Enabled      := True;
        //  Panel_Titulo.Caption  := 'Esperando Operación...';
        //  CheckBox1.Enabled     := False;


        //end;

        //procedure TDatProp.cancelaClick(Sender: TObject);
        //    begin
        //  if Inmuebles.State in [DsInsert, DsEdit]
        //    then
        //    Inmuebles.Cancel;
        //    Panel_Trabajo.Enabled:=False;
        //  Confirma.Enabled:=False;
        //  Cancela.Enabled:=False;
        //  CheckBox1.Enabled:=False;
        //  BuscaCalle.Enabled:=False;
        //  BuscaBarrio.Enabled:=False;
        //  Modifica.Enabled:=True;
        //end;

        //procedure TDatProp.FormCreate(Sender: TObject);
        //    begin
        //      Inmuebles.Open;
        //    Inmuebles.FindKey([Data_Tasa.InmueblesCircunscripcion.Value,
        //    Data_Tasa.InmueblesSeccion.Value, Data_Tasa.InmueblesManzana.Value,
        //    Data_Tasa.InmueblesParcela.Value, Data_Tasa.InmueblesP_H.Value]);

        //  aux_barrio:=Data_Tasa.InmueblesNom_Barrio_Dom_Esp.Value;
        //  aux_calle:=Data_Tasa.InmueblesNom_Calle_Dom_Esp.Value;
        //  aux_nro:=Data_Tasa.InmueblesNro_Dom_Esp.AsString;
        //  aux_piso_dpto:=Data_Tasa.InmueblesPiso_dpto_esp.Value;
        //  aux_ciudad:=Data_Tasa.InmueblesCiudad_Dom_Esp.Value;
        //  aux_cod_postal:=Data_Tasa.InmueblesCod_postal.Value;
        //  aux_provincia:=Data_Tasa.InmueblesProvincia_Dom_Esp.Value;
        //  aux_pais:=Data_Tasa.InmueblesPais_Dom_Esp.Value;
        //  aux_cuit := Data_Tasa.INMUEBLEScuil.value;
        //  Panel_Trabajo.Enabled:=False;
        //  Modifica.Enabled:=True;
        //  Confirma.Enabled:=False;
        //  Cancela.Enabled:=False;
        //  CheckBox1.Enabled:=False;
        //  CheckBox1.Checked:=False;
        //  BuscaCalle.Enabled:=False;
        //  BuscaBarrio.Enabled:=False;
        //end;

        //procedure TDatProp.FormDestroy(Sender: TObject);
        //    begin
        //      Inmuebles.Close;
        //    QCalles.Close;
        //  QBarrios.Close;
        //  QCalles_x_Barrio.Close;
        //end;

        //procedure TDatProp.NRO_DOM_ESPExit(Sender: TObject);
        //    begin
        //  if not CheckBox1.Checked=True then
        //  begin
        //    QCalles_x_Barrio.ParamByName('cod_calle').Value:=
        //      InmueblesCod_Calle_Dom_Esp.Value;
        //    QCalles_x_Barrio.Open;
        //    QCalles_x_Barrio.First;
        //    while not QCalles_x_Barrio.Eof do
        //    begin
        //      if (InmueblesNro_Dom_Esp.Value >= QCalles_x_BarrioDesde.Value) and
        //        (InmueblesNro_Dom_Esp.Value <= (QCalles_x_BarrioHasta.Value + 100)) and
        //        (((power(-1, InmueblesNro_Dom_Esp.Value) > 0) and
        //        (QCalles_x_BarrioPar.Value= True)) or
        //        ((power(-1, InmueblesNro_Dom_Esp.Value) < 0) and
        //        (QCalles_x_BarrioImPar.Value= True)))  then
        //      begin
        //        break;
        //      end;
        //      QCalles_x_Barrio.Next;
        //    end;
        //    if not QCalles_x_Barrio.Eof then
        //    begin
        //      InmueblesCod_Barrio_Dom_Esp.Value:=QCalles_x_BarrioCod_Barrio.Value;
        //    QBarrios.Open;
        //      try
        //        QBarrios.Locate('Código',InmueblesCod_Barrio_Dom_Esp.Value,[]);
        //        InmueblesNom_Barrio_Dom_Esp.Value:=
        //        QBarriosNombre.Value;
        //      except
        //      end;
        //    QBarrios.Close;
        //    end
        //    else
        //    begin
        //      Application.MessageBox('No se encuentra Barrio para esta Calle y Nº Domic..','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //    InmueblesNom_Barrio_Dom_Esp.Value:=' ';
        //    end;
        //    Piso_dpto.SetFocus;
        //    QCalles_x_Barrio.Close;
        //    InmueblesCiudad_Dom_Esp.Value:='VILLA ALLENDE';
        //    InmueblesProvincia_Dom_Esp.Value:='CORDOBA';
        //    InmueblesPais_Dom_Esp.Value:='ARGENTINA';
        //    InmueblesCod_Postal.Value:='5105';
        //  end;
        //end;

        //procedure TDatProp.ModificaClick(Sender: TObject);
        //    begin
        //      Panel_Trabajo.Enabled:=True;
        //    accion:='modif';
        //  Inmuebles.Edit;
        //  Panel_Titulo.Caption:='Modificando domicilio especial';
        //  Nro_dom_esp.Enabled:=True;
        //  Piso_dpto.Enabled:=True;
        //  CheckBox1.Enabled:=True;
        //  CheckBox1.Checked:=False;
        //  BuscaCalle.Enabled:=True;
        //  BuscaBarrio.Enabled:=True;
        //  Modifica.Enabled:=False;
        //  confirma.Enabled:=True;
        //  cancela.enabled:=True;
        //end;

        //procedure TDatProp.FormActivate(Sender: TObject);
        //    begin
        //      Inmuebles.Open;
        //    Inmuebles.FindKey([Data_Tasa.InmueblesCircunscripcion.Value,
        //    Data_Tasa.InmueblesSeccion.Value, Data_Tasa.InmueblesManzana.Value,
        //    Data_Tasa.InmueblesParcela.Value, Data_Tasa.InmueblesP_H.Value]);

        //  aux_barrio:=Data_Tasa.InmueblesNom_Barrio_Dom_Esp.Value;
        //  aux_calle:=Data_Tasa.InmueblesNom_Calle_Dom_Esp.Value;
        //  aux_nro:=Data_Tasa.InmueblesNro_Dom_Esp.AsString;
        //  aux_ciudad:=Data_Tasa.InmueblesCiudad_Dom_Esp.Value;
        //  aux_cod_postal:=Data_Tasa.InmueblesCod_postal.AsString;
        //  aux_provincia:=Data_Tasa.InmueblesProvincia_Dom_Esp.Value;
        //  aux_pais:=Data_Tasa.InmueblesPais_Dom_Esp.Value;
        //  aux_email:=Data_Tasa.InmueblesEmail_envio_cedulon.Value;
        //  aux_telefono:=Data_Tasa.InmueblesTelefono.Value;
        //  aux_celular:=Data_Tasa.InmueblesCelular.Value;
        //  aux_cuit:= Data_Tasa.INMUEBLEScuil.Value;

        //  Panel_Trabajo.Enabled:=False;
        //  Modifica.Enabled:=True;
        //  Confirma.Enabled:=False;
        //  Cancela.Enabled:=False;
        //  CheckBox1.Enabled:=False;
        //  CheckBox1.Checked:=False;
        //  BuscaCalle.Enabled:=False;
        //  BuscaBarrio.Enabled:=False;
        //end;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        ///BAJA
        ///
        //    procedure TGestInm.BajaClick(Sender: TObject);
        //    var
        //        permiso:smallint;
        //begin
        //permiso:=Verificar_Permiso_v2(PriTasa.usuario,'BAJAINM');
        //if permiso=0 then
        //begin
        //Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //Exit
        //end;
        //    with Query_Deuda do
        //begin
        //ParamByName('circunscripcion').AsInteger := Data_Tasa.INMUEBLESCircunscripcion.Value;
        //ParamByName('seccion').AsInteger         := Data_Tasa.INMUEBLESseccion.Value;
        //ParamByName('manzana').AsInteger         := Data_Tasa.INMUEBLESmanzana.Value;
        //ParamByName('parcela').AsInteger         := Data_Tasa.INMUEBLESparcela.Value;
        //ParamByName('p_h').AsInteger             := Data_Tasa.INMUEBLESp_h.Value;
        //Open;
        //end;
        //if (Query_DeudaCOLUMN1.Value>0) then
        //begin
        //Application.MessageBox('No se puede dar de baja el Inmueble por tener deuda',
        //                        'SIIMVA-Error',MB_ICONERROR+MB_OK);
        //Query_Deuda.Close;
        //Exit;
        //end
        //else
        //begin
        //    Application.CreateForm(TAutoriza, Autoriza);
        //    Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='BAJA DE INMUEBLE';
        //    if (Autoriza.ShowModal<> mrOK) then
        //    begin
        //    Autoriza.Free;
        //    Query_Deuda.Close;
        //    Exit;
        //    end;
        //    try
        //    Data_Tasa.Siimva.StartTransaction;
        //    // Auditoria
        //    Data_Tasa.AUDITOR_V2.ParamByName('@usuario').AsString        := PriTasa.usuario;
        //    Data_Tasa.AUDITOR_V2.ParamByName('@autorizacion').AsString   := '';//Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //    Data_Tasa.AUDITOR_V2.ParamByName('@identificacion').AsString := Rellena_Izquierda('0',2, IntToStr(Data_Tasa.INMUEBLEScircunscripcion.Value)) + '-'
        //        + Rellena_Izquierda('0',2, IntToStr(Data_Tasa.INMUEBLESseccion.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESmanzana.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESparcela.Value)) + '-'
        //        + Rellena_Izquierda('0',3, IntToStr(Data_Tasa.INMUEBLESp_h.Value));
        //    Data_Tasa.AUDITOR_V2.ParamByName('@observaciones').AsString  := Autoriza.Memo1.Lines.Text;
        //    Data_Tasa.AUDITOR_V2.ParamByName('@proceso').AsString        := 'BAJA DE INMUEBLE';
        //    Data_Tasa.AUDITOR_V2.ParamByName('@detalle').AsString        := ' ';
        //    Data_tasa.AUDITOR_V2.Prepare;
        //    Data_Tasa.AUDITOR_V2.ExecProc;
        //    Elimina_parcela_x_inmueble();
        //    Data_Tasa.Inmuebles.Delete;
        //    Data_Tasa.Siimva.Commit;
        //    Autoriza.Free;
        //    except
        //    Data_Tasa.Siimva.Rollback;
        //    Application.MessageBox('Se produjo un error en la baja del inmueble. ',
        //        'SIIMVA-Error', MB_ICONERROR + MB_OK);
        //    Autoriza.Free;
        //    end;
        //end;
        //Query_Deuda.Close;
        //end;

        //Query_deuda
        // SELECT SUM(DEBE)-SUM(HABER)
        // FROM CTASCTES_INMUEBLES
        // WHERE
        // CIRCUNSCRIPCION =:circunscripcion AND
        // SECCION=:seccion AND
        // MANZANA=:manzana AND
        // PARCELA=:parcela AND
        // P_H=:p_h

        //procedure TGestInm.Elimina_parcela_x_inmueble();
        //begin
        //    LimpiarParametrosConsulta(Data_Tasa.sqlElimina_Parcelas_x_Inmueble);
        //with Data_Tasa.sqlElimina_Parcelas_x_Inmueble do
        //begin
        //    ParamByName('cir').AsInteger := Data_Tasa.INMUEBLESCircunscripcion.Value;
        //ParamByName('sec').AsInteger := Data_Tasa.INMUEBLESseccion.Value;
        //ParamByName('man').AsInteger := Data_Tasa.INMUEBLESmanzana.Value;
        //ParamByName('par').AsInteger := Data_Tasa.INMUEBLESparcela.Value;
        //ParamByName('p_h').AsInteger := Data_Tasa.INMUEBLESp_h.Value;
        //ExecSQL;
        //end;

        //end;

        // sqlElimina_Parcelas_x_Inmueble
        // delete
        // from Parcelas_x_Inmueble
        // where
        // circunscripcion=:cir and
        // seccion=:sec and
        // manzana=:man and
        // parcela_unificada=:par AND
        // p_h_unificado=:p_h



        [HttpGet]
        public IActionResult GetDatosBaldio(int cir, int sec, int man, int par, int p_h)
        {
            try
            {
                var datos = _InmueblesService.GetDatosBaldio(cir, sec, man, par, p_h);

                if (datos == null)
                {
                    return NotFound(new { message = "No se encontraron datos para el baldío especificado." });
                }

                return Ok(datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Ocurrió un error al obtener los datos del baldío.",
                    error = ex.Message
                });
            }
        }


         [HttpGet]
        public IActionResult GetInmueblesByConcepto(int cod_concepto)
        {
            try
            {
                var inmuebles = _InmueblesService.GetInmueblesByConcepto(cod_concepto);

                if (inmuebles.Count() == 0)
                {
                    return NotFound(new { message = "No se encontraron datos para este concepto." });
                }

                return Ok(inmuebles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Ocurrió un error al obtener los datos de Inmuebles por concepto.",
                    error = ex.Message
                });
            }
        }






    }
}
