import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { UnitOfMeasurement } from '../../../data/UnitOfMeasurement';
import { UnitOfMeasurementService } from '../../../Service/UnitOfMeasurementService';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit {
  allunits: UnitOfMeasurement[] = [];
  filteredUnits: UnitOfMeasurement[] = [];
  unitedit: string = "/unitedit";
  sub!: Subscription;


  constructor(private unitservice: UnitOfMeasurementService, private toast: ToastrService) { }


  ngOnInit(): void {
    this.loadUnits();
  }


  loadUnits() {
    this.sub = this.unitservice.GetAll().subscribe({
      next: units => { this.allunits = units, this.filteredUnits = units }, error: err => console.log(err)
    })
  }

  DeleteItem(id: string) {
    this.unitservice.Delete(id).subscribe({
      next: response => { this.toast.success("Item a bien été supprimé", "Sucess"); this.loadUnits(); },
      error: err => this.toast.warning("Une erreur est survenue", "Error")
    });
  }
  onFilterList(list: any): void {
    this.filteredUnits = list
  }

}
