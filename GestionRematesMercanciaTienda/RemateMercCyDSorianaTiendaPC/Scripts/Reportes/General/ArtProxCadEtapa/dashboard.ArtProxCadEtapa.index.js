$(function () {
    $('#FechaArtProxCadEtapaDate input').datepicker({
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        format: 'yyyy-mm-dd'
    });
    //Evento para el drop down de Jede de Departamento
    $("#Id_Num_DptoProxCadEtapa").change(function () {
        var ddDptoProxCadEtapa = $('#Id_Num_DptoProxCadEtapa').val();
        var ddId_Categoria = $("#Id_Categoria");
        $.ajax({
            type: 'GET',
            cache: false,
            url: '../Reportes/iniciarComboCatRemPorEtapaPorJefe',
            data: { jefedepto: ddDptoProxCadEtapa },
            success: function (data) {
                ddId_Categoria.empty();
                ddId_Categoria.append($('<option></option>').val('-1').html('Seleccione'));
                for (var i = 0; i < data.length; i++) {
                    var x = data[i].Value;
                    var y = data[i].Text;
                    ddId_Categoria.append($('<option></option>').val(x).html(y));
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Ocurrio un error al cargar (Listado Categoria): " + thrownError);
            }
        });

    });
    //Evento del Boton de buscar folio buscar folio para la autorizacion
    $(".btn-artproxcadetapa").click(function (event) {
        var isAllValid = true;

        if ($('#FechaArtProxCadEtapa').val() == "") {
            isAllValid = false;
            var $div = $('#FechaArtProxCadEtapaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#FechaArtProxCadEtapaDate').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#Id_Num_DptoProxCadEtapa').val() == "-1") {
            isAllValid = false;            
            var $div = $('#Id_Num_DptoProxCadEtapa').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Id_Num_DptoProxCadEtapa').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#Id_Categoria').val() == "-1") {
            isAllValid = false;            
            var $div = $('#Id_Categoria').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Id_Categoria').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if ($('#Id_TipoVencimiento').val() == "-1") {
            isAllValid = false;            
            var $div = $('#Id_TipoVencimiento').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Id_TipoVencimiento').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        if (isAllValid) {
            BuscarArtProxCadPorEtapa();
        }

    });

});
function BuscarArtProxCadPorEtapa() {
    
    var Jefe = $("#Id_Num_DptoProxCadEtapa").val();
    var categoria = $("#Id_Categoria").val();
    var tipovencimiento = $("#Id_TipoVencimiento").val();
    var fecha = $("#FechaArtProxCadEtapa").val();

    $.ajax({
        type: 'GET',
        cache: false,
        url: '../Reportes/ObtenerGridReporteArtRemProxCadEtapa',
        data: { usuario: Jefe, categoria: categoria, opcion: tipovencimiento, fecha: fecha },
        success: function (data) {
            $('#divResults').html(data);
            $('#Reporte').show();
            pintartabla();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ocurrio un error al cargar (Articulos Proximos a Caducar por Etapa): " + thrownError);
        }

    });
}


function pintartabla() {

    $('.gvv').DataTable({
        dom: '<"html5buttons"B>lTfgitp',
        "pageLength": 50
       // , buttons: ['csv', 'excel', 'pdf', 'print']
        ,buttons: [
           
        ]     
    });
    $('.dataTables_filter').addClass('text-center');
    $('.dataTables_paginate').addClass('text-right');
    //$('.html5buttons').addClass('btn-danger');
    //$('.buttons-html5').addClass('btn-danger');

}