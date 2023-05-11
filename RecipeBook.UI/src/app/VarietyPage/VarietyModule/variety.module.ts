import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { ProductService } from "../../../Service/ProductService";
import { VarietyService } from "../../../Service/VarietyService";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { VarietyEditComponent } from "../VarietyDetailPage/variety-edit.component";
import { VarietyListComponent } from "../VarietyListPage/variety-list.component";

@NgModule({
  declarations: [
    VarietyEditComponent,
    VarietyListComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'varietylist', component: VarietyListComponent },
      { path: 'varietyedit', component: VarietyEditComponent },
      { path: 'varietyedit/:id', component: VarietyEditComponent }
    ]),
    SharedModule
  ],
  providers: [VarietyService, ProductService]
})

export class VarietyModule { }
