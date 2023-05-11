import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Gamme } from '../../../data/Gamme';
import { CreateGammeResponse } from '../../../Response/CreateGammeResponse';
import { GammeService } from '../../../Service/GammeService';


@Component({
  selector: 'app-gamme-edit',
  templateUrl: './gamme-edit.component.html',
  styleUrls: ['./gamme-edit.component.css']
})
export class GammeEditComponent implements OnInit {

  gamme = new Gamme();
  createResponse = new CreateGammeResponse();
  message: string = "";
  id: string | undefined;
  gammelist: string = "/gammelist"
  sub!: Subscription;

  constructor(private gammeservice: GammeService, private route: ActivatedRoute, private toast: ToastrService) { }


  ngOnInit(): void {
    this.id = String(this.route.snapshot.paramMap.get('id'));
    if (this.id != "null") {
      this.gammeservice.GetDetail(this.id).subscribe({
        next: data => this.gamme = data
      })
    }
  }


  HandleGamme() {
    if (this.id == 'null') {
      this.sub = (this.gammeservice.Create(this.gamme))
        .subscribe({
          next: (response: CreateGammeResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.gamme = new Gamme();
          }
        })
    } else {
      this.gammeservice.Update(this.gamme);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }


}
