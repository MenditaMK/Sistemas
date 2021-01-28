window.onload = inicializarEventos;
var tabla;
function inicializarEventos() {
    tabla = document.getElementById("tabla");
    document.getElementById("btnRecorrer").addEventListener("click", recorrerCeldas, false);
    document.getElementById("btnAgregar").addEventListener("click", agregarFila, false);
    document.getElementById("btnBorrar").addEventListener("click", borrarFila, false);
}

/* 
 * Esta función recorre la tabla y muestra el contenido de esta misma
 * */
function recorrerCeldas() {
    var mensaje;
    for (var i = 0, row; row = tabla.rows[i]; i++) {
        for (var j = 0, cell; cell = row.cells[j]; j++) {
            if (mensaje != null) {
                mensaje += ", " + cell.innerText;
            } else {
                mensaje = cell.innerText;
            }
        }
    }
    alert(mensaje);
}

/* 
 * Esta función agrega una nueva fila a la tabla
 * */
function agregarFila() {

    var fila = document.createElement("tr"); //Se crea una nueva fila
    var numeroAnterior = tabla.rows.length;
    var numero = parseInt(numeroAnterior) + 1;

    for (i = 0; i < tabla.rows[0].cells.length; i++) {

        celda = document.createElement("td");
        numeroCelda = numero * 10 + i + 1;
        textoCelda = document.createTextNode("Celda " + numeroCelda);

        celda.appendChild(textoCelda);
        fila.appendChild(celda);
        tabla.appendChild(fila);
    }
}

/*
 * Esta función borra la ultima fila de la tabla
 * */
function borrarFila() {
    tabla.deleteRow(tabla.rows.length - 1);
}