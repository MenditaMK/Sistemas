window.onload = inicializarEventos;

function inicializarEventos() {
    document.getElementById("btnSaludar").addEventListener("click", saludar, false);
}

function saludar() {
    alert("HELLO FUUUUCKING WOOOOOOORLLLLD");
}

class Persona{
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
}