window.onload = inicializarEventos;
var selectMarcas;
var selectModelos;

function inicializarEventos() {
    selectMarcas = document.getElementById("marcas");
    selectMarcas.onchange = listaModelos;

    var opcion1 = document.createElement("option");
    opcion1.text = "Renault";
    var opcion2 = document.createElement("option");
    opcion2.text = "Mercedes";
    var opcion3 = document.createElement("option");
    opcion3.text = "Audi";

    selectMarcas.add(opcion1);
    selectMarcas.add(opcion2);
    selectMarcas.add(opcion3);
}

function listaModelos() {
    selectModelos = document.getElementById("modelos");
    const seleccionado = selectMarcas.value;
    var length = selectModelos.options.length;
    for (i = length - 1; i >= 0; i--) {
        selectModelos.options[i] = null;
    }

    var opcion1 = document.createElement("option");
    var opcion2 = document.createElement("option");
    var opcion3 = document.createElement("option");

    switch (seleccionado) {
        case "Renault":
            option1.text = "Megane";
            option2.text = "Captur";
            option3.text = "Clio";
            break;
        case "Mercedes":
            option1.text = "GLS";
            option2.text = "SLC";
            option3.text = "GLE";
            break;
        case "Audi":
            option1.text = "A3";
            option2.text = "A4";
            option3.text = "A5";
            break;
    }
    selectModelos.add(opcion1);
    selectModelos.add(opcion2);
    selectModelos.add(opcion3);
}

//window.onload = inicializaEventos;
//var selMarca;
//var selModelo;

//function inicializaEventos() {

//    selMarca = document.getElementById("selMarca");
//    selMarca.onchange = listaModelos;

//    var option1 = document.createElement("option");
//    option1.text = "Audi";
//    var option2 = document.createElement("option");
//    option2.text = "Toyota";
//    var option3 = document.createElement("option");
//    option3.text = "Mercedes";

//    selMarca.add(option1);
//    selMarca.add(option2);
//    selMarca.add(option3);

//    listaModelos();

//}

//function listaModelos() {

//    selModelo = document.getElementById("selModelo");
//    const seleccionado = selMarca.value;
//    var length = selModelo.options.length;
//    for (i = length - 1; i >= 0; i--) {
//        selModelo.options[i] = null;
//    }

//    var option1 = document.createElement("option");
//    var option2 = document.createElement("option");
//    var option3 = document.createElement("option");

//    switch (seleccionado) {
//        case "Audi":
//            option1.text = "Audi A4";
//            option2.text = "Audi A6";
//            option3.text = "Audi Q5";
//            break;
//        case "Toyota":
//            option1.text = "Corolla";
//            option2.text = "Yaris";
//            option3.text = "Camry";
//            break;
//        case "Mercedes":
//            option1.text = "GLA";
//            option2.text = "Clase C";
//            option3.text = "Coupé";
//            break;
//    }

//    selModelo.add(option1);
//    selModelo.add(option2);
//    selModelo.add(option3);

//}
