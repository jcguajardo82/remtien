$(function () {
    $('#FechaCapMciaCaducaDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd',
    }).on('changeDate', function (value, date) {
        LlenarListFolioCapMciaCad();
    });

    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-capmciacad").click(function (event) {
        var isAllValid = true;

        if ($('#FechaCapMciaCaduca').val() == "") {
            isAllValid = false;
            var $div = $('#FechaCapMciaCaducaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FechaCapMciaCaducaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#FolCapMciaCaduca').val() == "-1") {
            isAllValid = false;            
            var $div = $('#FolCapMciaCaduca').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FolCapMciaCaduca').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if (isAllValid) {
            BuscarFolioMciaCadAutorizar();
        }

    });

});

function LlenarListFolioCapMciaCad() {
    var fecha = $("#FechaCapMciaCaduca").val();    
    var ddlFolCap = $('#FolCapMciaCaduca');

    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/iniciarComboFolioCapMciaCaducar',
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
    var FolCap = $("#FolCapMciaCaduca").val();
    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReporteCapturaMercancíaCaducar',
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
            { extend: 'pdf', title: 'Reporte de Captura de Mercancía por Caducar', className: 'btn-danger' }
        ]
    });
    $('.dataTables_filter').addClass('text-right');
    $('.dataTables_paginate').addClass('text-right');
    $('.html5buttons').addClass('btn-danger');
    $('.buttons-html5').addClass('btn-danger');

}
