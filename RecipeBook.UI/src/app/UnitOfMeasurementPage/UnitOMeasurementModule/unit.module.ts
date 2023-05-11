import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { UnitOfMeasurementService } from "../../../Service/UnitOfMeasurementService";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { UnitEditComponent } from "../UnitOfMeasurementEdit/unit-edit.component";
import { UnitListComponent } from "../UnitOfMeasurementList/unit-list.component";

@NgModule({
  declarations: [
    UnitEditComponent,
    UnitListComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'unitlist', component: UnitListComponent },
      { path: 'unitedit', component: UnitEditComponent },
      { path: 'unitedit/:id', component: UnitEditComponent }
    ]),
    SharedModule
  ],
  providers: [UnitOfMeasurementService]
})




export class UnitModule { }
