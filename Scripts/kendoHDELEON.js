/*EXTENSION DE KENDO HECHA POR HÉCTOR DE LEÓN www.hdeleon.net */

//constantes globales
var dialog; //es la variable para todos los dialogs del sistema

//refresca un grid
function jsRefrescaGrid(nombre) {

    $('#' + nombre).data('kendoGrid').dataSource.read();
    $('#' + nombre).data('kendoGrid').refresh();
}

//abre un dialog-----------------------------------------------------------
function jsShowDialog(url, width, height, title) {
    if (width === undefined) width = 300
    if (height === undefined) height = 300;
    if (title === undefined) title = "";

    $("#windowDialog .contenido").html("");
    $('#windowDialog').kendoWindow({
        modal: true,
        resizable: false,
        width: width,
        height: height,
        draggable: false

    }).data('kendoWindow').center().open()

    $("#windowDialog").prev().find(".k-window-title").text(title);
    jsShowWindowLoad();
    $("#windowDialog .contenido").load(url, function () { jsRemoveWindowLoad() })
}

function jsCloseDialog() {
    $("#windowDialog").data("kendoWindow").close();
}

//genera el nombre random de una carpeta
function jsObtieneNombreCarpeta() {
    //obtención de carpeta
    myDate = new Date();
    diaActual = myDate.getDate() + (myDate.getMonth() + 1) + myDate.getFullYear() + myDate.getTime();
    carpeta = "a" + diaActual + Math.floor((Math.random() * 100000) + 1);

}

