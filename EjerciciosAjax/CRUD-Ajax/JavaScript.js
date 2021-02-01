window.onload = inicializarEventos;
var lista;
var fila;
var button;

function inicializarEventos() {
    lista = document.getElementById("lista");
    cargarLista();

}

function cargarLista() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://apicrud.azurewebsites.net/API/Personas/");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            let listaPersonas = JSON.parse(llamada.responseText);
            generarLista(listaPersonas);
        }
    };
    llamada.send();
}

function generarLista(listaPersonas) {

    for (let persona of listaPersonas) {
        fila = document.createElement("tr");
        celda = document.createElement("td");
        button = document.createElement("button");
        
        //button.innerHTML = persona["Nombre"] + " "+ persona["Apellidos"];
        //button.addEventListener("click", prueba, false);
        celda.appendChild(document.createElement("event"));
        celda.onclick = function () {
            alert(persona["Nombre"] + " " + persona["Apellidos"]);
        };
        lista.appendChild(fila);
        fila.appendChild(celda);
        celda.appendChild(button);
        celda.innerHTML = persona["Nombre"] + " " + persona["Apellidos"];
    }
}

