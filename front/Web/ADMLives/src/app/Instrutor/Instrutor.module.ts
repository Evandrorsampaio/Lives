import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstrutorComponent } from './Instrutor.component';
import { RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ChartistModule } from 'ng-chartist';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { CadastroComponent } from './Cadastro/Cadastro.component';

const instrutorRoutes: Routes = [

  { path: '', component: InstrutorComponent },

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
    RouterModule.forChild(instrutorRoutes),
  ],
  declarations: [InstrutorComponent, CadastroComponent],
  bootstrap: [InstrutorComponent, CadastroComponent]

})
export class InstrutorModule { }
