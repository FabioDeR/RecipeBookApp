import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Category } from '../../../data/Category';
import { CategoryService } from '../../../Service/CategoryService';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  providers: [CategoryService]
})
export class CategoryListComponent implements OnInit {
  allCategories: Category[] = [];
  filterCategories: Category[] = [];
  categoryedit: string = "/categoryedit";
  sub!: Subscription;
 

  constructor(private categoryService: CategoryService, private toast: ToastrService) { }

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




}
