import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { AlunoCrudComponent } from './views/aluno-crud/aluno-crud.component';
import { AlunoCreateComponent } from './components/aluno/aluno-create/aluno-create.component';
import { AulaCrudComponent } from './views/aula-crud/aula-crud.component';
import { AulaCreateComponent } from './components/aula-create/aula-create.component';
import { FeriasCreateComponent } from './components/ferias/ferias-create/ferias-create.component';
import { FeriasCrudComponent } from './views/ferias-crud/ferias-crud.component';
import { FeriasUpdateComponent } from './components/ferias/ferias-update/ferias-update.component';
import { FeriasDeleteComponent } from './components/ferias/ferias-delete/ferias-delete.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  { 
    path: "login",
    component: LoginComponent
   },
  { 
    path: "",
    component: HomeComponent
   },
  {
    path: "alunos",
    component: AlunoCrudComponent
  },
  {
    path: "aluno/create",
    component: AlunoCreateComponent
  },
  {
    path: "aulas",
    component: AulaCrudComponent
  },
  {
    path: "aula/create",
    component: AulaCreateComponent
  },
  {
    path: "ferias",
    component: FeriasCrudComponent
  },
  {
    path: "ferias/create",
    component: FeriasCreateComponent
  },
  {
    path: "ferias/crud/:cpf",
    component: FeriasCrudComponent
  },
  {
    path: "ferias/update/:id",
    component: FeriasUpdateComponent
  },
  {
    path: "ferias/delete/:id",
    component: FeriasDeleteComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
