var $trporc;
var tipobusquedad;
var ArrayPorcBorrar = [];

$(function () {
    //Evento para el drop down de Periodicidad Modal para editar
    $("#Id_Periodicidad_Modal").change(function () {
        var ddPeriodicidad = $('#Id_Periodicidad_Modal').val();

        switch (ddPeriodicidad) {
            case "1":
                $("#modTxtDiaSemana").val("0");
                $("#modTxtDiaSemana").prop("disabled", true);
                $("#modTxtDiaMes").prop("disabled", false);
                break;
            case "3":
                $("#modTxtDiaMes").val("");
                $("#modTxtDiaMes").prop("disabled", true);
                $("#modTxtDiaSemana").prop("disabled", false);
                break;
            default:
                $("#modTxtDiaSemana").prop("disabled", false);
                $("#modTxtDiaMes").prop("disabled", false);
        }
        //if (ddPeriodicidad == "1") {
        //    $("#modTxtDiaSemana").val("0");
        //    $("#modTxtDiaSemana").prop("disabled", true);
        //}
        //else {
        //    $("#modTxtDiaSemana").prop("disabled", false);
        //}      
    });

    //Evento para el drop down de Periodicidad
    $("#Id_Periodicidad").change(function () {
        var ddPeriodicidad = $('#Id_Periodicidad').val();
        switch (ddPeriodicidad) {
            case "1":
                $("#DiaSemana").val("0");
                $("#DiaSemana").prop("disabled", true);
                $("#DiaMes").prop("disabled", false);
                break;
            case "3":
                $("#DiaMes").val("");
                $("#DiaMes").prop("disabled", true);
                $("#DiaSemana").prop("disabled", false);
                break;
            default:
                $("#DiaSemana").prop("disabled", false);
                $("#DiaMes").prop("disabled", false);
        }

        //if (ddPeriodicidad == "1") {
        //    $("#DiaSemana").val("0");
        //    $("#DiaSemana").prop("disabled", true);
        //}
        //else {          
        //    $("#DiaSemana").prop("disabled", false);
        //}
        
    });
    //Evento para el drop down de Dia de la Semanan
    $("#DiaSemana").change(function () {
        var ddPeriodicidad = $('#DiaSemana').val();
        if (ddPeriodicidad == "8") {
            $("#DiaAviso").val('');
            $("#DiaAviso").prop("disabled", true);
            $("#DiaAviso").val('0');
        }
        else {
            $("#DiaAviso").prop("disabled", false);
        }        
    });

    //Evento para la caja de texto de Dia de Aviso

    $("#DiaAviso").on('keyup change', function () {
        if ($("#DiaAviso").val() > 3 || $("#DiaAviso").val() == 0) {
            alert("Los días de aviso no pueden ser mayor a 3 o igual a 0");            
            $("#DiaAviso").val("")
            return false;
        }
        
    })
    
    /*
    $("#DiaAviso").on('keydown', function (event) {
        if (event.keyCode == 9 || event.keyCode == 13) {   //tab pressed
            if ($("#DiaAviso").val() > 3) {
                alert("Los días de aviso no pueden ser mayor a 3");
                return false;
            }           
        }
    });
    */
    //Evento para el boton de Historia de Categorias

    $(".btn-buscarcathisteli").click(function (event) {
        
        ddlFmto_Tienda = $("#CatEliFtoTiendaModal").val();
        ddTipoMcia = $("#Tipo_MciaModal").val();
        BuscarCatHistEliminadas(ddlFmto_Tienda, ddTipoMcia);
    });

    //Muestra el modal para la consulta de historia 
    $(".btn-historico").click(function (event) {
        var ftotienda = $('#Fmto_Tienda').val();
        var tipomcia = $('#Tipo_Mcia').val();

        $('#CatEliFtoTiendaModal').val(ftotienda);
        $('#Tipo_MciaModal').val(tipomcia);

        $('#ModalDelHist').html("Categorias Historico");
        $("#Panel_Cateliminadas_Content").attr("style", "height:auto;overflow:auto;");
        $("#tbodyHistEli").html("");
        //$("#Panel_Cateliminadas_Content").html("");
        tipobusquedad = "HC";
        $("#ConsultaCatDelHis").modal();
       
    });

    //Muestra el modal para los datos de eliminadas
    $(".btn-eliminadas").click(function (event) {

        var ftotienda = $('#Fmto_Tienda').val();
        var tipomcia = $('#Tipo_Mcia').val();

        $('#CatEliFtoTiendaModal').val(ftotienda);
        $('#Tipo_MciaModal').val(tipomcia);

        $('#ModalDelHist').html("Categorias Eliminadas");
        $("#Panel_Cateliminadas_Content").attr("style", "height:auto;overflow:auto;");
        $("#tbodyHistEli").html("");
        //$("#Panel_Cateliminadas_Content").html("");
        tipobusquedad = "CE";
        $("#ConsultaCatDelHis").modal();
    });

    //Evento para el boton agregar porcentajes

    $(".btnAddPorc").click(function (event) {
        var ArrayCate = [];
        ddlFmto_Tienda = $("#Fmto_Tienda").val();
        ddTipoMcia = $('#Tipo_Mcia').val();
        ddlCategoria = $("#modTxtIdKeyCat").val();
                
        var countRows = $('#tbodyCatPorc tr').length;

        if (countRows == 1) {
            $rowfirst = $('#tbodyCatPorc tr:last');
            $tdfirstA = $rowfirst.find('td')[0];
            $firstinpA = $tdfirstA.childNodes;
            var firstA = parseInt($firstinpA[0].value == undefined ? $firstinpA[1].value : $firstinpA[0].value);

            //Obtenemos el valor de	% Remate Penultimo Row
            $inifirstRemate = $rowfirst.find('td')[1];
            $firstinpRemate = $inifirstRemate.childNodes;
            var firstRemate = parseInt($firstinpRemate[0].value == undefined ? $firstinpRemate[1].value : $firstinpRemate[0].value);

            //Obtenemos el valor de	% Merma Penultimo Row
            $tdfirstMerma = $rowfirst.find('td')[2];
            $firstinpMerma = $tdfirstMerma.childNodes;
            var firstMerma = parseInt($firstinpMerma[0].value == undefined ? $firstinpMerma[1].value : $firstinpMerma[0].value);


            if (firstA == '') {                
                alert("El valor del Campo 'A' no puede ser vacío");
                return false;
            }
            if (firstRemate == '') {
                alert("El valor del Campo 'Remate' no puede ser vacío");
                return false;
            }
            if (firstMerma == '') {
                alert("El valor del Campo 'Merma' no puede ser vacío");
                
                return false;
            }
            else {
                $('#tblCatPorc').find("tr").each(function (index) {
                    item = {};
                    var i = 0;
                    $(this).find('td').each(function (i) {
                        switch (i) {
                            
                             //case 0:                        
                             //    item["FmtoTienda"] = ddlFmto_Tienda;
                             //    item["TipoMcia"] = ddTipoMcia;
                             //    item["Categoria"] = ddlCategoria;
                             //    var tdpat = $(this);
                             //    var tdchild = tdpat.children()
                             //    item["DiaInicio"] = tdchild.val();
                             //    break;
                                 
                            case 0:
                                item["FmtoTienda"] = ddlFmto_Tienda;
                                item["TipoMcia"] = ddTipoMcia;
                                item["Categoria"] = ddlCategoria;
                                item["DiaInicio"] = 0;

                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["DiaFin"] = tdchild.val();
                                break;
                            case 1:
                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["RebajaVta"] = tdchild.val();
                                break;
                            case 2:
                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["RebajaMerma"] = tdchild.val();
                                ArrayCate.push(item);
                                break;
                        }
                        i++;
                    });
                });
                GuardarPorcentajePorCategoria(ArrayCate);
            }
        }

        if (countRows > 1) {
            $rowfirst = $('#tbodyCatPorc tr:last').prev();
            $rowlast = $('#tbodyCatPorc tr:last');

            //Obtenemos el valor de A del Penultimo Row           
            $initdA = $rowfirst.find('td')[0];
            $iniinpA = $initdA.childNodes;
            var iniA = parseInt($iniinpA[0].value == undefined ? $iniinpA[1].value : $iniinpA[0].value);
            //Obtenemos el valor de A del Ultimo Row            
            $fintdA = $rowlast.find('td')[0];
            $fininpA = $fintdA.childNodes;
            var finA = parseInt($fininpA[0].value == undefined ? $fininpA[1].value : $fininpA[0].value);

            //Obtenemos el valor de	% Remate Penultimo Row
            $initdRemate = $rowfirst.find('td')[1];
            $iniinpRemate = $initdRemate.childNodes;
            var iniRemate = parseInt($iniinpRemate[0].value == undefined ? $iniinpRemate[1].value : $iniinpRemate[0].value);

            //Obtenemos el valor de	% Remate Ultimo Row
            $fintdRemate = $rowlast.find('td')[1];
            $fininpRemate = $fintdRemate.childNodes;
            var finRemate = parseInt($fininpRemate[0].value == undefined ? $fininpRemate[1].value : $fininpRemate[0].value);

            //Obtenemos el valor de	% Merma Penultimo Row
            $initdMerma = $rowfirst.find('td')[2];
            $iniinpMerma = $initdMerma.childNodes;
            var iniMerma = parseInt($iniinpMerma[0].value == undefined ? $iniinpMerma[1].value : $iniinpMerma[0].value);

            //Obtenemos el valor de	% Remate Ultimo Row
            $fintdMerma = $rowlast.find('td')[2];
            $fininpMerma = $fintdMerma.childNodes;
            var finMerma = parseInt($fininpMerma[0].value == undefined ? $fininpMerma[1].value : $fininpMerma[0].value);

            if (iniA == "" || finA == "") {
                alert("El valor del Campo 'A' no puede ser vacío");
                return false;
            }
            if (iniRemate == "" || finRemate == "") {
                alert("El valor del Campo 'Remate' no puede ser vacío");
                return false;
            }
            if (iniMerma == "" || finMerma == "") {
                alert("El valor del Campo 'Merma' no puede ser vacío");
                return false;
            }

            if (iniA >= finA) {
                alert("El valor del Campo 'A' del ultimo renglon, no debe ser Menor que el campo 'A' del anterior Renglon");
                return false;
            }
            if (iniRemate >= finRemate) {
                alert("El valor del Campo Remate del ultimo renglon, no debe ser Menor que el campo Remate del anterior Renglon");
                return false;
            }
            if (finMerma >= iniMerma) {
                alert("El valor del Campo Merma del ultimo renglon, no debe ser Mayor que el campo Merma del anterior Renglon");
                return false;
            }
            else {
                $('#tblCatPorc').find("tr").each(function (index) {
                    item = {};
                    var i = 0;
                    $(this).find('td').each(function (i) {
                        switch (i) {
                            /*
                             case 0:                        
                                 item["FmtoTienda"] = ddlFmto_Tienda;
                                 item["TipoMcia"] = ddTipoMcia;
                                 item["Categoria"] = ddlCategoria;
                                 var tdpat = $(this);
                                 var tdchild = tdpat.children()
                                 item["DiaInicio"] = tdchild.val();
                                 break;
                                 */
                            case 0:
                                item["FmtoTienda"] = ddlFmto_Tienda;
                                item["TipoMcia"] = ddTipoMcia;
                                item["Categoria"] = ddlCategoria;
                                item["DiaInicio"] = 0;

                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["DiaFin"] = tdchild.val();
                                break;
                            case 1:
                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["RebajaVta"] = tdchild.val();
                                break;
                            case 2:
                                var tdpat = $(this);
                                var tdchild = tdpat.children()
                                item["RebajaMerma"] = tdchild.val();
                                ArrayCate.push(item);
                                break;
                        }
                        i++;
                    });
                });
                GuardarPorcentajePorCategoria(ArrayCate);
            }
        }
        
    });
    //Evento para el boton de borrar un porcentaje
    $("#tblCatPorc").on('click', '.btn-delPor', function () {
        $tr = $(this).closest('tr');
        var i = 0;
        var porde = "";
        var pora = "";
        var porremate = "";
        var pormerma = "";
        var item = {};
        var ddlFmto_Tienda = $("#Fmto_Tienda").val();
        var ddTipoMcia = $('#Tipo_Mcia').val();
        var ddlCategoria = $("#modTxtIdKeyCat").val();

        $tr.find("td").each(function (index) {
            var td = "";
            var inp = "";
            switch (i) {
                case 0:
                    td = $(this);
                    inp = td.find("input:first");
                    pora = inp.val();
                    item["FmtoTienda"] = ddlFmto_Tienda;
                    item["TipoMcia"] = ddTipoMcia;
                    item["Categoria"] = ddlCategoria;
                    item["DiaInicio"] = 0;
                    item["DiaFin"] = pora;
                    break;
                case 1:
                    td = $(this);
                    inp = td.find("input:first");                    
                    porremate = inp.val();
                    item["RebajaVta"] = porremate;
                    break;
                case 2:
                    td = $(this);
                    inp = td.find("input:first");
                    pormerma = inp.val();
                    item["RebajaMerma"] = pormerma;
                    
                    break;
                //case 3:
                //    td = $(this);
                //    inp = td.find("input:first");
                //    pormerma = inp.val();
                //    break;
                default:
            }
             i++;
        });
      
        $trporc = $tr;
        if (pora == "" && porremate == "" && pormerma == "") {
            $('#divRenderPorCap').html("");
            $('#divRenderPorCap').append("Esta Seguro de Eliminar el Registro con el dia de inicio: ?");
            $("#modalBorrarPorcentajeCapturado").modal();           
        }
        else {
            $('#divRenderPorCap').html("");
            $('#divRenderPorCap').append("Esta Seguro de Eliminar el Registro con el dia de inicio: " + porde);
            $("#modalBorrarPorcentajeCapturado").modal();
            ArrayPorcBorrar.push(item);
        }
        //$(this).closest('tr').remove();
    });

    //Borrado de Renglones de Porcentajes
    $(".btndelRangoCapturado").click(function (event) {
        if (ArrayPorcBorrar.length > 0) {
            BorrarPorcentajePorCategoria(ArrayPorcBorrar);
        }
        //$trporc.remove();
    });

    $(".btn-addporccat").click(function (event) {

        ModPorFmto_Tienda = $('#ModPorcFmtoTienda').val();
        ModddTipoMcia = $('#Tipo_Mcia').val();
        ModPorCategoria_val = $('#ModPorcCategoria').val();
        ModPorPeriodicidad_val = $('#ModPorcPeriodicidad').val();
        ModPortxtDiaMes_val = $('#ModPorcDiaMes').val();
        ModPortxtDiaSemana_val = $('#ModPorcDiaSemana').val();
        ModPortxtDiaAviso_val = $('#ModPorcDiaAviso').val();
        
        var ArrayCate = [];
        var item = {};
        var countRows = $('#tbodyCatPorc tr').length;
        var indicador = true;

        item["CveOperacion"] = "I";
        item["FmtoTienda"] = ModPorFmto_Tienda;
        item["TipoMcia"] = ModddTipoMcia;
        item["Categoria"] = ModPorCategoria_val;
        item["Periodicidad"] = ModPorPeriodicidad_val;
        item["DiaMes"] = ModPortxtDiaMes_val;
        item["DiaSemana"] = ModPortxtDiaSemana_val;
        item["DiaAviso"] = ModPortxtDiaAviso_val;

        ArrayCate.push(item);

        var $id = ModPorFmto_Tienda + "," + ModPorCategoria_val + "," + ModPorPeriodicidad_val + "," + ModPortxtDiaMes_val + "," + ModPortxtDiaSemana_val + "," + ModPortxtDiaAviso_val;
        var table = $("#tblCatPorc");
        var $newRow = $('<tr/>');

        if (countRows == 1) {
            $rowfirst = $('#tbodyCatPorc tr:last');
            $tdfirstA = $rowfirst.find('td')[0];
            $firstinpA = $tdfirstA.childNodes;
            var firstA = parseInt($firstinpA[0].value == undefined ? $firstinpA[1].value : $firstinpA[0].value);

            //Obtenemos el valor de	% Remate Penultimo Row
            $inifirstRemate = $rowfirst.find('td')[1];
            $firstinpRemate = $inifirstRemate.childNodes;
            var firstRemate = parseInt($firstinpRemate[0].value == undefined ? $firstinpRemate[1].value : $firstinpRemate[0].value);

            //Obtenemos el valor de	% Merma Penultimo Row
            $tdfirstMerma = $rowfirst.find('td')[2];
            $firstinpMerma = $tdfirstMerma.childNodes;
            var firstMerma = parseInt($firstinpMerma[0].value == undefined ? $firstinpMerma[1].value : $firstinpMerma[0].value);

            if (firstA == '') {
                alert("Capture el valor del campo 'A'");
                return false;
            }
            if (firstRemate == '') {
                alert("Capture el valor del campo 'Remate'");
                return false;
            }
            if (firstMerma == '') {
                alert("Capture el valor del campo 'Merma'");
                return false;
            }
        }

        if (countRows > 1) {            
            $rowfirst = $('#tbodyCatPorc tr:last').prev();
            $rowlast = $('#tbodyCatPorc tr:last');

            //Obtenemos el valor de A del Penultimo Row           
            $initdA = $rowfirst.find('td')[0];            
            $iniinpA = $initdA.childNodes;
            var iniA = parseInt($iniinpA[0].value == undefined ? $iniinpA[1].value : $iniinpA[0].value);

            //Obtenemos el valor de A del Ultimo Row            
            $fintdA = $rowlast.find('td')[0];
            $fininpA = $fintdA.childNodes;
            var finA = $fininpA[0].value == "" ? "" : (parseInt($fininpA[0].value == undefined ? $fininpA[1].value : $fininpA[0].value));

            //Obtenemos el valor de	% Remate Penultimo Row
            $initdRemate = $rowfirst.find('td')[1];
            $iniinpRemate = $initdRemate.childNodes;
            var iniRemate = parseInt($iniinpRemate[0].value == undefined ? $iniinpRemate[1].value : $iniinpRemate[0].value);

            //Obtenemos el valor de	% Remate Ultimo Row
            $fintdRemate = $rowlast.find('td')[1];
            $fininpRemate = $fintdRemate.childNodes;
            var finRemate = $fininpRemate[0].value == "" ? "" : (parseInt($fininpRemate[0].value == undefined ? $fininpRemate[1].value : $fininpRemate[0].value));

            //Obtenemos el valor de	% Merma Penultimo Row
            $initdMerma = $rowfirst.find('td')[2];
            $iniinpMerma = $initdMerma.childNodes;
            var iniMerma = parseInt($iniinpMerma[0].value == undefined ? $iniinpMerma[1].value : $iniinpMerma[0].value);

            //Obtenemos el valor de	% Remate Ultimo Row
            $fintdMerma = $rowlast.find('td')[2];
            $fininpMerma = $fintdMerma.childNodes;
            var finMerma = $fininpMerma[0].value == "" ? "" : (parseInt($fininpMerma[0].value == undefined ? $fininpMerma[1].value : $fininpMerma[0].value));

            if (iniA == "" || finA == "") {
                alert("El valor del Campo 'A' no puede ser vacío");
                return false;
            }
            if (iniRemate == "" || finRemate == "" ) {
                alert("El valor del Campo 'Remate' no puede ser vacío");
                return false;
            }
            if (iniMerma == "" || finMerma == "") {
                alert("El valor del Campo 'Merma' no puede ser vacío");
                return false;
            }

            //if (iniA >= finA) {
            //    alert("El valor del Campo 'A' del ultimo renglon, no debe ser Menor que el campo 'A' del anterior Renglon");
            //    return false;
            //}
            if (finA >= iniA) {                
                alert("El valor del Campo 'A' del ultimo renglon, no debe ser Mayor que el campo 'A' del anterior Renglon");
                return false;
            }
            if (iniRemate >= finRemate) {
                alert("El valor del Campo Remate del ultimo renglon, no debe ser Menor que el campo Remate del anterior Renglon");
                return false;
            }
            if (finMerma >= iniMerma) {
                alert("El valor del Campo Merma del ultimo renglon, no debe ser Mayor que el campo Merma del anterior Renglon");
                return false;
            }
            else {

                $newRow.attr("id", $id);
                //1 Row
                $td = $('<td/>');
                $textbox_1 = $("<input >").attr("type", "text").attr("class", "form-control");
                $textbox_1.focus();
                $td.append($textbox_1);
                $newRow.append($td);

                //2 Row
                $td = $('<td/>');
                $textbox = $("<input >").attr("type", "text").attr("class", "form-control");
                $td.append($textbox);
                $newRow.append($td);

                //3 Row
                $td = $('<td/>');
                $textbox = $("<input >").attr("type", "text").attr("class", "form-control");
                $td.append($textbox);
                $newRow.append($td);
                /*
                //4 Row
                $td = $('<td/>');
                $textbox = $("<input >").attr("type", "text").attr("class", "form-control");       
                $td.append($textbox);
                $newRow.append($td);
                */
                //5 Row
                $td = $('<td/>');
                $btn_del = $("<button/>").attr("class", "btn btn-danger btn-delPor");
                $btn_del.text("Eliminar");
                $btn_del.attr("id", $id);
                //$btn_del.attr("onclick", "BorrarRowCatPorc(this)");
                $td.append($btn_del);
                $newRow.append($td);
                table.append($newRow);
                $textbox_1.focus();
                //GuardarCategoria(ArrayCate);
            }
        }             
        else {
           
            $newRow.attr("id", $id);
            //1 Row
            $td = $('<td/>');
            $textbox_1 = $("<input >").attr("type", "text").attr("class", "form-control");            
            $td.append($textbox_1);
            $newRow.append($td);

            //2 Row
            $td = $('<td/>');
            $textbox = $("<input >").attr("type", "text").attr("class", "form-control");
            $td.append($textbox);
            $newRow.append($td);

            //3 Row
            $td = $('<td/>');
            $textbox = $("<input >").attr("type", "text").attr("class", "form-control");
            $td.append($textbox);
            $newRow.append($td);
            /*
            //4 Row
            $td = $('<td/>');
            $textbox = $("<input >").attr("type", "text").attr("class", "form-control");       
            $td.append($textbox);
            $newRow.append($td);
            */
            //5 Row
            $td = $('<td/>');
            $btn_del = $("<button/>").attr("class", "btn btn-danger btn-delPor");
            $btn_del.text("Eliminar");
            $btn_del.attr("id", $id);
            //$btn_del.attr("onclick", "BorrarRowCatPorc(this)");
            $td.append($btn_del);
            $newRow.append($td);
            table.append($newRow);
            $textbox_1.focus();
            //GuardarCategoria(ArrayCate);
        }
        

    })

    // Edita la Categoria Seleccionada
    $(".btn-AddPorGuarda").click(function (event) {
        var ArrayCate = [];
        ddlFmto_Tienda = $("#Fmto_Tienda").val();
        item = {};
        //$("#tbodyCatPorc").html("");
        /*
        ddCategoria_val_modal = $('#Cat_FtoTienda_Modal').val();
        ddCategoria_text_modal = $("#Cat_FtoTienda_Modal").find("option:selected").text();

        ddPeriodicidad_val_modal = $('#Id_Periodicidad_Modal').val();
        ddPeriodicidad_text_modal = $("#Id_Periodicidad_Modal").find("option:selected").text();

        txtDiaMes_val = $('#modTxtDiaMes').val();
        txtDiaSemana_val = $('#modTxtDiaSemana').val();
        txtDiaAviso_val = $('#modTxtDiaAviso').val();

        item["CveOperacion"] = "U";
        item["FmtoTienda"] = ddlFmto_Tienda;
        item["Categoria"] = ddCategoria_val_modal;
        item["Periodicidad"] = ddPeriodicidad_val_modal;
        item["DiaMes"] = txtDiaMes_val;
        item["DiaSemana"] = txtDiaSemana_val;
        item["DiaAviso"] = txtDiaAviso_val;
        ArrayCate.push(item);
        */
    })

    //Guardar todo el listado de las categorias agregadas.
    $(".btn-savecat").click(function (event) {
        var ArrayCate = [];
        ddlFmto_Tienda = $("#Fmto_Tienda").val();
        ddlTipoMcia = $("#Tipo_Mcia").val();

        $('#tblCatCad').find("tr").each(function (index) {
            item = {};
            var i = 0;
            $(this).find('td').each(function (i) {
                switch (i) {
                    case 0:                       
                        item["CveOperacion"] = "U";
                        item["FmtoTienda"] = ddlFmto_Tienda;
                        item["TipoMcia"] = ddlTipoMcia;
                        item["Categoria"] = $(this).text();
                        break;                       
                    case 1:
                        item["Periodicidad"] = $(this).text();
                        break;
                    case 2:
                        var tdpat = $(this);
                        var tdchild = tdpat.children()                       
                        item["DiaMes"] = tdchild.val();
                        break;
                    case 3:
                        var tdpat = $(this);
                        var tdchild = tdpat.children()                       
                        item["DiaSemana"] = tdchild.val();
                        break;
                    case 4:
                        var tdpat = $(this);
                        var tdchild = tdpat.children()                       
                        item["DiaAviso"] = tdchild.val();
                        break;
                    case 7:
                        ArrayCate.push(item);
                        var a = 0;
                        break;                        
                }
                i++;
            });
        });
        GuardarCategoria(ArrayCate);
        
    });
    //Borra la Categoria Seleccionada
    $(".btndelCat").click(function (event) {
        var ArrayCate = [];
        ddlFmto_Tienda = $("#Fmto_Tienda").val();

        $('#tblCatCad').find("tr").each(function (index) {
            var $trpat = $(this);
            var i = 0;
            if ($trpat.attr("id") == $("#modTxtIdCatDel").val()) {

                var array = $("#modTxtIdCatDel").val();
                array = array.split(",");               
                item = {};

                item["CveOperacion"] = "D";
                item["FmtoTienda"] = array[0];
                item["TipoMcia"] = array[1];
                item["Categoria"] = array[2];
                item["Periodicidad"] = array[3];
                item["DiaMes"] = array[4] == '' ? '0' : array[4];
                item["DiaSemana"] = array[5];
                item["DiaAviso"] = array[6];
                ArrayCate.push(item);
                GuardarCategoria(ArrayCate);
                $trpat.remove();

            }
        });
    });
    // Edita la Categoria Seleccionada
    $(".btnEdit").click(function (event) {

        var isAllValid = true;
        var ArrayCate = [];
        ddlFmto_Tienda = $("#Fmto_Tienda").val();
        item = {};
        
        ddTipoMcia_val_modal = $('#Tipo_Mcia_Modal').val();
        ddTipoMcia_text_modal = $("#Tipo_Mcia_Modal").find("option:selected").text();


        ddCategoria_val_modal = $('#Cat_FtoTienda_Modal').val();
        ddCategoria_text_modal = $("#Cat_FtoTienda_Modal").find("option:selected").text();
        
        ddPeriodicidad_val_modal = $('#Id_Periodicidad_Modal').val();
        ddPeriodicidad_text_modal = $("#Id_Periodicidad_Modal").find("option:selected").text();

        txtDiaMes_val = $('#modTxtDiaMes').val();
        txtDiaSemana_val = $('#modTxtDiaSemana').val();
        txtDiaAviso_val = $('#modTxtDiaAviso').val();

        //Valida dia de la semana
        if (txtDiaSemana_val == "0" && ddPeriodicidad_val_modal != '-1' && ddPeriodicidad_val_modal != '1') {
            isAllValid = false;
            var $div = $('#modTxtDiaSemana').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#modTxtDiaSemana').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        
        if (ddPeriodicidad_val_modal != '-1' && ddPeriodicidad_val_modal != '3') {
            if (txtDiaMes_val == "" || txtDiaMes_val > 31 || txtDiaMes_val == "0") {
                isAllValid = false;
                if (txtDiaMes_val > 31) {
                    alert("El Día no pueden ser mayor a 31 o igual a 0");
                    $('#modTxtDiaMes').focus();
                    return false;
                }
                else {
                    var $div = $('#modTxtDiaMes').parent();
                    var $span = $div.children()[2];
                    $span.setAttribute("style", "visibility:visible");
                    return false;
                }

            }
            else {
                var $div = $('#modTxtDiaMes').parent();
                var $span = $div.children()[2];
                $span.setAttribute("style", "visibility:hidden");
            }
        }
        if (txtDiaSemana_val != "8") {
            if ($("#modTxtDiaAviso").val() > 3 || $("#modTxtDiaAviso").val() == 0 || $("#modTxtDiaAviso").val() == "") {
                isAllValid = false;
                alert("Los días de aviso no pueden ser mayor a 3 o igual a 0");
                $("#modTxtDiaAviso").val("")
                return false;
            }
        }
       

        if (isAllValid) {

            item["CveOperacion"] = "U";
            item["FmtoTienda"] = ddlFmto_Tienda;
            item["TipoMcia"] = ddTipoMcia_val_modal;
            item["Categoria"] = ddCategoria_val_modal;
            item["Periodicidad"] = ddPeriodicidad_val_modal;
            item["DiaMes"] = txtDiaMes_val == "" ? 0 : txtDiaMes_val;
            item["DiaSemana"] = txtDiaSemana_val;
            item["DiaAviso"] = txtDiaAviso_val == "" ? 0 : txtDiaAviso_val;
            ArrayCate.push(item);

            GuardarCategoriaEditada(ArrayCate, ddlFmto_Tienda, ddTipoMcia_text_modal, ddCategoria_val_modal, ddCategoria_text_modal, ddPeriodicidad_val_modal, ddPeriodicidad_text_modal, txtDiaMes_val, txtDiaSemana_val, txtDiaAviso_val);
        }
  
        
    })
    //Agrega una nueva Categoria
    $(".btn-add").click(function (event) {

        var isAllValid = true;
        ddlFmto_Tienda = $('#Fmto_Tienda').val();
        ddlTipo_Mcia = $('#Tipo_Mcia').val();
        ddCategoria_val = $('#Cat_FtoTienda').val();
        ddCategoria_text = $("#Cat_FtoTienda").find("option:selected").text();

        ddPeriodicidad_val = $('#Id_Periodicidad').val();
        ddPeriodicidad_text = $("#Id_Periodicidad").find("option:selected").text();
        
        txtDiaMes_val = $('#DiaMes').val().trim();
        txtDiaSemana_val = $('#DiaSemana').val();
        txtDiaAviso_val = $('#DiaAviso').val().trim();
        
        //Valida el formato de tienda
        if (ddlFmto_Tienda == "-1") {
            isAllValid = false;
            var $div = $('#Fmto_Tienda').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
            
        }
        else {
            var $div = $('#Fmto_Tienda').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        //Valida el tipo de mercancia
        if (ddlTipo_Mcia == "-1") {
            isAllValid = false;
            var $div = $('#Tipo_Mcia').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Tipo_Mcia').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");         
        }
        //Valida la Categoria
        if (ddCategoria_val == "-1") {
            isAllValid = false;
            var $div = $('#Cat_FtoTienda').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Cat_FtoTienda').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }

        //Valida la Periodicidad
        if (ddPeriodicidad_val == "-1") {
            isAllValid = false;
            var $div = $('#Id_Periodicidad').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#Id_Periodicidad').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
        //Valida dia del mes
        if (ddPeriodicidad_val != '-1' && ddPeriodicidad_val != '3') {
            if (txtDiaMes_val == "" || txtDiaMes_val > 31) {
                //El Día no pueden ser mayor a 31 o igual a 0"
                isAllValid = false;
                if (txtDiaMes_val > 31) {
                    alert("El Día no pueden ser mayor a 31 o igual a 0");
                }
                else {
                    var $div = $('#DiaMes').parent();
                    var $span = $div.children()[2];
                    $span.setAttribute("style", "visibility:visible");
                }

            }
            else {
                var $div = $('#DiaMes').parent();
                var $span = $div.children()[2];
                $span.setAttribute("style", "visibility:hidden");
            }
        }       

        //Valida dia de la semana
        if (txtDiaSemana_val == "-1" && ddPeriodicidad_val != '-1' && ddPeriodicidad_val != '1') {
            isAllValid = false;
            var $div = $('#DiaSemana').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#DiaSemana').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }

        //Valida dia de Aviso
        //if ((txtDiaAviso_val == "" && ddPeriodicidad_val != '-1' && ddPeriodicidad_val == '1') || (ddPeriodicidad_val != '-1' && ddPeriodicidad_val != '1' && txtDiaSemana_val != '8' && txtDiaSemana_val != '-1')) {
        if (txtDiaAviso_val == "") {
            isAllValid = false;
            var $div = $('#DiaAviso').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:visible");
        }
        else {
            var $div = $('#DiaAviso').parent();
            var $span = $div.children()[2];
            $span.setAttribute("style", "visibility:hidden");
        }
       
        if (isAllValid) {
            var ArrayCate = [];
            var item = {};

            item["CveOperacion"] = "I";
            item["FmtoTienda"] = ddlFmto_Tienda;
            item["TipoMcia"] = ddlTipo_Mcia;
            item["Categoria"] = ddCategoria_val;
            item["Periodicidad"] = ddPeriodicidad_val;
            item["DiaMes"] = txtDiaMes_val == "" ? -1 : txtDiaMes_val;
            item["DiaSemana"] = txtDiaSemana_val;
            item["DiaAviso"] = txtDiaAviso_val;
            ArrayCate.push(item);

            GuardarCategoriaAgregada(ArrayCate, ddlFmto_Tienda, ddlTipo_Mcia, ddCategoria_text, ddCategoria_val, ddPeriodicidad_text, ddPeriodicidad_val, txtDiaMes_val, txtDiaSemana_val, txtDiaAviso_val);
        }
    })

    //$("#Fmto_Tienda").change(function () {
    //    BuscarCategorias();
    //});
     
    //Evento para el drop down de Tipo de Mercancia

    $("#Tipo_Mcia").change(function () {
        var tipomcia = $("#Tipo_Mcia").val();

        if (tipomcia != "-1") {
            $(".btn-historico").prop("disabled", false);
            $(".btn-eliminadas").prop("disabled", false);
            BuscarCategorias();
        }
        else {
            $(".btn-historico").prop("disabled", true);
            $(".btn-eliminadas").prop("disabled", true);
        }
        
    });

    //Evento para el drop down de Formato Tienda

    $("#Fmto_Tienda").change(function () {
        var formatotienda = $("#Fmto_Tienda").val();

        if (formatotienda != "-1") {
            $(".btn-historico").prop("disabled", false);
            $(".btn-eliminadas").prop("disabled", false);
            BuscarCategorias();
        }
        else {
            $(".btn-historico").prop("disabled", true);
            $(".btn-eliminadas").prop("disabled", true);
        }

    });

    $(".btn-eliminadas").prop("disabled", true);
    $(".btn-historico").prop("disabled", true);
});

function EditarCategoria(obj) {
    var array = obj.id;
    array = array.split(",");

    var FmtoTienda = array[0];
    var TipoMcia = array[1];
    var categoria = array[2];
    var period = array[3];
    var diames = array[4];
    var diasemana = array[5];
    var diaaviso = array[6];

    $("#modTxtIdKey").val(array);
    $("#Cat_FtoTienda_Modal").val(categoria);
    $("#Tipo_Mcia_Modal").val(TipoMcia);
    $('#Id_Periodicidad_Modal').val(period);
    $('#modTxtDiaMes').val(diames);
    $('#modTxtDiaSemana').val(diasemana == "" ? "0" : diasemana);
    $('#modTxtDiaAviso').val(diaaviso);
    OcultarAvisosModalEditable();
    $("#Editar").modal();
}

function BorrarRowCat(obj) {   
    $("#modTxtIdCatDel").val(obj.id);
    $("#modalCancelacionCon").modal();
}

function GuardarCategoriaEditada(ListCategoria, ddlFmto_Tienda, ddTipoMcia_text_modal, ddCategoria_val_modal, ddCategoria_text_modal, ddPeriodicidad_val_modal, ddPeriodicidad_text_modal, txtDiaMes_val, txtDiaSemana_val, txtDiaAviso_val) {

    $.ajax({
        cache: false,
        type: "GET",
        url: '../Capturas/GuardarCategoria',
        async: true,
        dataType: "json",
        data: { categoria: JSON.stringify(ListCategoria) },
        success: function (data) {            
            
            var id = ddlFmto_Tienda + "," + ddTipoMcia_val_modal + "," + ddCategoria_val_modal + "," + ddPeriodicidad_val_modal + "," + txtDiaMes_val + "," + txtDiaSemana_val + "," + txtDiaAviso_val;

            $('#tblCatCad').find("tr").each(function (index) {
                var $tr = $(this)
                if ($tr.attr("id") == $("#modTxtIdKey").val()) {
                    var i = 0;
                    $(this).find('td').each(function (i) {
                        var td = $(this);
                        var inp = td.children();
                        switch (i) {
                            case 0:
                                //inp.val(ddCategoria_text_modal);
                                td.text(ddCategoria_text_modal);
                                break;
                            case 1:
                                //inp.val(ddTipoMcia_text_modal);
                                td.text(ddPeriodicidad_text_modal);
                                break;
                            case 2:
                                //inp.val(ddPeriodicidad_text_modal);
                                td.text(txtDiaMes_val);
                                break;
                            case 3:
                                //inp.val(txtDiaMes_val);
                                td.text(txtDiaSemana_val);
                                break;
                            case 4:
                                //inp.val(txtDiaSemana_val);
                                td.text(txtDiaAviso_val);
                                break;
                            case 5:
                                var $btn = td.find('button');
                                $btn.attr("id", id)
                                break;
                            case 6:
                                var $btn = td.find('button');
                                $btn.attr("id", id)
                                break;
                            case 7:
                                var $btn = td.find('button');
                                $btn.attr("id", id)
                                break;
                        }
                        i++;
                    });
                    $tr.attr("id", id)
                    $("#modTxtIdKey").val(id);
                }
            });
            //$("#modalAvisoEditar").modal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al gravar (Categoría): " + thrownError);
        }
    });
}

function GuardarCategoria(ListCategoria) {
    $.ajax({
        cache: false,
        type: "GET",
        url: '../Capturas/GuardarCategoria',
        async: true,
        dataType: "json",
        data: { categoria: JSON.stringify(ListCategoria) },
        success: function (data) {
            $("#modalAviso").modal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al gravar (Categoría): " + thrownError);
        }
    });
}

function GuardarCategoriaAgregada(ListCategoria, ddlFmto_Tienda, ddlTipo_Mcia, ddCategoria_text, ddCategoria_val, ddPeriodicidad_text, ddPeriodicidad_val, txtDiaMes_val, txtDiaSemana_val, txtDiaAviso_val) {
    $.ajax({
        cache: false,
        type: "GET",
        url: '../Capturas/GuardarCategoria',
        async: true,
        dataType: "json",
        data: { categoria: JSON.stringify(ListCategoria) },
        success: function (data) {            

            //Arma La tabla dinamica    
            var $id = ddlFmto_Tienda + "," + ddlTipo_Mcia + ","+ ddCategoria_val + "," + ddPeriodicidad_val + "," + txtDiaMes_val + "," + txtDiaSemana_val + "," + txtDiaAviso_val;            
            var table = $("#tblCatCad");
            var $newRow = $('<tr/>');
            $newRow.attr("id", $id);

            $td = $('<td/>');
            //$textbox = $("<input readonly>").attr("type", "text").attr("class", "form-control");
            //$textbox.val(ddCategoria_text);
            //$textbox.text(ddCategoria_val);
            //$td.append($textbox);
            $td.append(ddCategoria_text);
            $newRow.append($td);

            $td = $('<td/>');
            //$textbox = $("<input readonly>").attr("type", "text").attr("class", "form-control");
            //$textbox.val(ddPeriodicidad_text);
            //$textbox.text(ddPeriodicidad_val);
            //$td.append($textbox);
            $td.append(ddPeriodicidad_text);
            $newRow.append($td);

            $td = $('<td/>');
            //$textbox = $("<input readonly>").attr("type", "text").attr("class", "form-control");
            //$textbox.val(txtDiaMes_val);
            //$td.append($textbox);
            $td.append(txtDiaMes_val);
            $newRow.append($td);

            $td = $('<td/>');
            //$textbox = $("<input readonly>").attr("type", "text").attr("class", "form-control");
            //$textbox.val(txtDiaSemana_val);
            //$td.append($textbox);
            $td.append(txtDiaSemana_val);
            $newRow.append($td);


            $td = $('<td/>');
            //$textbox = $("<input readonly>").attr("type", "text").attr("class", "form-control");
            //$textbox.val(txtDiaAviso_val);
            //$td.append($textbox);
            $td.append(txtDiaAviso_val);
            $newRow.append($td);

            $td = $('<td/>');
            $btn_del = $("<button/>").attr("class", "btn btn-danger btn-del");
            $btn_del.text("Eliminar");
            $btn_del.attr("id", $id);
            $btn_del.attr("onclick", "BorrarRowCat(this)");
            $td.append($btn_del);
            $newRow.append($td);


            $td = $('<td/>');
            //$btn_edi = $("<button/>").attr("class", "btn btn-info btn-edit").attr("data-toggle", "modal").attr("data-target", "#Editar");
            $btn_edi = $("<button/>").attr("class", "btn btn-info btn-edit");
            $btn_edi.text("Editar");
            $btn_edi.attr("id", $id);
            $btn_edi.attr("onclick", "EditarCategoria(this)");
            $td.append($btn_edi);
            $newRow.append($td);

            $td = $('<td/>');
            //$btn_addpor = $("<button/>").attr("class", "btn btn-primary btn-AddPorGuarda").attr("data-toggle", "modal").attr("data-target", "#AddPorcentaje");
            $btn_addpor = $("<button/>").attr("class", "btn btn-primary btn-AddPorGuarda");
            $btn_addpor.text("Editar %");
            $btn_addpor.attr("id", $id);
            $btn_addpor.attr("onclick", "AgregarPorcentaje(this)");
            $td.append($btn_addpor);
            $newRow.append($td);

            table.append($newRow);

            $("#DiaMes").val("");
            $("#DiaSemana").val("-1");
            $("#DiaAviso").val("");
        },
        //error: function (xhr, ajaxOptions, thrownError) {
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GuardarPorcentajePorCategoria(ListPorcentaje) {
    $.ajax({
        cache: false,
        type: "GET",
        url: '../Capturas/GuardarPorcPorCat',
        async: true,
        dataType: "json",
        data: { porcentaje: JSON.stringify(ListPorcentaje) },
        success: function (data) {
            $("#modalAvisoPor").modal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al gravar (Porcentajes): " + thrownError);
        }
    });
}

function AgregarPorcentaje(obj) {
    var array = obj.id;
    array = array.split(",");
    var FmtoTienda = $('#Fmto_Tienda').val();
    var categoria = array[2];
    var period = array[3];
    var diames = array[4];
    var diasemana = array[5];
    var diaaviso = array[6];

    tr = obj.parentNode.parentNode;
    td = tr.firstElementChild;
    inp = td.innerHTML;
    var descat = inp;
    //inp = td.firstElementChild;
    //var descat = inp.value;
    
    $("#ModPorcFmtoTienda").val($("#Fmto_Tienda").find("option:selected").text());
    $("#ModPorcTipoMercancia").val($("#Tipo_Mcia").find("option:selected").text());
    $("#ModPorcCategoria").val(descat);

    $("#modTxtIdKeyCat").val(categoria);
    $('#AddPorcentaje').modal();

    BuscarCategPorcentaje(FmtoTienda, categoria);

    //$("#tbodyCatPorc").html("");
}

function BorrarRango() {

}

function BuscarCatHistEliminadas(FmtoTienda, TipoMcia) {
    $.ajax({
        cache: false,
        type: "POST",
        url: '../Capturas/ObtenerCategHistElminadas',
        async: true,
        dataType: "json",
        data: { FmtoTienda: FmtoTienda, TipoBusquedad: tipobusquedad, TipoMcia: TipoMcia },
        success: function (d) {
            //$("#Panel_Cateliminadas_Content").html("");
            $("#tbodyHistEli").html("");
            if (d && d.length > 0) {
                $("#Panel_Cateliminadas_Content").attr("style", "height:300px;overflow:auto;");
                $("#tbodyHistEli").html(d);
            }
            else {
                $("#Panel_Cateliminadas_Content").html("No existe Categorías elimandas para este Formato Tienda");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al gravar (Porcentajes): " + thrownError);
        }
    });
}

function BuscarCategPorcentaje(FmtoTienda, Categoria) {
    $.ajax({
        cache: false,
        type: "POST",
        url: '../Capturas/ObtenerCategPorcentaje',
        async: true,
        dataType: "json",
        data: { FmtoTienda: FmtoTienda, Categoria: Categoria },
        success: function (d) {
            $("#tbodyCatPorc").html("");
            if (d && d.length > 0) {
                //$("#Panel_CatPorcentaje_Content").attr("style", "height:300px;overflow:auto;");
                $("#tbodyCatPorc").html(d);
            }
                /*
            else {
                $("#tbodyCatPorc").html("No existe Catgorias Porcentaje para este Formato Tienda");
            }
            */
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al cargar (Porcentajes): " + thrownError);
        }
    });
}

function BuscarCategorias() {
    var FmtoTienda = $("#Fmto_Tienda").val();
    var Tipo_Mcia = $("#Tipo_Mcia").val();
    $.ajax({
        cache: false,
        type: "POST",
        url: '../Capturas/ObtenerCategorias',
        async: true,
        dataType: "json",
        data: { FmtoTienda: FmtoTienda, TipoMcia: Tipo_Mcia },
        success: function (d) {
            $("#tblCatCadbody").html("");
            if (d && d.length > 0) {                
                $("#tblCatCadbody").html(d);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al cargar (Categorias): " + thrownError);
        }
    });
}

function BuscarPorcentajeHistoricoModal(RolCapturaHist, DescCat) {    
    var ftotienda = $('#CatEliFtoTiendaModal').val();
    var tipomcia = $('#Tipo_MciaModal').val();
    $('#thistporcmodal').html("");
    $('#thistporcmodal').html(DescCat);
    $('#ConHistPorcModal').modal();
    $.ajax({
        cache: false,
        type: "POST",
        url: '../Capturas/ObtenerPorcentajeHistorico',
        async: true,
        dataType: "json",
        data: { FmtoTienda: ftotienda, TipoMcia: tipomcia, RolCapturaHist: RolCapturaHist },
        success: function (d) {
            $("#Panel_ConHistPorcModal_Content").html("");
            if (d && d.length > 0) {
                $("#Panel_ConHistPorcModal_Content").attr("style", "height:300px;overflow:auto;");
                $("#Panel_ConHistPorcModal_Content").html(d);
            }
            
        else {
                $("#Panel_ConHistPorcModal_Content").html("No existe Catgorias Porcentaje para este Formato Tienda");
        }
        
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al cargar (Porcentajes): " + thrownError);
        }
    });
}

function ValidaPorcentajesporcategoria() {
    var valido = true;

    var countRows = $('#tbodyCatPorc tr').length;

    if (countRows == 1) {

        $rowfirst = $('#tbodyCatPorc tr:last');
        $tdfirstA = $rowfirst.find('td')[0];
        $firstinpA = $tdfirstA.childNodes;
        var firstA = $firstinpA[0].value == undefined ? $firstinpA[1].value : $firstinpA[0].value;

        //Obtenemos el valor de	% Remate Penultimo Row
        $inifirstRemate = $rowfirst.find('td')[1];
        $firstinpRemate = $inifirstRemate.childNodes;
        var firstRemate = $firstinpRemate[0].value == undefined ? $firstinpRemate[1].value : $firstinpRemate[0].value;

        //Obtenemos el valor de	% Merma Penultimo Row
        $tdfirstMerma = $rowfirst.find('td')[2];
        $firstinpMerma = $tdfirstMerma.childNodes;
        var firstMerma = $firstinpMerma[0].value == undefined ? $firstinpMerma[1].value : $firstinpMerma[0].value;


        if (firstA == '') {
            alert("El valor del Campo 'A' no puede ser vacío");
            return false;
        }
        if (firstRemate == '') {
            alert("El valor del Campo 'Remate' no puede ser vacío");
            return false;
        }
        if (firstMerma == '') {
            alert("El valor del Campo 'Merma' no puede ser vacío");

            return false;
        }
        else {
            $('#tblCatPorc').find("tr").each(function (index) {
                item = {};
                var i = 0;
                $(this).find('td').each(function (i) {
                    switch (i) {
                        /*
                         case 0:                        
                             item["FmtoTienda"] = ddlFmto_Tienda;
                             item["TipoMcia"] = ddTipoMcia;
                             item["Categoria"] = ddlCategoria;
                             var tdpat = $(this);
                             var tdchild = tdpat.children()
                             item["DiaInicio"] = tdchild.val();
                             break;
                             */
                        case 0:
                            item["FmtoTienda"] = ddlFmto_Tienda;
                            item["TipoMcia"] = ddTipoMcia;
                            item["Categoria"] = ddlCategoria;
                            item["DiaInicio"] = 0;

                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["DiaFin"] = tdchild.val();
                            break;
                        case 1:
                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["RebajaVta"] = tdchild.val();
                            break;
                        case 2:
                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["RebajaMerma"] = tdchild.val();
                            ArrayCate.push(item);
                            break;
                    }
                    i++;
                });
            });
            GuardarPorcentajePorCategoria(ArrayCate);
        }
    }

    if (countRows > 1) {
        $rowfirst = $('#tbodyCatPorc tr:last').prev();
        $rowlast = $('#tbodyCatPorc tr:last');

        //Obtenemos el valor de A del Penultimo Row           
        $initdA = $rowfirst.find('td')[0];
        $iniinpA = $initdA.childNodes;
        var iniA = $iniinpA[0].value == undefined ? $iniinpA[1].value : $iniinpA[0].value;;
        //Obtenemos el valor de A del Ultimo Row            
        $fintdA = $rowlast.find('td')[0];
        $fininpA = $fintdA.childNodes;
        var finA = $fininpA[0].value == "" ? "" : (parseInt($fininpA[0].value == undefined ? $fininpA[1].value : $fininpA[0].value));

        //Obtenemos el valor de	% Remate Penultimo Row
        $initdRemate = $rowfirst.find('td')[1];
        $iniinpRemate = $initdRemate.childNodes;
        var iniRemate = $iniinpRemate[0].value == undefined ? $iniinpRemate[1].value : $iniinpRemate[0].value;;

        //Obtenemos el valor de	% Remate Ultimo Row
        $fintdRemate = $rowlast.find('td')[1];
        $fininpRemate = $fintdRemate.childNodes;
        var finRemate = $fininpRemate[0].value  == "" ? "" : (parseInt($fininpRemate[0].value == undefined ? $fininpRemate[1].value : $fininpRemate[0].value));

        //Obtenemos el valor de	% Merma Penultimo Row
        $initdMerma = $rowfirst.find('td')[2];
        $iniinpMerma = $initdMerma.childNodes;
        var iniMerma = $iniinpMerma[0].value == undefined ? $iniinpMerma[1].value : $iniinpMerma[0].value;;

        //Obtenemos el valor de	% Remate Ultimo Row
        $fintdMerma = $rowlast.find('td')[2];
        $fininpMerma = $fintdMerma.childNodes;
        var finMerma = $fininpMerma[0].value == "" ? "" : (parseInt($fininpMerma[0].value == undefined ? $fininpMerma[1].value : $fininpMerma[0].value));

        if (iniA == "" || finA == "") {
            alert("El valor del Campo 'A' no puede ser vacío");
            return false;
        }
        if (iniRemate == "" || finRemate == "" ) {
            alert("El valor del Campo 'Remate' no puede ser vacío");
            return false;
        }
        if (iniMerma == "" || finMerma == "" ) {
            alert("El valor del Campo 'Merma' no puede ser vacío");
            return false;
        }

        //if (iniA >= finA) {
        //    alert("El valor del Campo 'A' del ultimo renglon, no debe ser Menor que el campo 'A' del anterior Renglon");
        //    return false;
        //}
        if (finA >= iniA) {
            alert("El valor del Campo 'A' del ultimo renglon, no debe ser Mayor que el campo 'A' del anterior Renglon");
            return false;
        }

        if (iniRemate >= finRemate) {
            alert("El valor del Campo Remate del ultimo renglon, no debe ser Menor que el campo Remate del anterior Renglon");
            return false;
        }
        if (finMerma >= iniMerma) {
            alert("El valor del Campo Merma del ultimo renglon, no debe ser Mayor que el campo Merma del anterior Renglon");
            return false;
        }
        else {
            $('#tblCatPorc').find("tr").each(function (index) {
                item = {};
                var i = 0;
                $(this).find('td').each(function (i) {
                    switch (i) {
                        /*
                         case 0:                        
                             item["FmtoTienda"] = ddlFmto_Tienda;
                             item["TipoMcia"] = ddTipoMcia;
                             item["Categoria"] = ddlCategoria;
                             var tdpat = $(this);
                             var tdchild = tdpat.children()
                             item["DiaInicio"] = tdchild.val();
                             break;
                             */
                        case 0:
                            item["FmtoTienda"] = ddlFmto_Tienda;
                            item["TipoMcia"] = ddTipoMcia;
                            item["Categoria"] = ddlCategoria;
                            item["DiaInicio"] = 0;

                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["DiaFin"] = tdchild.val();
                            break;
                        case 1:
                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["RebajaVta"] = tdchild.val();
                            break;
                        case 2:
                            var tdpat = $(this);
                            var tdchild = tdpat.children()
                            item["RebajaMerma"] = tdchild.val();
                            ArrayCate.push(item);
                            break;
                    }
                    i++;
                });
            });
            GuardarPorcentajePorCategoria(ArrayCate);
        }
    }

    
}

function OcultarAvisosModalEditable() {
    var $div = $('#modTxtDiaMes').parent();
    var $span = $div.children()[2];
    $span.setAttribute("style", "visibility:hidden");
}
function BorrarPorcentajePorCategoria(ListPorcentaje) {
    $.ajax({
        cache: false,
        type: "GET",
        url: '../Capturas/BorrarPorcPorCat',
        async: true,
        dataType: "json",
        data: { porcentaje: JSON.stringify(ListPorcentaje) },
        success: function (data) {
            $("#modalAvisoPor").modal();
            $trporc.remove();
            ArrayPorcBorrar = [];
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Ocurrio un error al gravar (Porcentajes): " + thrownError);
        }
    });
}
