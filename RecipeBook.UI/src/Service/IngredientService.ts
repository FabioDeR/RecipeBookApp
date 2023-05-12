import { Injectable } from "@angular/core";
import { BaseService } from "./BaseService";
import { Ingredient } from "../data/Ingredient";
import { CreateIngredientResponse } from "../Response/CreateIngredientResponse";
import { IIngredientService } from "./Contract/IIngredientService";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class IngredientService extends BaseService<Ingredient, CreateIngredientResponse> implements IIngredientService {

  override name: string = 'Ingredient';
  GetAllIngredientByRecipeBookId(recipeId: string): Observable<Ingredient[]> {
    return this._http.get<Ingredient[]>(`${this.URL}/${this.name}/ingrendientlistbyrecipebookid/${recipeId}`);
  }
}
