window.onload = inicializa;

function inicializa() {
    document.getElementById("saluda").addEventListener("click", saludar, false);
}

function saludar() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "http://localhost:56626/servidor/Archivo.html");

    llamada.onreadystatechange = function () {

        if (llamada.readyState < 4) {

        } else if (llamada.readyState == 4 && llamada.status == 200) {
            var saludo = llamada.responseText;
            document.getElementById("respuesta").innerHTML = saludo;
        }
    };
    llamada.send();
}