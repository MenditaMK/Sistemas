window.onload = inicializarEventos;
var tabla;
function inicializarEventos() {
    tabla = document.getElementById("tabla");
    document.getElementById("btnRecorrer").addEventListener("click", recorrerCeldas, false);
    document.getElementById("btnAgregar").addEventListener("click", agregarFila, false);
    document.getElementById("btnBorrar").addEventListener("click", borrarFila, false);
}

/* INTERFAZ
 * Prototipo: recorrerCeldas()
 * Funcion: Esta función recorre el contenido de una tabla y lo muestra a través de un alert
 * Entradas: --
 * Salidas: --
 * Precondiciones: --
 * Postcondiciones: Se muestra el contenido de la tabla
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

/* INTERFAZ
 * Prototipo: recorrerCeldas()
 * Funcion: Esta función recorre el contenido de una tabla y lo muestra a través de un alert
 * Entradas: --
 * Salidas: --
 * Precondiciones: --
 * Postcondiciones: Se muestra el contenido de la tabla
 * */
function agregarFila() {

    var fila = document.createElement("tr"); //Se crea una nueva fila
    var numeroAnterior = tabla.rows[(tabla.rows.length - 1)].cells[0].innerText;

    for (i = 0; i < tabla.rows[0].cells.length; i++) {

        celda = document.createElement("td");
        numeroCelda = parseInt(numeroAnterior) + 10 + i;
        textoCelda = document.createTextNode("Celda" + numeroCelda);

        celda.appendChild(textoCelda);
        fila.appendChild(celda);
        tabla.appendChild(fila);
    }
}

function borrarFila() {
    tabla.deleteRow(tabla.rows.length - 1);
}