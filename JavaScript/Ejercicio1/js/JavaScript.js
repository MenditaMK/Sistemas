class Persona {
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
}

window.onload = inicializarEventos;

function inicializarEventos() {
    document.getElementById("btnSaludar").addEventListener("click", saludar, false);
}

function saludar() {
    //var nombre = document.getElementById("nombre").value;
    //var apellidos = document.getElementById("apellidos").value;

    //var persona = new Persona(nombre, apellidos);

    alert("HOLA " + document.getElementById("nombre").value + " " + document.getElementById("apellidos").value);
}

