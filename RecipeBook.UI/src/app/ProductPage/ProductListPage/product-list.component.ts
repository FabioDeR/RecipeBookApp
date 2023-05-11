import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription, tap } from 'rxjs';
import { Product } from '../../../data/Product';
import { ProductService } from '../../../Service/ProductService';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  allproducts: Product[] = [];
  filterProducts: Product[] = [];
  productedit: string = "/productedit";
  sub!: Subscription;

  constructor(private productservice: ProductService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.LoadProductList();
  }
  LoadProductList() {
    this.sub = this.productservice.GetAll().pipe(tap()).subscribe({
      next: products => {
        this.allproducts = products,
        this.filterProducts = products
      },
      error: err => console.log(err)
    })
  }

  DeleteItem(id: string) {
    this.productservice.Delete(id).subscribe({
      next: response => {
        this.toast.success("Item a bien été supprimé", "Sucess");
        this.LoadProductList();
      }
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filterProducts = list
  }
}
