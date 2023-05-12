import { Component, Inject, OnInit } from '@angular/core';
import { Ingredient } from '../../../data/Ingredient';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IngredientService } from '../../../Service/IngredientService';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { CreateIngredientResponse } from '../../../Response/CreateIngredientResponse';
import { VarietyService } from '../../../Service/VarietyService';
import { ProductService } from '../../../Service/ProductService';
import { UnitOfMeasurementService } from '../../../Service/UnitOfMeasurementService';
import { Product } from '../../../data/Product';
import { Variety } from '../../../data/Variety';
import { UnitOfMeasurement } from '../../../data/UnitOfMeasurement';

@Component({
  selector: 'app-ingredient-detail',
  templateUrl: './ingredient-detail.component.html',
  styleUrls: ['./ingredient-detail.component.css']
})
export class IngredientDetailComponent implements OnInit {

  ingredient: Ingredient = new Ingredient();
  sub!: Subscription;
  allproducts: Product[] = [];
  allvarieties: Variety[] = [];
  allunits: UnitOfMeasurement[] = [];

  constructor(public dialogRef: MatDialogRef<IngredientDetailComponent>,
    private ingredientService: IngredientService,
    private toast: ToastrService, private varietyService: VarietyService,
    private productService: ProductService, private unitService: UnitOfMeasurementService, @Inject(MAT_DIALOG_DATA) public recipebookId: string) { this.LoadAllList(); }




    ngOnInit(): void {
      this.LoadAllList();
  }


  LoadAllList() {
    this.unitService.GetAll().subscribe({
      next: data => this.allunits = data
    })
    this.productService.GetAll().subscribe({
      next: data => this.allproducts = data
    })
    this.varietyService.GetAll().subscribe({
      next: data => this.allvarieties = data
    })
    }
      
 
  

  SubmitIngredient(): void {
    this.ingredient.recipeId = this.recipebookId;

    console.log("Psot",this.ingredient)
      this.sub = (this.ingredientService.Create(this.ingredient))
        .subscribe({
          next: (response: CreateIngredientResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.ingredient = new Ingredient();
          }
        })     
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
