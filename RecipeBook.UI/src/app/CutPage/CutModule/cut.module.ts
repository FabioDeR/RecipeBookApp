import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { CutEditComponent } from "../CutDetailPage/cut-edit.component";
import { CutListComponent } from "../CutListPage/cut-list.component";


@NgModule({
  declarations: [
    CutEditComponent,
    CutListComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'cutlist', component: CutListComponent },
      { path: 'cutedit', component: CutEditComponent },
      { path: 'cutedit/:id', component: CutEditComponent }
    ]),
    SharedModule,
  ]
})


export class CutModule { }
