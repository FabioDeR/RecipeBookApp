import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../../Shared/SharedModule/shared.module";
import { CategoryDetailComponent } from "../CategoryDetail/category-detail.component";
import { CategoryListComponent } from "../CategoryListPage/category-list.component";


@NgModule({
  declarations: [
    CategoryListComponent,
    CategoryDetailComponent,  
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'categorylist', component: CategoryListComponent },
      { path: 'categoryedit', component: CategoryDetailComponent },
      { path: 'categoryedit/:id', component: CategoryDetailComponent }
    ]),
    SharedModule,   
  ]
})

export class CategoryModule { }
