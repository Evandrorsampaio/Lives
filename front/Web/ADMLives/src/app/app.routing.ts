import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
      },
      {
        path: 'material',
        loadChildren:
          () => import('./material-component/material.module').then(m => m.MaterialComponentsModule)
      },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'instrutores',
        loadChildren: () => import('./Instrutor/Instrutor.module').then(m => m.InstrutorModule)
      },
      {
        path: 'lives',
        loadChildren: () => import('./Live/Live.module').then(m => m.LiveModule)
      },
      {
        path: 'inscritos',
        loadChildren: () => import('./Inscrito/Inscrito.module').then(m => m.InscritoModule)
      },
      {
        path: 'inscricoes',
        loadChildren: () => import('./Inscricao/Inscricao.module').then(m => m.InscricaoModule)
      },
    ]
  }
];
