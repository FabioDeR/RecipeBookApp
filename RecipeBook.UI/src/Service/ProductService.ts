import { Injectable } from "@angular/core";
import { Product } from "../data/Product";
import { CreateProductResponse } from "../Response/CreateProductResponse";
import { BaseService } from "./BaseService";
import { IProductService } from "./Contract/IProductService";


@Injectable({
  providedIn: 'root'
  })
export class ProductService extends BaseService<Product, CreateProductResponse> implements IProductService {
  override name : string = "Product"
}
