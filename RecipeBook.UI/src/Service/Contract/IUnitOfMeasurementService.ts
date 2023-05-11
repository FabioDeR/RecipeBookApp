import { UnitOfMeasurement } from "../../data/UnitOfMeasurement";
import { CreateResponseUnitOfMeasurement } from "../../Response/CreateUnitOfMeasurementResponse";
import { IBaseService } from "./IBaseService";

export interface IUnitOfMeasurementService extends IBaseService<UnitOfMeasurement, CreateResponseUnitOfMeasurement> { }
