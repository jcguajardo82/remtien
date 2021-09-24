$(function () {
    $('#FechaActaDesctruccionDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd',
    }).on('changeDate', function (value, date) {
        LlenarListFolio();
    });

    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-actdestruccion").click(function (event) {
        var isAllValid = true;

        if ($('#FechaActaDesctruccion').val() == "") {
            isAllValid = false;
            var $div = $('#FechaActaDesctruccionDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FechaActaDesctruccionDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#FolActaDesctruccion').val() == "-1") {
            isAllValid = false;
            var $div = $('#FolActaDesctruccion').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FolActaDesctruccion').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if (isAllValid) {
            BuscarFolioMciaCadAutorizar();
        }

    });

});

function LlenarListFolio() {
    var fecha = $("#FechaActaDesctruccion").val();
    var ddlFolCap = $('#FolActaDesctruccion');

    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/iniciarComboFolioActaDestruccion',
        data: { fecha: fecha },
        success: function (data) {
            ddlFolCap.empty();
            ddlFolCap.append($('<option></option>').val('-1').html('Seleccione'));
            for (var i = 0; i < data.length; i++) {
                var x = data[i].Value;
                var y = data[i].Text;
                ddlFolCap.append($('<option></option>').val(x).html(y));
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ocurrio un error al cargar (Listado Folio): " + thrownError);
        }
    });
}

function BuscarFolioMciaCadAutorizar() {
    var FolCap = $("#FolActaDesctruccion").val();
    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReporteActaDestruccion',
        data: { folio: FolCap },
        success: function (data) {
            $('#divResults').html(data);
            pintartabla();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ocurrio un error al cargar (Folio Mercancía Caduca): " + thrownError);
        }

    });
}

function pintartabla() {

    $('.gvv').DataTable({
        dom: '<"html5buttons"B>lTfgitp',
        "pageLength": 50,
        buttons: [
            { extend: 'pdf', title: 'Reporte de Acta de Destrucción.', className: 'btn-danger', orientation: 'landscape', pageSize: 'LEGAL' }
        ]
    });
    $('.dataTables_filter').addClass('text-right');
    $('.dataTables_paginate').addClass('text-right');
    $('.html5buttons').addClass('btn-danger');
    $('.buttons-html5').addClass('btn-danger');

}
