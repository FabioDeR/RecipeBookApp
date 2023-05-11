import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MainLayoutComponent } from './Shared/MainLayout/main-layout.component';
import { NavBarComponent } from './Shared/NavigationPage/nav-bar.component';
import { WelcomeComponent } from './homePage/welcome.component';
import { RouterModule } from '@angular/router';
import { GammeModule } from './GammePage/GammeModule/gamme.module';
import { CategoryModule } from './CategoryPage/CategoryModule/category.module';
import { UnitModule } from './UnitOfMeasurementPage/UnitOMeasurementModule/unit.module';
import { ProductModule } from './ProductPage/ProductModule/product.module';
import { SupplierModule } from './SupplierPage/SupplierModule/supplier.module';
import { VarietyModule } from './VarietyPage/VarietyModule/variety.module';
import { CutModule } from './CutPage/CutModule/cut.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ServiceWorkerModule } from '@angular/service-worker';
import { RecipeModule } from './RecipePage/RecipeModule/recipe.module';
import { BaseService } from '../Service/BaseService';
import { IngredientListComponent } from './IngredientPage/IngredientList/ingredient-list.component';
import { IngredientDetailComponent } from './IngredientPage/IngredientDetail/ingredient-detail.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,  
    WelcomeComponent,
    NavBarComponent,
    MainLayoutComponent,
    IngredientListComponent,
    IngredientDetailComponent
   
  ],
  imports: [
    BrowserModule,
    NgbModule,
    RouterModule.forRoot([
      { path: 'welcome', component: WelcomeComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
    ]),
    GammeModule,
    CategoryModule,
    UnitModule,
    ProductModule,
    SupplierModule,
    VarietyModule,
    RecipeModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    CutModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: !isDevMode(),
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    MatSlideToggleModule,
    MatDialogModule
    
    
   

   
  ],
  providers: [BaseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
