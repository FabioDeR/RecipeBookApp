import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Cut } from '../../../data/Cut';
import { CutService } from '../../../Service/CutService';

@Component({
  selector: 'app-cut-list',
  templateUrl: './cut-list.component.html',
  styleUrls: ['./cut-list.component.css'],
  providers: [CutService]
})
export class CutListComponent implements OnInit {
  allCuts: Cut[] = [];
  filterCuts: Cut[] = [];
  sub!: Subscription;

  cutedit: string = "/cutedit";

  constructor(private cutService: CutService, private toastr: ToastrService) { }
  ngOnInit() {
    this.loadCuts();
  }

  loadCuts(): void {
    this.sub = this.cutService.GetAll().subscribe({
      next: cuts => {
        this.allCuts = cuts
        this.filterCuts = cuts
      }
      })
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filterCuts = list
  }


  DeleteItem(id: string) {
    this.cutService.Delete(id).subscribe({
      next: response => { this.toastr.success("Item a bien été supprimé", "Sucess"); this.loadCuts(); },
      error: err => this.toastr.warning("Une erreur est survenue", "Error")
    })

  }

}
