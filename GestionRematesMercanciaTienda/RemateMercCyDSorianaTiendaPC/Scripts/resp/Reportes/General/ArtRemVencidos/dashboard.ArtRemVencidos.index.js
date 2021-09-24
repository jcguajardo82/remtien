$(function () {
    $('#FechaArtRemVencidosDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd'
    });

    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-artremven").click(function (event) {
        var isAllValid = true;

        if ($('#FechaArtRemVencidos').val() == "") {
            isAllValid = false;
            var $div = $('#FechaArtRemVencidosDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FechaArtRemVencidosDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        
        if (isAllValid) {
            BuscarArtRematesVencidos();
        }

    });
    $('.dataTables_wrapper').addClass('style', 'overflow:auto;');
});

function BuscarArtRematesVencidos() {
    var fecha = $("#FechaArtRemVencidos").val();
    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReporteArtRemVencidos',
        data: { fecha: fecha },
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
            { extend: 'pdf', title: 'Reporte Artículos de Remate Vencidos.', className: 'btn-danger' }
        ]
    });
    $('.dataTables_filter').addClass('text-right');
    $('.dataTables_paginate').addClass('text-right');
    $('.html5buttons').addClass('btn-danger');
    $('.buttons-html5').addClass('btn-danger'); 
    $('#divResults').find('div.dataTables_wrapper').first().attr('id', 'treporte');
    $("#treporte").attr("style", "overflow:auto;");
}
