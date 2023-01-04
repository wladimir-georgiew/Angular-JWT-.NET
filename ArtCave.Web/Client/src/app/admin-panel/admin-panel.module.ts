import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateStandComponent } from './create-stand/create-stand.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';


@NgModule({
  declarations: [
    CreateStandComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatSidenavModule,
    RouterModule.forChild([
      { path: 'create-stand', component: CreateStandComponent },
    ])
  ],
  
})
export class AdminPanelModule { }
