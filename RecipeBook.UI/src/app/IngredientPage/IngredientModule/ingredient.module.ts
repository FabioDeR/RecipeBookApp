import { HttpClientModule } from "@angular/common/http";
import { IngredientDetailComponent } from "../IngredientDetail/ingredient-detail.component";
import { IngredientListComponent } from "../IngredientList/ingredient-list.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { RecipeService } from "../../../Service/RecipeBookService";
import { IngredientService } from "../../../Service/IngredientService";
import { VarietyService } from "../../../Service/VarietyService";
import { ProductService } from "../../../Service/ProductService";
import { UnitOfMeasurementService } from "../../../Service/UnitOfMeasurementService";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatDialogModule } from "@angular/material/dialog";
import { BrowserModule } from "@angular/platform-browser";
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    IngredientDetailComponent,
    IngredientListComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'ingredientlist/:id', component: IngredientListComponent }      
    ]),
    SharedModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  providers: [RecipeService, IngredientService, VarietyService, ProductService, UnitOfMeasurementService]
})

export class IngredientModule { }
