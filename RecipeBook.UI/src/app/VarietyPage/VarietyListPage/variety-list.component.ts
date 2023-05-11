import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Variety } from '../../../data/Variety';
import { VarietyService } from '../../../Service/VarietyService';

@Component({
  selector: 'app-variety-list',
  templateUrl: './variety-list.component.html',
  styleUrls: ['./variety-list.component.css'],
  providers: [VarietyService]
})
export class VarietyListComponent implements OnInit {

  allvarieties: Variety[] = [];
  filteredVarieties: Variety[] = [];
  varietyedit: string = "/varietyedit";
  sub!: Subscription

  constructor(private varietyservice: VarietyService, private toast: ToastrService) { }


  ngOnInit(): void {
    this.LoadVarietyList();
  }
  LoadVarietyList() {
    this.sub = this.varietyservice.GetAll().subscribe({
      next: varieties => { this.allvarieties = varieties; this.filteredVarieties = varieties }, error: err => console.log(err)
    })
  }
  DeleteItem(id: string) {
    this.varietyservice.Delete(id).subscribe({
      next: response => { this.toast.success("Item a bien été supprimé", "Sucess"); this.LoadVarietyList(); },
      error: err => this.toast.warning("Une erreur est survenue", "Error")
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  onFilterList(list: any): void {
    this.filteredVarieties = list
  }
}
