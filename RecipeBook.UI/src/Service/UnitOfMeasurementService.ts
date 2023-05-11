import { Injectable } from "@angular/core";
import { UnitOfMeasurement } from "../data/UnitOfMeasurement";
import { CreateResponseUnitOfMeasurement } from "../Response/CreateUnitOfMeasurementResponse";
import { BaseService } from "./BaseService";
import { IUnitOfMeasurementService } from "./Contract/IUnitOfMeasurementService";


@Injectable({
  providedIn: 'root'
  })
export class UnitOfMeasurementService extends BaseService<UnitOfMeasurement, CreateResponseUnitOfMeasurement> implements IUnitOfMeasurementService {
  override name: string = "UnitOfMeasurement";
}
