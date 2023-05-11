import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Gamme } from "../data/Gamme";
import { CreateGammeResponse } from "../Response/CreateGammeResponse";
import { BaseService } from "./BaseService";
import { IGammeService } from "./Contract/IGammeService";






@Injectable({
  providedIn: "root"
})
export class GammeService extends BaseService<Gamme, CreateGammeResponse> implements IGammeService  {
  override name: string = "Gamme";
}
