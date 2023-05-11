import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Cut } from '../../../data/Cut';
import { CreateCutResponse } from '../../../Response/CreateCutResponse';
import { CutService } from '../../../Service/CutService';

@Component({
  selector: 'app-cut-edit',
  templateUrl: './cut-edit.component.html',
  styleUrls: ['./cut-edit.component.css']
})
export class CutEditComponent implements OnInit {
  sub!: Subscription;
  cut: Cut = new Cut;
  createResponse: CreateCutResponse = new CreateCutResponse;

  id: string | undefined;

  cutList: string = "/cutlist";

  constructor(private cutService: CutService, private route: ActivatedRoute, private toast: ToastrService) { }



    ngOnInit(): void {
      this.id = String(this.route.snapshot.paramMap.get('id'));
      if (this.id != 'null') {
        this.cutService.GetDetail(this.id).subscribe({
          next: data => this.cut = data
        })
      }
    }


  


  SubmitCut(): void {
    if (this.id == 'null') {
      this.sub = (this.cutService.Create(this.cut))
        .subscribe({
          next: (response: CreateCutResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");

            }
            this.cut = new Cut();
          }
        })
    } else {
      this.cutService.Update(this.cut);
      this.toast.success("Item a bien été Modifié", "Sucess");
    }
  }

}
