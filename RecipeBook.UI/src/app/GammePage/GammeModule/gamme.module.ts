import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { GammeService } from "../../../Service/GammeService";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { GammeEditComponent } from "../GammeEditPage/gamme-edit.component";
import { GammeListComponent } from "../GammeListPage/gamme-list.component";





@NgModule({
  declarations: [
    GammeListComponent,
    GammeEditComponent  
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    RouterModule.forChild([
    { path: 'gammelist', component: GammeListComponent },
      { path: 'gammeedit', component: GammeEditComponent },
      { path: 'gammeedit/:id', component: GammeEditComponent }
    ]),
    SharedModule
  ],
  providers: [GammeService]
})

export class GammeModule { }
