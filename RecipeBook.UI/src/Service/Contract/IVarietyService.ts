import { Variety } from "../../data/Variety";
import { CreateVarietyResponse } from "../../Response/CreateVarietyResponse";
import { IBaseService } from "./IBaseService";

export interface IVarietyService extends IBaseService<Variety, CreateVarietyResponse> { }
