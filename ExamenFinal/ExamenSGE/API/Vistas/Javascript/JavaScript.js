window.onload = inicializarEventos;
var listadoMisiones;
var tabla;
var arrayCreditos;
var actualizada; //La creación de esta variable la explico en el put

function inicializarEventos() {
    tabla = document.getElementById("tabla");
    actualizada = true;
    let guardar = document.getElementById("guardar");
    arrayCreditos = new Array();  //Este array me ayudará posteriormente a comprobar si ha habido cambios en los créditos
    guardar.addEventListener("click", guardarCambios, false);
    cargarLista();
}

/** 
 * Este método lanza una petición a la api para obtener el listado completo
 * de las misiones no completadas de la base de datos
 * */
function cargarLista() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "http://localhost:61836/API/Mision/");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {

        } else if (llamada.readyState == 4 && llamada.status == 200) {
            listadoMisiones = JSON.parse(llamada.responseText);
            if (listadoMisiones.length == 0) {
                alert("No hay misiones por completar");
            } else {
                generarLista(listadoMisiones);
            }
        }
    };
    llamada.send();
}

/**
 * Este método genera el listado correspondiente para la tabla
 * @param {any} listadoMisiones El listado de las misiones no completadas
 */
function generarLista(listadoMisiones) {
    let fila;
    for (let mision of listadoMisiones) {
        fila = document.createElement("tr");
        celdaNombre = document.createElement("td");
        celdaDescripcion = document.createElement("td");
        celdaCreditos = document.createElement("td");
        creditos = document.createElement("input");
        creditos.type = "number";
        tabla.appendChild(fila);
        tabla.appendChild(celdaNombre);
        tabla.appendChild(celdaDescripcion);
        tabla.appendChild(celdaCreditos);
        celdaCreditos.appendChild(creditos);
        celdaNombre.innerText = mision.Nombre;
        celdaDescripcion.innerText = mision.Descripcion;
        creditos.value = mision.Creditos;
        creditos.id = mision.Id; //Aqui le establezco al input un id, que corresponderá con el id de la mision que ocupe dicha fila
        arrayCreditos[mision.Id] = mision.Creditos; //Aquí le asigno el valor de los creditos de la misión a la posición del array que 
                                                    //corresponda con el id de dicha misión, para así comprobar más tarde cuántos créditos
                                                    //tenía la misión incialmente
    }
}

/**
 * Este método comprueba si ha habido algun cambio en la misión y de ser así
 * actualiza las misiones correspondientes
 * */
function guardarCambios() {
    let i = 0;
//Como el valor del input puede cambiar pues lo comparo con la posición del array que corresponda
//a dicha misión, si no son iguales significa que sufrió un cambio
    for (let mision of listadoMisiones) {
        if (arrayCreditos[mision.Id] != document.getElementById(mision.Id).value && document.getElementById(mision.Id).value>=0) { //SI ENTRA AQUÍ SIGNIFICA QUE EL CAMBIO ORIGINAL HA CAMBIADO
            actualizarMision(mision.Id);
            if (actualizada == true) {
                arrayCreditos[mision.Id] = document.getElementById(mision.Id).value; //Actualizamos también el valor inicial de la misión por el actualizado
                i++; //Por cada iteración signfica que se ha actualizado una misión más
            }
        }
    }
    if (i == 0) {
        alert("No se ha actualizado ninguna misión");
    } else {
        alert("Se han actualizado " + i + " misiones");
    }
}

/**
 * Este método lanza una petición a la api para actualizar una determinada misión
 * de la base de datos
 * */
function actualizarMision(id) {
    let creditos = document.getElementById(id).value;
    let misionId = id;
    let mision = new clsMisiones(misionId, "", "", creditos, false);
    var llamada = new XMLHttpRequest();
    llamada.open("PUT", "http://localhost:61836/API/Mision/" + id);
    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(mision);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            actualizada = true; 
            console.log(llamada.responseText);
        }
    };
    llamada.send(json);
    //Utilizo la variable "actualizada" para confirmar que se actualizó correctamente la misión
    //y posteriormente, en el método que hace la llamada compruebo si lo hizo bien para poder
    //mostrar a través del alert cuantas misiones se actualizaron realmente, ya que si no utilizara esta variable
    //el alert me diría el total de misiones que hicieron la llamada a la api sin tener en cuenta que en alguna
    //pudo haber algún problema y no realizarse la actualización
}