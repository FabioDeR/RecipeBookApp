import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";


import { ButtonBackComponent } from "../ButtonBack/button-back.component";
import { ButtonPostCommponent } from "../ButtonPost/button-post.component";
import { ButtonRedirectComponent } from "../ButtonRedirect/button-redirect.component";
import { FilterListComponent } from "../FilterListComponent/filter-list.component";
import { DialogEditComponent } from "../DialogEdit/dialog-edit.component";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
@NgModule({
  declarations: [
    ButtonBackComponent,
    ButtonRedirectComponent,
    ButtonPostCommponent,
    FilterListComponent,
    DialogEditComponent
  ],
  imports: [
    CommonModule, 
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    
  ],
  exports: [
    CommonModule,    
    ButtonBackComponent,
    ButtonRedirectComponent,
    ButtonPostCommponent,
    FilterListComponent,
    DialogEditComponent
    ]
  })



export class SharedModule { }
