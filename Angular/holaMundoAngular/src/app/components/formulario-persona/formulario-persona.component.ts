import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-formulario-persona',
  templateUrl: './formulario-persona.component.html',
  styleUrls: ['./formulario-persona.component.css']
})
export class FormularioPersonaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  saludar(){
    var nombre =(<HTMLInputElement> document.getElementById("nombre")).value;
    var apellidos = (<HTMLInputElement> document.getElementById("apellidos")).value;
    alert("HOLA MUNDO "+nombre+" "+apellidos);
  }
}
