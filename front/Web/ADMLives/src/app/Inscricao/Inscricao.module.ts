import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InscricaoComponent } from './Inscricao.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ChartistModule } from 'ng-chartist';
import { FormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { CadastroComponent } from './Cadastro/Cadastro.component';

const inscricaoRoutes: Routes = [
  { path: '', component: InscricaoComponent },
  { path: 'cadastro', component: CadastroComponent}
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
    RouterModule.forChild(inscricaoRoutes),
  ],
  declarations: [InscricaoComponent, CadastroComponent]
})
export class InscricaoModule { }
