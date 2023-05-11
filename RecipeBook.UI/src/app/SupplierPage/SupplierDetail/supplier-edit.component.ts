import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Supplier } from '../../../data/Supplier';
import { CreateSupplierResponse } from '../../../Response/CreateSupplierResponse';
import { SupplierService } from '../../../Service/SupplierService';

@Component({
  selector: 'app-supplier-edit',
  templateUrl: './supplier-edit.component.html',
  styleUrls: ['./supplier-edit.component.css']
})
export class SupplierEditComponent implements OnInit {
  supplier = new Supplier()
  createResponse = new CreateSupplierResponse()
  message: string | undefined;
  id: string | undefined;
  sub!: Subscription;
  supplierlist: string = "/supplierlist";

  constructor(private supplierservice: SupplierService, private route: ActivatedRoute, private toast: ToastrService) {

  }
  ngOnInit(): void {
    this.id = String(this.route.snapshot.paramMap.get('id'));
    if (this.id != "null") {
      this.supplierservice.GetDetail(this.id).subscribe({
        next: data => this.supplier = data
      })
    }
  }
  HandleSupplier() {
    if (this.id == 'null') {
      this.sub = (this.supplierservice.Create(this.supplier))
        .subscribe({
          next: (response: CreateSupplierResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.supplier = new Supplier();
          }
        })
    } else {
      this.supplierservice.Update(this.supplier);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }
}
