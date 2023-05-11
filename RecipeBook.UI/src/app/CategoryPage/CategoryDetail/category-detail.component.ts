import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription, tap } from 'rxjs';
import { Category } from '../../../data/Category';
import { CreateCategoryResponse } from '../../../Response/CreateCategoryResponse';
import { CategoryService } from '../../../Service/CategoryService';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css'],
  providers: [CategoryService]
})
export class CategoryDetailComponent implements OnInit {
  category: Category = new Category;
  createResponse: CreateCategoryResponse = new CreateCategoryResponse;
  sub!: Subscription;
  id: string | undefined; 

  categorylist: string = "/categorylist";

  constructor(private categoryservice: CategoryService, private route: ActivatedRoute, private toast: ToastrService) { }


  ngOnInit(): void {
    this.id = String(this.route.snapshot.paramMap.get('id'));

    if (this.id != 'null') {
      this.categoryservice.GetDetail(this.id).subscribe({
        next: data => this.category = data
        })
    }

  }

  SubmitCategory(): void {
    if(this.id == 'null') {
      this.sub = (this.categoryservice.Create(this.category))
        .subscribe({
          next: (response: CreateCategoryResponse) => {
            if (response.success) {
              this.toast.success("Item a bien été ajouté", "Sucess");
            }
            else {
              this.toast.error("Une Erreur s'est produit", "Erreur");
              
            }
            this.category = new Category();
          }
        })
    } else {
      this.categoryservice.Update(this.category);
      this.toast.success("Item a bien été Modifié","Sucess");
    }
    
    
  }

  




}
