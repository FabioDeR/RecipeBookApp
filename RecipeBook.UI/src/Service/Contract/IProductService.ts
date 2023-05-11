import { Product } from "../../data/Product";
import { CreateProductResponse } from "../../Response/CreateProductResponse";
import { IBaseService } from "./IBaseService";

export interface IProductService extends IBaseService<Product, CreateProductResponse> { }
