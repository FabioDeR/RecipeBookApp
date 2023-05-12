import { Observable } from "rxjs";
import { CreateIngredientResponse } from "../../Response/CreateIngredientResponse";
import { Ingredient } from "../../data/Ingredient";
import { IBaseService } from "./IBaseService";

export interface IIngredientService extends IBaseService<Ingredient,CreateIngredientResponse> {

  GetAllIngredientByRecipeBookId(recipeId : string): Observable<Ingredient[]>;
}
