import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { SupplierService } from "../../../Service/SupplierService";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { SupplierEditComponent } from "../SupplierDetail/supplier-edit.component";
import { SupplierListComponent } from "../SupplierListPage/supplier-list.component";

@NgModule({
  declarations: [
    SupplierEditComponent,
    SupplierListComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'supplierlist', component: SupplierListComponent },
      { path: 'supplieredit', component: SupplierEditComponent },
      { path: 'supplieredit/:id', component: SupplierEditComponent }
    ]),
    SharedModule
  ],
  providers: [SupplierService]
})
export class SupplierModule { }
