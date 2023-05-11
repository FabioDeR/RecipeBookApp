import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { ProductService } from "../../../Service/ProductService";
import { UnitOfMeasurementService } from "../../../Service/UnitOfMeasurementService";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { ProductEditComponent } from "../ProductEditPage/product-edit.component";
import { ProductListComponent } from "../ProductListPage/product-list.component";

@NgModule({
  declarations: [
    ProductListComponent,
    ProductEditComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'productlist', component: ProductListComponent },
      { path: 'productedit', component: ProductEditComponent },
      { path: 'productedit/:id', component: ProductEditComponent }
    ]),
    SharedModule
  ],
  providers: [ProductService, UnitOfMeasurementService]
})

export class ProductModule { }
