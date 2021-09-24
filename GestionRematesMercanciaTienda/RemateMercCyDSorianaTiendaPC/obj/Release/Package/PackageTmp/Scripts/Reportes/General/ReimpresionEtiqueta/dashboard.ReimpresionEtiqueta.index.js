$(function () {

    $('#FechaBitacoraDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd',
    }).on('changeDate', function (value, date) {
        LlenarListFolio();
    });

    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-searchreimpetiqueta").click(function (event) {
        var isAllValid = true;

        if ($('#FechaEtiqueta').val() == "") {            
            isAllValid = false;
            var $div = $('#FechaEtiquetaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");

        }
        else {
            var $div = $('#FechaEtiquetaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");

        }
        if ($('#FolCapEtiqueta').val() == "-1") {
            isAllValid = false;
            //var $div = $('#FolCap').parent();
            //var $span = $div.children()[2];
            //$span.setAttribute("style", "visibility:visible");
            var $div = $('#FolCapEtiqueta').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");


        }
        else {
            var $div = $('#FolCapEtiqueta').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
            //var $div = $('#FolCap').parent();
            //var $span = $div.children()[2];
            //$span.setAttribute("style", "visibility:hidden");

        }
        if (isAllValid) {
            BuscarEtiquetas();
        }
    });
});

function BuscarEtiquetas() {    
    var FechaFolio = $("#FechaEtiqueta").val();
    var FolCap = $("#FolCapEtiqueta").val();
    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReImpEtiqueta',
        data: { fecha: FechaFolio, folio: FolCap },
        success: function (data) {
            $('#divResults').html(data);
            pintartabla();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ocurrio un error al cargar (Etiqueta): " + thrownError);
        }

    });
}

function LlenarListFolio() {
    var fecha = $("#FechaEtiqueta").val();
    
    ddlFolCap = $('#FolCapEtiqueta');

    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/iniciarComboFolioReImpEtiqueta',
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

function pintartabla() {

    $('.gvv').DataTable({
        dom: '<"html5buttons"B>lTfgitp',
        "pageLength": 50,
        buttons: [
           // { extend: 'pdf', title: 'Reimpresion de Etiquetas', className: 'btn-danger' }
        ]
    });
    $('.dataTables_filter').addClass('text-center');
    $('.dataTables_paginate').addClass('text-right');
    //$('.html5buttons').addClass('btn-danger');
    //$('.buttons-html5').addClass('btn-danger');

}