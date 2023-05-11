import { Injectable } from "@angular/core";
import { Culture } from "../data/Culture";
import { ICultureService } from "./Contract/ICultureService";
import { BaseService } from "./BaseService";
import { CreateCultureResponse } from "../Response/CreateCultureResponse";

@Injectable({
  providedIn: 'root'
})
export class CultureService extends BaseService<Culture, CreateCultureResponse> implements ICultureService {
  override name: string = "Culture";


}
