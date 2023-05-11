import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";


import { ButtonBackComponent } from "../ButtonBack/button-back.component";
import { ButtonPostCommponent } from "../ButtonPost/button-post.component";
import { ButtonRedirectComponent } from "../ButtonRedirect/button-redirect.component";
import { FilterListComponent } from "../FilterListComponent/filter-list.component";

@NgModule({
  declarations: [
    ButtonBackComponent,
    ButtonRedirectComponent,
    ButtonPostCommponent,
    FilterListComponent
  ],
  imports: [
    CommonModule, 
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    
  ],
  exports: [
    CommonModule,    
    ButtonBackComponent,
    ButtonRedirectComponent,
    ButtonPostCommponent,
    FilterListComponent
    ]
  })



export class SharedModule { }
