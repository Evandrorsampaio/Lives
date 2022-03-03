import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutes } from './dashboard.routing';
import { ChartistModule } from 'ng-chartist';
import { InstrutoresCardComponent } from './dashboard-components/InstrutoresCard/InstrutoresCard.component';
import { LivesCardComponent } from './dashboard-components/LivesCard/LivesCard.component';
import { InscricoesCardComponent } from './dashboard-components/InscricoesCard/InscricoesCard.component';
import { InscritosCardComponent } from './dashboard-components/InscritosCard/InscritosCard.component';

@NgModule({
  imports: [
    CommonModule,
    DemoMaterialModule,
    FlexLayoutModule,
    ChartistModule,
    RouterModule.forChild(DashboardRoutes)
  ],
  declarations: [
    DashboardComponent,
    InstrutoresCardComponent,
    LivesCardComponent,
    InscricoesCardComponent,
    InscritosCardComponent
  ]
})
export class DashboardModule {}
