import { CreateRecipeResponse } from "../../Response/CreateRecipeResponse";
import { Recipe } from "../../data/Recipe";
import { IBaseService } from "./IBaseService";

export interface IRecipeService extends IBaseService<Recipe, CreateRecipeResponse> { }
