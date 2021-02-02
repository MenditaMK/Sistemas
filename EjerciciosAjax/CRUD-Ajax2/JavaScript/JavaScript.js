window.onload = inicializarEventos;
var lista = $(".table");
var fila;
var button;
var idPersona;

class clsPersona {
    constructor(nombre, apellidos, fechaNacimiento, direccion, telefono) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}

function inicializarEventos() {
    lista = document.getElementById("lista");
    let crear = document.getElementById("crear");
    let eliminar = document.getElementById("eliminar");
    let actualizar = document.getElementById("actualizar");
    crear.addEventListener("click", crearPersona, false);
    eliminar.addEventListener("click", eliminarPersona, false);
    actualizar.addEventListener("click", actualizarPersona, false);
    
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
        fila.className = persona["Id"];

        celda.appendChild(document.createElement("event"));
        celda.onclick = function () {
            vincularDatos(persona);
        };
        lista.appendChild(fila);
        fila.appendChild(celda);
        celda.innerHTML = persona["Nombre"] + " " + persona["Apellidos"];
    }
}

function vincularDatos(persona) {
    let nombre = document.getElementById("nombre");
    let apellidos = document.getElementById("apellidos");
    let fecha = document.getElementById("fecha");
    let direccion = document.getElementById("direccion");
    let telefono = document.getElementById("telefono");
    let departamento = document.getElementById("departamento");

    idPersona = persona["Id"];
    nombre.value = persona["Nombre"];
    apellidos.value = persona["Apellidos"];
    let fechaCasteada = persona["FechaNacimiento"];
    //FALTA LA FECHA
    direccion.value = persona["Direccion"];
    telefono.value = persona["Telefono"];
    departamento.innerHTML = persona["IdDepartamento"];
}

function crearPersona() {
    //nombre.value = "";
    //apellidos.value = "";
    ////FALTA LA FECHA
    //direccion.value = "";
    //telefono.value = "";
    //departamento.innerHTML = "--";

    let persona = new clsPersona("kukuxumuxu", "JUAN", new Date(), "gominola", "6600");
    var llamada = new XMLHttpRequest();
    llamada.open("POST", "https://apicrud.azurewebsites.net/API/Personas/");
    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(persona);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            fila = document.createElement("tr");
            celda = document.createElement("td");

            celda.appendChild(document.createElement("event"));
            celda.onclick = function () {
                vincularDatos(persona);
            };
            lista.appendChild(fila);
            fila.appendChild(celda);
            celda.innerHTML = persona["Nombre"] + " " + persona["Apellidos"];
        }
    };
    llamada.send(json);
}

function eliminarPersona() {
    var llamada = new XMLHttpRequest();
    llamada.open("DELETE", "https://apicrud.azurewebsites.net/API/Personas/" + idPersona);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            let filaEliminada = document.getElementsByClassName(idPersona);
            lista.removeChild(filaEliminada);
            //FALTA ELIMINAR LA FILA DE LA TABLA
        }
    };
    llamada.send();
}

function actualizarPersona() {
    alert("hola");
    document.g
}