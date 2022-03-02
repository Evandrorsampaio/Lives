import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InscritoComponent } from './Inscrito.component';
import { RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ChartistModule } from 'ng-chartist';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { CadastroComponent } from './Cadastro/Cadastro.component';
import { MAT_DATE_LOCALE } from '@angular/material/core';

const inscritoRoutes: Routes = [
  { path: '', component: InscritoComponent },
  { path: 'cadastro', component: CadastroComponent,
    children: [
      { path: ':id', component: CadastroComponent }
  ]},
];

@NgModule({
  imports: [
    CommonModule,
    DemoMaterialModule,
    FlexLayoutModule,
    ChartistModule,
    RouterModule,
    FormsModule,
    MatListModule,
    MatCardModule,
    ReactiveFormsModule,
    RouterModule.forChild(inscritoRoutes),
  ],
  providers: [ { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }] ,
  declarations: [InscritoComponent, CadastroComponent],
  bootstrap: [InscritoComponent, CadastroComponent]
})
export class InscritoModule { }
