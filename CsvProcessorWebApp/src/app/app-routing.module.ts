import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultarComponent } from './consultar/consultar.component';
import { CsvFileComponent } from './csv-file/csv-file.component';
import { EsAdminGuard } from './es-admin.guard';
import { EsLogedGuard } from './es-loged.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'login', component: LoginComponent},
  {path: 'cargar-archivo', component: CsvFileComponent, canActivate: [EsAdminGuard]},
  {path: 'consultar', component: ConsultarComponent, canActivate: [EsLogedGuard]},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
