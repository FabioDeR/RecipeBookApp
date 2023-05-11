import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { RecipeListComponent } from "../RecipeListPage/recipe-list.component";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { RecipeEditComponent } from "../RecipeDetailPage/recipe-edit.component";
import { BrowserModule } from "@angular/platform-browser";



@NgModule({
  declarations: [
    RecipeListComponent,
    RecipeEditComponent
  ],
  imports: [
    HttpClientModule,    
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'recipelist', component: RecipeListComponent },
      { path: 'recipeedit', component: RecipeEditComponent },
      { path: 'recipeedit/:id', component: RecipeEditComponent }
    ]),
    SharedModule
  ]
  
  })



export class RecipeModule { }
