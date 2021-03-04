window.onload = inicializarEventos;


function inicializarEventos() {
    lista = document.getElementById("lista");
    listadoDepartamentos = document.getElementById("listaDepartamentos");
    let crear = document.getElementById("crear");
    let eliminar = document.getElementById("eliminar");
    let actualizar = document.getElementById("actualizar");
    crear.addEventListener("click", reestablecerCampos, false);
    eliminar.addEventListener("click", eliminarPersona, false);
    actualizar.addEventListener("click", guardarCambios, false);
    idPersona = 0;
    cargarListadoDepartamentos();
    cargarLista();
}

/** 
 * Este método lanza una petición a la api para obtener el listado completo
 * de las personas de la base de datos
 * */
function cargarLista() {
    var llamada = new XMLHttpRequest();
    let gif;
    llamada.open("GET", "https://apicrud.azurewebsites.net/API/Personas/");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
            if (llamada.readyState == 2) {
                gif = document.createElement("img");
                gif.src = "../css/833.gif";
                lista.appendChild(gif);
            }
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            lista.removeChild(gif)
            document.body.style.cursor = 'default';
            listaPersonas = JSON.parse(llamada.responseText);
            generarLista(listaPersonas);
        }
    };
    llamada.send();
}

/**
 * Este método lanzará una petición a la api para obtener el listado de
 * departamentos de la base de datos
 * */
function cargarListadoDepartamentos() {
    var llamada = new XMLHttpRequest();
    llamada.open("GET", "https://apicrud.azurewebsites.net/API/Departamentos/");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            let listado = JSON.parse(llamada.responseText);
            generarListaDepartamentos(listado);
        }
    };
    llamada.send();
}

/**
 * Este método lanza una petición a la api para eliminar a una determinada
 * persona
 * */
function eliminarPersona() {
    if (confirm("Estas seguro que quieres hacer esto?")) {
        if (idPersona != 0) {
            var llamada = new XMLHttpRequest();
            llamada.open("DELETE", "https://apicrud.azurewebsites.net/API/Personas/" + idPersona);
            llamada.onreadystatechange = function () {
                if (llamada.readyState < 4) {
                    document.body.style.cursor = 'wait';
                } else if (llamada.readyState == 4 && llamada.status == 200) {
                    document.body.style.cursor = 'default';
                    let filaEliminada = document.getElementById(idPersona);
                    lista.deleteRow(filaEliminada.rowIndex);
                    reestablecerCampos();
                    alert("Se ha eliminado a la persona correctamente");
                }
            };
            llamada.send();
        } else {
            alert("SELECCIONA UNA PERSONA ANTES!");
        }
    }
}

/**
 * Este método lanza una petición a la api para insertar una
 * nueva persona en la base de datos
 * */
function insertarPersona() {
    let nombre = document.getElementById("nombre").value;
    let apellidos = document.getElementById("apellidos").value;
    let fecha = document.getElementById("fecha").value;
    let direccion = document.getElementById("direccion").value;
    let telefono = document.getElementById("telefono").value;
    let departamento = listadoDepartamentos.value;
    let persona = new clsPersona(nombre, apellidos, fecha, direccion, telefono, departamento);
    var llamada = new XMLHttpRequest();
    llamada.open("POST", "https://apicrud.azurewebsites.net/API/Personas/");
    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(persona);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
            document.body.style.cursor = 'wait';
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            document.body.style.cursor = 'default';
            alert("Se ha añadido la persona correctamente");
            eliminarCeldas();
            cargarLista();
        }
    };
    llamada.send(json);
}

/**
 * Este método lanza una petición a la api para actualizar una determinada persona
 * de la base de datos
 * */
function actualizarPersona() {
    let nombre = document.getElementById("nombre").value;
    let apellidos = document.getElementById("apellidos").value;
    let fecha = document.getElementById("fecha").value;
    let direccion = document.getElementById("direccion").value;
    let telefono = document.getElementById("telefono").value;
    let departamento = listadoDepartamentos.value;
    let persona = new clsPersona(nombre, apellidos, fecha, direccion, telefono, departamento);
    var llamada = new XMLHttpRequest();
    llamada.open("PUT", "https://apicrud.azurewebsites.net/API/Personas/" + idPersona);
    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(persona);
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
            document.body.style.cursor = 'wait';
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            document.body.style.cursor = 'default';
            console.log(llamada.responseText);
            eliminarCeldas();
            cargarLista();

            alert("Persona Actualizada!!");
        }
    };
    llamada.send(json);
}