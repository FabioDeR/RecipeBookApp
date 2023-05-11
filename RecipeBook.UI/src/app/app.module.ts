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

@NgModule({
  declarations: [
    AppComponent,  
    WelcomeComponent,
    NavBarComponent,
    MainLayoutComponent, 
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
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-center',
    }),
    CutModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: !isDevMode(),
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    })
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
