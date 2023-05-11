import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../../data/Recipe';
import { Product } from '../../../data/Product';
import { Cut } from '../../../data/Cut';
import { UnitOfMeasurement } from '../../../data/UnitOfMeasurement';
import { RecipeService } from '../../../Service/RecipeBookService';
import { ProductService } from '../../../Service/ProductService';
import { CutService } from '../../../Service/CutService';
import { UnitOfMeasurementService } from '../../../Service/UnitOfMeasurementService';
import { CultureService } from '../../../Service/CultureService';
import { Culture } from '../../../data/Culture';
import { ToastrService } from 'ngx-toastr';
import { CreateRecipeResponse } from '../../../Response/CreateRecipeResponse';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css'],
  providers: [RecipeService, ProductService, CultureService, CutService, UnitOfMeasurementService]
})
export class RecipeEditComponent implements OnInit {
  recipe: Recipe = new Recipe();
  allproducts: Product[] = [];
  allcultures: Culture[] = [];
  allcuts: Cut[] = [];
  allunits: UnitOfMeasurement[] = [];
  recipelist: string = "recipelist";
  sub!: Subscription;

  constructor(private productService: ProductService,
    private recipeService: RecipeService,
    private cultureService: CultureService, private cutService: CutService, private unitService: UnitOfMeasurementService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.LoadAllList();
  }

  LoadAllList(): void {
    this.cultureService.GetAll().subscribe({
      next: cultures => { this.allcultures = cultures }
    })
    this.cutService.GetAll().subscribe({
      next: cuts => this.allcuts = cuts
    })
    this.productService.GetAll().subscribe({
      next: products => this.allproducts = products
    })
    this.unitService.GetAll().subscribe({
      next: units => this.allunits = units
    })
  }

  HandleRecipe(): void {
    console.log(this.recipe)
    this.recipe.quantity = 10.0; 
    this.sub = (this.recipeService.Create(this.recipe))
      .subscribe({
        next: (response: CreateRecipeResponse) => {
          if (response.success) {
            this.toast.success("Item a bien été ajouté", "Sucess");
          }
          else {
            this.toast.error("Une Erreur s'est produit", "Erreur");

          }
          this.recipe = new Recipe();
        }
      })
  }



}
