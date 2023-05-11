
import { Category } from "../../data/Category";
import { CreateCategoryResponse } from "../../Response/CreateCategoryResponse";
import { IBaseService } from "./IBaseService";

export interface ICategoryService extends IBaseService<Category,CreateCategoryResponse> { }
