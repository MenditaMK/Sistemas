window.onload = inicializa;

function inicializa() {
    document.getElementById("boton").addEventListener("click", mostrarApellido, false);
}

function mostrarApellido() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://apicrud.azurewebsites.net/API/Personas/44");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {

        } else if (llamada.readyState == 4 && llamada.status == 200) {
            var persona = JSON.parse(llamada.responseText);
            document.getElementById("apellido").innerHTML = persona["Apellidos"];
        }
    };
    llamada.send();
}