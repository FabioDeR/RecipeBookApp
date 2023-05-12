import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../../../Service/RecipeBookService';
import { IngredientService } from '../../../Service/IngredientService';
import { Recipe } from '../../../data/Recipe';
import { Ingredient } from '../../../data/Ingredient';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { IngredientDetailComponent } from '../IngredientDetail/ingredient-detail.component';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css']
})
export class IngredientListComponent implements OnInit {
  allingredient: Ingredient[] | null = [];
  id!: string;
  sub!: Subscription;
  recipeName : string =""


  ngOnInit(): void {
    this.id = String(this.route.snapshot.paramMap.get('id'));    
    this.recipeService.GetDetail(this.id).subscribe({
      next: (data: Recipe) => { this.recipeName = data.name }
      });    
    this.LoadIngredients();
  }

  constructor(public dialog: MatDialog,private ingredientService: IngredientService, private recipeService: RecipeService, private route: ActivatedRoute) { }
  openDialog(): void {
    const dialogRef = this.dialog.open(IngredientDetailComponent, {
      width: '450px',
      data: this.id 
    })
    dialogRef.afterClosed().subscribe(data => {
      this.LoadIngredients();
    });
  }
  LoadIngredients() {
    this.sub = (this.ingredientService.GetAllIngredientByRecipeBookId(this.id).subscribe({
      next: data => { this.allingredient = data}
    }))
  }

  

  
}
