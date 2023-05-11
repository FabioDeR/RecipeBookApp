import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Product } from '../../../data/Product';
import { UnitOfMeasurement } from '../../../data/UnitOfMeasurement';
import { CreateProductResponse } from '../../../Response/CreateProductResponse';
import { ProductService } from '../../../Service/ProductService';
import { UnitOfMeasurementService } from '../../../Service/UnitOfMeasurementService';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product = new Product(); 
  message: string = "";
  id: string = "";
  allunits: UnitOfMeasurement[] = [];
  sub!: Subscription;
  productlist: string = "/productedit"

  constructor(private toast: ToastrService, private productservice: ProductService, private route: ActivatedRoute, private unitservice: UnitOfMeasurementService) { }

  ngOnInit(): void {
    this.loadUnitList();
    this.id = String(this.route.snapshot.paramMap.get('id'));
    if (this.id != "null") {
      this.productservice.GetDetail(this.id).subscribe({
        next: data => this.product = data
      })
    }
  }

  HandleProduct() {
    if (this.id == 'null') {
      this.sub = (this.productservice.Create(this.product))
        .subscribe({
          next: (response: CreateProductResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.product = new Product();
          }
        })
    } else {
      this.productservice.Update(this.product);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }

  loadUnitList(): void {
    this.sub = this.unitservice.GetAll().subscribe({
      next: units => { this.allunits = units }, error: err => console.log(err)
    })
  }

  SelectedOption(event: any) {
    console.log(event.target.value);
    this.product.unitid = event.target.value;
  }


}
