import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl} from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  templateUrl: './formulario-reactivo.component.html',
  styleUrls: ['./formulario-reactivo.component.css']
})
export class FormularioReactivoComponent implements OnInit {
  formulario: FormGroup;
  constructor() { }

  ngOnInit(): void {
    this.formulario = new FormGroup(
      {
        nombre: new FormControl('',[]),
        apellidos:new FormControl('',[])
      }
    );
  }

  saludar(){
    alert("Hola "+this.formulario.controls.nombre.value+" "+this.formulario.controls.apellidos.value);
  }
}