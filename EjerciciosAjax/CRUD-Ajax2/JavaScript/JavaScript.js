﻿/**
 * LOS DEPARTAMENTOS, LA ACTUALIZACION, GETELEMENTBYID
 * */

window.onload = inicializarEventos;
var lista
var idPersona;
var listadoDepartamentos;
var listaPersonas;



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
    llamada.open("GET", "https://apicrud.azurewebsites.net/API/Personas/");
    llamada.onreadystatechange = function () {
        if (llamada.readyState < 4) {
            document.body.style.cursor = 'wait';  //Aparece el puntero como que carga
        } else if (llamada.readyState == 4 && llamada.status == 200) {
            document.body.style.cursor = 'default';
            listaPersonas = JSON.parse(llamada.responseText);
            generarLista(listaPersonas);
        }
    };
    llamada.send();
}

/**
 * Este método crea los elementos necesarios para la tabla que se
 * muestra en pantalla
 * @param {any} listaPersonas es el listado de personas
 */
function generarLista(listaPersonas) {
    let fila;
    for (let persona of listaPersonas) {
        fila = document.createElement("tr");
        celda = document.createElement("td");
        fila.id = persona.Id;
        fila.className = persona["Id"];  //No lo hago con el id porque entraria en conflicto buscando el id del departamento luego

        celda.appendChild(document.createElement("event"));
        celda.onclick = function () {
            vincularDatos(persona);
        };
        lista.appendChild(fila);
        fila.appendChild(celda);
        celda.innerText = persona.Nombre + " " + persona.Apellidos;
    }
}

/**
 * Este método bindea los datos de la persona seleccionada en la lista
 * con los elementos del formulario
 * @param {any} persona La persona a bindear los datos
 */
function vincularDatos(persona) {
    let nombre = document.getElementById("nombre");
    let apellidos = document.getElementById("apellidos");
    let fecha = document.getElementById("fecha");
    let direccion = document.getElementById("direccion");
    let telefono = document.getElementById("telefono");
    let departamento = document.getElementById(persona.IdDepartamento);
    ///listadoDepartamentos.selected.text = departamento.value; ////////////////////////////***************
    idPersona = persona.Id;
    nombre.value = persona.Nombre;
    apellidos.value = persona.Apellidos;
    let fechaConvertida = new Date(persona.FechaNacimiento.split('T', 1)); //Aqui creamos una nueva fecha a partir de la cadena recibida y recortada
    let mes, dia;
    if (fechaConvertida.getMonth() < 10) {
        mes = "0" + (fechaConvertida.getMonth()+1); //Aqui se suma mas uno al mes porque JS empieza los meses desde 0
    } else {
        mes = fechaConvertida.getMonth() + 1;
    }
    if (fechaConvertida.getDate() < 10) {
        dia = "0" + fechaConvertida.getDate(); //Es necesario poner el 0 delante de mes y dia porque si no no pilla luego el formato al ser éste yyyy-MM-dd 
    } else {
        dia = fechaConvertida.getDate();
    }
    fecha.value = fechaConvertida.getFullYear() + "-" + mes + "-" + dia;
    direccion.value = persona.Direccion;
    telefono.value = persona.Telefono;
    //departamento.innerHTML = persona["IdDepartamento"];
}

/**
 * Este método limpia los campos del formulario para crear una nueva persona
 * */
function reestablecerCampos() {
    idPersona = 0;
    nombre.value = "";
    apellidos.value = "";
    direccion.value = "";
    fecha.value = "";
    telefono.value = "";
   // departamento.innerHTML = "--";

    
}

/**
 * Este método lanza una petición a la api para eliminar a una determinada
 * persona
 * */
function eliminarPersona() {
    if (idPersona != 0) {
        var llamada = new XMLHttpRequest();
        llamada.open("DELETE", "https://apicrud.azurewebsites.net/API/Personas/" + idPersona);
        llamada.onreadystatechange = function () {
            if (llamada.readyState < 4) {
                document.body.style.cursor = 'wait';
            } else if (llamada.readyState == 4 && llamada.status == 200) {
                document.body.style.cursor = 'default';
                let filaEliminada = document.getElementById(idPersona);
                //let filaEliminada = document.getElementsByClassName(idPersona);
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
    let departamento = document.getElementById("departamento"); //FALTA BINDEAR CORRECTAMENTE EL DEPARTAMENTO
    let persona = new clsPersona(nombre, apellidos, fecha, direccion, telefono, 1);
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
 * Este método indicará qué hacer al comprobar si se trata de una inserción
 * o de una actualización a través del valor del id
 * */
function guardarCambios() {
    if (idPersona == 0) { //Si el id vale 0 significará que se trata de una nueva persona
        if (!document.getElementById("nombre").value ) {
            alert("No olvides de rellenar los campos marcados con asterisco!!")
        } else {
            insertarPersona();
        }
    } else {
        //actualizarPersona();
        actualizarInformacionPersona();
    }
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
    let departamento = document.getElementById("departamento"); //FALTA BINDEAR CORRECTAMENTE EL DEPARTAMENTO
    let persona = new clsPersona(nombre, apellidos, fecha, direccion, telefono, 1);
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
async function actualizarInformacionPersona() {

    let nombre = document.getElementById("nombre").value;
    let apellidos = document.getElementById("apellidos").value;
    let fecha = document.getElementById("fecha").value;
    let direccion = document.getElementById("direccion").value;
    let telefono = document.getElementById("telefono").value;
    let departamento = document.getElementById("departamento"); //FALTA BINDEAR CORRECTAMENTE EL DEPARTAMENTO
    let persona = new clsPersona(nombre, apellidos, fecha, direccion, telefono, 1);
    var json = JSON.stringify(persona);

    try {
        const respuesta = await fetch("https://apipersonas.azurewebsites.net/API/Persona/" + idPersona, { method: 'PUT', body: json, headers: { 'Content-type': 'application/json; charset=utf-8'} });

        if (respuesta.ok) {
            eliminarCeldas();
            cargarLista();
            alert("Persona Actualizada!!");
        }
    } catch {
        return false;
    }

}

/**
 * Este método elimina todas las celdas de la tabla para más tarde volverla a rellenar actualizada
 * Explicación: Es necesario eliminar la tabla y volverla a insertar porque si insertamos una nueva persona
 * a la tabla directamente ésta carecerá de un id, ya que este se otorga a la persona que está en la bbdd.
 * Por ello es necesario volverla a rellenar, para que esta persona tenga un id
 * */
function eliminarCeldas() {
    let longitud = lista.rows.length;
    for (let i = 2; i < longitud; i++) {
        lista.deleteRow(2); //Se elimina el dos porque es la posición de la primera persona de la lista
    }
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
 * Este método añade al selector todos los departamentos que
 * hay en la base de datos
 * @param {any} listado //El listado de departamentos
 */
function generarListaDepartamentos(listado) {
    let opcion;
    for (let departamento of listado) {
        opcion = document.createElement("option");
        opcion.id = departamento.Id;
        opcion.innerText = departamento["Nombre"];
        listadoDepartamentos.appendChild(opcion);
    }
    let prueba = listadoDepartamentos; ///////////////////////////////////PRUEBA
}

/**
 * Este método filtra la lista de personas a través del cuadro de búsqueda
 * */
function buscarPersonas() {
    let arrayPersonas = new Array();
    let i = 0;
    let nombre, apellidos;
    let busqueda = document.getElementById("busqueda");
    for (let persona of listaPersonas) {
        nombre = persona.Nombre.toUpperCase();
        apellidos = persona.Apellidos.toUpperCase();
        if (nombre.includes(busqueda.value.toUpperCase()) || apellidos.includes(busqueda.value.toUpperCase())) {
            arrayPersonas[i] = persona;
            i++;
        }
    }
    eliminarCeldas();
    generarLista(arrayPersonas);
}