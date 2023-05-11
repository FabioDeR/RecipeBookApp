import { Injectable } from "@angular/core";
import { Supplier } from "../data/Supplier";
import { CreateSupplierResponse } from "../Response/CreateSupplierResponse";
import { BaseService } from "./BaseService";
import { ISupplierService } from "./Contract/ISupplierService";


@Injectable({
  providedIn: 'root'
})
export class SupplierService extends BaseService<Supplier, CreateSupplierResponse> implements ISupplierService {
  override name : string = "Supplier"

}
