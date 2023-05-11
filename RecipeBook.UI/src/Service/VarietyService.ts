import { Injectable } from "@angular/core";
import { Variety } from "../data/Variety";
import { CreateVarietyResponse } from "../Response/CreateVarietyResponse";
import { BaseService } from "./BaseService";
import { IVarietyService } from "./Contract/IVarietyService";


@Injectable({
  providedIn: 'root'
  })
export class VarietyService extends BaseService<Variety, CreateVarietyResponse> implements IVarietyService {
  override name: string = "Variety";
}
