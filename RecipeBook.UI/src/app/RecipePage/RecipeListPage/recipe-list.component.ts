import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../../data/Recipe';
import { Subscription } from 'rxjs';

import { ToastrService } from 'ngx-toastr';
import { RecipeService } from '../../../Service/RecipeBookService';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
  providers: [RecipeService]
})
export class RecipeListComponent implements OnInit {
  allrecipes: Recipe[] = [];
  filterRecipes: Recipe[] = [];
  recipeedit: string = "/recipeedit";
  sub!: Subscription;


  constructor(private recipeservice: RecipeService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.LoadRecipeList();
  }
  LoadRecipeList() {
    this.sub = this.recipeservice.GetAll().subscribe({
      next: recipes => {
        this.allrecipes = recipes,
          this.filterRecipes = recipes
      },
      error: err => console.log(err)
    })
  }

  DeleteItem(id: string) {
    this.recipeservice.Delete(id).subscribe({
      next: response => {
        this.toast.success("Item a bien été supprimé", "Sucess");
        this.LoadRecipeList();
      }
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filterRecipes = list
  }
}
