import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { UnitOfMeasurement } from '../../../data/UnitOfMeasurement';
import { CreateResponseUnitOfMeasurement } from '../../../Response/CreateUnitOfMeasurementResponse';
import { UnitOfMeasurementService } from '../../../Service/UnitOfMeasurementService';

@Component({
  selector: 'app-unit-edit',
  templateUrl: './unit-edit.component.html',
  styleUrls: ['./unit-edit.component.css']
})
export class UnitEditComponent implements OnInit {

  unit = new UnitOfMeasurement();
  createResponse = new CreateResponseUnitOfMeasurement();
  message: string = "";
  id: string | undefined; 
  sub!: Subscription;

  unitlist: string = "/unitlist"

  constructor(private unitOfMeasurementService: UnitOfMeasurementService, private route: ActivatedRoute, private toast: ToastrService) { }

  ngOnInit(): void {
    this.id = String(this.route.snapshot.paramMap.get('id'));
    if (this.id != "null") {
      this.unitOfMeasurementService.GetDetail(this.id).subscribe({
        next: data => this.unit = data
      })
    }
  }


  HandleUnit(): void {
    if (this.id == 'null') {
      this.sub = (this.unitOfMeasurementService.Create(this.unit))
        .subscribe({
          next: (response: CreateResponseUnitOfMeasurement) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.unit = new UnitOfMeasurement();
          }
        })
    } else {
      this.unitOfMeasurementService.Update(this.unit);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }
}
