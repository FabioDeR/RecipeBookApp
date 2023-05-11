import { Supplier } from "../../data/Supplier";
import { CreateSupplierResponse } from "../../Response/CreateSupplierResponse";
import { IBaseService } from "./IBaseService";

export interface ISupplierService extends IBaseService<Supplier, CreateSupplierResponse> { }
