import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastroComponent } from './Cadastro/Cadastro.component';
import { RouterModule, Routes } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { ChartistModule } from 'ng-chartist';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DemoMaterialModule } from '../demo-material-module';
import { LiveComponent } from './Live.component';
import { MAT_DATE_LOCALE } from '@angular/material/core';

const liveRoutes: Routes = [

  { path: '', component: LiveComponent },
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
    RouterModule.forChild(liveRoutes),
  ],
  declarations: [LiveComponent, CadastroComponent],
  providers: [ { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }] ,
  bootstrap: [LiveComponent, CadastroComponent]

})
export class LiveModule { }
