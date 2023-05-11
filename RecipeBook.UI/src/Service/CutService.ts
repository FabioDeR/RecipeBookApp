import { Injectable } from "@angular/core";
import { Cut } from "../data/Cut";
import { CreateCutResponse } from "../Response/CreateCutResponse";
import { BaseService } from "./BaseService";
import { ICutService } from "./Contract/ICutService";

@Injectable({
  providedIn: 'root'
  })

export class CutService extends BaseService<Cut, CreateCutResponse> implements ICutService {
  override name : string = "Cut"

}
