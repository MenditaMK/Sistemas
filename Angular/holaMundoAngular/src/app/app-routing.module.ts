import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TablaPersonasComponent} from './components/tabla-personas/tabla-personas.component';
import {FormularioPersonaComponent} from './components/formulario-persona/formulario-persona.component';
import {ListadoPersonasComponent} from './components/listado-personas/listado-personas.component';
import {FormularioReactivoComponent} from './components/formulario-reactivo/formulario-reactivo.component';

const routes: Routes = [
  {path:'', component:TablaPersonasComponent},
  {path:'formularioReactivo', component:FormularioReactivoComponent},
  {path:'tabla', component:TablaPersonasComponent},
  {path:'formulario', component:FormularioPersonaComponent},
  {path:'listado', component:ListadoPersonasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
