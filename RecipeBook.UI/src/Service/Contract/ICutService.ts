import { Cut } from "../../data/Cut";
import { CreateCutResponse } from "../../Response/CreateCutResponse";
import { IBaseService } from "./IBaseService";

export interface ICutService extends IBaseService<Cut, CreateCutResponse> { }
