window.onload = inicializarEventos;
var idPersona;

function inicializarEventos() {
    document.getElementById("boton").addEventListener("click", borrarPersona, false);
    idPersona = document.getElementById("idPersona");
}

function borrarPersona() {
    var llamada = new XMLHttpRequest();
    llamada.open("DELETE", "https://apicrud.azurewebsites.net/API/Personas/" + idPersona.value);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            document.getElementById("resultado").innerHTML = "La persona se ha eliminado correctamente";
        }
    };
    llamada.send();
}