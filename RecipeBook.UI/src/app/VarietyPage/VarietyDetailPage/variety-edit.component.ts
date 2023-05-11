import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Product } from '../../../data/Product';
import { Variety } from '../../../data/Variety';
import { CreateVarietyResponse } from '../../../Response/CreateVarietyResponse';
import { ProductService } from '../../../Service/ProductService';
import { VarietyService } from '../../../Service/VarietyService';

@Component({
  selector: 'app-variety-edit',
  templateUrl: './variety-edit.component.html',
  styleUrls: ['./variety-edit.component.css'],
  providers: [VarietyService]
})
export class VarietyEditComponent implements OnInit {

  variety: Variety = new Variety();
  varietylist: string = "/varietylist";
  allproducts: Product[] = [];
  sub!: Subscription
  id: string = "";
  productid: string = "";
  message: string = "";
 


  constructor(private toast: ToastrService, private productservice: ProductService, private varietyservice: VarietyService, private router: ActivatedRoute) { }


  ngOnInit(): void {
    this.loadProducts()
    this.id = String(this.router.snapshot.paramMap.get('id'));
    if (this.id != "null") {
      this.varietyservice.GetDetail(this.id).subscribe({
        next: data => { this.variety = data; this.productid = data.productid }, error: err => console.log(err)

      })
    }
  }

  loadProducts() {
    this.sub = this.productservice.GetAll().subscribe({
      next: data => this.allproducts = data, error: err => console.log(err)
    })
  }

  HandleVariety() {
    if (this.id == 'null') {
      this.sub = (this.varietyservice.Create(this.variety))
        .subscribe({
          next: (response: CreateVarietyResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.variety = new Variety();            
          }
        })
    } else {
      this.varietyservice.Update(this.variety);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }

  SelectedOption(event: any) {
    this.variety.productid = event.target.value;
  }



}
