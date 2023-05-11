import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Subscription, tap } from "rxjs";
import { Gamme } from "../../../data/Gamme";
import { GammeService } from "../../../Service/GammeService";


@Component({
  selector: 'app-gamme-list',
  templateUrl: './gamme-list.component.html',
  styleUrls: ['./gamme-list.component.css'],
  providers: [GammeService]

})
export class GammeListComponent implements OnInit {

  allGamme: Gamme[] = [];
  filteredGammes: Gamme[] = [];
  nameRoute: string = "Gamme";
  gammeedit: string = "/gammeedit"
  sub!: Subscription;

  constructor(private gammeservice: GammeService, private toast: ToastrService) { }


  ngOnInit(): void {
    this.LoadGammeList();
  }

  

  DeleteItem(id: string) {
    this.gammeservice.Delete(id).subscribe({
      next: response => {
        this.toast.success("Item a bien été supprimé", "Sucess");
        this.LoadGammeList();
      },
      error: error => {
        this.toast.error("Une erreur est survenue", "Error");
      }
      });    
  }

 
  LoadGammeList(): void {
    this.sub = this.gammeservice.GetAll()
      .subscribe({
      next: gammes => {
        this.allGamme = gammes,
        this.filteredGammes = gammes
      },
      error: err => console.log(err)
    }); 

  }  

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filteredGammes = list
  }

}
