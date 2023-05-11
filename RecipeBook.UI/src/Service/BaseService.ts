import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { catchError, Observable, tap } from "rxjs";
import { IBaseService } from "./Contract/IBaseService";



@Injectable({
  providedIn: "root"
})
export class BaseService<T, Y> implements IBaseService<T, Y> {

  protected URL: string = "https://localhost:7091/api"
  protected name: string = "";


  constructor(private http: HttpClient, private toast: ToastrService) {

  }

  GetAll(): Observable<T[]> {
    return this.http.get<T[]>(`${this.URL}/${this.name}`);
  }
  GetDetail(id: string): Observable<T> {
    return this.http.get<T>(`${this.URL}/${this.name}/${id}`);
  }
  Create(newObject: T): Observable<Y> {
    return this.http.post<Y>(`${this.URL}/${this.name}`, newObject)
  }
  Update(updateObject: T): void {
    this.http.put(`${this.URL}/${this.name}`, updateObject)
      .subscribe({ error: err => console.log(err) });
  }


  Delete(id: string): Observable<object> {
    return this.http.delete(`${this.URL}/${this.name}/${id}`);      
  }

}
