window.onload = inicializarEventos;
var horaDecena, horaUnidad, minutoDecena, minutoUnidad, segundoDecena, segundoUnidad;
var horaActual;
let imagenes;

function inicializarEventos() {
    imagenes = document.getElementsByTagName("img");
}

setInterval(actualizarReloj, 1000, "JavaScript");

function actualizarReloj() {
    horaActual = new Date();
    actualizarImagen(0, horaActual.getHours().toString().charAt(0));
    actualizarImagen(1, horaActual.getHours().toString().charAt(1));
    actualizarImagen(3, horaActual.getMinutes().toString().charAt(0));
    actualizarImagen(4, horaActual.getMinutes().toString().charAt(1));
    actualizarImagen(6, horaActual.getSeconds().toString().charAt(0));
    actualizarImagen(7, horaActual.getSeconds().toString().charAt(1));
}

function actualizarImagen(posicion, digito) {
    imagenes[posicion].src = "imagenes/" + digito + ".gif";
}

