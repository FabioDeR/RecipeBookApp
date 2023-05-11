import { Observable } from "rxjs";

export interface IBaseService<T,Y>{

  GetAll(name : string): Observable<T[]>;

  GetDetail(id: string): Observable<T>;

  Create(newObject: T): Observable<Y>;

  Update(updateObject: T): void;

  Delete(id: string): void;
}
