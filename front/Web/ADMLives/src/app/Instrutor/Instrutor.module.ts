import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstrutorComponent } from './Instrutor.component';
import { RouterModule, Routes } from '@angular/router';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ChartistModule } from 'ng-chartist';
import { FormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { CadastroComponent } from './Cadastro/Cadastro.component';

const instrutorRoutes: Routes = [

  { path: '', component: InstrutorComponent },

  { path: 'cadastro', component: CadastroComponent, },

  { path: 'cadastro/:id', component: CadastroComponent }

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
    RouterModule.forChild(instrutorRoutes),
  ],
  declarations: [InstrutorComponent, CadastroComponent]
})
export class InstrutorModule { }
