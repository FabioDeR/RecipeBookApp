import { CreateCultureResponse } from "../../Response/CreateCultureResponse";
import { Culture } from "../../data/Culture";
import { IBaseService } from "./IBaseService";

export interface ICultureService extends IBaseService<Culture, CreateCultureResponse> { }
