import { Injectable } from "@angular/core";
import { Category } from "../data/Category";
import { CreateCategoryResponse } from "../Response/CreateCategoryResponse";
import { BaseService } from "./BaseService";
import { ICategoryService } from "./Contract/ICategoryService";



@Injectable({
  providedIn : 'root'
  })
export class CategoryService extends BaseService<Category, CreateCategoryResponse> implements ICategoryService {
  override name: string = "Category";

  
}
