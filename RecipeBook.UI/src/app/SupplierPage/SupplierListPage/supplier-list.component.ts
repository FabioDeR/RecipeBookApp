import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription, tap } from 'rxjs';
import { Supplier } from '../../../data/Supplier';
import { SupplierService } from '../../../Service/SupplierService';

@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrls: ['./supplier-list.component.css']
})
export class SupplierListComponent {
  allsupplier: Supplier[] = [];
  filteredSupplier: Supplier[] = [];
  supplieredit: string = "/supplieredit";
  sub!: Subscription;

  constructor(private supplierservice: SupplierService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.LoadSupplierList();
  }
  LoadSupplierList() {
    this.sub = this.supplierservice.GetAll().subscribe({
      next: suppliers => {
        this.allsupplier = suppliers,
        this.filteredSupplier = suppliers
      },
      error: err => console.log(err)
    })
  }

  DeleteItem(id: string) {
    this.supplierservice.Delete(id).subscribe({
      next: response => {
        this.toastr.success("Item a bien été supprimé", "Sucess");
        this.LoadSupplierList();
      },
      error: err => this.toastr.warning("Une erreur est survenue", "Error")
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filteredSupplier = list
  }
}
