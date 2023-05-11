import { Injectable } from "@angular/core";
import { Recipe } from "../data/Recipe";
import { IRecipeService } from "./Contract/IRecipeRepository";
import { CreateRecipeResponse } from "../Response/CreateRecipeResponse";
import { BaseService } from "./BaseService";

@Injectable({
  providedIn: 'root'
})
export class RecipeService extends BaseService<Recipe, CreateRecipeResponse> implements IRecipeService {
  override name: string = "Recipe"
}
