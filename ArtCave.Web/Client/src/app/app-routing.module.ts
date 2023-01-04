import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StandComponent } from './components/stand/stand.component';
import { ForbiddenComponent } from './error-pages/forbidden/forbidden/forbidden.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'stand', component: StandComponent, canActivate: [AuthGuard] },
  { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
  { 
    path: 'admin-panel',
    loadChildren: () => import('./admin-panel/admin-panel.module').then(m => m.AdminPanelModule),
    canActivate: [RoleGuard],
    data: { roles: ['Admin'] }
 },

  { path: 'forbidden', component : ForbiddenComponent},
  { path: '404', component : NotFoundComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
