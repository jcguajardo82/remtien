$(function () {
    $('#FechaMermaDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd'
    });
    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-merma").click(function (event) {
        var isAllValid = true;

        if ($('#FechaMerma').val() == "") {
            isAllValid = false;
            var $div = $('#FechaMermaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FechaMermaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#IdJefeMerma').val() == "-1") {
            isAllValid = false;
            var $div = $('#IdJefeMerma').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#IdJefeMerma').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
       
        if (isAllValid) {
            BuscarMerma();
        }

    });

});
function BuscarMerma() {

    var Jefe = $("#IdJefeMerma").val();
    var fecha = $("#FechaMerma").val();

    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReporteMerma',
        data: { fecha: fecha ,usuario: Jefe},
        success: function (data) {
            $('#divResults').html(data);
            $('#Reporte').show();
            pintartabla();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ocurrio un error al cargar (Merma): " + thrownError);
        }

    });
}


function pintartabla() {

    $('.gvv').DataTable({
        dom: '<"html5buttons"B>lTfgitp',
        "pageLength": 50,
        buttons: [
            //{ extend: 'pdf', title: 'Reporte Sugerido de Merma', className: 'btn-danger' }
        ]
    });
    $('.dataTables_filter').addClass('text-center');
    $('.dataTables_paginate').addClass('text-right');
    //$('.html5buttons').addClass('btn-danger');
    //$('.buttons-html5').addClass('btn-danger');

}