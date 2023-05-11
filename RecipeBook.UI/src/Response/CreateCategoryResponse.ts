import { Category } from "../data/Category";
import { BaseResponse } from "./BaseResponse";

export class CreateCategoryResponse extends BaseResponse {
  categoryDto: Category | undefined;
}
