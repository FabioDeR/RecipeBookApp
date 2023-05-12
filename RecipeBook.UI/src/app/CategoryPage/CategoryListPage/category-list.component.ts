import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Category } from '../../../data/Category';
import { CategoryService } from '../../../Service/CategoryService';
import { MatDialog } from '@angular/material/dialog';
import { DialogEditComponent } from '../../Shared/DialogEdit/dialog-edit.component';
import { CreateCategoryResponse } from '../../../Response/CreateCategoryResponse';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  providers: [CategoryService]
})
export class CategoryListComponent implements OnInit {
  allCategories: Category[] = [];
  filterCategories: Category[] = [];
  category: Category = new Category();
  categoryedit: string = "/categoryedit";
  sub!: Subscription;
 

  constructor(private categoryService: CategoryService, private toast: ToastrService, public dialog: MatDialog) { }

  DeleteItem(id: string) {
    this.categoryService.Delete(id).subscribe({
      next: response => { this.toast.success("Item a bien été supprimé", "Sucess"); this.loadCategories(); },
      error: err => this.toast.warning("Une erreur est survenue", "Error")
    })

  }

  ngOnInit(): void {
    this.loadCategories();
  }


  loadCategories(): void {
    this.sub = this.categoryService.GetAll().subscribe({
      next: categories => {
        this.allCategories = categories,
        this.filterCategories = categories
      },
      error: err => console.log(err)
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  onFilterList(list: any): void {
    this.filterCategories = list
  }


  openDialog(): void {
    const dialogRef = this.dialog.open(DialogEditComponent, {
      data: { category : this.category },
    });

    dialogRef.afterClosed().subscribe((result : Category) => {
      if (result != undefined) {
        this.CreateCategory(result)
      }
     
    });
  }

  CreateCategory(result: Category): void {
    this.sub = (this.categoryService.Create(result))
      .subscribe({
        next: (response: CreateCategoryResponse) => {
          if (response.success) {
            this.toast.success("Item a bien été ajouté", "Sucess");
            this.loadCategories();
          }
          else {
            this.toast.error("Une Erreur s'est produit", "Erreur");

          }
          this.category = new Category();
        }
      })
  }

}
