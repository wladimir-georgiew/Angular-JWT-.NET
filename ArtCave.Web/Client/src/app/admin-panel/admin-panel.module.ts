import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateStandComponent } from './create-stand/create-stand.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { CreateCategoryComponent } from './create-category/create-category.component';


@NgModule({
  declarations: [
    CreateStandComponent,
    CreateCategoryComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatSidenavModule,
    RouterModule.forChild([
      { path: 'create-stand', component: CreateStandComponent },
      { path: 'create-category', component: CreateCategoryComponent },
    ])
  ],
  
})
export class AdminPanelModule { }
